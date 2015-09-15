<%@ Page Title="Subpoeana : Home" Language="C#" AutoEventWireup="true" Inherits="WebAppln.ContentPages.Dashboard" MasterPageFile="~/Site.master" Codebehind="Dashboard.aspx.cs" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

     <div class="">
         <h3>Dashboard Calendar</h3>
                                            
    </div>
   
     <div class="col-xs-12 col-sm-12" id ="mycal">
        <div class="calendarbg"><div class="calendar_header_metal_spiral" style="width: 950px; left: 59.5px;"></div>
                <div id='full_calendar1'></div>
             </div>
        </div>
  

        <script type="text/javascript">
            jQuery(document).ready(function () {
                //jQuery("#accordion").accordion();
                var eventlist = <%=eventlist %> ;
                jQuery('#full_calendar1').fullCalendar({
                   // height:700,
                    header: {
                        left: 'today',
                        center: 'prev,title,next',
                        right: 'month,agendaWeek,agendaDay'
                    },
                    theme: true,
                    aspectRatio: 2,
                    defaultView: 'month',
                    selectable: true,
                    selectHelper: true,
                    viewRender: function (view, element) {
                        //alert(view.name);
                        //alert(view.visStart);
                        //alert(view.visEnd);
                    },
                    dayClick: function (date, allDay, jsEvent, view) {
                        //alert(view);
                        //callModal('$siteRoot/Calendar/TaskList.html','fullwidthboard');
                        //callCalendarModal('$siteRoot/Calendar/ProjectTaskList.html','Select Project','smlwidthboard');

                        // callModal('$siteRoot/Task/define.html?ProjectId=4','fullwidthboard');
                    },

                    select: function (startDate, endDate, allDay, jsEvent, view) {
                       // alert(allDay);
                        //callModal('$siteRoot/Calendar/TaskList.html','fullwidthboard');
                        var startd = jQuery.fullCalendar.formatDate(startDate, "MM/dd/yyyy");
                        var endd = jQuery.fullCalendar.formatDate(endDate, "MM/dd/yyyy");

                       // var myurl = "/Calendar/ProjectTaskList.html?xx=1&fdate=" + startd + "&todate=" + endd;
                        callCalendarModal(myurl, 'Select Project', 'smlwidthboard');


                        // callModal('$siteRoot/Task/define.html?ProjectId=4','fullwidthboard');
                    },

                    eventClick: function (calEvent, jsEvent, view) {
                        callCalendarModal(calEvent.url, 'Edit Task', 'fullwidthboard');
                        return false;
                    },

                    eventResize: function (event, dayDelta, minuteDelta, revertFunc) {

                        alert("The end date of " + event.title + "has been moved " + dayDelta + " days and " + minuteDelta + " minutes.");


                        LoadeventResize(event, dayDelta, minuteDelta);

                        var nsplit = event.url.split("#");

                        //alert(nsplit[1]);
                        revertFuncX(nsplit[1], minuteDelta);

                    },


                    eventDrop: function (event, dayDelta, minuteDelta, allDay, revertFunc) {

                        alert(
                        event.title + " was moved " +
                        dayDelta + " days and " +
                        minuteDelta + " minutes."
                        );

                        if (allDay) {
                            alert("Event is now all-day");
                        } else {
                            alert("Event has a time-of-day");
                        }

                        if (!confirm("Are you sure about this change?")) {
                            revertFunc();
                        }

                    },
                    editable: true, disableDragging: true,
                    events: eventlist
                });
                jQuery(".ui_tabs ").tabs();
                jQuery(".remove").click(function () {
                });
                var windowHeight = jQuery("body").height();
                var scrollareaheight = windowHeight - 115;
                //alert(scrollareaheight);
                jQuery(".scrollarea_section").css("max-height", scrollareaheight + 'px');
                jQuery(".leftarea").css("min-height", scrollareaheight + 'px');

                jQuery(".collabtab .nav-tabs").on("click", "a", function (e) {
                    //alert("hello");
                    e.preventDefault();
                    jQuery(this).tab('show');
                }).on("click", "i.delete", function () {
                    alert(jQuery(this).parent().attr("class"));
                    var anchor = jQuery(this).siblings('a');
                    jQuery(anchor.attr('href')).remove();
                    jQuery(this).parent().parent().remove();
                    jQuery(".nav-tabs li").children('a').first().click();
                });

                jQuery('.add-contact').click(function (e) {
                    alert("hello");
                    e.preventDefault();
                    var id = jQuery(".nav-tabs").children().length; //think about it ;)
                    jQuery(this).closest('li').before('<li><a href="#contact_' + id + '">New Tab</a><span class="actiontabs"><i class="fa fa-pencil edit"></i><i class="fa fa-trash-o delete"></i></span></li>');
                    jQuery('.tab-content').html();
                    // jQuery('.tab-content').append('<div class="tab-pane" id="contact_' + id + '">Contact Form: New Contact ' + id + '</div>');
                });


            })
    </script>
</asp:Content>
