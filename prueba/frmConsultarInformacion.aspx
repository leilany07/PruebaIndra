<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmConsultarInformacion.aspx.vb" Inherits="prueba.frmConsultarInformacion" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn-buscar {
            color: #ffffff;
            background-color: #30a056;
            border-color: #357ebd;
            margin-top: -31px;
            margin-left: -16px;
        }

        .btn-info-ico {
            color: #1ba7b4 !important;
            /* color: #9A9A9A !important; */
            background-color: rgba(0, 0, 0, 0) !important;
            border: rgba(0, 0, 0, 0) !important;
        }

        .btn-info, .btn-info:focus {
            background-color: #57b5e3 !important;
            border-color: #57b5e3;
            color: #fff;
        }

        .btn-primary {
            color: #FFFFFE;
            background-color: #42ca8a;
            border-color: #357ebd;
            margin-left: 1188px;
            margin-top: 1px;
        }

        .cajafiltros {
            margin: 15px 0 !important;
            padding: 15px;
            border: 1px solid #CCC;
            display: inline-block;
            background-color: #f3f3f3;
        }

        select {
            background: white;
            border: none;
            font-size: 14px;
            height: 28px;
            padding: 2px;
            width: 195px;
        }

        .lbl {
            margin-left: 14px;
        }
    </style>
    <asp:UpdatePanel runat="server" class="height100" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server" class="height100">
        <div class="page-header position-relative">
            <div class="header-title">
                <h2><strong>Consultar información</strong></h2>
            </div>
            <!--Header Buttons-->
            <div class="header-buttons">
                <a class="sidebar-toggler" href="#">
                    <i class="fa fa-arrows-h"></i>
                </a>
            </div>
            <!--Header Buttons End-->
        </div>
        <div class="page-body frmPage-Body">
            <div class="widget height100">
                <div class="widget-body height100">
                    <div class="componentHeight">


                        <%-- Box de filtros --%>

                        <div class="row">
                            <%-- usuario  --%>
                            <div class="form-group col-lg-3 col-md-3 col-sm-12">

                                <asp:Label ID="lblUser" CssClass="lbl" runat="server" Text="Usuario:"></asp:Label>
                                <div class="input-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtUsuario" runat="server" MaxLength="100" CssClass="form-control input-xs"></asp:TextBox>
                                </div>
                                <br />
                                <%-- Respuesta (Minima)  --%>


                                <asp:Label ID="lblReMi" CssClass="lbl" runat="server" Text="Respuesta (Minima):"></asp:Label>
                                <div class="input-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtResMini" onkeypress="javascript:return solonumeros(event)" runat="server" MaxLength="10" CssClass="form-control input-xs"></asp:TextBox>
                                </div>

                                <%-- Respuesta (Maxima)  --%>
                                <br />

                                <asp:Label ID="lblReMa" CssClass="lbl" runat="server" Text="Respuesta (Maxima):"></asp:Label>
                                <div class="input-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtResMaxima" onkeypress="javascript:return solonumeros(event)" runat="server" MaxLength="10" CssClass="form-control input-xs"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-lg-3 col-md-3 col-sm-3">
                            <asp:Label ID="NoLabel" runat="server" Text="">&nbsp;</asp:Label>
                            <div class="input-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <asp:Button ID="btnConsultar" CssClass="btn btn-buscar btn-Small" runat="server" Text="Consultar" />
                            </div>
                        </div>
                    </div>
                      <asp:GridView ID="gvResultados"
                            runat="server"
                            CssClass="table  table-hover table-bordered textMayuscularow"
                            AutoGenerateColumns="False"
                            Width="100%"
                            DataKeyNames="Id"
                            GridLines="None"
                            ShowHeaderWhenEmpty="True">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="N°"></asp:BoundField>
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario"></asp:BoundField>                         
                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta"></asp:BoundField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora"></asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="LkbtnEliminar" ForeColor="Red" runat="server" Text="Eliminar" data-toggle="tooltip" data-placement="top" data-original-title="Eliminar" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" CommandName="Eliminar"></asp:LinkButton>

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="TablecolumButton OrderHead " />
                                    <ItemStyle CssClass="TablecolumButton" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    
                </div>
            </div>
        </div>
    </asp:Panel>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnConsultar" />
             <asp:AsyncPostBackTrigger ControlID="gvResultados" />
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
