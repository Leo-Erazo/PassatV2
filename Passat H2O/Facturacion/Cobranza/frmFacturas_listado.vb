Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmFacturas_listado
    Dim instancia As New Datos.Users
    Public cargando As Boolean = True

    Private Sub frmFacturas_listado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If cargando Then Exit Sub
        btnBuscar_Click(Nothing, Nothing)
        cargando = False
    End Sub

    Private Sub frmFacturas_listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = My.Forms.frmPrincipal
            Lista_Facturas()
            Me.cmbEstado_fact.SelectedIndex = 0
            Me.cmbTipoFactura.SelectedIndex = 0
            Me.Width = frmPrincipal.Width - 50
            Me.Height = frmPrincipal.Height - 200
            Me.StartPosition = FormStartPosition.CenterScreen
            cargando = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
        
    End Sub

    Sub Lista_Facturas()
        Try

            'Me.btnBuscar.Enabled = False

            Dim socio_ID As Integer = 0
            Try
                If Me.txtSocio_ID.Text = Nothing Then
                    socio_ID = 0
                Else
                    socio_ID = Me.txtSocio_ID.Text
                End If

            Catch ex As Exception
                socio_ID = 0
            End Try

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(("sp_Lista_Facturas"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@flag", SqlDbType.Bit).Value = cargando

                    If socio_ID <> 0 Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = socio_ID
                    End If

                    Dim periodo As String = Me.txtPeriodo.Text
                    If periodo <> "" Then
                        comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Me.txtPeriodo.Text
                    End If

                    Dim Factura_num As Integer = 0
                    If Me.txtFactura_num.Text <> Nothing Then
                        Try
                            Factura_num = CType(Me.txtFactura_num.Text, Integer)
                        Catch ex As Exception
                            Factura_num = 0
                            MsgBox("Número de factura no válido!", MsgBoxStyle.Exclamation, "Listado de facturas")
                            Me.txtFactura_num.Text = Nothing
                        End Try
                    End If


                    If Factura_num <> 0 Then
                        comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = Factura_num
                    End If

                    If Me.cmbTipoFactura.SelectedIndex > 0 Then
                        comm.Parameters.Add("@Tipo_Factura", SqlDbType.VarChar, 14).Value = Me.cmbTipoFactura.Text
                    End If

                    If Me.cmbEstado_fact.SelectedIndex > 0 Then
                        comm.Parameters.Add("@Estado_Factura", SqlDbType.VarChar, 25).Value = Me.cmbEstado_fact.Text
                    End If

                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvFacturas.DataSource = tabla
                    If Me.dgvFacturas.Rows.Count > 0 Then
                        Me.dgvFacturas.Columns(6).DefaultCellStyle.Format = "c"
                        Me.dgvFacturas.Columns(7).DefaultCellStyle.Format = "c"
                        Me.dgvFacturas.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.dgvFacturas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.lblLineas.Text = Me.dgvFacturas.Rows.Count
                        tabla = Nothing
                    Else
                        Me.lblLineas.Text = 0
                    End If

                End Using
            End Using

            Me.btnBuscar.Text = "Buscar"
            Me.btnBuscar.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        cargando = False
        Lista_Facturas()
    End Sub

    Private Sub btnRegistrar_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar_pago.Click
        'Transfiere los datos al formulario FrmCobro_factura
        Dim Socio_id As Integer = 0
        Dim facturaNum As Integer = 0
        Dim saldoFactura As Double = 0
        Dim periodo_factura As Integer = 0

        Socio_id = Me.dgvFacturas.SelectedCells(4).Value

        facturaNum = CType(Me.dgvFacturas.SelectedCells(1).Value, Integer)
        periodo_factura = CType(Me.dgvFacturas.SelectedCells(3).Value, Integer)
        saldoFactura = CType(Me.dgvFacturas.SelectedCells(7).Value, Double)


        Try

            If saldoFactura = 0 Then
                MsgBox("Esta factura tiene saldo cero y no puede recibir abonos!", MsgBoxStyle.Information, "Pasat H2O")
                Exit Sub
            End If

            If verifica_facturas_anteriores(Socio_id, periodo_factura) Then
                My.Forms.frmPago_factura.Factura_Num = Me.dgvFacturas.SelectedCells(1).Value.ToString
                My.Forms.frmPago_factura.Socio_ID = Me.dgvFacturas.SelectedCells(4).Value.ToString
                My.Forms.frmPago_factura.Socio_Nombre = Me.dgvFacturas.SelectedCells(5).Value.ToString
                My.Forms.frmPago_factura.Periodo_ID = Me.dgvFacturas.SelectedCells(3).Value.ToString
                My.Forms.frmPago_factura.Vence = Me.dgvFacturas.SelectedCells(9).Value.ToString
                My.Forms.frmPago_factura.Show()
            Else
                Exit Sub
            End If

            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
        End Try
    End Sub


    Function verifica_facturas_anteriores(ByVal socio_id As Integer, ByVal periodo_factura As Integer) As Boolean

        'Verificamos si tiene facturas con saldo, de períodos anteriores para forzarlo que haga primero el pago de estas

        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("Lista_facturas_vencidas_en_pago", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.Add("@Socio_Id", SqlDbType.Int).Value = socio_id
                comm.Parameters.Add("@Periodo_factura", SqlDbType.Int).Value = periodo_factura

                Dim dr As SqlDataReader = comm.ExecuteReader
                If dr.HasRows Then

                    Dim i As Integer = 0
                    While dr.Read
                        i += 1
                    End While
                    If i > 1 Then
                        MsgBox(String.Format("El Socio tiene '{0}' facturas pendientes de pago, que deberán ser pagadas antes de abonarle a la factura que usted ha elegido." & vbCrLf & vbCrLf & "Seleccione las más antigua para continuar con el abono.", i - 1))
                        Me.txtSocio_ID.Text = socio_id
                        Me.cmbTipoFactura.SelectedIndex = 1
                        btnBuscar_Click(Nothing, Nothing)
                        Return False
                    End If

                End If
            End Using
        End Using
        'En caso que no haya encontrado facturas anteriores
        Return True
    End Function



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub cmbTipoFactura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoFactura.SelectedIndexChanged
        'If cargando Then Exit Sub
        'btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub cmbEstado_fact_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado_fact.SelectedIndexChanged
        'If cargando Then Exit Sub
        'btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgvFacturas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturas.CellDoubleClick
        ' btnRegistrar_pago_Click(Nothing, Nothing)
    End Sub


    Private Sub nupFuente_size_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupFuente_size.ValueChanged
        Me.dgvFacturas.DefaultCellStyle.Font = New Font("Arial", Me.nupFuente_size.Value)
    End Sub
End Class