function AUCategoryValidation()
{

   var categoryName=document.getElementById("ctl00_cphAMSMaster_txtCategory").value;
   var catyegoryDesc=document.getElementById("ctl00_cphAMSMaster_txtDesc").value;
   var catyegoryAbbreviation=document.getElementById("ctl00_cphAMSMaster_txtAbbreviation").value;
    var lblError= document.getElementById('ctl00_lblError');
   if(hasWhiteSpace(categoryName))
   {
    return false
   }
   if(hasWhiteSpace(catyegoryAbbreviation))
   {
    return false;
   }
   if(hasWhiteSpace(catyegoryDesc))
   {
    return false
   }
   
   if( categoryName=="")
   {
        lblError.innerHTML="Please Enter Category Name";
        return false;
   }
   if(!isNaN(categoryName))
   {
        lblError.innerHTML="Category Name should not contain only numeric value";
        return false;
   }
   if( catyegoryAbbreviation=="")
   {
        lblError.innerHTML="Please Enter Category Abbreviation";
        return false;
   }
   if(!isNaN(catyegoryAbbreviation))
   {
        lblError.innerHTML="Category Abbreviation should not contain only numeric value";
        return false;
   }
   if( catyegoryDesc=="")
   {
        lblError.innerHTML="Please Enter Category Description";
        return false;
   }
   if(!isNaN(catyegoryDesc))
   {
        lblError.innerHTML="Category Description should not contain only numeric value";
        return false;
   }
}
function AUCategoryValidationRepeater(gridCategory,gridDesc,gridAbbreviation)
{

   var categoryName=document.getElementById(gridCategory).value;
   var catyegoryDesc=document.getElementById(gridDesc).value;
   var catyegoryAbbreviation=document.getElementById(gridAbbreviation).value;
   var lblError= document.getElementById('ctl00_lblError');
   if(hasWhiteSpace(categoryName))
   {
    return false
   }
   if(hasWhiteSpace(catyegoryAbbreviation))
   {
    return false;
   }
   if(hasWhiteSpace(catyegoryDesc))
   {
    return false
   }
   
   if( categoryName=="")
   {
        lblError.innerHTML="Please Enter Category Name";
        return false;
   }
   if( catyegoryAbbreviation=="")
   {
        lblError.innerHTML="Please Enter Category Abbreviation";
        return false;
   }
   if( catyegoryDesc=="")
   {
        lblError.innerHTML="Please Enter Category Description";
        return false;
   }
   
}
function hasWhiteSpace(s) 
{
    var lblError= document.getElementById('ctl00_lblError');
    reWhiteSpace = new RegExp(/^\s+$/);

     // Check for white space
     if (reWhiteSpace.test(s)) {
          lblError.innerHTML="Please Check Your Field For Spaces";
          return true;
     }
}