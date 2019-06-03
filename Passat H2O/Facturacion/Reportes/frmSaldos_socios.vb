Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Strings

Public Class frmSaldos_socios
    Dim instancia As New Datos.Users

    Private Sub frmSaldos_socios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Try
            Carga_lista(Me.txtSocio_ID.Text, Me.txtPeriodo_ini.Text, Me.txtPeriodo_fin.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.txtSocio_ID.Focus()
    End Sub

    Sub Carga_lista(ByVal Socio_ID As String, ByVal periodo_ini As String, ByVal periodo_fin As String)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Saldos_socio", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    If Socio_ID <> Nothing Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    End If
                    If periodo_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ini", SqlDbType.VarChar, 6).Value = periodo_ini
                    End If

                    If periodo_fin <> Nothing Then
                        comm.Parameters.Add("@Periodo_fin", SqlDbType.VarChar, 6).Value = periodo_fin
                    End If

                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSaldos.DataSource = tabla
                    tabla = Nothing
                    Me.lblLineas_mostradas.Text = Me.dgvSaldos.Rows.Count
                End Using
            End Using

            Dim i As Integer = 0
            Dim saldos_totales As Double = 0
            Dim cargos_totales As Double = 0

            For i = 0 To Me.dgvSaldos.Rows.Count - 1
                saldos_totales += CType(Me.dgvSaldos.Item(9, i).Value, Decimal)
                cargos_totales += CType(Me.dgvSaldos.Item(8, i).Value, Decimal)

            Next

            Me.lblSumas.Text = Microsoft.VisualBasic.Strings.FormatCurrency(saldos_totales, 2)
            Me.tslblTotalCargos.Text = Microsoft.VisualBasic.Strings.FormatCurrency(cargos_totales, 2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Try
            Carga_lista(Me.txtSocio_ID.Text, Me.txtPeriodo_ini.Text, Me.txtPeriodo_fin.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvSaldos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaldos.CellClick
        Me.txtSocio_ID.Text = Me.dgvSaldos.SelectedCells(4).Value
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        GridAExcel_facturacion(Me.dgvSaldos)
    End Sub

    Function GridAExcel_facturacion(ByVal elGrid As DataGridView) As Boolean

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
            Dim NCol_minimos As Integer = elGrid.ColumnCount
            Dim NRow_minimos As Integer = elGrid.RowCount

            exHoja.Cells.Item(Fila_encabezado, 1) = "Saldos del asociado al " & Date.Now
            exHoja.Rows.Item(Fila_encabezado).Font.Bold = 2
            exHoja.Rows.Item(Fila_encabezado).Font.size = 14


            For i As Integer = 1 To NCol_minimos
                exHoja.Cells.Item(Encabezados_tabla_facturacion, i) = elGrid.Columns(i - 1).Name.ToString
            Next
            exHoja.Rows.Item(Encabezados_tabla_facturacion).Font.Italic = 2

            For Fila As Integer = 0 To NRow_minimos - 1
                For Col As Integer = 0 To NCol_minimos - 1
                    exHoja.Cells.Item(Fila + Encabezados_tabla_facturacion + 1, Col + 1) = elGrid.Rows(Fila).Cells(Col).Value
                Next
            Next

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

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            If Me.txtSocio_ID.Text <> Nothing Then
                My.Forms.frmImprime_saldos_asociado.Socio_ID = Me.txtSocio_ID.Text
            Else
                My.Forms.frmImprime_saldos_asociado.Socio_ID = 0
            End If

            If Me.txtPeriodo_ini.Text <> Nothing Then
                My.Forms.frmImprime_saldos_asociado.periodo_ini = Me.txtPeriodo_ini.Text
            Else
                My.Forms.frmImprime_saldos_asociado.periodo_ini = 201501
            End If


            If Me.txtPeriodo_fin.Text <> Nothing Then
                My.Forms.frmImprime_saldos_asociado.periodo_fin = Me.txtPeriodo_fin.Text
            Else
                My.Forms.frmImprime_saldos_asociado.periodo_fin = 0
            End If

            My.Forms.frmImprime_saldos_asociado.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try

    End Sub
End Class