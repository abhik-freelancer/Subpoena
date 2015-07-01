<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="VisionPlan.aspx.cs" 
            Inherits="WebAppln.ContentPages.VisionPlan" EnableEventValidation="false" %>



<%--<asp:Content ID="Content12" ContentPlaceHolderID="head" runat="server">
    <title>
        Vision Insurance Rate
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="Label3" runat="server" Text="Vision Insurance Rate"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="searchContainer">
       <div class="searchTextboxBlock">
           <label class="fullLbl">Carrier:</label>
                    <asp:DropDownList ID="DrpDwnCarrierSearch" runat="server" TabIndex="0">
                    </asp:DropDownList>
       </div>
        <div class="searchTextboxBlock">
                    <label class="fullLbl">Plan:</label>
                    <asp:DropDownList ID="DrpDwnPlanSearch" runat="server" TabIndex="1">
                    </asp:DropDownList>                    
        </div>
        <div class="searchTextboxBlock">
                    <label class="fullLbl">Page Size:</label>
                    <asp:DropDownList ID="PageSize" runat="server">
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
        <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch1" ValidationGroup="check" runat="server" Text="Another Carrier" OnClick="btnSearchAnotherCarrier_Click"
                        CssClass="addCustomerBtn" />

        </div>
        <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search Carrier" OnClick="btnSearchCarrier_Click"
                        CssClass="addCustomerBtn" />

              </div>         
     </div>
   
   <div class="Grid">
        <div class="gridOuterDiv">
                    
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
                           
                                                
                        <asp:TemplateField HeaderText="ID" Visible="false">
                             <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CarrierID" Visible="false">
                             <ItemTemplate>
                                    <asp:Label ID="lblCarrierID" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Carrier" SortExpression="Carrier">
                                <ItemTemplate>
                        <asp:Label ID="lblCarrier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="PlanID">
                             <ItemTemplate>
                                    <asp:Label ID="lblPlanID" runat="server" ></asp:Label>
                             </ItemTemplate>                       
                        </asp:TemplateField>--%>                                                 
                        <asp:TemplateField HeaderText="Plan Code" SortExpression="PlanType">
                                <ItemTemplate>
                        <asp:Label ID="lblPlanCode" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lens:Single Vision" >
                                <ItemTemplate>
                                    <asp:Label ID="lblLensSingleVision" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lens: Bifocal">
                                <ItemTemplate>
                        <asp:Label ID="lblLensBifocal" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lens: Trifocal">
                                <ItemTemplate>
                        <asp:Label ID="lblLensTrifocal" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lens: Lenticular">
                                <ItemTemplate>
                        <asp:Label ID="lblLensLenticular" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Contact Lenses Allowence">
                                <ItemTemplate>
                        <asp:Label ID="lblContactLenseAllowence" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Farmes Allowence">
                                <ItemTemplate>
                        <asp:Label ID="lblFarmesAllowence" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Exams Copay" >
                                <ItemTemplate>
                                    <asp:Label ID="lblExamsCopay" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IDD" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDD" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="VisionPlanId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblVisionPlanId" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployee" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee+Spouse">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeSpouse" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee+Children">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeChildren" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Family">
                                <ItemTemplate>
                                    <asp:Label ID="lblFamily" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Monthly">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalMonthly" runat="server" ></asp:Label>
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
       <asp:Label BackColor ="Yellow" ID="Label1" runat="server" Text="Vision Plan Update"></asp:Label>
    </h3>
        <asp:FileUpload ID="FileUpload1" runat="server"/>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="75px" />
        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"></asp:GridView>
    
   <div class="formLineDivInv">
            <asp:Label text="Carrier:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCarrier" runat="server" TabIndex="0">
            </asp:DropDownList>    
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Plan Code:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnPlan" runat="server" TabIndex="1">
            </asp:DropDownList>
        </div>
        <div class="formLineDivInv">
            <asp:Label text="Lens: SingleVision:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLensSingleVision" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Lens: Bifocal:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLensBifocal" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Lens: Trifocal:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLensTrifocal" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Lens: Lenticular:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtLensLenticular" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Contact Lense Allowence:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtContactLenseAllowence" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="FarmesAllowence:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFarmesAllowence" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Exams Copay:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtExamsCopay" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">  
    
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
     </div>
  </div>  
    <%--</form>--%>
  <div>
    <h3>
       <asp:Label BackColor ="Yellow" ID="Label2" runat="server" Text="Vision Plan Rate Update"></asp:Label>
    </h3>
    
    
    <div class="formLineDivInv">
            <asp:Label ID="Label3" text="Carrier:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCarrierD" runat="server" TabIndex="0">
            </asp:DropDownList>    
        </div>
        <div class="formLineDivInv">
            <asp:Label ID="Label4" text="Plan Code:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnPlanD" runat="server" TabIndex="1">
            </asp:DropDownList>
        </div>
        <div class="formLineDivInv">
            <asp:Label ID="Label5" text="Employee:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label ID="Label6" text="Employee+Spouse:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmployeeSpouse" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label ID="Label7" text="Employee+Child(ren):" runat="server"> </asp:Label>
            <asp:TextBox ID="txtEmployeeChildren" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv">
            <asp:Label ID="Label8" text="Family:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>    
        </div>
        <div class="formLineDivInv"> 
        
            <asp:Button ID="btnSaveD" runat="server" Text="Save" OnClick="btnSaveD_Click" />
            <asp:Button ID="btnResetD" runat="server" Text="Reset" OnClick="btnResetD_Click" />
       </div>
    </div>
    
</asp:Content>
