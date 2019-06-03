Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmLogin
    Dim instancia As New Datos.Users

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.MdiParent = My.Forms.frmPrincipal
            Dim usuarios As New List(Of Usuario_sistema)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Seleccione usuario' UNION Select Usuario_ID, Nombre From Usuarios", conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader()
                    Try
                        Dim item(2) As Object
                        While dr.Read
                            dr.GetValues(item)
                            Dim lista As New Usuario_sistema
                            lista.pUser_ID = item(0)
                            lista.pUser_Nombre = item(1)
                            usuarios.Add(lista)
                        End While

                        Me.cmbUsuarios.DataSource = usuarios
                        Me.cmbUsuarios.ValueMember = "pUser_ID"
                        Me.cmbUsuarios.DisplayMember = "pUser_Nombre"
                        Me.cmbUsuarios.SelectedIndex = 0
                        Me.cmbUsuarios.Focus()
                        dr.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
       
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbUsuarios_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.DropDownClosed
        Me.txtPass_actual.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Verifica_usuario()
    End Sub

    Sub Verifica_usuario()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Usuarios WHERE Usuario_ID = '{0}' AND Passw = '{1}'", Me.cmbUsuarios.SelectedValue, Me.txtPass_actual.Text), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            instancia.pUsuario_conectado = Me.cmbUsuarios.SelectedValue

                            Dim usuario As New Usuario_sistema
                            usuario.pUser_ID = Me.cmbUsuarios.SelectedValue
                            usuario.pUser_Nombre = Me.cmbUsuarios.Text
                            My.Forms.frmPrincipal.lblUsuario.Text = usuario.pUser_ID & " " & usuario.pUser_Nombre
                            My.Forms.frmPrincipal.Show()
                            Me.Close()
                        Else
                            MsgBox("Combinación de usuario y contraseña inválida!", MsgBoxStyle.Exclamation, "Pasat H2O")
                            Me.txtPass_actual.Focus()
                            Exit Sub
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.txtPass_actual.Focus()
    End Sub
End Class