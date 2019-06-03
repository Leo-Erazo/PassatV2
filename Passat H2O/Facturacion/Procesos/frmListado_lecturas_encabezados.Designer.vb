<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListado_lecturas_encabezados
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblLineas_mostradas = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnEmitir_facturas = New System.Windows.Forms.ToolStripButton
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.dgvLista_lecturas = New System.Windows.Forms.DataGridView
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvLista_lecturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblLineas_mostradas})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 354)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(885, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(104, 17)
        Me.ToolStripStatusLabel1.Text = "Líneas mostradas: "
        '
        'lblLineas_mostradas
        '
        Me.lblLineas_mostradas.Name = "lblLineas_mostradas"
        Me.lblLineas_mostradas.Size = New System.Drawing.Size(13, 17)
        Me.lblLineas_mostradas.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEmitir_facturas, Me.ToolStripLabel1, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(885, 39)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnEmitir_facturas
        '
        Me.btnEmitir_facturas.Image = Global.Passat_H2O.My.Resources.Resources._Rem
        Me.btnEmitir_facturas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEmitir_facturas.Name = "btnEmitir_facturas"
        Me.btnEmitir_facturas.Size = New System.Drawing.Size(174, 36)
        Me.btnEmitir_facturas.Text = "Generar Recibos de Pago"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 36)
        Me.btnCerrar.Text = "Cerrar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(308, 36)
        Me.ToolStripLabel1.Text = "  Listados de Lecturas de Consumo"
        '
        'dgvLista_lecturas
        '
        Me.dgvLista_lecturas.AllowUserToAddRows = False
        Me.dgvLista_lecturas.AllowUserToDeleteRows = False
        Me.dgvLista_lecturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLista_lecturas.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvLista_lecturas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLista_lecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLista_lecturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLista_lecturas.Location = New System.Drawing.Point(0, 39)
        Me.dgvLista_lecturas.Name = "dgvLista_lecturas"
        Me.dgvLista_lecturas.ReadOnly = True
        Me.dgvLista_lecturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLista_lecturas.Size = New System.Drawing.Size(885, 315)
        Me.dgvLista_lecturas.TabIndex = 2
        '
        'frmListado_lecturas_encabezados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 376)
        Me.Controls.Add(Me.dgvLista_lecturas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmListado_lecturas_encabezados"
        Me.Text = "Listados de Lecturas de Consumo Generados"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvLista_lecturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents dgvLista_lecturas As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLineas_mostradas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEmitir_facturas As System.Windows.Forms.ToolStripButton
End Class
