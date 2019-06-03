Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmReciboCtaAhorro
    Dim oRpt As New CryReciboCtaAhorro
    Dim instancia As New Datos.Users
    Public Transac_Num, Cta_num As Integer

    Private Sub frmImprime_Recibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim ds As New DataSet
                Using comm As New SqlCommand(String.Format("sp_Imprime_Recibo_CtaAhorro"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("Transac_Num", SqlDbType.Int).Value = Transac_Num
                    comm.Parameters.Add("Cta_Num", SqlDbType.Int).Value = Cta_num

                    Dim da As New SqlDataAdapter(comm)
                    da.Fill(ds, "ReciboCtaAhorro")
                End Using

                oRpt.SetDataSource(ds)
                Me.CryReciboCtaAhorro.ReportSource = oRpt
                Me.CryReciboCtaAhorro.Zoom(85)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        'My.Forms.frmFacturas_listado.Activate()
    End Sub
End Class