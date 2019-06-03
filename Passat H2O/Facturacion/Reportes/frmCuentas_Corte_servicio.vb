Imports System.Data
Imports System.Data.SqlClient

Public Class frmCuentas_Corte_servicio
    Dim instancia As New Datos.Users

    Private Sub frmCuentas_Corte_servicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_lista()
    End Sub

    Sub Carga_lista()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Cuentas_Corte_Servicio", conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvCuentas.DataSource = tabla
                    Me.dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    Me.dgvCuentas.Columns(3).DefaultCellStyle.Format = "c"
                    Me.dgvCuentas.Columns(4).DefaultCellStyle.Format = "c"
                    Me.dgvCuentas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.dgvCuentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvCuentas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    tabla = Nothing
                    Me.lblLineas_mostradas.Text = Me.dgvCuentas.Rows.Count

                    If Me.dgvCuentas.Rows.Count = 0 Then
                        MsgBox("No hay cuentas para cortar el servicio de agua.", MsgBoxStyle.Information, "iLeon Pasat h2o")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInforme.Click
        Try
            My.Forms.frmImprime_corte_servicio.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub
End Class