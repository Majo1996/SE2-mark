<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Startpagina.aspx.cs" Inherits="SE2_ontwikkelopdracht.Startpagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <br />
    <asp:Button ID="btnPlaats" runat="server" BorderColor="Gray" Text="Plaats advertentie" style="width: 200px; height: 45px;" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" style="width: 250px;"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" style="width: 160px;">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnZoek" runat="server" Text="Zoek" style="width: 100px;" />
&nbsp;&nbsp;&nbsp; 
            </div>
        <hr />
        <br />
        <div style="display:inline-block;">
        <asp:Panel ID="Panel1" runat="server" style="border-top-width: medium; border-top-style: solid; border-top-color: #808080; border-right-width: medium; border-right-style: solid; border-right-color: #808080; border-bottom-width: medium; border-bottom-style: solid; border-bottom-color: #808080; border-left-width: medium; border-left-style: solid; border-left-color: #808080;" Height="161px" Width="200px">
            <p>
                &nbsp;</p>
            <ul>
              <li> <asp:Label ID="lblAuto" runat="server">Auto's</asp:Label> </li>
                <li>Auto onderdelen</li>
                <li>Keukengerei</li>
                <li>Tuin gereedschap</li>
                <li>Boeken</li>
            </ul>    
        </asp:Panel>
        </div>
    <div style="display:inline-block;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 54px;"></asp:GridView>
    </div>

</asp:Content>

