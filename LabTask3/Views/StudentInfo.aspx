<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="LabTask3.Views.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <span>
               <asp:Label ID="msg" runat="server" Text=""></asp:Label>
        </span>
        <span>
                   <asp:DropDownList ID="filter" runat="server" OnSelectedIndexChanged="filter_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
               </span>
        <div>
            <asp:GridView ID="listStudents" DataKeyNames="ID,Name,Dept,DOB,Program"  runat="server" Width="800" AutoGenerateSelectButton="true" OnSelectedIndexChanged="listStudents_SelectedIndexChanged"></asp:GridView>
        </div>
        <div>
           
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="OnStudentUpdate" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="OnStudentDelete"/>
        </div>
    </section>
    <section>
        <div>
            <asp:Label ID="lblStdId" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="stdID" placeholder="Student ID" runat="server"></asp:TextBox>
        </div>
           <div>
            <asp:TextBox ID="stdName" placeholder="Name" runat="server"></asp:TextBox>
        </div>
           <div>
               <asp:Label ID="lblStdDept" runat="server" Text=""></asp:Label>
               <span>
                   <asp:DropDownList ID="optDept" runat="server" AutoPostBack="true"></asp:DropDownList>
               </span>
        </div>
           <div>
            <asp:TextBox ID="stdDOB" placeholder="DOB" runat="server"></asp:TextBox>
        </div>
         <div>
            <label>Program :</label>
             <asp:RadioButtonList ID="programList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="programList_SelectedIndexChanged"></asp:RadioButtonList>

        </div>
    </section>
    <div>
         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="OnStudentCreate" />
    </div>
</asp:Content>
