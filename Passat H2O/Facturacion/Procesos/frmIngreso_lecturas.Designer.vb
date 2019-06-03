<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngreso_lecturas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tsInicio = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.txtPeriodo = New System.Windows.Forms.ToolStripTextBox
        Me.btnCargar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.btnSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblLineas = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsGuardado = New System.Windows.Forms.ToolStrip
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnInconsistencias = New System.Windows.Forms.ToolStripButton
        Me.btnFinalizar_lecturas = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvLecturas = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancelar_fecha = New System.Windows.Forms.Button
        Me.btnAceptar_fecha = New System.Windows.Forms.Button
        Me.dtpLectura = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.tsInicio.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tsGuardado.SuspendLayout()
        CType(Me.dgvLecturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsInicio
        '
        Me.tsInicio.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsInicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtPeriodo, Me.btnCargar, Me.ToolStripLabel2, Me.btnSalir})
        Me.tsInicio.Location = New System.Drawing.Point(0, 0)
        Me.tsInicio.Name = "tsInicio"
        Me.tsInicio.Size = New System.Drawing.Size(760, 39)
        Me.tsInicio.TabIndex = 0
        Me.tsInicio.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripLabel1.Text = "Ingrese Período:"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(100, 39)
        '
        'btnCargar
        '
        Me.btnCargar.Image = Global.Passat_H2O.My.Resources.Resources.zoom_refresh
        Me.btnCargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(131, 36)
        Me.btnCargar.Text = "Generar y Cargar"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(380, 36)
        Me.ToolStripLabel2.Text = "     Captura de lecturas de medidor de agua"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 36)
        Me.btnSalir.Text = "Cerrar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblLineas})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 322)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(760, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(101, 17)
        Me.ToolStripStatusLabel1.Text = "Líneas mostradas:"
        '
        'lblLineas
        '
        Me.lblLineas.Name = "lblLineas"
        Me.lblLineas.Size = New System.Drawing.Size(13, 17)
        Me.lblLineas.Text = "0"
        '
        'tsGuardado
        '
        Me.tsGuardado.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsGuardado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.ToolStripSeparator2, Me.btnInconsistencias, Me.btnFinalizar_lecturas, Me.ToolStripSeparator3})
        Me.tsGuardado.Location = New System.Drawing.Point(0, 39)
        Me.tsGuardado.Name = "tsGuardado"
        Me.tsGuardado.Size = New System.Drawing.Size(760, 39)
        Me.tsGuardado.TabIndex = 3
        Me.tsGuardado.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Passat_H2O.My.Resources.Resources.database_save
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(163, 36)
        Me.btnGuardar.Text = "1. Guardar los cambios"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnInconsistencias
        '
        Me.btnInconsistencias.Enabled = False
        Me.btnInconsistencias.Image = Global.Passat_H2O.My.Resources.Resources.eye
        Me.btnInconsistencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInconsistencias.Name = "btnInconsistencias"
        Me.btnInconsistencias.Size = New System.Drawing.Size(181, 36)
        Me.btnInconsistencias.Text = "2. Verificar Inconsistencias"
        '
        'btnFinalizar_lecturas
        '
        Me.btnFinalizar_lecturas.Enabled = False
        Me.btnFinalizar_lecturas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFinalizar_lecturas.Image = Global.Passat_H2O.My.Resources.Resources.lock
        Me.btnFinalizar_lecturas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinalizar_lecturas.Name = "btnFinalizar_lecturas"
        Me.btnFinalizar_lecturas.Size = New System.Drawing.Size(265, 36)
        Me.btnFinalizar_lecturas.Text = "3. Finalizar Lecturas y Calcular Facturación"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'dgvLecturas
        '
        Me.dgvLecturas.AllowUserToDeleteRows = False
        Me.dgvLecturas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvLecturas.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLecturas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLecturas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLecturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLecturas.GridColor = System.Drawing.Color.White
        Me.dgvLecturas.Location = New System.Drawing.Point(0, 78)
        Me.dgvLecturas.Name = "dgvLecturas"
        Me.dgvLecturas.Size = New System.Drawing.Size(760, 244)
        Me.dgvLecturas.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.btnCancelar_fecha)
        Me.Panel1.Controls.Add(Me.btnAceptar_fecha)
        Me.Panel1.Controls.Add(Me.dtpLectura)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(187, 101)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(321, 115)
        Me.Panel1.TabIndex = 5
        Me.Panel1.Visible = False
        '
        'btnCancelar_fecha
        '
        Me.btnCancelar_fecha.Location = New System.Drawing.Point(155, 80)
        Me.btnCancelar_fecha.Name = "btnCancelar_fecha"
        Me.btnCancelar_fecha.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar_fecha.TabIndex = 3
        Me.btnCancelar_fecha.Text = "Cancelar"
        Me.btnCancelar_fecha.UseVisualStyleBackColor = True
        '
        'btnAceptar_fecha
        '
        Me.btnAceptar_fecha.Location = New System.Drawing.Point(236, 80)
        Me.btnAceptar_fecha.Name = "btnAceptar_fecha"
        Me.btnAceptar_fecha.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar_fecha.TabIndex = 2
        Me.btnAceptar_fecha.Text = "Aceptar"
        Me.btnAceptar_fecha.UseVisualStyleBackColor = True
        '
        'dtpLectura
        '
        Me.dtpLectura.Location = New System.Drawing.Point(15, 51)
        Me.dtpLectura.Name = "dtpLectura"
        Me.dtpLectura.Size = New System.Drawing.Size(296, 20)
        Me.dtpLectura.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Por favor indique la fecha real cuando se " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hizo la lectura."
        '
        'frmIngreso_lecturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 344)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvLecturas)
        Me.Controls.Add(Me.tsGuardado)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsInicio)
        Me.Name = "frmIngreso_lecturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de lecturas de consumo de agua potable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsInicio.ResumeLayout(False)
        Me.tsInicio.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tsGuardado.ResumeLayout(False)
        Me.tsGuardado.PerformLayout()
        CType(Me.dgvLecturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsInicio As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtPeriodo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnCargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsGuardado As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgvLecturas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar_fecha As System.Windows.Forms.Button
    Friend WithEvents btnAceptar_fecha As System.Windows.Forms.Button
    Friend WithEvents dtpLectura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFinalizar_lecturas As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLineas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnInconsistencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
End Class
