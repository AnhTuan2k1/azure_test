create database CinemaDB
use CinemaDB
set dateformat DMY

create table Account
(
	ID INT IDENTITY PRIMARY KEY,
	Username nvarchar(50) not null,
	Password nvarchar(50) not null,
	type nvarchar(20) not null,
)

create table Employee
(
	ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(60),
	Email nvarchar(70),
	Phone nvarchar(50),
	Birthday smalldatetime,
	AvatarUrl nvarchar(500),
	AccountID int not null foreign key references Account(ID),
)

create table Customer
(
	ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(60),
	Email nvarchar(70),
	Phone nvarchar(50),
	Birthday datetime,
	AvatarUrl nvarchar(500),
	AccountID int not null foreign key references Account(ID),
)

create table Cinema
(
	ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(60),
	Location nvarchar(200),
	ImageUrl nvarchar(500),
)

create table FilmGenre
(
    ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(50) not null,
)

create table Film
(
	ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(100) default '',
	Content nvarchar(4000) default '',
	FilmGenreID int not null foreign key references FilmGenre(ID),
	Length int,
	OpenningDay smalldatetime,
	ImageUrl nvarchar(500),
	TrailerUrl nvarchar(500),
	Nation nvarchar(500),
	Directior nvarchar(50),
	Cast nvarchar(200),
)

create table ProjectionRoom
(
	ID INT IDENTITY PRIMARY KEY,
	Name nvarchar(60),
	ScreenType nvarchar(20),
	CinemaID int not null foreign key references Cinema(ID)
)

create table ShowTimes
(
	ID INT IDENTITY PRIMARY KEY,
	StartTime smalldatetime not null,
	FilmID int not null foreign key references Film(ID),
	ProjectionRoomID int not null foreign key references ProjectionRoom(ID),
	CinemaID int not null foreign key references Cinema(ID)
)

create table Rate
(
	ID INT IDENTITY PRIMARY KEY,
	Point int not null,
	FilmID int not null foreign key references Film(ID),
	Customer int not null foreign key references Customer(ID),
)

create table Comment
(
	ID INT IDENTITY PRIMARY KEY,
	Content nvarchar(500) not null,
	FilmID int not null foreign key references Film(ID),
	Customer int not null foreign key references Customer(ID),
)

create table Ticket
(
	ID int identity primary key,
	DateSale smalldatetime not null,
	Seat nvarchar(50) not null,
	TicketType nvarchar(50) default N'Người Lớn',
	Money int default 100000,
	ShowTimes int not null foreign key references ShowTimes(ID),
	Customer int not null foreign key references Customer(ID),
	Employee int not null foreign key references Employee(ID),
)

create table Invoice
(
	ID int identity primary key,
	DateCreate smalldatetime not null,
	TotalPrice money,
	Customer int not null foreign key references Customer(ID),
	Employee int not null foreign key references Employee(ID)
)

create table InvoiceDetail
(
	Quantity int,
    InvoiceID int not null foreign key references Invoice(ID),
	TicketID int not null foreign key references Ticket(ID)
)

--Scaffold-DbContext "Server=(local);Database=CinemaDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

insert into Account(Username, Password, type) values('admin','1','Admin')
insert into Account(Username, Password, type) values('tuan','123','Customer')
insert into Account(Username, Password, type) values('anh','123','Employee')
insert into Account(Username, Password, type) values('quy','123','Employee')

insert into Employee(Name, Email, Phone, Birthday, AvatarUrl, AccountID) values(N'Anh Anh', 'anh@gmail.com', '0165416525', '12/10/2000'
,'https://firebasestorage.googleapis.com/v0/b/cooking-afe47.appspot.com/o/others%2Fdragon-100.png?alt=media&token=0b205c77-90cf-45be-80aa-2a4820777d0b'
,'3')
insert into Employee(Name, Email, Phone, Birthday, AvatarUrl, AccountID) values(N'Truong Quy', 'quy@gmail.com', '0165416525', '1/2/2001'
,'https://firebasestorage.googleapis.com/v0/b/cooking-afe47.appspot.com/o/others%2Fdragon-100.png?alt=media&token=0b205c77-90cf-45be-80aa-2a4820777d0b'
,'4')

