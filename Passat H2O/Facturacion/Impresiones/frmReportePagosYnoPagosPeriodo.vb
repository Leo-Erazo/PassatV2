Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmReportePagosYnoPagosPeriodo
    Dim oRpt As New CryPagosYnoPagosPeriodo
    Dim instancia As New Datos.Users

    Private Sub frmReportePagosYnoPagosPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      
        Genera_informe(Me.txtPeriodo_ID.Text, Me.txtPeriodo_hasta.Text)
    End Sub

    Sub Genera_informe(ByVal periodo_ini As String, ByVal periodo_fin As String)
        Try

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Pagos_Y_NoPagos_Periodo", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    If periodo_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ID_ini", SqlDbType.VarChar, 6).Value = periodo_ini
                    End If
                    If periodo_fin <> Nothing Then
                        comm.Parameters.Add("@Periodo_ID_fin", SqlDbType.VarChar, 6).Value = periodo_fin
                    End If

                    Dim da As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    da.Fill(ds, "PagosImpagos")

                    oRpt.SetDataSource(ds)
                    Me.CryPagosYnoPagos.ReportSource = oRpt
                    Me.CryPagosYnoPagos.Zoom(85)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub
End Class