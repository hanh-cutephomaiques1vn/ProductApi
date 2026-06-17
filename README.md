# ProductApi - Tuần 5: ASP.NET Core Web API Basics

## Giới thiệu

Dự án **ProductApi** là một Web API được xây dựng bằng **ASP.NET Core 8.0** nhằm thực hành các kiến thức cơ bản về Web API, bao gồm:

- Cấu trúc Controller và Routing
- Các phương thức HTTP (GET, POST, PUT, DELETE)
- Minimal APIs (phong cách mới)
- Tài liệu hóa API với Swagger/OpenAPI

## Công nghệ sử dụng

| Công nghệ | Phiên bản |
|------------|-----------|
| .NET | 8.0 |
| ASP.NET Core Web API | 8.0 |
| Swashbuckle (Swagger) | 6.6.2 |
| IDE | Visual Studio 2022 |

## Cấu trúc dự án

```
ProductApi/
├── Controllers/
│   └── ProductController.cs      # Controller truyền thống (CRUD)
├── Models/
│   └── Product.cs                # Model sản phẩm
├── Program.cs                    # Cấu hình app + Minimal APIs
├── ProductApi.csproj             # File quản lý dependencies
├── appsettings.json              # Cấu hình ứng dụng
└── README.md                     # Tài liệu mô tả API
```

## Cách chạy dự án

```bash
# Clone repository
git clone https://github.com/hanh-cutephomaiques1vn/ProductApi.git

# Di chuyển vào thư mục dự án
cd ProductApi

# Chạy ứng dụng
dotnet run

# Truy cập Swagger UI
# https://localhost:{port}/swagger
```

## Danh sách API Endpoints

### 1. Controller APIs — `api/product`

Sử dụng **Controller truyền thống** kế thừa `ControllerBase` với attribute routing `[Route("api/[controller]")]`.

| Method | URL | Mô tả | Request Body | Response |
|--------|-----|--------|-------------|----------|
| `GET` | `/api/product` | Lấy tất cả sản phẩm | — | `200 OK` + danh sách Product |
| `GET` | `/api/product/{id}` | Lấy sản phẩm theo ID | — | `200 OK` + Product / `404 Not Found` |
| `POST` | `/api/product` | Thêm sản phẩm mới | `{ "id", "name", "price" }` | `201 Created` + Product |
| `PUT` | `/api/product/{id}` | Cập nhật sản phẩm | `{ "id", "name", "price" }` | `204 No Content` / `404 Not Found` |
| `DELETE` | `/api/product/{id}` | Xóa sản phẩm | — | `204 No Content` / `404 Not Found` |

### 2. Minimal APIs — `api/minimal/products`

Sử dụng **Minimal APIs** (MapGet, MapPost, MapPut, MapDelete) trong `Program.cs` — phong cách mới của .NET.

| Method | URL | Mô tả | Request Body | Response |
|--------|-----|--------|-------------|----------|
| `GET` | `/api/minimal/products` | Lấy tất cả sản phẩm | — | `200 OK` + danh sách Product |
| `GET` | `/api/minimal/products/{id}` | Lấy sản phẩm theo ID | — | `200 OK` + Product / `404 Not Found` |
| `POST` | `/api/minimal/products` | Thêm sản phẩm mới | `{ "id", "name", "price" }` | `201 Created` + Product |
| `PUT` | `/api/minimal/products/{id}` | Cập nhật sản phẩm | `{ "id", "name", "price" }` | `204 No Content` / `404 Not Found` |
| `DELETE` | `/api/minimal/products/{id}` | Xóa sản phẩm | — | `204 No Content` / `404 Not Found` |

## Model — Product

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 15000000
}
```

| Trường | Kiểu | Mô tả |
|--------|------|--------|
| `id` | `int` | Mã sản phẩm |
| `name` | `string` | Tên sản phẩm |
| `price` | `decimal` | Giá sản phẩm (VND) |

## So sánh Controller vs Minimal APIs

| Tiêu chí | Controller | Minimal APIs |
|----------|-----------|--------------|
| Cấu trúc | Class kế thừa `ControllerBase` | Lambda trong `Program.cs` |
| Routing | `[Route]`, `[HttpGet]` attributes | `MapGet()`, `MapPost()` methods |
| Phù hợp | Dự án lớn, phức tạp | Prototype, microservices nhỏ |
| Tổ chức code | Tách riêng file Controller | Tập trung trong `Program.cs` |

## Kiểm thử API

Sử dụng **Swagger UI** tại đường dẫn `/swagger` khi chạy ứng dụng ở chế độ Development để kiểm thử tất cả các endpoints mà không cần Front-end.

## Tác giả

- **Hạnh** — Thực tập sinh (TTS)
- GitHub: [hanh-cutephomaiques1vn](https://github.com/hanh-cutephomaiques1vn)
