Imports Passat_H2O.Datos
Imports System.Data.SqlClient

Public Class frmCuentas_auto_pago
    Dim instancia As New Datos.Users

    Private Sub frmCuentas_auto_pago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("SELECT Socio_ID, Cuenta, Saldo_actual FROM Cuenta_Ahorro CA WHERE Saldo_actual > 0", conn)
                    comm.CommandType = CommandType.Text
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvCuentas.DataSource = tabla
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim i As Integer = 0
        Dim Socio_Id As Integer = 0
        Dim Cuenta_num As Integer = 0

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                For i = 0 To Me.dgvCuentas.Rows.Count - 1
                    Socio_Id = Me.dgvCuentas.Item(0, i).Value
                    Cuenta_num = Me.dgvCuentas.Item(1, i).Value 'Cuenta de ahorro

                    Using comm As New SqlCommand("sp_Servicios_auto_pago", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        comm.Parameters.Add("@Socio_id", SqlDbType.Int).Value = Socio_Id
                        Dim dr As SqlDataReader = comm.ExecuteReader
                        Dim tabla As New DataTable
                        tabla.Load(dr, LoadOption.OverwriteChanges)

                        Me.dgvServicios.DataSource = tabla
                        Me.dgvServicios.Refresh()


                        Dim factura_Num As Integer = 0
                        Dim j As Integer = 0

                        If Me.dgvServicios.Rows.Count > 0 Then
                            factura_Num = Me.dgvServicios.Item(1, 0).Value


                            For j = 0 To Me.dgvServicios.Rows.Count - 1
                                'Iterando sobre los servicios para aplicar el abono al mismo, y el cargo a la cuenta de ahorro
                                Dim servicio_id As Integer = 0

                                servicio_id = Me.dgvServicios.Item(5, j).Value

                                Using comm_servicios As New SqlCommand("sp_Genera_autoPago_servicio", conn)
                                    comm_servicios.CommandType = CommandType.StoredProcedure
                                    comm_servicios.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_Id
                                    comm_servicios.Parameters.Add("@Cuenta_num", SqlDbType.Int).Value = Cuenta_num
                                    comm_servicios.Parameters.Add("@factura_num", SqlDbType.Int).Value = factura_Num
                                    comm_servicios.Parameters.Add("@Servicio_id", SqlDbType.Int).Value = servicio_id
                                    Dim dar As SqlDataReader = comm_servicios.ExecuteReader
                                    dar.Read()

                                    dar.Close()

                                End Using
                            Next


                            'comm.Dispose()

                            'Verificar en este punto si la factura sigue con saldos: 'Pago parcial' o no: "Pagada"
                            Using comm_encabezados As New SqlCommand("sp_Actualiza_encabezado_Fact_AutoPago", conn)
                                comm_encabezados.CommandType = CommandType.StoredProcedure
                                comm_encabezados.Parameters.Add("@Factura_num", SqlDbType.Int).Value = factura_Num

                                Dim dr_encabezado As SqlDataReader = comm_encabezados.ExecuteReader

                                dr_encabezado.Read()
                                'MsgBox(dr_encabezado(0))
                                dr_encabezado.Close()

                            End Using

                        End If
                    End Using
                    Me.dgvServicios.DataSource = Nothing
                Next
                MsgBox("El auto pago con fondos de la cuenta de pagos anticipados han sido efectuadas")
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class