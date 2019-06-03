Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmAltos_Y_Bajos
    Dim Instancia As New Datos.Users
    Dim _periodo_ID As String

    Private Sub frmAltos_Y_Bajos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtPeriodo_ID.Focus()
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Carga_listado(Me.txtPeriodo_ID.Text)
    End Sub

    Sub Carga_listado(ByVal Periodo As String)
        If Periodo = String.Empty Then Exit Sub
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Inconsistencias_historico", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.Int).Value = Periodo
                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvLecturas.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using

            Me.lblCuenta.Text = Me.dgvLecturas.Rows.Count

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If Me.dgvLecturas.Rows.Count = 0 Then Exit Sub
        GridAExcel()
    End Sub

    Function GridAExcel() As Boolean
        Dim ElGrid_minimos As DataGridView = Me.dgvLecturas

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
            _periodo_ID = Me.txtPeriodo_ID.Text

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            exHoja.Cells.Item(Fila_encabezado, 1) = "Reporte de inconsistencias para las lecturas del período " & _periodo_ID
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14


            'exHoja.Cells.Item(Fila_encabezado_consumo_minimo, 1) = "Cuentas con lecturas iguales o inferiores a las del período anterior."

            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_minimos, i) = ElGrid_minimos.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_minimos).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_minimos + 1, Col + 1) = ElGrid_minimos.Rows(Fila).Cells(Col).Value
                Next
            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            'ajuste al texto
            ' exHoja.Rows.Item(1).Font.Bold = 1
            'exHoja.Rows.Item(1).HorizontalAlignment = 3
            'exHoja.Columns.AutoFit()


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

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        My.Forms.frmImprime_Inconsistencias.periodo = Me.txtPeriodo_ID.Text
        My.Forms.frmImprime_Inconsistencias.Show()
    End Sub
End Class