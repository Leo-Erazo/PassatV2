Imports System.Data



Public Class Datos

    Shared Cadena_conexion As String = "initial catalog=pasat_h2o;user ID= ileon; password= ileon"
    Public Property pCadena_conexion() As String
        Get
            Return Cadena_conexion
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                MsgBox("No se ha definido la conexión a la base de datos. No podrá realizar ninguna transacción.", MsgBoxStyle.Information, "iCoop")
            Else
                Cadena_conexion = value
            End If
        End Set
    End Property

    Shared User_id As String
    Public Property pUser_ID() As String
        Get
            Return User_id
        End Get
        Set(ByVal value As String)
            User_id = value
        End Set
    End Property

End Class


Public Class Formatos
    Sub Formatea_grid(ByVal Grid As datagridview)
        With Grid
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowsDefaultCellStyle.BackColor = Color.Lavender
            .GridColor = Color.White
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue
            .RowsDefaultCellStyle.SelectionForeColor = Color.Black
        End With
    End Sub

End Class