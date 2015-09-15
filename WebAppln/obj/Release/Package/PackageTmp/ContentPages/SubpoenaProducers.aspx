<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.master" CodeBehind="SubpoenaProducers.aspx.cs" Inherits="Website.Pages.SubpoenaProducers" %>
<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-4 form-group"> <a href="/ContentPages/SubpoenaProducers">Add New Subpoena </a></div>
           
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label4" Text="Open A Saved Subpoeana" runat="server"> </asp:Label>
            <asp:DropDownList ID="ExistingSubpoeanaList" CssClass="form-control" runat="server" OnSelectedIndexChanged="OnchangeexistingSubPoeana" AutoPostBack="true" TabIndex="2">
            </asp:DropDownList>
        </div>
         <div class="col-xs-4 form-group">
             <asp:Label ID="Label21" Text="Choose Subpoeana Tempalte" runat="server"> </asp:Label>
            <asp:DropDownList ID="ChooseSubpoeanaTempalte" CssClass="form-control" runat="server" OnSelectedIndexChanged="ChooseSubpoeanaTempalteSubPoeana" AutoPostBack="true" TabIndex="2">
                <asp:ListItem Text="Subpoena Duces Tecum" Value="0" />
                <asp:ListItem Text="Subpoena Duces Tecum 1" Value="1" />
            </asp:DropDownList>

         </div>
    </div>


    <div class="row">
        <input type="hidden" runat="server" ID="txtEditSubpoeanaId" value="" />
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label23" Text="State *:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnState" CssClass="form-control" runat="server" TabIndex="2">
            </asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3"  runat="server" ControlToValidate="DrpDwnState"
    Text="Please select state" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator> 
        </div>
         <div class="col-xs-4 form-group">
            <asp:Label ID="Label24" Text="County *:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DrpDwnCounty" CssClass="form-control" OnSelectedIndexChanged="OnchangeDrpDwnCounty" AutoPostBack="true" runat="server" TabIndex="3">
            </asp:DropDownList>
             <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1"  runat="server" ControlToValidate="DrpDwnCounty"
    Text="Please select country" ForeColor="Red" ErrorMessage="Please select country"></asp:RequiredFieldValidator>
        </div>
         <div class="col-xs-4 form-group">
            <asp:Label ID="Label5" Text="Detective *:" runat="server"> </asp:Label>
            <asp:DropDownList ID="DropDownDetective" CssClass="form-control" runat="server" TabIndex="3">
            </asp:DropDownList>
             <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2"  runat="server" ControlToValidate="DropDownDetective"
    Text="Please select detective" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator>
        </div>
    </div>
  
    
       
        <%-- <ajax:CascadingDropDown ID="CountryCascading" runat="server" Category="Country" TargetControlID="DrpDwnCounty" LoadingText="Loading Countries..." PromptText="Select Country" ServiceMethod="BindCountrydropdown" ServicePath="DropdownWebService.asmx">
            </ajax:CascadingDropDown>--%>
   

    <div class="row">
        <div class="col-xs-12 form-group">
            <asp:Label ID="Label18" Text="New Subpoena *:" runat="server">  </asp:Label>
            <asp:TextBox ID="txtSubpoenaName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="reqName" ForeColor="Red" ControlToValidate="txtSubpoenaName" ErrorMessage="Please enter New subpoeana name!" />
        </div>
       
    </div>

    <div class="row">
        --------------------------------------------------------------------------------------------------------------------------
    </div>

    <div class="row">
        <div class="col-xs-12 form-group">
            To: Office of the State Attorney  First judical Circuit :
        </div>
    </div>
    <div class="row">
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label22" Text="Supervisor:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSupervisor" CssClass="form-control" runat="server" ></asp:TextBox>
        </div>
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label2" Text="Representative:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRepresentative" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label3" Text="Date *:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            <%-- <img src="../Images/calender.png"/>   --%>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="txtDate" ErrorMessage="Please enter date!" />
        </div>
    </div>



    <div class="row">
        <div class="col-xs-12 form-group">
            ADE of the State Attomey, or his duly authorized Assistant, of the First Judical-gative assistance and.............as follows:
        </div>
    </div>
    <div></div>

    <div class="row">
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label6" Text="Custodian:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCustodian" CssClass="form-control" runat="server" ></asp:TextBox>
        </div>
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label7" Text="Records Pertain To:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRecordsPertainTo" CssClass="form-control" runat="server" ></asp:TextBox>
        </div>

    </div>

    <div></div>
    <div class="row">
        <div class="col-xs-12 form-group">
            <asp:Label ID="Label1" runat="server" Text="Address Individual Business"></asp:Label>
            <asp:TextBox ID="txtAddressIndividualBusiness" CssClass="form-control" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div></div>
    <div class="row">
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label8" Text="Crime Under Investigation:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtCrimeUnderInvestigation" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label9" Text="F.S.S.:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtFSS" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>

    </div>
    <div></div>

    <div class="row">
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label10" Text="Suspect(s):" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSuspect" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label11" Text="Offense #:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtOffense" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

    </div>
    <div></div>
    <div class="row">
        <div class="col-xs-12 form-group">
            <asp:Label ID="Label12" Text="Information Requested:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtInformationRequested" CssClass="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
        </div>
    </div>
    <div></div>
    <div class="row">
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label14" Text="No notice suspect disclaimer needed?:" runat="server"> </asp:Label>
            <asp:CheckBox ID="chkboxYes" CssClass="form-control" runat="server" />
        </div>
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label15" Text="Yes" runat="server"> </asp:Label>
            <asp:CheckBox ID="chkboxNo" CssClass="form-control" runat="server" />
        </div>
        <div class="col-xs-4 form-group">
            <asp:Label ID="Label16" Text="No" runat="server"> </asp:Label>
            <asp:Label ID="Label17" Text="(Required for certain companies, bank, etc.)" runat="server"> </asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 form-group">
            <asp:Label ID="Label13" Text="Probable Cause:" runat="server"> </asp:Label>
            <asp:TextBox ID="txtProbableCause" CssClass="form-control" runat="server" TextMode="MultiLine"
                Height="52px"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12 Pageheader">
            <asp:Label ID="lblSubheading"  runat="server" Text="AUTHORIZATION:"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 form-group">
            The requesting law enforcement agency has authorized the under signed representative to make the foregoing request and will be responsible for any</br>costs incurred in making said copies. Further, the undersigned here by certifies this request is made in good faith in furtherance of the official pendind</br>criminal investigation described herein and all other avenues for obtaining the described records have been exhausted  
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label19" Text="Representive</br>Signature<br>(Required)" runat="server"> </asp:Label>
            <asp:TextBox ID="txtRepresentativeSig" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-6 form-group">
            <asp:Label ID="Label20" Text="Supervisor</br>Signature<br>(Required)" runat="server"> </asp:Label>
            <asp:TextBox ID="txtSupervisorSig" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        ___________________________________________________________________________________________________________________________
    </div>
    <div class="row">
        <div class="col-xs-12 form-group">
            ...THIS SECTION MUST BE COMPLETED BY AUTHORIZING PROSECUTOR...
        </div>
    </div>

    <div class="row">
        <div class="col-xs-4 form-group">
            <asp:Button ID="btnSave" CssClass="FormButtonImp" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <div class="col-xs-4 form-group">
            <asp:Button ID="bntPreview" CssClass="FormButtonImp" runat="server" Text="Preview" OnClick="bntPreview_Click" />
        </div>
        <div class="col-xs-4 form-group">
            <asp:Button ID="bntSubmit" CssClass="FormButtonImp" runat="server" Text="Submit" OnClick="bntSubmit_Click" />
        </div>
    </div>
    
    <%--<script type="text/javascript">
        $(document).ready(function () {

            $("#MainContent_DrpDwnCounty").change(function () {
                alert(jQuery(this).val());
                //$("#tblCustomers tbody tr").remove();
                debugger;
                $.ajax({
                    type: "POST",
                    url: "SubpoenaProducers.aspx/ShowDetectiveuser",
                    data: "{'country:' " + $(this).val() + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //    response($.map(data.d, function (item) {
                        //        var rows = "<tr>"
                        //        + "<td class='customertd'>" + item.CustomerID + "</td>"
                        //        + "<td class='customertd'>" + item.CompanyName + "</td>"
                        //        + "<td class='customertd'>" + item.ContactName + "</td>"
                        //        + "<td class='customertd'>" + item.ContactTitle + "</td>"
                        //        + "<td class='customertd'>" + item.City + "</td>"
                        //        + "<td class='customertd'>" + item.Phone + "</td>"
                        //        + "</tr>";
                        //        $('#tblCustomers tbody').append(rows);
                        //    }))
                    },
                    failure: function (response) {
                        //var r = jQuery.parseJSON(response.responseText);
                        alert("Message: ");
                        //alert("StackTrace: " + r.StackTrace);
                        //alert("ExceptionType: " + r.ExceptionType);
                    }
                });
            });
        });

    </script>--%>
    <%-- </form>--%>
</asp:Content>

