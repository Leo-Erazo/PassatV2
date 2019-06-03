Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Strings


Public Class frmCargo_Cuenta_Ahorro
    Public Socio_ID As Integer = 0
    Public Nombre As String = String.Empty
    Public Cuenta_ahorro As Integer = 0
    Dim Importe As Double = 0
    Dim Fecha_real As Date
    Dim Instancia As New Datos.Users

    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buscar.Click
        If My.Forms.frmCuentas_ahorro_socios.Visible Then
            My.Forms.frmCuentas_ahorro_socios.BringToFront()
        Else
            My.Forms.frmCuentas_ahorro_socios.Show()
        End If
    End Sub

    Private Sub frmCargo_Cuenta_Ahorro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.lblCuenta_num.Text = Cuenta_ahorro
        Me.lblSocio_ID.Text = Socio_ID
        Me.lblnombre.Text = Nombre
        Me.txtImporte.Focus()
    End Sub

    Private Sub txtImporte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.Leave
        Try
            MsgBox("Que verifique que el cargo no sea superior al saldo")

            If Me.txtImporte.Text = String.Empty Then Me.txtImporte.Text = 0
            Importe = CType(Me.txtImporte.Text, Double)
            Me.btnGuardar.Enabled = True
        Catch ex As Exception
            MsgBox("Verifique el importe. Debe ser un valor mayor a cero", MsgBoxStyle.Exclamation, "Pasat H2O")
            Me.txtImporte.Focus()
            Me.btnGuardar.Enabled = False
            Exit Sub
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Try
                Me.Fecha_real = Me.dtpFechaCargo.Value
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                Exit Sub
            End Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Inserta_Cargo_Cuenta_Ahorro", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    comm.Parameters.Add("@Cuenta_num", SqlDbType.Int).Value = Cuenta_ahorro
                    comm.Parameters.Add("@Importe_cargo", SqlDbType.Decimal, 2).Value = -Importe
                    Dim usuario As New Datos.Usuario_sistema

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = Instancia.pUsuario_conectado
                    comm.Parameters.Add("@Fecha_Real", SqlDbType.DateTime).Value = Me.Fecha_real
                    comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar, 500).Value = Me.txtAnotaciones.Text

                    comm.ExecuteNonQuery()
                    MsgBox("Cargo aplicado satisfactoriamente.", MsgBoxStyle.Information, "Pasat H2O")
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class