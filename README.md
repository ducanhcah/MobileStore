MobileStore Flagship - Cửa hàng điện thoại trực tuyến
Dự án website bán lẻ điện thoại di động được xây dựng bằng ASP.NET Core 10.0 MVC. Website có giao diện hiện đại, hỗ trợ quản lý sản phẩm, danh mục và giỏ hàng.

Tính năng chính
Trang chủ: Hiển thị Banner quảng cáo và các sản phẩm nổi bật.
Chi tiết sản phẩm: Xem thông số kỹ thuật, giá bán và hình ảnh chất lượng cao.
Danh mục: Phân loại điện thoại theo hãng (iPhone, Samsung, Xiaomi...).
Giỏ hàng: Thêm/Xóa sản phẩm, cập nhật số lượng và tính tổng tiền.
Xác thực: Hệ thống Đăng ký/Đăng nhập dành cho người dùng (Sắp ra mắt).

Công nghệ sử dụng
Back-end: .NET 8.0, ASP.NET Core MVC.
Database: SQL Server (Server Name: Kirai).
ORM: Entity Framework Core.
Front-end: Bootstrap 5, FontAwesome, CSS3 (Glassmorphism design).

Hướng dẫn cài đặt
1. Yêu cầu hệ thống
Đã cài đặt .NET 8.0 SDK.
SQL Server đang hoạt động (Instance name: Kirai).
2. Cấu hình Database
Mở file appsettings.json và kiểm tra chuỗi kết nối:
JSON
"DefaultConnection": "Server=Kirai;Database=MobileStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
3. Chạy lệnh Migration
Mở Terminal tại thư mục dự án và thực hiện lệnh sau để tạo cấu trúc bảng:
Bash
dotnet ef database update
4. Khởi chạy ứng dụng
Bash
dotnet run
Sau đó truy cập: http://localhost:5000
