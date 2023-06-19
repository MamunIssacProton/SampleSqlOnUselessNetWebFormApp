<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstantSearch.aspx.cs" Inherits="LabTask3.Views.InstantSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <section>
      <%--  <div>
            <asp:TextBox runat="server" ID="textBox" onkeyup="handleContextChange()" AutoPostBack="true"></asp:TextBox>
<asp:Label runat="server" ID="resultLabel"></asp:Label>
        </div>--%>
        <div>
            <asp:TextBox ID="srchbx"  OnTextChanged="srchbx_TextChanged" AutoPostBack="true" runat="server" placeholder="Type to search here by name"></asp:TextBox>
        </div>
            <div>
                <asp:GridView ID="searchList" DataKeyNames="ID,Name,Dept,DOB,Program" runat="server"></asp:GridView>
            </div>
    </section>

</asp:Content>
