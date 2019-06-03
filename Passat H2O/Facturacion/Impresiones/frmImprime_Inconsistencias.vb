Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmImprime_Inconsistencias
    Public periodo As String

    Dim oRpt As New rptInconsistencias
    Dim instancia As New Datos.Users


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmImprime_Inconsistencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Inconsistencias_historico", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = periodo

                    Dim da As New SqlDataAdapter(comm)

                    Dim ds As New DataSet
                    da.Fill(ds, "Inconsistencias")
                    oRpt.SetDataSource(ds)
                    Me.CryInconsistencias.ReportSource = oRpt
                    Me.CryInconsistencias.Zoom(85)

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub
End Class