
------------------> UPDATE DATA GAPPINGWORLD BY TRANHIEU_BN <----------------------

use GW
go

-- update Postcategory not null
update PostCategory set Name2 = '' , PostCount = 0
go

--update Tag not null
update Tag set Slug2 = '' , PostCount = 0
go

--update PostCategory not null
update PostCategory set Slug2 = '', Photo = ''
go

--update data in FeaturePost table
SET IDENTITY_INSERT [dbo].[FeaturedPost] ON 

INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10016, 28777, 1, 1, N'Slide 1', N'', CAST(N'2019-12-16T03:22:27.593' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10017, 28775, 1, 1, N'Slide 2', N'', CAST(N'2019-12-16T03:22:41.213' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10018, 28736, 1, 1, N'Slide 3', N'', CAST(N'2019-12-16T03:22:57.377' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10019, 28628, 1, 1, N'Slide 4', N'', CAST(N'2019-12-16T03:23:12.727' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10020, 28617, 1, 1, N'Slide 5', N'', CAST(N'2019-12-16T03:23:26.387' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10021, 28653, 3, 1, N'Post 1', N'', CAST(N'2019-12-16T10:35:05.107' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10022, 28598, 3, 1, N'Post 2', N'', CAST(N'2019-12-16T10:35:19.567' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10023, 28655, 3, 1, N'Post 3', N'', CAST(N'2019-12-16T10:35:35.023' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10024, 28535, 3, 1, N'Post 4', N'', CAST(N'2019-12-16T10:35:47.427' AS DateTime))
INSERT [dbo].[FeaturedPost] ([ID], [PostID], [TypeID], [Active], [Name], [Description], [CreatedTime]) VALUES (10025, 28615, 3, 1, N'Post 5', N'', CAST(N'2019-12-16T10:36:02.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeaturedPost] OFF
Go

---------------------------------------------------------------------------
-- insert vào bảng PostCategory

--Công nghệ và dự báo
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Công nghệ và dự báo',N'','cong-nghe-va-du-bao','','','#000000','',0)
go

--Chính sách
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Chính sách',N'','chinh-sach','','','#000000','',0)
go

--Sự kiện ngành
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Sự kiện ngành',N'','su-kien-nganh','','','#000000','',0)
go

--Protein động vật
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Protein động vật',N'','protein-dong-vat','','','#000000','',0)
go

--Thực phẩm và đồ uống
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Thực Phẩm và Đồ uống',N'','thuc-pham-va-do-uong','','','#000000','',0)
go

--Vật tư nông nghiệp và khác
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Vật tư nông nghiệp và khác',N'','vat-tu-nong-nghiep-va-khac','','','#000000','',0)
go

--cà phê / cacao
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Cà phê/Ca cao',N'','ca-phe-cacao','','','#000000','',0)
go

--hạt tiêu
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Hạt tiêu',N'','hat-tieu','','','#000000','',0)
go

-- tacn và nguyên liệu
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'TACN và nguyên liệu',N'','tacn-va-nguyen-lieu','','','#000000','',0)
go

--phân bón
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Phân bón',N'','phan-bon','','','#000000','',0)
go

--thuốc bvtv
Insert into PostCategory(Active,ParentID,Name,Name2,Slug,Slug2,Photo,Color,Description,PostCount)
	values (1,0,N'Thuốc BVTV',N'','thuoc-bvtv','','','#000000','',0)
go



---------------------------------------------------
--update postcategoryID in Post table

--danh mục cà phê / cacao = caphe + cacao
update Post set PostCategoryID = 10288 where PostCategoryID in (10011,10068)
go

--danh mục hạt tiêu = hồ tiêu cũ
update Post set PostCategoryID = 10289 where PostCategoryID = 10014
go

-- danh mục TACN và nguyên liệu
update Post set PostCategoryID = 10290 where ID in (select PostID from PostTag where TagID in (10147,10632,11020))
go

--thuốc bảo vệ thực vật
update Post set PostCategoryID = 10292 where ID in (select PostID from PostTag where TagID in (12123,10762,10810))
go

--phân bón
update Post set PostCategoryID = 10291 where ID in (select PostID from PostTag where TagID = 10844)
go

--vật tư nông nghiệp và khác
update Post set PostCategoryID = 10287 where PostCategoryID = 10007
go

--chính sách
update Post set PostCategoryID = 10282 where ID in (select PostID from PostTag where TagID = 10152)
go

--thực phẩm và đồ uống : đưa trực tiếp thực phẩm + đồ uống vào
update Post set PostCategoryID = 10286 where PostCategoryID in (10058,10045)
go

--Cao su: thêm bài viết ở danh mục nguyên liệu thô vào danh mục này
update Post set PostCategoryID = 10010 where PostCategoryID = 10059
go

--thịt: thêm các bài trong thịt và thuỷ sản cũ và trong url có từ "thit"

 update Post set PostCategoryID = 10018 where PostCategoryID = 10057 and Url like '%thit%'
 go

 --thịt: thêm các bài trong thịt và thuỷ sản cũ và trong url có từ "chan-nuoi"

 update Post set PostCategoryID = 10018 where PostCategoryID = 10057 and Url like '%chan-nuoi%'
 

  --thịt: thêm các bài trong thịt và thuỷ sản cũ và trong url có từ "lon-song"

 update Post set PostCategoryID = 10018 where PostCategoryID = 10057 and Url like '%lon-song%'
 go

  --thịt: thêm các bài trong thịt và thuỷ sản cũ và trong text2 có từ "Pig"

  update Post set PostCategoryID = 10018 where PostCategoryID = 10057 and Text2 like '%Pig%'
  go

 --thuỷ sản: thêm các bài trong thịt và thuỷ sản còn lại
 update Post set PostCategoryID = 10018 where PostCategoryID = 10057
 go


----------------------------------------------------

--update parentID in PostCategory table

--hàng hoá
update PostCategory set ParentID = 10005 where ID in (10015,10284,10286,10287)
go

--công nghệ và dự báo
update PostCategory set ParentID = 10281 where ID in (10062,10063)
go

--protein động vật
update PostCategory set ParentID = 10284 where ID in (10018,10019,10017)
go

--thực phẩm và đồ uống
update PostCategory set ParentID = 10286 where ID in (10288,10012,10008,10013,10289,10016)
go

--vật tư nông nghiệp và khác
update PostCategory set ParentID = 10287 where ID in (10290,10291,10292,10010,10069)
go