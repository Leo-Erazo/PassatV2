<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentas_ahorro_socios
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btnNueva = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnHistorial = New System.Windows.Forms.ToolStripDropDownButton
        Me.AplicarUnAbonoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RetirarFondosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerMovimientosDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.txtSocio_ID = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.txtNombre = New System.Windows.Forms.ToolStripTextBox
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton
        Me.dgvCuentas_ahorro = New System.Windows.Forms.DataGridView
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvCuentas_ahorro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 341)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(862, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNueva, Me.ToolStripSeparator1, Me.btnEliminar, Me.ToolStripSeparator3, Me.btnHistorial, Me.ToolStripLabel1, Me.btnCerrar})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(862, 39)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnNueva
        '
        Me.btnNueva.Image = Global.Passat_H2O.My.Resources.Resources.add
        Me.btnNueva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(77, 36)
        Me.btnNueva.Text = "Nueva"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Passat_H2O.My.Resources.Resources.cross
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 36)
        Me.btnEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btnHistorial
        '
        Me.btnHistorial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AplicarUnAbonoToolStripMenuItem, Me.RetirarFondosToolStripMenuItem, Me.VerMovimientosDeCuentaToolStripMenuItem})
        Me.btnHistorial.Image = Global.Passat_H2O.My.Resources.Resources.report
        Me.btnHistorial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHistorial.Name = "btnHistorial"
        Me.btnHistorial.Size = New System.Drawing.Size(122, 36)
        Me.btnHistorial.Text = "Movimientos"
        '
        'AplicarUnAbonoToolStripMenuItem
        '
        Me.AplicarUnAbonoToolStripMenuItem.Image = Global.Passat_H2O.My.Resources.Resources.money_add
        Me.AplicarUnAbonoToolStripMenuItem.Name = "AplicarUnAbonoToolStripMenuItem"
        Me.AplicarUnAbonoToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.AplicarUnAbonoToolStripMenuItem.Text = "Aplicar un abono a cuenta para pagos anticipados"
        '
        'RetirarFondosToolStripMenuItem
        '
        Me.RetirarFondosToolStripMenuItem.Image = Global.Passat_H2O.My.Resources.Resources.money_delete
        Me.RetirarFondosToolStripMenuItem.Name = "RetirarFondosToolStripMenuItem"
        Me.RetirarFondosToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.RetirarFondosToolStripMenuItem.Text = "Aplicar un cargo a la cuenta para pagos anticipados"
        '
        'VerMovimientosDeCuentaToolStripMenuItem
        '
        Me.VerMovimientosDeCuentaToolStripMenuItem.Image = Global.Passat_H2O.My.Resources.Resources.report
        Me.VerMovimientosDeCuentaToolStripMenuItem.Name = "VerMovimientosDeCuentaToolStripMenuItem"
        Me.VerMovimientosDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.VerMovimientosDeCuentaToolStripMenuItem.Text = "Ver movimientos de cuenta seleccionada"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(309, 36)
        Me.ToolStripLabel1.Text = "Cuentas de ahorro del asociado     "
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 36)
        Me.btnCerrar.Text = "Cerrar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.txtSocio_ID, Me.ToolStripLabel3, Me.txtNombre, Me.btnRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 39)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(862, 39)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(59, 36)
        Me.ToolStripLabel2.Text = "Asociado:"
        '
        'txtSocio_ID
        '
        Me.txtSocio_ID.Name = "txtSocio_ID"
        Me.txtSocio_ID.Size = New System.Drawing.Size(100, 39)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(54, 36)
        Me.ToolStripLabel3.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(200, 39)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.Passat_H2O.My.Resources.Resources.zoom_refresh
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 36)
        Me.btnRefresh.Text = "Generar"
        '
        'dgvCuentas_ahorro
        '
        Me.dgvCuentas_ahorro.AllowUserToAddRows = False
        Me.dgvCuentas_ahorro.AllowUserToDeleteRows = False
        Me.dgvCuentas_ahorro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCuentas_ahorro.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas_ahorro.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentas_ahorro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuentas_ahorro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuentas_ahorro.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCuentas_ahorro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas_ahorro.GridColor = System.Drawing.Color.White
        Me.dgvCuentas_ahorro.Location = New System.Drawing.Point(0, 78)
        Me.dgvCuentas_ahorro.Name = "dgvCuentas_ahorro"
        Me.dgvCuentas_ahorro.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentas_ahorro.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCuentas_ahorro.RowHeadersWidth = 20
        Me.dgvCuentas_ahorro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentas_ahorro.Size = New System.Drawing.Size(862, 263)
        Me.dgvCuentas_ahorro.TabIndex = 5
        '
        'frmCuentas_ahorro_socios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 363)
        Me.Controls.Add(Me.dgvCuentas_ahorro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmCuentas_ahorro_socios"
        Me.Text = "Maestro de cuentas de ahorro del asociado"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvCuentas_ahorro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNueva As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtSocio_ID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtNombre As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvCuentas_ahorro As System.Windows.Forms.DataGridView
    Friend WithEvents btnHistorial As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AplicarUnAbonoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetirarFondosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerMovimientosDeCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
