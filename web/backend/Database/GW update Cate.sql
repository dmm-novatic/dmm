/****** Script for SelectTopNRows command from SSMS  ******/

SELECT  *  FROM [GW].[dbo].[PostCategory] where Active = 1 and ParentID = 10005


SELECT  *  FROM [GW].[dbo].[PostCategory] where Active = 1 and ParentID = 10287

ID	Active	ParentID	Name
10017	1	10284	Sữa
10018	1	10284	Thịt
10019	1	10284	Thủy sản

ID	Active	ParentID	Name
10010	1	10287	Cao su
10069	1	10287	Gỗ
10290	1	10287	TACN và nguyên liệu
10291	1	10287	Phân bón
10292	1	10287	Thuốc BVTV
 
ID	Active	ParentID	Name
10015	1	10005	Ngũ cốc
10284	1	10005	Protein động vật
10286	1	10005	Thực phẩm & Đồ uống
10287	1	10005	Vật tư nông nghiệp và khác

ID	Active	ParentID	Name
10008	1	10286	Đường
10012	1	10286	Chè
10013	1	10286	Hạt điều
10016	1	10286	Rau quả
10288	1	10286	Cà phê/Ca cao
10289	1	10286	Hạt tiêu

  select ID, Name, CreatedTime from Post where PostCategoryID = 10287

  
  --1. CAFE CACAO
  select ID, Name, CreatedTime from Post where PostCategoryID = 10286 AND Name like '%cà phê%' ;

  select ID, Name, CreatedTime from Post where PostCategoryID = 10286 AND Name like '%cacao%';

  
  select ID, Name, CreatedTime from Post where PostCategoryID = 10286 AND Name like '%rau%';
  
  select ID, Name, CreatedTime from Post where PostCategoryID = 10287 AND Name like N'%bón%';

  select ID, Name, CreatedTime from Post where PostCategoryID = 10286 AND Name like N'%đường%' and (ID != 43329   and ID !=  28565 and ID !=  28237 and ID != 28105);

  update Post set PostCategoryID =  10017 where ID in (select ID from Post where PostCategoryID = 10286 AND Name like N'%sữa%'  )

   