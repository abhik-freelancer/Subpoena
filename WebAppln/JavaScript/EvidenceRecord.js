function EvidenceRecord()
{
  if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Import")
  {
       if(document.getElementById("ctl00_cphAMSMaster_RdbAMS").checked==false && document.getElementById("ctl00_cphAMSMaster_RdbCMS").checked==false)
        {
            alert("Please Select an option to specify whether it is from CMS or AMS");
            return false;
        }
        if(document.getElementById("ctl00_cphAMSMaster_ddlEvidence").selectedIndex==0)
        {
            alert("Please Select Evidence type");
            return false;
        }
        if(isNaN(document.getElementById("ctl00_cphAMSMaster_txtId").value))
        {
            alert("Please insert numeric value in Item or LP field");
            return false;
        }
        if(document.getElementById("ctl00_cphAMSMaster_txtId").value=="")
        {
            alert("Please insert Item or LP Id");
            return false;
        }
        if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceName").value=="")
        {
            alert("Please Select evidence name");
            return false;
        }
        if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceDesc").value=="")
        {
           alert("Please Select evidence description");
           return false;
        }
        if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Add New")
        {
            if(document.getElementById("ctl00_cphAMSMaster_fileEvidence").value=="")
            {
               alert("Please Select a file");
               return false;
            }
        }
    }
    else if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Update")
    {
        if(document.getElementById("ctl00_cphAMSMaster_RdbAMS").checked==false && document.getElementById("ctl00_cphAMSMaster_RdbCMS").checked==false)
        {
            alert("Please Select an option to specify whether it is from CMS or AMS");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_ddlEvidence").selectedIndex==0)
        {
            alert("Please Select Evidence type");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceName").value=="")
        {
            alert("Please Select evidence name");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceDesc").value=="")
        {
           alert("Please Select evidence description");
           return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Add New")
        {
            if(document.getElementById("ctl00_cphAMSMaster_fileEvidence").value=="")
            {
               alert("Please Select a file");
               return false;
            }
        }
    }
    else if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Add New")
    {
       if(document.getElementById("ctl00_cphAMSMaster_RdbAMS").checked==false && document.getElementById("ctl00_cphAMSMaster_RdbCMS").checked==false)
        {
            alert("Please Select an option to specify whether it is from CMS or AMS");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_ddlEvidence").selectedIndex==0)
        {
            alert("Please Select Evidence type");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceName").value=="")
        {
            alert("Please Select evidence name");
            return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_txtEvidenceDesc").value=="")
        {
           alert("Please Select evidence description");
           return false;
        }
       if(document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value=="Add New")
        {
            if(document.getElementById("ctl00_cphAMSMaster_fileEvidence").value=="")
            {
               alert("Please Select a file");
               return false;
            }
        }
    }
}
function showtype()
{
    var myindex  = document.getElementById("ctl00_cphAMSMaster_ddlEvidence").selectedIndex;
    if(myindex >0)
    {
        document.getElementById("ctl00_cphAMSMaster_lblEvidenceIDType").innerHTML=document.getElementById("ctl00_cphAMSMaster_ddlEvidence").options[myindex].text;
        return false;
    }
}

function checkId()
{
if(document.getElementById("ctl00_cphAMSMaster_ddlEvidence").selectedIndex==0)
{
    alert("Please Select Evidence type");
    document.getElementById("ctl00_cphAMSMaster_txtId").value="";
    return false;
}
else
{
    __doPostBack('AddEvidenceRecord.aspx', 'MyArgument');
    return true;
}
   
}

function checkType(type)
{
//alert(type);
    if(type=="CMS")
    {
        alert("Item or lp from CMS cannot be updated");
        return false
    }
    else if(type=="AMS")
    {
        return true;
    }
}

function ControlOperationCMS()
{
    if(document.getElementById("ctl00_cphAMSMaster_RdbCMS").checked)
    {
        document.getElementById("ctl00_cphAMSMaster_trId").style.display="block";
        document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value="Import"
    }
    else
    {
        document.getElementById("ctl00_cphAMSMaster_trId").style.display="none";
    }
}
function ControlOperationAMS()
{
    if(document.getElementById("ctl00_cphAMSMaster_RdbAMS").checked)
    {
        document.getElementById("ctl00_cphAMSMaster_trId").style.display="none";
        document.getElementById("ctl00_cphAMSMaster_btnAddEvidence").value="Add New";
    }
    else
    {
        document.getElementById("ctl00_cphAMSMaster_trId").style.display="block";
    }
}