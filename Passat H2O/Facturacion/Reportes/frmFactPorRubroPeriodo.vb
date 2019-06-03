Imports System
Imports System.Data.SqlClient
'Imports Passat_H2O.Datos
Imports Microsoft.VisualBasic


Public Class frmFactPorRubroPeriodo
    Dim instancia As New Datos.Users
    Dim periodo As String = ""

    Private Sub frmFactPorRubroPeriodo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.frmSubTotalesReport1.Close()
    End Sub


    Private Sub frmFactPorRubroPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Dock = DockStyle.Fill
        Me.txtPeriodo_ID.Focus()
    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Me.dgvDatos.DataSource = Nothing
        If Me.txtPeriodo_ID.Text = Nothing Then Exit Sub

        periodo = Me.txtPeriodo_ID.Text
        If Verifica_existe_periodo(periodo) = True Then
            Carga_lista_existente(periodo)
            Me.dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Else
            Exit Sub
        End If
    End Sub


    Function Verifica_existe_periodo(ByVal Periodo As String) As Boolean
        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Estado From periodos WHERE PeriodoID = '{0}'", Periodo), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            If dr(0).ToString <> Nothing Then
                                Return True
                            Else
                                MsgBox("El período no existe!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
                                Return False 'No Existe
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox("El período no se ha podido verificar! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function


    Sub Carga_lista_existente(ByVal Periodo As String)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(("sp_Lista_Cobros_Facturados_MesII"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Periodo
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvDatos.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

        cambia_encabezados()
    End Sub


    Sub cambia_encabezados()
        Dim columnas_totales As Integer
        columnas_totales = Me.dgvDatos.Columns.Count 'Cuatro con las columnas de la izquierda. El resto son los rubros

        Dim i As Integer
        Dim y As Integer
        Dim texto_totales As String = Nothing
        Dim texto_encabezado As String

        Try

            For i = 4 To columnas_totales - 2 'Para evitar que renombre el total
                Dim encabezado As String
                encabezado = Me.dgvDatos.Columns(i).HeaderText
                Dim item As Integer = CInt(Microsoft.VisualBasic.Mid(encabezado, 2))

                Try
                    Using conn As New SqlConnection(instancia.pCadena_conexion)
                        conn.Open()
                        Using comm As New SqlCommand(("sp_Lee_rubro_report1"), conn)
                            comm.CommandType = CommandType.StoredProcedure
                            comm.Parameters.Add("@item", SqlDbType.Int).Value = item
                            Dim dr As SqlDataReader = comm.ExecuteReader
                            dr.Read()
                            texto_encabezado = dr(0)
                            Me.dgvDatos.Columns(i).HeaderText = texto_encabezado
                        End Using
                    End Using

                    Dim subtotal As Decimal = 0
                    For y = 0 To Me.dgvDatos.Rows.Count - 1
                        subtotal = subtotal + Me.dgvDatos.Item(i, y).Value
                    Next

                    texto_totales = texto_totales & "Total para " & texto_encabezado & String.Format(": $ {0}", subtotal) & vbCrLf

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat")
                End Try
            Next

            Dim Total As Decimal = 0
            For y = 0 To Me.dgvDatos.Rows.Count - 1
                Total = Total + Me.dgvDatos.Item(Me.dgvDatos.Columns.Count - 1, y).Value
            Next

            texto_totales = texto_totales & "TOTAL: $" & String.Format("{0}", Total) & vbCrLf

            If My.Forms.frmSubTotalesReport1.Visible = True Then
                My.Forms.frmSubTotalesReport1.BringToFront()
            Else
                My.Forms.frmSubTotalesReport1.Show()
            End If

            Me.lbltotalFilas.Text = Me.dgvDatos.Rows.Count

            My.Forms.frmSubTotalesReport1.txtSubtotales.Text = texto_totales
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat")
        End Try

    End Sub




    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        GridAExcel_facturacion()
    End Sub


    Function GridAExcel_facturacion() As Boolean
        Dim ElGrid_facturacion As DataGridView = Me.dgvDatos

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

            exHoja.Cells.Item(Fila_encabezado, 1) = "Facturación del período por abonado y rubro facturado."
            exHoja.Cells.Item(2, 1) = "Período: " & Me.txtPeriodo_ID.Text
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14

            Dim i As Integer = 1

            For i = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_facturacion, i) = ElGrid_facturacion.Columns(i - 1).HeaderText.ToString
            Next
            
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.Italic = 2
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.bold = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                Dim total_fila As Decimal = 0
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_facturacion + 1, Col + 1) = ElGrid_facturacion.Rows(Fila).Cells(Col).Value
                Next
            Next

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

End Class