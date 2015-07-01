<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddClientGroup.aspx.cs" 
    Inherits="WebAppln.ContentPages.AddClientGroup" EnableEventValidation="false" Title=":: AddClient Group ::" %>


<%--    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        Add Client Group
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label1" runat="server" Text="Add Client Group"></asp:Label>
    </h1>
    
    </div>
    </asp:Content>--%>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1-vsdoc.js"></script>
    <script src="../Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtEnDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
    </script>
    
    <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Group Name:</label>
                    <asp:TextBox ID="txtGroupName" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Nature of Business:</label>
                    <asp:TextBox ID="txtNatureofBsns" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search" OnClick="btnSearchGroup_Click"
                        CssClass="addCustomerBtn" />
                </div>
        </div>
                        
               
     <h2>
       <asp:Label BackColor="RosyBrown"  ID="lblGroupDetails" runat="server" Text="Group Details"></asp:Label>
    </h2>
 <%--   <table id="tblGrid" runat="server">
        <tr>
            <td><asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>--%>
                
    <div class="Grid">       
       
    <div class="gridOuterDiv">       
                 <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable"
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
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Group Name" SortExpression="GrpName">
                            <ItemTemplate>
                                <asp:Label ID="lblGrpName" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 

                        <%--<asp:TemplateField HeaderText="Address1">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress1" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> --%>

                        <asp:TemplateField HeaderText="Nature of Business" SortExpression="NatureofBusiness">
                            <ItemTemplate>
                                <asp:Label ID="llbNatureofBusiness" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="EIN">
                            <ItemTemplate>
                                <asp:Label ID="lblEN" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="NAJC/SIC Code">
                            <ItemTemplate>
                                <asp:Label ID="lblNacSscCode" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Requested Eff Date">
                            <ItemTemplate>
                                <asp:Label ID="lblRequestEnDt" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                        <%-- <asp:ImageField DataImageUrlField = "CompanyLogo" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>
                        <asp:TemplateField HeaderText="Logo" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientLogo" runat="server" ></asp:Label>
                                
                                </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField  ControlStyle-Width = "50" ControlStyle-Height = "50" HeaderText="Logo">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server"
                                 ImageUrl = '<%# Eval("ClientLogo", GetUrl("{0}")) %>' Height="50px" Width="50px" />
                            </ItemTemplate>
                             <ItemStyle Height="50px" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address1" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress1" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Address2" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress2" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="City ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcityID" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCityName" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="StateId" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="State" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblStateName" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="ZipCode" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblZipCode" runat="server" ></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField> 
                        
                        
                                                
                        
                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                               <asp:ImageButton ID="imgEdit" CommandName="Edit" CssClass="editGrid"  ImageUrl="../images/edit_icon.png" runat="server"  />
                        </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelte" runat="server" CssClass="crossRemove" ImageUrl="../images/Cross.png" CommandName="Delete"/>
                        </ItemTemplate>
                        </asp:TemplateField>                     
                 </Columns>
                </asp:GridView>
              </div> 
    <div>
    <h2>
       <asp:Label BackColor="RosyBrown"  ID="lblSubheading" runat="server" Text="Add Group"></asp:Label>
    </h2>

    <div class="searchContainer">

                <asp:Button ID="btnAddNew" ValidationGroup="check" runat="server" Text="New Add" formnovalidate
                    CssClass="addCustomerBtn" OnClick="btnAddGroup_Click" />
    </div>
           
    <div class="formLineDivInv">
            <asp:Label text="Group Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtGrpName" runat="server"></asp:TextBox>
            <%--<myajax:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtBoxNoSearch" />--%>
    
    </div>
        <div class="formLineDivInv">
            <asp:Label text="Nature of Business:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtNatureofBsns1" runat="server"></asp:TextBox>
        </div>

         <div class="formLineDivInv">
            <asp:Label text="EIN:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEn" runat="server"></asp:TextBox>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="NAJC/SIC Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtNacSsc" runat="server"></asp:TextBox>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Requested Eff Date:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEnDate" runat="server"></asp:TextBox>
             <img src="../Images/calender.png"/>
        </div>
            
        <div class="formLineDivInv">
             <asp:Label text="Client Logo:" runat="server"> </asp:Label>
             <asp:TextBox ID="txtLogo" runat="server"></asp:TextBox>  
    </div>      
    <div class="formLineDivInv">
             <asp:image  ID="Logo" runat="server" Height="80px" Width="94px"/>
                <asp:FileUpload ID="FileUpload1" runat="server"/>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="75px" />
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
             <asp:Label text="Zip Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
    </div>     
   <div class="formLineDivInv"> 
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="bntReset" CssClass="button" runat="server" Text="Reset" OnClick="btnReset_Click" />
   </div>  
           
            
    
   

    </div>
        </div>
</asp:Content>

