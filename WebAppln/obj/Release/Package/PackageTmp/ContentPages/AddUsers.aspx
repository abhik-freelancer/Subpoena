<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" 
    Inherits="WebAppln.ContentPages.AddUsers" EnableEventValidation="false" Title=":: Add Users ::" %>

<%--<asp:Content ID="Content121" ContentPlaceHolderID="head" runat="server">
    <title>
        Add User
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label1" runat="server" Text="Add Users"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content221" ContentPlaceHolderID="MainContent" runat="server">
   
    <%--<h1>
       <asp:Label ID="lblHeader" runat="server" Text="Add Users  "></asp:Label>
    </h1>--%>
     <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">User Name:</label>
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                 <div class="searchTextboxBlock">
                    <label class="fullLbl">User :</label>
                    <asp:TextBox ID="txtUser" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">E-Mail:</label>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearchUser" ValidationGroup="check" runat="server" Text="Search" OnClick="btnSearchUser_Click"
                        CssClass="addCustomerBtn" />

                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnExportxls" ValidationGroup="check" runat="server" Text="Export to Excel" OnClick="btnExportXls_Click"
                        CssClass="addCustomerBtn" />

                </div>
                
    </div>
    
     
       <div class="searchTextboxBlockPage">
                    <label>Page No:</label>
                    <asp:DropDownList ID="PageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSize_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:DropDownList>
                </div>
        <%--<td><asp:TextBox ID="txtPageNo" runat="server"></asp:TextBox></td>--%>
  <div class="Grid">
    <div class="gridOuterDiv">
            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable"
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" onsorting="GridView1_Sorting" 
                        onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" AllowSorting="true" AutoGenerateColumns="False" >
                       <HeaderStyle CssClass="GridHeader" />
                        <RowStyle  CssClass="GridEvenRow"/>
                        <AlternatingRowStyle CssClass="GridOddRow" />
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate" />
                <AlternatingRowStyle CssClass="alternate" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User">
                                <ItemTemplate>
                        <asp:Label ID="lblUser" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="Active">
                                <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-Mail" SortExpression="Email">
                                <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Pin" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblPin" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TaxSSNBrokerId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblTaxSSNBrokerId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="AgencyRoleId" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblAgencyRoleId" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField> 
                                               
                        <asp:TemplateField HeaderText="AgencyRole" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblAgencyRole" runat="server"  ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Fax" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblFax" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Company">
                                <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Login">
                                <ItemTemplate>
                        <asp:Label ID="lblLoginTime" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            
                               <asp:ImageButton ID="imgEdit" CommandName="Edit" CssClass="editGrid" ImageUrl="~/images/edit_icon.png" runat="server"  />
                        </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelte" CssClass="crossRemove" runat="server" ImageUrl="~/images/Cross.png" CommandName="Delete"/>
                        </ItemTemplate>
                        </asp:TemplateField>                         
                    </Columns>
                </asp:GridView>
           </div>
    </div>
    <div class="container" style="float:left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Add New User/ Edit Existing User"></asp:Label>
            </div>
        </div>
    
    <div class="formLineDivInv">
            <asp:Label text="User Type:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnUserType" runat="server" TabIndex="0" AutoPostBack="True" OnSelectedIndexChanged="DrpDwnUserType_OnTextChanged">
                </asp:DropDownList>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="User Name/E-Mail:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtUserName1" runat="server"></asp:TextBox>
    
    </div>
     <div class="formLineDivInv">
            <asp:Label text="E-Mail:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmailAdd" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="4 Number Pin:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="First Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Last Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Company:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Phone:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    
    </div>
     <div class="formLineDivInv">
            <asp:Label text="Tax Id/SSn:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtTaxId" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Agency Role:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnAgencyRole" runat="server" TabIndex="5">
                </asp:DropDownList>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Fax:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="WallEmailFrequency:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnWallEmailFrequency" Width="125px" runat="server">
            <asp:ListItem Value="1">60 minutes</asp:ListItem>
            <asp:ListItem Value="2">40 minutes</asp:ListItem>
            <asp:ListItem Value="3">20 minutes</asp:ListItem>
            <asp:ListItem Value="4">10 minutes</asp:ListItem>
            </asp:DropDownList>
    
    </div>
</div>
    <div id="tblFrmBroker" runat="server">
       
        <div class="formLineDivInv">
            <asp:Label ID="Label1" text="Address-I:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
         </div>    
       
        <div class="formLineDivInv">
            <asp:Label text="Address-II:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
    
        </div> 
         <div class="formLineDivInv">
            <asp:Label text="City:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCity" runat="server" TabIndex="5">
                </asp:DropDownList>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="State:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnState" runat="server" TabIndex="5">
                </asp:DropDownList>    
        </div>
         <div class="formLineDivInv">
            <asp:Label text="Zip Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>    
        </div>
   </div>
        
        <div class="formLineDivInv">
            <asp:Label text="Active:" runat="server"> </asp:Label>
            <asp:CheckBox ID="chkboxActive" runat="server" />
    
        </div>
        
    <div class="formLineDivInv">
                <span></span>
                <asp:Button ID="btnSave" CssClass="FormButtonImp"  runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" CssClass="FormButton" runat="server" Text="Reset" OnClick="btnReset_Click" />
    </div>
               
   
    
    
   
</asp:Content>