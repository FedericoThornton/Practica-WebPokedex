<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-3 text-danger-emphasis bg-warning-subtle border border-warning-subtle rounded-3">
        <h1 style="text-align: center">Bienvenido!</h1>
        <p style="text-align: center">Llegaste al mundo de los Pokemon</p>
        </div>
        <br />
        <div class="row row-cols-1 row-cols-md-3 g-4">
       <!-- <%
                foreach (dominio.Pokemon pokemon in ListaPokemons)
                {
            %>

            <div class="col">
                <div class="card">
                    <img src="<%:pokemon.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%:pokemon.Nombre %></h5>
                        <p class="card-text"><%:pokemon.Descripcion %></p>
                        <a href="DetallePokemon.aspx?Id = <%:pokemon.Id %>">Ver detalle</a>
                    </div>
                </div>
            </div>
            <% } %> -->
            <asp:Repeater ID="Repetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion")%></p>
                                <a href="DetallePokemon.aspx?Id = <%# Eval("Id")%>">Ver detalle</a>
                                <asp:Button Text="Ejemplo" CssClass="btn btn-primary" ID="btnEjemplo" runat="server" CommandArgument= '<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
        </div>
</asp:Content>
