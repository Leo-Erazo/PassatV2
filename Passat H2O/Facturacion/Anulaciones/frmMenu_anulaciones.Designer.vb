<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu_anulaciones
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
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnAnula_abono_factura = New System.Windows.Forms.Button
        Me.btnAnular_extraordinaria = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnAnula_penalizacion = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(366, 233)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAnula_abono_factura
        '
        Me.btnAnula_abono_factura.Location = New System.Drawing.Point(23, 39)
        Me.btnAnula_abono_factura.Name = "btnAnula_abono_factura"
        Me.btnAnula_abono_factura.Size = New System.Drawing.Size(75, 23)
        Me.btnAnula_abono_factura.TabIndex = 0
        Me.btnAnula_abono_factura.Text = "Seleccionar"
        Me.btnAnula_abono_factura.UseVisualStyleBackColor = True
        '
        'btnAnular_extraordinaria
        '
        Me.btnAnular_extraordinaria.Location = New System.Drawing.Point(23, 124)
        Me.btnAnular_extraordinaria.Name = "btnAnular_extraordinaria"
        Me.btnAnular_extraordinaria.Size = New System.Drawing.Size(75, 23)
        Me.btnAnular_extraordinaria.TabIndex = 3
        Me.btnAnular_extraordinaria.Text = "Seleccionar"
        Me.btnAnular_extraordinaria.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(23, 153)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Seleccionar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Anular un abono a cuenta de fondos para pagos anticipados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Anular una factura de servicio extraordinaria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(104, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Anular un abono a factura"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkRed
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(453, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Seleccione el tipo de documento a anular"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(104, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(325, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Anular un cargo o retiro a cuenta de fondos para pagos anticipados"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(23, 182)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Seleccionar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(104, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(258, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Anular factura por penalización en vencimiento pago."
        '
        'btnAnula_penalizacion
        '
        Me.btnAnula_penalizacion.Location = New System.Drawing.Point(23, 68)
        Me.btnAnula_penalizacion.Name = "btnAnula_penalizacion"
        Me.btnAnula_penalizacion.Size = New System.Drawing.Size(75, 23)
        Me.btnAnula_penalizacion.TabIndex = 1
        Me.btnAnula_penalizacion.Text = "Seleccionar"
        Me.btnAnula_penalizacion.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(104, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Tag = ""
        Me.Label7.Text = "Anular un Servicio o Rubro en la Factura."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Seleccionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gray
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 259)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(453, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Una vez anulada no se puede revertir la operación"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMenu_anulaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 282)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnAnula_penalizacion)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnAnular_extraordinaria)
        Me.Controls.Add(Me.btnAnula_abono_factura)
        Me.Controls.Add(Me.btnCerrar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenu_anulaciones"
        Me.Text = "Tipos de documentos que puede anular"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAnula_abono_factura As System.Windows.Forms.Button
    Friend WithEvents btnAnular_extraordinaria As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAnula_penalizacion As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
