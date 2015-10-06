<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" Title=":: Supoena Landing ::" CodeBehind="SubpoeanaProduserLanding.aspx.cs" Inherits="WebAppln.ContentPages.SubpoeanaProduserLanding" %>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="mainBgBx">
        <div class="page">

            <div class="">
               <h3> Home Page Admin/ Super Admin </h3>
            </div>
          
             <div class="inPtSec" style="height:400px;">
          


         <div class="row">
         <div class="col-xs-4 form-group">
           <a href="../ContentPages/OtherUsers?Type=save">Open a Saved Subpoena</a>
             </div>
         <div class="col-xs-4 form-group">
             <a href="../ContentPages/SubpoenaProducers">Create a New Subpoena</a>
             </div>  
             <div class="col-xs-4 form-group">
             <a href="../ContentPages/OtherUsers?Type=submit">Display Subpoena</a>
             </div> 
    </div>
                
                <!--inClm-->
            </div>

            
            <!--listArea-->

        </div>
        <!--page-->
    </div>

    
</asp:Content>