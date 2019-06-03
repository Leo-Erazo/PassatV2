Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Strings

Public Class frmCuentas_ahorro_socios
    Dim Instancia As New Datos.Users

    Private Sub frmCuentas_ahorro_socios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Activated
        Me.MdiParent = My.Forms.frmPrincipal
        Lista_cuentas(Nothing, 0)
        Me.txtNombre.Focus()
    End Sub

    

    Sub Lista_cuentas(ByVal Nombre As String, ByVal Socio_ID As Integer)
        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_cuentas_ahorro", conn)
                    comm.CommandType = CommandType.StoredProcedure

                    If Nombre <> Nothing Then
                        comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = Nombre
                    End If


                    If Socio_ID <> 0 Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    End If


                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvCuentas_ahorro.DataSource = tabla
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

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Dim socio_id As Integer = 0
        If Me.txtSocio_ID.Text <> Nothing Then
            Try
                socio_id = CInt(Me.txtSocio_ID.Text)
            Catch ex As Exception
                socio_id = 0
            End Try

        End If
        Lista_cuentas(Me.txtNombre.Text, socio_id)
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        Dim socio_id As Integer = 0
        If Me.txtSocio_ID.Text <> Nothing Then
            Try
                socio_id = CInt(Me.txtSocio_ID.Text)
            Catch ex As Exception
                socio_id = 0
            End Try

        End If
        Lista_cuentas(Me.txtNombre.Text, socio_id)
    End Sub

    Private Sub AplicarUnAbonoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicarUnAbonoToolStripMenuItem.Click
        If Me.dgvCuentas_ahorro.Rows.Count = 0 Then Exit Sub
        Try
            My.Forms.frmAbono_Cuenta_Ahorro.Socio_ID = Me.dgvCuentas_ahorro.SelectedCells(0).Value
            My.Forms.frmAbono_Cuenta_Ahorro.Nombre = Me.dgvCuentas_ahorro.SelectedCells(1).Value
            My.Forms.frmAbono_Cuenta_Ahorro.Cuenta_ahorro = Me.dgvCuentas_ahorro.SelectedCells(3).Value
            If My.Forms.frmAbono_Cuenta_Ahorro.Visible = True Then
                My.Forms.frmAbono_Cuenta_Ahorro.Activate()
                My.Forms.frmAbono_Cuenta_Ahorro.BringToFront()
            Else
                My.Forms.frmAbono_Cuenta_Ahorro.Show()
            End If
            'Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub VerMovimientosDeCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerMovimientosDeCuentaToolStripMenuItem.Click
        If Me.dgvCuentas_ahorro.Rows.Count = 0 Then Exit Sub
        Try
            My.Forms.frmReporte_mvtos_cta_ahorro.txtCuenta_ahorro.Text = Me.dgvCuentas_ahorro.SelectedCells(3).Value
            My.Forms.frmReporte_mvtos_cta_ahorro.txtSocio_ID.Text = Me.dgvCuentas_ahorro.SelectedCells(0).Value
            My.Forms.frmReporte_mvtos_cta_ahorro.txtNombre.Text = Me.dgvCuentas_ahorro.SelectedCells(1).Value
            If My.Forms.frmReporte_mvtos_cta_ahorro.Visible = True Then
                My.Forms.frmReporte_mvtos_cta_ahorro.BringToFront()
                My.Forms.frmReporte_mvtos_cta_ahorro.btnVer.PerformClick()
            Else
                My.Forms.frmReporte_mvtos_cta_ahorro.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNueva.Click
        My.Forms.frmCuentas_ahorro_crear.show()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim Cuenta_Num As Integer = 0
        Dim Resp As Integer = 0

        Try
            Cuenta_Num = Me.dgvCuentas_ahorro.SelectedCells(3).Value
            Resp = MsgBox("Está seguro de querer eliminar la cuenta de fondos del asociado seleccionada?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Pasat H2O")
            If Resp <> 1 Then
                Exit Sub
            Else
                'Borrar la cuenta
                Try
                    Using conn As New SqlConnection(Instancia.pCadena_conexion)
                        conn.Open()
                        Using comm As New SqlCommand("sp_delete_Cuenta_Fondos_Asociado", conn)
                            comm.CommandType = CommandType.StoredProcedure
                            comm.Parameters.Add("@Usuario", SqlDbType.Int).Value = Instancia.pUsuario_conectado
                            comm.Parameters.Add("@Cuenta_Num", SqlDbType.Int).Value = Cuenta_Num
                            Dim dr As SqlDataReader = comm.ExecuteReader
                            dr.Read()
                            If dr.HasRows Then
                                MsgBox("No es posible eliminar la cuenta porque ya tiene movimientos", MsgBoxStyle.Exclamation, "Pasat H2O")
                            Else
                                MsgBox("Cuenta eliminada.", MsgBoxStyle.Exclamation, "Pasat H2O")
                            End If
                        End Using
                    End Using
                    Lista_cuentas(Nothing, 0)
                Catch ex As Exception
                    MsgBox("Error al intentar borrar la cuenta de fondos del asociado." & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub RetirarFondosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetirarFondosToolStripMenuItem.Click
        If Me.dgvCuentas_ahorro.Rows.Count = 0 Then Exit Sub
        Try
            My.Forms.frmCargo_Cuenta_Ahorro.Socio_ID = Me.dgvCuentas_ahorro.SelectedCells(0).Value
            My.Forms.frmCargo_Cuenta_Ahorro.Nombre = Me.dgvCuentas_ahorro.SelectedCells(1).Value
            My.Forms.frmCargo_Cuenta_Ahorro.Cuenta_ahorro = Me.dgvCuentas_ahorro.SelectedCells(3).Value
            If My.Forms.frmCargo_Cuenta_Ahorro.Visible = True Then
                My.Forms.frmCargo_Cuenta_Ahorro.Activate()
                My.Forms.frmCargo_Cuenta_Ahorro.BringToFront()
            Else
                My.Forms.frmCargo_Cuenta_Ahorro.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub
End Class