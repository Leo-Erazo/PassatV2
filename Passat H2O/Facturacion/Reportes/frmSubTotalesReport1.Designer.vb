<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubTotalesReport1
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
        Me.txtSubtotales = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtSubtotales
        '
        Me.txtSubtotales.BackColor = System.Drawing.Color.White
        Me.txtSubtotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubtotales.Location = New System.Drawing.Point(0, 0)
        Me.txtSubtotales.Multiline = True
        Me.txtSubtotales.Name = "txtSubtotales"
        Me.txtSubtotales.ReadOnly = True
        Me.txtSubtotales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSubtotales.Size = New System.Drawing.Size(537, 85)
        Me.txtSubtotales.TabIndex = 0
        '
        'frmSubTotalesReport1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 85)
        Me.Controls.Add(Me.txtSubtotales)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubTotalesReport1"
        Me.Text = "Sub Totales para los rubros facturados"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSubtotales As System.Windows.Forms.TextBox
End Class
