Public Class Datos

#Region "Logins"
    Shared Cadena_conexion As String = "initial catalog=pasat_h2o_V2;user ID= ileon; password= ileon"

#End Region

    Public Class Usuario_sistema
        Public Sub New()
        End Sub

        Private User_id As Integer
        Public Property pUser_ID() As Integer
            Get
                Return User_id
            End Get
            Set(ByVal value As Integer)
                User_id = value
            End Set
        End Property

        Private User_Nombre As String
        Public Property pUser_Nombre() As String
            Get
                Return User_Nombre
            End Get
            Set(ByVal value As String)
                User_Nombre = value
            End Set
        End Property

    End Class

    Public Class Users
        Public Property pCadena_conexion() As String
            Get
                Return Cadena_conexion
            End Get
            Set(ByVal value As String)
                If value = String.Empty Then
                    MsgBox("No se ha definido la conexión a la base de datos. No podrá realizar ninguna transacción.", MsgBoxStyle.Information, "Passat")
                Else
                    Cadena_conexion = value
                End If
            End Set
        End Property

        Shared Usuario_conectado As Integer
        Public Property pUsuario_conectado() As Integer
            Get
                Return Usuario_conectado
            End Get
            Set(ByVal value As Integer)
                Usuario_conectado = value
            End Set
        End Property
       
    End Class


    Public Class Formatos
        Sub Formatea_grid(ByVal Grid As DataGridView)
            With Grid
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .RowHeadersWidth = 10
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .BackgroundColor = Color.WhiteSmoke
                .RowsDefaultCellStyle.BackColor = Color.WhiteSmoke
                .GridColor = Color.White
                .RowsDefaultCellStyle.ForeColor = Color.Black
                .RowsDefaultCellStyle.SelectionBackColor = Color.LightYellow
                .RowsDefaultCellStyle.SelectionForeColor = Color.Blue
            End With
        End Sub

    End Class

#Region "Geografía"

    Public Class Sectores
        Public Sub New()
        End Sub

        Private SectorID As Integer

        Public Property pSectorID() As Integer
            Get
                Return Me.SectorID
            End Get
            Set(ByVal value As Integer)
                Me.SectorID = value
            End Set
        End Property

        Private Sector_Desc As String

        Public Property pSector_Desc() As String
            Get
                Return Me.Sector_Desc
            End Get
            Set(ByVal value As String)
                Me.Sector_Desc = value
            End Set
        End Property
    End Class

    Public Class Bloques
        Public Sub New()
        End Sub

        Private BloqueID As String

        Public Property pBloqueID() As String
            Get
                Return Me.BloqueID
            End Get
            Set(ByVal value As String)
                Me.BloqueID = value
            End Set
        End Property

        Private Bloque_Desc As String

        Public Property pBloque_Desc() As String
            Get
                Return Me.Bloque_Desc
            End Get
            Set(ByVal value As String)
                Me.Bloque_Desc = value
            End Set
        End Property
    End Class

    Public Class Avenidas
        Public Sub New()
        End Sub

        Private AvenidaID As Integer

        Public Property pAvenidaID() As Integer
            Get
                Return Me.AvenidaID
            End Get
            Set(ByVal value As Integer)
                Me.AvenidaID = value
            End Set
        End Property

        Private Avenida_Desc As String

        Public Property pAvenida_Desc() As String
            Get
                Return Me.Avenida_Desc
            End Get
            Set(ByVal value As String)
                Me.Avenida_Desc = value
            End Set
        End Property
    End Class

#End Region
    
