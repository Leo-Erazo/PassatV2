Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmImprime_Pagos_del_dia
    Dim oRpt As New CryPagosDelDia ' Cambiar esta línea
    Dim instancia As New Datos.Users

    Private Sub frmImprime_Pagos_del_dia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            Dim dia As Date
            dia = Me.dtpDia.Value.ToShortDateString

            Me.MdiParent = My.Forms.frmPrincipal
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Cobros_Del_Dia", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@DIA", SqlDbType.Date).Value = dia
                    Dim da As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    da.Fill(ds, "Pagos")

                    oRpt.SetDataSource(ds)
                    Me.CryPagosDelDia.ReportSource = oRpt
                    Me.CryPagosDelDia.Zoom(85)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub
End Class