<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="GroupCreation1.aspx.cs" 
Inherits="Website.Pages.GroupCreation1" Title=":: Group Creation ::" %>
<%--<asp:Content ID="Content12" ContentPlaceHolderID="head" runat="server">
    <title>
        Group Creation
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="lblHeader" runat="server" Text="Group Creation"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <input type="hidden" runat="server" id="hdneditId" value="" />
<%--<div id="Div1321" align="center" runat="server">--%>
    <div class="container" style="float:left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Create Group"></asp:Label>
            </div>
        </div>
    <%--<div class="main_box_in">
        <span class="Sectionheader">Create Group</span>
    </div>--%>
   
    <div class="row">
         <div class="col-xs-3 form-group">
            <asp:Label text="Group Name *:" runat="server"> </asp:Label>
             </div>
         <div class="col-xs-9 form-group">
            <asp:TextBox ID="txtGroupName" CssClass="form-control" runat="server"></asp:TextBox> 
              <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ForeColor="Red" controltovalidate="txtGroupName" errormessage="Please enter Group name!" />
             </div>   
    </div>
    <div class="row">
        <div class="col-xs-3 form-group">
            <asp:Label text="Address1 *:" runat="server"> </asp:Label>
             </div>
         <div class="col-xs-9 form-group">
        <asp:TextBox ID="txtAddress1" CssClass="form-control" runat="server"></asp:TextBox>  
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ForeColor="Red" controltovalidate="txtAddress1" errormessage="Please enter address1!" />
          </div>    
    </div>
    <div class="row">
         <div class="col-xs-3 form-group">
            <asp:Label text="Address2 :" runat="server"> </asp:Label>
             </div>
         <div class="col-xs-9 form-group">
         <asp:TextBox ID="txtAddress2" CssClass="form-control" runat="server"></asp:TextBox> 
        <%-- <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3"  controltovalidate="txtAddress2" ForeColor="Red" errormessage="Please enter address2!" />--%>
           </div>   
    </div>
    <div class="row">
        <div class="col-xs-3 form-group">
            <asp:Label text="City *:" runat="server"> </asp:Label>
            </div>
         <div class="col-xs-9 form-group">
          <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4"  ForeColor="Red" controltovalidate="txtCity" errormessage="Please enter City !" />
            </div> 
    </div>
    <div class="row">
          <div class="col-xs-3 form-group">
            <asp:Label text="State *:" runat="server"> </asp:Label>
              </div>
        <div class="col-xs-9 form-group">
            <asp:DropDownList ID="DropDownState" CssClass="form-control" runat="server" TabIndex="5">
                    </asp:DropDownList>   

            <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID"  runat="server" ControlToValidate="DropDownState"
    Text="Please select state" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator>
            </div> 
    </div>
    <div class="row">
         <div class="col-xs-3 form-group">
            <asp:Label text="Zip Code *:" runat="server"> </asp:Label>
             </div>
         <div class="col-xs-9 form-group">
         <asp:TextBox ID="txtZipcode" CssClass="form-control" runat="server"></asp:TextBox>    
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ForeColor="Red" controltovalidate="txtZipcode" errormessage="Please enter Zipcode !" />
          </div> 
    </div>
     <div class="row">
          <div class="col-xs-3 form-group">
            <asp:Label text="Country *:" runat="server"> </asp:Label>
              </div>
         <div class="col-xs-9 form-group">
            <asp:DropDownList ID="DropDownCountry" CssClass="form-control" runat="server" TabIndex="5">
                    </asp:DropDownList> 
             <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3"  runat="server" ControlToValidate="DropDownCountry"
    Text="Please select country" ForeColor="Red" ErrorMessage="Please select country"></asp:RequiredFieldValidator>  
             </div> 
    </div>
     <div class="formLineDivInv"><label></label>
         
                    <asp:Button ID="btnSubmit1" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="btnSubmit1_Click" />
                    <asp:Button ID="btnReset" CssClass="FormButton" runat="server" Text="Reset" OnClick="btnReset_Click" />
     </div>
     
    </div>
</asp:Content>