#Region "Socio"
    Public Class Socio
        Private Transac_num As Integer

        Public Property pTransac_num() As Integer
            Get
                Return Me.Transac_num
            End Get
            Set(ByVal value As Integer)
                Me.Transac_num = value
            End Set
        End Property

        Private Socio_ID As Integer

        Public Property pSocio_ID() As Integer
            Get
                Return Me.Socio_ID
            End Get
            Set(ByVal value As Integer)
                Me.Socio_ID = value
            End Set
        End Property

        Private Sector_ID As Integer


        Public Property pSector_ID() As Integer
            Get
                Return Me.Sector_ID
            End Get
            Set(ByVal value As Integer)
                Me.Sector_ID = value
            End Set
        End Property

        Private Bloque_ID As String

        Public Property pBloque_ID() As String
            Get
                Return Me.Bloque_ID
            End Get
            Set(ByVal value As String)
                Me.Bloque_ID = value
            End Set
        End Property

        Private Correlativo_ruta As Integer

        Public Property pCorrelativo_ruta() As Integer
            Get
                Return Me.Correlativo_ruta
            End Get
            Set(ByVal value As Integer)
                Me.Correlativo_ruta = value
            End Set
        End Property

        Private Direccion_fisica As String

        Public Property pDireccion_fisica() As String
            Get
                Return Me.Direccion_fisica
            End Get
            Set(ByVal value As String)
                Me.Direccion_fisica = value
            End Set
        End Property

        Private Convenio As Boolean

        Public Property pConvenio() As Boolean
            Get
                Return Me.Convenio
            End Get
            Set(ByVal value As Boolean)
                Me.Convenio = value
            End Set
        End Property

        Private Periodo_Convenio As Integer

        Public Property pPeriodo_Convenio() As Integer
            Get
                Return Me.Periodo_Convenio
            End Get
            Set(ByVal value As Integer)
                Me.Periodo_Convenio = value
            End Set
        End Property


        Private propietario As String

        Public Property ppropietario() As String
            Get
                Return Me.propietario
            End Get
            Set(ByVal value As String)
                Me.propietario = value
            End Set
        End Property

        Private inquilino As String

        Public Property pinquilino() As String
            Get
                Return Me.inquilino
            End Get
            Set(ByVal value As String)
                Me.inquilino = value
            End Set
        End Property

        Private tel_fijo As String

        Public Property ptel_fijo() As String
            Get
                Return Me.tel_fijo
            End Get
            Set(ByVal value As String)
                Me.tel_fijo = value
            End Set
        End Property

        Private tel_portatil As String

        Public Property ptel_portatil() As String
            Get
                Return Me.tel_portatil
            End Get
            Set(ByVal value As String)
                Me.tel_portatil = value
            End Set
        End Property


        Private correo As String

        Public Property pcorreo() As String
            Get
                Return Me.correo
            End Get
            Set(ByVal value As String)
                Me.correo = value
            End Set
        End Property


        Private ruta As Integer

        Public Property pruta() As Integer
            Get
                Return Me.ruta
            End Get
            Set(ByVal value As Integer)
                Me.ruta = value
            End Set
        End Property

        Private contador_num As String

        Public Property pcontador_num() As String
            Get
                Return Me.contador_num
            End Get
            Set(ByVal value As String)
                Me.contador_num = value
            End Set
        End Property

        Private Lectura_ultima As Integer

        Public Property pLectura_ultima() As Integer
            Get
                Return Me.Lectura_ultima
            End Get
            Set(ByVal value As Integer)
                Me.Lectura_ultima = value
            End Set
        End Property

        Private Lectura_penultima As Integer

        Public Property pLectura_penultima() As Integer
            Get
                Return Me.Lectura_penultima
            End Get
            Set(ByVal value As Integer)
                Me.Lectura_penultima = value
            End Set
        End Property

        Private Estado As Boolean

        Public Property pEstado() As Boolean
            Get
                Return Me.Estado
            End Get
            Set(ByVal value As Boolean)
                Me.Estado = value
            End Set
        End Property

        Private Fecha_crea As DateTime

        Public Property pFecha_crea() As DateTime
            Get
                Return Me.Fecha_crea
            End Get
            Set(ByVal value As DateTime)
                Me.Fecha_crea = value
            End Set
        End Property

        Private Fecha_edita As DateTime

        Public Property pFecha_edita() As DateTime
            Get
                Return Me.Fecha_edita
            End Get
            Set(ByVal value As DateTime)
                Me.Fecha_edita = value
            End Set
        End Property

        Private Transac_crea As Integer

        Public Property pTransac_crea() As Integer
            Get
                Return Me.Transac_crea
            End Get
            Set(ByVal value As Integer)
                Me.Transac_crea = value
            End Set
        End Property


        Private Transac_edit As Integer

        Public Property pTransac_edit() As Integer
            Get
                Return Me.Transac_edit
            End Get
            Set(ByVal value As Integer)
                Me.Transac_edit = value
            End Set
        End Property

    End Class