insert into Customer(Name, Email, Phone, Birthday, AvatarUrl, AccountID) values(N'Tran Tuan','cuopnhaxac2001@gmail.com','0165416525'
,'5/2/1999','https://firebasestorage.googleapis.com/v0/b/cooking-afe47.appspot.com/o/others%2Fdragon-100.png?alt=media&token=0b205c77-90cf-45be-80aa-2a4820777d0b'
,'2')

insert into Cinema(Name, Location, ImageUrl) values(N'Hai Bà Trưng',N'135 Hai Bà Trưng, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh'
,'https://firebasestorage.googleapis.com/v0/b/cooking-afe47.appspot.com/o/others%2Fdragon-100.png?alt=media&token=0b205c77-90cf-45be-80aa-2a4820777d0b')
insert into Cinema(Name, Location, ImageUrl) values(N'Quốc Thanh',N'271 Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh'
,'https://firebasestorage.googleapis.com/v0/b/cooking-afe47.appspot.com/o/others%2Fdragon-100.png?alt=media&token=0b205c77-90cf-45be-80aa-2a4820777d0b')


insert into FilmGenre(Name) values(N'Hành Động') --1
insert into FilmGenre(Name) values(N'Kinh Dị')
insert into FilmGenre(Name) values(N'Hoạt Hình')
insert into FilmGenre(Name) values(N'Bom Tấn')
insert into FilmGenre(Name) values(N'Hài')
insert into FilmGenre(Name) values(N'Tình Cảm')
insert into FilmGenre(Name) values(N'Khoa Học Viễn Tưởng')
insert into FilmGenre(Name) values(N'Gia Đình')

insert into Film(Name, Content, FilmGenreID, Length, OpenningDay, ImageUrl, TrailerUrl, Nation, Directior, Cast)
values (N'NỮ VƯƠNG HUYỀN THOẠI',N'Lấy cảm hứng từ những sự kiện có thật trong lịch sử đã xảy ra ở Vương quốc Dahomey - một trong những quốc gia hùng mạnh nhất của châu Phi thế kỷ 18 và 19. “Nữ Vương Huyền Thoại” xoay quanh nhóm chiến binh toàn nữ Agojie với nhiệm vụ bảo vệ vương quốc và đức vua. Vị tướng Nanisca huấn luyện một thế hệ chiến binh mới để chiến đấu chống lại kẻ thù muốn phá hủy lối sống của họ'
           ,'1','135','12/10/2022','https://cdn.galaxycine.vn/media/2022/10/8/1200x1800_1665216609067.jpg'
		   ,'https://www.youtube.com/watch?v=7UIEvSSCwJA&ab_channel=GalaxyCinema%28Official%29'
		   ,N'Cannada, MỸ', 'Gina Prince-Bythewood','Viola Davis, Thuso Mbedu, Lashana Lynch')
insert into Film(Name, Content, FilmGenreID, Length, OpenningDay, ImageUrl, TrailerUrl, Nation, Directior, Cast)
values (N'BLACK ADAM',N'Black Adam được các fan truyện tranh biết đến nhiều nhất trong vai trò kẻ thù - đối thủ lớn nhất của siêu anh hùng Shazam của vũ trụ truyện tranh và điện ảnh DC. Theo nhiều phiên bản truyện, nếu như người được chọn hô to câu thần chú “Shazam!” sẽ lập tức nhận được sức mạnh của phù thủy cổ xưa, thì câu thần chú này sẽ giúp cho Black Adam có được sức mạnh của 6 vị thần Ai Cập cổ đại gồm: Shu (Thần Gió với sức mạnh bất khả chiến bại), Heru (Vị thần của bầu trời, chiến tranh và săn bắn với siêu tốc độ), Amon (Thần bảo hộ các Pharaoh ban cho thể lực dồi dào), Zehuti (Vị thần của trí tuệ vô song), Aton (cho Black Adam sức mạnh của sấm sét) and Mehen (Thần Rắn với sức mạnh của lòng can đảm).'
           ,'1','125','20/10/2022','https://cdn.galaxycine.vn/media/2022/9/26/900wx1350h_1664177555434.jpg'
		   ,'https://www.youtube.com/watch?v=XBH5bmXOyUc&ab_channel=GalaxyCinema%28Official%29'
		   ,N'MỸ','Jaume Collet-Serra','Dwayne Johnson, Pierce Brosnan, Sarah Shahi')
