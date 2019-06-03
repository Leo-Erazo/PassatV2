<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprime_factura_manual
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
        Me.CryFactura_manual = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CryFactura_manual
        '
        Me.CryFactura_manual.ActiveViewIndex = -1
        Me.CryFactura_manual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CryFactura_manual.DisplayGroupTree = False
        Me.CryFactura_manual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CryFactura_manual.Location = New System.Drawing.Point(0, 0)
        Me.CryFactura_manual.Name = "CryFactura_manual"
        Me.CryFactura_manual.SelectionFormula = ""
        Me.CryFactura_manual.Size = New System.Drawing.Size(789, 424)
        Me.CryFactura_manual.TabIndex = 0
        Me.CryFactura_manual.ViewTimeSelectionFormula = ""
        '
        'frmImprime_factura_manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 424)
        Me.Controls.Add(Me.CryFactura_manual)
        Me.Name = "frmImprime_factura_manual"
        Me.Text = "Impresión de Factura Manual"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CryFactura_manual As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
