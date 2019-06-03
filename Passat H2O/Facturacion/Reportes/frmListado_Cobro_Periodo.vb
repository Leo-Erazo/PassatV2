Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmListado_Cobro_Periodo
    Dim instancia As New Datos.Users
    Dim periodo As String = ""

    Function Verifica_existe_periodo(ByVal Periodo As String) As Boolean
        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Estado From periodos WHERE PeriodoID = '{0}'", Periodo), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            If dr(0).ToString = "Activo" Then
                                Return True
                            Else
                                MsgBox("Aunque el período está ya definido, no es el período activo. " & vbCrLf & "Aceptar para continuar.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                                Return False 'Existe pero está Cerrado o Activo
                            End If
                        End If

                    Catch ex As Exception
                        MsgBox("El período no se ha podido verificar! " & ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function

    Sub Carga_lista_existente(ByVal Periodo As String)
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(("sp_Lista_Cobros_Facturados_Mes"), conn)
                    comm.CommandType = CommandType.StoredProcedure
                    comm.Parameters.Add("@Periodo_ID", SqlDbType.VarChar, 6).Value = Periodo
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim tabla As New DataTable
                    tabla.Load(dr, LoadOption.OverwriteChanges)
                    Me.dgvDetalle.DataSource = tabla
                    tabla = Nothing
                    Me.lblLineas.Text = Me.dgvDetalle.Rows.Count
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub


    Private Sub frmListado_Cobro_Periodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Width = Me.MdiParent.Width * 0.75
        Me.Height = Me.MdiParent.Height * 0.75

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        periodo = Me.txtPeriodo_ID.Text
        If Verifica_existe_periodo(periodo) = True Then
            Carga_lista_existente(periodo)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCrystal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystal.Click
        My.Forms.frmImprime_Listado_gral_cobros.Periodo_ID_ = periodo
        My.Forms.frmImprime_Listado_gral_cobros.Show()
    End Sub

    Private Sub bntSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
End Class