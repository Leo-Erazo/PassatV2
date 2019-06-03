Imports Passat_H2O.Datos
Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class frmSectores
    Dim instancia As New Datos.Users
    Dim grid As New Formatos
    Dim modo_apertura As String

    Private Sub frmSectores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select Sector_ID as [Sector ID], Sector_Desc as [Nombre del Sector] From Sectores", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSectores.DataSource = tabla
                    grid.Formatea_grid(Me.dgvSectores)
                    Me.dgvSectores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    Me.dgvSectores.Columns(0).Width = 100
                    dr.Close()
                End Using
            End Using
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Me.txtSector_id.Clear()
        Me.txtSector_nombre.Clear()
        Desactiva_controles(False)
        Me.txtSector_nombre.Focus()
        Me.modo_apertura = "Nuevo"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.txtSector_id.Clear()
        Me.txtSector_nombre.Clear()
        Desactiva_controles(True)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtSector_nombre.Text = String.Empty Then Exit Sub
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                If Me.modo_apertura = "Nuevo" Then
                    Using comm As New SqlCommand(String.Format("Insert INTO Sectores VALUES ('{0}')", Me.txtSector_nombre.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                Else
                    Using comm As New SqlCommand(String.Format("UPDATE Sectores SET Sector_desc = '{0}' WHERE Sector_ID = '{1}'", Me.txtSector_nombre.Text, Me.txtSector_id.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                End If
                
            End Using

            Desactiva_controles(True)
            frmSectores_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

        
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvSectores.Rows.Count = 0 Then Exit Sub
        Desactiva_controles(False)
        Me.txtSector_id.Text = Me.dgvSectores.SelectedCells(0).Value.ToString
        Me.txtSector_nombre.Text = Me.dgvSectores.SelectedCells(1).Value.ToString
        Me.modo_apertura = "Edición"
    End Sub

    Sub Desactiva_controles(ByVal bandera As Boolean)
        Me.Panel1.Visible = bandera
        Me.btnEditar.Enabled = bandera
        Me.btnEliminar.Enabled = bandera
        Me.Panel1.Visible = Not bandera
        Me.txtSector_id.Enabled = bandera
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim sector_ID As Integer = 0
                sector_ID = CType(Me.dgvSectores.SelectedCells(0).Value, Integer)

                Using comm As New SqlCommand(String.Format("select * from Socios where Sector_ID = '{0}'", sector_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    Try
                        If dr.HasRows Then
                            MsgBox("Este Sector no puede ser eliminado porque ya hay asociados que lo tienen como parte de la ruta de lectura.", MsgBoxStyle.Information, "Pasat H2O")
                            Exit Sub
                        Else
                            dr.Close()
                            Dim res As Integer = 0

                            res = MsgBox("Está seguro de querer eliminar este sector?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")

                            If res = 1 Then
                                Try
                                    Using comm_delete As New SqlCommand("sp_delete_Sector", conn)
                                        comm_delete.CommandType = CommandType.StoredProcedure
                                        Dim usuario As New Datos.Usuario_sistema
                                        comm_delete.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUser_ID
                                        comm_delete.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = sector_ID
                                        comm_delete.ExecuteNonQuery()

                                        MsgBox("El registro ha sido borrado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")

                                        frmSectores_Load(Nothing, Nothing)
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