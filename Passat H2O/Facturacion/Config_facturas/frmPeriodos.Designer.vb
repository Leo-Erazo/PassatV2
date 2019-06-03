<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.PanelIndicaciones = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelDatos = New System.Windows.Forms.Panel
        Me.GroupLecturas = New System.Windows.Forms.GroupBox
        Me.dtpAnalisisCorteServicio = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtpLectura_conta = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpAprobacion_lecturas = New System.Windows.Forms.DateTimePicker
        Me.dtpAnalisis_inconsist = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpIngreso_lecturas = New System.Windows.Forms.DateTimePicker
        Me.dtpEmision_facturas = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEmite_listado = New System.Windows.Forms.DateTimePicker
        Me.dtpDistribuye_Facturas = New System.Windows.Forms.DateTimePicker
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupDefinicion = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.txtPeriodo_ID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Group_vencimiento = New System.Windows.Forms.GroupBox
        Me.dtpVencimiento_real = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.nupDias = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbEstado = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.dtpCorte_suministro = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.dtpAviso_corte_servicio = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.dtpVencimiento_facturas = New System.Windows.Forms.DateTimePicker
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.dgvPeriodos = New System.Windows.Forms.DataGridView
        Me.btnSeleccionar = New System.Windows.Forms.ToolStripButton
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton
        Me.btnEditar = New System.Windows.Forms.ToolStripButton
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton
        Me.btnSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.PanelIndicaciones.SuspendLayout()
        Me.PanelDatos.SuspendLayout()
        Me.GroupLecturas.SuspendLayout()
        Me.GroupDefinicion.SuspendLayout()
        Me.Group_vencimiento.SuspendLayout()
        CType(Me.nupDias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSeleccionar, Me.ToolStripSeparator4, Me.btnNuevo, Me.ToolStripSeparator1, Me.btnEditar, Me.ToolStripSeparator2, Me.btnEliminar, Me.ToolStripLabel1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(211, 36)
        Me.ToolStripLabel1.Text = "Ciclos de facturación    "
        '
        'PanelIndicaciones
        '
        Me.PanelIndicaciones.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelIndicaciones.Controls.Add(Me.Label2)
        Me.PanelIndicaciones.Controls.Add(Me.Label1)
        Me.PanelIndicaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelIndicaciones.Location = New System.Drawing.Point(0, 39)
        Me.PanelIndicaciones.Name = "PanelIndicaciones"
        Me.PanelIndicaciones.Size = New System.Drawing.Size(984, 72)
        Me.PanelIndicaciones.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(10, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(399, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(10, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(407, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Los períodos pueden tener 3 estados: Pasivo, Activo y Cerrado"
        '
        'PanelDatos
        '
        Me.PanelDatos.Controls.Add(Me.GroupLecturas)
        Me.PanelDatos.Controls.Add(Me.GroupDefinicion)
        Me.PanelDatos.Controls.Add(Me.Group_vencimiento)
        Me.PanelDatos.Controls.Add(Me.btnGuardar)
        Me.PanelDatos.Controls.Add(Me.btnCancelar)
        Me.PanelDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDatos.Location = New System.Drawing.Point(0, 111)
        Me.PanelDatos.Name = "PanelDatos"
        Me.PanelDatos.Size = New System.Drawing.Size(984, 297)
        Me.PanelDatos.TabIndex = 2
        Me.PanelDatos.Visible = False
        '
        'GroupLecturas
        '
        Me.GroupLecturas.Controls.Add(Me.dtpAnalisisCorteServicio)
        Me.GroupLecturas.Controls.Add(Me.Label14)
        Me.GroupLecturas.Controls.Add(Me.Label15)
        Me.GroupLecturas.Controls.Add(Me.dtpLectura_conta)
        Me.GroupLecturas.Controls.Add(Me.Label8)
        Me.GroupLecturas.Controls.Add(Me.dtpAprobacion_lecturas)
        Me.GroupLecturas.Controls.Add(Me.dtpAnalisis_inconsist)
        Me.GroupLecturas.Controls.Add(Me.Label11)
        Me.GroupLecturas.Controls.Add(Me.Label10)
        Me.GroupLecturas.Controls.Add(Me.dtpIngreso_lecturas)
        Me.GroupLecturas.Controls.Add(Me.dtpEmision_facturas)
        Me.GroupLecturas.Controls.Add(Me.Label9)
        Me.GroupLecturas.Controls.Add(Me.Label12)
        Me.GroupLecturas.Controls.Add(Me.dtpEmite_listado)
        Me.GroupLecturas.Controls.Add(Me.dtpDistribuye_Facturas)
        Me.GroupLecturas.Controls.Add(Me.Label18)
        Me.GroupLecturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.GroupLecturas.ForeColor = System.Drawing.Color.Blue
        Me.GroupLecturas.Location = New System.Drawing.Point(11, 84)
        Me.GroupLecturas.Name = "GroupLecturas"
        Me.GroupLecturas.Size = New System.Drawing.Size(961, 100)
        Me.GroupLecturas.TabIndex = 48
        Me.GroupLecturas.TabStop = False
        Me.GroupLecturas.Text = "Lecturas"
        '
        'dtpAnalisisCorteServicio
        '
        Me.dtpAnalisisCorteServicio.Location = New System.Drawing.Point(10, 79)
        Me.dtpAnalisisCorteServicio.Name = "dtpAnalisisCorteServicio"
        Me.dtpAnalisisCorteServicio.Size = New System.Drawing.Size(230, 21)
        Me.dtpAnalisisCorteServicio.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(12, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(148, 17)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Análisis Corte Servicio"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(6, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 17)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Emite Hojas Lectura"
        '
        'dtpLectura_conta
        '
        Me.dtpLectura_conta.Location = New System.Drawing.Point(245, 36)
        Me.dtpLectura_conta.Name = "dtpLectura_conta"
        Me.dtpLectura_conta.Size = New System.Drawing.Size(230, 21)
        Me.dtpLectura_conta.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(247, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Lectura de contadores"
        '
        'dtpAprobacion_lecturas
        '
        Me.dtpAprobacion_lecturas.Location = New System.Drawing.Point(245, 79)
        Me.dtpAprobacion_lecturas.Name = "dtpAprobacion_lecturas"
        Me.dtpAprobacion_lecturas.Size = New System.Drawing.Size(230, 21)
        Me.dtpAprobacion_lecturas.TabIndex = 5
        '
        'dtpAnalisis_inconsist
        '
        Me.dtpAnalisis_inconsist.Location = New System.Drawing.Point(717, 36)
        Me.dtpAnalisis_inconsist.Name = "dtpAnalisis_inconsist"
        Me.dtpAnalisis_inconsist.Size = New System.Drawing.Size(230, 21)
        Me.dtpAnalisis_inconsist.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(242, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(193, 17)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Aprobación Lecturas y cortes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(719, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 17)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Análisis de inconsistencias"
        '
        'dtpIngreso_lecturas
        '
        Me.dtpIngreso_lecturas.Location = New System.Drawing.Point(481, 36)
        Me.dtpIngreso_lecturas.Name = "dtpIngreso_lecturas"
        Me.dtpIngreso_lecturas.Size = New System.Drawing.Size(230, 21)
        Me.dtpIngreso_lecturas.TabIndex = 2
        '
        'dtpEmision_facturas
        '
        Me.dtpEmision_facturas.Location = New System.Drawing.Point(481, 79)
        Me.dtpEmision_facturas.Name = "dtpEmision_facturas"
        Me.dtpEmision_facturas.Size = New System.Drawing.Size(230, 21)
        Me.dtpEmision_facturas.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(478, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 17)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Ingreso de lecturas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(483, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 17)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Emisión de Facturas"
        '
        'dtpEmite_listado
        '
        Me.dtpEmite_listado.Location = New System.Drawing.Point(9, 36)
        Me.dtpEmite_listado.Name = "dtpEmite_listado"
        Me.dtpEmite_listado.Size = New System.Drawing.Size(230, 21)
        Me.dtpEmite_listado.TabIndex = 0
        '
        'dtpDistribuye_Facturas
        '
        Me.dtpDistribuye_Facturas.Location = New System.Drawing.Point(717, 79)
        Me.dtpDistribuye_Facturas.Name = "dtpDistribuye_Facturas"
        Me.dtpDistribuye_Facturas.Size = New System.Drawing.Size(230, 21)
        Me.dtpDistribuye_Facturas.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(719, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 17)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Distribución Facturas"
        '
        'GroupDefinicion
        '
        Me.GroupDefinicion.Controls.Add(Me.Label3)
        Me.GroupDefinicion.Controls.Add(Me.cmbYear)
        Me.GroupDefinicion.Controls.Add(Me.Label4)
        Me.GroupDefinicion.Controls.Add(Me.Label7)
        Me.GroupDefinicion.Controls.Add(Me.cmbMes)
        Me.GroupDefinicion.Controls.Add(Me.txtPeriodo_ID)
        Me.GroupDefinicion.Controls.Add(Me.Label5)
        Me.GroupDefinicion.Controls.Add(Me.Label6)
        Me.GroupDefinicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.GroupDefinicion.ForeColor = System.Drawing.Color.DarkGreen
        Me.GroupDefinicion.Location = New System.Drawing.Point(12, 2)
        Me.GroupDefinicion.Name = "GroupDefinicion"
        Me.GroupDefinicion.Size = New System.Drawing.Size(474, 82)
        Me.GroupDefinicion.TabIndex = 10
        Me.GroupDefinicion.TabStop = False
        Me.GroupDefinicion.Text = "Mes y año facturación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Año"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(9, 53)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(121, 23)
        Me.cmbYear.TabIndex = 0
        Me.cmbYear.Text = "Seleccione año"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Seleccione el año y el mes de facturación"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(366, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "(Autogenerado)"
        '
        'cmbMes
        '
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbMes.Location = New System.Drawing.Point(136, 53)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 23)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.Text = "Seleccione Mes"
        '
        'txtPeriodo_ID
        '
        Me.txtPeriodo_ID.Enabled = False
        Me.txtPeriodo_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.txtPeriodo_ID.Location = New System.Drawing.Point(263, 53)
        Me.txtPeriodo_ID.Name = "txtPeriodo_ID"
        Me.txtPeriodo_ID.Size = New System.Drawing.Size(100, 23)
        Me.txtPeriodo_ID.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(133, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Mes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(260, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Período ID"
        '
        'Group_vencimiento
        '
        Me.Group_vencimiento.Controls.Add(Me.dtpVencimiento_real)
        Me.Group_vencimiento.Controls.Add(Me.Label13)
        Me.Group_vencimiento.Controls.Add(Me.nupDias)
        Me.Group_vencimiento.Controls.Add(Me.Label16)
        Me.Group_vencimiento.Controls.Add(Me.cmbEstado)
        Me.Group_vencimiento.Controls.Add(Me.Label20)
        Me.Group_vencimiento.Controls.Add(Me.Label21)
        Me.Group_vencimiento.Controls.Add(Me.dtpCorte_suministro)
        Me.Group_vencimiento.Controls.Add(Me.Label23)
        Me.Group_vencimiento.Controls.Add(Me.dtpAviso_corte_servicio)
        Me.Group_vencimiento.Controls.Add(Me.Label17)
        Me.Group_vencimiento.Controls.Add(Me.dtpVencimiento_facturas)
        Me.Group_vencimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Group_vencimiento.ForeColor = System.Drawing.Color.Red
        Me.Group_vencimiento.Location = New System.Drawing.Point(12, 186)
        Me.Group_vencimiento.Name = "Group_vencimiento"
        Me.Group_vencimiento.Size = New System.Drawing.Size(691, 104)
        Me.Group_vencimiento.TabIndex = 9
        Me.Group_vencimiento.TabStop = False
        Me.Group_vencimiento.Text = "Vencimientos"
        '
        'dtpVencimiento_real
        '
        Me.dtpVencimiento_real.Location = New System.Drawing.Point(451, 35)
        Me.dtpVencimiento_real.Name = "dtpVencimiento_real"
        Me.dtpVencimiento_real.Size = New System.Drawing.Size(230, 20)
        Me.dtpVencimiento_real.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(448, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 17)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Fecha Real Vencimiento"
        '
        'nupDias
        '
        Me.nupDias.Location = New System.Drawing.Point(373, 35)
        Me.nupDias.Name = "nupDias"
        Me.nupDias.Size = New System.Drawing.Size(63, 20)
        Me.nupDias.TabIndex = 1
        Me.nupDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(240, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 30)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Días de gracia sobre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fecha vencimiento"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Cerrado", "Pasivo"})
        Me.cmbEstado.Location = New System.Drawing.Point(482, 74)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(199, 21)
        Me.cmbEstado.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(479, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 17)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Estado"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(242, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 17)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Corte de Suministro"
        '
        'dtpCorte_suministro
        '
        Me.dtpCorte_suministro.Location = New System.Drawing.Point(240, 75)
        Me.dtpCorte_suministro.Name = "dtpCorte_suministro"
        Me.dtpCorte_suministro.Size = New System.Drawing.Size(230, 20)
        Me.dtpCorte_suministro.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(6, 55)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(154, 17)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Aviso de Corte Servicio"
        '
        'dtpAviso_corte_servicio
        '
        Me.dtpAviso_corte_servicio.Location = New System.Drawing.Point(4, 75)
        Me.dtpAviso_corte_servicio.Name = "dtpAviso_corte_servicio"
        Me.dtpAviso_corte_servicio.Size = New System.Drawing.Size(230, 20)
        Me.dtpAviso_corte_servicio.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(6, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(164, 17)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Vencimiento de Facturas"
        '
        'dtpVencimiento_facturas
        '
        Me.dtpVencimiento_facturas.Location = New System.Drawing.Point(4, 33)
        Me.dtpVencimiento_facturas.Name = "dtpVencimiento_facturas"
        Me.dtpVencimiento_facturas.Size = New System.Drawing.Size(230, 20)
        Me.dtpVencimiento_facturas.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Location = New System.Drawing.Point(728, 260)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 29)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Location = New System.Drawing.Point(809, 260)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 29)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dgvPeriodos
        '
        Me.dgvPeriodos.AllowUserToAddRows = False
        Me.dgvPeriodos.AllowUserToDeleteRows = False
        Me.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPeriodos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPeriodos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPeriodos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPeriodos.Location = New System.Drawing.Point(0, 408)
        Me.dgvPeriodos.Name = "dgvPeriodos"
        Me.dgvPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPeriodos.Size = New System.Drawing.Size(984, 131)
        Me.dgvPeriodos.TabIndex = 4
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Image = Global.Passat_H2O.My.Resources.Resources.icon_checkmark_round_128
        Me.btnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(103, 36)
        Me.btnSeleccionar.Text = "Seleccionar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Passat_H2O.My.Resources.Resources.add
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 36)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Passat_H2O.My.Resources.Resources.database_edit
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(110, 36)
        Me.btnEditar.Text = "Abrir / Editar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Passat_H2O.My.Resources.Resources.cross
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 36)
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Passat_H2O.My.Resources.Resources.Salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(65, 36)
        Me.btnSalir.Text = "Salir"
        '
        'frmPeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.dgvPeriodos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelDatos)
        Me.Controls.Add(Me.PanelIndicaciones)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmPeriodos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Períodos de facturación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelIndicaciones.ResumeLayout(False)
        Me.PanelIndicaciones.PerformLayout()
        Me.PanelDatos.ResumeLayout(False)
        Me.GroupLecturas.ResumeLayout(False)
        Me.GroupLecturas.PerformLayout()
        Me.GroupDefinicion.ResumeLayout(False)
        Me.GroupDefinicion.PerformLayout()
        Me.Group_vencimiento.ResumeLayout(False)
        Me.Group_vencimiento.PerformLayout()
        CType(Me.nupDias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PanelIndicaciones As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelDatos As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Group_vencimiento As System.Windows.Forms.GroupBox
    Friend WithEvents dtpLectura_conta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpCorte_suministro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpAviso_corte_servicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimiento_facturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpDistribuye_Facturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpEmision_facturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpAnalisis_inconsist As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents dgvPeriodos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupDefinicion As System.Windows.Forms.GroupBox
    Friend WithEvents btnSeleccionar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents nupDias As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpEmite_listado As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAprobacion_lecturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpIngreso_lecturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimiento_real As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupLecturas As System.Windows.Forms.GroupBox
    Friend WithEvents dtpAnalisisCorteServicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
