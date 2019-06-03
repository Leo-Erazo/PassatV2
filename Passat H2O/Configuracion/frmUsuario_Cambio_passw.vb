Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmUsuario_Cambio_passw
    Dim instancia As New Datos.Users
    Dim nombre, user_tipo, pass_actual, pass_nuevo As String

    Private Sub frmUsuario_Cambio_passw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Dim usuario As New Datos.Users

        Me.txtUsuario_id.Text = usuario.pUsuario_conectado
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Nombre, Passw, Tipo From Usuarios WHERE Usuario_ID = '{0}'", usuario.pUsuario_conectado), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            Me.txtNombre.Text = dr(0)
                            pass_actual = dr(1)
                            Me.txtTipoUsuario.Text = dr(2)
                            Me.txtPass_actual.Focus()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub txtPasswConfirma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPasswConfirma.TextChanged
        If Me.txtPassNuevo.Text = String.Empty Then Exit Sub
        If Me.txtPasswConfirma.Text = Me.txtPassNuevo.Text Then
            Me.lblCoinciden.Text = "Coinciden!"
        Else
            Me.lblCoinciden.Text = "No Coinciden!"
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Me.txtPass_actual.Text <> pass_actual Then
                MsgBox("La contraseña actual no es correcta.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Me.txtPass_actual.Focus()
                Me.txtPassNuevo.Clear()
                Me.txtPasswConfirma.Clear()
                Exit Sub
            End If

            If Me.txtPass_actual.Text <> pass_actual Then
                MsgBox("Las contraseña nuevas no coinciden.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Exit Sub
            Else
                pass_nuevo = Me.txtPassNuevo.Text
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("UPDATE Usuarios SET Passw = '{2}'  WHERE Usuario_ID = '{0}' AND Passw = '{1}'", Me.txtUsuario_id.Text, pass_actual, pass_nuevo), conn)
                    Try
                        comm.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                    End Try
                    MsgBox("Listo.", MsgBoxStyle.Information, "Pasat H2O")
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class