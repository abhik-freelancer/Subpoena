<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="GroupCreation1.aspx.cs" 
Inherits="Website.Pages.GroupCreation1" Title=":: Group Creation ::" %>
<%--<asp:Content ID="Content12" ContentPlaceHolderID="head" runat="server">
    <title>
        Group Creation
    </title>
    <div class="heading1">
	<h1>
       <asp:Label ID="lblHeader" runat="server" Text="Group Creation"></asp:Label>
    </h1>
    
    </div>
</asp:Content>--%>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">

<%--<div id="Div1321" align="center" runat="server">--%>
    <div class="container" style="float:left">

        <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="Create Group"></asp:Label>
            </div>
        </div>
    <%--<div class="main_box_in">
        <span class="Sectionheader">Create Group</span>
    </div>--%>
   
    <div class="formLineDivInv">
            <asp:Label text="Group Name:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Address1:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Address2:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="City:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="State:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DropDownState" runat="server" TabIndex="5">
                    </asp:DropDownList>    
    </div>
    <div class="formLineDivInv">
            <asp:Label text="Zip Code:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtZipcode" runat="server"></asp:TextBox>    
    </div>
     <div class="formLineDivInv">
            <asp:Label text="Country:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DropDownCountry" runat="server" TabIndex="5">
                    </asp:DropDownList>    
    </div>
     <div class="formLineDivInv"><label></label>
         
                    <asp:Button ID="btnSubmit1" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="btnSubmit1_Click" />
                    <asp:Button ID="btnReset" CssClass="FormButton" runat="server" Text="Reset" OnClick="btnReset_Click" />
     </div>
      <div class="searchContainer">
                <div class="searchTextboxBlock">
                    <label class="fullLbl">Group Name:</label>
                    <asp:TextBox ID="txtGrpSearch" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                   
                </div>
                 <div class="searchTextboxBlockTransparent">
                    <br />
                    <asp:Button ID="btnGrpSearch" ValidationGroup="check" runat="server" Text="Search" OnClick="btnGrpSearch_Click"
                        CssClass="addCustomerBtn" />

                </div>

       <div class="Grid" id="tblGrid" runat="server">        
       
            <div class="gridOuterDiv">
       
                    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"   CssClass="grid-view">  --%>
                    <asp:GridView ID="GridView1" runat="server"   Width="100%"  EnableModelValidation="True" AllowPaging="True" PageSize="10" CssClass="gridtable" 
                        onpageindexchanging="GridView1_PageIndexChanging" onrowdatabound="GridView1_RowDataBound" AllowSorting="True" onsorting="GridView1_Sorting" AutoGenerateColumns="False"
                        onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" >

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
                            <asp:TemplateField HeaderText="GroupId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrpId" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grp Name" SortExpression="GrpName">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrpName" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address1">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress1" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address2">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress2" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StateId" Visible="False" >
                                <ItemTemplate>
                                    <asp:Label ID="lblStateId" runat="server" ></asp:Label>
                                </ItemTemplate>                      
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Name" SortExpression="StateName"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblStateName" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <%--<asp:TemplateField HeaderText="Zip Code" >
                                <ItemTemplate>
                                    <asp:Label ID="ZipCode" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Country Name" SortExpression="CountryName"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblCountryName" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CountryId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblCountryId" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>    
                            
                              <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblActive" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="CreatedBy" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField>    
                            
                            <asp:TemplateField HeaderText="CreatedOn" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField> 
                            
                             <asp:TemplateField HeaderText="UpdatedBy" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdatedBy" runat="server" ></asp:Label>
                                </ItemTemplate>                       
                            </asp:TemplateField> 
                            
                             <asp:TemplateField HeaderText="UpdatedOn" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdatedOn" runat="server" ></asp:Label>
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
                                                   
                        
                        </Columns>
                    </asp:GridView>
                  </div>
    </div>
    </div>
    </div>
</asp:Content>