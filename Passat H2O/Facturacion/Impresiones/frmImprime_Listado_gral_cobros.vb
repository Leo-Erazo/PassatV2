Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmImprime_Listado_gral_cobros
    Dim oRpt As New rptListado_Cobros_Del_Periodo ' Cambiar esta línea
    Dim instancia As New Datos.Users
    Public Periodo_ID_ As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmImprime_Listado_gral_cobros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = My.Forms.frmPrincipal
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Cobros_Facturados_Mes", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Me.Periodo_ID_
                    Dim da As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    da.Fill(ds, "Listado_cobros")

                    oRpt.SetDataSource(ds)
                    Me.CryCobros_del_mes.ReportSource = oRpt
                    Me.CryCobros_del_mes.Zoom(85)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub
End Class