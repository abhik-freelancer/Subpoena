<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs"
    Inherits="Website.Pages.UserResgistration" Title=":: Group Creation ::" %>

<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="float: left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
                <asp:Label ID="lblSubheading" runat="server" Text="Register With Subpoena Tool"></asp:Label>
            </div>
        </div>
        <%--<div class="main_box_in">
        <span class="Sectionheader">Register With Subpoena Tool</span>
    </div>--%>


         <input type="hidden" runat="server" id="hdneditId" value="" />
        <div class="row">
             <div class="col-xs-3 form-group">
            <asp:Label Text="First Name *:" runat="server"> </asp:Label>
                 </div>
             <div class="col-xs-9 form-group">
            <asp:TextBox ID="txtFirstName"  CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ForeColor="Red" controltovalidate="txtFirstName" errormessage="Please enter First name!" />
                 </div>
        </div>
        <div class="row">
             <div class="col-xs-3 form-group">
            <asp:Label ID="Label1" Text="Last Name *:" runat="server"> </asp:Label>
                 </div>
             <div class="col-xs-9 form-group">
            <asp:TextBox ID="txtLastName"  CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ForeColor="Red" controltovalidate="txtLastName" errormessage="Please enter Last name!" />
        </div>
             </div>
        <div class="row">
             <div class="col-xs-3 form-group">
            <asp:Label Text="Email Address *:" runat="server"> </asp:Label>
                 </div>
             <div class="col-xs-9 form-group">
            <asp:TextBox ID="txtEmail"  CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ForeColor="Red" controltovalidate="txtEmail" errormessage="Please enter Email !" />
                 </div>
        </div>
        <div class="row">
             <div class="col-xs-3 form-group">
            <asp:Label Text="Group *:" runat="server"> </asp:Label>
                 </div>
             <div class="col-xs-9 form-group">
            <asp:DropDownList ID="DropDownGroup"  CssClass="form-control" runat="server" TabIndex="4">
            </asp:DropDownList>
                 <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4"  runat="server" ControlToValidate="DropDownGroup"
    Text="Please select group" ForeColor="Red" ErrorMessage="Please select group"></asp:RequiredFieldValidator>  
                 </div>
        </div>
        <div class="row">
             <div class="col-xs-3 form-group">
              <asp:Label ID="Label2" Text="Role *:" runat="server"> </asp:Label>
                 </div>
             <div class="col-xs-9 form-group">

                <%--
                    a.      Super Admin (us) set up accounts and the work flow of each account - Superadmin will have access to everything - Home page will have dashboard which will be implemented later.

b.     Admin (lead person) set up groups and group leaders - same like super admin for now - Home page will have dashboard which will be implemented later.       
                     c.      Group Leader (lead of each group) enters and manger users - (This user have only access to - Users Registration, Subpoena)

d.     Other Users (Da, Officers, courts) end users - ( This user has only access to Home Page ) - Page No. 10

e. 	Detective - ( This user has only access to Home Page ) - Page No. 8

f. 	Subpoena Producer - ( This user has only access to Home Page ) Page No 9--%>

            <asp:DropDownList runat="server"  CssClass="form-control" ID="DropdownUserrole">
                <asp:ListItem Text="Super Admin" Value="SuperAdmin"  />
                <asp:ListItem Text="Admin" Value="Admin"  />
                  <asp:ListItem Text="Group Leader" Value="GroupLeader"  />
                <asp:ListItem Text="Detective" Value="Detective"  />
                <asp:ListItem Text="subpoena producer" Value="subpoenaproducer" />
                <asp:ListItem Text="Other users" Value="Otherusers" />
            </asp:DropDownList>
                 </div>
        </div>
        <div class="formLineDivInv">
            <label></label>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="FormButtonImp" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="FormButton" />
        </div>
        
    </div>
</asp:Content>
