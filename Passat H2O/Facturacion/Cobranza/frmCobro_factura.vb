Imports System.Data
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmCobro_factura
    Dim instancia As New Datos.Users
    Dim cobro As New Datos.Cobros

    Private Sub frmCobro_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_Modalidad_pago()
        Me.txtPago_importe.Focus()
    End Sub

    Sub Carga_Modalidad_pago()
        Try
            Dim Modalidad As New List(Of Modalidad_pago)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0 Modo_ID , 'Seleccione modalidad' Descripcion UNION Select Modo_ID, Descripcion From Modalidad_Pago", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Modalidad_pago
                        lista.pModalidad_ID = items(0)
                        lista.pModalidad_Desc = items(1)
                        Modalidad.Add(lista)
                    End While

                    Me.cmbModalidad.DataSource = Modalidad
                    Me.cmbModalidad.ValueMember = "pModalidad_ID"
                    Me.cmbModalidad.DisplayMember = "pModalidad_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtSaldo_actual_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPago_importe.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.dtpFecha_abono.Focus()
        End If
    End Sub


    Function Asigna_variables() As Boolean
        With cobro
            .pFecha_abono = Me.dtpFecha_abono.Value
            .pFecha_transaccion = Date.Now

            .pFactura_Num = CType(Me.txtFactura_num.Text, Integer)
            .pSocio_ID = CType(Me.txtSocio_ID.Text, Integer)
            .pPropietario_nom = Me.txtPropietario.Text

            If Me.cmbModalidad.SelectedValue = 0 Then
                MsgBox("Seleccione una modalidad de pago.")
                Me.cmbModalidad.Focus()
                Return False
            Else
                .pModalidad_ID = Me.cmbModalidad.SelectedValue
            End If

            .pBanco = Me.txtBanco.Text
            .pReferencia_num = Me.txtReferencia.Text

            Try
                .pSaldo_actual = CType(Me.txtSaldo_actual.Text, Double)
            Catch ex As Exception
                MsgBox("El Saldo tiene formato de número no válido", MsgBoxStyle.Exclamation, "Pasat")
                Return False
            End Try

            Try
                .pAbono = CType(Me.txtPago_importe.Text, Double)
            Catch ex As Exception
                MsgBox("Verifique el valor del abono", MsgBoxStyle.Exclamation, "Pasat")
                Return False
            End Try

            Try
                If .pAbono > .pSaldo_actual Then
                    MsgBox("El valor del abono es mayor que el saldo a cancelar.", MsgBoxStyle.Exclamation, "Pasat")
                    Me.txtPago_importe.Focus()
                    Return False
                End If

                If .pAbono <= CType(0, Double) Then
                    MsgBox("El valor del abono debe ser mayor a cero y menor o igual que el saldo.", MsgBoxStyle.Exclamation, "Pasat")
                    Me.txtPago_importe.Focus()
                    Return False
                End If

                If .pAbono < .pSaldo_actual Then
                    Dim res As Integer
                    res = MsgBox("El valor del abono es menor que el saldo a cancelar. La factura quedará con un saldo pendiente y se sumará al historial de pagos pendientes del cliente." & vbCrLf & vbCrLf & "Aceptar para aplicar el abono. Cancelar para modificar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat")
                    If res <> 1 Then
                        Me.txtPago_importe.Focus()
                        Return False
                    End If
                End If

                .pNuevo_saldo = .pSaldo_actual - .pAbono
                .pAnotaciones = Me.txtAnotaciones.Text

            Catch ex As Exception
                MsgBox("Verifique el valor del abono", MsgBoxStyle.Exclamation, "Pasat")
                Return False
            End Try
        End With

        Dim respuesta As Integer = 0

        respuesta = MsgBox("Va a aplicar un abono de: $ " & cobro.pAbono & vbCrLf & "Factura: " & cobro.pFactura_Num & vbCrLf & "Nombre: " & cobro.pPropietario_nom & vbCrLf & "Si los datos son correctos, presione Aceptar o Cancelar para corregir la información", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Passat H2O")

        If respuesta = 1 Then
            Return True
        Else
            MsgBox("Se ha cancelado la operación", MsgBoxStyle.Information, "Passat H2O")
            Return False
        End If

    End Function

    Function Aplica_abono() As Boolean
        Try


            'Using conn As New SqlConnection(instancia.pCadena_conexion)
            '    conn.Open()
            '    Using comm As New SqlCommand("sp_Inserta_Abono_pago", conn)
            '        comm.CommandType = CommandType.StoredProcedure
            '        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = cobro.pSocio_ID
            '        comm.Parameters.Add("@Factura_Num", SqlDbType.Int).Value = cobro.pFactura_Num
            '        comm.Parameters.Add("@Saldo_actual", SqlDbType.Decimal, 2).Value = cobro.pSaldo_actual
            '        comm.Parameters.Add("@Abono", SqlDbType.Decimal, 2).Value = cobro.pAbono
            '        comm.Parameters.Add("@Nuevo_saldo", SqlDbType.Decimal, 2).Value = cobro.pNuevo_saldo
            '        comm.Parameters.Add("@Fecha_abono", SqlDbType.DateTime).Value = cobro.pFecha_abono
            '        comm.Parameters.Add("@Fecha_Transac", SqlDbType.DateTime).Value = cobro.pFecha_transaccion
            '        Dim usuario As New Datos.Users

            '        comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = usuario.pUsuario_conectado
            '        comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar, 500).Value = cobro.pAnotaciones
            '        comm.Parameters.Add("@Modalidad_abono", SqlDbType.Int).Value = cobro.pModalidad_ID
            '        comm.Parameters.Add("@Banco", SqlDbType.VarChar, 50).Value = cobro.pBanco
            '        comm.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = cobro.pReferencia_num

            '        Dim dr As SqlDataReader = comm.ExecuteReader()
            '        dr.Read()
            '        cobro.pTransac_Num = dr(0)
            '        Return True
            '    End Using
            'End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
            Return False
        End Try
    End Function

    Private Sub txtPago_importe_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPago_importe.Leave
        If Me.txtPago_importe.Text = String.Empty Then Me.txtPago_importe.Text = 0
        Try
            cobro.pAbono = CType(Me.txtPago_importe.Text, Decimal)
        Catch ex As Exception
            cobro.pAbono = 0
            MsgBox("Ingrese un cantidad válida. El abono debe ser un número mayor que cero.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Me.txtPago_importe.Focus()
            Exit Sub
        End Try
    End Sub

   
    Private Sub txtBanco_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBanco.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtReferencia.Focus()
        End If
    End Sub

    Private Sub txtReferencia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtAnotaciones.Focus()
        End If
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Asigna_variables() Then
            'Procede el abono
            If Aplica_abono() Then
                My.Forms.frmImprime_Recibo.Transac_Num = cobro.pTransac_Num
                My.Forms.frmImprime_Recibo.Factura_num = cobro.pFactura_Num
                My.Forms.frmImprime_Recibo.Show()
                My.Forms.frmFacturas_listado.txtSocio_ID.Clear()
                Me.Close()
            Else
                MsgBox("Ha ocurrido un error al aplicar el abono. Verifique los datos e intente de nuevo.", MsgBoxStyle.Information, "Pasat")
                Me.Close()
            End If
        End If
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class