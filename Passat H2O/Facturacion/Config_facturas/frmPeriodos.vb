Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmPeriodos
    Dim modo_apertura As String = "Nuevo"
    Dim instancia As New Datos.Users
    Dim cargando As Boolean = True
    Dim periodo As New Periodos
    Public formulario_invoca As String


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmPeriodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carga_Listado()
        If Me.modo_apertura = "Nuevo" Then
            Me.cmbEstado.SelectedIndex = 2 'Pasivo cuando se está creando
        Else
            'Abre_modo_edicion
        End If
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Width = Me.Parent.Width * 0.7
        Me.Height = Me.Parent.Height * 0.9
    End Sub

    Sub Carga_Listado()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_periodos", conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvPeriodos.DataSource = tabla
                    tabla = Nothing
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.PanelDatos.Visible = True
        modo_apertura = "Nuevo"
        Me.nupDias.Value = 0
        Me.cmbEstado.Enabled = True
        Me.cmbMes.Enabled = True
        Me.cmbYear.Enabled = True
        Me.cmbEstado.Enabled = False
    End Sub

    Sub Desactiva_botones(ByVal Bandera As Boolean)
        Me.btnNuevo.Enabled = Bandera
        Me.btnEditar.Enabled = Bandera
        Me.btnSalir.Enabled = Bandera
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Verificar fechas lógicas cronológicamente
        'Asigna variables
        Try
            If Me.modo_apertura = "Nuevo" Then
                If Asigna_variables() = True Then
                    If Verifica_logica_fechas() Then
                        If Ciclo_no_existe() Then
                            If Me.Genera_transaccion(periodo) Then
                                Insert_periodo(periodo)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Else
                'Modo Edición
                If Asigna_variables() Then
                    If Verifica_logica_fechas() Then
                        Actualiza_registro(periodo)
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If

            Carga_Listado()
            Me.PanelDatos.Visible = False
            Me.cmbEstado.Enabled = True
            Me.cmbMes.Enabled = True
            Me.cmbYear.Enabled = True
            Me.cmbMes.SelectedIndex = -1
            Me.cmbYear.SelectedIndex = -1
            Me.txtPeriodo_ID.Clear()

        Catch ex As Exception
            MsgBox("Error!. " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h20")
        End Try
    End Sub

    '--- Funciones
    Function Ciclo_no_existe() As Boolean
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Periodos WHERE PeriodoID = '{0}'", Me.txtPeriodo_ID.Text), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    If dr.HasRows Then
                        MsgBox("Este período ya existe. Verifique año y mes e inténtelo de nuevo.", MsgBoxStyle.Information, "Pasat H2O")
                        Return False
                    Else
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error!. " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h20")
            Return False
        End Try
    End Function

    Function Asigna_variables() As Boolean
        With periodo
            Try
                .paño = Me.cmbYear.Text
            Catch ex As Exception
                MsgBox("Indique un año válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End Try

            Try
                .pmes = Me.cmbMes.Text
            Catch ex As Exception
                MsgBox("Indique un mes válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End Try

            Try
                If Me.txtPeriodo_ID.Text = String.Empty Then Return False
                .pperiodo_ID = Me.txtPeriodo_ID.Text
            Catch ex As Exception
                Return False
            End Try

            Try
                .pEmite_listado = Me.dtpEmite_listado.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pLectura_medidor = Me.dtpLectura_conta.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pIngreso_lecturas = Me.dtpIngreso_lecturas.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pAnalisis_incons = Me.dtpAnalisis_inconsist.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try


            Try
                .pAnalisis_Corte_servicio = Me.dtpAnalisisCorteServicio.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try


            Try
                .pAprobacion_lecturas = Me.dtpAprobacion_lecturas.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pEmision_factura = Me.dtpEmision_facturas.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pDistribuye_fact = Me.dtpDistribuye_Facturas.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pVencimiento_fac = Me.dtpVencimiento_facturas.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pAviso_corte = Me.dtpAviso_corte_servicio.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pCorte_suministro = Me.dtpCorte_suministro.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Try
                .pEstado = Me.cmbEstado.Text
            Catch ex As Exception
                Return False
            End Try

            Try
                .pDias_gracia = Me.nupDias.Value
            Catch ex As Exception
                Return False
            End Try
            '.pTransac_num Lo toma de insertar transacción
            '.pFecha Lo toma de insertar transacción

            Try
                Me.dtpVencimiento_real.Value = Me.dtpVencimiento_facturas.Value.AddDays(Me.nupDias.Value)
                .pVencimiento_real = Me.dtpVencimiento_real.Value.ToShortDateString
            Catch ex As Exception
                Return False
            End Try

            Return True
        End With
    End Function

    Function Verifica_logica_fechas() As Boolean
        With periodo
            If .pLectura_medidor < .pEmite_listado Then
                MsgBox("La de lectura del contador debe hacerse despues de emitir el listado.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpLectura_conta.Focus()
                Return False
            End If

            If .pIngreso_lecturas < .pLectura_medidor Then
                MsgBox("El ingreso de las facturas debe ser posterior o igual a la de lectura del contador.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpIngreso_lecturas.Focus()
                Return False
            End If

            If .pAnalisis_incons < .pIngreso_lecturas Then
                MsgBox("El análisis de las lecturas debe ser posterior a su captura.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpAnalisis_inconsist.Focus()
                Return False
            End If
            If .pAnalisis_Corte_servicio < .pIngreso_lecturas Then
                MsgBox("El análisis de los cortes de servicio debe ser posterior a su captura.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpAnalisisCorteServicio.Focus()
                Return False
            End If

            If .pAprobacion_lecturas < .pAnalisis_Corte_servicio Or .pAprobacion_lecturas < .pAnalisis_incons Then
                MsgBox("Asegúrese de autorizar la facturación despues del análisis de inconsistencias y cuentas por cortar el servicio.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpAprobacion_lecturas.Focus()
                Return False
            End If

            If .pEmision_factura < .pAprobacion_lecturas Then
                MsgBox("La emisión de facturas debe ser igual o mayor a la de autorización de las lecturas.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpEmision_facturas.Focus()
                Return False
            End If

            If .pDistribuye_fact < .pEmision_factura Then
                MsgBox("La fecha de distribución debe ser igual o mayor a la de emisión.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpDistribuye_Facturas.Focus()
                Return False
            End If

            If .pVencimiento_fac < .pDistribuye_fact Then
                MsgBox("Indique una fecha de vencimiento mayor o igual de distribución de las facturas.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpVencimiento_facturas.Focus()
                Return False
            End If

            'If .pAviso_corte < .pVencimiento_fac Then
            '    MsgBox("Indique una fecha de aviso de corte del servicio mayor al de vencimiento de la factura.", MsgBoxStyle.Information, "Pasat h20")
            '    Me.dtpAviso_corte_servicio.Focus()
            '    Return False
            'End If

            If .pCorte_suministro < .pAviso_corte Then
                MsgBox("Indique una fecha de ejecución de corte mayor a la de aviso del mismo.", MsgBoxStyle.Information, "Pasat h20")
                Me.dtpCorte_suministro.Focus()
                Return False
            End If

            Dim control As Control
            Dim fecha_previa As DateTime
            fecha_previa = Me.dtpLectura_conta.Value.ToShortDateString
            Dim bandera As Boolean = False

            For Each control In Me.Group_vencimiento.Controls
                If TypeOf control Is DateTimePicker Then
                    If fecha_previa = CType(control, DateTimePicker).Value.ToShortDateString Then
                        fecha_previa = CType(control, DateTimePicker).Value.ToShortDateString
                        bandera = True
                    Else
                        bandera = False
                        fecha_previa = CType(control, DateTimePicker).Value.ToShortDateString
                    End If
                End If
            Next

            If bandera = True Then
                Dim res As Integer
                res = MsgBox("Algunas las fechas son iguales. Se recomienda, para un buen funcionamiento del sistema, que se defina un Ciclo de Facturación, y se indique en cada uno de los controles las fechas respectivas. " & vbCrLf & vbCrLf & "Aceptar para continuar o Cancelar para hacer modificaciones", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Pasat H2O")
                If res <> 1 Then Return False 'Decide continuar con los valores en pantalla
            End If

            If Me.cmbEstado.SelectedIndex = -1 Then
                Me.cmbEstado.SelectedItem = 2 ' Cuando se está creando; 1 = Activo, cuando está en curso. 3 = Cerrado, cuando ha finalizado el período
                Return False
            End If
        End With

        Return True
    End Function

    Function Genera_transaccion(ByVal periodo As Periodos) As Boolean
        Try
            Using conn As New SqlClient.SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim fecha As DateTime
                fecha = DateTime.Now
                periodo.pTransac_fecha = fecha 'La misma de creación cuando se es nuevo

                Using comm As New SqlCommand("sp_Insert_Transaccion", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Transac_ID", SqlDbType.VarChar, 4).Value = "300" 'Alta o edición de Períodos de Facturación
                    comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha
                    Dim usuario As New Datos.Users

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.VarChar, 6).Value = usuario.pUsuario_conectado
                    comm.ExecuteNonQuery()
                End Using

                Using comm As New SqlCommand("SELECT IDENT_CURRENT('Transacciones_sistema')", conn)
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    If reader.HasRows Then
                        reader.Read()
                        periodo.pTransac_num = Convert.ToInt32(reader(0))
                    End If
                End Using
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
            Return False
        End Try
    End Function

    Sub Insert_periodo(ByVal periodo As Periodos)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Inserta_periodos", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    With periodo
                        comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = .pperiodo_ID
                        comm.Parameters.Add("@anio", SqlDbType.Int).Value = .paño
                        comm.Parameters.Add("@mes", SqlDbType.Int).Value = .pmes
                        comm.Parameters.Add("@Emite_hoja", SqlDbType.Date).Value = .pEmite_listado
                        comm.Parameters.Add("@Lectura_medidor", SqlDbType.Date).Value = .pLectura_medidor
                        comm.Parameters.Add("@Ingreso_lecturas", SqlDbType.Date).Value = .pIngreso_lecturas
                        comm.Parameters.Add("@Analisis_incons", SqlDbType.Date).Value = .pAnalisis_incons
                        comm.Parameters.Add("@Analisis_cortes_servicio", SqlDbType.Date).Value = .pAnalisis_Corte_servicio
                        comm.Parameters.Add("@Aprobacion_lecturas", SqlDbType.Date).Value = .pAprobacion_lecturas
                        comm.Parameters.Add("@Emision_factura", SqlDbType.Date).Value = .pEmision_factura
                        comm.Parameters.Add("@Distribuye_fact", SqlDbType.Date).Value = .pDistribuye_fact
                        comm.Parameters.Add("@Vencimiento_fac", SqlDbType.Date).Value = .pVencimiento_fac
                        comm.Parameters.Add("@Aviso_corte", SqlDbType.Date).Value = .pAviso_corte
                        comm.Parameters.Add("@Corte_suministro", SqlDbType.Date).Value = .pCorte_suministro
                        comm.Parameters.Add("@Estado", SqlDbType.VarChar, 7).Value = .pEstado
                        comm.Parameters.Add("@Transac_num", SqlDbType.Int).Value = .pTransac_num
                        comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = .pTransac_fecha
                        comm.Parameters.Add("@dias_gracia", SqlDbType.Int).Value = .pDias_gracia
                        comm.Parameters.Add("@Vencimiento_real", SqlDbType.DateTime).Value = .pVencimiento_real
                    End With
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using
            End Using
            MsgBox("Periodo Creado Satisfactoriamente. Puede actualizar su información abriéndolo nuevamente. ", MsgBoxStyle.Information, "Pasat h2o")
        Catch ex As Exception
            MsgBox("Error! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Sub Actualiza_registro(ByVal periodo As Periodos)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Update_periodos", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    With periodo
                        Dim usuario As New Datos.Users

                        comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = usuario.pUsuario_conectado
                        comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = .pperiodo_ID
                        comm.Parameters.Add("@Emite_hoja", SqlDbType.Date).Value = .pEmite_listado
                        comm.Parameters.Add("@Lectura_medidor", SqlDbType.Date).Value = .pLectura_medidor
                        comm.Parameters.Add("@Ingreso_lecturas", SqlDbType.Date).Value = .pIngreso_lecturas
                        comm.Parameters.Add("@Analisis_incons", SqlDbType.Date).Value = .pAnalisis_incons
                        comm.Parameters.Add("@Analisis_cortes_servicio", SqlDbType.Date).Value = .pAnalisis_Corte_servicio
                        comm.Parameters.Add("@Aprobacion_lecturas", SqlDbType.Date).Value = .pAprobacion_lecturas
                        comm.Parameters.Add("@Emision_factura", SqlDbType.Date).Value = .pEmision_factura
                        comm.Parameters.Add("@Distribuye_fact", SqlDbType.Date).Value = .pDistribuye_fact
                        comm.Parameters.Add("@Vencimiento_fac", SqlDbType.Date).Value = .pVencimiento_fac
                        comm.Parameters.Add("@Aviso_corte", SqlDbType.Date).Value = .pAviso_corte
                        comm.Parameters.Add("@Corte_suministro", SqlDbType.Date).Value = .pCorte_suministro
                        comm.Parameters.Add("@Estado", SqlDbType.VarChar, 7).Value = .pEstado
                        comm.Parameters.Add("@dias_gracia", SqlDbType.Int).Value = .pDias_gracia
                        comm.Parameters.Add("@Vencimiento_real", SqlDbType.DateTime).Value = .pVencimiento_real
                    End With
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using
            End Using
            MsgBox("Periodo actualizado satisfactoriamente.", MsgBoxStyle.Information, "Pasat h2o")
        Catch ex As Exception
            MsgBox("Error! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    '--- Controles

    Private Sub cmbYear_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.DropDown
        Dim year_ As Integer
        year_ = CInt(Date.Now.Year)
        Dim i As Integer
        For i = year_ To year_ + 100
            Me.cmbYear.Items.Add(year_)
            year_ += 1
        Next
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged, cmbYear.SelectedIndexChanged
        If Me.cmbYear.SelectedIndex <> -1 And Me.cmbMes.SelectedIndex <> -1 Then
            Me.txtPeriodo_ID.Text = Me.cmbYear.Text & Me.cmbMes.Text
        Else
            Me.txtPeriodo_ID.Clear()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim res As Integer
        res = MsgBox("Está seguro de querer salir?" & vbCrLf & vbCrLf & "Aceptar para salir sin guardar o Cancelar para hacer modificaciones.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Pasat H2O")
        If res = 1 Then
            Me.PanelDatos.Visible = False
            Me.cmbYear.Enabled = True
            Me.cmbMes.Enabled = True
            Me.cmbEstado.Enabled = True
            Me.nupDias.Value = 0
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        If Me.formulario_invoca = My.Forms.frmToma_lectura.Name Then
            If Me.dgvPeriodos.SelectedRows(0).Cells("Estado").Value <> "Pasivo" Then
                MsgBox("Seleccione un período con Estado 'Pasivo' para poder continuar")
                Exit Sub
            End If
            My.Forms.frmToma_lectura.txtPeriodo_ID.Text = Me.dgvPeriodos.SelectedCells(0).Value.ToString
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Dim estado As String = String.Empty
        estado = Me.dgvPeriodos.SelectedCells(3).Value.ToString
        If estado = "Cerrado" Then
            MsgBox("Este período ya está cerrado y no puede editarse.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End If

        modo_apertura = "Editando"
        Me.cmbEstado.Enabled = False

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Periodo_para_edicion", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Me.dgvPeriodos.SelectedCells(0).Value
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    Try
                        With periodo
                            .pperiodo_ID = dr(0)
                            .paño = dr(1)
                            .pmes = dr(2)
                            .pEmite_listado = dr(3)
                            .pLectura_medidor = dr(4)
                            .pIngreso_lecturas = dr(5)
                            .pAnalisis_incons = dr(6)
                            .pAnalisis_Corte_servicio = dr(7)
                            .pAprobacion_lecturas = dr(8)
                            .pEmision_factura = dr(9)
                            .pDistribuye_fact = dr(10)
                            .pVencimiento_fac = dr(11)
                            .pAviso_corte = dr(12)
                            .pCorte_suministro = dr(13)
                            .pEstado = dr(14)
                            'Transacc
                            'Fecha
                            'Transacc
                            'Fecha
                            .pDias_gracia = dr(19)
                            .pVencimiento_real = dr(20)

                            Me.txtPeriodo_ID.Text = .pperiodo_ID
                            Me.cmbYear.Text = .paño
                            Me.cmbMes.Text = .pmes
                            Me.cmbMes.Enabled = False
                            Me.cmbYear.Enabled = False

                            Me.dtpEmite_listado.Value = .pEmite_listado
                            Me.dtpLectura_conta.Value = .pLectura_medidor
                            Me.dtpIngreso_lecturas.Value = .pIngreso_lecturas
                            Me.dtpAnalisis_inconsist.Value = .pAnalisis_incons
                            Me.dtpAnalisisCorteServicio.Value = .pAnalisis_Corte_servicio
                            Me.dtpAprobacion_lecturas.Value = .pAprobacion_lecturas
                            Me.dtpEmision_facturas.Value = .pEmision_factura
                            Me.dtpDistribuye_Facturas.Value = .pDistribuye_fact
                            Me.dtpVencimiento_facturas.Value = .pVencimiento_fac
                            Me.dtpAviso_corte_servicio.Value = .pAviso_corte
                            Me.dtpCorte_suministro.Value = .pCorte_suministro
                            Me.cmbEstado.Text = .pEstado
                            Me.nupDias.Value = .pDias_gracia
                            Me.dtpVencimiento_real.Value = .pVencimiento_real
                        End With

                        Me.PanelDatos.Visible = True
                        Me.dgvPeriodos.Enabled = True

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Exit Sub
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim Periodo_ID As String = String.Empty

                Periodo_ID = Me.dgvPeriodos.SelectedCells(0).Value

                Using comm As New SqlCommand(String.Format("Select Periodo_ID Lectura From Lecturas_Detalle WHERE Periodo_ID = '{0}' UNION Select Periodo_ID Facturas From Facturacion_Detalle WHERE Periodo_ID = '{0}'", Periodo_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    Try
                        If dr.HasRows Then
                            MsgBox("Este período no puede ser eliminado porque ya tiene registros de toma de lecturas y/o facturación", MsgBoxStyle.Information, "Pasat H2O")
                            Exit Sub
                        Else
                            dr.Close()
                            Dim res As Integer = 0
                            res = MsgBox("Está seguro de querer eliminar este período?" & vbCrLf & vbCrLf & "Aceptar para borrar, Cancelar para salir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
                            If res = 1 Then
                                Try
                                    Using comm_delete As New SqlCommand("sp_delete_Periodo", conn)
                                        comm_delete.CommandType = CommandType.StoredProcedure
                                        Dim usuario As New Datos.Usuario_sistema

                                        comm_delete.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUser_ID
                                        comm_delete.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Periodo_ID

                                        comm_delete.ExecuteNonQuery()

                                        MsgBox("El registro ha sido borrado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                                        Carga_Listado()
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

    Private Sub nupDias_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupDias.ValueChanged
        Me.dtpVencimiento_real.Value = Me.dtpVencimiento_facturas.Value.AddDays(Me.nupDias.Value)
    End Sub

    Private Sub dtpVencimiento_facturas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVencimiento_facturas.ValueChanged
        Me.dtpVencimiento_real.Value = Me.dtpVencimiento_facturas.Value.AddDays(Me.nupDias.Value)
    End Sub
End Class