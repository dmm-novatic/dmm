<!DOCTYPE html>
    <html lang="en">
    
    
    <head>
      <title>Novatic | Admin dashboard</title>
      <!-- HTML5 Shim and Respond.js IE10 support of HTML5 elements and media queries -->
      <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
      <!--[if lt IE 10]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
          <![endif]-->
      <!-- Meta -->
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <meta name="description"
        content="Novatic Technology Solutions" />
      <meta name="keywords" content="novatic" />
      <meta name="author" content="Harry Nguyen" />
      <!-- Favicon icon -->
      <link rel="icon" href="files/assets/images/favicon.ico" type="image/x-icon">
    
    
      <!-- INCLUDE CSS START -->
      <?php include_once("lib/novaticCSS.php") ?>
      <!-- INCLUDE CSS END -->
    
    
    </head>
    
    <body>
      <!-- [ Pre-loader ] start -->
      <div class="loader-bg">
        <div class="loader-bar"></div>
      </div>
      <!-- [ Pre-loader ] end -->
      <div id="pcoded" class="pcoded">
        <div class="pcoded-overlay-box"></div>
        <div class="pcoded-container navbar-wrapper">
    
    
    
          
    
          <!-- INCLUDE HEADER START -->
          <?php include_once("lib/novaticHeader.php") ?>
          <!-- INCLUDE HEADER END -->
    
    
          <div class="pcoded-main-container">
            <div class="pcoded-wrapper">
    
    
    
              <!-- INCLUDE NAV START -->
              <?php include_once("lib/novaticNav.php") ?>
              <!-- INCLUDE NAV END -->
    
              
    
    
              <div class="pcoded-content">
                            <div class="page-header card">
                                <div class="col">
    
                                <div class="page-header-title">
                                            <i class="fa fa-server"></i>
                                            <div class="d-inline">
                                                <h3 class="tableTitle">Công ty</h3>
                                            </div>
                                        </div>
    
                                        <a href="#" id="btnAddItem" onclick="editItem(0);"
                                                class="btn btn-brand btn-elevate btn-icon-sm">
                                                <i class="fa fa-plus"></i>
                                                <span class='hideOnMobile'>New Record</span>
                                            </a>
    
     
    
    
                                </div>
                            </div>
    
                            <div class="pcoded-inner-content">
                                <div class="main-body">
                                    <div class="page-wrapper">
    
                                        <!-- Page-body start -->
                                        <div class="page-body">
    
                                            <div class="card">
                                                <div class="card-block novaticContainer">
                                                    <div class="dt-responsive table-responsive">
    
                                                    <table id="tableData" class="table  table-hover">
                                                    <thead>
                                                        <!--<tr>
                                                            <th>Index</th>
                                                            <th>Apply Type ID</th>
                                                            <th>Active</th>
                                                            <th>Apply Type Name</th>
                                                            <th>Description</th>
                                                            <th>Created Time</th>
                                                            <th>Detail</th>
                                                            <th>Delete</th>
                                                        </tr>-->
                                                        <th>Index</th>
						<th>ID</th>
						<th>Tên</th>
						<th>Mô tả</th>
						<th>Ngành nghề</th>
						<th>Thông tin công ty</th>
						<th>Quy mô công ty</th>

                                                        <th>Detail</th>
                                                        <th>Delete</th>
                                                    </thead>
                                                    <tbody>  
                                                    </tbody>
                                                    <tfoot>  
                                                    <th>Index</th>
						<th>ID</th>
						<th>Tên</th>
						<th>Mô tả</th>
						<th>Ngành nghề</th>
						<th>Thông tin công ty</th>
						<th>Quy mô công ty</th>

                                                    <th> </th>
                                                    <th> </th>
                                                    </tfoot>
                                                </table>




                                                
                                                <div class="modal fade" id="modal-id">
                                                    <div class="modal-dialog modal-lg">
                                                        <div class="modal-content">
                                                            <div class="modal-header bg-gradient-info">
                                                                <button type="button" class="close"
                                                                    data-dismiss="modal"
                                                                    aria-hidden="true">&times;</button>
                                                                <h4 class="modal-title"><i class="fa fa-edit"></i> Detail item</h4>
                                                            </div>
                                                            <div class="modal-body">


                                                                <form action="" method="POST" onsubmit='updateItem(updatingItemID); return false;' role="form">

                                                                    <!-- <div class="form-group">
                                                                        <label for="">Apply type ID</label>
                                                                        <input type="text" class="form-control"
                                                                            id="companyId" required readonly
                                                                            placeholder="">
                                                                    </div>


                                                                    <div class='form-group'>
                                                                        <label for=''>Apply type name</label>
                                                                        <input type='text' class='form-control'
                                                                            id='companyName' required
                                                                            placeholder=''>
                                                                    </div>


                                                                    <div class='form-group'>
                                                                        <label for=''>Description</label>
                                                                        <input type='text' class='form-control'
                                                                            id='companyDescription'
                                                                            placeholder=''>
                                                                    </div>


                                                                    <div class='form-group'>
                                                                        <label for=''>CreatedTime</label>
                                                                        <input type='text'
                                                                            class='form-control datetimepicker'
                                                                            id='companyCreatedTime'
                                                                            placeholder=''>
                                                                    </div>


                                                                    <div class='form-group' style="">
                                                                        <label for=''>Active</label>
                                                                        <input type='text' class='form-control'
                                                                            id='companyActive' readonly
                                                                            placeholder=''>
                                                                    </div>
                                                                    -->
                                                                     <div class="form-group"   >
                    <label for="">ID</label><span class='required'>*</span>
                    <input type="number" class="form-control" value="0"
                        id="companyId" required readonly
                        placeholder="">
                </div> <div class="form-group" style="display:none "  >
                    <label for="">Active</label><span class='required'>*</span>
                    <input type="number" class="form-control" value="0"
                        id="companyActive" required  
                        placeholder="">
                </div>   <div class="form-group">
                    <label for="">Tên</label><span class='required'>*</span>
                    <input type="text" class="form-control"
                        id="companyName" required  
                        placeholder="">
                </div>   
                <div class="form-group">
                    <label for="">Mô tả</label>
                    <textarea class="form-control" rows="2"  id="companyDescription" ></textarea>
                </div>
                


                <!-- load n-n data --> 
                <div class='form-group row selectContainer'>
                    <label class=''>Tỉnh/thành</label><span class='required'>*</span>
                    <div class='col-sm-12'>
                        <select name='select' multiple='multiple' required id='companyCompanyProvinceID' class='form-control fill dataSelect' style=' border: 1px solid #e9ecef; '>
                        </select>
                    </div>
                </div>
                <script>
                var provinceData =[];
                function loadDataSelectProvince() {
                    $.ajax({
                        url: 'http://localhost/demo3/api/province/read.php',
                        type: 'GET',
                        async:'true',
                        contentType: 'application/json',
                        success: function(responseData) {
                            console.log(new Date().getSeconds()+':'+new Date().getMilliseconds()+' - loaded province');
                            // debugger;
                            var data = responseData.data;
                            provinceData = data;
                            data.forEach(function(item, index) {
                                var data = {
                                    id: item.id,
                                    text: item.name
                                };
                                var newOption = new Option(data.text, data.id, false, false);
                                $('#companyCompanyProvinceID').append(newOption).trigger('change');
                            }); 
                        },
                        error: function(e) {
                            //console.log(e.message);
                        }
                    });
                }
                $(document).ready(function() {
                    loadDataSelectProvince();
                });
                </script> 


                
                
                
                <script>
                var companyProvinceData =[];
                function loadDataSelectCompanyProvince(companyID) {
                    $.ajax({
                        url: 'http://localhost/demo3/api/companyProvince/readQuery.php',
                        type: 'POST',
                        async:'true',
                        data: {condition:' companyID='+companyID+' '},
                        success: function(responseData) {
                            console.log(new Date().getSeconds()+':'+new Date().getMilliseconds()+' - loaded companyProvince');
                            debugger;
                            var data = responseData.data;
                            companyProvinceData = data;  

                            var currentProvinceData = [];
                            data.forEach(function(item, index) {
                                currentProvinceData.push(item.provinceID);
                            });
                            $('#companyCompanyProvinceID').val(currentProvinceData).trigger('change');
                        },
                        error: function(e) {
                            //console.log(e.message);
                        }
                    });
                }
                $(document).ready(function() {
                    // loadDataSelectCompanyProvince();
                });
                </script> 
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                <div class='form-group row selectContainer'>
                        <label class=''>Ngành nghề</label>
                        <div class='col-sm-12'>
                            <select name='select' multiple='multiple'  id='companyCompanyCategoryID' class='form-control fill dataSelect' style=' border: 1px solid #e9ecef; '>
                            </select>
                        </div>
                    </div>
                    <script>
                    var companyCategoryData =[];
                    function loadDataSelectCompanyCategory() {
                        $.ajax({
                            url: 'http://localhost/demo3/api/companyCategory/read.php',
                            type: 'GET',
                            async:'true',
                            contentType: 'application/json',
                            success: function(responseData) {
                                console.log(new Date().getSeconds()+':'+new Date().getMilliseconds()+' - loaded companyCategory');
                                // debugger;
                                var data = responseData.data;
                                companyCategoryData = data;
                                data.forEach(function(item, index) {
                                    var data = {
                                        id: item.id,
                                        text: item.name
                                    };
                                    var newOption = new Option(data.text, data.text, false, false);
                                    $('#companyCompanyCategoryID').append(newOption).trigger('change');
                                }); 
                            },
                            error: function(e) {
                                //console.log(e.message);
                            }
                        });
                    }
                    $(document).ready(function() {
                        loadDataSelectCompanyCategory();
                    });
                    </script><div class='form-group'>
                                            <label for=''>Ngày tạo </label><span class='required'>*</span>
                                            <div class='input-group date datetimepicker' id='companyCreatedTimeDiv'>
                                                <input type='text' id="companyCreatedTime" required class="form-control" required/>
                                                <span class="input-group-addon"> <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>   
                <div class="form-group">
                    <label for="">Thông tin công ty</label>
                    <textarea class="form-control" rows="2"  id="companyCompanyInfo" ></textarea>
                </div>
                    <script>
                    var companyCompanyInfoEditor;
                    ClassicEditor
                        .create( document.querySelector('#companyCompanyInfo'))
                        .then( editor => {
                            // console.log( 'Editor was initialized', editor );
                            companyCompanyInfoEditor = editor;
                            editor.model.document.on( 'change:data', ( evt, data ) => {
                                // debugger;
                                // console.log('Updated:'+ data );
                                $('#companyCompanyInfo').val(companyCompanyInfoEditor.getData());
                            });
                        })
                        .catch( err => {
                            console.error( err.stack );
                        }); 
                    </script>   
                <div class="form-group">
                    <label for="">Quy mô công ty</label>
                    <textarea class="form-control" rows="2"  id="companySize" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Quốc gia</label>
                    <textarea class="form-control" rows="2"  id="companyCountry" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Ảnh</label>
                    <textarea class="form-control" rows="2"  id="companyPhoto" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Địa chỉ</label>
                    <textarea class="form-control" rows="2"  id="companyAddress" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Website</label>
                    <textarea class="form-control" rows="2"  id="companyHomepage" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Số điện thoại</label>
                    <textarea class="form-control" rows="2"  id="companyPhone" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Email</label>
                    <textarea class="form-control" rows="2"  id="companyEmail" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Fax</label>
                    <textarea class="form-control" rows="2"  id="companyFax" ></textarea>
                </div>   
                <div class="form-group">
                    <label for="">Liên hệ</label>
                    <textarea class="form-control" rows="2"  id="companyContact" ></textarea>
                </div>
                    <script>
                    var companyContactEditor;
                    ClassicEditor
                        .create( document.querySelector('#companyContact'))
                        .then( editor => {
                            // console.log( 'Editor was initialized', editor );
                            companyContactEditor = editor;
                            editor.model.document.on( 'change:data', ( evt, data ) => {
                                // debugger;
                                // console.log('Updated:'+ data );
                                $('#companyContact').val(companyContactEditor.getData());
                            });
                        })
                        .catch( err => {
                            console.error( err.stack );
                        }); 
                    </script>




                                                                    <input style="display:none" id="hiddenSubmit" type="submit" class="btn btn-default" value="Save changes">
                                                                </form>


                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default"
                                                                    data-dismiss="modal">Close</button>
                                                                <button type="button" class="btn btn-primary"
                                                                    id="btnUpdateItem"
                                                                    onclick="document.getElementById('hiddenSubmit').click();">Save
                                                                    changes</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>





                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
    
               
              <!-- Main-body end -->
    
              <div id="styleSelector">
    
              </div>
            </div>
          </div>
        </div>
      </div>
    
    
    
      <!-- Warning Section Starts -->
      <!-- Older IE warning message -->
      <!--[if lt IE 10]>
        <div class="ie-warning">
            <h1>Warning!!</h1>
            <p>You are using an outdated version of Internet Explorer, please upgrade <br/>to any of the following web browsers to access this website.</p>
            <div class="iew-container">
                <ul class="iew-download">
                    <li>
                        <a href="http://www.google.com/chrome/">
                            <img src="../files/assets/images/browser/chrome.png" alt="Chrome">
                            <div>Chrome</div>
                        </a>
                    </li>
                    <li>
                        <a href="https://www.mozilla.org/en-US/firefox/new/">
                            <img src="../files/assets/images/browser/firefox.png" alt="Firefox">
                            <div>Firefox</div>
                        </a>
                    </li>
                    <li>
                        <a href="http://www.opera.com">
                            <img src="../files/assets/images/browser/opera.png" alt="Opera">
                            <div>Opera</div>
                        </a>
                    </li>
                    <li>
                        <a href="https://www.apple.com/safari/">
                            <img src="../files/assets/images/browser/safari.png" alt="Safari">
                            <div>Safari</div>
                        </a>
                    </li>
                    <li>
                        <a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie">
                            <img src="../files/assets/images/browser/ie.png" alt="">
                            <div>IE (9 & above)</div>
                        </a>
                    </li>
                </ul>
            </div>
            <p>Sorry for the inconvenience!</p>
        </div>
        <![endif]-->
      <!-- Warning Section Ends -->
      <!-- Required Jquery -->
      
      
      <!-- INCLUDE NAV START -->
      <?php include_once("lib/novaticJS.php") ?>
      <!-- INCLUDE NAV END -->
    
    
      <script>
            var hiddenItem = ["active","createdTime","country","photo","address","homepage","phone","email","fax","contact"];
            var dataSource = [];
            var updatingItemID = 0;
            var tableUpdating = 0;
            var table;
    
            $(document).ready(function () {
                // Load data
                loadData();
                // includeLibrary();
    
                // Datetime picker
                $('.datetimepicker').datetimepicker({
                    format: 'YYYY-MM-DD HH:mm:ss'
                });

                $('.dataSelect').select2();
    
                $(".datetimepicker").on('dp.change', function (e) {
                    // console.log(this.value);
                    this.value = moment(this.value).format("YYYY-MM-DD HH:mm:ss");
                    // console.log(this.value);
                })
    
            });
    
    
            function loadData() {
                $.ajax({
                    url: "http://localhost/demo3/api/company/read.php",
                    type: "GET",
                    contentType: "application/json",
                    success: function (responseData) {
                        // debugger;
                        var data = responseData.data;
                        dataSource = data;
    
 
    
    
                        data.forEach(function (item, index) {
                            // console.log(item, index);
                            var rowContent = "";
                            rowContent += "<td style='text-align: center;'>" + (index + 1) + "</td>";
                            for (var key in item) {
                                if (item.hasOwnProperty(key)) {
                                    // console.log(key + " -> " + item[key]);
                                    if (!hiddenItem.includes(key)) {
                                        rowContent += "<td class='row"+item.id+"-column column-"+key+"' property='"+key+"'>" + item[key] + "</td>";
                                    }
                                }
                            }
                            rowContent += "<td style='text-align: center;'><a onclick='editItem(" + item.id + ")'><i class='fa fa-edit fa-2x' style='color:#03a9f4'></i></a></td>";
                            rowContent += "<td style='text-align: center;'><a onclick='deleteItem(" + item.id + ")'><i class='fa fa-trash fa-2x' style='color:#e91e63'></i></a></td>";
                            
                            var newRow = "<tr id='row"+item.id+"' >" + rowContent + "</tr>";
                            $(newRow).appendTo($("#tableData tbody"));
                            
                            // $("#tableData #dummyRow").after("<tr id='row"+item.id+"' >" + rowContent + "</tr>");
                        });
    
                        //Init datatable
                        if (tableUpdating === 0) {
                            initTable();
                        }

                        //update data with foreign key
                        updateTable();
                    },
                    error: function (e) {
                        //console.log(e.message);
                        initTable();
                    }
                });
            }

            function initTable(){
                table = $('#tableData').DataTable({
                    aLengthMenu: [
                        [10, 25, 50, 100, 200, -1],
                        [10, 25, 50, 100, 200, 'Tất cả']
                    ],
                    'order': [
                        [1, 'desc']
                    ]
                });
    
    
                
                table.on('order.dt search.dt', function() {
                    table.column(0, {
                        search: 'applied',
                        order: 'applied'
                    }).nodes().each(function(cell, i) {
                        cell.innerHTML = i + 1;
                    });
                }).draw();
    
                $('#tableData tfoot th:not(:last-child):not(:nth-last-child(2))').each(function() {
                    var title = $(this).text();
                    $(this).html("<input type='text' class='tableFooterFilter' placeholder=' ' />");
                });
    
                table.columns().every(function() {
                    var that = this;
    
                    $('input', this.footer()).on('keyup change', function() {
                        if (that.search() !== this.value) {
                            that
                                .search(this.value)
                                .draw();
                        }
                    });
                });
            }
    
            function editItem(id) {
                updatingItemID = id;
                $("#modal-id").modal('show');
    
                let obj = getItemById(id);
                		$("#companyId").val(id > 0 ? obj.id : "");
		$("#companyActive").val(id > 0 ? obj.active : "");
		$("#companyName").val(id > 0 ? obj.name : "");
		$("#companyDescription").val(id > 0 ? obj.description : "");
		$("#companyCompanyCategoryID").val(id > 0 ? obj.companyCategoryID : "");
		$("#companyCreatedTime").val(id > 0 ? obj.createdTime : "");
		$("#companyCompanyInfo").val(id > 0 ? obj.companyInfo : "");
		$("#companySize").val(id > 0 ? obj.size : "");
		$("#companyCountry").val(id > 0 ? obj.country : "");
		$("#companyPhoto").val(id > 0 ? obj.photo : "");
		$("#companyAddress").val(id > 0 ? obj.address : "");
		$("#companyHomepage").val(id > 0 ? obj.homepage : "");
		$("#companyPhone").val(id > 0 ? obj.phone : "");
		$("#companyEmail").val(id > 0 ? obj.email : "");
		$("#companyFax").val(id > 0 ? obj.fax : "");
		$("#companyContact").val(id > 0 ? obj.contact : "");
companyCompanyInfoEditor.setData((id > 0 ? obj.companyInfo : ''));
companyContactEditor.setData((id > 0 ? obj.contact : ''));

                // $("#companyId").val(id > 0 ? obj.id : "");
                // $("#companyName").val(id > 0 ? obj.name : "");
                // $("#companyDescription").val(id > 0 ? obj.description : "");
                // $("#companyCreatedTime").val(id > 0 ? obj.createdTime : "");
                // $("#companyActive").val(id > 0 ? obj.active : "");

                if(id==0){
                    $("#companyActive").val(1);
                    $("#companyCreatedTime").val(new Date());
                }
                else{
                    // correcting data
                    //$('#buyProvinceID').val(obj.provinceID.split(", ")).trigger('change');
                    
                
$('#companyCompanyCategoryID').val(obj.companyCategoryID.split(", ")).trigger('change');


                    //correcting data 2
                    loadDataSelectCompanyProvince(id);

                    

                }
            }
    
    
            function updateItem(id) {
                var actionName = (id == 0 ? "Create" : "Update");
                let obj = getItemById(id);
                let objName = id > 0 ? obj.name : " ";
    
                // "id": $("#companyId").val(),
                // "name": $("#companyName").val(),
                // "description": $("#companyDescription").val(),
                // "createdTime": $("#companyCreatedTime").val(),
                // "active": $("#companyActive").val()
                var updatingObj = {
                    		"id": $("#companyId").val(),
		"active": $("#companyActive").val(),
		"name": $("#companyName").val(),
		"description": $("#companyDescription").val(),
		"companyCategoryID": $("#companyCompanyCategoryID").val(),
		"createdTime": datetimeFormat($("#companyCreatedTime").val()),
		"companyInfo": $("#companyCompanyInfo").val(),
		"size": $("#companySize").val(),
		"country": $("#companyCountry").val(),
		"photo": $("#companyPhoto").val(),
		"address": $("#companyAddress").val(),
		"homepage": $("#companyHomepage").val(),
		"phone": $("#companyPhone").val(),
		"email": $("#companyEmail").val(),
		"fax": $("#companyFax").val(),
		"contact": $("#companyContact").val(),

                };

                // correcting data
                //updatingObj.provinceID = updatingObj.provinceID.join(", ");
                
                
updatingObj.companyCategoryID = updatingObj.companyCategoryID.join(", ");
    
                Swal.fire({
                    title: 'Are you sure?',
                    text: "Performing " + actionName + " item " + objName,
                    type: 'info',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#443',
                    confirmButtonText: 'Yes, confirm!'
                }).then((result) => {
                    if (result.value) {
                        $("#modal-id").modal('hide');
    
                        //CALL AJAX TO UPDATE
                        if (id > 0) {
                            $.ajax({
                                url: "http://localhost/demo3/api/company/update.php",
                                type: "POST",
                                contentType: "application/json",
                                data: JSON.stringify(updatingObj),
                                success: function (responseData) {
                                    // debugger;
                                    if (responseData.status === 200 && responseData.message === "SUCCESS") {
                                        Swal.fire(
                                            'Updated!',
                                            'Item ' + objName + ' has been successfully updated!',
                                            'success'
                                        );
                                        updateTable(id,updatingObj,"update");
                                        var updatedItemIndex= dataSource.findIndex(item => parseInt(item.id) === id);
                                        dataSource[updatedItemIndex] = updatingObj;
                                    }
                                },
                                error: function (e) {
                                    //console.log(e.message);
                                    Swal.fire(
                                        'Error!',
                                        'Could\' update item, please check your data',
                                        'error'
                                    );
                                }
                            });
                        };
    
                        //CALL AJAX TO CREATE
                        if (id == 0) {
                            updatingObj.id = 1;
                            updatingObj.active = 1;
                            console.log(updatingObj);
                            $.ajax({
                                url: "http://localhost/demo3/api/company/create.php",
                                type: "POST",
                                contentType: "application/json",
                                data: JSON.stringify(updatingObj),
                                success: function (responseData) {
                                    // debugger;
                                    if (responseData.status === 201 && responseData.message === "CREATED") {
                                        Swal.fire(
                                            'Created!',
                                            'New item has been successfully created!',
                                            'success'
                                        );
                                        updatingObj = responseData.data;
                                        updateTable(0,updatingObj,"add");
                                    }
                                },
                                error: function (e) {
                                    //console.log(e.message);
                                    Swal.fire(
                                        'Error!',
                                        'Could\' create item, please check your data',
                                        'error'
                                    );
                                }
                            });
                        }
                    }
                })
            }
    
            function deleteItem(id) {
                let obj = getItemById(id);
                Swal.fire({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#d33',
                    cancelButtonColor: '#3085d6',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.value) {
    
                        //CALL AJAX TO DELETE
                        $.ajax({
                            url: "http://localhost/demo3/api/company/delete.php",
                            type: "POST",
                            contentType: "application/json",
                            data: JSON.stringify({ "id": id }),
                            success: function (responseData) {
                                // debugger;
                                if (responseData.status === 200 && responseData.message === "SUCCESS") {
                                    Swal.fire(
                                        'Deleted!',
                                        'Item ' + obj.name + ' has been deleted.',
                                        'success'
                                    );
                                    updateTable(id,0,"delete");
                                }
                            },
                            error: function (e) {
                                //console.log(e.message);
                                Swal.fire(
                                    'Error!',
                                    'Item ' + obj.name + ' can\'t be deleted.',
                                    'error'
                                );
                            }
                        });
    
                    }
                })
            }
    
            function updateTable(id,obj,action) {
                if(action === "delete"){ 
                    table.row("#row"+id).remove().draw();
                }
    
                if(action === "add"){
                    console.log("Added:"+obj);
    
                    var addedItems = [obj];
                    var addedValues =[];
    
    
                    addedItems.forEach(function (item, index) {
                        // console.log(item, index);
                        var rowContent = "";
                        addedValues.push("<td style='text-align: center;'></td>");
                        for (var key in item) {
                            if (item.hasOwnProperty(key)) {
                                // console.log(key + " -> " + item[key]);
                                if (!hiddenItem.includes(key)) {
                                    addedValues.push("<td class='row"+item.id+"-column column-"+key+"' property='"+key+"'>" + item[key] + "</td>");
                                }
                            }
                        }
                        addedValues.push("<td style='text-align: center;'><a onclick='editItem(" + item.id + ")'><i class='fa fa-edit fa-2x' style='color:#03a9f4'></i></a></td>");
                        addedValues.push("<td style='text-align: center;'><a onclick='deleteItem(" + item.id + ")'><i class='fa fa-trash fa-2x' style='color:#e91e63'></i></a></td>");
    
                        table.row.add(addedValues).draw();
                    });
                    // location.reload();
                }
    
                if(action === "update"){
                    // alert(id);
                    $(".row"+id+"-column").each(function(){
                        var propertyName = $(this).attr("property");
                        console.log(propertyName);
                        
                        for (var key in obj) {
                            if (key === propertyName && obj.hasOwnProperty(key)) {
                                this.innerText = obj[key];
                            }
                        }
    
                    });
                }

                //Update columns with foreign key
                // var NO_FKFKUpdateSelector = 'tr';
                // if( !(typeof(id) === 'undefined')) {
                //     NO_FKFKUpdateSelector = '#row'+id;
                // }
                // $('#tableData tbody '+NO_FKFKUpdateSelector+' td[property=NO_FKID]').each(function(){
                //     // debugger;
                //     var companyID = parseInt($(this).attr('class').replace('row','').replace('-column',''));
                //     var companyObj = getItemById(companyID);
                //     var NO_FKID = parseInt(companyObj.NO_FKID);
                //     var NO_FKObj = NO_FKData.find(item => parseInt(item.id) === NO_FKID);
                //     $(this).text(NO_FKObj.name);
                //     // console.log('FK updated for Staff '+companyID);
                // });
                
            }
    
    
            function getItemById(id) {
                const result = dataSource.find(item => parseInt(item.id) === id);
                return result;
            }
    
            function camelToSentenceCase(input) {
                var text = input;
                var result = text.replace(/([A-Z])/g, " $1");
                var finalResult = result.charAt(0).toUpperCase() + result.slice(1);
                return finalResult;
            }
            
            function datetimeFormat(datetime){
                return moment(datetime).format("YYYY-MM-DD HH:mm:ss");
            }
 
    
             
        </script>
    
    </body>
    </html>