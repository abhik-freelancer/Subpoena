<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalendarDashboard.aspx.cs" Inherits="WebAppln.ContentPages.CalendarDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="poenaFormContainer" runat="server" id="dvSelection">
        <div class="row">
            <div class="col-xs-3 form-group">
                <asp:Label ID="Label23" Text="State *:" runat="server"> </asp:Label>
                <asp:DropDownList ID="DrpDwnState" CssClass="form-control mandatory" runat="server" TabIndex="2" AutoPostBack="True"  OnSelectedIndexChanged="OnchangeDrpDwnState">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ControlToValidate="DrpDwnState"
                    Text="Please select state" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-3 form-group">
                <asp:Label ID="Label24" Text="County" runat="server"> </asp:Label>
                <asp:DropDownList ID="DrpDwnCounty" CssClass="form-control mandatory" AutoPostBack="true" runat="server" TabIndex="3"  OnSelectedIndexChanged="OnchangeDrpDwnCounty">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="DrpDwnCounty"
                    Text="Please select country" ForeColor="Red" ErrorMessage="Please select country"></asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-3 form-group">
                <asp:Label ID="Label1" Text="Group" runat="server"> </asp:Label>
                <asp:DropDownList ID="DropDownGroup" CssClass="form-control mandatory" AutoPostBack="true" runat="server" TabIndex="3"  OnSelectedIndexChanged="OnchangeDrpDwnGroup">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownGroup"
                    Text="Please select Group" ForeColor="Red" ErrorMessage="Please select Group"></asp:RequiredFieldValidator>
            </div>
            <div class="col-xs-3 form-group">
                <asp:Label ID="Label5" Text="Detective" runat="server"> </asp:Label>
                <asp:DropDownList ID="DropDownDetective" CssClass="form-control mandatory" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="OnchangeDropDownDetective">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownDetective"
                    Text="Please select detective" ForeColor="Red" ErrorMessage="Please select state"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="">
        <h3>Dashboard Calendar</h3>
    </div>
    <div class="colmA">
        <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender"
            ShowGridLines="True"
            ShowTitle="True"
            OnSelectionChanged="Calendar1_SelectionChanged"
            runat="server" Height="450" Width="950" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" >
            <DayHeaderStyle BackColor="#FFCCFF" Font-Bold="True" Height="28px" BorderStyle="Double" HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" Wrap="True" />
        <DayStyle HorizontalAlign="Right" VerticalAlign="Top" />    
        </asp:Calendar>
    </div>
</asp:Content>
