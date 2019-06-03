Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmImprime_corte_servicio
    Dim oRpt As New CryCorte_servicio
    Dim instancia As New Datos.Users

    Private Sub frmImprime_corte_servicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim ds As New DataSet

                Using comm As New SqlCommand(String.Format("sp_Lista_Cuentas_Corte_Servicio"), conn)
                    Dim da As New SqlDataAdapter(comm)
                    da.Fill(ds, "Corte_Servicio")
                End Using

                oRpt.SetDataSource(ds)
                Me.CrystalReportViewer1.ReportSource = oRpt
                Me.CrystalReportViewer1.Zoom(85)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class