Imports System.Data.SqlClient
Imports Passat_H2O.Datos.Users
Imports System.Windows.Forms

Public Class frmImprime_facturas
    Dim oRpt As New CryFacturas_individuales
    Dim instancia As New Datos.Users

    Private Sub frmImprime_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim ds As New DataSet

                Using comm As New SqlCommand(String.Format("EXEC sp_Lista_Emision_Facturas '{0}'", Me.Tag.ToString), conn)
                    Dim da As New SqlDataAdapter(comm)
                    da.Fill(ds, "Facturacion_Encabezado")
                End Using

                oRpt.SetDataSource(ds)
                Me.CryFacturas.ReportSource = oRpt
                Me.CryFacturas.Zoom(85)

                Using comm As New SqlCommand(String.Format("UPDATE Lecturas_encabezado Set Estado = 'Impreso' WHERE Periodo_ID =  '{0}'", Me.Tag.ToString), conn)
                    comm.ExecuteNonQuery()
                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class