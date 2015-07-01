function SignInvalidation()
{
    var id=document.getElementById("ctl00_cphAMSMaster_txtId").value;
    var pass=document.getElementById("ctl00_cphAMSMaster_txtPass").value;
    if(hasSpace(id))
    {
        return false;
    }
    if(hasSpace(pass))
    {
        return false;
    }
    if(id=="")
    {
        alert("User Id should not be Blank");
        return false;
    }
    if(pass=="")
    {
        alert("Password should not be Blank");
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