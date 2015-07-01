//This method is used for tab movement 
$(function(){
       var index=0; 
       var navTab=document.getElementById("ctl00_cphAMSMaster_hdnNavigateTab").value;
       if(navTab=="")
       {
            $('#T0').addClass("profile-selected");
            $('.SlideTab').tabSwitch('create',{width:706});
       }
       else
       {
            $('#T0').removeClass("profile-selected");
            $(navTab).addClass("profile-selected");            
            index=$(navTab).attr("rel");            
            $('.SlideTab').tabSwitch('create',{width:706});
            $('.SlideTab').tabSwitch('moveTo',{index: index});
       }
		$('.tabSelect').click(function(e){
        $(".profile-selected").removeClass("profile-selected");
        	index=$(this).attr("rel");
			$(this).addClass("profile-selected");
			$('.SlideTab').tabSwitch('moveTo',{index: parseInt($(this).attr("rel"))});
			e.preventDefault();
		});
		$('.Nav').click(function(e){		    
			if($(this).attr("alt")==1)//This portion is fired when user click next img button
			{			
			    if(index==8)
			    {
			        index=0;
			        $('#T8').removeClass("profile-selected");
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
			        index=8;
			        $('#T0').removeClass("profile-selected");
			        $('#T8').addClass("profile-selected");
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
	
	function ModifyCourseTabIndex(id)
	{
	    document.getElementById(id).focus();
	}