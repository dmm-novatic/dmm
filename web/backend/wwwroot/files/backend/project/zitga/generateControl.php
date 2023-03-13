<?php
//Novatic Technology Solution
//PHP Restful API code generator
//Harry Louis William van Heisenberg bin Salman de Keangnam
//v1.0

// include libraries
include_once 'generateEngine.php';
$projectName = "Zitga";
$databaseHostname = "localhost";
$databaseName = "zitga";
$databaseUsername = "root";
$databasePassword = "";
$homeURL = "http://localhost/zitga/";
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
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("info","TEXT","NULL","EDITOR","NO_FK","FALSE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("branchID","INT","NULL","DEFAULT","branch","TRUE","Chi nhánh");
$attributeArray[] = Attribute::newAttribute("dob","TIMESTAMP","NULL","DEFAULT","NO_FK","FALSE","Ngày sinh");
$attributeArray[] = Attribute::newAttribute("sexID","INT","NULL","DEFAULT","sex","FALSE","Giới tính");
$attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","FALSE","Ảnh");
$attributeArray[] = Attribute::newAttribute("address","TEXT","NULL","DEFAULT","NO_FK","FALSE","Địa chỉ");
$attributeArray[] = Attribute::newAttribute("phone","TEXT","NULL","DEFAULT","NO_FK","TRUE","Số điện thoại");
$attributeArray[] = Attribute::newAttribute("facebook","TEXT","NULL","DEFAULT","NO_FK","FALSE","Facebook");
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

// 6. geo province
$modelName = "province";
$displayName = "Tỉnh thành";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","UNIQUE","NO_FK","TRUE","Tên tỉnh/thành phố");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


#endregion


// II. FUNCTIONAL MODELS
// 1.sex
$modelName = "sex";
$displayName = "Giới tính";
$attributeArray = array();
// public static function newAttribute($name, $type, $nullable,$optionalFunction,$foreignKey,$showOnTable,$displayName) {
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 2.maritalStatus
$modelName = "maritalStatus";
$displayName = "Tình trạng hôn nhân";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 3. jobCategory
$modelName = "jobCategory";
$displayName = "Danh mục Job";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 4. jobTitle
$modelName = "jobTitle";
$displayName = "Job title";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 5. jobType
$modelName = "jobType";
$displayName = "Job type";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 6. jobStatus
$modelName = "jobStatus";
$displayName = "Job status";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 7. jobRank
$modelName = "jobRank";
$displayName = "Job rank";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 8. company
// $modelName = "company";
// $displayName = "Công ty";
// $attributeArray = array();
// $attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
// $attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
// $attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
// $attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
// $attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","FALSE","Ngày tạo");
// $attributeArray[] = Attribute::newAttribute("companyInfo","TEXT","NULL","EDITOR","NO_FK","TRUE","Thông tin công ty"); 
// $attributeArray[] = Attribute::newAttribute("size","TEXT","NULL","DEFAULT","NO_FK","TRUE","Quy mô công ty"); 
// $attributeArray[] = Attribute::newAttribute("country","TEXT","NULL","DEFAULT","NO_FK","FALSE","Quốc gia"); 
// $attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","FALSE","Ảnh"); 
// $attributeArray[] = Attribute::newAttribute("address","TEXT","NULL","DEFAULT","NO_FK","FALSE","Địa chỉ"); 
// $attributeArray[] = Attribute::newAttribute("homepage","TEXT","NULL","DEFAULT","NO_FK","FALSE","Website"); 
// $attributeArray[] = Attribute::newAttribute("phone","TEXT","NULL","DEFAULT","NO_FK","FALSE","Số điện thoại"); 
// $attributeArray[] = Attribute::newAttribute("email","TEXT","NULL","DEFAULT","NO_FK","FALSE","Email"); 
// $attributeArray[] = Attribute::newAttribute("fax","TEXT","NULL","DEFAULT","NO_FK","FALSE","Fax"); 
// $attributeArray[] = Attribute::newAttribute("workingHour","TEXT","NULL","DEFAULT","NO_FK","FALSE","Giờ làm việc"); 
// $attributeArray[] = Attribute::newAttribute("contact","TEXT","NULL","EDITOR","NO_FK","FALSE","Liên hệ"); 
// // function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
// generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 9.branch
$modelName = "branch";
$displayName = "Chi nhánh";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// $attributeArray[] = Attribute::newAttribute("companyID","INT","NOT NULL","DEFAULT","company","TRUE","Công ty");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 10.hrStaff
// $modelName = "hrStaff";
// $displayName = "HR staff";
// $attributeArray = array();
// $attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
// $attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
// $attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
// $attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
// $attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// $attributeArray[] = Attribute::newAttribute("companyID","INT","NOT NULL","DEFAULT","company","TRUE","Công ty");
// $attributeArray[] = Attribute::newAttribute("branchID","INT","NOT NULL","DEFAULT","branch","TRUE","Chi nhánh");
// $attributeArray[] = Attribute::newAttribute("dob","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","FALSE","Ngày sinh");
// $attributeArray[] = Attribute::newAttribute("sexID","INT","NULL","DEFAULT","sex","FALSE","Giới tính");
// $attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","FALSE","Ảnh");
// $attributeArray[] = Attribute::newAttribute("address","TEXT","NULL","DEFAULT","NO_FK","FALSE","Địa chỉ");
// $attributeArray[] = Attribute::newAttribute("phone","TEXT","NULL","DEFAULT","NO_FK","TRUE","Số điện thoại");
// $attributeArray[] = Attribute::newAttribute("email","TEXT","NULL","DEFAULT","NO_FK","FALSE","Email");
// $attributeArray[] = Attribute::newAttribute("facebook","TEXT","NULL","DEFAULT","NO_FK","FALSE","Facebook");
// // function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
// generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 11. job
$modelName = "job";
$displayName = "Job";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("openTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày mở");
$attributeArray[] = Attribute::newAttribute("closeTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày đóng");
// $attributeArray[] = Attribute::newAttribute("companyID","INT","NOT NULL","DEFAULT","company","FALSE","Công ty");
$attributeArray[] = Attribute::newAttribute("hrStaffID","INT","NOT NULL","DEFAULT","account","TRUE","HR staff");
$attributeArray[] = Attribute::newAttribute("branchID","TEXT","NOT NULL","DEFAULT","branch","FALSE","Chi nhánh");
$attributeArray[] = Attribute::newAttribute("jobCategoryID","TEXT","NOT NULL","DEFAULT","jobCategory","TRUE","Danh mục job");
$attributeArray[] = Attribute::newAttribute("jobRankID","TEXT","NOT NULL","DEFAULT","jobRank","FALSE","Job rank");
$attributeArray[] = Attribute::newAttribute("jobTitleID","TEXT","NOT NULL","DEFAULT","jobTitle","FALSE","Job title");
$attributeArray[] = Attribute::newAttribute("jobTypeID","TEXT","NOT NULL","DEFAULT","jobType","FALSE","Job type");
$attributeArray[] = Attribute::newAttribute("jobStatusID","TEXT","NOT NULL","DEFAULT","jobStatus","TRUE","Job status");
$attributeArray[] = Attribute::newAttribute("quantity","INT","NOT NULL","DEFAULT","NO_FK","TRUE","Số lượng");
$attributeArray[] = Attribute::newAttribute("photo","VARCHAR","NULL","DEFAULT","NO_FK","FALSE","Ảnh");
$attributeArray[] = Attribute::newAttribute("requirementExperience","TEXT","NULL","EDITOR","NO_FK","FALSE","Yêu cầu kinh nghiệm");
$attributeArray[] = Attribute::newAttribute("requirementAcademicDegree","TEXT","NULL","EDITOR","NO_FK","FALSE","Yêu cầu bằng cấp");
$attributeArray[] = Attribute::newAttribute("requirementSex","TEXT","NULL","DEFAULT","NO_FK","FALSE","Yêu cầu giới tính");
$attributeArray[] = Attribute::newAttribute("requirementDocument","TEXT","NULL","EDITOR","NO_FK","FALSE","Yêu cầu hồ sơ");
$attributeArray[] = Attribute::newAttribute("requirementLanguage","TEXT","NULL","EDITOR","NO_FK","FALSE","Yêu cầu ngôn ngữ");
$attributeArray[] = Attribute::newAttribute("requirementDetail","TEXT","NULL","EDITOR","NO_FK","FALSE","Chi tiết yêu cầu");
$attributeArray[] = Attribute::newAttribute("workingHour","TEXT","NULL","DEFAULT","NO_FK","FALSE","Giờ làm việc");
$attributeArray[] = Attribute::newAttribute("salary","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mức lương");
$attributeArray[] = Attribute::newAttribute("jobDetail","TEXT","NULL","EDITOR","NO_FK","FALSE","Chi tiết công việc");
$attributeArray[] = Attribute::newAttribute("benefit","TEXT","NULL","EDITOR","NO_FK","FALSE","Chi tiết chế độ");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);



