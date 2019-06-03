Imports Passat_H2O.Datos
Imports System.Data.SqlClient

Public Class frmSocio_Maestro
    Dim instancia As New Datos.Users
    Dim Cargando As Boolean = True

    Private Sub frmSocio_Maestro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Activated
        Dim grid As New Formatos
        Try
            grid.Formatea_grid(Me.dgvSocios_maestro)
            Me.StartPosition = FormStartPosition.CenterParent

            Carga_grid()
            Carga_combos_Sector()
            Carga_combos_Bloques()

            Me.MdiParent = My.Forms.frmPrincipal
            Me.Width = Me.Parent.Width * 0.8
            Me.Height = Me.Parent.Height * 0.9
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try
        Cargando = False
    End Sub

    Sub Carga_grid()
        'llenarlo insertando filas
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_socios_maestro", conn)
                    comm.CommandType = CommandType.StoredProcedure

                    If Cargando = True Then
                        comm.Parameters.Add("@Socio_num", SqlDbType.Int).Value = 0
                        comm.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = 0
                        comm.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 6).Value = 0
                        comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 50).Value = ""

                    Else
                        Try
                            Dim Cuenta_Num As Integer = 0
                            If Me.txtCuenta_Num.Text = String.Empty Or Me.txtCuenta_Num.Text = "0" Then
                                Cuenta_Num = 0
                            Else
                                Cuenta_Num = CType(Me.txtCuenta_Num.Text, Integer)
                                comm.Parameters.Add("@Socio_num", SqlDbType.Int).Value = Cuenta_Num
                            End If

                            'Dim Sector_ID As Integer = 0
                            comm.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = Me.cmbSector.SelectedValue
                            comm.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 6).Value = Me.cmbBloque.SelectedValue
                            comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 50).Value = Me.txtpropietario.Text


                        Catch ex As Exception
                            MsgBox("El número de cuenta debe valor entero y positivo.", MsgBoxStyle.Exclamation, "Pasat H2O")
                            Exit Sub
                        End Try
                        'comm.Parameters.Add("@Socio_num", SqlDbType.Int).Value = 0
                    End If

                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSocios_maestro.DataSource = tabla
                    tabla = Nothing
                    Me.lblLineas_mostradas.Text = Me.dgvSocios_maestro.Rows.Count
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Sector()
        Try
            Dim Sectores As New List(Of Sectores)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Todos' UNION Select Sector_ID, Sector_Desc From Sectores", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    'dr.Read()
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Sectores
                        lista.pSectorID = items(0)
                        lista.pSector_Desc = items(1)
                        Sectores.Add(lista)
                    End While

                    Me.cmbSector.DataSource = Sectores
                    Me.cmbSector.ValueMember = "pSectorID"
                    Me.cmbSector.DisplayMember = "pSector_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques()
        Try
            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques(ByVal Sector As Integer)
        Try

            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques WHERE Sector_ID = '{0}'", Me.cmbSector.SelectedValue), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub


    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvSocios_maestro.Rows.Count = 0 Then Exit Sub

        'Verifica si el usuario es administrador para poder modificar el perfil del abonado.
        Dim usuario As New Datos.Users

        If Me.Verifica_perfil(usuario.pUsuario_conectado) Then
            Try
                My.Forms.frmSocio.Socio_ID = CInt(Me.dgvSocios_maestro.SelectedCells(0).Value)
                My.Forms.frmSocio.Modo_abre = "Edición"
                My.Forms.frmSocio.Show()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
            End Try
        End If

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
                        MsgBox("Su usuario no está autorizado para ver este formulario.", MsgBoxStyle.Exclamation, "Pasat")
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
        If My.Forms.frmSocio.Visible Then
            MsgBox("El formulario de datos del socio ya está abierto. Si necesita ver los datos de otros socio, por favor cierrelo e inténte de nuevo.", MsgBoxStyle.Information, "Pasat h2o")
            Exit Sub
        End If

        My.Forms.frmSocio.Modo_abre = "Nuevo"
        My.Forms.frmSocio.Show()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCuenta_Num_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta_Num.TextChanged
        Me.cmbSector.SelectedIndex = 0
        Carga_grid()
    End Sub

    Private Sub cmbSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSector.SelectedIndexChanged
        If Cargando Then Exit Sub
        Me.Carga_combos_Bloques(Me.cmbSector.SelectedValue)
        Me.txtCuenta_Num.Clear()
        Carga_grid()
    End Sub

    Private Sub txtpropietario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpropietario.TextChanged
        Me.txtCuenta_Num.Clear()
        Me.cmbSector.SelectedIndex = 0
        Carga_grid()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim Socio_ID As Integer = 0
                Socio_ID = Me.dgvSocios_maestro.SelectedCells(0).Value

                Dim res As Integer = 0
                res = MsgBox("Está seguro de querer eliminar este asociado?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
                If res = 1 Then
                    Try
                        Using comm As New SqlCommand("sp_delete_Socio", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                            comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = instancia.pUsuario_conectado
                            Dim dr As SqlDataReader = comm.ExecuteReader
                            dr.Read()
                            Try
                                If dr.HasRows Then
                                    MsgBox("Este Usuario no puede ser eliminado porque ya tiene transacciones registradas en el Log del sistema.", MsgBoxStyle.Information, "Pasat H2O")
                                    Exit Sub
                                Else
                                    MsgBox("El registro ha sido borrado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                                    Carga_grid()
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
                            End Try
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
                    End Try
                Else
                    Exit Sub
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try
    End Sub

    Private Sub cmbBloque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBloque.SelectedIndexChanged
        If Cargando Then Exit Sub
        Me.txtCuenta_Num.Clear()
        Carga_grid()
    End Sub

    Private Sub nupFuente_size_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupFuente_size.ValueChanged
        Me.dgvSocios_maestro.DefaultCellStyle.Font = New Font("Arial", Me.nupFuente_size.Value)
    End Sub
End Class