<?php
//Novatic Technology Solution
//PHP Restful API code generator
//Harry Louis William van Heisenberg bin Salman de Keangnam
//v1.0

// include libraries
include_once 'generateEngine.php';
$projectName = "Demo";
$databaseHostname = "localhost";
$databaseName = "demo3";
$databaseUsername = "root";
$databasePassword = "";
$homeURL = "http://localhost/demo3/";
$output = "output/";


// 0. Person table - demo
// $modelName = "person";
// $attributeArray = array();
// $attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
// $attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
// $attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
// $attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
// $attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// // function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
// generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);

// list param: newAttribute($name, $type, $nullable,$foreignKey,$showOnTable,$displayName) {
echo "<style>body{background:#000;color:#4CAF50;}</style>";
echo date('Y-m-d H:i:s')." - Novatic technology solution - Novatic Portal generating engine started<br/>";


// I. CORE MODELS
#region
// 1.account
$modelName = "account";
$displayName = "Tài khoản";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("email","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Email");
$attributeArray[] = Attribute::newAttribute("username","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên đăng nhập");
$attributeArray[] = Attribute::newAttribute("password","VARCHAR","NOT NULL","DEFAULT","NO_FK","FALSE","Mật khẩu");
$attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","TRUE","Ảnh");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("info","TEXT","NULL","EDITOR","NO_FK","FALSE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 2.authentication
$modelName = "authentication";
$displayName = "Authentication";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("accountID","INT","NOT NULL","DEFAULT","account","TRUE","Tài khoản");
$attributeArray[] = Attribute::newAttribute("token","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Token");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("validTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày hết hạn");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 3.messageCheckingStatus
$modelName = "messageCheckingStatus";
$displayName = "Trạng thái đọc thông báo";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 4.notification
$modelName = "notification";
$displayName = "Thông báo";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("messageCheckingStatusID","INT","NOT NULL","DEFAULT","messageCheckingStatus","TRUE","Trạng thái");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 5.message
$modelName = "message";
$displayName = "Tin nhắn";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("sender","TEXT","NOT NULL","DEFAULT","NO_FK","TRUE","Người gửi");
$attributeArray[] = Attribute::newAttribute("source","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Nguồn");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("messageCheckingStatusID","INT","NOT NULL","DEFAULT","messageCheckingStatus","TRUE","Trạng thái");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);

#endregion



// II. FUNCTIONAL MODELS
// 1.province
$modelName = "province";
$displayName = "Tỉnh thành";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên tỉnh/thành phố");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 2.companyCategory
$modelName = "companyCategory";
$displayName = "Ngành nghề doanh nghiệp";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 3. company
$modelName = "company";
$displayName = "Công ty";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("companyCategoryID","TEXT","NULL","DEFAULT","companyCategory","TRUE","Ngành nghề");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","FALSE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("companyInfo","TEXT","NULL","EDITOR","NO_FK","TRUE","Thông tin công ty"); 
$attributeArray[] = Attribute::newAttribute("size","TEXT","NULL","DEFAULT","NO_FK","TRUE","Quy mô công ty"); 
$attributeArray[] = Attribute::newAttribute("country","TEXT","NULL","DEFAULT","NO_FK","FALSE","Quốc gia"); 
// $attributeArray[] = Attribute::newAttribute("provinceID","TEXT","NOT NULL","DEFAULT","province","TRUE","Tỉnh/thành");
$attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","FALSE","Ảnh"); 
$attributeArray[] = Attribute::newAttribute("address","TEXT","NULL","DEFAULT","NO_FK","FALSE","Địa chỉ"); 
$attributeArray[] = Attribute::newAttribute("homepage","TEXT","NULL","DEFAULT","NO_FK","FALSE","Website"); 
$attributeArray[] = Attribute::newAttribute("phone","TEXT","NULL","DEFAULT","NO_FK","FALSE","Số điện thoại"); 
$attributeArray[] = Attribute::newAttribute("email","TEXT","NULL","DEFAULT","NO_FK","FALSE","Email"); 
$attributeArray[] = Attribute::newAttribute("fax","TEXT","NULL","DEFAULT","NO_FK","FALSE","Fax"); 
$attributeArray[] = Attribute::newAttribute("contact","TEXT","NULL","EDITOR","NO_FK","FALSE","Liên hệ"); 
// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 4.companyProvince
$modelName = "companyProvince";
$displayName = "Cấu hình công ty - tỉnh thành";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("provinceID","INT","NOT NULL","DEFAULT","province","TRUE","Tỉnh/thành");
$attributeArray[] = Attribute::newAttribute("companyID","INT","NOT NULL","DEFAULT","company","TRUE","Công ty");
// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 4.buy
$modelName = "buy";
$displayName = "Tin tức bán";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("price","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Giá");
$attributeArray[] = Attribute::newAttribute("companyCategoryID","TEXT","NULL","DEFAULT","companyCategory","TRUE","Ngành nghề");
$attributeArray[] = Attribute::newAttribute("provinceID","TEXT","NOT NULL","DEFAULT","province","TRUE","Tỉnh/thành");
$attributeArray[] = Attribute::newAttribute("publishedYear","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Năm thành lập");
// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 5.sell
$modelName = "sell";
$displayName = "Tin tức mua";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("price","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Giá");
$attributeArray[] = Attribute::newAttribute("companyCategoryID","TEXT","NULL","DEFAULT","companyCategory","TRUE","Ngành nghề");
$attributeArray[] = Attribute::newAttribute("provinceID","TEXT","NOT NULL","DEFAULT","province","TRUE","Tỉnh/thành");
$attributeArray[] = Attribute::newAttribute("publishedYear","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Năm thành lập");
// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);



// 6.customer
$modelName = "customer";
$displayName = "Khách hàng";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("projectName","TEXT","NOT NULL","DEFAULT","NO_FK","TRUE","Tên dự án");
$attributeArray[] = Attribute::newAttribute("price","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Giá");
$attributeArray[] = Attribute::newAttribute("startTime","TIMESTAMP","NULL","DEFAULT","NO_FK","TRUE","Ngày bắt đầu");
$attributeArray[] = Attribute::newAttribute("finishTime","TIMESTAMP","NULL","DEFAULT","NO_FK","TRUE","Ngày kết thúc");
$attributeArray[] = Attribute::newAttribute("detailInfo","TEXT","NULL","EDITOR","NO_FK","TRUE","Chi tiết");

// function generate($projectName, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);

// Generate test script
generateTestFile($projectName,$output,$homeURL);

// Generate lib files
generateLibFiles($output,$homeURL);

// Generate login file
generateLoginFile($output,$homeURL);

// Generate file manager file
generateFileManagerFile($output,$homeURL);

// Generate config files
generateConfigFiles($output,$homeURL, $databaseName, $databaseHostname, $databaseUsername, $databasePassword);

//execute database
executeDatabase( $databaseName, $databaseHostname, $databaseUsername, $databasePassword);

echo date('Y-m-d H:i:s')." - Novatic technology solution - Novatic Portal generating completed<br/>";
echo date('Y-m-d H:i:s')." - Created by <a href='fb.com/libert4692'>Harry Nguyen</a> 09/2019 - what a beautiful work!<br/>";
//Generating completed !
?>