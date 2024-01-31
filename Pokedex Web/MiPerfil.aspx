<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Pokedex_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .validacion{
           color:red;
           font-size:medium;
               
           
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El email es requerido" ControlToValidate="txtEmail" runat="server" />
               
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Nombre es requerido" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Apellido es requerido" ControlToValidate="txtApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de nacimiento</label>
                <asp:TextBox runat="server" ID="txtFechaNacimiento" TextMode="Date" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ImageUrl="https://www.pngkey.com/png/detail/233-2332677_ega-png.png" ID="imgNuevoPerfil" runat="server" CssClass="img-fluid mb-3" />
        </div>
        </div>
    <div class="row">
         <div class="col-md-4"> 
             <asp:Button Text="Guardar" ID="btnGuardar" Onclick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" />
             <a href="/">Regresar</a>

         </div>
    </div>
</asp:Content>
