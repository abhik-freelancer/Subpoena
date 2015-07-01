<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Site.master" CodeBehind="SubpoenaProducers.aspx.cs" Inherits="Website.Pages.SubpoenaProducers" %>


<%--<head runat="server">
    <title>Untitled Page</title>
    <link href="Style.css" rel="Stylesheet" type="text/css" />
</head>--%>
    <asp:Content ID="Content202" ContentPlaceHolderID="MainContent" runat="server">
<%--<body>--%>
    <%--<form id="form1" runat="server">--%>
    <div>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnNewSubpoena" runat="server" Text="Create New Subpoena" OnClick="btnNewSubpoena_Click" />               
        </td>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label ID="Label18" text="New Subpoena:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSubpoenaName" runat="server"></asp:TextBox>
    
    </div>
    <div class="formLineDivInv">
            <asp:Label ID="Label23" text="State:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnState" runat="server" TabIndex="2">
                </asp:DropDownList>  
            <asp:Label ID="Label24" text="County:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCounty" runat="server" TabIndex="3">
                </asp:DropDownList>    
               
     </div>
    -----------------------------------------------------------------------------------------
    <div></div>
    
    <div>
        <asp:Label ID="Label4" text="To: Office of the State Attorney </br> First judical Circuit :" runat="server"> </asp:Label>
    </div>
    <div class="formLineDivInv">                
            <asp:Label text="Supervisor:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSupervisor" runat="server" Width="298px"></asp:TextBox>
            <asp:Label ID="Label2" text="Representative:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRepresentative" runat="server" Width="298px"></asp:TextBox>
            <asp:Label ID="Label3" text="Date:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox> 
            <img src="../Images/calender.png"/>     
    </div>
    <div></div>
     <div class="formLineDiv">
            <asp:Label ID="Label5" runat="server" Text="ADE of the State Attomey, or his duly authorized Assistant, of the First Judical-gative assistance and.............as follows:"></asp:Label>
            
    </div>
    <div></div>
    <div class="formLineDivInv">
            <asp:Label ID="Label6" text="Custodian:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCustodian" runat="server" Width="396px"></asp:TextBox>
            <asp:Label ID="Label7" text="Records Pertain To:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRecordsPertainTo" runat="server" Width="367px"></asp:TextBox>
             
     </div> 
    <div></div>
    <div class="formLineDiv">
            <asp:Label ID="Label1" runat="server" Text="Address Individual Business"></asp:Label>
            <asp:TextBox ID="txtAddressIndividualBusiness" runat="server" Width="778px"></asp:TextBox>
    </div>
    <div></div>
    <div class="formLineDivInv">
            <asp:Label ID="Label8" text="Crime Under Investigation:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCrimeUnderInvestigation" runat="server" Width="429px"></asp:TextBox>
             <asp:Label ID="Label9" text="F.S.S.:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFSS" runat="server" Width="315px"></asp:TextBox>
            
            
    </div>
    <div></div>
    
     <div class="formLineDivInv">
            <asp:Label ID="Label10" text="Suspect(s):" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSuspect" runat="server" Width="429px"></asp:TextBox>
             <asp:Label ID="Label11" text="Offense #:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtOffense" runat="server" Width="315px"></asp:TextBox>
            
    </div>
    <div></div>
     <div class="formLineDivInv">
            <asp:Label ID="Label12" text="Information Requested:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtInformationRequested" runat="server" TextMode="MultiLine" Width="805px"></asp:TextBox>
        </div>
        <div></div>
        <div class="formLineDivInv">
            <asp:Label ID="Label14" text="No notice suspect disclaimer needed?:" runat="server"> </asp:Label>
            <asp:CheckBox ID="chkboxYes" runat="server" />
            <asp:Label ID="Label15" text="Yes" runat="server"> </asp:Label>
            <asp:CheckBox ID="chkboxNo" runat="server" />
            <asp:Label ID="Label16" text="No" runat="server"> </asp:Label>
            <asp:Label ID="Label17" text="(Required for certain companies, bank, etc.)" runat="server"> </asp:Label>
    
        </div>
        
     <div class="formLineDivInv">
            <asp:Label ID="Label13" text="Probable Cause:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtProbableCause" runat="server" TextMode="MultiLine" 
                Height="52px" Width="852px"></asp:TextBox>
     </div>
    
     <div class="row">
            <div class="col-sm-12 Pageheader">
               <asp:Label  ID="lblSubheading" runat="server" Text="AUTHORIZATION:"></asp:Label>
            </div>
        </div>   
     
      <div>
          <asp:Label ID="Label22" text="The requesting law enforcement agency has authorized the under signed representative to make the foregoing request and will be responsible for any</br>costs incurred in making said copies. Further, the undersigned here by certifies this request is made in good faith in furtherance of the official pendind</br>criminal investigation described herein and all other avenues for obtaining the described records have been exhausted   " runat="server"> </asp:Label>
            
    </div>
     <div class="formLineDivInv">
            
             <asp:Label ID="Label19" text="Representive</br>Signature<br>(Required)" runat="server"> </asp:Label>
             <asp:TextBox ID="txtRepresentativeSig" runat="server"></asp:TextBox>
             <asp:Label ID="Label20" text="Supervisor</br>Signature<br>(Required)" runat="server"> </asp:Label>
             <asp:TextBox ID="txtSupervisorSig" runat="server" Width="424px"></asp:TextBox>      
    </div>  
   <div>
   ___________________________________________________________________________________________________________________________
   </div>
      <div class="formLineDivInv">
             <asp:Label ID="Label21" text="...THIS SECTION MUST BE COMPLETED BY AUTHORIZING PROSECUTOR..." runat="server"> </asp:Label>
            
    </div>
    
    <div class="formLineDivInv"> 
       <span></span>
                <asp:Button ID="btnSave" CssClass="FormButtonImp" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="bntPreview" CssClass="FormButtonImp" runat="server" Text="Preview" OnClick="bntPreview_Click" />
                <asp:Button ID="bntSubmit" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="bntSubmit_Click" />
   </div> 
    
     
    <%--</form>--%>

</asp:Content>

