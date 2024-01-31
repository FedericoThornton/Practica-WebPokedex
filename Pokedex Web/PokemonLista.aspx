<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="Pokedex_Web.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-3 text-danger-emphasis bg-warning-subtle border border-warning-subtle rounded-3">
        <h1 style="text-align: center">Lista de Pokemon </h1>
        <hr />
        <div class="row">
            <div class="col-2">
                <asp:Label Text="Filtrar:" ID="Filtro" CssClass="form-label" runat="server" />
                <div>
                    <asp:TextBox CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" ID="txtFiltro" AutoPostBack="true" runat="server" />
                </div>
                <asp:CheckBox CssClass="" Text="Filtro avanzado" AutoPostBack="true" ID="chkfiltroAvanzado" runat="server" OnCheckedChanged="chkfiltroAvanzado_CheckedChanged" />
            </div>
        </div>
        <hr />
        <%if (chkfiltroAvanzado.Checked)

            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="LblCampo" runat="server" CssClass="form-label" />
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="DdlCampo" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="Número" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Tipo" />
                        <asp:ListItem Text="Debilidad" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" ID="LblCriterio" runat="server" CssClass="form-label" />
                    <asp:DropDownList CssClass="form-control" ID="DdlCriterio" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" ID="lblFitroavanzado" runat="server" CssClass="form-label" />
                    <asp:TextBox CssClass="form-control" runat="server" ID="TxtFiltroavanzado">
                    </asp:TextBox>
                </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" ID="lblEstado" CssClass="form-label" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="DdlEstado">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        <div class="row">
            <div class="col">
                <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
        </div>
        <%} %>
            <asp:GridView ID="dgvPokemons" CssClass="table" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" OnPageIndexChanging="dgvPokemons_PageIndexChanging"
                PageSize="3" AllowPaging="true"
                runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar" />
                </Columns>
            </asp:GridView>
           
            <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
      </div>
       
</asp:Content>
