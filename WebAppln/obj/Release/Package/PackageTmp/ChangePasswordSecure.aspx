<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordSecure.aspx.cs" Inherits="WebAppln.ChangePasswordSecure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>- Subpoeana</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="Content/Site.css" type="text/css" />
</head>
<body class="loginBody">
    <form id="Form1" runat="server">
  
        <asp:UpdateProgress ID="UpdateProgressLogin" runat="server" DisplayAfter="10" DynamicLayout="True" AssociatedUpdatePanelID="UpdatePanelLogin">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="Images/loading.gif" />
                    Please Wait Contents are Loading...    
                </div>

            </ProgressTemplate>

        </asp:UpdateProgress>
          
        <myajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ></myajax:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
            <ContentTemplate>
                <div class="loginContainer">

                    <img src="Images/loginLOGOSOBPEONA.png" />
                    <div style="width: 100%" class="system-message">
                        <asp:Label ID="lbFailureText" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </div>

                   

                      <asp:TextBox ID="txttempass" runat="server" placeholder="Temporarry Password"  ></asp:TextBox>

                    <asp:TextBox ID="txtnewPassword" runat="server" placeholder="New Password"  TextMode="Password" ></asp:TextBox>

                      <asp:TextBox ID="txtconfirmmpass" runat="server" placeholder="Confirm Password"  TextMode="Password" ></asp:TextBox>

                    <asp:Button ID="btn_Changepass" runat="server" Text="Submit" CssClass="signin" OnClick="btn_Submit_Click" />

    
                   
                </div>
                <div class="Container">
                    
                    <div class="loginfooterouter">
                        <footer>
                            <p>&copy; <%: DateTime.Now.Year %> - Subpoeana. All Rights Reserved.
                                <a target="_blank" href="http://www.thethinkerz.com">Powerd by</a>

                            </p>
                        </footer>
                    </div>
            </ContentTemplate>
            <%--<Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_SignIn" EventName="Click" />

            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