#End Region

#Region "Facturación"
    Public Class Facturacion
        Public Sub New()
        End Sub

        Private Servicio_ID As Integer

        Public Property pServicio_ID() As Integer
            Get
                Return Me.Servicio_ID
            End Get
            Set(ByVal value As Integer)
                Me.Servicio_ID = value
            End Set
        End Property

        Private Servicio_Desc As String

        Public Property pServicio_Desc() As String
            Get
                Return Me.Servicio_Desc
            End Get
            Set(ByVal value As String)
                Me.Servicio_Desc = value
            End Set
        End Property

        Private Tarifa_ID As Integer

        Public Property pTarifa_ID() As Integer
            Get
                Return Me.Tarifa_ID
            End Get
            Set(ByVal value As Integer)
                Me.Tarifa_ID = value
            End Set
        End Property

        Private Tarifa_Desc As String

        Public Property pTarifa_Desc() As String
            Get
                Return Me.Tarifa_Desc
            End Get
            Set(ByVal value As String)
                Me.Tarifa_Desc = value
            End Set
        End Property

        Private Minimo_medida As Integer

        Public Property pMinimo_medida() As Integer
            Get
                Return Me.Minimo_medida
            End Get
            Set(ByVal value As Integer)
                Me.Minimo_medida = value
            End Set
        End Property

        Private Máximo_medida As Integer

        Public Property pMáximo_medida() As Integer
            Get
                Return Me.Máximo_medida
            End Get
            Set(ByVal value As Integer)
                Me.Máximo_medida = value
            End Set
        End Property

        Private Importe_base As Double

        Public Property pImporte_base() As Double
            Get
                Return Me.Importe_base
            End Get
            Set(ByVal value As Double)
                Me.Importe_base = value
            End Set
        End Property

        Private Importe_exceso As Double

        Public Property pImporte_exceso() As Double
            Get
                Return Me.Importe_exceso
            End Get
            Set(ByVal value As Double)
                Me.Importe_exceso = value
            End Set
        End Property

        Private Transac_tarifa As Integer

        Public Property pTransac_tarifa() As Integer
            Get
                Return Me.Transac_tarifa
            End Get
            Set(ByVal value As Integer)
                Me.Transac_tarifa = value
            End Set
        End Property

        Private Fecha_edicion As DateTime

        Public Property pFecha_edicion() As DateTime
            Get
                Return Me.Fecha_edicion
            End Get
            Set(ByVal value As DateTime)
                Me.Fecha_edicion = value
            End Set
        End Property
    End Class
#End Region

