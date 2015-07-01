<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="OtherUsers.aspx.cs" 
Inherits="Website.Pages.OtherUsers" Title=":: PageforOtherUsers::" %>

    
<asp:Content ID="Content222" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container" style="float:left">
        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Display Subpoena"></asp:Label>
            </div>
        </div>
    <%--<div class="main_box_in">
        <span class="Sectionheader">Display Subpoena</span>
    </div>--%>
    
    <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Case Id:</label>
                    <asp:TextBox ID="txtCaseId" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Official:</label>
                    <asp:TextBox ID="txtOfficial" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Status:</label>
                    <asp:TextBox ID="txtStatus" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div>
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Detactive:</label>
                    <asp:TextBox ID="txtDetactive" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div>
                 <div class="searchTextboxBlock">
                    <label class="fullLbl">Date:</label>
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="50" Width="100%"></asp:TextBox>                   
                </div> 
                
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnSearch" ValidationGroup="check" runat="server" Text="Search Subpoena" OnClick="btnSubmit_Click"
                        CssClass="addCustomerBtn" />

                </div>
                 </div>
                <div>
                
                <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnExportxls" ValidationGroup="check" runat="server" Text="Export to Excel" OnClick="btnExportxls_Click"
                        CssClass="addCustomerBtn" />
                </div>                
                
                    <div class="searchTextboxBlock">
                    <label class="fullLbl">Page Size:</label><asp:DropDownList ID="PageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSize_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:DropDownList>
               </div>                
                    
                </div>
           
        
     <div class="Grid" id="Div1" runat="server"> 
            <div class="gridOuterDiv"> 
                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"   CssClass="gridtable"  AllowPaging="True" PageSize="10" 
                onpageindexchanging="GridView1_PageIndexChanging" onsorting="GridView1_Sorting" AllowSorting="true" >
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
                        <asp:TemplateField HeaderText="Subpoena Frm Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubpoenaFrmId" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            
                        <asp:TemplateField HeaderText="Case ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblCaseId" runat="server" ></asp:Label>
                                </ItemTemplate>  
                        </asp:TemplateField>   
                                              
                        <asp:TemplateField HeaderText="State ID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            
                        <asp:TemplateField HeaderText="State Name" SortExpression="StateName">
                                <ItemTemplate>
                                    <asp:Label ID="lblStateName" runat="server" ></asp:Label>
                                </ItemTemplate>   
                          </asp:TemplateField>  
                                   
                        <asp:TemplateField HeaderText="County Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblCountyid" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                         </asp:TemplateField>
                          
                        <asp:TemplateField HeaderText="Cunty Name" SortExpression="CuntyName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCountyName" runat="server" ></asp:Label>
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Official Name" SortExpression="OfficialName">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficialName" runat="server" ></asp:Label>
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Detective Name" SortExpression="DetectiveName">
                                <ItemTemplate>
                                    <asp:Label ID="lbldeDetetiveName" runat="server" ></asp:Label>
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" ></asp:Label>
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" ></asp:Label>
                                </ItemTemplate>              
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PDFPath">
                                <ItemTemplate>
                                    <asp:Label ID="lblPDFPath" runat="server" ></asp:Label>
                                </ItemTemplate>              
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Content">
                                <ItemTemplate>
                                    <asp:Label ID="lblContent" runat="server" ></asp:Label>
                                </ItemTemplate>              
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RepresentativeSig">
                                <ItemTemplate>
                                    <asp:Label ID="lblRepresentativeSig" runat="server" ></asp:Label>
                                </ItemTemplate>              
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="SupervisorSig">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupervisorSig" runat="server" ></asp:Label>
                                </ItemTemplate>              
                        </asp:TemplateField>

                        <%--<asp:BoundField DataField="CaseId" HeaderText="Case ID" />
                        <asp:BoundField DataField="StateId" HeaderText="State" />
                        <asp:BoundField DataField="OfficialName" HeaderText="Official Name" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="" HeaderText="Subpoena" />--%>
                       <%-- <asp:TemplateField HeaderText="Edit">
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
    
    </div>
</asp:Content>