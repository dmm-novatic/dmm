document.writeln("<script src='https://cdnjs.cloudflare.com/ajax/libs/crypto-js/3.1.2/rollups/aes.js'></script>");
window.aedapi = (function () {	
	var listAPIKey = [
		'aedssomockapikey'
	];
	var keyEncryption = "vnext@2022";
	var aedapi = {
		client: {
			init: function (dataKey) {
				if (dataKey && dataKey.apiKey) {
					console.log(dataKey.apiKey)
					if (listAPIKey.includes(dataKey.apiKey)) 
						return new Promise((resolve, reject) => resolve('apiKey is valid'))
					return new Promise((resolve, reject) => reject({message: 'apiKey is invalid'}))
				}
				return new Promise((resolve, reject) => reject({message: 'apiKey is invalid'}))
			},

			open: function (type) {
				if (type === 'login') {
					const urlLogin = './login.html'
					window.open(urlLogin, '_blank')
				} else {
					const urlLogout = './logout.html'
					window.open(urlLogout, '_blank')
				}
			},

			saveToken: function (data) {
				if (data) {
					var encrypted = CryptoJS.AES.encrypt(data, keyEncryption);
					localStorage.setItem('token', encrypted.toString())
				}
			},

			removeToken: function () {
				const token = localStorage.getItem('token')
				if (token) {
					localStorage.removeItem('token')
				}
			},

			get: function (type) {
				const token = localStorage.getItem('token');
				if (token) {
					const decrypted = CryptoJS.AES.decrypt(token, keyEncryption);
					const tokenSend = decrypted.toString(CryptoJS.enc.Utf8);
					if (type === 'profile') {
						var response = 
							{
								"id": 1,
								"email" : "nguyenvana@gmail.com",
								"email_confirm_code" : 123456,
								"is_active": true,
								"is_deleted": false,
								"is_email_confirm": true,
								"is_lock_out_enable": false,
								"is_phone_number_confirm": true,
								"is_two_factor_enable": true,
								"last_modifier_time": "2021-12-12 01:11:11",
								"last_modifier_userId": 11,
								"name": "Nguyen Van A",
								"normalized_email_addrres" : "nguyenvana@gov.com.vn",
								"normalized_user_name": "Nguyen Van A",
								"phone_number": "0123456789",
								"sur_name": "Van A",
								"tenantId" : 1,
								"user_name" : "Nguyen Van A",
								"department" : "Bo Tai Chinh",
								"is_sub_account" : true
							}
						// call api get profile and return response
						// var profile = getProfile(tokenSend)
						// .then(function (response) {
						// 	if (response.data) return response.data
						// }, function (error) {
						// 	console.log('Error: ' + error.message);
						// });
						return new Promise((resolve, reject) => 
							resolve(response)
						)
					} else if (type === 'enterprise') { // get enterprise info
						// var enterpriseInfo = getEnterpriseInfo(tokenSend)
						// .then(function (response) {
						// 	if (response.data) return response.data
						// }, function (error) {
						// 	console.log('Error: ' + error.message);
						// });
						const response = 
						{
							"id": 1,
							"loaiHinhDoanhNghiep": {
								"id": 1,
								"tenLoaiHinh": "Công ty cổ phần",
								"isDNNN": true
							},
							"organizationUnit": {
								"id": 6,
								"parentName": "Tập đoàn",
								"code": "00001.00003",
								"parentId": 0,
								"name": "Tập Đoàn Công Nghiệp Cao Su Việt Nam"
							},
							"isActive": true,
							"ngayPheDuyet": "2022-01-11T01:59:05.495Z",
							"ghiChuPheDuyet": "phê duyệt",
							"creationTime": "2022-01-11T01:59:05.495Z",
							"creatorUserId": 0,
							"lastModifierUserId": 0,
							"lastModificationTime": "2022-01-11T01:59:05.495Z",
							"tenTinhThanh": "Đà Nẵng",
							"tenQuanHuyen": "Quận Ngũ Hành Sơn",
							"maSoThue": "035353",
							"idDangKyKinhDoanh": "10",
							"tinhTrangThanhLap": 0,
							"ngayThanhLap": "2022-01-11T01:59:05.495Z",
							"isDnnn": true,
							"tenGiaoDich": "xxxx",
							"tenTiengAnh": "xxxxxx",
							"tenVietTat": "xx",
							"loaiHinhDoanhNghiepId": 0,
							"organizationUnitId": 0,
							"hasDoanhNghiepCon": true,
							"capDoanhNghiep": 0,
							"tileVonNhaNuoc": 0,
							"diaChi": "xx/xxxx",
							"email": "nguyenvanb@gmail.com",
							"dienThoai": "097xxxxx",
							"website": "https://website",
							"vonDieuLe": 200000,
							"tongSoLaoDong": 1000,
							"maGiaoDich": "99",
							"nguoiDaiDien": "nguyen van a",
							"gioiTinh": 0,
							"ngaySinh": "2022-01-11T01:59:05.495Z",
							"cmnd": "209338XXXX",
							"chucVuNguoiDaiDien": "giamdoc",
							"emailNguoiDaiDien": "nguyenvana@gmail.com",
							"dienThoaiNguoiDaiDien": "021213889",
							"maTinhThanh": "00003.00015",
							"maQuanHuyen": "00003.00015.00004",
							"moTa": "mô tả doang nghiệp",
							"trangThaiHoatDong": 0
						}
						return new Promise((resolve, reject) => 
							resolve(response)
						)
					}
				} else {
					return new Promise((resolve, reject) => 
							reject({message: 'token is invalid'})
						)
				}
			},

			update: function (data) {
				const token = localStorage.getItem('token');
				if (token) {
					const decrypted = CryptoJS.AES.decrypt(token, keyEncryption);
					const tokenSend = decrypted.toString(CryptoJS.enc.Utf8);
					var tmp = {
						"id": 1,
						"email": "nguyenvanb@gmail.com",
						"email_confirm_code": 123456,
						"is_active": true,
						"is_deleted": false,
						"is_email_confirm": true,
						"is_lock_out_enable": false,
						"is_phone_number_confirm": true,
						"is_two_factor_enable": true,
						"last_modifier_time": "2021-12-12 01:11:11",
						"last_modifier_userId": 11,
						"name": "Nguyen Van B",
						"normalized_email_addrres": "nguyenvanb@gov.com.vn",
						"normalized_user_name": "Nguyen Van B",
						"phone_number": "0123456789",
						"sur_name": "Van B",
						"tenantId": 1,
						"user_name": "Nguyen Van B",
						"department": "Bo Tai Chinh",
						"is_sub_account": true
					}
					if (data && data.profile) {
						// call api update profile and return response
						// var resUpdateProfile = updateProfile(JSON.stringify(tmp), tokenSend)
						// .then(function (response) {
						// 	if (response.data) return response.data
						// }, function (error) {
						// 	console.log('Error: ' + error.message);
						// });
						return new Promise((resolve, reject) => 
							resolve(tmp)
						)
					}
				} else {
					return new Promise((resolve, reject) => 
							reject({message: 'token is invalid'})
						)
				}
			}
		},

		load: function (ls, fuc) {
			if (ls === 'client') {
				var c = fuc()
				return c
			}
		}
	};
	const getProfile = async (token) => {
		const response = await fetch('URL get profile', {
			method: 'GET',
			// body: myBody, // string or object
			headers: {
				'Content-Type': 'application/json',
				'Authorization': 'bearer ' + token
			}
		});
		const myJson = await response.json(); //extract JSON from the http response
		// do something with myJson
		return myJson
	};
	const updateProfile = async (param, token) => {
		const response = await fetch('URL update profile', {
			method: 'PUT',
			body: param, // string or object
			headers: {
				'Content-Type': 'application/json',
				'Authorization': 'bearer ' + token
			}
		});
		const myJson = await response.json(); //extract JSON from the http response
		// do something with myJson
		return myJson
	};
	const getEnterpriseInfo = async (token) => {
		const response = await fetch('URL get enterprise', {
			method: 'GET',
			// body: myBody, // string or object
			headers: {
				'Content-Type': 'application/json',
				'Authorization': 'bearer ' + token
			}
		});
		const myJson = await response.json(); //extract JSON from the http response
		// do something with myJson
		return myJson
	};
	return aedapi;
}());