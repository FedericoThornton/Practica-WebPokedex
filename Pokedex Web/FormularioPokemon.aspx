<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Pokedex_Web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScripManager1" runat="server" />


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox ID="TxtNumero" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="TxtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="TxtDescripcion" TextMode="Multiline" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="DdlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="DdlTipo" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="DdlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="DdlDebilidad" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Imagen</label>
                        <asp:TextBox ID="TxtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtUrlImagen_TextChanged" runat="server" />
                    </div>
                    <div>
                        <div>
                            <asp:Image ImageUrl="https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg" ID="ImagenPokemon" Width="80%" runat="server" />
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <div>

                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                    <a href="PokemonLista.aspx">Cancelar</a>
                    <asp:Button Text="Inactivar" ID="btnInactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" runat="server" />
                </div>
            </div>

            <div class="mb-3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Borrar" ID="btnBorrar" CssClass="btn btn-danger" OnClick="btnBorrar_Click" runat="server" />
                        </div>
         <% if (ConfirmaEliminacion)
             { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar físico" ID="btnConfirmaEliminar" CssClass="btn btn-outline-warning" OnClick="btnConfirmaEliminar_Click" runat="server" />
                        </div>
                        <%  } %>
             </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
