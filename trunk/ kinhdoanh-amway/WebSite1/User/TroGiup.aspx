<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" Async="true"  AutoEventWireup="true" CodeFile="TroGiup.aspx.cs" Inherits="User_TroGiup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Mọi thông tin chi tiết xin liên hệ: group Myfamily.</p>
    <p>
        Địa chỉ: <a href="https://www.facebook.com/groups/193356717517376/">https://www.facebook.com/groups/193356717517376/</a></p>
    <p>
        &nbsp;</p>
    
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send Mail" /></div>
</asp:Content>

