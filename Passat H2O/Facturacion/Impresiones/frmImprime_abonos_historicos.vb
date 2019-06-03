Imports System.Data.SqlClient
Imports Passat_H2O.Datos


Public Class frmImprime_abonos_historicos
    Dim oRpt As New rptAbonos_historicos

    Dim instancia As New Datos.Users
    Dim Sector_ As Integer
    Dim bloque_ As String
    Dim Socio_ID_ As Integer
    Dim Fecha_ini As Date
    Dim Fecha_fin As Date

    Private Sub frmImprime_abonos_historicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        If Asignacion_variables() = True Then
            Carga_grid()
        End If

    End Sub

    Function Asignacion_variables() As Boolean
        Me.Sector_ = My.Forms.frmReporte_pagos_socio.cmbSector.SelectedValue
        Me.bloque_ = My.Forms.frmReporte_pagos_socio.cmbBloque.SelectedValue

        If Me.bloque_ = CType(0, String) Then Me.bloque_ = ""


        If My.Forms.frmReporte_pagos_socio.txtSocio_ID.Text = String.Empty Then
            Me.Socio_ID_ = 0
        Else
            Me.Socio_ID_ = CType(My.Forms.frmReporte_pagos_socio.txtSocio_ID.Text, Integer)
        End If

        Me.Fecha_ini = My.Forms.frmReporte_pagos_socio.dtpFecha_ini.Value.ToShortDateString & " 00:00:01"
        Me.Fecha_fin = My.Forms.frmReporte_pagos_socio.dtpFecha_fin.Value.ToShortDateString & " 23:59:59"

        Return True

    End Function

    Sub Carga_grid()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_abonos_socios", conn)
                    comm.CommandType = CommandType.StoredProcedure
                    If Me.Sector_ <> 0 Then
                        comm.Parameters.Add("@Sector_ID", SqlDbType.Int).Value = Me.Sector_
                    End If

                    If Me.bloque_ <> Nothing Then
                        comm.Parameters.Add("@Bloque_ID", SqlDbType.VarChar, 4).Value = Me.bloque_
                    End If

                    If Me.Socio_ID_ <> 0 Then
                        comm.Parameters.Add("@Socio_ID", SqlDbType.Int).Value = Me.Socio_ID_
                    End If

                    comm.Parameters.Add("@Fecha_ini", SqlDbType.DateTime).Value = Me.Fecha_ini
                    comm.Parameters.Add("@Fecha_fin", SqlDbType.DateTime).Value = Me.Fecha_fin

                    Dim adapter As New SqlDataAdapter(comm)
                    Dim ds As New DataSet
                    adapter.Fill(ds, "Abonos_historicos")

                    oRpt.SetDataSource(ds)
                    Me.CryAbonos_historicos.ReportSource = oRpt
                    Me.CryAbonos_historicos.Zoom(85)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class