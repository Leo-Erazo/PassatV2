Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmImprime_Recibo
    Dim oRpt As New CryRecibo
    Dim instancia As New Datos.Users
    Public Transac_Num, Factura_num As Integer
    Public saldo_anterior As Double

    Private Sub frmImprime_Recibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim ds As New DataSet
                Using comm As New SqlCommand(String.Format("sp_Imprime_Recibo_Pago"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Transac_num_abono", SqlDbType.Int).Value = Transac_Num
                    comm.Parameters.Add("@Factura_Num", SqlDbType.Int).Value = Factura_num
                    comm.Parameters.Add("@Saldo_anterior", SqlDbType.Decimal, 2).Value = saldo_anterior

                    Dim da As New SqlDataAdapter(comm)
                    da.Fill(ds, "Recibo")
                End Using

                oRpt.SetDataSource(ds)
                Me.CryRecibo.ReportSource = oRpt
                Me.CryRecibo.Zoom(85)

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