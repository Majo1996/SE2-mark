<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaatsAdvertentie.aspx.cs" Inherits="SE2_ontwikkelopdracht.PlaatsAdvertentie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="180px">
        <asp:ListItem>Categorie</asp:ListItem>
        <asp:ListItem>Voertuigen</asp:ListItem>
        <asp:ListItem>Auto onderdelen</asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Keuken</asp:ListItem>
        <asp:ListItem>Tuin</asp:ListItem>
        <asp:ListItem>Boeken</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Prijs:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; €
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
    ,-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Sla advertentie op!" />
<br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Omschrijving"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="168px" Width="301px" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<br />
<br />
Foto&#39;s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
<asp:FileUpload ID="FileUpload1" runat="server" Height="31px" Width="302px" onchange ="CheckExt(this)"/>
    <br />
Foto&#39;s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<asp:FileUpload ID="FileUpload2" runat="server" Height="31px" Width="302px" onchange ="CheckExt(this)"/>
    <br />
Foto&#39;s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <script type ="text/javascript">
        var validFiles = ["png", "jpg", "jpeg"];
        function CheckExt(obj) {
            var source = obj.value;
            var ext = source.substring(source.lastIndexOf(".") + 1, source.length).toLowerCase();
            for (var i = 0; i < validFiles.length; i++) {
                if (validFiles[i] == ext)
                    break;
            }
            if (i >= validFiles.length) {
                alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n" + validFiles.join(", "));
            }
        }
    </script>
&nbsp;&nbsp;&nbsp; 
<br />
<asp:FileUpload ID="FileUpload3" runat="server" Height="31px" Width="302px" onchange ="CheckExt(this)"/>
    </asp:Content>
