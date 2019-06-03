<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPenaliza_masiva
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblVencimiento = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnGenera_factura = New System.Windows.Forms.Button
        Me.btnCambia_periodo = New System.Windows.Forms.Button
        Me.lblPeriodo_mostrado = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslblCuentaFacturas = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslblImporte_vencido = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsprogressbar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslblFacts_emitidas = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgListaFacturas = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgListaFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(890, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generación de facturas por penalización en pagos vencidos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblVencimiento)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnGenera_factura)
        Me.Panel1.Controls.Add(Me.btnCambia_periodo)
        Me.Panel1.Controls.Add(Me.lblPeriodo_mostrado)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(890, 126)
        Me.Panel1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(0, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Label4.Size = New System.Drawing.Size(890, 30)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nota: el listado muestra sólo los socios con estado 'Activo'. El recargo no se ap" & _
            "licará para los socios que tienen convenio para el período seleccionado o anteri" & _
            "or."
        '
        'lblVencimiento
        '
        Me.lblVencimiento.AutoSize = True
        Me.lblVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblVencimiento.ForeColor = System.Drawing.Color.Blue
        Me.lblVencimiento.Location = New System.Drawing.Point(214, 70)
        Me.lblVencimiento.Name = "lblVencimiento"
        Me.lblVencimiento.Size = New System.Drawing.Size(97, 17)
        Me.lblVencimiento.TabIndex = 7
        Me.lblVencimiento.Text = "Vencimiento..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(3, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(205, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha vencimiento del período:"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCerrar.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar.Location = New System.Drawing.Point(777, 50)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(38, 36)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGenera_factura
        '
        Me.btnGenera_factura.Location = New System.Drawing.Point(436, 66)
        Me.btnGenera_factura.Name = "btnGenera_factura"
        Me.btnGenera_factura.Size = New System.Drawing.Size(147, 23)
        Me.btnGenera_factura.TabIndex = 4
        Me.btnGenera_factura.Text = "Generar facturación..."
        Me.btnGenera_factura.UseVisualStyleBackColor = True
        '
        'btnCambia_periodo
        '
        Me.btnCambia_periodo.Location = New System.Drawing.Point(436, 39)
        Me.btnCambia_periodo.Name = "btnCambia_periodo"
        Me.btnCambia_periodo.Size = New System.Drawing.Size(147, 23)
        Me.btnCambia_periodo.TabIndex = 3
        Me.btnCambia_periodo.Text = "Seleccione otro período..."
        Me.btnCambia_periodo.UseVisualStyleBackColor = True
        '
        'lblPeriodo_mostrado
        '
        Me.lblPeriodo_mostrado.AutoSize = True
        Me.lblPeriodo_mostrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblPeriodo_mostrado.ForeColor = System.Drawing.Color.Blue
        Me.lblPeriodo_mostrado.Location = New System.Drawing.Point(214, 42)
        Me.lblPeriodo_mostrado.Name = "lblPeriodo_mostrado"
        Me.lblPeriodo_mostrado.Size = New System.Drawing.Size(69, 17)
        Me.lblPeriodo_mostrado.TabIndex = 2
        Me.lblPeriodo_mostrado.Text = "Período..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(3, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "El período mostrado es:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblCuentaFacturas, Me.ToolStripStatusLabel2, Me.tslblImporte_vencido, Me.tsprogressbar, Me.ToolStripStatusLabel3, Me.tslblFacts_emitidas})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 307)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(890, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(140, 17)
        Me.ToolStripStatusLabel1.Text = "Total facturas mostradas:"
        '
        'tslblCuentaFacturas
        '
        Me.tslblCuentaFacturas.Name = "tslblCuentaFacturas"
        Me.tslblCuentaFacturas.Size = New System.Drawing.Size(13, 17)
        Me.tslblCuentaFacturas.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(133, 17)
        Me.ToolStripStatusLabel2.Text = "Importe total vencido: $"
        '
        'tslblImporte_vencido
        '
        Me.tslblImporte_vencido.Name = "tslblImporte_vencido"
        Me.tslblImporte_vencido.Size = New System.Drawing.Size(28, 17)
        Me.tslblImporte_vencido.Text = "0.00"
        '
        'tsprogressbar
        '
        Me.tsprogressbar.Name = "tsprogressbar"
        Me.tsprogressbar.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(204, 17)
        Me.ToolStripStatusLabel3.Text = "Facturas por penalización generadas: "
        '
        'tslblFacts_emitidas
        '
        Me.tslblFacts_emitidas.Name = "tslblFacts_emitidas"
        Me.tslblFacts_emitidas.Size = New System.Drawing.Size(13, 17)
        Me.tslblFacts_emitidas.Text = "0"
        '
        'dgListaFacturas
        '
        Me.dgListaFacturas.AllowUserToAddRows = False
        Me.dgListaFacturas.AllowUserToDeleteRows = False
        Me.dgListaFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgListaFacturas.BackgroundColor = System.Drawing.Color.White
        Me.dgListaFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgListaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgListaFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgListaFacturas.Location = New System.Drawing.Point(0, 126)
        Me.dgListaFacturas.Name = "dgListaFacturas"
        Me.dgListaFacturas.RowHeadersWidth = 15
        Me.dgListaFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgListaFacturas.Size = New System.Drawing.Size(890, 181)
        Me.dgListaFacturas.TabIndex = 3
        '
        'frmPenaliza_masiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 329)
        Me.Controls.Add(Me.dgListaFacturas)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPenaliza_masiva"
        Me.Text = "Generación de cargos por penalización"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgListaFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPeriodo_mostrado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCambia_periodo As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGenera_factura As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblVencimiento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgListaFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblCuentaFacturas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblImporte_vencido As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsprogressbar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblFacts_emitidas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
