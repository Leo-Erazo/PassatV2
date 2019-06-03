Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmAnula_abono_factura
    Public Factura_num As Integer = 0
    Dim instancia As New Datos.Users

    Private Sub frmAnula_abono_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = My.Forms.frmPrincipal
            Me.txtFactura_num.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.txtFactura_num.Text <> Nothing Then
            Try
                Factura_num = Me.txtFactura_num.Text()
            Catch ex As Exception
                Factura_num = 0
                MsgBox("El número de la factura no es un valor válido!", MsgBoxStyle.Information, "Anulando abono a fatura.")
                Exit Sub
            End Try
        End If

        If Factura_num <> 0 Then
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_lista_abonos_para_anular", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Factura_num", SqlDbType.Int).Value = Factura_num

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim table As New DataTable

                    table.Load(dr, LoadOption.OverwriteChanges)
                    If table.Rows.Count = 0 Then
                        MsgBox("La factura aún no tiene abonos aplicados.", MsgBoxStyle.Information, "Anulación de abonos a factura.")
                        Me.Close()
                    Else
                        Me.btnAceptar.Enabled = True
                    End If

                    If table.Rows.Count > 0 Then
                        Me.dgvAbonos.DataSource = table
                    End If

                    Me.dgvAbonos.DefaultCellStyle.Font = New Font("Arial", 12)
                End Using
            End Using
        End If

    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnSelecciona_abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecciona_abono.Click
        Dim respuesta As Integer = 0

        If Me.dgvAbonos.Rows.Count = 0 Then
            MsgBox("No hay abonos que anular.", MsgBoxStyle.Exclamation, "Anular abono a factura")
            Exit Sub
        End If

        respuesta = MsgBox("La anulación no se puede revertir. Desea continuar con la anulación?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Anulando documento")
        If respuesta = 6 Then
            anula_abono()
        Else
            MsgBox("Proceso cancelado. No se anuló la factura.", MsgBoxStyle.Information)
        End If



    End Sub

    Sub anula_abono()
        Dim Transac_num, Factura_num, Importe As Integer
        Transac_num = Me.dgvAbonos.SelectedCells.Item(0).Value
        Factura_num = Me.dgvAbonos.SelectedCells.Item(1).Value
        Importe = Me.dgvAbonos.SelectedCells.Item(2).Value
        Try
            My.Forms.frmAnula_abono_servicios.Transac_num = Transac_num
            My.Forms.frmAnula_abono_servicios.Factura_num = Factura_num
            My.Forms.frmAnula_abono_servicios.Show()
            My.Forms.frmFacturas_listado.cargando = False
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class