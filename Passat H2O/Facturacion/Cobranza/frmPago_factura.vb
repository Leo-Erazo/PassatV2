Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmPago_factura
    Dim instancia As New Datos.Users
    Dim cobro As New Datos.Cobros
    Public Socio_ID, Periodo_ID, Factura_Num As Integer
    Public Socio_Nombre, Vence As String
    Dim saldoTotal = 0

    Private Sub frmPago_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmPrincipal
        Carga_Modalidad_pago()
        crear_cuadricula()
        carga_datos(Factura_Num)
    End Sub

    Sub crear_cuadricula()
        Me.txtSocio_ID.Text = Me.Socio_ID
        Me.txtSocio_nombre.Text = Me.Socio_Nombre
        Me.txtFactura_No.Text = Me.Factura_Num
        Me.txtPeriodo_ID.Text = Me.Periodo_ID
        Me.txtFecha_vence.Text = Me.Vence

        Me.dgvRubros.Columns.Add("item", "Item")
        Me.dgvRubros.Columns.Add("Rubro_ID", "Rubro ID")
        Me.dgvRubros.Columns.Add("Servicio_desc", "Descripción del servicio")
        Me.dgvRubros.Columns.Add("Saldo", "Saldo")
        Me.dgvRubros.Columns.Add("Abono", "Importe Abono")
        Me.dgvRubros.Columns.Add("Nuevo_Saldo", "Nuevo Saldo")
        Me.dgvRubros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRubros.Columns(0).Width = 20
        Me.dgvRubros.Columns(1).Width = 30
        Me.dgvRubros.Columns(2).Width = 100
        Me.dgvRubros.Columns(3).Width = 30
        Me.dgvRubros.Columns(4).Width = 30
        Me.dgvRubros.Columns(5).Width = 30
        Me.dgvRubros.Columns(1).ReadOnly = True
        Me.dgvRubros.Columns(2).ReadOnly = True
        Me.dgvRubros.Columns(3).ReadOnly = True
        Me.dgvRubros.Columns(5).ReadOnly = True
    End Sub



    Sub carga_datos(ByVal Factura_No As Integer)
        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand(String.Format("SELECT cc.servicio_ID, s.Servicio_desc, cc.Saldo, S.prioridad  FROM Cargos_cliente cc INNER JOIN Servicios s ON	s.Servicio_Id = cc.servicio_ID WHERE Factura_num = '{0}' AND Saldo>0 ORDER BY Factura_num, prioridad ASC", Factura_No), conn)
                Dim dr As SqlDataReader
                dr = comm.ExecuteReader()
                Try
                    Dim item(3) As Object
                    Dim i As Integer = 0

                    While dr.Read
                        dr.GetValues(item)
                        Me.dgvRubros.Rows.Add()
                        Me.dgvRubros.Item(0, i).Value = i + 1
                        Me.dgvRubros.Item(1, i).Value = item(0)
                        Me.dgvRubros.Item(2, i).Value = item(1)
                        Me.dgvRubros.Item(3, i).Value = item(2)
                        Me.dgvRubros.Item(3, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        Me.dgvRubros.Item(4, i).Value = 0.0
                        Me.dgvRubros.Item(4, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        Me.dgvRubros.Item(5, i).Value = item(2)
                        Me.dgvRubros.Item(5, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        saldoTotal += item(2)
                        i += 1
                    End While

                    Me.tslblLineas.Text = i
                    Me.tslblTotal_saldo.Text = saldoTotal

                    dr.Close()

                    Me.dgvRubros.Item(4, 0).Selected = True
                    Me.cmbModalidad.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                End Try
            End Using
        End Using

    End Sub

    Private Sub dgvRubros_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRubros.CellBeginEdit

        Dim fila_actual As Integer
        fila_actual = Me.dgvRubros.CurrentRow.Index.ToString
        If verifica_pago_rubro(fila_actual) = False Then
            MsgBox("No se puede abonar a un rubro si el inmediato superior de la lista no quedará a saldo cero al guardar el abono" & vbCrLf & "Verifique el abono del item anterior.", MsgBoxStyle.Exclamation, "Abonos a factura")
            Me.dgvRubros.Item(4, fila_actual).Value = 0
            Me.dgvRubros.Item(5, fila_actual).Value = Me.dgvRubros.Item(3, fila_actual).Value
            Me.dgvRubros.Item(4, 0).Selected = True
            Exit Sub
        End If
        Me.dgvRubros.CurrentRow.Cells(4).Style.BackColor = Color.Orange
        If Me.dgvRubros.CurrentRow.Cells(4).Value = 0 Then
            Me.dgvRubros.CurrentRow.Cells(4).Value = Nothing
        End If
    End Sub

    Private Sub dgvRubros_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRubros.CellEndEdit
        Me.dgvRubros.CurrentRow.Cells(4).Style.BackColor = Color.White
        If Me.dgvRubros.CurrentRow.Cells(4).Value = Nothing Then
            Me.dgvRubros.CurrentRow.Cells(4).Value = 0
        Else
            Try
                Dim verifica = Me.dgvRubros.CurrentRow.Cells(4).Value / 1
                If Me.dgvRubros.CurrentRow.Cells(3).Value < Me.dgvRubros.CurrentRow.Cells(4).Value Then
                    MsgBox("No se aceptan abonos superiores al cargo adeudado. Verifique el importe a abonar a este rubro", MsgBoxStyle.Exclamation, "Abonos a factura")
                    Me.dgvRubros.CurrentRow.Cells(4).Value = 0
                    Me.dgvRubros.CurrentRow.Cells(5).Value = Me.dgvRubros.CurrentRow.Cells(3).Value
                    Exit Sub
                End If
                Me.dgvRubros.CurrentRow.Cells(5).Value = Me.dgvRubros.CurrentRow.Cells(3).Value - Me.dgvRubros.CurrentRow.Cells(4).Value
                
            Catch ex As Exception
                MsgBox("Debe ingresar un valor numérico!", MsgBoxStyle.Exclamation, "Abonos a factura")
                Me.dgvRubros.CurrentRow.Cells(4).Value = 0
                Exit Sub
            End Try
        End If

        Dim suma_abonos = 0
        Dim i = 0

        For i = 0 To Me.dgvRubros.Rows.Count - 1
            suma_abonos += Me.dgvRubros.Item(4, i).Value
        Next
        Me.tslblTotal_abonando.Text = suma_abonos
    End Sub

    Function verifica_pago_rubro(ByVal fila As Integer) As Boolean
        ' MsgBox("En fila " & fila)
        If fila = 0 Then
            Return True
        End If
        Dim saldo_fila_anterior = Me.dgvRubros.Item(5, fila - 1).Value
        If fila > 0 And (saldo_fila_anterior = 0.0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Me.cmbModalidad.SelectedIndex = 0 Then
                MsgBox("Seleccion una modalidad de pago", MsgBoxStyle.Exclamation, "Abono factura")
                Me.cmbModalidad.Focus()
                Exit Sub
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim i As Integer = 0
                Dim abono_total As Decimal = 0.0
                Dim transac_num As Integer = 0

                Using comm1 As New SqlCommand("sp_Genera_transac_abono", conn)
                    comm1.CommandType = CommandType.StoredProcedure
                    comm1.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = instancia.pUsuario_conectado
                    Dim dr1 As SqlDataReader = comm1.ExecuteReader
                    dr1.Read()
                    Try
                        transac_num = dr1(0)
                        dr1.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try

                End Using

                For i = 0 To Me.dgvRubros.Rows.Count - 1
                    If i = 0 And Me.dgvRubros.Item(4, 0).Value = 0 Then
                        MsgBox("Debe aplicar un abono. No se ha realizado ningún abono.", MsgBoxStyle.Exclamation, "Abono a factura")
                        Exit Sub
                    End If

                    aplicar_abono(transac_num, conn, i)

                    abono_total += Me.dgvRubros.Item(4, 0).Value
                Next

                'Dim estatus As String = "Pagada"
                'Dim factura_num As Integer = CInt(Me.txtFactura_No.Text)

                'If abono_total <> saldoTotal Then
                '    estatus = "Pago parcial"
                'End If

                actualiza_encabezado(Factura_Num)

                Me.dgvRubros.Rows.Clear()
                Me.dgvRubros.Columns.Clear()
                Me.tslblTotal_abonando.Text = 0

                My.Forms.frmImprime_Recibo.Transac_Num = transac_num
                My.Forms.frmImprime_Recibo.Factura_num = factura_num
                My.Forms.frmImprime_Recibo.saldo_anterior = saldoTotal
                My.Forms.frmImprime_Recibo.Show()
                My.Forms.frmFacturas_listado.txtSocio_ID.Clear()

                Me.Close()

                'frmPago_factura_Load(Nothing, Nothing)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Abono a factura")
        End Try
    End Sub

    Sub aplicar_abono(ByVal transac_num As Integer, ByVal conn As SqlConnection, ByVal fila As Integer)
        Dim socio_ID, factura_num, servicio_id, Usuario_ID, Modalidad_abono As Integer
        Dim saldo_actual, abono, nuevo_saldo As Double
        Dim Fecha_Abono As DateTime
        Dim Anotaciones, Banco, Referencia As String

        Try
            socio_ID = Me.txtSocio_ID.Text
            factura_num = Me.txtFactura_No.Text
            Fecha_Abono = DateAdd(DateInterval.Minute, 1, Me.dtpFecha_abono.Value)
            Anotaciones = Me.txtAnotaciones.Text
            Usuario_ID = instancia.pUsuario_conectado
            Modalidad_abono = Me.cmbModalidad.SelectedValue
            Banco = Me.txtBanco.Text
            Referencia = Me.txtRef_num.Text

            servicio_id = Me.dgvRubros.Item(1, fila).Value
            saldo_actual = Me.dgvRubros.Item(3, fila).Value
            abono = Me.dgvRubros.Item(4, fila).Value

            If abono = 0 Then Exit Sub

            nuevo_saldo = Me.dgvRubros.Item(5, fila).Value

            Using comm As New SqlCommand("sp_Inserta_Abono_pago", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.Add("@Transac_num", SqlDbType.Int).Value = transac_num
                comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = socio_ID
                comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = factura_num
                comm.Parameters.Add("@Servicio_ID", SqlDbType.Int).Value = servicio_id
                comm.Parameters.Add("@Saldo_actual", SqlDbType.Decimal, 18).Value = saldo_actual
                comm.Parameters.Add("@Abono", SqlDbType.Decimal, 18).Value = abono
                comm.Parameters.Add("@Nuevo_saldo", SqlDbType.Decimal, 18).Value = nuevo_saldo
                comm.Parameters.Add("@Fecha_Abono", SqlDbType.DateTime).Value = Fecha_Abono
                comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = Usuario_ID
                comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar).Value = Anotaciones
                comm.Parameters.Add("@Modalidad_abono", SqlDbType.Int).Value = Modalidad_abono
                comm.Parameters.Add("@Banco", SqlDbType.VarChar).Value = Banco
                comm.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Referencia
                comm.ExecuteNonQuery()
                comm.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Abono a factura")
        End Try


    End Sub

    Sub actualiza_encabezado(ByVal factura_num As Integer)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Actualiza_Encabezado_abono", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = factura_num
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()

                    MsgBox(dr(0), MsgBoxStyle.Information, "Abono a factura")

                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Abono a factura")
        End Try

    End Sub

    Sub Carga_Modalidad_pago()
        Try
            Dim Modalidad As New List(Of Modalidad_pago)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0 Modo_ID , 'Seleccione modalidad' Descripcion UNION Select Modo_ID, Descripcion From Modalidad_Pago", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Modalidad_pago
                        lista.pModalidad_ID = items(0)
                        lista.pModalidad_Desc = items(1)
                        Modalidad.Add(lista)
                    End While

                    Me.cmbModalidad.DataSource = Modalidad
                    Me.cmbModalidad.ValueMember = "pModalidad_ID"
                    Me.cmbModalidad.DisplayMember = "pModalidad_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try

    End Sub
End Class