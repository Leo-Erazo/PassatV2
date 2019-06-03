Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmIngreso_lecturas
    Dim ds As New DataSet
    Dim instancia As New Datos.Users

    Private Sub frmIngreso_lecturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Width = Me.Parent.Width * 0.7
        Me.Height = Me.Parent.Height * 0.95
        Me.txtPeriodo.Focus()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Me.btnGuardar.Enabled = True
        If Me.dgvLecturas.Rows.Count > 0 Then
            Dim resp As Integer
            resp = MsgBox("ATENCION: si carga los datos del período solicitado y no ha guardado los cambios del listado actual, éstos quedarán sin efecto y se procederá con la solicitud de carga." & vbCrLf & vbCrLf & "Aceptar para continuar o Cancelar para seguir en el listado actual.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
            If resp <> 1 Then Exit Sub
            ds.Tables.Clear()
        End If
        If Determina_Periodo_existe(Me.txtPeriodo.Text) Then
            'Carga listado
            If Determina_Listado_existe(Me.txtPeriodo.Text) = True Then
                Carga_lista_existente()
                Me.Panel1.Visible = False
                Me.btnInconsistencias.Enabled = True
            Else
                Me.Panel1.Visible = True
            End If
        Else
            MsgBox("Este período aún no ha sido definido. Primero debe crearlo en el módulo de períodos para poder crear el listado de toma de lecturas." & vbCrLf & vbCrLf & "Aceptar para continuar", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
            Exit Sub
        End If
        
    End Sub

    Function Determina_Periodo_existe(ByVal Periodo As String) As Boolean
        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Estado From periodos WHERE PeriodoID = '{0}'", Me.txtPeriodo.Text), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            If dr(0).ToString = "Pasivo" Then
                                Return True
                            Else
                                MsgBox("Aunque el período está ya definido, tiene un estado no válido para tomar lecturas. " & vbCrLf & vbCrLf & "Se le mostrará el listado, pero no podrá hacer modificaciones." & vbCrLf & vbCrLf & "Aceptar para continuar.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                                Me.btnGuardar.Enabled = False
                                Me.btnInconsistencias.Enabled = False
                                Carga_lista_existente()
                                Return True 'Existe pero está Cerrado o Activo
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function

    Function Determina_Listado_existe(ByVal Periodo As String) As Boolean
        'La función determina si hay algún listado ya generado y guardado en la tabla LECTURAS.
        'Si existiera, se le notificará al usuario que hay uno, con las opciones de verlo ó eliminarlo y generar uno nuevo.

        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Lecturas_detalle WHERE Periodo_ID = '{0}'", Me.txtPeriodo.Text), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        If dr.HasRows Then
                            Return True
                        Else
                            Return False
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function

    Sub Carga_lista_existente()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(("sp_Lista_Captura_lecturas"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo", SqlDbType.VarChar, 6).Value = Me.txtPeriodo.Text
                    comm.Parameters.Add("@Fecha", SqlDbType.Date).Value = Me.dtpLectura.Value

                    Dim usuario As New Datos.Users
                    comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUsuario_conectado

                    Dim da As New SqlDataAdapter(comm)
                    ds.Tables.Clear()
                    da.Fill(ds, 0)
                    Me.dgvLecturas.DataSource = ds.Tables(0)
                    Me.lblLineas.Text = Me.dgvLecturas.Rows.Count - 1

                    Me.dgvLecturas.Columns(7).DefaultCellStyle.BackColor = Color.LightBlue
                    Me.dgvLecturas.Columns(7).DefaultCellStyle.ForeColor = Color.Blue
                    Me.dgvLecturas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    'Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
    '    Dim resp As Integer
    '    resp = MsgBox("Asegúrese de guardar antes de salir. Aceptar para para salir, Cancelar para volver al listado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")

    '    If resp <> 1 Then
    '        Exit Sub
    '    Else
    '        Me.Close()
    '    End If
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.dgvLecturas.Rows.Count = 0 Then
            MsgBox("No hay datos que guardar.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End If


        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Lecturas_detalle WHERE Periodo_ID = '{0}'", Me.txtPeriodo.Text), conn)
                    Dim da As New SqlDataAdapter(comm)
                    Dim cb As New SqlCommandBuilder(da)
                    da.UpdateCommand = cb.GetUpdateCommand(True)
                    da.Update(ds.Tables(0))
                    ds.Tables(0).AcceptChanges()
                    Me.btnInconsistencias.Enabled = True
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub btnAceptar_fecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar_fecha.Click
        Carga_lista_existente()
        Me.Panel1.Visible = False
    End Sub

    Private Sub btnCancelar_fecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar_fecha.Click
        Me.Panel1.Visible = False
        Exit Sub
    End Sub

    Function Determina_Listado_Enc_existe(ByVal Periodo As String) As Boolean
        'La función determina si hay algún listado ya generado y guardado en la tabla LECTURAS.
        'Si existiera, se le notificará al usuario que hay uno, con las opciones de verlo ó eliminarlo y generar uno nuevo.

        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Lecturas_Encabezado WHERE Periodo_ID = '{0}'", Me.txtPeriodo.Text), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        If dr.HasRows Then
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function

    Private Sub btnFinalizar_lecturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar_lecturas.Click
        Dim resp As Integer
        Dim periodo_ID As String = Me.txtPeriodo.Text

        If Me.txtPeriodo.Text = String.Empty Then Exit Sub
        'Verificar si el período no ha sido ya facturado.

        If Determina_Periodo_existe(Me.txtPeriodo.Text) Then
            'Carga listado
            If Determina_Listado_Enc_existe(Me.txtPeriodo.Text) = True Then
                MsgBox("ATENCION: Este período ya aparece finalizado." & vbCrLf & vbCrLf & "Aceptar para continuar", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
                Exit Sub
            End If
        End If

        resp = MsgBox("Asegúrese de guardar los cambios antes realizar este procedimiento. " _
            & vbCrLf & vbCrLf & "Al finalizar el listado ya no podrá hacer modificaciones y se procederá a calcular la facturación. " _
            & vbCrLf & vbCrLf & "Asegúrese de tener autorizadas aquellas lecturas con irregularidades en el consumo o error en su ingreso, ya que de haberlas se tomarán como válidas, pero se agregarán a un historial, para ser consultado posteriormente." & vbCrLf & vbCrLf & "Está seguro de querer finalizarlo?" & vbCrLf & vbCrLf _
            & "Aceptar para finalizar, Cancelar para salir", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")

        If resp = 1 Then
            'Finaliza el listado
            Try
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()

                    'Se verifica aquí si este período tiene facturas vencidas pendientes de que se le aplique la
                    'factura por penalización. Se le exige al operario que corra el proceso de generación masiva de las facturas
                    'por penalización antes de poder continuar

                    If verifica_facturas_vencidas() = True Then
                        Dim respuesta = MsgBox("El período que se va a cerrar aún tiene facturas pendientes de pago. El sistema procederá a generar el cargo automático por penalización. Este cobro saldrá reflejado en la factura del período que está por activarse." & vbCrLf & vbCrLf & "Si hay algún Socio con convenio para este período que se está cerrando y que no lo haya marcado en la ficha de dicho Socio, puede dar click en cancelar y hacer el ajuste. Luego puede proceder de nuevo a correr el proceso de Facturación del nuevo período.", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, "Facturación del nuevo período")

                        If respuesta = 2 Then
                            MsgBox("Proceso cancelado. No se generaron las facturas por penalización. Aún no se ha generado la facturación masiva del siguiente período, hasta que se generen primero las penalizaciones.", MsgBoxStyle.Information)
                            Exit Sub
                        Else

                            MsgBox("Se generará un backup previo a la facturación por si es necesaria una reversión crítica del sistema, a este punto.", MsgBoxStyle.Information)

                            If BackUp() = False Then
                                MsgBox("Se intentó hacer una copia de respaldo previa a la facturación y no ha sido posible realizarla satisfactoriamente. Por lo que se ha suspendido la facturación. Por favor intente nuevamente.", MsgBoxStyle.Information, "iLeon Pasat")
                                Exit Sub
                            End If

                            Ejecutar_cargos_penalizacion()

                        End If

                    End If
        
                    Try
                        Using comm As New SqlCommand("sp_Genera_FACTURACION", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Date.Now
                            comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = instancia.pUsuario_conectado
                            comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = periodo_ID
                            comm.ExecuteNonQuery()

                            MsgBox("La facturación ha sido generada. Se procederá a ejecutar el proceso de autopago para las facturas de Socios con cuenta de pago anticipado. Luego puede proceder a la impresión de los recibos.", MsgBoxStyle.Information, "Pasat")

                            My.Forms.frmCuentas_auto_pago.Show()

                            If My.Forms.frmPenaliza_masiva_auto.Visible Then
                                My.Forms.frmPenaliza_masiva_auto.Close()
                            End If

                            If My.Forms.frmCuentas_auto_pago.Visible Then
                                My.Forms.frmCuentas_auto_pago.Close()
                            End If

                            MsgBox("La facturación del nuevo período ha sido generada satisfactoriamente. Puede proceder a imprimir las facturas.", MsgBoxStyle.Information, "Passat H20 V2")

                            Me.Close()

                        End Using

                    Catch ex As Exception
                        MsgBox("Se guardaron las lecturas con inconsistencias, pero no ha sido posible generar la facturación. Se aborta el proceso. " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Information, "Pasat")
                        Exit Sub
                    End Try

                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Function verifica_facturas_vencidas() As Boolean
        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("sp_lista_facturas_vencidas_pdte_cargo", conn)
                comm.CommandType = CommandType.Text
                Dim dr As SqlDataReader = comm.ExecuteReader
                If dr.HasRows = False Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Sub Ejecutar_cargos_penalizacion()
        My.Forms.frmPenaliza_masiva_auto.Show()
    End Sub


    Private Sub btnInconsistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInconsistencias.Click
        Try
            My.Forms.frmVerifica_inconsistencia._periodo_ID = Me.txtPeriodo.Text
            My.Forms.frmVerifica_inconsistencia.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub dgvLecturas_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLecturas.DataError
        MsgBox("Error en el valor ingresado. Verifique que sea un valor entero válido!", MsgBoxStyle.Exclamation, "Pasat H20")
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim resp As Integer
        resp = MsgBox("Asegúrese de guardar antes de salir. Aceptar para para salir, Cancelar para volver al listado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")

        If resp <> 1 Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtPeriodo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnCargar.PerformClick()
        End If
    End Sub

    Function BackUp() As Boolean
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_BackUp_Pasat", conn)
                    comm.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            'MsgBox("Error al hacer copia de seguridad. " & ex.Message, MsgBoxStyle.Information, "Pasat H2O")
            Return False
        End Try
    End Function

End Class