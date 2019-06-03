Imports System.Data.SqlClient

Public Class frmPrincipal
    Dim Instancia As New Datos.Users

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim usuario As New Datos.Usuario_sistema
        ' usuario.pUser_ID = 10000
        'MsgBox("Aquí pondremos la pantalla de autenticación de usuarios.")
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_tareas_ciclo_facturacion", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    While dr.Read
                        Dim datos(2) As Object
                        dr.GetValues(datos)
                        Me.txtNotificaciones.Text += datos(0) & " " & datos(1) & vbCrLf
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("No ha sido posible determinar actividades críticas del Ciclo de Facturación para este día.", MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
        
    End Sub

    Private Sub SectoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SectoresToolStripMenuItem.Click
        My.Forms.frmSectores.Show()
    End Sub

    Private Sub AltaDeNuevoAsociadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaDeNuevoAsociadoToolStripMenuItem.Click
        If My.Forms.frmSocio.Visible = False Then
            My.Forms.frmSocio.Show()
        Else
            My.Forms.frmSocio.BringToFront()
        End If
        My.Forms.frmSocio.Modo_abre = "Nuevo"
    End Sub

    Private Sub BloquesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloquesToolStripMenuItem.Click
        If My.Forms.frmBloques.Visible = False Then
            My.Forms.frmBloques.Show()
        Else
            My.Forms.frmBloques.BringToFront()
        End If
    End Sub

    Private Sub SendasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.frmSendas.Visible = False Then
            My.Forms.frmSendas.Show()
        Else
            My.Forms.frmSendas.BringToFront()
        End If
    End Sub

    Private Sub ServiciosPrestadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiciosPrestadosToolStripMenuItem.Click
        If My.Forms.frmServicios.Visible = False Then
            My.Forms.frmServicios.Show()
        Else
            My.Forms.frmServicios.BringToFront()
        End If
    End Sub

    Private Sub Tarifas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTarifas.Click
        Dim usuario As New Datos.Users
        If Me.Verifica_perfil(usuario.pUsuario_conectado) Then
            If My.Forms.frmTarifas.Visible = False Then
                My.Forms.frmTarifas.Show()
            Else
                My.Forms.frmTarifas.BringToFront()
            End If
        End If

    End Sub

    Private Sub MaestroDeAsociadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaestroDeAsociadosToolStripMenuItem.Click
        If My.Forms.frmSocio_Maestro.Visible = True Then
            My.Forms.frmSocio_Maestro.BringToFront()
        Else
            My.Forms.frmSocio_Maestro.Show()
        End If

    End Sub

    Private Sub GenerarListadoTomaLecturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarListadoTomaLecturasToolStripMenuItem.Click
        'MsgBox("La impresión del listado de lecturas debe coincidir con la fecha del calendario de facturación. En evaluación si este proceso desactivaría el período anterior y activa el siguiente inmediato.")

        If My.Forms.frmToma_lectura.Visible = True Then
            My.Forms.frmToma_lectura.BringToFront()
        Else
            My.Forms.frmToma_lectura.Show()
        End If
    End Sub

    Private Sub CapturarLecturasTomadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturarLecturasTomadasToolStripMenuItem.Click
        If My.Forms.frmIngreso_lecturas.Visible = True Then
            My.Forms.frmIngreso_lecturas.BringToFront()
        Else
            My.Forms.frmIngreso_lecturas.Show()
        End If

    End Sub

    Private Sub VerListadoHistóricoDeLecturasTomadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerListadoHistóricoDeLecturasTomadasToolStripMenuItem.Click
        If My.Forms.frmListado_lecturas_encabezados.Visible = True Then
            My.Forms.frmListado_lecturas_encabezados.BringToFront()
        Else
            My.Forms.frmListado_lecturas_encabezados.Show()
        End If
    End Sub

    Private Sub PeríodosCiclosDeFacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeríodosCiclosDeFacturaciónToolStripMenuItem.Click
        Dim usuario As New Datos.Users
        If Me.Verifica_perfil(usuario.pUsuario_conectado) Then
            If My.Forms.frmPeriodos.Visible = True Then
                My.Forms.frmPeriodos.BringToFront()
            Else
                My.Forms.frmPeriodos.Show()
            End If
        End If
    End Sub

    Private Sub GenerarFacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarFacturaciónToolStripMenuItem.Click
        If My.Forms.frmListado_lecturas_encabezados.Visible = True Then
            My.Forms.frmListado_lecturas_encabezados.BringToFront()
        Else
            My.Forms.frmListado_lecturas_encabezados.Show()
        End If
    End Sub

    Private Sub CapturarPasoSocioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturarPasoSocioToolStripMenuItem.Click
        If My.Forms.frmFacturas_listado.Visible = True Then
            My.Forms.frmFacturas_listado.BringToFront()
        Else
            My.Forms.frmFacturas_listado.Show()
        End If
    End Sub

    Private Sub PagosRealizadosPorElSocioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosRealizadosPorElSocioToolStripMenuItem.Click
        If My.Forms.frmReporte_pagos_socio.Visible = True Then
            My.Forms.frmReporte_pagos_socio.BringToFront()
        Else
            My.Forms.frmReporte_pagos_socio.Show()
        End If
    End Sub

    Private Sub ListadoDeCobrosParaElPeríodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCobrosParaElPeríodoToolStripMenuItem.Click
        If My.Forms.frmListado_Cobro_Periodo.Visible = True Then
            My.Forms.frmListado_Cobro_Periodo.BringToFront()
        Else
            My.Forms.frmListado_Cobro_Periodo.Show()
        End If
    End Sub


  
    Private Sub ImprimirTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.frmListado_lecturas_encabezados.Visible = True Then
            My.Forms.frmListado_lecturas_encabezados.BringToFront()
        Else
            My.Forms.frmListado_lecturas_encabezados.Show()
        End If
    End Sub

    Private Sub SaldosDelSocioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosDelSocioToolStripMenuItem.Click
        If My.Forms.frmSaldos_socios.Visible = True Then
            My.Forms.frmSaldos_socios.BringToFront()
        Else
            My.Forms.frmSaldos_socios.Show()
        End If
    End Sub

    Private Sub SaldosPorSocioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.frmSaldos_socios.Visible = True Then
            My.Forms.frmSaldos_socios.BringToFront()
        Else
            My.Forms.frmSaldos_socios.Show()
        End If
    End Sub

    Private Sub AnálisisDeInconsistenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnálisisDeInconsistenciasToolStripMenuItem.Click
        MsgBox("Aquí se mostrarán las lecturas con posibles inconsistencias, pero que se dieron por aprobadas para generar la facturación.")
        Exit Sub
    End Sub

    Function Verifica_perfil(ByVal usuario As Integer) As Boolean
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
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

    Private Sub CrearFacturaManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearFacturaManualToolStripMenuItem.Click
        If My.Forms.frmFactura_manual.Visible = True Then
            My.Forms.frmFactura_manual.BringToFront()
        Else
            My.Forms.frmFactura_manual.Show()
        End If
    End Sub

    Private Sub ReimprimirFacturaManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Forms.frmRe_Imprime_factura_manual.Visible = True Then
            My.Forms.frmRe_Imprime_factura_manual.BringToFront()
        Else
            My.Forms.frmRE_Imprime_factura_manual.Show()
        End If
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    'Private Sub frmPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    'Generar el reporte de abonos y enviarlo por correo
    '    'Generar la bitácora de transacciones y enviarlo por correo.
    '    Dim Cadena_mensaje As String = ""
    '    Dim Suma_total As Double = 0

    '    Cadena_mensaje += "Reporte de ingresos en caja por pagos de asociados." & vbCrLf & vbCrLf
    '    Try
    '        Using conn As New SqlConnection(Instancia.pCadena_conexion)
    '            conn.Open()
    '            Using comm As New SqlCommand("sp_Reporte_Abonos_del_dia", conn)
    '                Dim dr As SqlDataReader = comm.ExecuteReader
    '                While dr.Read
    '                    Dim cadena(4) As Object
    '                    dr.GetValues(cadena)
    '                    Cadena_mensaje += cadena(0) & " " & cadena(1) & " " & cadena(2) & " $ " & cadena(3) & vbCrLf
    '                    Suma_total += CType(cadena(3), Double)
    '                End While
    '            End Using
    '        End Using
    '        Cadena_mensaje += vbCrLf & "Total de pagos recibidos: $" & Suma_total
    '        MsgBox(Cadena_mensaje)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
    '    End Try
    'End Sub

    Private Sub ListadoDeCuentasConMoraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCuentasConMoraToolStripMenuItem.Click
        My.Forms.frmCuentas_Corte_servicio.Show()
    End Sub

    Private Sub UsuariosDelSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosDelSistemaToolStripMenuItem.Click
        Dim usuario As New Datos.Users
        If Verifica_perfil(usuario.pUsuario_conectado) = True Then
            If My.Forms.frmUsuarios.Visible = True Then
                My.Forms.frmUsuarios.BringToFront()
            Else
                My.Forms.frmUsuarios.Show()
            End If
        End If
    End Sub

    Private Sub MaestroDeCuentasDeAhorroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaestroDeCuentasDeAhorroToolStripMenuItem.Click
        If My.Forms.frmCuentas_ahorro_socios.Visible = True Then
            My.Forms.frmCuentas_ahorro_socios.BringToFront()
        Else
            My.Forms.frmCuentas_ahorro_socios.Show()
        End If
    End Sub

    Private Sub tsSocios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSocios.Click
        Dim usuario As New Datos.Users
        If Verifica_perfil(usuario.pUsuario_conectado) = False Then
            Me.tsSocios.Enabled = False
        End If
    End Sub

    Private Sub tsRegiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRegiones.Click
        Dim usuario As New Datos.Users
        If Verifica_perfil(usuario.pUsuario_conectado) = False Then
            Me.tsRegiones.Enabled = False
        End If
    End Sub

    Private Sub tsParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsParametros.Click
        Dim usuario As New Datos.Users
        Try
            If Verifica_perfil(usuario.pUsuario_conectado) = False Then
                Me.tsParametros.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
        
    End Sub

    Private Sub tsFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFacturacion.Click
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Verifica_usuario", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    Dim usuario As New Datos.Users
                    comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = usuario.pUsuario_conectado
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    If dr(0) = "Supervisor" Then
                        MsgBox("Su usuario no está autorizado para acceder a este menú.", MsgBoxStyle.Exclamation, "Pasat")
                        Me.tsFacturacion.Enabled = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub CambioDeContraseñaDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDeContraseñaDeUsuarioToolStripMenuItem.Click
        If My.Forms.frmUsuario_Cambio_passw.Visible Then
            My.Forms.frmUsuario_Cambio_passw.BringToFront()
        Else
            My.Forms.frmUsuario_Cambio_passw.Show()
        End If
    End Sub

    Private Sub AltosYBajosConsumosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltosYBajosConsumosToolStripMenuItem.Click
        If My.Forms.frmAltos_Y_Bajos.Visible Then
            My.Forms.frmAltos_Y_Bajos.BringToFront()
        Else
            My.Forms.frmAltos_Y_Bajos.Show()
        End If
    End Sub

    Private Sub PagosEImpagosDelPeríodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosEImpagosDelPeríodoToolStripMenuItem.Click
        If My.Forms.frmReportePagosYnoPagosPeriodo.Visible Then
            My.Forms.frmReportePagosYnoPagosPeriodo.BringToFront()
        Else
            My.Forms.frmReportePagosYnoPagosPeriodo.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If My.Forms.frmReportes_Consolidados.Visible Then
            My.Forms.frmReportes_Consolidados.BringToFront()
        Else
            My.Forms.frmReportes_Consolidados.Show()
        End If
    End Sub

    Private Sub AbonosTotalesDelPeríodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbonosTotalesDelPeríodoToolStripMenuItem.Click
        If My.Forms.frmRepo_Ingresos_mes_consolidado.Visible Then
            My.Forms.frmRepo_Ingresos_mes_consolidado.BringToFront()
        Else
            My.Forms.frmRepo_Ingresos_mes_consolidado.Show()
        End If
    End Sub

    Private Sub LToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LToolStripMenuItem.Click
        Try
            If My.Forms.frmFacturas_listado.Visible = True Then
                My.Forms.frmFacturas_listado.BringToFront()
            Else
                My.Forms.frmFacturas_listado.Show()
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub PagosDeAsociadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosDeAsociadosToolStripMenuItem.Click
        Try
            If My.Forms.frmReporte_pagos_socio.Visible = True Then
                My.Forms.frmReporte_pagos_socio.BringToFront()
            Else
                My.Forms.frmReporte_pagos_socio.Show()
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub SaldosPorCobrarAAsociadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosPorCobrarAAsociadosToolStripMenuItem.Click
        If My.Forms.frmSaldos_socios.Visible = True Then
            My.Forms.frmSaldos_socios.BringToFront()
        Else
            My.Forms.frmSaldos_socios.Show()
        End If
    End Sub

    Private Sub CierreDiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreDiarioToolStripMenuItem.Click
        Try
            If My.Forms.frmImprime_Pagos_del_dia.Visible Then
                My.Forms.frmImprime_Pagos_del_dia.BringToFront()
            Else
                My.Forms.frmImprime_Pagos_del_dia.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub HacerRespaldoDeBaseDeDatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HacerRespaldoDeBaseDeDatosToolStripMenuItem.Click
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_BackUp_Pasat", conn)
                    comm.ExecuteNonQuery()
                    MsgBox("Copia de Seguridad realizada satisfactoriamente.", MsgBoxStyle.Information, "Pasat H2O")
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al hacer copia de seguridad. " & ex.Message, MsgBoxStyle.Information, "Pasat H2O")
        End Try
    End Sub

    Private Sub lblAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAcercaDe.Click
        MsgBox("ileon Passat H2O V2 :: Sistema de Facturación de Agua y Otros Servicios." & vbCrLf & "Desarrollado por: Ing. José Leonidas Erazo Quijada" & vbCrLf & "leonidaserazo@yahoo.com" & vbCrLf & vbCrLf & "Todos los derechos reservados." & vbCrLf & "El Salvador. 2018")
    End Sub


    Private Sub RestaurarBaseDeDatosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurarBaseDeDatosToolStripMenuItem1.Click
        MsgBox("La restauración de la base de datos del sistema debe ser realizada por alguien capacitado, y deberá hacerse desde SQL Manager Studio. Revise el manual para llevar a cabo este proceso de manera apropiada.", MsgBoxStyle.Exclamation, "Pasat H2O")
        'Dim usuario As New Datos.Users
        'Dim resp As Integer = 0

        'Try
        '    If Verifica_perfil(usuario.pUsuario_conectado) = False Then
        '        Me.tsParametros.Enabled = False
        '    Else
        '        resp = MsgBox("Restaurar la base de datos provocará que los cambios que haya realizado posterior a la fecha del archivo backup se pierdan." & vbCrLf & vbCrLf & "Está completamente seguro de querer proceder con la restauración?" & vbCrLf & vbCrLf & "Aceptar para proceder, Cancelar para desistir.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")

        '        If resp = 1 Then
        '            Me.ofdRestoreBD.ShowDialog()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        'End Try

    End Sub

    Private Sub ConsumosMetrosCúbicosDeAsociadoPorPeríodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumosMetrosCúbicosDeAsociadoPorPeríodoToolStripMenuItem.Click
        Try
            If My.Forms.frmReporteConsumPeriodoSocio.Visible Then
                My.Forms.frmReporteConsumPeriodoSocio.BringToFront()
            Else
                My.Forms.frmReporteConsumPeriodoSocio.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

 
    Private Sub FacturaciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciToolStripMenuItem.Click
        My.Forms.frmFactPorRubroPeriodo.Show()
    End Sub

    Private Sub VerAbonadosConConvenioDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerAbonadosConConvenioDePagoToolStripMenuItem.Click
        Try
            If My.Forms.frmSociosConConvenioPago.Visible = False Then
                My.Forms.frmSociosConConvenioPago.Show()
            Else

                My.Forms.frmSociosConConvenioPago.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub VerAbonadosInactivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerAbonadosInactivosToolStripMenuItem.Click
        Try
            If My.Forms.frmSociosInactivos.Visible = True Then
                My.Forms.frmSociosInactivos.BringToFront()
            Else
                My.Forms.frmSociosInactivos.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    
    Private Sub Genera_recargo_masivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Genera_recargo_masivo.Click
        'Dim respuesta As Integer
        'respuesta = MsgBox("Esta acción genera una factura de recargo por las facturas pendientes de pago, vencidas a esta fecha. Esta operación no se puede deshacer." & vbCrLf & "Está seguro de querer continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Facturación masiva de cargos por pagos vencidos")
        'If respuesta = 1 Then
        My.Forms.frmPenaliza_masiva.Show()

        'Se ejecuta la rutina que lee todos los registros del período indicado, que tengan estatus de "pendiente de pago"
        'Se cargará un grid con los números de las facturas, a las que se les irá marcando como "Generó cargo = S"
        'Else
        'Exit Sub
        'End If
    End Sub

    Private Sub AutoCobranzaConCuentaPagosAnticipadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoCobranzaConCuentaPagosAnticipadosToolStripMenuItem.Click
        My.Forms.frmCuentas_auto_pago.Show()
    End Sub

    Private Sub FacturaciónAutomáticaPenalizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónAutomáticaPenalizaciónToolStripMenuItem.Click
        My.Forms.frmPenaliza_masiva_auto.Show()
    End Sub


    Private Sub CuentasDeSociosParaPagosAnticipadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentasDeSociosParaPagosAnticipadosToolStripMenuItem.Click
        If My.Forms.frmCuentas_ahorro_socios.Visible = True Then
            My.Forms.frmCuentas_ahorro_socios.BringToFront()
        Else
            My.Forms.frmCuentas_ahorro_socios.Show()
        End If
    End Sub

    Private Sub tsAnular_transac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAnular_transac.Click
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Verifica_usuario", conn)
                    comm.CommandType = CommandType.StoredProcedure

                    Dim usuario As New Datos.Users

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = usuario.pUsuario_conectado

                    Dim dr As SqlDataReader = comm.ExecuteReader

                    dr.Read()

                    If dr(0) <> "Administrador" Then
                        MsgBox("La operación de anular documentos (Abonos, cargos) sólo puede realizarlo un usuario con perfil Administrador.", MsgBoxStyle.Exclamation, "Pasat")
                        Me.tsAnular_transac.Enabled = False
                        Exit Sub
                    Else
                        If My.Forms.frmMenu_anulaciones.Visible = True Then
                            My.Forms.frmMenu_anulaciones.BringToFront()
                        Else
                            My.Forms.frmMenu_anulaciones.Show()
                        End If

                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub ConstantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConstantesToolStripMenuItem.Click
        If My.Forms.frmConstantes.Visible = False Then
            My.Forms.frmConstantes.Show()
        Else
            My.Forms.frmConstantes.BringToFront()
        End If
    End Sub
End Class