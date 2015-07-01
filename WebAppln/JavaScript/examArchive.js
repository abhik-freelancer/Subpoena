
    function checkUncheck(c1, c2, c3, main)
    {
        var mc=document.getElementById(main);
        var radio = document.forms[0].elements['RadioButtonList1'];
        var checkBox1= document.getElementById(c1);
        var checkBox2= document.getElementById(c2);
        var checkBox3= document.getElementById(c3);
        if(mc.checked == true)
        {
            checkBox1.checked=true;
            checkBox2.checked=true;
            checkBox3.checked=true;
        } 
        else
        {
            checkBox1.checked=false;
            checkBox2.checked=false;
            checkBox3.checked=false;
        }
    function myfileinput_onkeypress()
	{			
	        alert("ss");	
			return false;
	}
					
	function myfileinput_onkeydown(e)
	{
		if(e.keyCode != 11)
		{
				return false;
		}
	}

	function myfileinput_onkeyup(e)
	{
		if(e.keyCode != 11)
		{
			return false;
		}
	}      
    }
    function DisableControl(ctrl)
    {
        var options = ctrl.getElementsByTagName('input');
        var chkSearchByTermRange= document.getElementById('ctl00_cphAMSMaster_chkSearchByTermRange');
        var chkSearchByDateRange= document.getElementById('ctl00_cphAMSMaster_chkSearchByDateRange');
        var ddlTermFrom= document.getElementById('ctl00_cphAMSMaster_ddlTermFrom');
        var ddlYearFrom= document.getElementById('ctl00_cphAMSMaster_ddlYearFrom');
        var ddlTermTo= document.getElementById('ctl00_cphAMSMaster_ddlTermTo');
        var ddlYearTo= document.getElementById('ctl00_cphAMSMaster_ddlYearTo');
        var txtDateFrom = document.getElementById('ctl00_cphAMSMaster_txtDateFrom');
        var txtDateTo= document.getElementById('ctl00_cphAMSMaster_txtDateTo');
        var cal1= document.getElementById('ctl00_cphAMSMaster_dtImg3');
        var cal2= document.getElementById('ctl00_cphAMSMaster_dtImg4');
        if(ctrl.id=='ctl00_cphAMSMaster_chkSearchByTermRange')
            chkSearchByDateRange.checked=false;
        if(ctrl.id=='ctl00_cphAMSMaster_chkSearchByDateRange')
            chkSearchByTermRange.checked=false;
        if(options[0].checked==true)
        {
            ddlTermFrom.disabled=false;
            ddlYearFrom.disabled=false;
            ddlTermTo.disabled=false;
            ddlYearTo.disabled=false;
            txtDateFrom.disabled=true;
            txtDateTo.disabled=true;
            cal1.disabled=true;
            cal2.disabled=true;
            
        }
        if(options[1].checked==true)
        {
            ddlTermFrom.disabled=true;
            ddlYearFrom.disabled=true;
            ddlTermTo.disabled=true;
            ddlYearTo.disabled=true;
            txtDateFrom.disabled=false;
            txtDateTo.disabled=false;
            cal1.disabled=false;
            cal2.disabled=false;
            
        }
        
    }

    function checkdate(input, errorLabel)
    {
        var input=document.getElementById(input).value;
        var error= document.getElementById(errorLabel);
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ 
        var returnval=false
        if (!validformat.test(input))
        {
            error.innerHTML="Invalid Date Format";
        }
        else{ 
        error.innerHTML="";
        var monthfield=input.split("/")[0]
        var dayfield=input.split("/")[1]
        var yearfield=input.split("/")[2]
        var dayobj = new Date(yearfield, monthfield-1, dayfield)
        if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield))
        {
            error.innerHTML="Invalid Day, Month, or Year range";
        }
        else
        returnval=true
        }
        if (returnval==false) input.select()
        return returnval
    }
    
    function clearError(input)
    {
        input.innerHTML="";
    }
