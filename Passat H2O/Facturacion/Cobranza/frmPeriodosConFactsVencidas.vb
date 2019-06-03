Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmPeriodosConFactsVencidas
    Dim instancia As New Datos.Users

    Private Sub frmPeriodosConFactsVencidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("sp_Lista_periodos_facturas_vencidas", conn)
                comm.CommandType = CommandType.Text

                Dim da As New SqlDataAdapter(comm)
                Dim ds As New DataSet

                da.Fill(ds, 0)
                Me.dgvPeriodos.DataSource = ds.Tables(0)


            End Using
        End Using
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgvPeriodos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodos.CellDoubleClick
        Dim periodo As Integer = 0
        Try
            periodo = Me.dgvPeriodos.SelectedCells(0).Value
            My.Forms.frmPenaliza_masiva.periodo = periodo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
        Me.Close()
    End Sub
End Class