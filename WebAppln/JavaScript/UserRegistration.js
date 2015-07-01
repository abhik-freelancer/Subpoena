function UserRegistrationValidation()
{
    var btntext=document.getElementById("ctl00_cphAMSMaster_btnRegister").value;
    var userId=document.getElementById("ctl00_cphAMSMaster_txtId").value;
    var userFName=document.getElementById("ctl00_cphAMSMaster_txtFName").value;
    var password=document.getElementById("ctl00_cphAMSMaster_txtPass").value;
    var rePass=document.getElementById("ctl00_cphAMSMaster_txtRePass").value;
    var activefrom=document.getElementById("ctl00_cphAMSMaster_txtActiveFrom").value;
    var activeUpto=document.getElementById("ctl00_cphAMSMaster_txtActiveUpTo").value;
    var txtEmail=document.getElementById("ctl00_cphAMSMaster_txtEmail").value;
    if(btntext=="Change Passward")
    {
        if(password!=rePass)
        {
            alert("Password And Retype Password Does not match");
            return false;
        }
        if(rePass.length<6)
        {
            alert("Password should be more than six characters");
            return false;
        }
    }
    else
    {
        var groupName=document.getElementById("ctl00_cphAMSMaster_ddlGroup").value;
        if(hasSpace(userId))
        {
            return false;
        }
        if(userId=="")
        {
            alert("Please Enter User ID");
            return false;
        }
        if(txtEmail=="")
        {
            alert("Please Enter Email ID");
            return false;
        }
        if(hasSpace(userFName))
        {
            return false;
        }
        if(userFName=="")
        {
            alert("Please Enter User First Name");
            return false;
        }
        if(hasSpace(groupName))
        {
            return false;
        }
        if(hasSpace(password))
        {
            return false;
        }
        if(password=="")
        {
            alert("Please Enter Password");
            return false;
        }
        if(hasSpace(rePass))
        {
            return false;
        }
        if(rePass=="")
        {
            alert("Please Enter Retype Password");
            return false;
        }
        if(hasSpace(activefrom))
        {
            return false;
        }
        if(activefrom=="")
        {
            alert("Please Enter Active From");
            return false;
        }
        if(hasSpace(activeUpto))
        {
            return false;
        }
        if(activeUpto=="")
        {
            alert("Please Enter Active Upto");
            return false;
        }
        if(activefrom>activeUpto)
        {
            alert("Activation Period not valid");
            return false;
        }
        if(password!=rePass)
        {
            
            alert("Password And Retype Password Does not match");
            return false;
        }
        if(password.length<6)
        {
            alert("Password should be more than six characters");
            return false;
        }
    }
}
function hasSpace(s)
{
     reSpace = new RegExp(/^\s+$/);
     if (reSpace.test(s)) 
     {
          alert("Please Check Your Fields For Spaces");
          return true;
     }
}
