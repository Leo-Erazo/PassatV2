Imports Passat_H2O.Datos.Users

Public Class frmAnula_extraordinaria
    Dim instancia As New Datos.Users
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub frmAnula_extraordinaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim factura_num As Integer = 0

        Dim respuesta As Integer

        If Me.txtFactura_num.Text <> Nothing Then
            Try
                factura_num = CType(Me.txtFactura_num.Text, Integer)

            Catch ex As Exception
                MsgBox("El número de factura no es un valor válido!", MsgBoxStyle.Exclamation, "Anulando penalización")
                Exit Sub
            End Try

        End If

        respuesta = MsgBox("La anulación no se puede revertir. Desea continuar con la anulación?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Anulando documento")
        If respuesta = 6 Then
            Anula_penalidad(factura_num)
        Else
            MsgBox("Proceso cancelado. No se anuló la factura.", MsgBoxStyle.Information)
        End If
    End Sub

    Sub Anula_penalidad(ByVal factura_num As Integer)

        Try
            Using conn As New SqlClient.SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlClient.SqlCommand("sp_Anula_penalidad_extraordinaria", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = factura_num
                    Dim dr As SqlClient.SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    MsgBox(dr(0), MsgBoxStyle.Information, "Anulando documento")
                    dr.Close()

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class