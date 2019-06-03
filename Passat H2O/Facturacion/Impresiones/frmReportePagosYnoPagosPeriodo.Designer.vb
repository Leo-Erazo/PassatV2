<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportePagosYnoPagosPeriodo
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
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.txtPeriodo_ID = New System.Windows.Forms.ToolStripTextBox
        Me.btnAceptar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.CryPagosYnoPagos = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtPeriodo_hasta = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.txtPeriodo_ID, Me.ToolStripLabel3, Me.txtPeriodo_hasta, Me.btnAceptar, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(812, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(85, 36)
        Me.ToolStripLabel2.Text = "Período desde:"
        '
        'txtPeriodo_ID
        '
        Me.txtPeriodo_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo_ID.Name = "txtPeriodo_ID"
        Me.txtPeriodo_ID.Size = New System.Drawing.Size(100, 39)
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Passat_H2O.My.Resources.Resources.zoom_refresh
        Me.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 36)
        Me.btnAceptar.Text = "Aceptar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(362, 36)
        Me.ToolStripLabel1.Text = "Reporte de Pagos e Impagos del período"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 36)
        Me.btnCerrar.Text = "Cerrar"
        '
        'CryPagosYnoPagos
        '
        Me.CryPagosYnoPagos.ActiveViewIndex = -1
        Me.CryPagosYnoPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CryPagosYnoPagos.DisplayGroupTree = False
        Me.CryPagosYnoPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CryPagosYnoPagos.Location = New System.Drawing.Point(0, 39)
        Me.CryPagosYnoPagos.Name = "CryPagosYnoPagos"
        Me.CryPagosYnoPagos.SelectionFormula = ""
        Me.CryPagosYnoPagos.Size = New System.Drawing.Size(812, 325)
        Me.CryPagosYnoPagos.TabIndex = 1
        Me.CryPagosYnoPagos.ViewTimeSelectionFormula = ""
        '
        'txtPeriodo_hasta
        '
        Me.txtPeriodo_hasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo_hasta.Name = "txtPeriodo_hasta"
        Me.txtPeriodo_hasta.Size = New System.Drawing.Size(100, 39)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(40, 36)
        Me.ToolStripLabel3.Text = "Hasta:"
        '
        'frmReportePagosYnoPagosPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 364)
        Me.Controls.Add(Me.CryPagosYnoPagos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmReportePagosYnoPagosPeriodo"
        Me.Text = "frmReportePagosYnoPagosPeriodo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CryPagosYnoPagos As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtPeriodo_ID As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtPeriodo_hasta As System.Windows.Forms.ToolStripTextBox
End Class
