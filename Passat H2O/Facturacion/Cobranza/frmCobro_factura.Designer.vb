<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobro_factura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTransaccion_num = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFactura_num = New System.Windows.Forms.TextBox
        Me.txtSocio_ID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPropietario = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSaldo_actual = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPago_importe = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpFecha_abono = New System.Windows.Forms.DateTimePicker
        Me.txtAnotaciones = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbModalidad = New System.Windows.Forms.ComboBox
        Me.txtBanco = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(494, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(278, 36)
        Me.ToolStripLabel1.Text = "Captura de pago del socio          "
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 36)
        Me.btnCerrar.Text = "Cerrar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 409)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(494, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Transacción del Sistema"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTransaccion_num
        '
        Me.txtTransaccion_num.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTransaccion_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransaccion_num.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtTransaccion_num.ForeColor = System.Drawing.Color.Blue
        Me.txtTransaccion_num.Location = New System.Drawing.Point(196, 48)
        Me.txtTransaccion_num.Name = "txtTransaccion_num"
        Me.txtTransaccion_num.ReadOnly = True
        Me.txtTransaccion_num.Size = New System.Drawing.Size(100, 21)
        Me.txtTransaccion_num.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(407, 376)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 30)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(55, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Factura del sistema:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFactura_num
        '
        Me.txtFactura_num.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFactura_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFactura_num.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFactura_num.ForeColor = System.Drawing.Color.Blue
        Me.txtFactura_num.Location = New System.Drawing.Point(196, 73)
        Me.txtFactura_num.Name = "txtFactura_num"
        Me.txtFactura_num.ReadOnly = True
        Me.txtFactura_num.Size = New System.Drawing.Size(100, 21)
        Me.txtFactura_num.TabIndex = 1
        '
        'txtSocio_ID
        '
        Me.txtSocio_ID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSocio_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSocio_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtSocio_ID.ForeColor = System.Drawing.Color.Blue
        Me.txtSocio_ID.Location = New System.Drawing.Point(196, 98)
        Me.txtSocio_ID.Name = "txtSocio_ID"
        Me.txtSocio_ID.ReadOnly = True
        Me.txtSocio_ID.Size = New System.Drawing.Size(100, 21)
        Me.txtSocio_ID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(107, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cuenta No.:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPropietario
        '
        Me.txtPropietario.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPropietario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtPropietario.ForeColor = System.Drawing.Color.Blue
        Me.txtPropietario.Location = New System.Drawing.Point(196, 123)
        Me.txtPropietario.Name = "txtPropietario"
        Me.txtPropietario.ReadOnly = True
        Me.txtPropietario.Size = New System.Drawing.Size(288, 21)
        Me.txtPropietario.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(15, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Nombre Titular de Cuenta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSaldo_actual
        '
        Me.txtSaldo_actual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSaldo_actual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldo_actual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtSaldo_actual.ForeColor = System.Drawing.Color.Blue
        Me.txtSaldo_actual.Location = New System.Drawing.Point(196, 148)
        Me.txtSaldo_actual.Name = "txtSaldo_actual"
        Me.txtSaldo_actual.ReadOnly = True
        Me.txtSaldo_actual.Size = New System.Drawing.Size(100, 21)
        Me.txtSaldo_actual.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(99, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Saldo Actual:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPago_importe
        '
        Me.txtPago_importe.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPago_importe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPago_importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtPago_importe.ForeColor = System.Drawing.Color.Blue
        Me.txtPago_importe.Location = New System.Drawing.Point(196, 175)
        Me.txtPago_importe.Name = "txtPago_importe"
        Me.txtPago_importe.Size = New System.Drawing.Size(100, 24)
        Me.txtPago_importe.TabIndex = 5
        Me.txtPago_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(68, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Importe  del pago:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(326, 376)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(52, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Fecha real del pago:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha_abono
        '
        Me.dtpFecha_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtpFecha_abono.Location = New System.Drawing.Point(196, 204)
        Me.dtpFecha_abono.Name = "dtpFecha_abono"
        Me.dtpFecha_abono.Size = New System.Drawing.Size(249, 21)
        Me.dtpFecha_abono.TabIndex = 6
        '
        'txtAnotaciones
        '
        Me.txtAnotaciones.BackColor = System.Drawing.Color.White
        Me.txtAnotaciones.Location = New System.Drawing.Point(18, 328)
        Me.txtAnotaciones.MaxLength = 500
        Me.txtAnotaciones.Multiline = True
        Me.txtAnotaciones.Name = "txtAnotaciones"
        Me.txtAnotaciones.Size = New System.Drawing.Size(464, 42)
        Me.txtAnotaciones.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Anotaciones:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(57, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Modalidad de pago:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModalidad
        '
        Me.cmbModalidad.FormattingEnabled = True
        Me.cmbModalidad.Location = New System.Drawing.Point(196, 231)
        Me.cmbModalidad.Name = "cmbModalidad"
        Me.cmbModalidad.Size = New System.Drawing.Size(247, 21)
        Me.cmbModalidad.TabIndex = 7
        '
        'txtBanco
        '
        Me.txtBanco.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtBanco.ForeColor = System.Drawing.Color.Blue
        Me.txtBanco.Location = New System.Drawing.Point(258, 258)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(185, 21)
        Me.txtBanco.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(204, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Banco:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtReferencia.ForeColor = System.Drawing.Color.Blue
        Me.txtReferencia.Location = New System.Drawing.Point(258, 285)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(185, 21)
        Me.txtReferencia.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(15, 289)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(237, 17)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "No. Cheque, remesa o transferencia"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCobro_factura
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(494, 431)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtBanco)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbModalidad)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAnotaciones)
        Me.Controls.Add(Me.dtpFecha_abono)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtPago_importe)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSaldo_actual)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPropietario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSocio_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFactura_num)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtTransaccion_num)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCobro_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pasat H2O :: Cobro de Factura"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTransaccion_num As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFactura_num As System.Windows.Forms.TextBox
    Friend WithEvents txtSocio_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPropietario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo_actual As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPago_importe As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha_abono As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAnotaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbModalidad As System.Windows.Forms.ComboBox
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
End Class
