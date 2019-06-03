Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmVerifica_inconsistencia
    Dim instancia As New Datos.Users
    Public _periodo_ID As String

    Private Sub frmVerifica_inconsistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Activated
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_listados()
    End Sub

    Sub Carga_listados()
        Try
            'Los de consumo nulo o negativo
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_consumos_negativos", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = _periodo_ID
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvConsumo_negativo.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

        If Me.dgvConsumo_negativo.Rows.Count > 0 Then
            Me.lblNegativas.Text = Me.dgvConsumo_negativo.Rows.Count
        Else
            Me.lblNegativas.Text = 0
        End If

        'Los de consumo elevado
        Dim _porciento As Decimal

        If Me.txtPorciento.Text = String.Empty Then _porciento = 10
        _porciento = CType(Me.txtPorciento.Text, Decimal)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_consumos_elevados", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = _periodo_ID
                    comm.Parameters.Add("@Porcentaje", SqlDbType.Decimal, 2).Value = _porciento

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvConsumo_elevado.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

        If Me.dgvConsumo_elevado.Rows.Count > 0 Then
            Me.lblCuentasExceso.Text = Me.dgvConsumo_elevado.Rows.Count
        Else
            Me.lblCuentasExceso.Text = 0
        End If

    End Sub

    Sub Consumo_excesivo(ByVal porcentaje As Decimal)

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_consumos_elevados", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = _periodo_ID
                    comm.Parameters.Add("@Porcentaje", SqlDbType.Decimal, 2).Value = porcentaje

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvConsumo_elevado.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnRecalcula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalcula.Click
        Dim porcentaje As Decimal

        If Me.txtPorciento.Text = String.Empty Then
            porcentaje = 0
        Else
            Try
                porcentaje = CType(Me.txtPorciento.Text, Decimal)
            Catch ex As Exception
                MsgBox("Verifique que el valor esté entre 0 y 100", MsgBoxStyle.Exclamation, "Pasat H2O")
                Exit Sub
            End Try
        End If
        Consumo_excesivo(porcentaje)

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        My.Forms.frmIngreso_lecturas.btnFinalizar_lecturas.Enabled = True
        Me.Close()
    End Sub

    Private Sub txtPorciento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorciento.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnRecalcula.PerformClick()
        End If
    End Sub



    Function GridAExcel() As Boolean
        Dim ElGrid_minimos As DataGridView = Me.dgvConsumo_negativo
        Dim ElGrid_maximos As DataGridView = Me.dgvConsumo_elevado

        Dim Fila_encabezado As Integer = 1
        Dim Fila_encabezado_consumo_minimo As Integer = 3
        Dim Encabezados_tabla_minimos As Integer = 4

        Me.btnExcel.Enabled = False

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol_minimos As Integer = ElGrid_minimos.ColumnCount
            Dim NRow_minimos As Integer = ElGrid_minimos.RowCount


            Dim NCol_maximos As Integer = ElGrid_maximos.ColumnCount
            Dim NRow_maximos As Integer = ElGrid_maximos.RowCount


            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            exHoja.Cells.Item(Fila_encabezado, 1) = "Reporte de inconsistencias para las lecturas del período " & _periodo_ID
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14


            exHoja.Cells.Item(Fila_encabezado_consumo_minimo, 1) = "Cuentas con lecturas iguales o inferiores a las del período anterior."

            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_minimos, i) = ElGrid_minimos.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_minimos).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_minimos + 1, Col + 1) = ElGrid_minimos.Rows(Fila).Cells(Col).Value
                Next
            Next

            Dim Encabezado_Maximos As Integer = Encabezados_tabla_minimos + NRow_minimos + 2

            exHoja.Cells.Item(Encabezado_Maximos, 1) = "Cuentas con consumos por encima del " & Me.txtPorciento.Text & " % con respecto al período anterior."
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            'ajuste al texto
            ' exHoja.Rows.Item(1).Font.Bold = 1
            'exHoja.Rows.Item(1).HorizontalAlignment = 3
            'exHoja.Columns.AutoFit()
            For i As Integer = 1 To NCol_maximos
                exHoja.Cells.Item(Encabezado_Maximos + 1, i) = ElGrid_maximos.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezado_Maximos + 1).Font.Italic = 2

            For Fila As Integer = 0 To NRow_maximos - 1
                For Col As Integer = 0 To NCol_maximos - 1
                    exHoja.Cells.Item(Fila + Encabezado_Maximos + 2, Col + 1) = ElGrid_maximos.Rows(Fila).Cells(Col).Value
                Next
            Next


            'Aplicación visible
            exApp.Application.Visible = True
            Dim columna As Integer = 2
            For columna = 2 To 8
                exHoja.Columns.Item(columna).AutoFit()
            Next


            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

            Me.btnExcel.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Me.btnExcel.Enabled = True
            Return False
        End Try

        Return True

    End Function

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        GridAExcel()
    End Sub
End Class