Imports System.Data.SqlClient
Imports Passat_H2O.Datos.Users

Public Class frmAnula_abono_servicios
    Dim instancia As New Datos.Users
    Public Transac_num As Integer = 0
    Public Factura_num As Integer = 0

    Private Sub frmAnula_abono_servicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = My.Forms.frmPrincipal

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Anula_Servicio_Abono", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Transac_num", SqlDbType.Int).Value = Transac_num
                    comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = Factura_num
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvServicios.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using

            If Me.dgvServicios.Rows.Count > 0 Then
                If Me.anula_Servicio() = False Then
                    MsgBox("Al menos un rubro de la factura dio error. Revise el resultado.", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("El abono fue anulado satisfactoriamente", MsgBoxStyle.Information)
                End If

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Function anula_Servicio() As Boolean

        Try
            Dim flag As Boolean = True
            Dim i As Integer = 0
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()

                For i = 0 To Me.dgvServicios.Rows.Count - 1
                    If Me.dgvServicios.Item(4, i).Value = "Anulado" Then
                        MsgBox("Este abono ya fue anulado previamente.")
                        'Exit Sub

                    End If

                    Dim Servicio_ID As Integer = Me.dgvServicios.Item(2, i).Value
                    Using comm As New SqlCommand("sp_Anula_abono", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        comm.Parameters.Add("@Transac_Num", SqlDbType.Int).Value = Transac_num
                        comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = Factura_num
                        comm.Parameters.Add("@Servicio_Id", SqlDbType.Int).Value = Servicio_ID
                        Dim dr As SqlDataReader = comm.ExecuteReader
                        dr.Read()

                        If dr(0).ToString <> "Exito!" Then
                            MsgBox(dr(0))
                            flag = False
                        End If

                        dr.Close()
                    End Using

                Next
                Me.Close()
            End Using

            Return flag

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

End Class