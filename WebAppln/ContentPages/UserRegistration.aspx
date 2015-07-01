<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" 
    Inherits="Website.Pages.UserResgistration" Title=":: Group Creation ::" %>
    
    <asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="float:left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Register With Subpoena Tool"></asp:Label>
            </div>
        </div>
    <%--<div class="main_box_in">
        <span class="Sectionheader">Register With Subpoena Tool</span>
    </div>--%>
    
    
    
    <div class="formLineDivInv">
            <asp:Label text="First Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label ID="Label1" text="Last Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Email Address:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Group:" runat="server"> </asp:Label>
            <td class="col2"><asp:DropDownList ID="DropDownGroup" runat="server" TabIndex="4" >
            </asp:DropDownList>  
    </div>    
            
           <div class="formLineDivInv"> 
                        <span></span>
                        
                                                   
            <asp:Button ID="btnSubmit"  runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="FormButtonImp" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="FormButton" />
            </div>
            <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">First Name:</label>
                    <asp:TextBox ID="txtNameSearch" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div>
                 <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnFNameSearch" ValidationGroup="check" runat="server" Text="Search" OnClick="btnFNameSearch_Click"
                        CssClass="addCustomerBtn" />
                 </div> 
                         
            
            
    <div class="Grid"  id="tblGrid" runat="server">
    <div class="gridOuterDiv">
   
                <asp:GridView ID="GridView1" runat="server"   Width="100%" BorderWidth="0"  EnableModelValidation="True" AllowPaging="True" PageSize="10" 
                        onpageindexchanging="GridView1_PageIndexChanging" CssClass="gridtable" onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" 
                        onrowdatabound="GridView1_RowDataBound" AllowSorting="True" AutoGenerateColumns="False" >
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
                        <Columns>
                        <asp:TemplateField HeaderText="User Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserId" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            
                        <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserFirstName" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserLastName" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-Mail">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserEmail" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>

                        <asp:TemplateField HeaderText="GrpID" Visible="False" >
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupId" runat="server" ></asp:Label>
                                </ItemTemplate>                      
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Group Name"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupName" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
 




                        <%--<asp:BoundField DataField="UserId" HeaderText="ID" />
                        <asp:BoundField DataField="UserFirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="UserLastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="UserEmail" HeaderText="E-Mail" />
                        <asp:BoundField DataField="Group" HeaderText="User Group" /> --%>
                        <%--<asp:BoundField DataField="GrpName" HeaderText="User Group Name" /> --%>
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
    
        </div>
        </div>
</asp:Content>