insert into Film(Name, Content, FilmGenreID, Length, OpenningDay, ImageUrl, TrailerUrl, Nation, Directior, Cast)
values (N'Confidential Assignment 2: International',N'Đặc vụ Tiên Lim Cheol-ryung (Hyun Bin) trở lại Hàn Quốc để đánh Triều một tổ chức phạm tội. Cùng lúc đó, Kang Jin-tae (Yoo Hae Jin) ở Đơn vị phạm tội mạng đang khao khát trở lại đơn vị cũ, thì được trao cho một nhiệm vụ đặc biệt với Cheol-ryung. Min-young (Lim YoonA) cũng có cơ hội tiếp tục câu chuyện tình yêu “phát cuồng” dành cho Cheol-ryung. Jin-tae và Cheol-ryung cùng làm việc dù vẫn còn nhiều nghi ngờ về động cơ của đối phương. Ngay khi bộ đôi chuẩn bị kích hoạt ẩn náu của Jang Myung-jun (Jin Sun Kyu), thủ lĩnh của tổ chức phạm tội, đặc vụ FBI Jack (Daniel Henney) xông vào. This new prefixed to the Traversation thành một cuộc điều tra quốc tế giữa 3 quốc gia, hẹn ước nhiều tình tiết kịch tính và toàn bộ bất ngờ.'
           ,'1','129','27/10/2022','https://cdn.galaxycine.vn/media/2022/10/12/1200wx1800h_1665592993771.jpg'
		   ,'https://www.youtube.com/watch?v=t0ixlAp4BSU&feature=emb_title'
		   ,N'Hàn Quốc','Lee Seok Hoon','Hyun Bin, Lim Yoona, Daniel Henney, Yoo Hae Jin')
		   insert into Film(Name, Content, FilmGenreID, Length, OpenningDay, ImageUrl, TrailerUrl, Nation, Directior, Cast)
values (N'Lyle, Chú Cá Sấu Biết Hát',N'Khi gia đình Primm chuyển đến thành phố New York, cậu con trai nhỏ Josh gặp khó khăn trong việc thích nghi với ngôi trường và những người bạn mới. Mọi thứ thay đổi khi cậu bé phát hiện ra ra Lyle - một chàng cá sấu mê tắm rửa, trứng cá muối và âm nhạc sống trên gác mái của của mình. Hai người nhanh chóng trở thành bạn bè. Thế nhưng, khi cuộc sống của Lyle bị ông hàng xóm Grumps đe dọa, gia đình Primm buộc phải kết hợp với ông chủ cũ của Lyle là Hector P. Valenti (Javier Bardem) để cho cả thế giới thấy giá trị tình thân và sự kỳ diệu của một chàng cá sấu biết hát. '
           ,'1','104','4/11/2022','https://cdn.galaxycine.vn/media/2022/11/1/1200x1800_1667275197172.jpg'
		   ,'https://www.youtube.com/watch?v=J14BfxOUxIs&feature=emb_title'
		   ,N'MỸ','Will Speck, Josh Gordon','Shawn Mendes, Javier Bardem, Winslow Fegley')

insert into ProjectionRoom(Name, ScreenType, CinemaID) values(N'Cinema 1','2D','1')
insert into ProjectionRoom(Name, ScreenType, CinemaID) values(N'Cinema 2','2D','1')
insert into ProjectionRoom(Name, ScreenType, CinemaID) values(N'Cinema 1','2D','2')
insert into ProjectionRoom(Name, ScreenType, CinemaID) values(N'Cinema 2','2D','2')
