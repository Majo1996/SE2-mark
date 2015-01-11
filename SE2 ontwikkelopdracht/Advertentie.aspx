<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Advertentie.aspx.cs" Inherits="SE2_ontwikkelopdracht.Advertentie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Image ID="Img1" runat="server" Height="33px" Width="39px"  />
    <asp:Image ID="Img2" runat="server" Height="33px" Width="39px"  />
    <asp:Image ID="Img3" runat="server" Height="33px" Width="39px"  />
   
    <br />
    <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnString %>" ProviderName="<%$ ConnectionStrings:ConnString.ProviderName %>" SelectCommand="SELECT DBI292158.ACCOUNT.NAAM, DBI292158.BOD.BEDRAG FROM DBI292158.ACCOUNT INNER JOIN DBI292158.BOD ON DBI292158.ACCOUNT.ACCOUNTNR = DBI292158.BOD.ACCOUNTNR"></asp:SqlDataSource>
        <br />
    <div>
        <asp:Button ID="btnBied" runat="server" Text="Bied" OnClick="btnBied_Click"/>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="," ></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
    &nbsp;&nbsp;&nbsp;
        <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <div>
    <asp:TextBox ID="TextBox1" runat="server" Height="200px" ReadOnly="True" TextMode="MultiLine" Width="391px"></asp:TextBox>       
    </div> 
    </div>
    </div>
</asp:Content>
