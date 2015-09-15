<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" 
    Inherits="Website.Pages.ChangePassword" Title=":: Change Password ::" %>

<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="float:left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Change Password"></asp:Label>
            </div>
        </div>
    <%--<div class="main_box_in">
        <span class="Sectionheader">Change Password</span>
    </div>--%>
         <input type="hidden" runat="server" id="hdneditId" value="" />
    <%--<asp:Button ID="btnView" CssClass="button" runat="server" Text="View" OnClick="btnView_Click" />
    <asp:Button ID="btnAddNew" CssClass="button" runat="server" Text="Add New" OnClick="btnAddNew_Click" />--%>
    <div class="formLineDivInv">
            <asp:Label text="E-Mail Address *:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> 
         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ForeColor="Red" controltovalidate="txtEmail" errormessage="Please enter Group name!" />   
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Temporary Password *:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtTempPassword" runat="server" TextMode="Password"></asp:TextBox> 
         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ForeColor="Red" controltovalidate="txtTempPassword" errormessage="Please enter Group name!" />   
    </div>
    <div class="formLineDivInv">
            <asp:Label text="New Password *:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ForeColor="Red" controltovalidate="txtNewPassword" errormessage="Please enter Group name!" />    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Retype Password *:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRetypPassword" runat="server" TextMode="Password"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ForeColor="Red" controltovalidate="txtRetypPassword" errormessage="Please enter Group name!" />    
    </div>           
            
  <div class="formLineDivInv">
                <span></span>
           
                <asp:Button ID="btnSubmit" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="FormButton" />
                
                <%--<asp:TextBox ID="txtEmailSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnEmail"   runat="server" Text="E-mail Search" OnClick="btnEmailSearch_Click" />  --%> 
   </div>
   
       
       
      
   </asp:Content>