Imports System.Data.SqlClient

Public Class frmUsuarios
    Dim instancia As New Datos.Users
    Dim editando As Boolean = False

    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.cmbTipo.Text = "Seleccione Tipo"
        Me.txtNombre.Focus()
        Carga_lista()
    End Sub

    Sub Carga_lista()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Usuarios", conn)
                    Dim tabla As New DataTable
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvUsuarios.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, , "Pasat H2O")
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        'MsgBox("Si el usuario operando no es administrador no podrá modificar el registro.")
        Dim usuario As New Datos.Users

        If Verifica_perfil(usuario.pUsuario_conectado) Then
            Me.Panel1.Visible = True
            Me.txtNombre.Clear()
            Me.txtpassw1.Clear()
            Me.txtPassw2.Clear()
            Me.lblContrase.Visible = False
            Me.txtNombre.Focus()

            Carga_datos_usuario(CType(Me.dgvUsuarios.SelectedCells(0).Value, Integer))
            editando = True
        Else
            MsgBox("No está autorizado para modificar usuarios.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
            editando = False
            Exit Sub
        End If
    End Sub

    Sub Carga_datos_usuario(ByVal User_ID As Integer)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Usuario_ID, Nombre, Passw, Tipo, Estado From Usuarios WHERE Usuario_ID = '{0}'", User_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            Me.txtUsuario_ID.Text = dr(0)
                            Me.txtNombre.Text = dr(1)
                            Me.txtpassw1.Text = dr(2)
                            Me.cmbTipo.Text = dr(3)
                            Me.chkActivo.Checked = CType(dr(4), Boolean)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, "Pasat H2O")
                        Me.txtNombre.Clear()
                        Me.txtpassw1.Clear()
                        Me.txtPassw2.Clear()
                        Me.lblContrase.Visible = False
                        Me.Panel1.Visible = False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Function Verifica_perfil(ByVal usuario As Integer) As Boolean
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Verifica_usuario", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = usuario
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    If dr(0) = "Administrador" Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            Return False
        End Try
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim usuario As New Datos.Users
        If Verifica_perfil(usuario.pUsuario_conectado) Then
            Me.Panel1.Visible = True
            Me.txtUsuario_ID.Clear()
            Me.txtNombre.Focus()
            Me.btnNuevo.Enabled = False
            Me.btnEditar.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.editando = False
        Else
            MsgBox("No está autorizado para modificar usuarios.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
            Exit Sub
        End If
    End Sub

    Private Sub txtPassw2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassw2.Leave
        If Me.txtNombre.Text = String.Empty Then
            Me.txtNombre.Focus()
            Exit Sub
        End If

        If Me.txtpassw1.Text <> Me.txtPassw2.Text Then
            Me.lblContrase.Visible = True
            Me.lblContrase.ForeColor = Color.Yellow
            Me.lblContrase.Text = "No Coinciden!"
            Me.btnAceptar.Enabled = False
        Else
            Me.lblContrase.Visible = True
            Me.lblContrase.ForeColor = Color.White
            Me.lblContrase.Text = "Coinciden!"
            Me.btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub txtPassw2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassw2.TextChanged
        Me.lblContrase.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtNombre.Text = String.Empty Then Exit Sub
        If Me.txtpassw1.Text = String.Empty Then Exit Sub
        If Me.lblContrase.Text <> "Coinciden!" Then
            MsgBox("Las contraseñas no coinciden!")
            Exit Sub
        End If


        If editando = False Then
            Inserta_user()
        Else
            Actualiza_user()
        End If

        Carga_lista()
        Me.txtNombre.Clear()
        Me.txtpassw1.Clear()
        Me.txtPassw2.Clear()
        Me.lblContrase.Visible = False
        Me.Panel1.Visible = False
        Me.btnNuevo.Enabled = True
        Me.btnEditar.Enabled = True
        Me.btnEliminar.Enabled = True
    End Sub

    Sub Actualiza_user()
        Dim nombre_user As String
        Dim Contrase As String
        Dim tipo_user As String
        Dim estado As Boolean

        Try
            nombre_user = Me.txtNombre.Text
            Contrase = Me.txtpassw1.Text
            tipo_user = Me.cmbTipo.Text
            estado = Me.chkActivo.Checked

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Update_Usuario", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    Dim usuario As New Datos.Users
                    comm.Parameters.Add("@Usuario_editor", SqlDbType.Int).Value = usuario.pUsuario_conectado
                    Dim usuario_editado As Integer = 0
                    usuario_editado = CType(Me.txtUsuario_ID.Text, Integer)
                    comm.Parameters.Add("@Usuario_editado", SqlDbType.Int).Value = usuario_editado
                    comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre_user
                    comm.Parameters.Add("@passw", SqlDbType.VarChar, 8).Value = Contrase
                    comm.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado
                    comm.Parameters.Add("@Tipo", SqlDbType.VarChar, 20).Value = tipo_user
                    comm.ExecuteNonQuery()
                    MsgBox("El Usuario ha sido actualizado satisfactoriamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, "Pasat H2O")
        End Try
    End Sub

    Sub Inserta_user()
        Dim Contrase As String
        Dim nombre_user As String
        Dim tipo_user As String

        Try
            nombre_user = Me.txtNombre.Text
            Contrase = Me.txtpassw1.Text
            tipo_user = Me.cmbTipo.Text
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Inserta_Usuario", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre_user
                    comm.Parameters.Add("@passw", SqlDbType.VarChar, 8).Value = Contrase
                    comm.Parameters.Add("@Tipo", SqlDbType.VarChar, 20).Value = tipo_user

                    Dim usuario As New Datos.Users
                    comm.Parameters.Add("@Usuario_crea", SqlDbType.Int).Value = usuario.pUsuario_conectado
                    comm.ExecuteNonQuery()
                    MsgBox("El Usuario ha sido creado satisfactoriamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim usuario As New Datos.Users
        If usuario.pUsuario_conectado = Me.dgvUsuarios.SelectedCells(0).Value Then
            MsgBox("El usuario no puede autoeliminarse. Debe crear otro usuario Administrador para poder borrar el solicitado.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End If

        Try
            Dim resp As Integer = 0
            resp = MsgBox("Realmente desea eliminar este usuario?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
            If resp = 1 Then
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()
                    Dim User_ID As Integer = 0

                    User_ID = Me.dgvUsuarios.SelectedCells(0).Value

                    Using comm As New SqlCommand("sp_delete_User", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUsuario_conectado
                        comm.Parameters.Add("@User_ID", SqlDbType.VarChar, 6).Value = User_ID 'El que se va a borrar

                        Dim dr As SqlDataReader = comm.ExecuteReader
                        dr.Read()
                        Try
                            If dr.HasRows Then
                                MsgBox("Este Usuario no puede ser eliminado porque ya tiene transacciones registradas en el Log del sistema.", MsgBoxStyle.Information, "Pasat H2O")
                                Exit Sub
                            Else
                                MsgBox("El usuario ha sido eliminado.", MsgBoxStyle.Information, "Pasat H2O")
                                Carga_lista()
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
                        End Try
                    End Using
                End Using
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Panel1.Visible = False
        Me.txtUsuario_ID.Clear()
        Me.txtNombre.Clear()
        Me.txtpassw1.Clear()
        Me.txtPassw2.Clear()
        Me.cmbTipo.Text = "Seleccione Tipo"
        Me.btnNuevo.Enabled = True
        Me.btnEditar.Enabled = True
        Me.btnEliminar.Enabled = True
    End Sub
End Class