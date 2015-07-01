//This method is used for tab movement 
$(function(){
       var index=0;       
       var navTab=document.getElementById("ctl00_cphAMSMaster_hdntabnavigate").value;//storing the value of hiddenfile in the navtab variable      
       if(navTab=="")
       {
            $('#T0').addClass("profile-selected");
            $('.SlideTab').tabSwitch('create',{width:706, height:460});
       }
       else
       {
            $('#T0').removeClass("profile-selected");
            $(navTab).addClass("profile-selected"); //Add the selector class to the variable           
            index=$(navTab).attr("rel");            
            $('.SlideTab').tabSwitch('create',{width:706, height:460});
            $('.SlideTab').tabSwitch('moveTo',{index: index});
       }
        	$('.tabSelect').click(function(e){
		    $(".profile-selected").removeClass("profile-selected");
		    index=$(this).attr("rel");			
			$(this).addClass("profile-selected");//Add the selector class to the sender
			$('.SlideTab').tabSwitch('moveTo',{index: parseInt($(this).attr("rel"))});
			e.preventDefault();			
	        document.getElementById("ctl00_cphAMSMaster_hdntabnavigate").value = ("#"+$(this).attr("id")).trim();
			var naode= e.target;
			
		});
		$('.Nav').click(function(e){
		
			if($(this).attr("alt")==1)//This portion is fired when user click next img button
			{
			    if(index==5)
			    {
			        index=0;
			        $('#T5').removeClass("profile-selected");
			        $('#T0').addClass("profile-selected");
			        
			    }
			    else
			    {
			        var prevId="#T"+index;
			        index++;
			        var presentId="#T"+index;
			        $(prevId).removeClass("profile-selected");
 			        $(presentId).addClass("profile-selected");
			    }
			}
			else if($(this).attr("alt")==-1)//This portion is fired when user click prev img button
			{
			    if(index==0)
			    {
			        index=5;
			        $('#T0').removeClass("profile-selected");
			        $('#T5').addClass("profile-selected");
			    }
			    else
			    {
			        var prevId="#T"+index;
			        index--;
			        var presentId="#T"+index;
			        $(prevId).removeClass("profile-selected");
			        $(presentId).addClass("profile-selected");
			    }
			}
			
			$('.SlideTab').tabSwitch('moveStep',{step: parseInt($(this).attr("alt"))});
			e.preventDefault();
		});
	});
	
	function setTab()
	{
	    
	}
	
	function myfileinput_onkeypress(evt)
	{		
	    var charCode = (evt.which) ? evt.which : event.keyCode		
		if(charCode==9)
		{
		    return true;
		}
		else
		{
		    return false;
		}
	}
     function isNumberKey(evt)
      {
      
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }

	function CheckTabIndex(id)
	{
 	    document.getElementById(id).focus();
	}
    function noNumbers(e)
    {
       
    var keynum;
    var keychar;
    var numcheck;

    if(window.event) // IE
      {
      keynum = e.keyCode;
      alert(e.keycode);
      }
    else if(e.which) // Netscape/Firefox/Opera
      {
      keynum = e.which;
      alert(keynum);
      }
    keychar = String.fromCharCode(keynum);
    numcheck = /\d/;
    return !numcheck.test(keychar);
    }