#Region "Cobros"
    Public Class Cobros

        Public Sub New()
        End Sub

        Private Fecha_abono As Date

        Public Property pFecha_abono() As DateTime
            Get
                Return Me.Fecha_abono
            End Get
            Set(ByVal value As DateTime)
                Me.Fecha_abono = value
            End Set
        End Property

        Private Fecha_transaccion As DateTime

        Public Property pFecha_transaccion() As DateTime
            Get
                Return Me.Fecha_transaccion
            End Get
            Set(ByVal value As DateTime)
                Me.Fecha_transaccion = value
            End Set
        End Property

        Private Transac_Num As Integer

        Public Property pTransac_Num() As Integer
            Get
                Return Me.Transac_Num
            End Get
            Set(ByVal value As Integer)
                Me.Transac_Num = value
            End Set
        End Property

        Private Factura_Num As Integer

        Public Property pFactura_Num() As Integer
            Get
                Return Me.Factura_Num
            End Get
            Set(ByVal value As Integer)
                Me.Factura_Num = value
            End Set
        End Property

        Private Socio_ID As Integer
        Public Property pSocio_ID() As Integer
            Get
                Return Me.Socio_ID
            End Get
            Set(ByVal value As Integer)
                Me.Socio_ID = value
            End Set
        End Property

        Private Propietario_nom As String
        Public Property pPropietario_nom() As String
            Get
                Return Me.Propietario_nom
            End Get
            Set(ByVal value As String)
                Me.Propietario_nom = value
            End Set
        End Property

        Private Saldo_actual As Double
        Public Property pSaldo_actual() As Double
            Get
                Return Me.Saldo_actual
            End Get
            Set(ByVal value As Double)
                Me.Saldo_actual = value
            End Set
        End Property

        Private Abono As Double
        Public Property pAbono() As Double
            Get
                Return Me.Abono
            End Get
            Set(ByVal value As Double)
                Me.Abono = value
            End Set
        End Property

        Private Nuevo_saldo As Double
        Public Property pNuevo_saldo() As Double
            Get
                Return Me.Nuevo_saldo
            End Get
            Set(ByVal value As Double)
                Me.Nuevo_saldo = value
            End Set
        End Property

        Private Modalidad_ID As Integer

        Public Property pModalidad_ID() As Integer
            Get
                Return Modalidad_ID
            End Get
            Set(ByVal value As Integer)
                Me.Modalidad_ID = value
            End Set
        End Property

        Private Banco As String
        Public Property pBanco() As String
            Get
                Return Me.Banco
            End Get
            Set(ByVal value As String)
                Me.Banco = value
            End Set
        End Property


        Private Referencia_num As String
        Public Property pReferencia_num() As String
            Get
                Return Me.Referencia_num
            End Get
            Set(ByVal value As String)
                Me.Referencia_num = value
            End Set
        End Property




        Private Anotaciones As String
        Public Property pAnotaciones() As String
            Get
                Return Me.Anotaciones
            End Get
            Set(ByVal value As String)
                Me.Anotaciones = value
            End Set
        End Property

    End Class

    Public Class Modalidad_pago

        Public Sub New()
        End Sub

        Private Modalidad_ID As Integer

        Public Property pModalidad_ID() As Integer
            Get
                Return Modalidad_ID
            End Get
            Set(ByVal value As Integer)
                Me.Modalidad_ID = value
            End Set
        End Property

        Private Modalidad_Desc As String

        Public Property pModalidad_Desc() As String
            Get
                Return Modalidad_Desc
            End Get
            Set(ByVal value As String)
                Me.Modalidad_Desc = value
            End Set
        End Property





    End Class

#End Region

