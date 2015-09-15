<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppln.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
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
          
        <myajax:ToolkitScriptManager runat="server" ></myajax:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
            <ContentTemplate>
                <div class="loginContainer">

                    <img src="Images/loginLOGOSOBPEONA.png" />
                    <div style="width: 100%" class="system-message">
                        <asp:Label ID="lbFailureText" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </div>

                    <asp:TextBox ID="txtUserName" runat="server"  ></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" ></asp:TextBox>
                    <asp:Button ID="btn_SignIn" runat="server" Text="Login with us..." CssClass="signin" OnClick="btn_SignIn_Click" />

                    <%--<p>
                        Forgot Password?
                        <asp:LinkButton ID="lnkForgotPassword" Text="Click Here..." runat="server" ></asp:LinkButton>
                    </p>--%>
                </div>
                <div class="Container">
                  <%--  <myajax:ModalPopupExtender BackgroundCssClass="ModalPopupBG" ID="ForgotPassword_ModalPopupExtender"
                        runat="server" TargetControlID="lnkForgotPassword" PopupControlID="Panel1"
                        OkControlID="btnpopupcancel" CancelControlID="btnpopupcancel">
                    </myajax:ModalPopupExtender>--%>
                    <div class="popup_Buttons" style="display: none">

                        <input id="btnpopupcancel" value="Cancel" type="button" />
                    </div>
                    <div id="Panel1" style="display: none;" class="DivForgotPasswordPanel">
                        <iframe id="frameeditexpanse"  src="Forgotpassword.aspx" height="300" width="350"
                            ></iframe>
                    </div>


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
