<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSocio
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSocio))
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAgregar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnQuitar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.chkConvenioPago = New System.Windows.Forms.CheckBox
        Me.btnAyuda = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtCasa_Num_Fisico = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtDireccion_fisica = New System.Windows.Forms.TextBox
        Me.chkMismo = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSocio_ID = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCorreo_elec = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTel_portatil = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTel_fijo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInquilino_nom = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPropietario_nom = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCorrelativo_ruta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbBloque = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbSector = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtContador_num = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvServicios_contratados = New System.Windows.Forms.DataGridView
        Me.txtLectura_ultima = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtLectura_penultima = New System.Windows.Forms.TextBox
        Me.PanAyuda = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnCerrar_ayuda = New System.Windows.Forms.Button
        Me.txtPeriodo_convenio = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvServicios_contratados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanAyuda.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(445, 502)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(91, 23)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Aceptar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(348, 502)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(91, 23)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cancelar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAgregar, Me.ToolStripSeparator1, Me.btnQuitar, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(530, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Passat_H2O.My.Resources.Resources.add
        Me.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 22)
        Me.btnAgregar.Text = "Agregar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnQuitar
        '
        Me.btnQuitar.Image = Global.Passat_H2O.My.Resources.Resources.cross
        Me.btnQuitar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(60, 22)
        Me.btnQuitar.Text = "Quitar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripLabel1.Text = "Servicios que se le facturarán"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.chkConvenioPago)
        Me.GroupBox1.Controls.Add(Me.btnAyuda)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtCasa_Num_Fisico)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtDireccion_fisica)
        Me.GroupBox1.Controls.Add(Me.chkMismo)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtSocio_ID)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCorreo_elec)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTel_portatil)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTel_fijo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtInquilino_nom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPropietario_nom)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCorrelativo_ruta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbBloque)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbSector)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 302)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generales"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Label12.Location = New System.Drawing.Point(384, 259)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Período último libre penalización"
        '
        'chkActivo
        '
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(249, 16)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(57, 19)
        Me.chkActivo.TabIndex = 40
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'chkConvenioPago
        '
        Me.chkConvenioPago.AutoSize = True
        Me.chkConvenioPago.Location = New System.Drawing.Point(311, 262)
        Me.chkConvenioPago.Name = "chkConvenioPago"
        Me.chkConvenioPago.Size = New System.Drawing.Size(75, 34)
        Me.chkConvenioPago.TabIndex = 39
        Me.chkConvenioPago.Text = "Con " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "convenio"
        Me.chkConvenioPago.UseVisualStyleBackColor = True
        '
        'btnAyuda
        '
        Me.btnAyuda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAyuda.Location = New System.Drawing.Point(240, 99)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(50, 23)
        Me.btnAyuda.TabIndex = 38
        Me.btnAyuda.Text = "?"
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 123)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(468, 15)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Dirección física real resultante (La que aparece en recibo. Modifique a convenien" & _
            "cia)"
        '
        'txtCasa_Num_Fisico
        '
        Me.txtCasa_Num_Fisico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCasa_Num_Fisico.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtCasa_Num_Fisico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCasa_Num_Fisico.Location = New System.Drawing.Point(141, 99)
        Me.txtCasa_Num_Fisico.Name = "txtCasa_Num_Fisico"
        Me.txtCasa_Num_Fisico.Size = New System.Drawing.Size(112, 22)
        Me.txtCasa_Num_Fisico.TabIndex = 3
        Me.txtCasa_Num_Fisico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(141, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 15)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "No. Físico Casa"
        '
        'txtDireccion_fisica
        '
        Me.txtDireccion_fisica.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion_fisica.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtDireccion_fisica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDireccion_fisica.Location = New System.Drawing.Point(12, 141)
        Me.txtDireccion_fisica.Name = "txtDireccion_fisica"
        Me.txtDireccion_fisica.Size = New System.Drawing.Size(525, 22)
        Me.txtDireccion_fisica.TabIndex = 4
        '
        'chkMismo
        '
        Me.chkMismo.AutoSize = True
        Me.chkMismo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.chkMismo.Location = New System.Drawing.Point(149, 208)
        Me.chkMismo.Name = "chkMismo"
        Me.chkMismo.Size = New System.Drawing.Size(64, 19)
        Me.chkMismo.TabIndex = 33
        Me.chkMismo.Text = "Mismo"
        Me.chkMismo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(373, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(145, 26)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Datos del Socio"
        '
        'txtSocio_ID
        '
        Me.txtSocio_ID.Enabled = False
        Me.txtSocio_ID.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtSocio_ID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSocio_ID.Location = New System.Drawing.Point(88, 14)
        Me.txtSocio_ID.Name = "txtSocio_ID"
        Me.txtSocio_ID.Size = New System.Drawing.Size(150, 22)
        Me.txtSocio_ID.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 15)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Socio No.:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(123, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 15)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(298, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 15)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(65, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "*"
        '
        'txtCorreo_elec
        '
        Me.txtCorreo_elec.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtCorreo_elec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCorreo_elec.Location = New System.Drawing.Point(116, 272)
        Me.txtCorreo_elec.Name = "txtCorreo_elec"
        Me.txtCorreo_elec.Size = New System.Drawing.Size(186, 22)
        Me.txtCorreo_elec.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(116, 253)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Correo Electrónico"
        '
        'txtTel_portatil
        '
        Me.txtTel_portatil.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtTel_portatil.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTel_portatil.Location = New System.Drawing.Point(12, 272)
        Me.txtTel_portatil.Name = "txtTel_portatil"
        Me.txtTel_portatil.Size = New System.Drawing.Size(96, 22)
        Me.txtTel_portatil.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Teléfono Portátil"
        '
        'txtTel_fijo
        '
        Me.txtTel_fijo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTel_fijo.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtTel_fijo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTel_fijo.Location = New System.Drawing.Point(373, 228)
        Me.txtTel_fijo.Name = "txtTel_fijo"
        Me.txtTel_fijo.Size = New System.Drawing.Size(161, 22)
        Me.txtTel_fijo.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(373, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Teléfono Fijo"
        '
        'txtInquilino_nom
        '
        Me.txtInquilino_nom.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtInquilino_nom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtInquilino_nom.Location = New System.Drawing.Point(12, 228)
        Me.txtInquilino_nom.Name = "txtInquilino_nom"
        Me.txtInquilino_nom.Size = New System.Drawing.Size(355, 22)
        Me.txtInquilino_nom.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Nombre del inquilino"
        '
        'txtPropietario_nom
        '
        Me.txtPropietario_nom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPropietario_nom.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtPropietario_nom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPropietario_nom.Location = New System.Drawing.Point(12, 186)
        Me.txtPropietario_nom.Name = "txtPropietario_nom"
        Me.txtPropietario_nom.Size = New System.Drawing.Size(522, 22)
        Me.txtPropietario_nom.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Nombre del propietario"
        '
        'txtCorrelativo_ruta
        '
        Me.txtCorrelativo_ruta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCorrelativo_ruta.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtCorrelativo_ruta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCorrelativo_ruta.Location = New System.Drawing.Point(12, 99)
        Me.txtCorrelativo_ruta.Name = "txtCorrelativo_ruta"
        Me.txtCorrelativo_ruta.Size = New System.Drawing.Size(125, 22)
        Me.txtCorrelativo_ruta.TabIndex = 2
        Me.txtCorrelativo_ruta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Correlativo lectura"
        '
        'cmbBloque
        '
        Me.cmbBloque.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBloque.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.cmbBloque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbBloque.FormattingEnabled = True
        Me.cmbBloque.Location = New System.Drawing.Point(247, 55)
        Me.cmbBloque.Name = "cmbBloque"
        Me.cmbBloque.Size = New System.Drawing.Size(287, 23)
        Me.cmbBloque.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Bloque"
        '
        'cmbSector
        '
        Me.cmbSector.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.cmbSector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbSector.FormattingEnabled = True
        Me.cmbSector.Location = New System.Drawing.Point(12, 55)
        Me.cmbSector.Name = "cmbSector"
        Me.cmbSector.Size = New System.Drawing.Size(226, 23)
        Me.cmbSector.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sector"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(97, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "*"
        '
        'txtContador_num
        '
        Me.txtContador_num.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContador_num.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtContador_num.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtContador_num.Location = New System.Drawing.Point(10, 35)
        Me.txtContador_num.Name = "txtContador_num"
        Me.txtContador_num.Size = New System.Drawing.Size(160, 22)
        Me.txtContador_num.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Medidor No."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvServicios_contratados)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Location = New System.Drawing.Point(6, 369)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(530, 131)
        Me.Panel2.TabIndex = 31
        '
        'dgvServicios_contratados
        '
        Me.dgvServicios_contratados.AllowUserToAddRows = False
        Me.dgvServicios_contratados.AllowUserToDeleteRows = False
        Me.dgvServicios_contratados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvServicios_contratados.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvServicios_contratados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvServicios_contratados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvServicios_contratados.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvServicios_contratados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicios_contratados.Location = New System.Drawing.Point(0, 25)
        Me.dgvServicios_contratados.Name = "dgvServicios_contratados"
        Me.dgvServicios_contratados.ReadOnly = True
        Me.dgvServicios_contratados.RowHeadersWidth = 16
        Me.dgvServicios_contratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServicios_contratados.Size = New System.Drawing.Size(530, 106)
        Me.dgvServicios_contratados.TabIndex = 31
        '
        'txtLectura_ultima
        '
        Me.txtLectura_ultima.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtLectura_ultima.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLectura_ultima.Location = New System.Drawing.Point(183, 35)
        Me.txtLectura_ultima.Name = "txtLectura_ultima"
        Me.txtLectura_ultima.Size = New System.Drawing.Size(113, 22)
        Me.txtLectura_ultima.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(183, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Lectura último período"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtLectura_penultima)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtLectura_ultima)
        Me.GroupBox2.Controls.Add(Me.txtContador_num)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 304)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 64)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lecturas"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(315, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(131, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Lectura penúltimo período"
        '
        'txtLectura_penultima
        '
        Me.txtLectura_penultima.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtLectura_penultima.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLectura_penultima.Location = New System.Drawing.Point(315, 35)
        Me.txtLectura_penultima.Name = "txtLectura_penultima"
        Me.txtLectura_penultima.Size = New System.Drawing.Size(131, 22)
        Me.txtLectura_penultima.TabIndex = 2
        '
        'PanAyuda
        '
        Me.PanAyuda.BackColor = System.Drawing.Color.SteelBlue
        Me.PanAyuda.Controls.Add(Me.Label3)
        Me.PanAyuda.Controls.Add(Me.TextBox1)
        Me.PanAyuda.Controls.Add(Me.btnCerrar_ayuda)
        Me.PanAyuda.Location = New System.Drawing.Point(25, 35)
        Me.PanAyuda.Name = "PanAyuda"
        Me.PanAyuda.Size = New System.Drawing.Size(499, 221)
        Me.PanAyuda.TabIndex = 41
        Me.PanAyuda.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(9, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "La ruta de lectura"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(12, 42)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(477, 163)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'btnCerrar_ayuda
        '
        Me.btnCerrar_ayuda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar_ayuda.Location = New System.Drawing.Point(407, 11)
        Me.btnCerrar_ayuda.Name = "btnCerrar_ayuda"
        Me.btnCerrar_ayuda.Size = New System.Drawing.Size(82, 23)
        Me.btnCerrar_ayuda.TabIndex = 0
        Me.btnCerrar_ayuda.Text = "Cerrar"
        Me.btnCerrar_ayuda.UseVisualStyleBackColor = True
        '
        'txtPeriodo_convenio
        '
        Me.txtPeriodo_convenio.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.txtPeriodo_convenio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPeriodo_convenio.Location = New System.Drawing.Point(404, 276)
        Me.txtPeriodo_convenio.Name = "txtPeriodo_convenio"
        Me.txtPeriodo_convenio.Size = New System.Drawing.Size(142, 22)
        Me.txtPeriodo_convenio.TabIndex = 41
        '
        'frmSocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(567, 532)
        Me.Controls.Add(Me.txtPeriodo_convenio)
        Me.Controls.Add(Me.PanAyuda)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSocio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos del Asociado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvServicios_contratados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanAyuda.ResumeLayout(False)
        Me.PanAyuda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContador_num As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo_elec As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTel_portatil As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTel_fijo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInquilino_nom As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPropietario_nom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbBloque As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSector As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSocio_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnQuitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkMismo As System.Windows.Forms.CheckBox
    Friend WithEvents txtLectura_ultima As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLectura_penultima As System.Windows.Forms.TextBox
    Friend WithEvents txtCasa_Num_Fisico As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion_fisica As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dgvServicios_contratados As System.Windows.Forms.DataGridView
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents chkConvenioPago As System.Windows.Forms.CheckBox
    Friend WithEvents PanAyuda As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar_ayuda As System.Windows.Forms.Button
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo_convenio As System.Windows.Forms.TextBox
End Class