// 12.applyStatus
$modelName = "applyStatus";
$displayName = "Trạng thái ứng tuyển";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 13.applyType
$modelName = "applyType";
$displayName = "Loại ứng tuyển";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 14.applicant
$modelName = "applicant";
$displayName = "Ứng viên";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("dob","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày sinh");
$attributeArray[] = Attribute::newAttribute("sexID","INT","NULL","DEFAULT","sex","TRUE","Giới tính");
$attributeArray[] = Attribute::newAttribute("maritalStatusID","INT","NULL","DEFAULT","maritalStatus","FALSE","Tình trạng hôn nhân");
$attributeArray[] = Attribute::newAttribute("selfDescription","TEXT","NULL","EDITOR","NO_FK","FALSE","Tự giới thiệu");
$attributeArray[] = Attribute::newAttribute("country","TEXT","NULL","DEFAULT","NO_FK","FALSE","Quốc tịch");
$attributeArray[] = Attribute::newAttribute("photo","TEXT","NULL","DEFAULT","NO_FK","TRUE","Ảnh");
$attributeArray[] = Attribute::newAttribute("address","TEXT","NULL","DEFAULT","NO_FK","FALSE","Địa chỉ");
$attributeArray[] = Attribute::newAttribute("phone","TEXT","NULL","DEFAULT","NO_FK","FALSE","Số điện thoại");
$attributeArray[] = Attribute::newAttribute("email","TEXT","NULL","DEFAULT","NO_FK","FALSE","Email");
$attributeArray[] = Attribute::newAttribute("facebook","TEXT","NULL","DEFAULT","NO_FK","FALSE","Facebook");
$attributeArray[] = Attribute::newAttribute("linkedIn","TEXT","NULL","DEFAULT","NO_FK","FALSE","Linkedin");
$attributeArray[] = Attribute::newAttribute("academicDegree","TEXT","NULL","EDITOR","NO_FK","TRUE","Trình độ học vấn");
$attributeArray[] = Attribute::newAttribute("highschool","TEXT","NULL","EDITOR","NO_FK","FALSE","Trường THPT");
$attributeArray[] = Attribute::newAttribute("university","TEXT","NULL","EDITOR","NO_FK","FALSE","Trường Đại học/Cao đẳng");
$attributeArray[] = Attribute::newAttribute("experience","TEXT","NULL","EDITOR","NO_FK","TRUE","Kinh nghiệm");
$attributeArray[] = Attribute::newAttribute("careerHistory","TEXT","NULL","EDITOR","NO_FK","FALSE","Quá trình công tác");
$attributeArray[] = Attribute::newAttribute("referer","TEXT","NULL","DEFAULT","NO_FK","FALSE","Người xác nhận thông tin");
$attributeArray[] = Attribute::newAttribute("contactPerson","TEXT","NULL","EDITOR","NO_FK","FALSE","Người liên lạc khẩn cấp");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);


