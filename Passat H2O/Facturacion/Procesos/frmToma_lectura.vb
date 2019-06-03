Imports System
Imports System.Data.SqlClient
Imports Passat_H2O.Datos

Public Class frmToma_lectura
    Dim instancia As New Datos.Users
    Dim cargando As Boolean = True

    Private Sub frmToma_lectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carga_combos_Sector()
        Carga_combos_Bloques()
        Me.MdiParent = My.Forms.frmPrincipal
        Me.Height = Me.Parent.Height * 0.75
        cargando = False
    End Sub

    Private Sub btnPeriodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodos.Click
        If My.Forms.frmPeriodos.Visible = False Then
            My.Forms.frmPeriodos.formulario_invoca = Me.Name
            My.Forms.frmPeriodos.Show()
        End If
    End Sub

    Sub Carga_combos_Sector()
        Try
            Dim Sectores As New List(Of Sectores)
            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand("Select 0, 'Todos los Sectores' UNION Select Sector_ID, Sector_Desc From Sectores", conn)
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
                Using comm As New SqlCommand("Select '0', 'Todos los Bloques' UNION Select Bloque_ID, Bloque_Desc From Bloques", conn)
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
                Using comm As New SqlCommand(String.Format("Select '0', 'Todos los Bloques' UNION Select Bloque_ID, Bloque_Desc From Bloques WHERE Sector_ID = '{0}'", Me.cmbSector.SelectedValue), conn)
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

    Private Sub cmbSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSector.SelectedIndexChanged
        Try
            If cargando Then Exit Sub
            Me.Carga_combos_Bloques(Me.cmbSector.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
        End Try
    End Sub

    Private Sub btnListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListar.Click
        If Me.txtPeriodo_ID.Text = String.Empty Then
            MsgBox("Por favor indique el período para el que se hará la toma de lecturas de consumo", MsgBoxStyle.Information, "Pasat H2O")
            Exit Sub
        End If

        If Me.cmbSector.SelectedIndex <> -1 And Me.cmbSector.SelectedIndex <> -1 Then
            Try
                Using conn As New SqlConnection(instancia.pCadena_conexion)
                    conn.Open()
                    Using comm As New SqlCommand("sp_Lista_Toma_lecturas_filtrado", conn)
                        comm.CommandType = CommandType.StoredProcedure
                        If Me.cmbSector.SelectedIndex = 0 Then
                            comm.Parameters.Add("@Sector", SqlDbType.Int).Value = 0
                        Else
                            comm.Parameters.Add("@Sector", SqlDbType.Int).Value = Me.cmbSector.SelectedValue
                        End If

                        If Me.cmbBloque.SelectedIndex = 0 Then
                            comm.Parameters.Add("@Bloque", SqlDbType.VarChar, 6).Value = ""
                        Else
                            comm.Parameters.Add("@Bloque", SqlDbType.VarChar, 6).Value = Me.cmbBloque.SelectedValue
                        End If
                        comm.Parameters.Add("@Periodo", SqlDbType.VarChar, 6).Value = Me.txtPeriodo_ID.Text

                        Dim dr As SqlDataReader
                        dr = comm.ExecuteReader
                        Dim tabla As New DataTable
                        tabla.Load(dr, LoadOption.OverwriteChanges)
                        Me.dgvLectura.DataSource = tabla
                        dr.Close()
                        tabla = Nothing
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Passat H2O")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        My.Forms.frmImprime_Toma_lecturas.Show()
    End Sub

    Private Sub txtPeriodo_ID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeriodo_ID.Leave
        If Determina_Periodo_existe(Me.txtPeriodo_ID.Text) = True Then
            Me.btnListar.Enabled = True
            Me.btnImprimir.Enabled = True
        End If
    End Sub

    Function Determina_Periodo_existe(ByVal Periodo As String) As Boolean
        Try
            If Periodo = String.Empty Then
                MsgBox("Indique un período válido.", MsgBoxStyle.Exclamation, "Pasat H2O")
                Return False
            End If

            Using conn As New SqlConnection(instancia.pCadena_conexion)
                conn.Open()
                Using comm As New SqlCommand(String.Format("Select Estado From periodos WHERE PeriodoID = '{0}'", Me.txtPeriodo_ID.Text), conn)
                    Dim dr As SqlDataReader
                    dr = comm.ExecuteReader
                    Try
                        dr.Read()
                        If dr.HasRows Then
                            If dr(0).ToString = "Pasivo" Then
                                Return True
                            Else
                                MsgBox("Aunque el período está ya definido, tiene un estado no válido para tomar lecturas. Podrá verlo o generar el listado para impresión pero podría tener problemas en el módulo de captura de los datos.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pasat H2O")
                            End If
                            Me.btnImprimir.Enabled = True
                            Me.btnListar.Enabled = True
                        Else
                            MsgBox("Este período aún no ha sido definido. Primero debe crearlo en el módulo de períodos para poder crear el listado de toma de lecturas." & vbCrLf & vbCrLf & "Aceptar para continuar", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pasat H2O")
                            Me.btnImprimir.Enabled = False
                            Me.btnListar.Enabled = False
                            Return False 'No existe el período
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Pasat H2O")
        End Try
    End Function

    Private Sub txtPeriodo_ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeriodo_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnListar.Focus()
        End If
    End Sub
End Class