<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetectiveVacationManage.aspx.cs" Inherits="WebAppln.ContentPages.DetectiveVacationManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="poenaFormContainer poenaFormContainerWhite">
        <div class="blankGeneric" id="dvOutPutMsg" runat="server">
            <asp:Label ID="lblOutPutMsg" runat="server" Text="success"></asp:Label>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group poenaformHeader">
                Plan your Leave and Vacation
            </div>
        </div>
         <div class="col-xs-12 form-group">
            <asp:Label ID="lblMsg" Text="Yes" ForeColor="Red" runat="server"> </asp:Label>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                <asp:GridView ID="GrdViewDetetiveVacation" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    OnRowCancelingEdit="GrdViewDetetiveVacation_RowCancelingEdit"
                    OnRowEditing="GrdViewDetetiveVacation_RowEditing"
                    OnRowUpdating="GrdViewDetetiveVacation_RowUpdating"
                    OnRowDeleting="GrdViewDetetiveVacation_RowDeleting" EmptyDataText="No records fond for leave or vacation"
                    AlternatingRowStyle-BackColor="LightGreen">
                    <Columns>
                        <asp:TemplateField HeaderText="Leave Start Date" ControlStyle-Width="185px" ControlStyle-BorderColor="#ffff99" ItemStyle-Width="160px" HeaderStyle-Width="160px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="datepickerCompleted" Text='<%# Eval("FromDate", "{0:MM-dd-yyyy}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelFromDate" runat="server" Text='<%# Eval("FromDate", "{0:MM-dd-yyyy}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Leave End Date" ControlStyle-Width="185px" ControlStyle-BorderColor="#ffff99" ItemStyle-Width="160px" HeaderStyle-Width="160px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="datepickerCompleted" Text='<%# Eval("ToDate", "{0:MM-dd-yyyy}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelToDate" runat="server" Text='<%# Eval("ToDate", "{0:MM-dd-yyyy}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Leave Description" ControlStyle-Width="560px" ControlStyle-BorderColor="#ffff99" ItemStyle-Width="560px" HeaderStyle-Width="560px">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxEditDescription" runat="server" MaxLength="400" Text='<%# Bind("VacationDescription") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("VacationDescription") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
                 <table border="1">
                    <tr>
                        <td style="width:185px">
                            <asp:TextBox ID="txtAddFromDate" Width="170px" CssClass="datepickerCompleted" runat="server" />
                        </td>
                        <td style="width:187px">
                            <asp:TextBox ID="txtAddToDate" Width="170px" CssClass="datepickerCompleted"  runat="server" />
                        </td>
                        <td style="width:562px">
                            <asp:TextBox ID="TextBoxDescription" MaxLength="400" Width="550px" runat="server" />
                        </td>
                        <td style="width:66px">
                            <asp:Button ID="btnAdd" runat="server" Width="65px" Text="Add" OnClick="Insert" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script src="../Scripts/jquery-1.10.2.js"></script>
<script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script>
        $(function () {
            //$("#MainContent_GrdViewDetetiveVacation_txtFromDate_0").datepicker({
            //    dateFormat: "yy-mm-dd"
            //});
            //$("#MainContent_GrdViewDetetiveVacation_txtToDate_0").datepicker({
            //    dateFormat: "yy-mm-dd"
            //});
            //$("#MainContent_txtAddFromDate").datepicker({
            //    dateFormat: "yy-mm-dd"
            //});
            //$("#MainContent_txtAddToDate").datepicker({
            //    dateFormat: "yy-mm-dd"
            //});
            $(".datepickerCompleted").datepicker({
               // dateFormat: "yy-mm-dd"
                //showOtherMonths: true, selectOtherMonths: true, minDate: '-1m', maxDate: '+3m'
            });

            jQuery("a").filter(function () {
                return this.innerHTML.indexOf("Delete") == 0;
            }).click(function () {
                return confirm("Are you sure you want to delete this record?");
            });
        });

        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function SetTarget1() {
            document.forms[0].target = "_self";
        }
    </script>
</asp:Content>
