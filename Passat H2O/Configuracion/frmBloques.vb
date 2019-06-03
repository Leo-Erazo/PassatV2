Imports Passat_H2O.Datos
Imports System.Data.SqlClient

Public Class frmBloques
    Dim instancia As New Datos.Users
    Dim grid As New Datos.Formatos
    Dim modo_apertura As String

    Private Sub frmBloques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Activated
        Carga_Grid()
        Carga_combo()
    End Sub

    Sub Carga_Grid()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("select BL.Sector_ID [Sector ID], SE.Sector_Desc [Sector Descripción], BL.Bloque_ID [Polígono ID], BL.Bloque_Desc [Descripción Bloque] from Bloques BL inner join Sectores SE ON SE.Sector_ID = BL.Sector_ID", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    'dr.Read()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvBloques.DataSource = tabla
                    grid.Formatea_grid(Me.dgvBloques)
                    Me.dgvBloques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    Me.dgvBloques.Columns(0).Width = 80
                    Me.dgvBloques.Columns(2).Width = 80
                    dr.Close()
                End Using
            End Using
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combo()
        Try
            Dim Sectores As New List(Of Sectores)

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Seleccione Sector' UNION Select Sector_ID, Sector_Desc From Sectores", conn)
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
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Desactiva_controles(True)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cmbSector.SelectedIndex = 0 Then Exit Sub
        If Me.txtBloque_id.Text = String.Empty Then Exit Sub
        If Me.txtBloque_nombre.Text = String.Empty Then Exit Sub

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                If Me.modo_apertura = "Nuevo" Then
                    Using comm As New SqlCommand(String.Format("Insert INTO Bloques VALUES ('{0}', '{1}','{2}')", Me.cmbSector.SelectedValue, Me.txtBloque_id.Text, Me.txtBloque_nombre.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                Else
                    Using comm As New SqlCommand(String.Format("UPDATE Bloques SET Bloque_desc = '{0}' WHERE Sector_ID = '{1}' AND Bloque_ID = '{2}'", Me.txtBloque_nombre.Text, Me.cmbSector.SelectedValue, Me.txtBloque_id.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                End If

            End Using

            Desactiva_controles(True)
            frmBloques_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try


    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvBloques.Rows.Count = 0 Then Exit Sub
        Desactiva_controles(False)
        Try

            Me.cmbSector.SelectedValue = Me.dgvBloques.SelectedCells(0).Value
            Me.txtBloque_id.Text = Me.dgvBloques.SelectedCells(2).Value.ToString
            Me.txtBloque_nombre.Text = Me.dgvBloques.SelectedCells(3).Value.ToString
            Me.cmbSector.Enabled = False
            Me.txtBloque_id.Enabled = False

            Me.modo_apertura = "Edición"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
        
    End Sub

    Sub Desactiva_controles(ByVal bandera As Boolean)
        Me.Panel1.Visible = bandera
        Me.btnEditar.Enabled = bandera
        Me.btnEliminar.Enabled = bandera
        Me.Panel1.Visible = Not bandera
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Desactiva_controles(False)
        Me.cmbSector.Enabled = True
        Me.cmbSector.SelectedIndex = 0
        Me.txtBloque_id.Enabled = True
        Me.txtBloque_id.Clear()
        Me.txtBloque_nombre.Clear()
        Me.cmbSector.Focus()
        Me.modo_apertura = "Nuevo"
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim Sector_ID As Integer = 0
                Dim Bloque_ID As String = String.Empty
                Sector_ID = Me.dgvBloques.SelectedCells(0).Value
                Bloque_ID = Me.dgvBloques.SelectedCells(2).Value

                Using comm As New SqlCommand(String.Format("select * from Socios where Bloque_ID = '{0}'and Sector_ID = '{1}'", Bloque_ID, Sector_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    Try
                        If dr.HasRows Then
                            MsgBox("Este bloque o polígono no puede ser eliminado porque ya hay asociados que lo tienen como parte de la ruta de lectura.", MsgBoxStyle.Information, "Pasat H2O")
                            Exit Sub
                        Else
                            dr.Close()
                            Dim res As Integer = 0
                            res = MsgBox("Está seguro de querer eliminar este bloque?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
                            If res = 1 Then
                                Try
                                    Using comm_delete As New SqlCommand("sp_delete_Bloque", conn)
                                        comm_delete.CommandType = CommandType.StoredProcedure
                                        Dim usuario As New Datos.Usuario_sistema
                                        comm_delete.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUser_ID
                                        comm_delete.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = Sector_ID
                                        comm_delete.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 6).Value = Bloque_ID

                                        comm_delete.ExecuteNonQuery()

                                        MsgBox("El registro ha sido borrado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                                        Carga_Grid()
                                    End Using
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
                                End Try
                            Else
                                Exit Sub
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
                    End Try

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try
    End Sub
End Class