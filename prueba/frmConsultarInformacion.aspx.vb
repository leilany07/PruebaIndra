Imports PruebaNegocios
Public Class frmConsultarInformacion
    Inherits System.Web.UI.Page
    Dim dt As DataTable = New DataTable
    Dim resMax As Long
    Dim resMin As Long
    Dim Usuario As String
    Dim objetoResultado As PruebaNegocios.Resultado = New PruebaNegocios.Resultado()
#Region "Propiedades"
    Private Property dtRes As DataTable
        Get
            Return ViewState("dtRes")
        End Get
        Set(value As DataTable)
            ViewState("dtRes") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                gvResultados.DataSource = New DataTable
                gvResultados.DataBind()
            End If

        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            'concultar las respuetas segun los parametros

            ' si todos son vacios entonces enviar mensaje y limpiar los campos
            If (txtResMaxima.Text.Trim = "" And txtResMini.Text.Trim = "" And txtUsuario.Text.Trim = "") Then
                limpiar()
                MsgBox("No se encontro resultado con los filtros ingresados")
                Exit Sub
            End If

            If (txtResMaxima.Text <> "") Then
                resMax = txtResMaxima.Text
            Else
                resMax = 0
            End If
            If (txtResMini.Text <> "") Then
                resMin = txtResMini.Text
            Else
                resMin = 0
            End If
            If (txtUsuario.Text <> "") Then
                Usuario = txtUsuario.Text
            End If


            If (resMax < resMin) Then
                MsgBox("No se puede realizar la consulta Respuesta minima no puede ser mayor  a respuesta maxima!!!")
                Exit Sub
            End If


            dtRes = objetoResultado.mostrarResultadosFiltroRespM(Usuario, resMin, resMax)
            If (dtRes.Rows.Count > 0) Then
                gvResultados.DataSource = dtRes
                gvResultados.DataBind()
            Else
                gvResultados.DataSource = New DataTable
                    gvResultados.DataBind()
                    MsgBox("No se encontro resultado con los filtros ingresados")
                    limpiar()
                    Exit Sub
                End If



        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub
    Sub limpiar()
        Try
            txtResMaxima.Text = ""
            txtResMini.Text = ""
            txtUsuario.Text = ""
        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub
    Private Sub gvResultados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvResultados.RowCommand
        Try

            Dim colsNoVisible = gvResultados.DataKeys(e.CommandArgument).Values
            Dim id As Integer
            Dim dias As Integer
            id = colsNoVisible.Values(0)
            Dim dtCopiaDtRes As DataTable = New DataTable
            If e.CommandName = "Eliminar" Then

                dtCopiaDtRes = dtRes.Select("Id = '" & colsNoVisible(0) & "'").CopyToDataTable

                If (dtCopiaDtRes.Rows.Count > 0) Then
                    'No se puede eliminar un registro si fue creado en menos de 30 dias sacar la fecha convertirla en dias
                    dias = Integer.Parse(dtCopiaDtRes.Rows(0).Item("dias").ToString())
                    If (dias > 30) Then
                        eliminar(id)
                        MsgBox("se elimino el resultado!!!")
                        'actualizar la tabla
                        dtRes = objetoResultado.mostrarResultadosFiltroRespM(Usuario, resMin, resMax)
                        If (dtRes.Rows.Count > 0) Then
                            gvResultados.DataSource = dtRes
                            gvResultados.DataBind()
                        Else
                            gvResultados.DataSource = New DataTable
                            gvResultados.DataBind()

                        End If
                    Else
                        MsgBox("Error no se puede eliminar registro. Por que es menor a 30 dias de creación")
                    End If

                End If


            End If
        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub
    Sub eliminar(id As Integer)
        Try
            objetoResultado.eliminar(id)
        Catch ex As Exception
            MsgBox("Error" + ex.Message)
        End Try
    End Sub




End Class