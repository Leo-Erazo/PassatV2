Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Strings
Imports Passat_H2O.Datos

Public Class frmAbono_Cuenta_Ahorro
    Public Socio_ID As Integer = 0
    Public Nombre As String = String.Empty
    Public Cuenta_ahorro As Integer = 0
    Dim Importe As Double = 0
    Dim Fecha_real As Date
    Dim Instancia As New Datos.Users

    Private Sub frmAbono_Cuenta_Ahorro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Activated
        Me.MdiParent = My.Forms.frmPrincipal
        Me.lblCuenta_num.Text = Cuenta_ahorro
        Me.lblSocio_ID.Text = Socio_ID
        Me.lblnombre.Text = Nombre
        Carga_Modalidad_pago()
        Me.txtImporte.Focus()
    End Sub


    Sub Carga_Modalidad_pago()
        Try
            Dim Modalidad As New List(Of Modalidad_pago)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0 Modo_ID , 'Seleccione modalidad' Descripcion UNION Select Modo_ID, Descripcion From Modalidad_Pago", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Modalidad_pago
                        lista.pModalidad_ID = items(0)
                        lista.pModalidad_Desc = items(1)
                        Modalidad.Add(lista)
                    End While

                    Me.cmbModalidad.DataSource = Modalidad
                    Me.cmbModalidad.ValueMember = "pModalidad_ID"
                    Me.cmbModalidad.DisplayMember = "pModalidad_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try

    End Sub


    Private Sub txtImporte_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.Leave
        Try
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

    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buscar.Click
        If My.Forms.frmCuentas_ahorro_socios.Visible Then
            My.Forms.frmCuentas_ahorro_socios.BringToFront()
        Else
            My.Forms.frmCuentas_ahorro_socios.Show()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim pModalidad_ID As Int16
        Dim pBanco, pReferencia_num As String

        Try
            Try
                Me.Fecha_real = Me.dtpFechaAbono.Value
                If Me.cmbModalidad.SelectedValue = 0 Then
                    MsgBox("Seleccione una modalidad de pago.")
                    Me.cmbModalidad.Focus()
                    Exit Sub
                Else
                    pModalidad_ID = Me.cmbModalidad.SelectedValue
                End If

                pBanco = Me.txtBanco.Text
                pReferencia_num = Me.txtReferencia.Text

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                Exit Sub
            End Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Inserta_Abono_Cuenta_Ahorro", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    comm.Parameters.Add("@Cuenta_num", SqlDbType.Int).Value = Cuenta_ahorro
                    comm.Parameters.Add("@Importe_abono", SqlDbType.Decimal, 2).Value = Importe
                    'Dim usuario As New Datos.Usuario_sistema

                    comm.Parameters.Add("@Usuario_ID", SqlDbType.Int).Value = Instancia.pUsuario_conectado
                    comm.Parameters.Add("@Fecha_Real", SqlDbType.DateTime).Value = Me.Fecha_real
                    comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar, 500).Value = Me.txtAnotaciones.Text

                    comm.Parameters.Add("@Modalidad_abono", SqlDbType.Int).Value = pModalidad_ID
                    comm.Parameters.Add("@Banco", SqlDbType.VarChar, 50).Value = pBanco
                    comm.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = pReferencia_num

                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    dr.Read()
                    Dim Transac_Num As Int64
                    Transac_Num = dr(0)

                    MsgBox("Abono aplicado satisfactoriamente.", MsgBoxStyle.Information, "Pasat H2O")


                    My.Forms.frmReciboCtaAhorro.Transac_Num = Transac_Num
                    My.Forms.frmReciboCtaAhorro.Cta_num = Cuenta_ahorro
                    My.Forms.frmReciboCtaAhorro.Show()

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