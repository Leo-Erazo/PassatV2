<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura_manual
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSocio_ID = New System.Windows.Forms.Button
        Me.txtSocio_ID = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtServicio_ID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtServicio_desc = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnServicio = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvCargos = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblLineas = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.btnQuitar = New System.Windows.Forms.Button
        Me.txtAnotaciones = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSocio_nombre = New System.Windows.Forms.TextBox
        Me.PanelSocios = New System.Windows.Forms.Panel
        Me.dgvSocios = New System.Windows.Forms.DataGridView
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btnSelecc_socios = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.txtBusque_nombre = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.btnCerrarSocios = New System.Windows.Forms.ToolStripButton
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.PanelServicios = New System.Windows.Forms.Panel
        Me.dgvServicios = New System.Windows.Forms.DataGridView
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSeleccionar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.btnCerrar_servicios = New System.Windows.Forms.ToolStripButton
        Me.chkManda_otro_periodo = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PanelSocios.SuspendLayout()
        CType(Me.dgvSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.PanelServicios.SuspendLayout()
        CType(Me.dgvServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 16.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cargo por servicios extraordinarios"
        '
        'btnSocio_ID
        '
        Me.btnSocio_ID.Location = New System.Drawing.Point(180, 63)
        Me.btnSocio_ID.Name = "btnSocio_ID"
        Me.btnSocio_ID.Size = New System.Drawing.Size(62, 23)
        Me.btnSocio_ID.TabIndex = 1
        Me.btnSocio_ID.Text = "Buscar..."
        Me.btnSocio_ID.UseVisualStyleBackColor = True
        '
        'txtSocio_ID
        '
        Me.txtSocio_ID.BackColor = System.Drawing.Color.White
        Me.txtSocio_ID.Location = New System.Drawing.Point(74, 65)
        Me.txtSocio_ID.Name = "txtSocio_ID"
        Me.txtSocio_ID.ReadOnly = True
        Me.txtSocio_ID.Size = New System.Drawing.Size(100, 20)
        Me.txtSocio_ID.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 54)
        Me.Panel1.TabIndex = 5
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(547, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 26)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "Cancelar y salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cuenta No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Titular:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.Location = New System.Drawing.Point(74, 113)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(278, 20)
        Me.txtDireccion.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Dirección:"
        '
        'txtServicio_ID
        '
        Me.txtServicio_ID.BackColor = System.Drawing.Color.White
        Me.txtServicio_ID.Location = New System.Drawing.Point(74, 137)
        Me.txtServicio_ID.Name = "txtServicio_ID"
        Me.txtServicio_ID.ReadOnly = True
        Me.txtServicio_ID.Size = New System.Drawing.Size(100, 20)
        Me.txtServicio_ID.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Servicio:"
        '
        'txtServicio_desc
        '
        Me.txtServicio_desc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServicio_desc.BackColor = System.Drawing.Color.White
        Me.txtServicio_desc.Location = New System.Drawing.Point(74, 161)
        Me.txtServicio_desc.Name = "txtServicio_desc"
        Me.txtServicio_desc.ReadOnly = True
        Me.txtServicio_desc.Size = New System.Drawing.Size(647, 20)
        Me.txtServicio_desc.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Descripción:"
        '
        'btnServicio
        '
        Me.btnServicio.Location = New System.Drawing.Point(180, 135)
        Me.btnServicio.Name = "btnServicio"
        Me.btnServicio.Size = New System.Drawing.Size(62, 23)
        Me.btnServicio.TabIndex = 3
        Me.btnServicio.Text = "Buscar..."
        Me.btnServicio.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.dgvCargos)
        Me.Panel2.Controls.Add(Me.StatusStrip1)
        Me.Panel2.Location = New System.Drawing.Point(0, 266)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(731, 191)
        Me.Panel2.TabIndex = 16
        '
        'dgvCargos
        '
        Me.dgvCargos.AllowUserToAddRows = False
        Me.dgvCargos.AllowUserToDeleteRows = False
        Me.dgvCargos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCargos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvCargos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCargos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCargos.Location = New System.Drawing.Point(0, 0)
        Me.dgvCargos.Name = "dgvCargos"
        Me.dgvCargos.ReadOnly = True
        Me.dgvCargos.RowHeadersWidth = 20
        Me.dgvCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCargos.Size = New System.Drawing.Size(731, 169)
        Me.dgvCargos.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblLineas, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 169)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(731, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(43, 17)
        Me.ToolStripStatusLabel1.Text = "Líneas:"
        '
        'lblLineas
        '
        Me.lblLineas.Name = "lblLineas"
        Me.lblLineas.Size = New System.Drawing.Size(13, 17)
        Me.lblLineas.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(54, 17)
        Me.ToolStripStatusLabel2.Text = "Sumas: $"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(28, 17)
        Me.ToolStripStatusLabel3.Text = "0.00"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(72, 234)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(62, 23)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(140, 234)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(62, 23)
        Me.btnQuitar.TabIndex = 5
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtAnotaciones
        '
        Me.txtAnotaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnotaciones.Location = New System.Drawing.Point(74, 186)
        Me.txtAnotaciones.MaxLength = 500
        Me.txtAnotaciones.Multiline = True
        Me.txtAnotaciones.Name = "txtAnotaciones"
        Me.txtAnotaciones.Size = New System.Drawing.Size(647, 39)
        Me.txtAnotaciones.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Anotaciones:"
        '
        'txtSocio_nombre
        '
        Me.txtSocio_nombre.BackColor = System.Drawing.Color.White
        Me.txtSocio_nombre.Location = New System.Drawing.Point(74, 89)
        Me.txtSocio_nombre.Name = "txtSocio_nombre"
        Me.txtSocio_nombre.ReadOnly = True
        Me.txtSocio_nombre.Size = New System.Drawing.Size(278, 20)
        Me.txtSocio_nombre.TabIndex = 8
        '
        'PanelSocios
        '
        Me.PanelSocios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSocios.Controls.Add(Me.dgvSocios)
        Me.PanelSocios.Controls.Add(Me.StatusStrip3)
        Me.PanelSocios.Controls.Add(Me.ToolStrip2)
        Me.PanelSocios.Location = New System.Drawing.Point(55, 132)
        Me.PanelSocios.Name = "PanelSocios"
        Me.PanelSocios.Size = New System.Drawing.Size(672, 280)
        Me.PanelSocios.TabIndex = 20
        Me.PanelSocios.Visible = False
        '
        'dgvSocios
        '
        Me.dgvSocios.AllowUserToAddRows = False
        Me.dgvSocios.AllowUserToDeleteRows = False
        Me.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSocios.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSocios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSocios.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSocios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSocios.Location = New System.Drawing.Point(0, 29)
        Me.dgvSocios.Name = "dgvSocios"
        Me.dgvSocios.ReadOnly = True
        Me.dgvSocios.RowHeadersWidth = 20
        Me.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSocios.Size = New System.Drawing.Size(670, 227)
        Me.dgvSocios.TabIndex = 2
        '
        'StatusStrip3
        '
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 256)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.Size = New System.Drawing.Size(670, 22)
        Me.StatusStrip3.TabIndex = 1
        Me.StatusStrip3.Text = "StatusStrip3"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(41, 17)
        Me.ToolStripStatusLabel5.Text = "Socios"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSelecc_socios, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.txtBusque_nombre, Me.ToolStripLabel2, Me.btnCerrarSocios})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(670, 29)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnSelecc_socios
        '
        Me.btnSelecc_socios.Image = Global.Passat_H2O.My.Resources.Resources.icon_checkmark_round_128
        Me.btnSelecc_socios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelecc_socios.Name = "btnSelecc_socios"
        Me.btnSelecc_socios.Size = New System.Drawing.Size(87, 26)
        Me.btnSelecc_socios.Text = "Seleccionar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(115, 26)
        Me.ToolStripLabel1.Text = "Busque por nombre:"
        '
        'txtBusque_nombre
        '
        Me.txtBusque_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusque_nombre.Name = "txtBusque_nombre"
        Me.txtBusque_nombre.Size = New System.Drawing.Size(100, 29)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(110, 26)
        Me.ToolStripLabel2.Text = "          Socios"
        '
        'btnCerrarSocios
        '
        Me.btnCerrarSocios.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrarSocios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrarSocios.Name = "btnCerrarSocios"
        Me.btnCerrarSocios.Size = New System.Drawing.Size(59, 26)
        Me.btnCerrarSocios.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(257, 231)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(74, 26)
        Me.btnGuardar.TabIndex = 22
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'PanelServicios
        '
        Me.PanelServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelServicios.Controls.Add(Me.dgvServicios)
        Me.PanelServicios.Controls.Add(Me.StatusStrip2)
        Me.PanelServicios.Controls.Add(Me.ToolStrip1)
        Me.PanelServicios.Location = New System.Drawing.Point(109, 134)
        Me.PanelServicios.Name = "PanelServicios"
        Me.PanelServicios.Size = New System.Drawing.Size(557, 210)
        Me.PanelServicios.TabIndex = 23
        Me.PanelServicios.Visible = False
        '
        'dgvServicios
        '
        Me.dgvServicios.AllowUserToAddRows = False
        Me.dgvServicios.AllowUserToDeleteRows = False
        Me.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvServicios.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Consolas", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvServicios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicios.Location = New System.Drawing.Point(0, 29)
        Me.dgvServicios.Name = "dgvServicios"
        Me.dgvServicios.ReadOnly = True
        Me.dgvServicios.RowHeadersWidth = 20
        Me.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServicios.Size = New System.Drawing.Size(555, 157)
        Me.dgvServicios.TabIndex = 2
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel4})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 186)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(555, 22)
        Me.StatusStrip2.TabIndex = 1
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(116, 17)
        Me.ToolStripStatusLabel4.Text = "Servicios disponibles"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSeleccionar, Me.ToolStripLabel3, Me.btnCerrar_servicios})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(555, 29)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Image = Global.Passat_H2O.My.Resources.Resources.icon_checkmark_round_128
        Me.btnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(87, 26)
        Me.btnSeleccionar.Text = "Seleccionar"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(188, 26)
        Me.ToolStripLabel3.Text = "Servicios                        "
        '
        'btnCerrar_servicios
        '
        Me.btnCerrar_servicios.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnCerrar_servicios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar_servicios.Name = "btnCerrar_servicios"
        Me.btnCerrar_servicios.Size = New System.Drawing.Size(59, 26)
        Me.btnCerrar_servicios.Text = "Cerrar"
        '
        'chkManda_otro_periodo
        '
        Me.chkManda_otro_periodo.AutoSize = True
        Me.chkManda_otro_periodo.Checked = True
        Me.chkManda_otro_periodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkManda_otro_periodo.Enabled = False
        Me.chkManda_otro_periodo.Location = New System.Drawing.Point(341, 240)
        Me.chkManda_otro_periodo.Name = "chkManda_otro_periodo"
        Me.chkManda_otro_periodo.Size = New System.Drawing.Size(201, 17)
        Me.chkManda_otro_periodo.TabIndex = 24
        Me.chkManda_otro_periodo.Text = "Mandar a cobro en siguiente período"
        Me.chkManda_otro_periodo.UseVisualStyleBackColor = True
        '
        'frmFactura_manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 456)
        Me.Controls.Add(Me.PanelServicios)
        Me.Controls.Add(Me.PanelSocios)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAnotaciones)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnServicio)
        Me.Controls.Add(Me.txtServicio_desc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtServicio_ID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSocio_nombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSocio_ID)
        Me.Controls.Add(Me.btnSocio_ID)
        Me.Controls.Add(Me.chkManda_otro_periodo)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(747, 494)
        Me.MinimizeBox = False
        Me.Name = "frmFactura_manual"
        Me.Text = "Facturación de servicios extraordinarios"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PanelSocios.ResumeLayout(False)
        Me.PanelSocios.PerformLayout()
        CType(Me.dgvSocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.PanelServicios.ResumeLayout(False)
        Me.PanelServicios.PerformLayout()
        CType(Me.dgvServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSocio_ID As System.Windows.Forms.Button
    Friend WithEvents txtSocio_ID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtServicio_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtServicio_desc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnServicio As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvCargos As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLineas As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents txtAnotaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSocio_nombre As System.Windows.Forms.TextBox
    Friend WithEvents PanelSocios As System.Windows.Forms.Panel
    Friend WithEvents dgvSocios As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSelecc_socios As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrarSocios As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtBusque_nombre As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents PanelServicios As System.Windows.Forms.Panel
    Friend WithEvents dgvServicios As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSeleccionar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar_servicios As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkManda_otro_periodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
End Class
