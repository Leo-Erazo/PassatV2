Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmConstantes
    Dim instancia As New Datos.Users

    Private Sub Constantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand("Select * From Constantes Where Constante_nom = 'Consumo_porcentual'", conn)
                comm.CommandType = CommandType.Text
                Dim dr As SqlDataReader
                dr = comm.ExecuteReader
                dr.Read()
                Me.nupVariacion.Value = dr(2)
                dr.Close()
            End Using

            Using comm As New SqlCommand("Select * From Constantes Where Constante_nom = 'Facturas_corte_Servicio'", conn)
                comm.CommandType = CommandType.Text
                Dim dr As SqlDataReader
                dr = comm.ExecuteReader
                dr.Read()
                Me.nupFacturas.Value = dr(2)
                dr.Close()
            End Using

        End Using

        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Using conn As New SqlConnection(instancia.pCadena_conexion)
            conn.Open()
            Using comm As New SqlCommand(String.Format("Update Constantes set Valor = {0} WHERE Constante_nom = 'Facturas_corte_Servicio'", Me.nupFacturas.Value), conn)
                comm.CommandType = CommandType.Text
                Try
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("No ha sido posible actualizar las constantes. " & ex.Message)
                    Me.Close()
                End Try
            End Using


            Using comm As New SqlCommand(String.Format("Update Constantes set Valor = {0} WHERE Constante_nom = 'Consumo_porcentual'", Me.nupVariacion.Value), conn)
                comm.CommandType = CommandType.Text
                Try
                    comm.ExecuteNonQuery()
                    MsgBox("Constantes actualizadas!.")
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No ha sido posible actualizar las constantes. " & ex.Message)
                End Try
            End Using

        End Using
    End Sub
End Class