Imports System.Data
Imports System.Data.SqlClient


Public Class frmListado_lecturas_encabezados
    Dim instancia As New Datos.Users

    Private Sub frmListado_lecturas_encabezados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Activated
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_lista()
    End Sub

    Sub Carga_lista()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Lecturas_consumo", conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvLista_lecturas.DataSource = tabla
                    tabla = Nothing
                    Me.lblLineas_mostradas.Text = Me.dgvLista_lecturas.Rows.Count
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEmitir_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmitir_facturas.Click
        Dim periodo As String
        Try
            periodo = Me.dgvLista_lecturas.SelectedCells(1).Value.ToString
            My.Forms.frmImprime_facturas.Tag = periodo.ToString
            My.Forms.frmImprime_facturas.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat")
        End Try
        
    End Sub

End Class