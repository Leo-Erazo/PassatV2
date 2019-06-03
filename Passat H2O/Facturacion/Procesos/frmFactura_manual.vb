Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmFactura_manual
    Dim instancia As New Datos.Users
    Dim Precio As Double
    Dim Importe_cargo As Double
    Dim Generando_Cargo_Pago_tardio As Boolean = False


    Private Sub frmFactura_manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServicio.Click
        If Me.txtSocio_ID.Text = String.Empty Then
            MsgBox("Seleccione un socio a quien ha de facturarse el servicio.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Me.txtSocio_ID.Focus()
            Exit Sub
        End If

        Me.PanelServicios.Visible = True
        Me.PanelServicios.BringToFront()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Servicios_para_facturar", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvServicios.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PanelServicios.Visible = False
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        Try
            If Me.dgvServicios.Rows.Count = 0 Then Exit Sub
            Me.txtServicio_ID.Text = Me.dgvServicios.SelectedCells(0).Value
            Me.txtServicio_desc.Text = Me.dgvServicios.SelectedCells(1).Value
            Precio = Me.dgvServicios.SelectedCells(2).Value
            Me.PanelServicios.Visible = False
            Me.txtAnotaciones.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub dgvServicios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicios.CellDoubleClick
        btnSeleccionar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnSocio_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSocio_ID.Click
        Me.PanelSocios.Visible = True
        Lista_socios(Me.txtBusque_nombre.Text)
    End Sub

    Sub Lista_socios(ByVal Nombre As String)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Socios_para_facturar", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 50).Value = Nombre
                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSocios.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub txtBusque_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusque_nombre.TextChanged
        If Me.txtBusque_nombre.Text = String.Empty Then Exit Sub
        Lista_socios(Me.txtBusque_nombre.Text)
    End Sub

    Private Sub btnSelecc_socios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecc_socios.Click
        Try
            If Me.dgvSocios.Rows.Count = 0 Then Exit Sub
            Me.txtSocio_ID.Text = Me.dgvSocios.SelectedCells(0).Value
            Me.txtSocio_nombre.Text = Me.dgvSocios.SelectedCells(1).Value
            Me.txtDireccion.Text = Me.dgvSocios.SelectedCells(2).Value
            Me.PanelSocios.Visible = False
            Me.txtServicio_ID.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub dgvSocios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSocios.CellDoubleClick
        btnSelecc_socios_Click(Nothing, Nothing)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            If Me.txtSocio_ID.Text = String.Empty Then Exit Sub
            If Me.txtServicio_ID.Text = String.Empty Then Exit Sub
            If Precio = 0 Then
                MsgBox("No puede facturar un servicio con costo cero!", MsgBoxStyle.Exclamation, "Pasat H2O")
                Exit Sub
            End If



            If Me.dgvCargos.Columns.Count = 0 Then
                Me.dgvCargos.Columns.Add("Servicio_ID", "Código")
                Me.dgvCargos.Columns.Add("Servicio_Desc", "Descripción")
                Me.dgvCargos.Columns.Add("Costo_uni", "Costo Unit")
            End If

            Me.dgvCargos.Rows.Add()
            With Me.dgvCargos
                .Item(0, .Rows.Count - 1).Value = Me.txtServicio_ID.Text
                .Item(1, .Rows.Count - 1).Value = Me.txtServicio_desc.Text
                .Item(2, .Rows.Count - 1).Value = Precio
            End With

            Me.txtServicio_ID.Clear()
            Me.txtServicio_desc.Clear()
            Me.txtAnotaciones.Clear()
            Me.btnServicio.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If Me.dgvCargos.Rows.Count = 0 Then Exit Sub
        Me.dgvCargos.Rows.Remove(Me.dgvCargos.SelectedRows(0))
    End Sub

    Private Sub btnCerrarSocios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarSocios.Click
        Me.PanelSocios.Visible = False
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Me.txtSocio_ID.Text = String.Empty Then
            MsgBox("Debe indicar el socio al que se ha de facturar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
            Exit Sub
        End If

        If Me.dgvCargos.Rows.Count = 0 Then
            MsgBox("Debe indicar el servicio que se ha de facturar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
            Importe_cargo = 0
            Exit Sub
        Else
            Dim i As Integer
            Importe_cargo = 0
            For i = 0 To Me.dgvCargos.Rows.Count - 1
                Importe_cargo += CType(Me.dgvCargos.Item(2, i).Value, Double)
            Next
        End If

        Guarda_Factura()
    End Sub

    Dim Transac_num, Factura_num As Integer

    Sub Guarda_Factura()

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()

                Using comm As New SqlCommand("sp_Genera_FACTURACION_Manual", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Date.Now
                    Dim usuario As New Datos.Users

                    comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUsuario_conectado
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = CType(Me.txtSocio_ID.Text, Integer)
                    comm.Parameters.Add("@Importe", SqlDbType.Decimal, 2).Value = Importe_cargo

                    If Me.chkManda_otro_periodo.Checked Then
                        comm.Parameters.Add("@Saldo", SqlDbType.Decimal, 2).Value = 0
                        comm.Parameters.Add("@Manda_otro_periodo", SqlDbType.VarChar, 50).Value = "Cobra en Próx. Período"
                    Else
                        comm.Parameters.Add("@Saldo", SqlDbType.Decimal, 2).Value = Importe_cargo
                        comm.Parameters.Add("@Manda_otro_periodo", SqlDbType.VarChar, 50).Value = "Pendiente Pago"
                    End If

                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    dr.Read()
                    Transac_num = dr(0)
                    Factura_num = dr(1)

                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
        End Try

        'Inicia el guardado de las líneas en Cobros_penalidad
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim i As Integer = 0

                For i = 0 To Me.dgvCargos.Rows.Count - 1
                    Using comm As New SqlCommand("sp_Genera_FACTURACION_Manual_Detalle", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        comm.Parameters.Add("@Transac_num", SqlDbType.Int).Value = Transac_num
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = CType(Me.txtSocio_ID.Text, Integer)
                        comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = Factura_num

                        Dim Cod_servicio As Integer = 0
                        Cod_servicio = CType(Me.dgvCargos.Item(0, i).Value, Integer)
                        comm.Parameters.Add("@Servicio_ID", SqlDbType.Int).Value = Cod_servicio

                        Dim Importe_cargo As Double = 0
                        Importe_cargo = CType(Me.dgvCargos.Item(2, i).Value, Integer)
                        comm.Parameters.Add("@Importe", SqlDbType.Int).Value = Importe_cargo

                        comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar, 500).Value = Me.txtAnotaciones.Text
                        If Me.chkManda_otro_periodo.Checked Then
                            comm.Parameters.Add("@Manda_otro_periodo", SqlDbType.VarChar, 1).Value = "S"
                        Else
                            comm.Parameters.Add("@Manda_otro_periodo", SqlDbType.VarChar, 1).Value = "N"
                        End If

                        comm.ExecuteNonQuery()

                    End Using
                Next
                If Me.chkManda_otro_periodo.Checked Then
                    MsgBox("El cargo ha sido generado satisfactoriamente. El cobro aparecerá en la factura del próximo período de facturación junto al consumo de agua.", MsgBoxStyle.Information, "Pasat H2O")
                Else
                    MsgBox("El cargo ha sido generado satisfactoriamente. Proceda a recibir y registrar el pago del usuario.", MsgBoxStyle.Information, "Pasat H2O")
                    'Meter aquí la rutina de facturación
                End If

                My.Forms.frmImprime_factura_manual.Tag = Factura_num
                My.Forms.frmImprime_factura_manual.Show()
            End Using

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
        End Try

    End Sub

    Private Sub txtSocio_ID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSocio_ID.Leave
        Try
            If Me.txtSocio_ID.Text = String.Empty Then Exit Sub

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Inquilino FROM Socios WHERE Socio_ID = '{0}'", Me.txtSocio_ID.Text), conn)
                    Dim dr As SqlDataReader = Nothing
                    dr.Read()
                    If dr.HasRows Then
                        Me.txtSocio_nombre.Text = dr(0)
                    Else
                        MsgBox("Cuenta de asociado no válida", MsgBoxStyle.Exclamation, "iLeon Pasat h2o")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ileon Pasat h20")
        End Try
    End Sub

    
    Private Sub btnCerrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar_servicios.Click
        Me.PanelServicios.Visible = False
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class