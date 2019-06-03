Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmReporte_pagos_socio
    Dim instancia As New Datos.Users
    Dim Sector_ As Integer
    Dim bloque_ As String
    Dim Socio_ID_ As Integer
    Dim Fecha_ini As Date
    Dim Fecha_fin As Date


    Private Sub frmReporte_pagos_socio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carga_combos_Sector()
        Carga_combos_Bloques()
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Width = Me.MdiParent.Width * 0.75
        Me.Height = Me.MdiParent.Height * 0.75

    End Sub

    Sub Carga_combos_Sector()
        Try
            Dim Sectores As New List(Of Sectores)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Seleccione Sector' UNION Select Sector_ID, Sector_Desc From Sectores", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    'dr.Read()
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Sectores
                        lista.pSectorID = items(0)
                        lista.pSector_Desc = items(1)
                        Sectores.Add(lista)
                    End While

                    Me.cmbSector.DataSource = Sectores
                    Me.cmbSector.ValueMember = "pSectorID"
                    Me.cmbSector.DisplayMember = "pSector_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques()
        Try
            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques", conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_combos_Bloques(ByVal Sector As Integer)
        Try
            Dim Bloques As New List(Of Bloques)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select '0', 'Seleccione Bloque' UNION Select Bloque_ID, Bloque_Desc From Bloques WHERE Sector_ID = '{0}'", Me.cmbSector.SelectedValue), conn)
                    Dim dr As SqlDataReader = comm.ExecuteReader
                    Dim items(2) As Object
                    While dr.Read
                        dr.GetValues(items)
                        Dim lista As New Bloques
                        lista.pBloqueID = items(0)
                        lista.pBloque_Desc = items(1)
                        Bloques.Add(lista)
                    End While
                    Me.cmbBloque.DataSource = Bloques
                    Me.cmbBloque.ValueMember = "pBloqueID"
                    Me.cmbBloque.DisplayMember = "pBloque_Desc"
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Carga_grid()
        Try
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Try
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

                        Dim dr As SqlDataReader = comm.ExecuteReader()
                        Dim tabla As New DataTable
                        tabla.Load(dr, LoadOption.OverwriteChanges)
                        Me.dgvAbonos.DataSource = tabla
                        If Me.dgvAbonos.Rows.Count > 0 Then
                            Me.dgvAbonos.Columns(5).DefaultCellStyle.Format = "c"
                            Me.dgvAbonos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If


                        tabla = Nothing
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Sub Suma_Abonos()
        Dim Suma As Double = 0
        Dim lineas As Integer = 0

        Dim i As Integer
        If Me.dgvAbonos.Rows.Count = 0 Then
            Exit Sub
        End If


        For i = 0 To Me.dgvAbonos.Rows.Count - 1
            Suma += CType(Me.dgvAbonos.Item(5, i).Value, Double)
        Next

        Me.lblLineas.Text = Me.dgvAbonos.Rows.Count
        Me.lblSumas.Text = Suma
    End Sub

    Function Asignacion_variables() As Boolean

        Me.Sector_ = Me.cmbSector.SelectedValue
        Me.bloque_ = Me.cmbBloque.SelectedValue

        If Me.bloque_ = CType(0, String) Then Me.bloque_ = ""
        If Me.txtSocio_ID.Text <> String.Empty Then
            Try
                Me.Socio_ID_ = Me.txtSocio_ID.Text
            Catch ex As Exception
                MsgBox("La cuenta del socio tiene que ser un número entero. Verifique por favor", MsgBoxStyle.Information, "Pasat H2O")
                Me.Socio_ID_ = 0
                Return False
            End Try
        Else
            Me.Socio_ID_ = 0
        End If

        Me.Fecha_ini = Me.dtpFecha_ini.Value.ToShortDateString & " 00:00:01"
        Me.Fecha_fin = Me.dtpFecha_fin.Value.ToShortDateString & " 23:59:59"

        Return True

    End Function

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        'Si se digita una cuenta de usuario, se desactivan los combos del sector y de los bloques
        If Asignacion_variables() = True Then
            Carga_grid()
            Suma_Abonos()
        End If
    End Sub

    Private Sub dgvAbonos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAbonos.CellDoubleClick
        Me.txtSocio_ID.Text = Me.dgvAbonos.SelectedCells(2).Value
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnReimprime_recibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReimprime_recibo.Click
        If Me.dgvAbonos.Rows.Count = 0 Then Exit Sub
        Try
            My.Forms.frmImprime_Recibo.Transac_Num = CType(Me.dgvAbonos.SelectedCells(0).Value, Integer)
            My.Forms.frmImprime_Recibo.Factura_num = CType(Me.dgvAbonos.SelectedCells(1).Value, Integer)
            My.Forms.frmImprime_Recibo.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        My.Forms.frmImprime_abonos_historicos.Show()
    End Sub
End Class