function ShowGridImage(imgid)
{
    document.getElementById(imgid).style.display="none";
}
function CancelImage(imgid, option)
{
    document.getElementById(imgid).style.display="block";
    document.getElementById(option).value="";
}
function CancelCopy(imgid,programName,programOption)
{
    document.getElementById(imgid).style.display="block";
    document.getElementById(programName).value="";
    document.getElementById(programOption).value="";
}


function SetGridHide(grid)
{    
    var gridIds=document.getElementById("ctl00_cphAMSMaster_hdnDivIds").value;
    var imageIds=document.getElementById("ctl00_cphAMSMaster_hdnImageIds").value;    
    var allGrids=new Array();
    var allImages=new Array();
    var maxLength=0;
    allGrids=gridIds.split(",");
    allImages=imageIds.split(",");
    if(allGrids.length>0)
    {
        maxLength=allGrids.length-1;
    }    
    for(var i=0;i<maxLength;i++)
    {
        if(allGrids[i]!=grid)
        {
            new Effect.Fold(allGrids[i]);
            document.getElementById(allImages[i]).style.display="block";
        }
    }
    
}

function CheckAvgWeek(evt)
  {
     var charCode = (evt.which) ? evt.which : event.keyCode
     if (charCode > 31  && (charCode < 46 || charCode > 57) || charCode==47)
        return false;
     return true;
  }
  function CheckAddUpdateFields()
  {
    var programName= document.getElementById('ctl00_cphAMSMaster_txtName').value;
    var programOption = document.getElementById('ctl00_cphAMSMaster_txtOption').value;
    var avgWeek = document.getElementById('ctl00_cphAMSMaster_txtweeks').value;
    var lblError= document.getElementById('ctl00_lblError');
    if(programName=="")
    {
        lblError.innerHTML="Program Name Should Not be Empty";
        return false;
    }
    
    if(!isNaN(programName.charAt(0)))
    {
         lblError.innerHTML="Program Name Should Not Starts with Numeric";
         return false;
    }
    else
    {
        lblError.innerHTML="";
    }
    if(programOption=="")
    {
        lblError.innerHTML="Program Option Should Not be Empty";
        return false;
    }
    if(!isNaN(programOption.charAt(0)))
    {
         lblError.innerHTML="Program Option Should Not Starts with Numeric";
         return false;
    }
    else
    {
        lblError.innerHTML="";
    }
    
    if(avgWeek=="")
    {
        lblError.innerHTML="Average Week Should Not be Empty";
        return false;
    }
    
  }
      