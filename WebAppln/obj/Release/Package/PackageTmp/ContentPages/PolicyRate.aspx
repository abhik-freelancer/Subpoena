<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="PolicyRate.aspx.cs" Inherits="WebAppln.ContentPages.PolicyRate" %>



<asp:Content ID="Content202" ContentPlaceHolderID="MainContent" runat="server">


  <h2>
       <asp:Label ID="lblHeader" runat="server" Text="Policy Rate"></asp:Label>
  </h2>
  
  <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Carrier:</label>
                    <asp:DropDownList ID="DrpDwnCarrier" runat="server" TabIndex="0">
                        </asp:DropDownList>
                </div>
                <div class="searchTextboxBlock">        
         
                    <label class="fullLbl">State:</label>
                    <asp:DropDownList ID="DrpDwnState" runat="server" TabIndex="2">
                        </asp:DropDownList>
                 </div>
                 <div class="searchTextboxBlock">
                    <label class="fullLbl">County:</label>
                    <asp:DropDownList ID="DrpDwnCounty" runat="server" TabIndex="5">
                        </asp:DropDownList>
                 </div>
                 
                 <div class="searchTextboxBlock">
                    <label class="fullLbl">From:</label>
                    <asp:TextBox ID="txtFrom" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                 </div>
                  <div class="searchTextboxBlock">
                    <label class="fullLbl">To:</label>
                    <asp:TextBox ID="txtTo" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                 </div>
                 <div class="searchTextboxBlock">
                    <label class="fullLbl">Factor:</label>
                    <asp:TextBox ID="txtFactor" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                 </div>
         </div>
         <div class="formLineDivInv"> 
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        
 </div>
 
  <div class="Grid">
    <div class="gridOuterDiv">
                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid-view">--%>
                <%--<asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True"  
                        onrowdatabound="GridView1_RowDataBound" AllowSorting="True" AutoGenerateColumns="False" PageSize="10" onpageindexchanging="GridView1_PageIndexChanging CssClass="grid-view" >
                     --%>
                <%--<asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True"  
                      onrowdatabound="GridView1_RowDataBound"  AllowSorting="True" AutoGenerateColumns="False" CssClass="grid-view" >
                    
                    <HeaderStyle CssClass="header" />
                    <RowStyle CssClass="normal" />
                    <AlternatingRowStyle CssClass="alternate" />--%>
                    <%--<asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" 
                        onrowdatabound="GridView1_RowDataBound"  
                         AutoGenerateColumns="False" >--%>
                     <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True"  CssClass="gridtable"
                      onrowdatabound="GridView1_RowDataBound"  AllowSorting="True" AutoGenerateColumns="False" >
                
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
                        <asp:TemplateField HeaderText="Id" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CarrierId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblCarrierId" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Carrier">
                                <ItemTemplate>                        
                        <asp:Label ID="lblCarrier" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PlanCode" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblPlanCode" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Plan" Visible="False">
                                <ItemTemplate>                        
                        <asp:Label ID="lblPlan" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="StateId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="StateName">
                                <ItemTemplate>                        
                        <asp:Label ID="lblStateName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="CountyId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblCountyId" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CountyName">
                                <ItemTemplate>                        
                        <asp:Label ID="lblCountyName" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="From">
                                <ItemTemplate>
                        <asp:Label ID="lblFrom" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To">
                                <ItemTemplate>
                        <asp:Label ID="lblTo" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Factor">
                                <ItemTemplate>
                        <asp:Label ID="lblFactor" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Adjust">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgIncrease" CommandName="Increase" ImageUrl="~/images/Increase.png" runat="server"  />
                            <asp:ImageButton ID="imgDecrease" CommandName="Decrease" ImageUrl="~/images/Decrease.png" runat="server"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                                
                    </Columns>
                </asp:GridView>
      </div>
      </div> 
      <div>
      <h3>
       <asp:Label ID="Label1" runat="server" Text="Rate"></asp:Label>
      </h3>
      
      <div class="searchContainer">
                    <div class="searchTextboxBlock">
                        <label class="fullLbl">Carrier:</label>
                        <asp:DropDownList ID="DrpDwnCarrierR" runat="server" TabIndex="0">
                            </asp:DropDownList>
                    </div>
                    <div class="searchTextboxBlock">        
             
                        <label class="fullLbl">State:</label>
                        <asp:DropDownList ID="DrpDwnStateR" runat="server" TabIndex="2">
                            </asp:DropDownList>
                     </div>
                     <div class="searchTextboxBlock">
                        <label class="fullLbl">County:</label>
                        <asp:DropDownList ID="DrpDwnCountyR" runat="server" TabIndex="5">
                            </asp:DropDownList>
                     </div>
                     
                     <div class="searchTextboxBlock">
                        <label class="fullLbl">From:</label>
                        <asp:TextBox ID="txtFromR" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                     </div>
                      <div class="searchTextboxBlock">
                        <label class="fullLbl">To:</label>
                        <asp:TextBox ID="txtToR" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                     </div>
                     <div class="searchTextboxBlock">
                        <label class="fullLbl">Rate:</label>
                        <asp:TextBox ID="txtRateR" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                     </div>
             
    
    
    
    
             <div class="formLineDivInv"> 
                    <asp:Button ID="btnSaveR" runat="server" Text="Save" OnClick="btnSaveR_Click" />
                    <asp:Button ID="btnResetR" runat="server" Text="Reset" OnClick="btnResetR_Click" />
            
            </div>
                  <asp:FileUpload ID="FileUpload1" runat="server"/>
                  <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="75px" />
        
   </div>
   
   <div class="Grid">
    <div class="gridOuterDiv">
    <asp:GridView ID="GridView2" runat="server"   Width="100%"  EnableModelValidation="True"  
                      onrowdatabound="GridView2_RowDataBound"  AllowSorting="True" AutoGenerateColumns="False" CssClass="gridtable" >
                
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
                        <asp:TemplateField HeaderText="Id" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblIdR" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CarrierId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblCarrierIdR" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Carrier">
                                <ItemTemplate>                        
                        <asp:Label ID="lblCarrierR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PlanCode" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblPlanCodeR" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Plan" Visible="False">
                                <ItemTemplate>                        
                        <asp:Label ID="lblPlanR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="StateId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblStateIdR" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="StateName">
                                <ItemTemplate>                        
                        <asp:Label ID="lblStateNameR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="CountyId" Visible="False">
                             <ItemTemplate>
                        <asp:Label ID="lblCountyIdR" runat="server" ></asp:Label>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CountyName">
                                <ItemTemplate>                        
                        <asp:Label ID="lblCountyNameR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="From">
                                <ItemTemplate>
                        <asp:Label ID="lblFromR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To">
                                <ItemTemplate>
                        <asp:Label ID="lblToR" runat="server" ></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                        <asp:Label ID="lblRateR" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Adjust">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgIncrease" CommandName="Increase" ImageUrl="~/images/Increase.png" runat="server"  />
                            <asp:ImageButton ID="imgDecrease" CommandName="Decrease" ImageUrl="~/images/Decrease.png" runat="server"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                                
                    </Columns>
                </asp:GridView>
    
    
    </div>
    </div>
       
     
      
      
      


    </div>
</asp:Content>
