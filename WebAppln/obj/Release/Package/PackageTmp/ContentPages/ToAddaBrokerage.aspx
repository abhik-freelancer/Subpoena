<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ToAddaBrokerage.aspx.cs" Inherits="WebAppln.ContentPages.ToAddaBrokerage" EnableEventValidation="false" %>

<%--<asp:Content ID="Content12" ContentPlaceHolderID="head" runat="server">
    <title>
        Add Brokerage
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label1" runat="server" Text="Add Brokerage"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Brokerage Name:</label>
                    <asp:TextBox ID="txtBrokerName" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Tax ID:</label>
                    <asp:TextBox ID="txtTaxId" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search" OnClick="btnSearchBrokerage_Click"
                        CssClass="addCustomerBtn" />

                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnExportxls" ValidationGroup="check" runat="server" Text="Export to Excel" OnClick="btnExportXls_Click"
                        CssClass="addCustomerBtn" />

                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Page No:</label>
                    <asp:DropDownList ID="brkPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSize_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:DropDownList>
                </div>
    </div>
    <div class="Grid">
        
       
    <div class="gridOuterDiv">

                <asp:GridView ID="GridView1" runat="server"   Width="100%" BorderStyle="None" BorderWidth="0"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable"
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" onsorting="GridView1_Sorting" AllowSorting="true" AutoGenerateColumns="False" >

                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle  CssClass="GridEvenRow"/>
                        <AlternatingRowStyle CssClass="GridOddRow" />
                          <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate" />
                        <AlternatingRowStyle CssClass="alternate" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                             <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                       <%-- <asp:ImageField DataImageUrlField = "CompanyLogo" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>
                        <asp:TemplateField HeaderText="Logo" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyLogo" runat="server" ></asp:Label>
                                
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField  ControlStyle-Width = "40" ControlStyle-Height = "40" HeaderText="Logo">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server"
                                 ImageUrl = '<%# Eval("CompanyLogo", GetUrl("{0}")) %>' Height="101px" Width="121px" />
                            </ItemTemplate>
                             <ItemStyle Height="25px" Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="ContactName">
                                <ItemTemplate>
                        <asp:Label ID="lblContactName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TaxID/SSN">
                                <ItemTemplate>
                        <asp:Label ID="lblTaxSSN" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                        <asp:Label ID="lblContactPhone" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address-I">
                                <ItemTemplate>
                        <asp:Label ID="lblAddr1" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address-II">
                                <ItemTemplate>
                        <asp:Label ID="lblAddr2" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="City" SortExpression="CityName">
                                <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="StateId" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="State" SortExpression="StateName">
                                <ItemTemplate>
                        <asp:Label ID="lblStateName" runat="server"  ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zip">
                                <ItemTemplate>
                        <asp:Label ID="lblZip" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="URL">
                                <ItemTemplate>
                        <asp:Label ID="lblCompanyUrl" runat="server" ></asp:Label>
                                </ItemTemplate><%# Bind("CompanyUrl") %>
                        </asp:TemplateField>--%> 
                        <asp:TemplateField HeaderText="URL">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlContro" runat="server" NavigateUrl='<%# Eval("CompanyUrl", GetUrl("{0}")) %>'
                                        Text='<%# Bind("CompanyUrl") %>'></asp:HyperLink>
                                </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" CommandName="Edit" CssClass="editGrid" ImageUrl="~/images/edit_icon.png" runat="server"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelte" runat="server" CssClass="crossRemove" ImageUrl="~/images/delet_icon.png" CommandName="Delete"/>
                        </ItemTemplate>
                    </asp:TemplateField>


                        <%--<asp:BoundField DataField="CompanyLogo" HeaderText="Logo" />
                        <asp:BoundField DataField="ContactName" HeaderText="Name" />
                        <asp:BoundField DataField="TaxSSN" HeaderText="TaxID/SSN" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone" />
                        <asp:BoundField DataField="Addr1" HeaderText="Address-I" />
                        <asp:BoundField DataField="Addr2" HeaderText="Address-II" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="StateID" HeaderText="State" />
                        <asp:BoundField DataField="Zip" HeaderText="Zip" />
                        <asp:BoundField DataField="CompanyUrl" HeaderText="URL" />--%>
                    </Columns>
                </asp:GridView>
            
    </div>



    </div>
    <div>
        <div class="row">
            <div class="col-sm-12 Pageheader">
                <asp:Label ID="lblSubheading" runat="server" Text="Add a Brokerage"></asp:Label>
            </div>
        </div>
    <div class="formLineDivInv">
            <asp:Label text="Contact Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>    
    </div>
        <div class="formLineDivInv">
            <asp:Label text="Tax ID/SSN:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtTaxSsn" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Contact Phone:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    
    </div> 
    <div class="formLineDivInv">
            <asp:Label text="Address-I:" runat="server"> </asp:Label>
           <asp:TextBox ID="txtAddr1" runat="server"></asp:TextBox>
    
    </div>      
      <div class="formLineDivInv">
            <asp:Label text="Address-II:" runat="server"> </asp:Label>
           <asp:TextBox ID="txtAddr2" runat="server"></asp:TextBox>
    
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
            <asp:Label text="Zip:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>   
    </div> 
      <div class="formLineDivInv">
             <asp:Label text="Company Logo:" runat="server"> </asp:Label>
             <asp:TextBox ID="txtLogo" runat="server"></asp:TextBox>  
    </div>      
    <div class="formLineDivInv">
            <span></span>
             <asp:image  ID="Logo" runat="server" Height="80px" Width="94px"/>
                <asp:FileUpload ID="FileUpload1" runat="server"/>
        <span></span>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="FormButton" OnClick="btnUpload_Click" Width="75px" />
    </div>  
       <div class="formLineDivInv">
             <asp:Label text="Company URL:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
    </div>   
     <div class="formLineDivInv">           
           <span></span>
    
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="FormButtonImp" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="FormButton" />
               
            
    
   </div>
<%--  </form>--%>
  </div>
</asp:Content>
