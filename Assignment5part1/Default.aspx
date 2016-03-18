<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5part1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cookie and Session Testing page</h1>
    <br />
    <h3>Enter the information</h3>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    <br />
    <br />
    <asp:Label ID="nameLabel" runat="server" Text="nameLabel"></asp:Label>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="emailLabel"></asp:Label>
    <h1>XML file manipulation</h1>
    <br />
    <h3>Enter the information to add to XML file. Search for the Username in the XML file. If exists then print out the warning</h3>
    <br />
    <asp:Label ID="usernameLbl" runat="server" Text="Username:"></asp:Label>
    <asp:TextBox ID="userNameTxtBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="passwordLbl" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="passwordTxtBox" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="submitButton2" runat="server" Text="Submit" OnClick="submitButton2_Click" />
    <asp:Label ID="resultLbl" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <h3>All old web services TryIt</h3>
    <asp:Label ID="Label3" runat="server" Text="Filter Function:"></asp:Label>
    <asp:TextBox ID="filterTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" />
    <br>
    <asp:Label ID="filterResult" runat="server" Text="result?"></asp:Label>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Top 10 words function:"></asp:Label>
    <asp:TextBox ID="top10TextBox" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
    <br>
    <asp:Label ID="top10Result" runat="server" Text="result: "></asp:Label>
</asp:Content>
