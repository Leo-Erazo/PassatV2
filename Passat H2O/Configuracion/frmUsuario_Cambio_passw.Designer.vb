<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario_Cambio_passw
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
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUsuario_id = New System.Windows.Forms.TextBox
        Me.txtTipoUsuario = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPass_actual = New System.Windows.Forms.TextBox
        Me.txtPassNuevo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPasswConfirma = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.lblCoinciden = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(310, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(59, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario ID"
        '
        'txtUsuario_id
        '
        Me.txtUsuario_id.BackColor = System.Drawing.SystemColors.Info
        Me.txtUsuario_id.Location = New System.Drawing.Point(90, 47)
        Me.txtUsuario_id.Name = "txtUsuario_id"
        Me.txtUsuario_id.ReadOnly = True
        Me.txtUsuario_id.Size = New System.Drawing.Size(55, 20)
        Me.txtUsuario_id.TabIndex = 2
        '
        'txtTipoUsuario
        '
        Me.txtTipoUsuario.BackColor = System.Drawing.SystemColors.Info
        Me.txtTipoUsuario.Location = New System.Drawing.Point(90, 73)
        Me.txtTipoUsuario.Name = "txtTipoUsuario"
        Me.txtTipoUsuario.ReadOnly = True
        Me.txtTipoUsuario.Size = New System.Drawing.Size(279, 20)
        Me.txtTipoUsuario.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Contraseña actual"
        '
        'txtPass_actual
        '
        Me.txtPass_actual.Location = New System.Drawing.Point(151, 99)
        Me.txtPass_actual.MaxLength = 8
        Me.txtPass_actual.Name = "txtPass_actual"
        Me.txtPass_actual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.txtPass_actual.Size = New System.Drawing.Size(100, 20)
        Me.txtPass_actual.TabIndex = 6
        '
        'txtPassNuevo
        '
        Me.txtPassNuevo.Location = New System.Drawing.Point(151, 125)
        Me.txtPassNuevo.MaxLength = 8
        Me.txtPassNuevo.Name = "txtPassNuevo"
        Me.txtPassNuevo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.txtPassNuevo.Size = New System.Drawing.Size(100, 20)
        Me.txtPassNuevo.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(52, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Contraseña nueva"
        '
        'txtPasswConfirma
        '
        Me.txtPasswConfirma.Location = New System.Drawing.Point(151, 151)
        Me.txtPasswConfirma.MaxLength = 8
        Me.txtPasswConfirma.Name = "txtPasswConfirma"
        Me.txtPasswConfirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.txtPasswConfirma.Size = New System.Drawing.Size(100, 20)
        Me.txtPasswConfirma.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Contraseña confirme"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(245, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(59, 23)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(14, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(278, 26)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cambio de contraseña usuario"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombre.Location = New System.Drawing.Point(151, 47)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(218, 20)
        Me.txtNombre.TabIndex = 13
        '
        'lblCoinciden
        '
        Me.lblCoinciden.AutoSize = True
        Me.lblCoinciden.Location = New System.Drawing.Point(257, 154)
        Me.lblCoinciden.Name = "lblCoinciden"
        Me.lblCoinciden.Size = New System.Drawing.Size(13, 13)
        Me.lblCoinciden.TabIndex = 14
        Me.lblCoinciden.Text = "  "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Passat_H2O.My.Resources.Resources.change_password
        Me.PictureBox1.Location = New System.Drawing.Point(310, 108)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 179)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 35)
        Me.Panel1.TabIndex = 16
        '
        'frmUsuario_Cambio_passw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(381, 214)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblCoinciden)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPasswConfirma)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPassNuevo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPass_actual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTipoUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsuario_id)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuario_Cambio_passw"
        Me.Text = "Pasat :: Cambio de Contraseña"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario_id As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPass_actual As System.Windows.Forms.TextBox
    Friend WithEvents txtPassNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPasswConfirma As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblCoinciden As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
