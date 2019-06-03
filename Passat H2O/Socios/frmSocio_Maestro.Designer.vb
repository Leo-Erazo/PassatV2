<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSocio_Maestro
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.btnSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblLineas_mostradas = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.txtCuenta_Num = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.txtpropietario = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.dgvSocios_maestro = New System.Windows.Forms.DataGridView
        Me.cmbSector = New System.Windows.Forms.ComboBox
        Me.cmbBloque = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.nupFuente_size = New System.Windows.Forms.NumericUpDown
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dgvSocios_maestro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupFuente_size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.ToolStripSeparator1, Me.btnEditar, Me.ToolStripSeparator2, Me.btnEliminar, Me.ToolStripLabel1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1082, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Passat_H2O.My.Resources.Resources.add
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 36)
        Me.btnNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Passat_H2O.My.Resources.Resources.database_edit
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(73, 36)
        Me.btnEditar.Text = "Editar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Passat_H2O.My.Resources.Resources.cross
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 36)
        Me.btnEliminar.Text = "Eliminar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(317, 36)
        Me.ToolStripLabel1.Text = "Listado Maestro de Asociados            "
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(65, 36)
        Me.btnSalir.Text = "Salir"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblLineas_mostradas})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 424)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1082, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(104, 17)
        Me.ToolStripStatusLabel1.Text = "Lineas Mostradas: "
        '
        'lblLineas_mostradas
        '
        Me.lblLineas_mostradas.Name = "lblLineas_mostradas"
        Me.lblLineas_mostradas.Size = New System.Drawing.Size(10, 17)
        Me.lblLineas_mostradas.Text = "."
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.txtCuenta_Num, Me.ToolStripLabel3, Me.txtpropietario, Me.ToolStripLabel4})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 39)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1082, 25)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel2.Text = "Busque No. Cuenta"
        '
        'txtCuenta_Num
        '
        Me.txtCuenta_Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta_Num.Name = "txtCuenta_Num"
        Me.txtCuenta_Num.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripLabel3.Text = "Nombre propietario:"
        '
        'txtpropietario
        '
        Me.txtpropietario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpropietario.Name = "txtpropietario"
        Me.txtpropietario.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(323, 22)
        Me.ToolStripLabel4.Text = "Sector:                                                                          " & _
            "      Bloque:"
        '
        'dgvSocios_maestro
        '
        Me.dgvSocios_maestro.AllowUserToAddRows = False
        Me.dgvSocios_maestro.AllowUserToDeleteRows = False
        Me.dgvSocios_maestro.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSocios_maestro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSocios_maestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSocios_maestro.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSocios_maestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSocios_maestro.Location = New System.Drawing.Point(0, 64)
        Me.dgvSocios_maestro.Name = "dgvSocios_maestro"
        Me.dgvSocios_maestro.ReadOnly = True
        Me.dgvSocios_maestro.Size = New System.Drawing.Size(1082, 360)
        Me.dgvSocios_maestro.TabIndex = 4
        '
        'cmbSector
        '
        Me.cmbSector.FormattingEnabled = True
        Me.cmbSector.Location = New System.Drawing.Point(535, 42)
        Me.cmbSector.Name = "cmbSector"
        Me.cmbSector.Size = New System.Drawing.Size(221, 21)
        Me.cmbSector.TabIndex = 0
        '
        'cmbBloque
        '
        Me.cmbBloque.FormattingEnabled = True
        Me.cmbBloque.Location = New System.Drawing.Point(812, 43)
        Me.cmbBloque.Name = "cmbBloque"
        Me.cmbBloque.Size = New System.Drawing.Size(161, 21)
        Me.cmbBloque.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(979, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fuente:"
        '
        'nupFuente_size
        '
        Me.nupFuente_size.Location = New System.Drawing.Point(1022, 42)
        Me.nupFuente_size.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nupFuente_size.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nupFuente_size.Name = "nupFuente_size"
        Me.nupFuente_size.Size = New System.Drawing.Size(38, 20)
        Me.nupFuente_size.TabIndex = 11
        Me.nupFuente_size.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'frmSocio_Maestro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 446)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nupFuente_size)
        Me.Controls.Add(Me.cmbBloque)
        Me.Controls.Add(Me.cmbSector)
        Me.Controls.Add(Me.dgvSocios_maestro)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSocio_Maestro"
        Me.Text = "Listado Maestro de Asociados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dgvSocios_maestro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupFuente_size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLineas_mostradas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCuenta_Num As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dgvSocios_maestro As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbSector As System.Windows.Forms.ComboBox
    Friend WithEvents txtpropietario As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbBloque As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nupFuente_size As System.Windows.Forms.NumericUpDown
End Class
