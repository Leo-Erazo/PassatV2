

Public Class frmSociosInactivos

    Private Sub frmSociosInactivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim instancia As New Datos.Users

        Try
            Me.MdiParent = My.Forms.frmPrincipal
            Using conn As New SqlClient.SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlClient.SqlCommand("Select Socio_ID, Propietario, Inquilino, Direccion_fisica From socios SO WHERE Estado = 0", conn)
                    Dim dr As SqlClient.SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvDatos.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
            If Me.dgvDatos.Rows.Count <> 0 Then
                Me.lblTotalLineas.Text = Me.dgvDatos.Rows.Count
            Else
                Me.lblTotalLineas.Text = "0"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class