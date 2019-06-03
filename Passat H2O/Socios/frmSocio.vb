Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmSocio
    Dim instancia As New Datos.Users
    Dim grid As New Formatos
    Public Modo_abre As String
    Dim cargando As Boolean = True
    Public Socio_ID As Integer = 0
    Public Periodo_convenio As Integer = 0

    Dim socio As New Socio


    Private Sub frmSocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carga_combos_Sector()
        Carga_combos_Bloques()
        ' Carga_Sendas()

        If Me.Modo_abre = "Edición" Then
            socio.pSocio_ID = Socio_ID
            Carga_Datos(socio.pSocio_ID)
            Carga_Grid_servicios(socio.pSocio_ID)
            Llena_controles()
        End If
        cargando = False
        Me.MdiParent = My.Forms.frmPrincipal
        Me.dgvServicios_contratados.DefaultCellStyle.Font = New Font("Arial", 10)
    End Sub

    Sub Carga_Datos(ByVal Socio_ID As Integer)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select * From Socios WHERE Socio_ID = '{0}'", Socio_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            With socio
                                .pSocio_ID = dr(0)
                                .pSector_ID = dr(1)
                                .pBloque_ID = dr(2)
                                .pCorrelativo_ruta = dr(3)
                                '.pSenda = dr(4)
                                .ppropietario = dr(4)
                                .pinquilino = dr(5)
                                .ptel_fijo = dr(6)
                                .ptel_portatil = dr(7)
                                .pruta = dr(8)
                                .pcontador_num = dr(9)
                                .pLectura_ultima = dr(10)
                                .pLectura_penultima = dr(11)
                                .pEstado = CType(dr(12), Boolean)
                                .pTransac_crea = dr(13)
                                .pTransac_edit = dr(14)
                                .pFecha_crea = CType(dr(15), Date)
                                .pFecha_edita = CType(dr(16), Date)
                                'La dr(17) es el numero de la cuenta vieja. Los nuevos caeran con un cero en ese campo
                                .pDireccion_fisica = dr(18)
                                .pConvenio = dr(19)
                                .pPeriodo_Convenio = dr(20)
                                'Pendiente modificar la rutina de actualizaci[on del socio
                            End With
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
                        Me.Close()
                    End Try
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Llena_controles()
        With socio
            Me.txtSocio_ID.Text = Socio_ID
            Me.txtCorrelativo_ruta.Text = .pCorrelativo_ruta
            Me.txtContador_num.Text = .pcontador_num
            Me.txtCorreo_elec.Text = .pcorreo
            Me.txtInquilino_nom.Text = .pinquilino
            Me.txtPropietario_nom.Text = .ppropietario
            Me.txtTel_fijo.Text = .ptel_fijo
            Me.txtTel_portatil.Text = .ptel_portatil
            Me.cmbBloque.SelectedValue = .pBloque_ID
            Me.cmbSector.SelectedValue = .pSector_ID
            Me.txtLectura_ultima.Text = .pLectura_ultima
            Me.txtLectura_penultima.Text = .pLectura_penultima
            Me.txtSocio_ID.Enabled = False
            Me.txtDireccion_fisica.Text = .pDireccion_fisica
            Me.chkConvenioPago.Checked = .pConvenio
            Me.chkActivo.Checked = .pEstado
            Me.txtPeriodo_convenio.Text = .pPeriodo_Convenio
        End With
    End Sub

    Sub Carga_Grid_servicios(ByVal Socio_ID As Integer)
        Try
            Dim dr As SqlDataReader

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Servicios_socio", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    dr = comm.ExecuteReader
                    Try
                        Me.dgvServicios_contratados.Columns.Add(0, "Servicio")
                        Me.dgvServicios_contratados.Columns.Add(1, "Servicio Descripción")
                        Me.dgvServicios_contratados.Columns.Add(2, "Tarifa")
                        Me.dgvServicios_contratados.Columns.Add(3, "Tarifa Descripción")
                        Me.dgvServicios_contratados.Columns(0).Width = 50
                        Me.dgvServicios_contratados.Columns(1).Width = 150
                        Me.dgvServicios_contratados.Columns(3).Width = 150

                        While dr.Read
                            Me.dgvServicios_contratados.Rows.Add()
                            With Me.dgvServicios_contratados
                                .Item(0, .Rows.Count - 1).Value = dr(0)
                                .Item(1, .Rows.Count - 1).Value = dr(1)
                                .Item(2, .Rows.Count - 1).Value = dr(2)
                                .Item(3, .Rows.Count - 1).Value = dr(3)
                            End With
                        End While

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Sector()
        Try
            Dim Sectores As New List(Of Sectores)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Seleccione Sector' UNION Select Sector_ID, Sector_Desc From Sectores", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Sectores
                        lista.pSectorID = items(0)
                        lista.pSector_Desc = items(1)
                        Sectores.Add(lista)
                    End While

                    Me.cmbSector.DataSource = Sectores
                    Me.cmbSector.ValueMember = "pSectorID"
                    Me.cmbSector.DisplayMember = "pSector_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques()
        Try
            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques(ByVal Sector As Integer)
        Try

            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques WHERE Sector_ID = '{0}'", Me.cmbSector.SelectedValue), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    'Sub Carga_Sendas()
    '    Try
    '        Dim Sendas As New List(Of Avenidas)
    '        Using conn As New SqlConnection(instancia.pCadena_conexion)
    '            conn.Open()
    '            Using comm As New SqlCommand("Select 0, 'Seleccione Senda' UNION Select Senda_ID, Senda_Desc From Sendas", conn)
    '                Dim dr As SqlDataReader = comm.ExecuteReader
    '                Dim items(2) As Object
    '                While dr.Read
    '                    dr.GetValues(items)
    '                    Dim lista As New Avenidas
    '                    lista.pAvenidaID = items(0)
    '                    lista.pAvenida_Desc = items(1)
    '                    Sendas.Add(lista)
    '                End While
    '                Me.cmbSenda.DataSource = Sendas
    '                Me.cmbSenda.ValueMember = "pAvenidaID"
    '                Me.cmbSenda.DisplayMember = "pAvenida_Desc"
    '                dr.Close()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
    '    End Try
    'End Sub

    Private Sub cmbSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSector.SelectedIndexChanged
        Try
            If cargando Then Exit Sub
            Me.Carga_combos_Bloques(Me.cmbSector.SelectedValue)
            Me.txtDireccion_fisica.Text = String.Empty
            Me.txtDireccion_fisica.Text = Me.cmbSector.Text + " " + Me.cmbBloque.Text + " Casa No. " + Me.txtCasa_Num_Fisico.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.Modo_abre = "Nuevo" Then
            'Rutina de INSERT
            If Verifica_Campos() Then
                'Rutina de Genera_transaccion
                Me.Asigna_variables(socio)
                If Genera_transaccion(socio) Then
                    Insert_socio(socio)
                    If My.Forms.frmSocio_Maestro.Visible Then
                        My.Forms.frmSocio_Maestro.Activate()
                    End If

                Else
                    MsgBox("Error al generar la transacción. ", MsgBoxStyle.Exclamation, "Pasat h2o")
                    Exit Sub
                End If
            End If

        Else
            'Rutina de UPDATE
            If Verifica_Campos() Then
                'Rutina de Genera_transaccion
                Me.Asigna_variables(socio)
                If Genera_transaccion(socio) Then
                    Update_socio(socio)
                    If My.Forms.frmSocio_Maestro.Visible Then
                        My.Forms.frmSocio_Maestro.Activate()
                    End If
                Else
                    MsgBox("Error al generar la transacción. ", MsgBoxStyle.Exclamation, "Pasat h2o")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Function Genera_transaccion(ByVal socio As Socio) As Boolean
        Try
            Using conn As New SqlClient.SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim fecha As DateTime
                fecha = DateTime.Now
                socio.pFecha_crea = fecha
                socio.pFecha_edita = fecha

                Using comm As New SqlCommand("sp_Insert_Transaccion", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Transac_ID", SqlDbType.VarChar, 4).Value = "100" 'Alta de socio
                    comm.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha
                    Dim usuario As New Datos.Users

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.VarChar, 6).Value = usuario.pUsuario_conectado 'instancia.pUser_ID
                    comm.ExecuteNonQuery()
                End Using

                Using comm As New SqlCommand("SELECT IDENT_CURRENT('Transacciones_sistema')", conn)
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    If reader.HasRows Then
                        reader.Read()
                        socio.pTransac_num = Convert.ToInt32(reader(0))
                        socio.pTransac_crea = socio.pTransac_num
                        socio.pTransac_edit = socio.pTransac_num
                    End If
                End Using
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "iCoop")
            Return False
        End Try
    End Function

    Sub Update_socio(ByVal socio As Socio)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Update_socio", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    With socio
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = .pSocio_ID
                        comm.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = .pSector_ID
                        comm.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 4).Value = .pBloque_ID
                        comm.Parameters.Add("@Casa_num", SqlDbType.Int).Value = .pCorrelativo_ruta
                        'comm.Parameters.Add("@Senda", SqlDbType.Int).Value = .pSenda
                        comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 100).Value = .ppropietario
                        comm.Parameters.Add("@Inquilino", SqlDbType.VarChar, 100).Value = .pinquilino
                        comm.Parameters.Add("@Tel_fijo", SqlDbType.VarChar, 50).Value = .ptel_fijo
                        comm.Parameters.Add("@Tel_port", SqlDbType.VarChar, 50).Value = .ptel_portatil
                        comm.Parameters.Add("@Ruta", SqlDbType.Int).Value = .pruta
                        comm.Parameters.Add("@Medidor_num", SqlDbType.VarChar, 20).Value = .pcontador_num
                        comm.Parameters.Add("@Lectura_ultima", SqlDbType.Int).Value = .pLectura_ultima
                        comm.Parameters.Add("@Lectura_penultima", SqlDbType.Int).Value = .pLectura_penultima
                        comm.Parameters.Add("@Estado", SqlDbType.Bit).Value = .pEstado
                        comm.Parameters.Add("@Transac_Edita_num", SqlDbType.Int).Value = .pTransac_edit
                        comm.Parameters.Add("@Fecha_edita", SqlDbType.Date).Value = .pFecha_edita
                        comm.Parameters.Add("@Direccion_fisica", SqlDbType.VarChar, 500).Value = .pDireccion_fisica
                        comm.Parameters.Add("@Convenio", SqlDbType.Bit).Value = .pConvenio
                        comm.Parameters.Add("@Periodo_convenio", SqlDbType.Int).Value = .pPeriodo_Convenio
                    End With
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using

                Using comm As New SqlCommand(String.Format("DELETE Servicios_Cliente WHERE Socio_ID = '{0}'", socio.pSocio_ID), conn)
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using

                Try
                    Dim i As Integer = 0
                    For i = 0 To (Me.dgvServicios_contratados.Rows.Count - 1)
                        Using comm As New SqlCommand("sp_Inserta_Servicios_Socio", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            With socio
                                comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = .pSocio_ID
                                comm.Parameters.Add("@Servicio_ID", SqlDbType.Int).Value = CInt(Me.dgvServicios_contratados.Item(0, i).Value)
                                comm.Parameters.Add("@Servicio_Desc", SqlDbType.VarChar, 50).Value = Me.dgvServicios_contratados.Item(1, i).Value.ToString
                            End With
                            comm.ExecuteNonQuery()
                            comm.Dispose()
                        End Using
                    Next
                    MsgBox("Socio Actualizado Satisfactoriamente!", MsgBoxStyle.Information, "Pasat h2o")
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Error al insertar los servicios del abonado! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h2o")
                End Try

            End Using
        Catch ex As Exception
            MsgBox("Error! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Sub Insert_socio(ByVal Socio As Socio)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Inserta_socio", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    With Socio
                        comm.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = .pSector_ID
                        comm.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 4).Value = .pBloque_ID
                        comm.Parameters.Add("@Casa_num", SqlDbType.Int).Value = .pCorrelativo_ruta
                        comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 100).Value = .ppropietario
                        comm.Parameters.Add("@Inquilino", SqlDbType.VarChar, 100).Value = .pinquilino
                        comm.Parameters.Add("@Tel_fijo", SqlDbType.VarChar, 50).Value = .ptel_fijo
                        comm.Parameters.Add("@Tel_port", SqlDbType.VarChar, 50).Value = .ptel_portatil
                        comm.Parameters.Add("@Ruta", SqlDbType.Int).Value = .pruta
                        comm.Parameters.Add("@Medidor_num", SqlDbType.VarChar, 20).Value = .pcontador_num
                        comm.Parameters.Add("@Estado", SqlDbType.Bit).Value = .pEstado
                        comm.Parameters.Add("@Transac_Crea_num", SqlDbType.Int).Value = .pTransac_crea
                        comm.Parameters.Add("@Transac_Edita_num", SqlDbType.Int).Value = .pTransac_edit
                        comm.Parameters.Add("@Fecha_Crea", SqlDbType.Date).Value = .pFecha_crea
                        comm.Parameters.Add("@Fecha_edita", SqlDbType.Date).Value = .pFecha_edita
                        comm.Parameters.Add("@Direccion_fisica", SqlDbType.VarChar, 500).Value = .pDireccion_fisica
                        comm.Parameters.Add("@Convenio", SqlDbType.Bit).Value = .pConvenio
                    End With
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using

                Using comm As New SqlCommand("SELECT IDENT_CURRENT('Socios')", conn)
                    Dim reader As SqlDataReader = comm.ExecuteReader
                    If reader.HasRows Then
                        reader.Read()
                        Socio.pSocio_ID = Convert.ToInt32(reader(0))
                        reader.Close()
                        Me.txtSocio_ID.Text = Socio.pSocio_ID
                    End If
                End Using

                Using comm As New SqlCommand(String.Format("DELETE Servicios_Cliente WHERE Socio_ID = '{0}'", Socio.pSocio_ID), conn)
                    comm.ExecuteNonQuery()
                    comm.Dispose()
                End Using

                Dim i As Integer = 0
                For i = 0 To (Me.dgvServicios_contratados.Rows.Count - 1)
                    Using comm As New SqlCommand("sp_Inserta_Servicios_Socio", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        With Socio
                            comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = .pSocio_ID
                            comm.Parameters.Add("@Servicio_ID", SqlDbType.Int).Value = CInt(Me.dgvServicios_contratados.Item(0, i).Value)
                            comm.Parameters.Add("@Servicio_Desc", SqlDbType.VarChar, 50).Value = Me.dgvServicios_contratados.Item(1, i).Value.ToString
                        End With
                        comm.ExecuteNonQuery()
                        comm.Dispose()
                    End Using
                Next
                MsgBox("Socio Creado Satisfactoriamente! ", MsgBoxStyle.Information, "Pasat h2o")
                Me.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat h2o")
        End Try
    End Sub

    Function Verifica_Campos() As Boolean
        If Me.cmbSector.SelectedIndex = 0 Then
            MsgBox("Seleccione un Sector", MsgBoxStyle.Information, "Pasat h2o")
            Return False
        End If

        If Me.cmbBloque.SelectedIndex = 0 Then
            MsgBox("Seleccione un Bloque", MsgBoxStyle.Information, "Pasat h2o")
            Return False
        End If

        'If Me.cmbSenda.SelectedIndex = 0 Then
        '    MsgBox("Seleccione una calle, avenida o senda", MsgBoxStyle.Information, "Pasat h2o")
        '    Return False
        'End If

        If Me.txtCorrelativo_ruta.Text = String.Empty Then
            MsgBox("Indique el número de casa", MsgBoxStyle.Information, "Pasat h2o")
            Return False
        End If

        If Me.txtPropietario_nom.Text = String.Empty Then
            Dim resp As Integer = MsgBox("El nombre del propietario quedará en blanco. Aceptar para dejarlo en blanco o Cancel para colocar un nombre.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Pasat h2o")
            If resp <> 0 Then
                Me.txtPropietario_nom.Focus()
                Return False
            End If
        End If

        If Me.txtInquilino_nom.Text = String.Empty Then
            Dim resp As Integer = MsgBox("El nombre del inquilino quedará en blanco. Aceptar para dejarlo en blanco o Cancel para colocar un nombre.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Pasat h2o")
            If resp <> 1 Then
                Me.txtInquilino_nom.Focus()
                Return False
            End If
        End If

        If Me.txtContador_num.Text = String.Empty Then
            MsgBox("Debe indicar el número de contador.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtContador_num.Focus()
            Return False
        End If

        If Me.dgvServicios_contratados.Rows.Count = 0 Then
            MsgBox("No ha definido los servicios contratados.", MsgBoxStyle.Information, "Pasat h2o")
            Return False
        End If

        If Me.txtLectura_ultima.Text = String.Empty Then
            MsgBox("Debe indicar un valor de lectura. Si no la hay coloque cero.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtLectura_ultima.Text = 0
            Me.txtLectura_ultima.Focus()
            Return False
        Else
            Try
                socio.pLectura_ultima = CType(Me.txtLectura_ultima.Text, Integer)
            Catch ex As Exception
                MsgBox("Verifique el valor de lectura. Debe ser mayor o igual a cero. Si no la hay coloque cero.", MsgBoxStyle.Information, "Pasat h2o")
                Return False
            End Try
        End If

        If Me.txtLectura_penultima.Text = String.Empty Then
            MsgBox("Debe indicar un valor de lectura. Si no la hay coloque cero.", MsgBoxStyle.Information, "Pasat h2o")
            Me.txtLectura_penultima.Text = 0
            Me.txtLectura_penultima.Focus()
            Return False
        Else
            Try
                socio.pLectura_penultima = CType(Me.txtLectura_penultima.Text, Integer)
            Catch ex As Exception
                MsgBox("Verifique el valor de lectura. Debe ser mayor o igual a cero. Si no la hay coloque cero.", MsgBoxStyle.Information, "Pasat h2o")
                Return False
            End Try

        End If

        If Me.txtDireccion_fisica.Text = String.Empty Then
            Me.txtDireccion_fisica.Text = Me.cmbSector.Text + " " + Me.cmbBloque.Text + " Casa No. " + Me.txtCasa_Num_Fisico.Text
        End If

        If Me.chkConvenioPago.Checked And Me.txtPeriodo_convenio.Text = Nothing Then
            MsgBox("Ha indicado que el socio tiene convenio de pago, pero no ha indicado el período último excento de penalización.", MsgBoxStyle.Exclamation, "Datos del socio")
            Me.txtPeriodo_convenio.Focus()
            Return False
        End If

        If Me.txtPeriodo_convenio.Text = 0 Then
            MsgBox("Debe indicar un período válido. Revise la nomenclatura, por ejemplo: 201805, equivaldría a que el socio tiene convenio de pago de facturas vencidas hasta Mayo 2018. Cualquier factura vencida, posterior a esa fecha, será sujeta de penalización automática.", MsgBoxStyle.Exclamation, "Datos del socio")
            Me.txtPeriodo_convenio.Focus()
            Return False
        End If


        Return True
    End Function

    Sub Asigna_variables(ByVal Socio As Socio)
        With Socio
            .pSector_ID = Me.cmbSector.SelectedValue
            .pBloque_ID = Me.cmbBloque.SelectedValue
            .pDireccion_fisica = Me.txtDireccion_fisica.Text
            .pCorrelativo_ruta = Me.txtCorrelativo_ruta.Text
            .ppropietario = Me.txtPropietario_nom.Text
            .pinquilino = Me.txtInquilino_nom.Text
            .ptel_fijo = Me.txtTel_fijo.Text
            .ptel_portatil = Me.txtTel_portatil.Text
            .pcorreo = Me.txtCorreo_elec.Text
            .pcontador_num = Me.txtContador_num.Text
            .pLectura_ultima = CType(Me.txtLectura_ultima.Text, Integer)
            .pLectura_penultima = CType(Me.txtLectura_penultima.Text, Integer)
            .pConvenio = Me.chkConvenioPago.Checked
            Try
                .pPeriodo_Convenio = Me.txtPeriodo_convenio.Text
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Período de convenio de pago")
                Me.txtPeriodo_convenio.Text = 0
                .pPeriodo_Convenio = Me.txtPeriodo_convenio.Text
            End Try

            .pEstado = Me.chkActivo.Checked

        End With

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        My.Forms.frmServicios.Formulario_invoca = Me.Name
        My.Forms.frmServicios.Show()
    End Sub

    Private Sub chkMismo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMismo.CheckedChanged
        If Me.chkMismo.Checked = True Then
            Me.txtInquilino_nom.Text = Me.txtPropietario_nom.Text
        Else
            Me.txtInquilino_nom.Text = String.Empty
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Dim resp As Integer = 0
        resp = MsgBox("Asegúrese de guardar si hizo cambios." & vbCrLf & vbCrLf & "Aceptar para salir sin guardar. Cancelar para volver al fomulario.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
        If resp = 1 Then
            Me.Close()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        Me.dgvServicios_contratados.Rows.Remove(Me.dgvServicios_contratados.SelectedRows(0))
    End Sub

    Private Sub txtCorrelativo_ruta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCorrelativo_ruta.Leave
        Try
            Me.txtCorrelativo_ruta.Text = CType(Me.txtCorrelativo_ruta.Text, Integer)
        Catch ex As Exception
            MsgBox("El número de correlativo de casa tiene que ser un entero positivo. Es el que se utiliza en la ruta de lecturas. " & vbCrLf & vbCrLf & "Si no es indicado apropiadamente, corre el riesgo de que quede fuera de la ruta de lectura." & vbCrLf & vbCrLf & "El número físico real de la casa debe ser colocado en el siguiente campo.", MsgBoxStyle.Information, "Pasat H2O")
            Me.txtCorrelativo_ruta.Focus()
        End Try

    End Sub

    Private Sub txtCorrelativo_ruta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCorrelativo_ruta.TextChanged
        Me.txtCasa_Num_Fisico.Text = Me.txtCorrelativo_ruta.Text

    End Sub

    Private Sub cmbBloque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBloque.SelectedIndexChanged
        Me.txtDireccion_fisica.Text = Me.cmbSector.Text + " " + Me.cmbBloque.Text + " Casa No. " + Me.txtCasa_Num_Fisico.Text
    End Sub

    Private Sub cmbSenda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtDireccion_fisica.Text = Me.cmbSector.Text + " " + Me.cmbBloque.Text + " Casa No. " + Me.txtCasa_Num_Fisico.Text
    End Sub

    Private Sub btnCerrar_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar_ayuda.Click
        Me.PanAyuda.Visible = False
    End Sub

    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        Me.PanAyuda.Visible = True
    End Sub

    Private Sub txtCasa_Num_Fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCasa_Num_Fisico.TextChanged
        Me.txtDireccion_fisica.Text = Me.cmbSector.Text + " " + Me.cmbBloque.Text + " Casa No. " + Me.txtCasa_Num_Fisico.Text
    End Sub

    Private Sub chkConvenioPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConvenioPago.CheckedChanged
        If Me.chkConvenioPago.Checked Then
            Me.txtPeriodo_convenio.Enabled = True
        Else
            Dim respuesta = MsgBox("Al deshabilitar el convenio se borrará el período de convenio, si ha indicado alguno." & vbCrLf & "Desea deshabilitar el convenio?", MsgBoxStyle.YesNo)
            If respuesta = 6 Then
                Me.txtPeriodo_convenio.Enabled = False
                Me.txtPeriodo_convenio.Text = 0
            End If
        End If
    End Sub

    Private Sub txtPeriodo_convenio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeriodo_convenio.Leave
        If Me.chkConvenioPago.Checked And Me.txtPeriodo_convenio.Text = Nothing Then
            MsgBox("Si selecciona la opción convenio de pago debe indicar el período último exento de penalización por vencimiento de factura", MsgBoxStyle.Information)
            Me.txtPeriodo_convenio.Text = 0
            Me.chkConvenioPago.Checked = False
        End If

        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("select PeriodoID from periodos WHERE Estado = 'Activo'", conn)
                Dim dr As SqlDataReader = comm.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    Dim periodo_activo = dr(0)
                    Dim periodo_convenio = Me.txtPeriodo_convenio.Text
                    If periodo_convenio > periodo_activo Then
                        MsgBox("El período convenido no puede ser superiror al período activo -" + periodo_activo + "-")
                    End If
                End If


            End Using
        End Using
    End Sub
End Class