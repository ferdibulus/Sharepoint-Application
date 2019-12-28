<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Movie.ascx.cs" Inherits="FilmListeleme.Movie.Movie" %>
<asp:HiddenField ID="hf_id" runat="server" />
<table>
    <tr>
        <td>
            <asp:Label ID="lbl_title" runat="server" Text="Movie Title" Width="150px"></asp:Label>
            <asp:TextBox ID="txt_title" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbl_release" runat="server" Text="Release Year" Width="150px"></asp:Label>
            <asp:TextBox ID="txt_release" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="Save" Width="100px" OnClick="btn_save_Click" />
            <asp:Button ID="btn_delete" runat="server" Text="Delete" Width="100px" OnClick="btn_delete_Click" />
            <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="100px" OnClick="btn_clear_Click" />
        </td>
    </tr>
</table>
<asp:GridView ID="gv_films" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="Movie ID"></asp:BoundField>
        <asp:BoundField DataField="title" HeaderText="Movie Title"></asp:BoundField>
        <asp:BoundField DataField="release" HeaderText="Release Date"></asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lb_View" runat="server" CommandArgument='<%# Eval ("id") %>' OnClick="lb_View_OnClick">View</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

