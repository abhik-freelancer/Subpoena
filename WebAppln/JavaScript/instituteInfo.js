function validateFields(val, valdesc)
{
    
   var strAll=document.getElementById(valdesc).value;
  
    var desc=val;
    var email="E-MAIL";
    var fax="FAX";
    var phone="TELEPHONE NUMBER";
    if(desc.search(email)>=0)
    {
       var emailRegEx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
       if(!strAll.match(emailRegEx))
       {
        alert('Please enter a valid email address.');
        return false;
        }
        else
            return true;
    }
    if(desc.search(phone)>=0)
    {
       var phoneRegEx = /^\d{1,10}$/;
       if(!strAll.match(phoneRegEx))
       {
        alert('Please enter a valid Phone Number.');
        return false;
       }
       else
            return true;
    }
}