// 15.apply
$modelName = "apply";
$displayName = "Ứng tuyển";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","TRUE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("jobID","INT","NOT NULL","DEFAULT","job","TRUE","Job");
$attributeArray[] = Attribute::newAttribute("applicantID","INT","NOT NULL","DEFAULT","applicant","TRUE","Ứng viên");
$attributeArray[] = Attribute::newAttribute("hrStaffID","INT","NOT NULL","DEFAULT","account","TRUE","HR Staff");
$attributeArray[] = Attribute::newAttribute("applyStatusID","INT","NOT NULL","DEFAULT","applyStatus","TRUE","Status");
$attributeArray[] = Attribute::newAttribute("applyTypeID","INT","NOT NULL","DEFAULT","applyType","FALSE","Loại ứng tuyển");
$attributeArray[] = Attribute::newAttribute("source","VARCHAR","NULL","EDITOR","NO_FK","FALSE","Nguồn");
$attributeArray[] = Attribute::newAttribute("selfDescription","TEXT","NULL","EDITOR","NO_FK","FALSE","Tự giới thiệu");
$attributeArray[] = Attribute::newAttribute("cv","TEXT","NULL","DEFAULT","NO_FK","FALSE","CV");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
generate($projectName,$output,$databaseName,$modelName,$attributeArray,$homeURL,$displayName);



// 16.applyStatusHistory
$modelName = "applyStatus";
$displayName = "Trạng thái ứng tuyển";
$attributeArray = array();
$attributeArray[] = Attribute::newAttribute("id","INT","NOT NULL","DEFAULT","NO_FK","TRUE","ID");
$attributeArray[] = Attribute::newAttribute("active","INT","NOT NULL","DEFAULT","NO_FK","FALSE","Active");
// $attributeArray[] = Attribute::newAttribute("name","VARCHAR","NOT NULL","DEFAULT","NO_FK","TRUE","Tên");
$attributeArray[] = Attribute::newAttribute("description","TEXT","NULL","DEFAULT","NO_FK","FALSE","Mô tả");
$attributeArray[] = Attribute::newAttribute("createdTime","TIMESTAMP","NOT NULL","DEFAULT","NO_FK","TRUE","Ngày tạo");
$attributeArray[] = Attribute::newAttribute("applyStatusID","INT","NOT NULL","DEFAULT","applyStatus","TRUE","Status");
$attributeArray[] = Attribute::newAttribute("applyID","INT","NOT NULL","DEFAULT","apply","TRUE","Status");
// function generate($projectName,$output, $databaseName, $modelName, $attributeArray){
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
echo date('Y-m-d H:i:s')." - Created by <a href='fb.com/libert4692'>Harry Nguyen</a> 09/2019 - what af beautiful work!<br/>";
//Generating completed !
?>