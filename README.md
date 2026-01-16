MobileStore
Website bán hàng điện thoại di động được xây dựng bằng kiến trúc ASP.NET Core MVC.

Công nghệ sử dụng
Framework: .NET 10.0 (ASP.NET Core MVC)
Database: SQL Server
ORM: Entity Framework Core
Giao diện: Bootstrap 5, CSS3, FontAwesome

Các tính năng chính
Trang chủ: Hiển thị Banner và danh sách sản phẩm nổi bật.
Danh mục sản phẩm: Phân loại điện thoại theo hãng sản xuất.
Chi tiết sản phẩm: Xem thông tin cấu hình, mô tả và giá bán.
Giỏ hàng: Thêm, xóa và cập nhật số lượng sản phẩm.
Tìm kiếm: Tìm kiếm sản phẩm theo tên.
Xác thực: Đăng ký, đăng nhập người dùng (Identity).

Hướng dẫn cài đặt
Clone dự án: git clone https://github.com/ducanhcah/MobileStore.git
Cấu hình chuỗi kết nối Database trong file appsettings.json.
Cập nhật cơ sở dữ liệu (Migration): dotnet ef database update
Chạy dự án: dotnet run

Cấu trúc thư mục
Controllers: Xử lý logic điều hướng và yêu cầu.
Models: Định nghĩa cấu trúc dữ liệu sản phẩm, danh mục, giỏ hàng.
Views: Giao diện người dùng (Razor Pages).
Data: Cấu hình DbContext và Seed Data.
wwwroot: Chứa các tệp tĩnh như hình ảnh, CSS và JavaScript.
