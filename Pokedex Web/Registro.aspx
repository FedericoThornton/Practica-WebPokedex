<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokedex_Web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
    .validacion{
        color:red;
        font-size:medium;
            
        
    }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="row">
        <div class="col-4">
            <h2>Creá tu perfil Trainee</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail"/>
                <asp:RequiredFieldValidator ErrorMessage="El email es requerido" CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
               
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
                <asp:RequiredFieldValidator ErrorMessage="El Password es requerido" CssClass="validacion" ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button Text="Registrarse" cssclass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>

        </div>
    </div>



</asp:Content>
