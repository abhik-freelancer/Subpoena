function ForgetPasswordvalidation()
{
    var id=document.getElementById("ctl00_cphAMSMaster_txtUserId").value;
    if(hasSpace(id))
    {
        return false;
    }
    
    if(id=="")
    {
        alert("User Id should not be empty");
        return false;
    }
}
function hasSpace(s)
{
    reWhiteSpace = new RegExp(/^\s+$/);
     if (reWhiteSpace.test(s)) 
     {
          alert("Please Check Your Fields For Spaces");
          return true;
     }
 }

 function LoginRedirect() {
     window.location = "../Secure/Login.aspx"
 }