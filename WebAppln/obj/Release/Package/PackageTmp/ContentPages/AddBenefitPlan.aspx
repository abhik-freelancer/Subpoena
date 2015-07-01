<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="AddBenefitPlan.aspx.cs" Inherits="WebAppln.ContentPages.AddBenefitPlan" EnableEventValidation="false" %>

<%--<asp:Content ID="Content123" ContentPlaceHolderID="head" runat="server">
    <title>
       Benefit Plan
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label2" runat="server" Text="Add Benefit Plan"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>

<asp:Content ID="Content223" ContentPlaceHolderID="MainContent" runat="server">

    <div id="Div1" align="center" runat="server">
   
    <h3>
       <asp:Label BackColor ="Yellow" ID="lblSubheading" runat="server" Text="Insurance Carriers"></asp:Label>
    </h3>
    </div>

    <%-- <table runat="server">
        <tr>
            <td class="col1">Carrier:</td>
            <td class="col1">Plan:</td>
        </tr>--%>
     <div class="searchContainer">
            <div class="searchTextboxBlock">
                    <label class="fullLbl">Carrier:</label>
                    <asp:DropDownList ID="DrpDwnCarrier" runat="server" TabIndex="5">
                    </asp:DropDownList>
            </div>
            <div class="searchTextboxBlock">
                    <label class="fullLbl">Plan:</label>
                    <asp:DropDownList ID="DrpDwnPlan" runat="server" TabIndex="5">
                    </asp:DropDownList>
            </div>
             <%--<div class="searchTextboxBlock">
                    <label class="fullLbl">Currency:</label>
                    <asp:DropDownList ID="DrpDwnCurrency" runat="server" TabIndex="5">
                    </asp:DropDownList>
            </div>--%>
         <%--OnSelectedIndexChanged="PageSize_SelectedIndexChanged" DR--%>
            <div class="searchTextboxBlock">
                    <label class="fullLbl">Page Size:</label>
                    <asp:DropDownList ID="benefitPageSize" runat="server" AutoPostBack="True" >
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:DropDownList>
                </div>
            <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnExportxls" ValidationGroup="check" runat="server" Text="Export to Excel" OnClick="btnExportXls_Click"
                        CssClass="addCustomerBtn" />

            </div>
            <div class="searchTextboxBlockTransparent" >
                    <br />
                    <asp:Button ID="btnSearch1" ValidationGroup="check" runat="server" Text="Another Carrier" OnClick="btnSearchAnotherCarrier_Click"
                        CssClass="addCustomerBtn" />

                </div>   
             <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search Carrier" OnClick="btnSearchCarrier_Click"
                        CssClass="addCustomerBtn" />

              </div>
      
   <div class="Grid">
        
       
    <div class="gridOuterDiv">

                <%-- <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="5" 
                        onpageindexchanging="GridView1_PageIndexChanging"  onsorting="GridView1_Sorting" AllowSorting="True" AutoGenerateColumns="False" > --%>
                <%--<asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="grid-view" PageSize="10">--%>
               <%-- <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True"  
                        onrowdatabound="GridView1_RowDataBound" AllowSorting="True" AutoGenerateColumns="False" CssClass="grid-view" >--%>
                        <%--<HeaderStyle CssClass="header" />
                        <RowStyle  CssClass="RowStyle"/>
                        <RowStyle CssClass="RowStyle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                        <AlternatingRowStyle CssClass="alternate" />
                        <AlternatingRowStyle CssClass="alternate" />--%>
                    <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable"
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" onsorting="GridView1_Sorting" AllowSorting="true" AutoGenerateColumns="False" >

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
                    <Columns>
                           
                        <%--<asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Carrier" HeaderText="Carrier" SortExpression="Carrier" />
                        <asp:BoundField DataField="PlanType" HeaderText="Plan Type" SortExpression="PlanType"/>
                        <asp:BoundField DataField="PhysicalCoPay" HeaderText="PhysicalCoPay" />
                        <asp:BoundField DataField="IndividualDeductble" HeaderText="Individual Deductble" />
                        <asp:BoundField DataField="FamilyDeductble" HeaderText="Family Deductble " />
                        <asp:BoundField DataField="CoInsurance" HeaderText="CoInsurance" />
                        <asp:BoundField DataField="IndvOutofPocketMax" HeaderText="Indv. Out ofPocket Max" />
                        <asp:BoundField DataField="FamilyOutofPocketMax" HeaderText="Family Out of PocketMax" />
                        <asp:BoundField DataField="Network" HeaderText="Network" />
                        <asp:BoundField DataField="MRICTScam" HeaderText="MRICTScam" />
                        <asp:BoundField DataField="PrescriptionCopy" HeaderText="PrescriptionCopy" />
                        <asp:BoundField DataField="UrgentCareCopy" HeaderText="Urgent Care Copy" />
                        <asp:BoundField DataField="EmergencyRoomCopy" HeaderText="EmergencyRoomCopy" />
                        <asp:BoundField DataField="LifetimeMax" HeaderText="LifetimeMax" />--%>
                        
                        <asp:TemplateField HeaderText="ID" Visible="false">
                             <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Carrier" SortExpression="Carrier">
                                <ItemTemplate>
                        <asp:Label ID="lblCarrier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>                                                 
                        <asp:TemplateField HeaderText="Plan Type" SortExpression="PlanType">
                                <ItemTemplate>
                        <asp:Label ID="lblPlanType" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Currency" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Physical Co-pay">
                                <ItemTemplate>
                        <asp:Label ID="lblPhysicalCoPay" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Individual Deductble">
                                <ItemTemplate>
                        <asp:Label ID="lblIndividualDeductble" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Family Deductble">
                                <ItemTemplate>
                        <asp:Label ID="lblFamilyDeductble" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Co-Insurance (%)">
                                <ItemTemplate>
                        <asp:Label ID="lblCoInsurance" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Indv Out of Pocket Max">
                                <ItemTemplate>
                        <asp:Label ID="lblIndvOutofPocketMax" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Family Out of Pocket Max" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFamilyOutofPocketMax" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Network">
                                <ItemTemplate>
                        <asp:Label ID="lblNetwork" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MRICT Scam">
                                <ItemTemplate>
                        <asp:Label ID="lblMRICTScam" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Prescription Co-pay">
                                <ItemTemplate>
                        <asp:Label ID="lblPrescriptionCopy" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Urgent Care Co-pay">
                                <ItemTemplate>
                        <asp:Label ID="lblUrgentCareCopy" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emergency Room Co-pay">
                                <ItemTemplate>
                        <asp:Label ID="lblEmergencyRoomCopy" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Pharmacy Deductible" Visible="false">
                                <ItemTemplate>
                        <asp:Label ID="lblPharmacyDeductible" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LifetimeMax" Visible="false">
                                <ItemTemplate>
                        <asp:Label ID="lblLifetimeMax" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="ToWebbassedDoctor" Visible="false">
                                <ItemTemplate>
                        <asp:Label ID="lblToWebbassedDoctor" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PlanDescription" Visible="false">
                                <ItemTemplate>
                        <asp:Label ID="lblPlanDescription" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PlanCode" Visible="false">
                                <ItemTemplate>
                        <asp:Label ID="lblPlanCode" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" CommandName="Edit" ImageUrl="../images/editGrid.png" runat="server"  />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            
                            <asp:ImageButton ID="imgDelte" runat="server" ImageUrl="../images/cross-script.png" CommandName="Delete"/>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
           </div>
           </div>
    <div>
        <div class="formLineDivInv">
    
    <h3>
       <asp:Label BackColor ="Yellow" ID="Label1" runat="server" Text="Add a New Insurance Carrier"></asp:Label>
    </h3>
            </div>
     <div class="formLineDivInv">
            <asp:FileUpload ID="FileUpload1" runat="server"/>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="75px" />
    </div>
        
            
    <%--<asp:Button ID="btnNewCarrier" runat="server" Text="Add a Carrier Manually" OnClick="btnNewCarrier_Click" />  --%>             
     
     <div class="formLineDivInv">
            <asp:Label text="Carrier:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCarrier" runat="server"></asp:TextBox>    
     </div>
     <div class="formLineDivInv">
            <asp:Label text="Plan Type:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPlantyp" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Currency:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCurrency" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Physical Co-pay:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPhysicalCoPay" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label  text="Individual Deductble:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtIndividualDeductble" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Family Deductble:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFamilyDeductble" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Co-Insurance:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCoInsurance" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Indv Out of Pocket Max:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtIndvOutofPocketMax" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Family Out of Pocket Max:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFamilyOutofPocketMax" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Network:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtNetwork" runat="server"></asp:TextBox>   
    </div> 
            <div class="formLineDivInv">
            <asp:Label text="MRICT Scam:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtMRICTScam" runat="server"></asp:TextBox>    
    </div> 
        
     <div class="formLineDivInv">
                    <label class="fullLbl">Prescription Co-pay:</label>
                    <asp:DropDownList ID="PrescriptionCopay" runat="server" AutoPostBack="True" >
                        <asp:ListItem Value="1">$10</asp:ListItem>
                        <asp:ListItem Value="2">$20</asp:ListItem>
                        <asp:ListItem Value="3">$65</asp:ListItem>
                        <asp:ListItem Value="4">$200</asp:ListItem>
                    </asp:DropDownList>
    </div>
     <div class="formLineDivInv">
            <asp:Label  text="UrgentCare Co-pay:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtUrgentCareCopy" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="Emergency Room Co-pay:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmergencyRoomCopy" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="Pharmacy Deductible:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPharmacyDeductible" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="Lifetime Max:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLifetimeMax" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="To Webbassed Doctor:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtToWebbassedDoctor" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="Plan Description:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPlanDescription" runat="server"></asp:TextBox>   
    </div> 
     <div class="formLineDivInv">
            <asp:Label text="Plan Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtPlanCode" runat="server"></asp:TextBox>   
    </div> 
    <div class="formLineDivInv">    
    
                <asp:Button ID="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
    </div>
    </div>
    </div>
</asp:Content>
