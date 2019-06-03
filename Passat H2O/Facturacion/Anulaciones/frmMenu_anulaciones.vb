Public Class frmMenu_anulaciones

    Private Sub frmMenu_anulaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = My.Forms.frmPrincipal
    End Sub

    Private Sub btnAnula_abono_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnula_abono_factura.Click
        If My.Forms.frmFacturas_listado.Visible = True Then
            My.Forms.frmFacturas_listado.BringToFront()
        Else
            My.Forms.frmFacturas_listado.Show()
        End If

        If My.Forms.frmAnula_abono_factura.Visible = True Then
            My.Forms.frmAnula_abono_factura.BringToFront()
        Else
            My.Forms.frmAnula_abono_factura.Show()
        End If

    End Sub


    Private Sub btnAnula_penalizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnula_penalizacion.Click

        If My.Forms.frmAnula_penalidad.Visible = True Then
            My.Forms.frmAnula_penalidad.BringToFront()
        Else
            My.Forms.frmAnula_penalidad.Show()
        End If

    End Sub

    Private Sub btnAnular_extraordinaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular_extraordinaria.Click
        If My.Forms.frmAnula_extraordinaria.Visible = True Then
            My.Forms.frmAnula_extraordinaria.BringToFront()
        Else
            My.Forms.frmAnula_extraordinaria.Show()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class