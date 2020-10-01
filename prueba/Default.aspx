<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="prueba._Default" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        select {
            background: #808080;
            border: none;
            font-size: 14px;
            height: 26px;
            padding: 2px;
            width: 117px;
        }

        .modal-dialog {
            right: auto;
            left: 69%;
            width: 763px;
            padding-top: 30px;
            padding-bottom: 30px;
            height: 240px;
        }

        .convenciones {
            /*text-align: center;*/
            /*width: 50px;*/
            padding-top: 5px;
            padding-left: 5px;
            padding-right: 5px;
            height: 25px;
            cursor: text;
            border: 0px !important;
        }

        .login-container .loginbox {
            position: relative;
            width: 300px !important;
            height: auto !important;
            padding: 0 0 20px 0;
            -webkit-box-shadow: 0 0 14px rgba(0,0,0,.1);
            -moz-box-shadow: 0 0 14px rgba(0,0,0,.1);
            box-shadow: 0 0 14px rgba(0,0,0,.1);
        }

        body {
            padding-bottom: 0;
            min-height: 100%;
            font-family: 'Open Sans','Segoe UI';
            font-size: 13px;
            color: #444;
        }

        .fadeInDown {
            -webkit-animation-name: fadeInDown;
            animation-name: fadeInDown;
        }

        .animated {
            -webkit-animation-duration: 1s;
            animation-duration: 1s;
            -webkit-animation-fill-mode: both;
            animation-fill-mode: both;
        }

        .login-container {
            position: relative;
            margin: 10% auto;
            max-width: 300px;
        }

        .info {
            color: #49962a;
            border-color: #00acd6;
        }

        a {
            color: #42ca67;
            text-decoration: none;
            cursor: pointer;
        }

         .btn-default {
            color: #FFFFFE;
            background-color: #42ca8a;
            border-color: #357ebd;
       
          
        }

    </style>
        

    <!--Fonts-->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,600,700,300" rel="stylesheet" type="text/css">

    <!--Beyond styles-->
    <link id="beyond-link" href="assets/css/beyond.min.css" rel="stylesheet" />
    <link href="assets/css/demo.min.css" rel="stylesheet" />
    <link href="assets/css/animate.min.css" rel="stylesheet" />
    <asp:UpdatePanel runat="server" class="height100" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="height100">
                <%--<asp:Button ID="btnCrearCuenta" runat="server" Text="Crear Cuenta" CssClass="btn btn-primary btn-block" />--%>

                <div class="login-container animated fadeInDown">
                    <div class="loginbox-or">
                        <div class="or-line"></div>
                       <h3> <strong>Registrar Cálculo</strong></h3> 
                       
                    </div>
                    <div class="loginbox-textbox">
                        Usuario*:
                        <asp:TextBox runat="server" ID="txtUsuario" MaxLength="100"  CssClass="form-control input-xs"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuarios" runat="server"
                            ValidationGroup="VGiniciar"
                            ControlToValidate="txtUsuario"
                            Display="None" ErrorMessage="Digité el usuario">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceUsuarios" runat="server" Enabled="True"
                            TargetControlID="rfvUsuarios">
                        </asp:ValidatorCalloutExtender>
                    </div>
                    <div class="loginbox-textbox">
                        Límite*:
                        <asp:TextBox runat="server"  ID="txtLimi"  MaxLength="5" onkeypress="javascript:return solonumeros(event)" CssClass="form-control input-xs"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLimi" runat="server"
                            ValidationGroup="VGiniciar"
                            ControlToValidate="txtLimi"
                            Display="None" ErrorMessage="Digité el límite">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vceLimi" runat="server" Enabled="True"
                            TargetControlID="rfvLimi">
                        </asp:ValidatorCalloutExtender>
                    </div>
                    <div class="loginbox-forgot">
                    </div>
                    <br />
                    
                     <br />
                    <div class="loginbox-submit">                       
                        <asp:Button ID="btnCalcular" runat="server" ValidationGroup="VGiniciar" Text="Calcular" CssClass="btn btn-primary btn-block" />
                    </div>
                      <br />
                     
                    <h3> <strong>  <asp:Label ID="lblRes" runat="server" Text=""></asp:Label></strong></h3> 
                     <div class="loginbox-submit">                       
                        <asp:Button ID="btnConsultarCalc" runat="server" Visible="false"  Text="Consultar Cálculos" CssClass="btn btn-default btn-block" />
                    </div>
                </div>
                
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCalcular" />
        </Triggers>
    </asp:UpdatePanel>

    <script>
     function solonumeros(e) {
 
            var key;
 
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }
 
            if (key < 48 || key > 57) {
                return false;
            }
 
            return true;
        }
    </script>
</asp:Content>
