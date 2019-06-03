Public Class frmRe_Imprime_Factura_Manual

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            My.Forms.frmImprime_factura_manual.Tag = CType(Me.txtFactura_num.Text, Integer)
        Catch ex As Exception
            MsgBox("Verifique el número de la factura sea correcto.", MsgBoxStyle.Exclamation, "Pasat H2O")
            Exit Sub
        End Try

        My.Forms.frmImprime_factura_manual.Show()
    End Sub

    Private Sub frmRe_Imprime_Factura_Manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
        Me.txtFactura_num.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class