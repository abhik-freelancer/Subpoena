<%@ Page Language="C#" MasterPageFile="../Site.master" AutoEventWireup="true" CodeBehind="OtherUsers.aspx.cs" 
Inherits="WebAppln.ContentPages.OtherUsers" Title=":: PageforOtherUsers::" %>

   <asp:Content ID="Content22" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:TextBox class="txtAllCaseId" id="txtCaseIdAll" runat="server" type="text"  ></asp:TextBox>
    <div class="mainBgBx">
        <div class="page">

            <div class="">
               <h3> Home Page for Other User</h3>
            </div>
          
            <div class="inPtSec">
                <div class="hdln2">
                    Display Subpoena ..
                </div>

                <%--<div class="inClm">
                    <div class="inAAA">
                        <div class="inGrup">
                            <label class="lblIt">Case ID</label>
                            <asp:TextBox class="infldIt" id="txtCaseId" runat="server" type="text" ></asp:TextBox>
                        </div>

                        <div class="inGrup">
                            <label class="lblIt">Status</label>
                            <asp:TextBox class="infldIt" runat="server" id="txtStatus"  type="text" ></asp:TextBox>
                        </div>
                    </div>

                    <div class="inBBB">
                        <div class="inGrup">
                            <label class="lblIt">Official</label>
                          <asp:TextBox class="infldIt" runat="server" id="txtOfficial" type="text" OnTextChanged="txtOfficial_TextChanged" ></asp:TextBox>
                        </div>
                        <div class="inGrup">
                            <label class="lblIt">Date</label>
                            <asp:TextBox class="infldIt" id="txtDate" runat="server" TextMode="Date"  type="text" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="inCCC">
                        <div class="srcBtnB">
                             <asp:Button ID="bntSearch" CssClass="FormButtonImp" runat="server" Text="Search Case" OnClick="bntSearch_Click" />
                          
                        </div>
                    </div>
                    <div class="magic"></div>
                </div>--%>
                <!--inClm-->
            </div>
            <!--inPtSec-->

            <div class="listArea">

                <div class="listCntrl">
                   <%-- <div class="cntrAA">
                        <a href="#" class="exprBtn">Export to Excel</a>
                    </div>--%>
                    <%--<div class="cntrBB">
                        <select class="pagEr">
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                            <option value="100">100</option>
                        </select>
                    </div>--%>
                    <div class="magic"></div>
                </div>

                <div class="tablBox">

                    <div class="preview">

                        <div class="preview">
                            <table id="jqgrid"></table>
                            <div id="pager_jqgrid"></div>
                            <div class="clearfix"></div>
                        </div>

                    </div>
                </div>

            </div>
            <!--listArea-->

        </div>
        <!--page-->
    </div>
    <%--<script src="../Scripts/jquery-1.10.2.js"></script>--%>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script type="text/javascript">

        //Date Picker
        $(function () {
            $("#MainContent_txtDate").datepicker({
                dateFormat: "yy-mm-dd"
            });
            $('#MainContent_txtCaseIdAll').hide();
        });
        function getres(res) {
            var availableTags=  new Array();
            for(i=0;i < res.length; i++)
            {
                 res[i];
                availableTags.push(res[i]);
            }
      //      alert(availableTags);
            return availableTags;
        }
        //End Date Picker
        //case Id Auto Complete
        $(function () {
            var cases=$('#MainContent_txtCaseIdAll').val();
            var res = cases.split(",");
           // alert(res);
          //  var availableTags = [
            var availableTags=getres(res);
         //   ];
            $("#MainContent_txtCaseId").autocomplete({
                source: availableTags
            });
        });
        //EndCase Id Auto Complete

        // ----------------------------------------------------------------------------------------------------
        jQuery("#jqgrid").jqGrid({
            url: '../Handler1.ashx',
            mtype: 'POST',
            postData: { QueryString: "<%=sqlQuery %>" },
            datatype: 'json',
            height: '360',
            colNames: ['Actions', 'SubpoenaFrmId', 'CaseId', 'Subpoena Name', 'Official Name', 'Detactive Name', 'Date', 'PDFPath'], // 'Actions',
            colModel: [
                { name: 'act', index: 'act', sortable: false, search: false, width: 70 },
                 { name: 'SubpoenaFrmId', label: 'SubpoenaFrmId', hidden: true },
                { name: 'CaseId', index: 'CaseId', sortable: true },
                { name: 'SubpoenaName', index: 'SubpoenaName', sortable: true },
                { name: 'OfficialName', index: 'OfficialName', sortable: true },
                { name: 'DetativeName', index: 'DetativeName', sortable: true },
                { name: 'Date', index: 'Date', sortable: true },
                 { name: 'PDFPath', index: 'PDFPath', sortable: true }
            ],

            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#pager_jqgrid',
            sortname: 'SubpoenaFrmId',
            toolbarfilter: true,
            viewrecords: true,
            sortorder: "desc",
            gridComplete: function () {
                var ids = jQuery("#jqgrid").jqGrid('getDataIDs');
                for (var i = 0; i < ids.length; i++) {
                    var cl = ids[i];
                    if('<%=actionType %>' =='save')
                    {
                        be = "<span class='btn btn-xs btn-default btn-quick' title='Edit Row' onclick=\"editRow('" + cl + "'); \"><i class='fa fa-pencil'></i></span>";
                    }
                    else{
                        be = "<span class='btn btn-xs btn-default btn-quick delete_row' title='view Row' onclick=\"viewRow('" + cl + "');\"><i class='fa fa-times'></i></span>";
                    }
                    jQuery("#jqgrid").jqGrid('setRowData', ids[i], { act: be});  //act:be+se+ca
                   // be = "<span class='btn btn-xs btn-default btn-quick' title='Edit Row' onclick=\"editRow('" + cl + "'); \"><i class='fa fa-pencil'></i></span>";
                   // //se = "<button class='btn btn-xs btn-default btn-quick' title='Save Row' onclick=\"jQuery('#jqgrid').saveRow('"+cl+"');\"><i class='fa fa-save'></i></button>";
                   //// ca = "<span class='btn btn-xs btn-default btn-quick delete_row' title='Delete Row' onclick=\"deleteRow('" + cl + "');\"><i class='fa fa-times'></i></span>";
                   // ca = "<span class='btn btn-xs btn-default btn-quick delete_row' title='view Row' onclick=\"viewRow('" + cl + "');\"><i class='fa fa-times'></i></span>";
                   // jQuery("#jqgrid").jqGrid('setRowData', ids[i], { act: be + ca });  //act:be+se+ca
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
            var sitename = jQuery("#jqgrid").getCell(row_ID, 'SubpoenaFrmId');
            //location.href = 'Modify?USR_ID=' + sitename;
            //alert(sitename);
            window.location.href = 'SubpoenaProducers.aspx?Type=Edit&&Id=' + sitename;
            //window.open();
            //History.replaceState({ state: 3 }, "State 3", "#MBO=Define=id=" + sitename)
            // ClickHeaderLinkMenu(url);
        }
        function viewRow(row_ID) {
            
            var sitename = jQuery("#jqgrid").getCell(row_ID, 'SubpoenaFrmId');
                // e.preventDefault();
                var url = 'SubpoenaProducers.aspx?Type=view&&Id=' + sitename;
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
           

            //window.open('GroupCreation1.aspx?DeleteId=' + sitename);
            // alert(sitename);
            //var url = '$siteRoot/User/Modify.html?USR_ID=' + sitename;
            //History.replaceState({ state: 3 }, "State 3", "#MBO=Define=id=" + sitename)
            // ClickHeaderLinkMenu(url);
        }
        function deleteRow(row_ID) {
            if (confirm("Do you Want to Delete this record ? ")) {
                var sitename = jQuery("#jqgrid").getCell(row_ID, 'GrpId');
                // e.preventDefault();
                var url = "SubpoenaProducers.aspx?Type=deleted&&DeleteId=" + sitename;
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