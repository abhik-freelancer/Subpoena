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
       
    <%--<asp:Button ID="btnView" CssClass="button" runat="server" Text="View" OnClick="btnView_Click" />
    <asp:Button ID="btnAddNew" CssClass="button" runat="server" Text="Add New" OnClick="btnAddNew_Click" />--%>
    <div class="formLineDivInv">
            <asp:Label text="E-Mail Address:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Temporary Password:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtTempPassword" runat="server" TextMode="Password"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="New Password:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Retype Password:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRetypPassword" runat="server" TextMode="Password"></asp:TextBox>    
    </div>           
            
  <div class="formLineDivInv">
                <span></span>
           
                <asp:Button ID="btnSubmit" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="FormButton" />
                
                <%--<asp:TextBox ID="txtEmailSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnEmail"   runat="server" Text="E-mail Search" OnClick="btnEmailSearch_Click" />  --%> 
   </div>
   
   <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">E-Mail Address:</label>
                    <asp:TextBox ID="txtEmailSearch" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                   
                </div>
                 <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnEmail" ValidationGroup="check" runat="server" Text="Search" OnClick="btnEmailSearch_Click"
                        CssClass="addCustomerBtn" />

                </div>
        </div>            
       
      <div class="Grid" id="Div1" runat="server"> 
            <div class="gridOuterDiv">       
                    <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable"
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting"  AutoGenerateColumns="False" >

                        <HeaderStyle CssClass="header" />
                        <RowStyle  CssClass="RowStyle"/>
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate" />
                        <AlternatingRowStyle CssClass="alternate" />
                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"   CssClass="gridtable"  AllowPaging="True" PageSize="10" onpageindexchanging="GridView1_PageIndexChanging"
                onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting">
                <HeaderStyle CssClass="header" />
                        <RowStyle  CssClass="RowStyle"/>
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate" />--%>
                        
                    <Columns>
                        
                        <asp:TemplateField HeaderText="PasswordChangeId" Visible="false">
                             <ItemTemplate>
                                    <asp:Label ID="lblPasswordChangeId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-Mail Address">
                                <ItemTemplate>
                        <asp:Label ID="lblEmailAddress" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Temporary Password">
                                <ItemTemplate>
                        <asp:Label ID="lblTempPassword" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="New Password">
                                <ItemTemplate>
                        <asp:Label ID="lblNewPassword" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Retype Password">
                                <ItemTemplate>
                        <asp:Label ID="lblRetypePassword" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" CommandName="Edit" ImageUrl="../images/blankImg.png" runat="server" CssClass="editGrid"  />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>                            
                            <asp:ImageButton ID="imgDelte" runat="server" ImageUrl="../images/blankImg.png" CommandName="Delete" CssClass="crossRemove"/>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                       <%-- <asp:BoundField DataField="PasswordChangeId" HeaderText="ID" />
                        <asp:BoundField DataField="EmailAddress" HeaderText="E-Mail Address" />
                        <asp:BoundField DataField="TempPassword" HeaderText="Temporary Password" Visible="false" />
                        <asp:BoundField DataField="NewPassword" HeaderText="New Password" Visible="false" />
                        <asp:BoundField DataField="RetypePassword" HeaderText="Retype Password" Visible="false" />--%>
                       
                        <%--<asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                               <asp:ImageButton ID="imgEdit" CommandName="Edit" ImageUrl="~/images/edit_icon.png" runat="server"  />
                        </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelte" runat="server" ImageUrl="~/images/Cross.png" CommandName="Delete"/>
                        </ItemTemplate>
                        </asp:TemplateField> --%>
                                            
                         
                                       
                       <%-- <asp:TemplateField HeaderText="Action">
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("UserId")%>'
                                    CommandName="cmdEdit" Text="Edlit"></asp:LinkButton>
                                &nbsp;&nbsp;---&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Countryid")%>'
                                    CommandName="cmdDelete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
     </div>
    </div>
   </asp:Content>