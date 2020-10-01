
Imports PruebaNegocios
Public Class _Default
    Inherits System.Web.UI.Page
    Dim objetoUsua As PruebaNegocios.Usuario = New PruebaNegocios.Usuario()
    Dim objetoResultado As PruebaNegocios.Resultado = New PruebaNegocios.Resultado()
    Dim WserUsuario As WsUsuario.WSbuscarUsuarioSoapClient = New WsUsuario.WSbuscarUsuarioSoapClient()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub



    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Try
            Dim resultado As Long = 0
            Dim limite As Long

            Dim dtuser As DataTable = New DataTable
            Dim dts As DataSet = New DataSet
            Dim user As String

            'web service
            dts = WserUsuario.WSlistadoUsuarioNombre(txtUsuario.Text.Trim)
            dtuser = dts.Tables(0)

            'clase de negocios
            'dtuser = objetoUsua.mostrarUsusarioNombre(txtUsuario.Text.Trim)

            If (dtuser.Rows.Count <= 0) Then
                txtLimi.Text = ""
                txtUsuario.Text = ""
                lblRes.Text = ""
                MsgBox("Error usuario invalido")
            Else
                'hacer los calculos y registrar en la tabla de resultados
                user = dtuser.Rows(0).Item("USUARIO").ToString().Trim()
                resultado = Long.Parse(txtLimi.Text.Trim)

                For i As Integer = 0 To (resultado - 1)

                    If (i Mod 3 = 0) Or (i Mod 5 = 0) Then
                        resultado += i
                    End If
                Next

                lblRes.Text = "Resultado: " & resultado

                objetoResultado.InsetarResultado(user, resultado)
                btnConsultarCalc.Visible = True
                MsgBox("Se registro la respuesta")
            End If

        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub

    Private Sub btnConsultarCalc_Click(sender As Object, e As EventArgs) Handles btnConsultarCalc.Click
        Try
            Response.Redirect("frmConsultarInformacion.aspx", False)
        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub
End Class