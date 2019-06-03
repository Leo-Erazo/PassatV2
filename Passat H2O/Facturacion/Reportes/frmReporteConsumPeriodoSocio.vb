Imports System.Data.SqlClient
Imports System.Math

Public Class frmReporteConsumPeriodoSocio
    Dim instancia As New Datos.Users

    Private Sub frmReporteConsumPeriodoSocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.txtSocio_ID.Focus()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Sub Lista_consumos()

        Dim fecha_ini, Fecha_fin, Socio_ID As String

        Socio_ID = Me.txtSocio_ID.Text
        fecha_ini = Me.txtPeriodo_ini.Text
        Fecha_fin = Me.txtPeriodo_fin.Text

        'Try
        '    Socio_ID = CType(Me.txtSocio_ID.Text, Integer)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "iLeon Pasat H2O")
        'End Try


        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Consumo_metros_asociado", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    If fecha_ini <> Nothing Then
                        comm.Parameters.Add("@Periodo_ini", SqlDbType.Int).Value = fecha_ini
                    End If

                    If Fecha_fin <> Nothing Then
                        comm.Parameters.Add("@Periodo_fin", SqlDbType.Int).Value = Fecha_fin
                    End If

                    If Socio_ID <> Nothing Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    End If

                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvMetros.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Lista_consumos()
        Dim i As Integer = 0
        Dim sumas As Double = 0

        If Me.dgvMetros.Rows.Count > 0 Then
            For i = 0 To Me.dgvMetros.Rows.Count - 1
                sumas += Me.dgvMetros.Item(5, i).Value
            Next
            Me.lblPromedio.Text = round(sumas / (Me.dgvMetros.Rows.Count - 1), 0)
        Else
            Me.lblPromedio.Text = 0
        End If
        
    End Sub
End Class