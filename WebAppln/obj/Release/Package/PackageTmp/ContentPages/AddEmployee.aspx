<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="WebAppln.ContentPages.AddEmployee" EnableEventValidation="false" %>

<%--<asp:Content ID="Content122" ContentPlaceHolderID="head" runat="server">    
    <title>
        Add Employee
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label1" runat="server" Text="Add Employee"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content222" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-1.4.1-vsdoc.js"></script>
<script src="../Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="../Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtDOB.ClientID %>").dynDateTime({
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
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtSpouseDOB.ClientID %>").dynDateTime({
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
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtChld1Dob.ClientID %>").dynDateTime({
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

</script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtChld2Dob.ClientID %>").dynDateTime({
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




    
    <%--<h1>
       <asp:Label ID="lblHeader" runat="server" Text="Add Employee  "></asp:Label>
    </h1>--%>
    
    <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Carrier:</label>
                    <asp:TextBox ID="txtCarrier" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                    
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Group Name:</label>
                    <asp:TextBox ID="txtGroup" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                    
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Name:</label>
                    <asp:TextBox ID="txtName1" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                    
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Age:</label>
                    <asp:TextBox ID="txtAge" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                    
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Medical Tier:</label>
                    <asp:TextBox ID="txtBrokerName" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                    
                </div>
                
                <div class="searchTextboxBlockTransparent">
                    
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search" OnClick="btnSearchEmplyee_Click"
                        CssClass="addCustomerBtn" />

                </div>
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnExportxls" ValidationGroup="check" runat="server" Text="Export to Excel" OnClick="btnExportXls_Click"
                        CssClass="addCustomerBtn" />

                </div> 
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Page Size:</label>
                    <asp:DropDownList ID="empPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSize_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:DropDownList>
                </div>
    </div>
   
    <div class="Grid">
        
       
    <div class="gridOuterDiv">            


                <%--<asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" 
                        onpageindexchanging="GridView1_PageIndexChanging" onsorting="GridView1_Sorting" AllowSorting="True" AutoGenerateColumns="False" >--%>
                    <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" 
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" 
                        onrowdeleting="GridView1_RowDeleting" onsorting="GridView1_Sorting" AllowSorting="true" CssClass="gridtable" AutoGenerateColumns="False" >
                
                        <HeaderStyle CssClass="header" />
                        <RowStyle  CssClass="RowStyle"/>
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate"/>
                        <AlternatingRowStyle CssClass="alternate"/>
                    <Columns>
                        <%--<asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="DOB" HeaderText="DOB" />
                        <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age"/>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="" HeaderText="Medical Ter???" />
                        <asp:BoundField DataField="" HeaderText="Death Ter???" />
                        <asp:BoundField DataField="" HeaderText="Vision???" />
                        <asp:BoundField DataField="ZipCode" HeaderText="Zip" />
                        <asp:BoundField DataField="SpouseDOB" HeaderText="SpouseDOB" />
                        <asp:BoundField DataField="SpouseAge" HeaderText="SpouseAge" />
                        <asp:BoundField DataField="ChildCount" HeaderText="Child Count" />
                        <asp:BoundField DataField="Child1DOB" HeaderText="Child1 DOB" />
                        <asp:BoundField DataField="Child1Age" HeaderText="Child1 Age" />
                        <asp:BoundField DataField="Child2DOB" HeaderText="Child2 DOB" />
                        <asp:BoundField DataField="Child2Age" HeaderText="Child2 Age" />
                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                        <asp:BoundField DataField="Salary" HeaderText="Salary" />
                        <asp:BoundField DataField="SalaryType" HeaderText="SalaryT ype"/>--%>
                        
                        <asp:TemplateField HeaderText="Id" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GroupID" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblGroupID" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GrpName" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblGrpName" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                        <asp:Label ID="lblDOB" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GenId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblGenId" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="SSN" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblSSN" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medical Tier">
                                <ItemTemplate>
                        <asp:Label ID="lblMedicalTier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dental Tier">
                                <ItemTemplate>
                        <asp:Label ID="lblDeathTier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vision Tier">
                                <ItemTemplate>
                        <asp:Label ID="lblVisionTier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zip">
                                <ItemTemplate>
                        <asp:Label ID="lblZipcode" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spouse DOB">
                                <ItemTemplate>
                        <asp:Label ID="lblSpouseDOB" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spouse Age">
                                <ItemTemplate>
                        <asp:Label ID="lblSpouseAge" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child Count">
                                <ItemTemplate>
                        <asp:Label ID="lblChildCount" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SpouseSSN" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblSpouseSSN" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child1 DOB">
                                <ItemTemplate>
                        <asp:Label ID="lblChild1DOB" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child1 Age">
                                <ItemTemplate>
                        <asp:Label ID="lblChild1Age" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child1SSN" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblChild1SSN" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child2 DOB">
                                <ItemTemplate>
                        <asp:Label ID="lblChild2DOB" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child2 Age">
                                <ItemTemplate>
                        <asp:Label ID="lblChild2Age" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child2SSN" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblChild2SSN" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Corba" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblCorba" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>                      
                        
                        <asp:TemplateField HeaderText="Occupation">
                                <ItemTemplate>
                        <asp:Label ID="lblOccupation" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary">
                                <ItemTemplate>
                        <asp:Label ID="lblSalary" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SalaryType">
                                <ItemTemplate>
                        <asp:Label ID="lblSalaryType" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ModeofSalID" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblModeofSalID" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ModeofSal" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblModeofSal" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField> 
                                                
                        <asp:TemplateField HeaderText="Address1" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblAddress1" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address2" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblAddress2" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                                               
                        <asp:TemplateField HeaderText="CityId" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblCityId" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="CityName" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblCityName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="StateId" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="StateName" Visible="False">
                                <ItemTemplate>
                        <asp:Label ID="lblStateName" runat="server"  ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" CommandName="Edit" ImageUrl="~/images/edit_icon.png" runat="server"  />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelte" runat="server" ImageUrl="~/images/Cross.png" CommandName="Delete"/>
                        </ItemTemplate>
                        </asp:TemplateField>
                                                
                    </Columns>
                </asp:GridView>            
    </div>
    </div>
    
    <div>
    <h3>
       <asp:Label BackColor ="Yellow" ID="lblSubheading" runat="server" Text="Add Employee"></asp:Label>
    </h3>    
         <%--<asp:Button ID="btnAddEmployee" CssClass="button" runat="server" Text="Add" OnClick="btnAddEmplyee_Click" />--%>
         <%--<div class="searchTextboxBlockTransparent">
                    <asp:Button ID="btnAddEmployee" ValidationGroup="check" runat="server" Text="Add" OnClick="btnAddEmplyee_Click"
                        CssClass="addCustomerBtn" />
         </div>--%>
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="75px" />
         
         <div class="formLineDivInv">
                <asp:Label text="Group Name:" runat="server"> </asp:Label>
                <asp:DropDownList ID="DrpDwnGroup" runat="server" TabIndex="5">
                </asp:DropDownList>     
        </div> 
        <div class="formLineDivInv">
                <asp:Label text="Last Name:" runat="server"> </asp:Label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        
        </div>
        <div class="formLineDivInv">
                <asp:Label text="First Name:" runat="server"> </asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        
        </div>
        <div class="formLineDivInv">
                <asp:Label text="DOB:" runat="server"> </asp:Label>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                <img src="../Images/calender.png"/>
        </div>
        <div class="formLineDivInv">
                <asp:Label text="Age:" runat="server"> </asp:Label>
                <asp:TextBox ID="txtAge1" runat="server"></asp:TextBox>
        </div>
        <div class="formLineDivInv">
                <asp:Label text="Gender:" runat="server"> </asp:Label>
                <asp:DropDownList ID="DrpDwnGender" runat="server" TabIndex="5">
                    </asp:DropDownList>     
        </div>
        <div class="formLineDivInv">
                 <asp:Label text="SSN:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtSSN" runat="server"></asp:TextBox>  
        </div>
        <div class="formLineDivInv">
                 <asp:Label text="Spouse DOB:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtSpouseDOB" runat="server"></asp:TextBox>
                 <img src="../Images/calender.png"/>  
        </div>
        <div class="formLineDivInv">
                 <asp:Label text="Spouse Age:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtSpouseAge" runat="server"></asp:TextBox>  
        </div>
        <div class="formLineDivInv">
                 <asp:Label text="Child Count:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtChildCount" runat="server" OnTextChanged="txtChildCount_TextChanged"></asp:TextBox>  
        </div>
        <div class="formLineDivInv">
                 <asp:Label text="Spouse SSN:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtSpouseSSN" runat="server"></asp:TextBox>  
        </div>


        <div class="formLineDivInv">
                 <asp:Label text="Child1 DOB:" runat="server"> </asp:Label>
                 <asp:TextBox ID="txtChld1Dob" runat="server"></asp:TextBox>
                 <img src="../Images/calender.png"/> 
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Child1 Age:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtChld1Age" runat="server"></asp:TextBox>
        </div> 
        <div class="formLineDivInv">
            <asp:Label text="Child1 SSN:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtChld1Ssn" runat="server"></asp:TextBox>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Child2 DOB:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtChld2Dob" runat="server"></asp:TextBox>
            <img src="../Images/calender.png"/>
        </div> 
        <div class="formLineDivInv">
            <asp:Label text="Child2 Age:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtChld2Age" runat="server"></asp:TextBox>
        </div> 
        <div class="formLineDivInv">
            <asp:Label text="Child2 SSN:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtChld2Ssn" runat="server"></asp:TextBox>
    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="CORBA:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCorba" runat="server"></asp:TextBox>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Occupation:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Salary:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Salary Type:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSalTyp" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Mode of Salary:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnModeofSalary" runat="server" TabIndex="5">
                </asp:DropDownList>     
           
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Medical Tier:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtMedicalTier" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Dental Tier:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtDentalTier" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Vision Tier:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtVisionTier" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Address-I:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAdd1" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Address-II:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAdd2" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="City:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCity" runat="server" TabIndex="15">
                </asp:DropDownList>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="State:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnState" runat="server" TabIndex="16">
                </asp:DropDownList>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Zip Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>    
    </div> 
    <div class="formLineDivInv"> 
                <asp:Button ID="btnSave" cssclass="button" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" cssclass="button" Text="Reset" OnClick="btnReset_Click" />
     </div> 
    
    </div>
</asp:Content>
