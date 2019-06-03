Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmImprime_saldos_asociado
    Dim oRpt As New rptSaldos_socio
    Dim instancia As New Datos.Users
    Public Socio_ID As Integer
    Public periodo_ini As String
    Public periodo_fin As Integer


    Private Sub frmImprime_abonos_historicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_grid()
    End Sub

    Sub Carga_grid()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_saldos_socio", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    If Socio_ID <> 0 Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    End If
                    If periodo_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ini", SqlDbType.Int).Value = periodo_ini
                    End If

                    If periodo_fin <> 0 Then
                        comm.Parameters.Add("@Periodo_fin", SqlDbType.Int).Value = periodo_fin
                    End If

                    Dim adapter As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    adapter.Fill(ds, "Saldos_socio")

                    oRpt.SetDataSource(ds)
                    Me.CrySaldos_Socio.ReportSource = oRpt
                    Me.CrySaldos_Socio.Zoom(85)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
End Class