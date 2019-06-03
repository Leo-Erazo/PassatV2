Imports System.Data.SqlClient
Imports Passat_H2O.Datos
Imports System.Windows.Forms
'Imports Passat_H2O.frmImprime_Toma_lecturas

Public Class frmImprime_Toma_lecturas
    Dim oRpt As New rptLista_Toma_lecturas
    Dim instancia As New Datos.Users


    Private Sub frmImprime_Toma_lecturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal

        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("sp_Lista_Toma_lecturas_filtrado", conn)
                    comm.CommandType = CommandType.StoredProcedure

                    If My.Forms.frmToma_lectura.cmbSector.SelectedIndex = 0 Then
                        comm.Parameters.Add("@Sector", SqlDbType.Int).Value = 0
                    Else
                        comm.Parameters.Add("@Sector", SqlDbType.Int).Value = My.Forms.frmToma_lectura.cmbSector.SelectedValue
                    End If

                    If My.Forms.frmToma_lectura.cmbBloque.SelectedIndex = 0 Then
                        comm.Parameters.Add("@Bloque", SqlDbType.VarChar, 6).Value = ""
                    Else
                        comm.Parameters.Add("@Bloque", SqlDbType.VarChar, 6).Value = My.Forms.frmToma_lectura.cmbBloque.SelectedValue
                    End If
                    comm.Parameters.Add("@Periodo", SqlDbType.VarChar, 6).Value = My.Forms.frmToma_lectura.txtPeriodo_ID.Text

                    Dim da As New SqlDataAdapter(comm)

                    Dim ds As New DataSet
                    da.Fill(ds, "Listado_lectura")
                    oRpt.SetDataSource(ds)
                    Me.CryToma_lecturas.ReportSource = oRpt
                    Me.CryToma_lecturas.Zoom(85)

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class