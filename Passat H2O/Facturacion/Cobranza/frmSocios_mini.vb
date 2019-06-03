Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms

Public Class frmSocios_mini
    Dim instancia As New Datos.Users
    Private Sub frmSocios_mini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_Listado("")
    End Sub

    Sub Carga_Listado(ByVal nombre As String)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Socios_para_facturar", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Propietario", SqlDbType.VarChar, 50).Value = Nombre
                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSocios.DataSource = tabla
                    tabla = Nothing
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub dgvSocios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSocios.CellDoubleClick
        If Me.dgvSocios.Rows.Count = 0 Then Exit Sub
        Try
            My.Forms.frmCuentas_ahorro_crear.txtSocioID.Text = Me.dgvSocios.SelectedCells(0).Value
            My.Forms.frmCuentas_ahorro_crear.txtTitular.Text = Me.dgvSocios.SelectedCells(1).Value
            My.Forms.frmCuentas_ahorro_crear.txtImporte.Focus()
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al seleccionar el asociado", MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
        
    End Sub

    Private Sub txtSocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        Carga_Listado(Me.txtNombre.Text)
    End Sub
End Class