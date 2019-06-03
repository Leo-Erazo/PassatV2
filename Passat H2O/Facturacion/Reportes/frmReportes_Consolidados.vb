Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports Microsoft.VisualBasic.Strings

Public Class frmReportes_Consolidados
    Dim instancia As New Datos.Users
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmReportes_Consolidados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        carga_combos()

    End Sub

    Sub carga_combos()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("SELECT PeriodoID From Periodos ORDER BY PeriodoID DESC", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    Dim i As Integer = 0

                    Me.cmbPeriodo_ini.Items.Add(0)
                    Me.cmbPeriodo_ini.Items.Item(0) = dr(0)
                    Me.cmbPeriodo_fin.Items.Add(0)
                    Me.cmbPeriodo_fin.Items.Item(0) = dr(0)
                    While dr.Read
                        i += 1
                        Me.cmbPeriodo_ini.Items.Add(i)
                        Me.cmbPeriodo_ini.Items.Item(i) = dr(0)
                        Me.cmbPeriodo_fin.Items.Add(i)
                        Me.cmbPeriodo_fin.Items.Item(i) = dr(0)
                    End While
                End Using
            End Using

            Me.cmbPeriodo_ini.SelectedIndex = Me.cmbPeriodo_ini.Items.Count - 1
            Me.cmbPeriodo_fin.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Lista_facturacion()
        Lista_abonos()
        Lista_Consumo_metros()
    End Sub

    Sub Lista_Consumo_metros()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Consumo_Metros_acumulada_sector_periodo", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    Dim periodo_ini As String
                    Dim periodo_fin As String

                    periodo_ini = Me.cmbPeriodo_ini.Text
                    If periodo_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ini", SqlDbType.VarChar, 6).Value = periodo_ini
                    End If

                    periodo_fin = Me.cmbPeriodo_fin.Text
                    If periodo_fin <> Nothing Then
                        comm.Parameters.Add("@Periodo_fin", SqlDbType.VarChar, 6).Value = periodo_fin
                    End If

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvMetros.DataSource = tabla
                    tabla = Nothing

                End Using
            End Using
            Dim i As Integer = 0
            Dim Metros As Integer = 0

            For i = 0 To Me.dgvMetros.Rows.Count - 1
                Metros += Me.dgvMetros.Item(2, i).Value
            Next
            Me.lblMetros.Text = Metros
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Sub Lista_abonos()
        Dim year_ini, year_fin, mes_ini, mes_fin As String
        Dim Fecha_ini, Fecha_fin As Date

        year_ini = Strings.Left(Me.cmbPeriodo_ini.Text, 4)
        mes_ini = Strings.Right(Me.cmbPeriodo_ini.Text, 2)

        year_fin = Strings.Left(Me.cmbPeriodo_fin.Text, 4)
        mes_fin = Strings.Right(Me.cmbPeriodo_fin.Text, 2)


        Try
            Fecha_ini = "01" & "-" & mes_ini & "-" & year_ini & " 00:00:01"
        Catch ex As Exception
            MsgBox("Por favor verifique el período sea uno válido " & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End Try


        Dim dia_hasta As String = "01"

        Select Case mes_fin
            Case 1, "01", 3, "03", 5, "05", 7, "07", 8, "08", 10, 12
                dia_hasta = "31"
            Case 4, "04", 6, "06", 9, "09", 11
                dia_hasta = "30"
            Case 2, "02"
                If year_fin \ 4 = 0 And year_fin \ 100 <> 0 And year_fin \ 400 = 0 Then
                    dia_hasta = "29"
                Else
                    dia_hasta = "28"
                End If
        End Select

        Try
            Fecha_fin = dia_hasta & "-" & mes_fin & "-" & year_fin & " 23:59:59"
        Catch ex As Exception
            MsgBox("Por favor verifique el período que sea uno válido " & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End Try


        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Abonos_acumulados_sector_periodo", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ini", SqlDbType.DateTime).Value = Fecha_ini
                    comm.Parameters.Add("@Periodo_fin", SqlDbType.DateTime).Value = Fecha_fin
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    ' dr.Read()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvAbonos.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
            Dim i As Integer = 0
            Dim Abonos As Double = 0

            For i = 0 To Me.dgvAbonos.Rows.Count - 1
                Abonos += Me.dgvAbonos.Item(3, i).Value
            Next
            Me.lblSumas_abonos.Text = Abonos


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Sub Lista_facturacion()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_facturacion_acumulada_sector_periodo", conn)
                    comm.CommandType = CommandType.StoredProcedure

                    Dim periodo_ini As String
                    Dim periodo_fin As String

                    periodo_ini = Me.cmbPeriodo_ini.Text
                    If periodo_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ini", SqlDbType.VarChar, 6).Value = periodo_ini
                    End If

                    periodo_fin = Me.cmbPeriodo_fin.Text
                    If periodo_fin <> Nothing Then
                        comm.Parameters.Add("@Periodo_fin", SqlDbType.VarChar, 6).Value = periodo_fin
                    End If

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    ' dr.Read()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvFacturacion.DataSource = tabla
                    tabla = Nothing

                End Using
            End Using
            Dim i As Integer = 0
            Dim facturacion As Double = 0

            For i = 0 To Me.dgvFacturacion.Rows.Count - 1
                facturacion += Me.dgvFacturacion.Item(4, i).Value
            Next
            Me.lblSumas_dolares.Text = facturacion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Function GridAExcel_facturacion() As Boolean
        Dim ElGrid_facturacion As DataGridView = Me.dgvFacturacion

        Dim Fila_encabezado As Integer = 1
        Dim Fila_encabezado_facturacion As Integer = 3
        Dim Encabezados_tabla_facturacion As Integer = 4

        Me.btnExcel.Enabled = False

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol_minimos As Integer = ElGrid_facturacion.ColumnCount
            Dim NRow_minimos As Integer = ElGrid_facturacion.RowCount

            exHoja.Cells.Item(Fila_encabezado, 1) = "Facturación acumulada desde el período " & Me.cmbPeriodo_ini.Text & " hasta " & Me.cmbPeriodo_fin.Text
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14


            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_facturacion, i) = ElGrid_facturacion.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_facturacion + 1, Col + 1) = ElGrid_facturacion.Rows(Fila).Cells(Col).Value
                Next
            Next

            GridAExcel_Abonos(exLibro)

            'Aplicación visible
            exApp.Application.Visible = True
            
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

    Function GridAExcel_Abonos(ByRef exLibro As Microsoft.Office.Interop.Excel.Workbook) As Boolean
        Dim ElGrid_Abonos As DataGridView = Me.dgvAbonos

        Dim Fila_encabezado As Integer = 1
        Dim Fila_encabezado_Abonos As Integer = 3
        Dim Encabezados_tabla_facturacion As Integer = 4

        Me.btnExcel.Enabled = False

        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            '   exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol_minimos As Integer = ElGrid_Abonos.ColumnCount
            Dim NRow_minimos As Integer = ElGrid_Abonos.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            exHoja.Cells.Item(Fila_encabezado, 1) = "Abonos acumulados desde el período " & Me.cmbPeriodo_ini.Text & " hasta " & Me.cmbPeriodo_fin.Text
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14

            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_facturacion, i) = ElGrid_Abonos.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_facturacion + 1, Col + 1) = ElGrid_Abonos.Rows(Fila).Cells(Col).Value
                Next
            Next

            GridAExcel_Metros(exLibro)

            exHoja = Nothing
            exLibro = Nothing

            Me.btnExcel.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Me.btnExcel.Enabled = True
            Return False
        End Try

        Return True

    End Function


    Function GridAExcel_Metros(ByRef exLibro As Microsoft.Office.Interop.Excel.Workbook) As Boolean
        Dim ElGrid_metros As DataGridView = Me.dgvMetros

        Dim Fila_encabezado As Integer = 1
        Dim Encabezados_tabla_facturacion As Integer = 4

        Me.btnExcel.Enabled = False

        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            '   exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol_minimos As Integer = ElGrid_metros.ColumnCount
            Dim NRow_minimos As Integer = ElGrid_metros.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            exHoja.Cells.Item(Fila_encabezado, 1) = "Metros cúbicos acumulados desde el período " & Me.cmbPeriodo_ini.Text & " hasta " & Me.cmbPeriodo_fin.Text
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14

            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_facturacion, i) = ElGrid_metros.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_facturacion + 1, Col + 1) = ElGrid_metros.Rows(Fila).Cells(Col).Value
                Next
            Next


            exHoja = Nothing
            exLibro = Nothing

            Me.btnExcel.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Me.btnExcel.Enabled = True
            Return False
        End Try

        Return True

    End Function

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        GridAExcel_facturacion()
    End Sub
End Class