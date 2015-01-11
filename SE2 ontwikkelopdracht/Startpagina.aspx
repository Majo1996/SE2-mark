
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Startpagina.aspx.cs" Inherits="SE2_ontwikkelopdracht.Startpagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <br />
    <asp:Button ID="btnPlaats" runat="server" BorderColor="Gray" Text="Plaats advertentie" style="width: 200px; height: 45px;" OnClick="btnPlaats_Click" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" style="width: 250px;"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnZoek" runat="server" Text="Zoek" style="width: 100px;" OnClick="btnZoek_Click" />
&nbsp;&nbsp;&nbsp; 
            </div>
        <hr />
        <br />
        <div style="display:inline-block;">
        <asp:Panel ID="Panel1" runat="server" style="border-top-width: medium; border-top-style: solid; border-top-color: #808080; border-right-width: medium; border-right-style: solid; border-right-color: #808080; border-bottom-width: medium; border-bottom-style: solid; border-bottom-color: #808080; border-left-width: medium; border-left-style: solid; border-left-color: #808080;" Height="161px" Width="200px">
            <p>
                &nbsp;</p>
            <ul>
              <li> <asp:LinkButton ID="lblAuto" runat="server" OnClick="lblAuto_Click">Voertuigen</asp:LinkButton> </li>
                <li><asp:LinkButton ID="lblOnderdelen" runat="server" OnClick="lblOnderdelen_Click">Auto onderdelen</asp:LinkButton></li>
                <li><asp:LinkButton ID="lblKeuken" runat="server" OnClick="lblKeuken_Click">Keukengerei</asp:LinkButton></li>
                <li><asp:LinkButton ID="lblTuin" runat="server" OnClick="lblTuin_Click">Tuin gereedschap</asp:LinkButton></li>          
                <li><asp:LinkButton ID="lblBoek" runat="server" OnClick="lblBoek_Click">Boeken</asp:LinkButton></li>
            </ul>
        </asp:Panel>
        </div>
    <div style="display:inline-block;">
            <asp:GridView ID="GridView1" runat="server" style="margin-left: 54px;" DataSourceID="Sqlgv1" Width="527px" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="OMSCHRIJVING" HeaderText="OMSCHRIJVING" SortExpression="OMSCHRIJVING" />
                <asp:BoundField DataField="VRAAGPRIJS" HeaderText="VRAAGPRIJS" SortExpression="VRAAGPRIJS" />
                <asp:ButtonField Text="Bekijk de advertentie!" CommandName="GridView1_RowCommand" CausesValidation="True" >
                <ItemStyle ForeColor="Black" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Sqlgv1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnString %>" ProviderName="<%$ ConnectionStrings:ConnString.ProviderName %>" SelectCommand="SELECT &quot;OMSCHRIJVING&quot;, &quot;VRAAGPRIJS&quot; FROM &quot;ADVERTENTIE&quot; ORDER BY &quot;ADVERTENTIENR&quot; DESC"></asp:SqlDataSource>
    </div>

</asp:Content>

