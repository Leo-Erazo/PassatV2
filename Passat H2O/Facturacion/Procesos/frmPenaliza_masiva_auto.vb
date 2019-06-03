Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmPenaliza_masiva_auto
    Dim instancia As New Datos.Users

    Private Sub frmPenaliza_masiva_auto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("sp_lista_facturas_vencidas_pdte_cargo", conn)
                comm.CommandType = CommandType.Text
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(comm)
                da.Fill(ds, 0)
                Me.dgvFacturas_Vencidas.DataSource = ds.Tables(0)

            End Using
        End Using

        Dim i As Integer = 0
        Dim Socio_id As Integer = 0
        Dim Periodo_id As Integer = 0
        Dim Factura_num As Integer = 0

        Me.tsProgressBar.Maximum = Me.dgvFacturas_Vencidas.Rows.Count - 1
        Try
            For i = 0 To Me.dgvFacturas_Vencidas.Rows.Count - 1
                Periodo_id = Me.dgvFacturas_Vencidas.Item(0, i).Value
                Socio_id = Me.dgvFacturas_Vencidas.Item(1, i).Value
                Factura_num = Me.dgvFacturas_Vencidas.Item(2, i).Value

                Me.Genera_cargo_auto_pago_extempo(Periodo_id, Socio_id, Factura_num)

                Me.dgvFacturas_Vencidas.RowsDefaultCellStyle.ForeColor = Color.Red
                Me.tsProgressBar.Value = i
            Next
            MsgBox("Penalizaciones aplicadas. Se cobrarán en la factura del período que está por abrir", MsgBoxStyle.Information, "Passat")
            'Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        

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

                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    dr.Read()


                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
        End Try
    End Sub
End Class