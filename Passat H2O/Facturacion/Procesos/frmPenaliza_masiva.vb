Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmPenaliza_masiva
    Dim ds As New DataSet
    Dim instancia As New Datos.Users
    Public periodo As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPenaliza_masiva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Activated
        Me.MdiParent = My.Forms.frmPrincipal
        Me.lblPeriodo_mostrado.Text = periodo

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Dim cadena As String = ""
                If periodo = 0 Then
                    cadena = "Select PeriodoID, Vencimiento_real From periodos WHERE Estado = 'Activo'"
                Else
                    cadena = String.Format("Select PeriodoID, Vencimiento_real From periodos WHERE periodoID = '{0}'", periodo)
                End If

                Using comm As New SqlCommand(cadena, conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            Me.lblPeriodo_mostrado.Text = dr(0).ToString
                            Me.lblVencimiento.Text = dr(1).ToString
                        Else
                            Me.lblPeriodo_mostrado.Text = "0"
                            Me.lblVencimiento.Text = "--/--/---"
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_facturas_vencidas", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.Int).Value = CType(Me.lblPeriodo_mostrado.Text, Integer)

                    Dim da As New SqlDataAdapter(comm)
                    'Dim dgvtempo As New DataGridView

                    ds.Tables.Clear()
                    da.Fill(ds, 0)
                    Me.dgListaFacturas.DataSource = ds.Tables(0)

                    Me.tslblCuentaFacturas.Text = Me.dgListaFacturas.Rows.Count

                    Dim i As Integer = 0
                    Dim suma As Double = 0

                    For i = 0 To Me.dgListaFacturas.RowCount - 1
                        suma += Me.dgListaFacturas.Item(5, i).Value
                    Next

                    Me.tslblImporte_vencido.Text = suma
                    'Me.dgListaFacturas.Columns(5).Width = 300

                End Using
            End Using


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O V2")
        End Try

    End Sub

    Private Sub btnGenera_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenera_factura.Click

        Dim respuesta As Integer

        respuesta = MsgBox("Esta operación generará las facturas por recargo por pago vencido del período seleccionado y para los socios SIN convenio. Esta operación no se puede deshacer." & vbCrLf & vbCrLf & "Aceptar para continuar; cancelar para no facturar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Cargo por facturas vencidas")

        If respuesta = 1 Then

            Dim i As Integer = 0
            Try
                Me.tsprogressbar.Maximum = Me.dgListaFacturas.Rows.Count - 1
                Me.tsprogressbar.Visible = True
                For i = 0 To Me.dgListaFacturas.Rows.Count - 1
                    Me.tsprogressbar.Value = i
                    Dim periodo_ID = Me.dgListaFacturas.Item(0, i).Value
                    Dim Socio_ID = Me.dgListaFacturas.Item(2, i).Value
                    Dim Factura_afectada = Me.dgListaFacturas.Item(4, i).Value

                    Me.Genera_cargo_auto_pago_extempo(periodo_ID, Socio_ID, Factura_afectada)

                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Facturación de recargos pagos vencidos.")
                MsgBox("Si por alguna razón algunas facturas siguen con el estatus 'Pendiente aplicar recargo', puede ejecutar de nuevo el proceso.", MsgBoxStyle.Information, "Facturación de recargos.")
            End Try
        Else
            MsgBox("No se ha realizado ninguna acción.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Me.tsprogressbar.Value = 0
        Me.tsprogressbar.Visible = False
        Me.frmPenaliza_masiva_Load(Nothing, Nothing)
    End Sub


    Sub Genera_cargo_auto_pago_extempo(ByVal Periodo_ID As Integer, ByVal Socio_ID As Integer, ByVal factura As Integer)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Genera_Cargo_Pago_extraOrdinario", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    Dim usuario As New Datos.Users

                    comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = usuario.pUsuario_conectado
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    comm.Parameters.Add("@Factura_Genero_cargo", SqlDbType.Int).Value = factura
                    comm.Parameters.Add("@Periodo_Consultado", SqlDbType.Int).Value = Periodo_ID

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    MsgBox(dr(0))
                    'MsgBox("La facturación de los cargos por facturas vencidas se ha realizado satisfactoriamente.")
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
        End Try
    End Sub


    Private Sub btnCambia_periodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambia_periodo.Click
        'Mostrará una lista de períodos para seleccionar, y así mostrar las facturas que están de períodos anteriores.
        frmPeriodosConFactsVencidas.Show()
    End Sub

End Class