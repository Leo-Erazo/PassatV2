Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmServicios
    Dim instancia As New Datos.Users
    Dim grid As New Formatos
    Public Modo_abre As String
    Dim cargando As Boolean = True
    Public Formulario_invoca As String


    Private Sub frmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Activated
        Try
            Carga_combos_Tarifas()
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_servicios", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvServicios.DataSource = tabla
                    grid.Formatea_grid(Me.dgvServicios)
                    Me.dgvServicios.Columns(0).Width = 80
                    Me.dgvServicios.Columns(2).Width = 80
                    dr.Close()
                End Using
            End Using
            Me.cmbRequiere_lectura.SelectedIndex = 1
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Tarifas()
        Try
            Dim Tarifas As New List(Of Facturacion)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Seleccione Tarifa' UNION Select Tarifa_ID, Tarifa_Desc From Tarifas", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    'dr.Read()
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Facturacion
                        lista.pTarifa_ID = items(0)
                        lista.pTarifa_Desc = items(1)
                        Tarifas.Add(lista)
                    End While

                    Me.cmbTarifa.DataSource = Tarifas
                    Me.cmbTarifa.ValueMember = "pTarifa_ID"
                    Me.cmbTarifa.DisplayMember = "pTarifa_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Try
            Me.txtServicio_nombre.Clear()
            Me.txtServicio_id.Clear()
            Me.cmbRequiere_lectura.SelectedIndex = 0
            Me.cmbTarifa.SelectedIndex = 0

            Desactiva_controles(False)
            'Carga_combos_Tarifas()
            Me.txtServicio_nombre.Focus()
            Me.Modo_abre = "Nuevo"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.txtServicio_nombre.Clear()
        Me.txtServicio_id.Clear()
        Me.cmbRequiere_lectura.SelectedIndex = 0
        Me.cmbTarifa.SelectedIndex = 0
        Desactiva_controles(True)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtServicio_nombre.Text = String.Empty Then
            MsgBox("Debe colocar una descripción al Servicio.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End If

        If Me.cmbTarifa.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar una tarifa para este servicio. Si no existe tendrá que primero crearla en el formulario de tarifas.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                If Me.Modo_abre = "Nuevo" Then
                    Using comm As New SqlCommand(String.Format("Insert INTO Servicios VALUES ('{0}', '{1}', '{2}')", Me.txtServicio_nombre.Text, Me.cmbTarifa.SelectedValue, Me.cmbRequiere_lectura.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                Else
                    Using comm As New SqlCommand(String.Format("UPDATE Servicios SET Servicio_desc = '{0}', Tarifa_ID = '{1}', Requiere_leer = '{3}' WHERE Servicio_ID = '{2}'", Me.txtServicio_nombre.Text, Me.cmbTarifa.SelectedValue, Me.txtServicio_id.Text, Me.cmbRequiere_lectura.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                End If

            End Using

            Desactiva_controles(True)
            Me.txtServicio_nombre.Clear()
            Me.txtServicio_id.Clear()
            Me.cmbRequiere_lectura.SelectedIndex = 0
            Me.cmbTarifa.SelectedIndex = 0

            frmServicios_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvServicios.Rows.Count = 0 Then Exit Sub
        Desactiva_controles(False)
        Me.txtServicio_id.Text = Me.dgvServicios.SelectedCells(0).Value.ToString
        Me.txtServicio_nombre.Text = Me.dgvServicios.SelectedCells(1).Value.ToString
        Me.cmbTarifa.SelectedValue = Me.dgvServicios.SelectedCells(2).Value
        Me.cmbRequiere_lectura.Text = Me.dgvServicios.SelectedCells(4).Value.ToString
        Me.Modo_abre = "Edición"
    End Sub

    Sub Desactiva_controles(ByVal bandera As Boolean)
        Me.Panel1.Visible = bandera
        Me.btnEditar.Enabled = bandera
        Me.btnEliminar.Enabled = bandera
        Me.Panel1.Visible = Not bandera
    End Sub

    Private Sub dgvServicios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicios.CellDoubleClick
        If Me.Formulario_invoca = My.Forms.frmSocio.Name Then
            Try
                If My.Forms.frmSocio.dgvServicios_contratados.Columns.Count = 0 Then
                    My.Forms.frmSocio.dgvServicios_contratados.Columns.Add("Servicio_ID", "Servicio ID")
                    My.Forms.frmSocio.dgvServicios_contratados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    My.Forms.frmSocio.dgvServicios_contratados.Columns.Add("Servicio_Desc", "Servicio Descripción")
                    My.Forms.frmSocio.dgvServicios_contratados.Columns.Add("Tarifa_ID", "Tarifa")
                    My.Forms.frmSocio.dgvServicios_contratados.Columns.Add("Tarifa_Desc", "Tarifa Descripción")

                End If

                Dim i As Integer = 0
                For i = 0 To My.Forms.frmSocio.dgvServicios_contratados.Rows.Count - 1
                    If Me.dgvServicios.SelectedCells(0).Value = My.Forms.frmSocio.dgvServicios_contratados.Item(0, i).Value Then
                        MsgBox("Este servicio ya está asignado!", MsgBoxStyle.Information, "Pasat")
                        Exit Sub
                    End If
                Next

                My.Forms.frmSocio.dgvServicios_contratados.Rows.Add()
                My.Forms.frmSocio.dgvServicios_contratados.Item(0, My.Forms.frmSocio.dgvServicios_contratados.Rows.Count - 1).Value = Me.dgvServicios.SelectedCells(0).Value
                My.Forms.frmSocio.dgvServicios_contratados.Item(1, My.Forms.frmSocio.dgvServicios_contratados.Rows.Count - 1).Value = Me.dgvServicios.SelectedCells(1).Value
                My.Forms.frmSocio.dgvServicios_contratados.Item(2, My.Forms.frmSocio.dgvServicios_contratados.Rows.Count - 1).Value = Me.dgvServicios.SelectedCells(2).Value
                My.Forms.frmSocio.dgvServicios_contratados.Item(3, My.Forms.frmSocio.dgvServicios_contratados.Rows.Count - 1).Value = Me.dgvServicios.SelectedCells(3).Value

                My.Forms.frmSocio.dgvServicios_contratados.Columns(0).Width = 80
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat h2o")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim resp As Integer = 0
            resp = MsgBox("Realmente desea eliminar este servicio?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
            If resp = 1 Then
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()
                    Dim Servicio_ID As Integer = 0

                    Servicio_ID = Me.dgvServicios.SelectedCells(0).Value

                    Using comm As New SqlCommand("sp_delete_Servicio", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        Dim usuario As New Datos.Usuario_sistema

                        comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUser_ID
                        comm.Parameters.Add("@Servicio_ID", SqlDbType.VarChar, 6).Value = Servicio_ID

                        Dim dr As SqlDataReader = comm.ExecuteReader
                        dr.Read()
                        Try
                            If dr.HasRows Then
                                MsgBox("Este Servicio no puede ser eliminado porque ya tiene registros de facturación.", MsgBoxStyle.Information, "Pasat H2O")
                                Exit Sub
                            Else
                                MsgBox("El Servicio ha sido eliminado.", MsgBoxStyle.Information, "Pasat H2O")
                                frmServicios_Load(Nothing, Nothing)
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

    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        Me.PanAyuda.Visible = True
    End Sub

    Private Sub btnCerrar_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar_ayuda.Click
        Me.PanAyuda.Visible = False
    End Sub

End Class