Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmImprime_factura_manual
    Dim oRpt As New CryFactura_Manual
    Dim instancia As New Datos.Users

    Private Sub frmImprime_factura_manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim ds As New DataSet

                Using comm As New SqlCommand(String.Format("sp_Imprime_Factura_Manual"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Factura_Num", SqlDbType.Int).Value = CType(Me.Tag, Integer)
                    Dim da As New SqlDataAdapter(comm)
                    da.Fill(ds, "Factura")
                End Using

                oRpt.SetDataSource(ds)
                Me.CryFactura_manual.ReportSource = oRpt
                Me.CryFactura_manual.Zoom(85)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub
End Class