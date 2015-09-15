<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" MasterPageFile="../Site.master" CodeBehind="PasswordList.aspx.cs" Inherits="Website.Pages.PasswordList" %>

<asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row paddingbottom15">
                    <div class="col-xs-12 col-sm-6 col-md-6">
                        <h3 class="font-md">CHANGE PASSWORD List</h3>
                    </div>
                    <%--<div class="col-xs-12 col-sm-6 col-md-6">
                        <a class="btn btn-xs btn-primary pull-right" href="GroupCreation1.aspx" onclick="" >New Group</a>
                    </div>--%>
                </div>
 <div class="preview">

                     <div class="preview">
                                        <table id="jqgrid"></table><div id="pager_jqgrid"></div> 
                                        <div class="clearfix"></div>
                                        </div>

 </div>
  
    
<script type="text/javascript">

    // ----------------------------------------------------------------------------------------------------
    jQuery("#jqgrid").jqGrid({
        url: '../Handler1.ashx',
        mtype: 'POST',
        postData: { QueryString: "<%=sqlQuery %>" },
        datatype: 'json',
        height: '360',
        colNames: ['Actions', 'Id', 'Email', 'TempPassword', 'NewPassword', 'RetypePassword'],
        colModel: [
			{ name: 'act', index: 'act', sortable: false, search: false, width: 70 },
             { name: 'PasswordChangeId', label: 'PasswordChangeId', hidden: true },
             { name: 'EmailAddress', index: 'EmailAddress', sortable: true },
			{ name: 'TempPassword', index: 'TempPassword', sortable: true },
			{ name: 'NewPassword', index: 'NewPassword', sortable: true },
		    { name: 'RetypePassword', index: 'RetypePassword', sortable: true },
            
        ],

        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager_jqgrid',
        sortname: 'PasswordChangeId',
        toolbarfilter: true,
        viewrecords: true,
        sortorder: "asc",
        gridComplete: function () {
            var ids = jQuery("#jqgrid").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var cl = ids[i];
                be = "<span class='btn btn-xs btn-default btn-quick' title='Edit Row' onclick=\"editRow('" + cl + "'); \"><i class='fa fa-pencil'></i></span>";
                //se = "<button class='btn btn-xs btn-default btn-quick' title='Save Row' onclick=\"jQuery('#jqgrid').saveRow('"+cl+"');\"><i class='fa fa-save'></i></button>";
                 ca = "<span class='btn btn-xs btn-default btn-quick delete_row' title='Delete Row' onclick=\"deleteRow('" + cl + "');\"><i class='fa fa-times'></i></span>";
              
                jQuery("#jqgrid").jqGrid('setRowData', ids[i], { act: be + ca });  //act:be+se+ca
            }
        },
        editurl: "",
        multiselect: false,
        autowidth: true,
    });
    // ----------------------------------------------------------------------------------------------------

    //enable datepicker
    function pickDate(cellvalue, options, cell) {
        setTimeout(function () {
            jQuery(cell).find('input[type=text]')
					.datepicker({ format: 'yyyy-mm-dd', autoclose: true });
        }, 0);
    }

    jQuery("#jqgrid").jqGrid('navGrid', "#pager_jqgrid", {
        edit: false,
        add: false,
        del: false,
        search: false,
        refresh: true
    });
    jQuery("#jqgrid").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false, defaultSearch: 'cn' });
    //jQuery("#jqgrid").jqGrid('inlineNav', "#pager_jqgrid");

    /* Add tooltips */
    jQuery('.navtable .ui-pg-button').tooltip({
        container: 'body'
    });

    // Get Selected ID's
    jQuery("a.get_selected_ids").bind("click", function () {
        s = jQuery("#jqgrid").jqGrid('getGridParam', 'selarrrow');
        alert(s);
    });

    // Select/Unselect specific Row by id
    jQuery("a.select_unselect_row").bind("click", function () {
        jQuery("#jqgrid").jqGrid('setSelection', "13");
    });

    // Select/Unselect specific Row by id
    jQuery("a.delete_row").bind("click", function () {

        var su = jQuery("#jqgrid").jqGrid('delRowData', 1);
        if (su) alert("Succes. Write custom code to delete row from server"); else alert("Already deleted or not in list");
    });

    function editRow(row_ID) {
        var sitename = jQuery("#jqgrid").getCell(row_ID, 'PasswordChangeId');
        //location.href = 'Modify?USR_ID=' + sitename;
        //alert(sitename);
        window.location.href = 'ChangePassword.aspx?EditId=' + sitename;
        //window.open();
        //History.replaceState({ state: 3 }, "State 3", "#MBO=Define=id=" + sitename)
       // ClickHeaderLinkMenu(url);
    }
    function deleteRow(row_ID) {
        if (confirm("Do you Want to Delete this record ? ")) {
            var sitename = jQuery("#jqgrid").getCell(row_ID, 'PasswordChangeId');
            // e.preventDefault();
            var url = "PasswordList.aspx?Type=deleted&&DeleteId=" + sitename;
            window.location.href = url;
          //  jQuery.ajax({
          //      method: "GET",
          //      datatype: 'text',
          //      url: url,
          //      data: {}
          //  })
          //.done(function (msg) {
          //    //alert(msg);

          //}).always(function () {
          //    //location.reload(true);
          //    //jQuery('#jqgrid').GridDestroy();
          //    jQuery("#jqgrid").trigger('reloadGrid');
          //});
        }

        //window.open('GroupCreation1.aspx?DeleteId=' + sitename);
        // alert(sitename);
        //var url = '$siteRoot/User/Modify.html?USR_ID=' + sitename;
        //History.replaceState({ state: 3 }, "State 3", "#MBO=Define=id=" + sitename)
       // ClickHeaderLinkMenu(url);
    }

    // On Resize
    jQuery(window).resize(function () {

        if (window.afterResize) {
            clearTimeout(window.afterResize);
        }

        window.afterResize = setTimeout(function () {

            /**
				After Resize Code
				.................
			**/

            jQuery("#jqgrid").jqGrid('setGridWidth', jQuery(".ui-jqgrid").parent().width());

        }, 500);

    });


    jQuery(".ui-jqgrid").removeClass("ui-widget ui-widget-content");
    jQuery(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");
    jQuery(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");
    jQuery(".ui-jqgrid-pager").removeClass("ui-state-default");
    jQuery(".ui-jqgrid").removeClass("ui-widget-content");

    jQuery(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    jQuery(".ui-pg-div").removeClass().addClass("btn btn-sm btn-primary");
    jQuery(".ui-icon.ui-icon-plus").removeClass().addClass("fa fa-plus");
    jQuery(".ui-icon.ui-icon-pencil").removeClass().addClass("fa fa-pencil");
    jQuery(".ui-icon.ui-icon-trash").removeClass().addClass("fa fa-trash-o");
    jQuery(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search");
    jQuery(".ui-icon.ui-icon-refresh").removeClass().addClass("fa fa-refresh");
    jQuery(".ui-icon.ui-icon-disk").removeClass().addClass("fa fa-save").parent(".btn-primary").removeClass("btn-primary").addClass("btn-success");
    jQuery(".ui-icon.ui-icon-cancel").removeClass().addClass("fa fa-times").parent(".btn-primary").removeClass("btn-primary").addClass("btn-danger");

    jQuery(".ui-icon.ui-icon-seek-prev").wrap("");
    jQuery(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

    jQuery(".ui-icon.ui-icon-seek-first").wrap("");
    jQuery(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

    jQuery(".ui-icon.ui-icon-seek-next").wrap("");
    jQuery(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

    jQuery(".ui-icon.ui-icon-seek-end").wrap("");
    jQuery(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");



</script>

  </asp:Content>    
