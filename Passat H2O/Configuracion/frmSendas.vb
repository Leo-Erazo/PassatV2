Imports Passat_H2O.Datos
Imports System.Data.SqlClient

Public Class frmSendas
    Dim instancia As New Datos.Users
    Dim grid As New Formatos
    Dim modo_apertura As String

    Private Sub frmSendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select Senda_ID as [Senda ID], Senda_Desc as [Nombre de la Senda] From Sendas", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvSendas.DataSource = tabla
                    grid.Formatea_grid(Me.dgvSendas)
                    Me.dgvSendas.Columns(0).Width = 80
                    dr.Close()
                End Using
            End Using
            Me.MdiParent = My.Forms.frmPrincipal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Desactiva_controles(False)
        Me.txtSenda_nombre.Focus()
        Me.modo_apertura = "Nuevo"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Desactiva_controles(True)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtSenda_nombre.Text = String.Empty Then Exit Sub
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                If Me.modo_apertura = "Nuevo" Then
                    Using comm As New SqlCommand(String.Format("Insert INTO Sendas VALUES ('{0}')", Me.txtSenda_nombre.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                Else
                    Using comm As New SqlCommand(String.Format("UPDATE Sendas SET Senda_desc = '{0}' WHERE Senda_ID = '{1}'", Me.txtSenda_nombre.Text, Me.txtSenda_id.Text), conn)
                        comm.ExecuteNonQuery()
                    End Using
                End If

            End Using

            Desactiva_controles(True)
            frmSendas_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Me.dgvSendas.Rows.Count = 0 Then Exit Sub
        Desactiva_controles(False)
        Me.txtSenda_id.Text = Me.dgvSendas.SelectedCells(0).Value.ToString
        Me.txtSenda_nombre.Text = Me.dgvSendas.SelectedCells(1).Value.ToString
        Me.modo_apertura = "Edición"
    End Sub

    Sub Desactiva_controles(ByVal bandera As Boolean)
        Me.Panel1.Visible = bandera
        Me.btnEditar.Enabled = bandera
        Me.btnEliminar.Enabled = bandera
        Me.Panel1.Visible = Not bandera
    End Sub
End Class