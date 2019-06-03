Imports System.Data
Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmCuentas_ahorro_crear
    Dim Instancia As New Datos.Users
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        My.Forms.frmSocios_mini.Show()
    End Sub

    Private Sub frmCuentas_ahorro_crear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Carga_Modalidad_pago()
        Me.txtSocioID.Focus()
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



    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Verifica_controles() = False Then Exit Sub
        Guarda_cuenta(CType(Me.txtSocioID.Text, Integer), CType(Me.txtImporte.Text, Double))
    End Sub

    Sub Guarda_cuenta(ByVal Socio_ID As Integer, ByVal Importe As Double)
        Dim pModalidad_ID As Int16
        Dim pBanco, pReferencia_num As String

        Try

            If Me.cmbModalidad.SelectedValue = 0 Then
                MsgBox("Seleccione una modalidad de pago.")
                Me.cmbModalidad.Focus()
                Exit Sub
            Else
                pModalidad_ID = Me.cmbModalidad.SelectedValue
            End If

            pBanco = Me.txtBanco.Text
            pReferencia_num = Me.txtReferencia.Text
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Guarda_Cta_Ahorro", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@User", SqlDbType.Int).Value = Instancia.pUsuario_conectado
                    comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Socio_ID
                    comm.Parameters.Add("@Abono_importe", SqlDbType.Decimal, 2).Value = Importe
                    comm.Parameters.Add("@Anotaciones", SqlDbType.VarChar, 500).Value = Me.txtAnotaciones.Text

                    comm.Parameters.Add("@Modalidad_abono", SqlDbType.Int).Value = pModalidad_ID
                    comm.Parameters.Add("@Banco", SqlDbType.VarChar, 50).Value = pBanco
                    comm.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = pReferencia_num

                    Dim dr As SqlDataReader = comm.ExecuteReader()
                    dr.Read()
                    If dr.HasRows Then
                        Dim valores(2) As Object

                        dr.GetValues(valores)

                        Dim Transac_Num, Cuenta_ahorro As Int64
                        Transac_Num = valores(0)
                        Cuenta_ahorro = valores(1)

                        MsgBox("Transacción generada satisfactoriamente.", MsgBoxStyle.Information, "Pasat H2O")


                        My.Forms.frmReciboCtaAhorro.Transac_Num = Transac_Num
                        My.Forms.frmReciboCtaAhorro.Cta_num = Cuenta_ahorro
                        My.Forms.frmReciboCtaAhorro.Show()
                    Else
                        MsgBox("Recuerde que el cliente sólo puede tener UNA cuenta para pagos anticipados", MsgBoxStyle.Information, "Passat H2O")
                    End If
                    
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al crear la cuenta de fondos del asociado. Recuerde que el cliente sólo puede tener UNA cuenta para pagos anticipados. " & vbCrLf & "Si está seguro que el cliente no tiene cuenta para pagos anticipados, consulte con el administrador del sistema.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End Try
        Me.Close()
    End Sub

    Function Verifica_controles() As Boolean
        If Me.txtSocioID.Text = String.Empty Then Return False

        Dim importe As Double = 0
        Dim socio As Integer = 0

        Try
            socio = CType(Me.txtSocioID.Text, Integer)
        Catch ex As Exception
            MsgBox("Cuenta de asociado no válida", MsgBoxStyle.Exclamation, "Pasat H20")
            Return False
        End Try

        Try
            importe = CType(Me.txtImporte.Text, Double)
        Catch ex As Exception
            importe = 0
            MsgBox("Verifique el importe del abono", MsgBoxStyle.Exclamation, "Pasat H20")
            Me.txtImporte.Focus()
            Return False
        End Try

        Return True

    End Function

    Private Sub txtSocioID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSocioID.Leave
        If Me.txtSocioID.Text = String.Empty Then Exit Sub
        Dim Socio_ID As Integer

        Try
            Socio_ID = CType(Me.txtSocioID.Text, Integer)
        Catch ex As Exception
            Socio_ID = 0
            MsgBox("Verifique el número de la cuenta del asociado. Debe ser un número entero y positivo.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Me.txtSocioID.Focus()
            Exit Sub
        End Try

        Try
            Using conn As New SqlConnection(Instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Propietario From Socios WHERE Socio_ID = '{0}'", Socio_ID), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    dr.Read()
                    If dr.HasRows Then
                        Me.txtTitular.Text = dr(0)
                    Else
                        MsgBox("El número de la cuenta del asociado no es válida", MsgBoxStyle.Exclamation, "Pasat H2O")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Verifique el número de la cuenta del asociado. Debe ser un número entero y positivo.", MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub
End Class