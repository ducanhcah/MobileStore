<div align="center">
  <h1>MOBILE STORE PROJECT</h1>
  <p>Hệ thống quản lý và bán lẻ điện thoại di động trực tuyến</p>
</div>

<hr>

<h3>1. Công nghệ cốt lõi</h3>
<ul>
  <li><b>Framework:</b> .NET 10.0 (ASP.NET Core MVC)</li>
  <li><b>Cơ sở dữ liệu:</b> SQL Server</li>
  <li><b>Thư viện:</b> Entity Framework Core, Identity</li>
  <li><b>Front-end:</b> HTML5, CSS3, Bootstrap 5</li>
</ul>

<h3>2. Chức năng hệ thống</h3>
<table width="100%">
  <tr>
    <td><b>Người dùng</b></td>
    <td>Xem sản phẩm, Chi tiết sản phẩm, Tìm kiếm, Giỏ hàng</td>
  </tr>
  <tr>
    <td><b>Hệ thống</b></td>
    <td>Đăng ký, Đăng nhập, Phân quyền người dùng</td>
  </tr>
  <tr>
    <td><b>Dữ liệu</b></td>
    <td>Phân loại sản phẩm theo danh mục (Category)</td>
  </tr>
</table>

<h3>3. Hướng dẫn triển khai</h3>
<pre>
# 1. Tải mã nguồn
git clone https://github.com/ducanhcah/MobileStore.git

# 2. Cấu hình Database
Mở appsettings.json và chỉnh sửa ConnectionStrings:
"DefaultConnection": "Server=Kirai;Database=MobileStoreDB;..."

# 3. Tạo bảng dữ liệu
dotnet ef database update

# 4. Chạy ứng dụng
dotnet run
</pre>

<h3>4. Cấu trúc thư mục</h3>
<ul>
  <li><b>Controllers:</b> Điều hướng và xử lý logic nghiệp vụ.</li>
  <li><b>Models:</b> Định nghĩa thực thể (Product, Category, Cart).</li>
  <li><b>Views:</b> Giao diện hiển thị người dùng (.cshtml).</li>
  <li><b>Data:</b> Quản lý kết nối Database và dữ liệu mẫu.</li>
  <li><b>wwwroot:</b> Chứa tài nguyên tĩnh (Images, CSS, JS).</li>
</ul>

<hr>

<div align="center">
  <p>Dự án được phát triển bởi <b>ducanhcah</b></p>
</div>