#Region "Períodos"
    Public Class Periodos
        Public Sub New()
        End Sub

        Private periodo_ID As String

        Public Property pperiodo_ID() As String
            Get
                Return Me.periodo_ID
            End Get
            Set(ByVal value As String)
                Me.periodo_ID = value
            End Set
        End Property

        Private año As Integer

        Public Property paño() As Integer
            Get
                Return Me.año
            End Get
            Set(ByVal value As Integer)
                Me.año = value
            End Set
        End Property

        Private mes As Integer

        Public Property pmes() As Integer
            Get
                Return Me.mes
            End Get
            Set(ByVal value As Integer)
                Me.mes = value
            End Set
        End Property

        Private Emite_listado As DateTime

        Public Property pEmite_listado() As DateTime
            Get
                Return Me.Emite_listado
            End Get
            Set(ByVal value As DateTime)
                Me.Emite_listado = value
            End Set
        End Property

        Private Lectura_medidor As DateTime

        Public Property pLectura_medidor() As DateTime
            Get
                Return Me.Lectura_medidor
            End Get
            Set(ByVal value As DateTime)
                Me.Lectura_medidor = value
            End Set
        End Property

        Private Ingreso_lecturas As DateTime

        Public Property pIngreso_lecturas() As DateTime
            Get
                Return Me.Ingreso_lecturas
            End Get
            Set(ByVal value As DateTime)
                Me.Ingreso_lecturas = value
            End Set
        End Property

        Private Analisis_incons As DateTime

        Public Property pAnalisis_incons() As DateTime
            Get
                Return Me.Analisis_incons
            End Get
            Set(ByVal value As DateTime)
                Me.Analisis_incons = value
            End Set
        End Property

        Private Analisis_Corte_servicio As DateTime

        Public Property pAnalisis_Corte_servicio() As DateTime
            Get
                Return Me.Analisis_Corte_servicio
            End Get
            Set(ByVal value As DateTime)
                Me.Analisis_Corte_servicio = value
            End Set
        End Property

        Private Aprobacion_lecturas As DateTime

        Public Property pAprobacion_lecturas() As DateTime
            Get
                Return Me.Aprobacion_lecturas
            End Get
            Set(ByVal value As DateTime)
                Me.Aprobacion_lecturas = value
            End Set
        End Property

        Private Emision_factura As DateTime

        Public Property pEmision_factura() As DateTime
            Get
                Return Me.Emision_factura
            End Get
            Set(ByVal value As DateTime)
                Me.Emision_factura = value
            End Set
        End Property

        Private Distribuye_fact As DateTime

        Public Property pDistribuye_fact() As DateTime
            Get
                Return Me.Distribuye_fact
            End Get
            Set(ByVal value As DateTime)
                Me.Distribuye_fact = value
            End Set
        End Property

        Private Vencimiento_fac As DateTime

        Public Property pVencimiento_fac() As DateTime
            Get
                Return Me.Vencimiento_fac
            End Get
            Set(ByVal value As DateTime)
                Me.Vencimiento_fac = value
            End Set
        End Property

        Private Aviso_corte As DateTime

        Public Property pAviso_corte() As DateTime
            Get
                Return Me.Aviso_corte
            End Get
            Set(ByVal value As DateTime)
                Me.Aviso_corte = value
            End Set
        End Property

        Private Corte_suministro As DateTime

        Public Property pCorte_suministro() As DateTime
            Get
                Return Me.Corte_suministro
            End Get
            Set(ByVal value As DateTime)
                Me.Corte_suministro = value
            End Set
        End Property


        Private Estado As String

        Public Property pEstado() As String
            Get
                Return Me.Estado
            End Get
            Set(ByVal value As String)
                Me.Estado = value
            End Set
        End Property

        Private Transac_num As Integer

        Public Property pTransac_num() As Integer 'De creación
            Get
                Return Me.Transac_num
            End Get
            Set(ByVal value As Integer)
                Me.Transac_num = value
            End Set
        End Property

        Private Transac_fecha As DateTime

        Public Property pTransac_fecha() As DateTime 'De creación / Edición
            Get
                Return Me.Transac_fecha
            End Get
            Set(ByVal value As DateTime)
                Me.Transac_fecha = value
            End Set
        End Property

        Private Dias_gracia As Integer

        Public Property pDias_gracia() As Integer 'despues de la fecha de vencimiento
            Get
                Return Me.Dias_gracia
            End Get
            Set(ByVal value As Integer)
                Me.Dias_gracia = value
            End Set
        End Property

        Private Vencimiento_real As DateTime

        Public Property pVencimiento_real() As DateTime 'al sumar los días de gracia
            Get
                Return Me.Vencimiento_real
            End Get
            Set(ByVal value As DateTime)
                Me.Vencimiento_real = value
            End Set
        End Property


    End Class
#End Region


End Class

