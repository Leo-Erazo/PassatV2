Imports Passat_H2O.Datos
Imports System.Data.SqlClient

Public Class frmTarifas
    Dim instancia As New Datos.Users
    Dim grid As New Formatos
    Dim modo_apertura As String
    Dim tarifa As New Facturacion

    Private Sub frmTarifas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Tarifas", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvTarifas.DataSource = tabla
                    grid.Formatea_grid(Me.dgvTarifas)
                    Me.dgvTarifas.Columns(1).Width = 200
                    Me.dgvTarifas.Columns(4).DefaultCellStyle.Format = "C"
                    Me.dgvTarifas.Columns(5).DefaultCellStyle.Format = "C"
                    dr.Close()
                End Using
            End Using
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Me.txtTarifa_Desc.Clear()
        Me.txtImporte_base.Text = "0.00"
        Me.txtImporte_exceso.Text = "0.00"
        Me.txtMaximo.Text = "0.00"
        Me.txtMinimo.Text = "0.00"

        Desactiva_controles(False)
        Me.txtTarifa_Desc.Focus()
        Me.modo_apertura = "Nuevo"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Desactiva_controles(True)
    End Sub

    Function Verifica_controles() As Boolean
        If Me.txtTarifa_Desc.Text = String.Empty Then
            MsgBox("Debe indicar una descripción para la tarifa.", MsgBoxStyle.Information, "Pasat h2o")
            Return False
        End If

        If Me.txtMinimo.Text = String.Empty Then
            Me.txtMinimo.Text = 0
            Return False
        End If

        If Me.txtMaximo.Text = String.Empty Then
            MsgBox("El valor máximo debe ser indicado. De lo contrario se le asignará el valor de 1.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtMaximo.Text = 1
            Return False
        End If

        If Me.txtImporte_base.Text = String.Empty Then
            MsgBox("Debe indicar el importe del cobro base.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtImporte_base.Text = "0.0"
            Return False
        End If


        If Me.txtImporte_exceso.Text = String.Empty Then
            MsgBox("El importe por consumo superior al base estipulado quedará en cero.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtImporte_exceso.Text = "0.0"
            Return False
        End If

        Return True
    End Function

    Sub Asigna_variables()
        With tarifa
            .pTarifa_Desc = Me.txtTarifa_Desc.Text

            Try
                .pMinimo_medida = CInt(Me.txtMinimo.Text)
            Catch ex As Exception
                MsgBox("Verifique el valor del consumo mínimo", MsgBoxStyle.Information, "Pasat h2o")
                Me.txtMinimo.Focus()
            End Try

            Try
                .pMáximo_medida = CInt(Me.txtMaximo.Text)
            Catch ex As Exception
                MsgBox("Verifique el valor del consumo máximo", MsgBoxStyle.Information, "Pasat h2o")
                Me.txtMaximo.Focus()
            End Try

            Try
                .pImporte_base = CDec(Me.txtImporte_base.Text)
            Catch ex As Exception
                MsgBox("Verifique el valor del importe costo base", MsgBoxStyle.Information, "Pasat h2o")
                Me.txtImporte_base.Focus()
            End Try

            Try
                .pImporte_exceso = CDec(Me.txtImporte_exceso.Text)
            Catch ex As Exception
                MsgBox("Verifique el valor del importe cobro por exceso", MsgBoxStyle.Information, "Pasat h2o")
                Me.txtImporte_exceso.Focus()
            End Try

        End With
    End Sub

    Function Genera_transaccion(ByVal tarifa As Facturacion) As Boolean
        Try
            Using conn As New SqlClient.SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim fecha As DateTime
                fecha = DateTime.Now
                tarifa.pFecha_edicion = fecha 'La misma de creación cuando se es nuevo

                Using comm As New SqlCommand("sp_Insert_Transaccion", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Transac_ID", SqlDbType.VarChar, 4).Value = "200" 'Alta o edición de tarifas
                    comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha
                    Dim usuario As New Datos.Usuario_sistema

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.VarChar, 6).Value = usuario.pUser_ID 'instancia.pUser_ID
                    comm.ExecuteNonQuery()
                End Using

                Using comm As New SqlCommand("SELECT IDENT_CURRENT('Transacciones_sistema')", conn)
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    If reader.HasRows Then
                        reader.Read()
                        tarifa.pTransac_tarifa = Convert.ToInt32(reader(0))
                    End If
                End Using
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "iCoop")
            Return False
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Verifica_controles()
        Me.Asigna_variables()
        If Genera_transaccion(tarifa) Then
            Try
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()
                    If Me.modo_apertura = "Nuevo" Then
                        Using comm As New SqlCommand("sp_Inserta_tarifa", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            With tarifa
                                comm.Parameters.Add("@Tarifa_desc", SqlDbType.VarChar, 100).Value = .pTarifa_Desc
                                comm.Parameters.Add("@Medida_minimo", SqlDbType.Int).Value = .pMinimo_medida
                                comm.Parameters.Add("@Medida_maximo", SqlDbType.Int).Value = .pMáximo_medida
                                comm.Parameters.Add("@Importe_base", SqlDbType.Decimal).Value = .pImporte_base
                                comm.Parameters.Add("@Importe_unidad_exceso", SqlDbType.Decimal).Value = .pImporte_exceso
                                comm.Parameters.Add("@Transac_num", SqlDbType.Int).Value = .pTransac_tarifa
                                comm.Parameters.Add("@Transac_edit", SqlDbType.Int).Value = .pTransac_tarifa
                                comm.Parameters.Add("@Fecha_edit", SqlDbType.DateTime).Value = .pFecha_edicion
                            End With
                            comm.ExecuteNonQuery()
                            MsgBox("Registro guardado satisfactoriamente!", MsgBoxStyle.Information, "Pasat h2o")
                        End Using
                    Else 'En modo Edición
                        Using comm As New SqlCommand("sp_Update_tarifa", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            With tarifa
                                .pTarifa_ID = CInt(Me.txtTarifa_id.Text)
                                comm.Parameters.Add("@Tarifa_ID", SqlDbType.Int).Value = .pTarifa_ID
                                comm.Parameters.Add("@Tarifa_desc", SqlDbType.VarChar, 100).Value = .pTarifa_Desc
                                comm.Parameters.Add("@Medida_minimo", SqlDbType.Int).Value = .pMinimo_medida
                                comm.Parameters.Add("@Medida_maximo", SqlDbType.Int).Value = .pMáximo_medida
                                comm.Parameters.Add("@Importe_base", SqlDbType.Decimal).Value = .pImporte_base
                                comm.Parameters.Add("@Importe_unidad_exceso", SqlDbType.Decimal).Value = .pImporte_exceso
                                comm.Parameters.Add("@Transac_edit", SqlDbType.Int).Value = .pTransac_tarifa
                                comm.Parameters.Add("@Fecha_edit", SqlDbType.DateTime).Value = .pFecha_edicion
                            End With
                            comm.ExecuteNonQuery()
                            MsgBox("Registro actualizado satisfactoriamente!", MsgBoxStyle.Information, "Pasat h2o")
                        End Using
                    End If

                End Using
                Desactiva_controles(True)
                frmTarifas_Load(Nothing, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            End Try
        Else
            MsgBox("Error al generar la transacción", MsgBoxStyle.Exclamation, "Pasat H2O")
        End If

        Me.txtTarifa_Desc.Clear()
        Me.txtImporte_base.Text = "0.00"
        Me.txtImporte_exceso.Text = "0.00"
        Me.txtMaximo.Text = "0.00"
        Me.txtMinimo.Text = "0.00"


    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvTarifas.Rows.Count = 0 Then Exit Sub
        Desactiva_controles(False)
        Me.txtTarifa_id.Text = Me.dgvTarifas.SelectedCells(0).Value.ToString
        Me.txtTarifa_Desc.Text = Me.dgvTarifas.SelectedCells(1).Value.ToString
        Me.txtMinimo.Text = Me.dgvTarifas.SelectedCells(2).Value
        Me.txtMaximo.Text = Me.dgvTarifas.SelectedCells(3).Value
        Me.txtImporte_base.Text = Me.dgvTarifas.SelectedCells(4).Value
        Me.txtImporte_exceso.Text = Me.dgvTarifas.SelectedCells(5).Value
        Me.txtTarifa_id.Enabled = False
        Me.modo_apertura = "Edición"
    End Sub

    Sub Desactiva_controles(ByVal bandera As Boolean)
        Me.Panel1.Visible = bandera
        Me.btnEditar.Enabled = bandera
        Me.btnEliminar.Enabled = bandera
        Me.Panel1.Visible = Not bandera
    End Sub

    Private Sub txtMinimo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinimo.Leave
        Try
            If CInt(Me.txtMinimo.Text) < 0 Then
                Me.txtMinimo.Text = "0"
            End If
        Catch ex As Exception
            MsgBox("Verifique el valor de medida mínimo", MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Private Sub txtMaximo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaximo.Leave
        Try
            If CInt(Me.txtMaximo.Text) < 0 Then
                Me.txtMaximo.Text = "0"
            End If
        Catch ex As Exception
            MsgBox("Verifique el valor de medida máximo", MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Private Sub txtImporte_base_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte_base.Leave
        Try
            If CDec(Me.txtImporte_base.Text) < 0 Then
                Me.txtImporte_base.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox("Verifique el valor de importe base.", MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Private Sub txtImporte_exceso_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte_exceso.Leave
        Try
            If CDec(Me.txtImporte_exceso.Text) < 0 Then
                Me.txtImporte_exceso.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox("Verifique el valor de importe sobre exceso.", MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim resp As Integer = 0
            resp = MsgBox("Realmente desea eliminar esta Tarifa?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
            If resp = 1 Then
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()
                    Dim Tarifa_ID As Integer = 0

                    Tarifa_ID = Me.dgvTarifas.SelectedCells(0).Value

                    Using comm As New SqlCommand("sp_delete_Tarifa", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        Dim usuario As New Datos.Usuario_sistema

                        comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUser_ID
                        comm.Parameters.Add("@Tarifa_ID", SqlDbType.VarChar, 6).Value = Tarifa_ID

                        Dim dr As SqlDataReader = comm.ExecuteReader
                        dr.Read()
                        Try
                            If dr.HasRows Then
                                'MsgBox(dr(0))
                                MsgBox("Esta Tarifa no puede ser eliminada porque ya tiene Servicios asignados.", MsgBoxStyle.Information, "Pasat H2O")
                                Exit Sub
                            Else
                                MsgBox("La Tarifa ha sido eliminada.", MsgBoxStyle.Information, "Pasat H2O")
                                frmTarifas_Load(Nothing, Nothing)
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
End Class