Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmRepo_Ingresos_mes_consolidado
    Dim oRpt As New CryAbonosConsolidadosMes
    Dim instancia As New Datos.Users

    Private Sub frmRepo_Ingresos_mes_consolidado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        For i = 2000 To 2200
            Me.cmbYear.Items.Add(i)
        Next
        Me.cmbYear.SelectedIndex = 0
        Me.cmbMes.SelectedIndex = 0
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Sub Genera_informe(ByVal mes As Integer, ByVal year As Integer)
        Try

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Cobros_Del_Mes", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@year", SqlDbType.Int).Value = year
                    comm.Parameters.Add("@mes", SqlDbType.Int).Value = mes
                    Dim da As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    da.Fill(ds, "Abonos")

                    oRpt.SetDataSource(ds)
                    Me.CryAbonosConsolidados.ReportSource = oRpt
                    Me.CryAbonosConsolidados.Zoom(85)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Genera_informe(Me.cmbMes.Text, Me.cmbYear.Text)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class