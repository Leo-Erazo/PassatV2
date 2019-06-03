Imports System.Data.SqlClient

Public Class frmReporte_mvtos_cta_ahorro
    Dim instancia As New Datos.Users
    Private Sub frmReporte_mvtos_cta_ahorro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCuenta_ahorro.Focus()
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Dim fecha_ini, Fecha_fin As Date
        fecha_ini = Me.dtpIni.Value.ToShortDateString & " 00:00:01"
        Fecha_fin = Me.dtpFin.Value.ToShortDateString & " 23:59:59"

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Mvtos_Cuenta_Ahorro", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Fecha_Ini", SqlDbType.DateTime).Value = fecha_ini
                    comm.Parameters.Add("@Fecha_Fin", SqlDbType.DateTime).Value = Fecha_fin
                    comm.Parameters.Add("@Cuenta_num", SqlDbType.Int).Value = CType(Me.txtCuenta_ahorro.Text, Integer)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvMvtos.DataSource = tabla
                    Me.dgvMvtos.Columns(4).DefaultCellStyle.Format = "c"
                    Me.dgvMvtos.Columns(5).DefaultCellStyle.Format = "c"
                    Me.dgvMvtos.Columns(6).DefaultCellStyle.Format = "c"
                    Me.dgvMvtos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvMvtos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dgvMvtos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    tabla = Nothing
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class