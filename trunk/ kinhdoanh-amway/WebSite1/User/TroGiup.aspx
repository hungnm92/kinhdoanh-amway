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
    
    <table cellpadding="10" cellspacing="10" id="FormLienKe" align="center">
    <tr>
        <td colspan="2" align="center">
            <h1>Trợ Giúp</h1>
        </td>
    </tr>
    <tr>
        <td style="width: 30%" colspan="2">
            Nếu bạn có bất cứ thắc mắc, ý kiến đóng góp hoặc câu hỏi gì liên quan đến website, 
hãy liên lạc với tôi bằng form dưới đây. Tôi sẽ hồi âm bạn sớm nhất có thể. 
Tôi luôn cố gắng trả lời tất cả những email gửi tới.
            </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Họ và tên:<span class="style1"> *</span></td>
        <td style="width: 70%">
            <asp:TextBox ID="txtHoTen" runat="server" Width="300px"  />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtHoTen" ErrorMessage="Vui lòng điền tên bạn" 
                Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Địa chỉ&nbsp;</td>
        <td style="width: 70%">
            <asp:TextBox ID="txtDiaChi" runat="server" Width="300px"   />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Điện Thoại:</td>
        <td style="width: 70%">
            <asp:TextBox ID="txtDienThoai" runat="server" Width="300px"   />
        </td>
    </tr>
    <tr>
        <td style="width: 30%">
            Email:<span class="style1"> *</span></td>
        <td style="width: 70%">
            <asp:TextBox ID="txtEmail" runat="server" Width="300px"   />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="Vui lòng nhập Email" 
                Display="Dynamic" />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  runat="server" 
                ErrorMessage="Email không hợp lệ" ControlToValidate="txtEmail" 
                Display="Dynamic"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 30%" valign="top">
            Thông điệp:<span class="style1"> *</span></td>
        <td >
            <asp:TextBox ID="txtNoiDung" style="background-color:#FAFAFA; padding:5px;" 
            TextMode="MultiLine" Rows="6" runat="server" Width="420px" />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtNoiDung" ErrorMessage="*" 
                Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" align="center" id="LinkOfList">
            <asp:Button ID="btnSend" runat="server" Text="Gửi liên hệ" 
                onclick="btnSend_Click" />
            </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" align="center" id="Td1">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
    </tr>
</table>

</asp:Content>

