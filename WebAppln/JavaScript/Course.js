function CourseValidation()
{
    var departmentName=document.getElementById("ctl00_cphAMSMaster_ddlDept").value;
    var CourseTitle=document.getElementById("ctl00_cphAMSMaster_txtCourse").value;
    var courseDescription=document.getElementById("ctl00_cphAMSMaster_txtDescription").value;
    
    var abbreviation=document.getElementById("ctl00_cphAMSMaster_txtAbbreviation").value;
    var termOffered=document.getElementById("ctl00_cphAMSMaster_txtTermOffered").value;
    var minStudents=document.getElementById("ctl00_cphAMSMaster_txtMinStudents").value;
    var maxStudents=document.getElementById("ctl00_cphAMSMaster_txtMaxStudents").value;
    var noOfLecture=document.getElementById("ctl00_cphAMSMaster_txtNoOfLecture").value;
    var noOfLab=document.getElementById("ctl00_cphAMSMaster_txtNoOfLab").value;
    var noOfSeminar=document.getElementById("ctl00_cphAMSMaster_txtNoOfSeminar").value;    
   
    if(document.getElementById("ctl00_cphAMSMaster_ddlDept").selectedIndex == 0)
    {
        alert("Please Select Department");
        return false;
    }
    if(hasSpace(CourseTitle))
    {
        return false;
    }
    if(CourseTitle=="")
    {
        alert("Please Enter Course Title");
        return false;
    }
    if(abbreviation=="")
    {
        alert("Please Enter Course Abbreviation");
        return false;
    }
    if(hasSpace(courseDescription))
    {
        return false;
    }
    if(courseDescription=="")
    {
        alert("Please Enter Course Description");
        return false;
    }
    if(termOffered=="")
    {
        alert("Please Enter TermOffered");
        return false;
    }
    if(minStudents=="")
    {
        alert("Please Enter Min no. of Student");
        return false;
    }
    if(isNaN(minStudents))
    {
        alert("Please Enter Numeric Value for MinStudents");
        return false;
    }
    if(isNaN(maxStudents))
    {
        alert("Please Enter Numeric Value for MaxStudents");
        return false;
    }
    if(maxStudents=="")
    {
        alert("Please Enter Max No. of Student");
        return false;
    }
    if(noOfLecture=="")
    {
        alert("Please Enter No. of Lecture");
        return false;
    }
    if(isNaN(noOfLecture))
    {
        alert("Please Enter Numeric Value for No.Of Lecture");
        return false;
    }
    if(noOfLab=="")
    {
        alert("Please Enter No. of Lab");
        return false;
    }
    if(isNaN(noOfLab))
    {
        alert("Please Enter Numeric Value for No.Of Lab");
        return false;
    }
    if(noOfSeminar=="")
    {
        alert("Please Enter no. of Seminar");
        return false;
    }                
    if(isNaN(noOfSeminar))
    {
        alert("Please Enter Numeric Value for No.Of Seminar");
        return false;
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
//$(document).ready(function(){
//        $("#accordion").accordion({ autoHeight: false });
//  });
  
function CollapseAll()
  {
      var id="";
      for(i=0;i<10;i++)
      {
         id="msg_Body"+i;
//         alert(id);
         $(id).hide();
      }
  }
 function ExpandAll()
  {
      var id="";
      for(i=0;i<10;i++)
      {
         id="msg_Body"+i;
//         alert(id);
         $(id).show();
      }
  }