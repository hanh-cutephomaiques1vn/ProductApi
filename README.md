# ProductApi — Tuần 5 & Tuần 6

REST API xây dựng bằng **ASP.NET Core 8.0 Web API** với Entity Framework Core, Dependency Injection, Data Validation, Custom Middleware và Swagger UI.

---

## 🚀 Cách chạy

```bash
# Clone repository
git clone https://github.com/hanh-cutephomaiques1vn/ProductApi.git
cd ProductApi

# Khôi phục packages
dotnet restore

# Cập nhật database (MSSQL)
dotnet ef database update

# Chạy ứng dụng
dotnet run
```

- **Swagger UI**: `https://localhost:{port}/swagger`

---

## 🏗️ Kiến trúc dự án

```
ProductApi/
├── Controllers/
│   └── ProductController.cs          # API Controller — CRUD endpoints
├── Data/
│   └── AppDbContext.cs               # EF Core DbContext — kết nối MSSQL
├── Middleware/
│   └── RequestLoggingMiddleware.cs   # Custom Middleware — log thời gian request
├── Migrations/                       # EF Core Migrations
├── Models/
│   └── Product.cs                    # Model + Data Annotations Validation
├── Services/
│   ├── IProductService.cs            # Interface — tách biệt logic
│   └── ProductService.cs            # Implementation — thao tác DB qua EF Core
├── Program.cs                        # Entry point — DI, Middleware, Pipeline
├── appsettings.json                  # Connection string MSSQL
├── ProductApi.csproj                 # Dependencies
└── README.md
```

---

## 📦 Model — Product

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 15000000
}
```

### Data Annotations Validation

| Trường  | Kiểu      | Validation                                       |
|---------|-----------|--------------------------------------------------|
| `Id`    | `int`     | Auto-generated                                   |
| `Name`  | `string`  | `[Required]`, `[StringLength(100, Min = 2)]`     |
| `Price` | `decimal` | `[Required]`, `[Range(0, 1,000,000,000)]`        |

> Nếu dữ liệu không hợp lệ → API trả về `400 Bad Request` kèm thông báo lỗi chi tiết.

---

## 📋 Danh sách API Endpoints

Base URL: `/api/product`

| Method   | Endpoint              | Mô tả                  | Request Body          | Response              |
|----------|-----------------------|-------------------------|-----------------------|-----------------------|
| `GET`    | `/api/product`        | Lấy tất cả sản phẩm    | —                     | `200 OK`              |
| `GET`    | `/api/product/{id}`   | Lấy sản phẩm theo ID   | —                     | `200 OK` / `404`      |
| `POST`   | `/api/product`        | Thêm sản phẩm mới      | `{ name, price }`     | `201 Created` / `400` |
| `PUT`    | `/api/product/{id}`   | Cập nhật sản phẩm      | `{ name, price }`     | `204 No Content` / `404` / `400` |
| `DELETE` | `/api/product/{id}`   | Xóa sản phẩm           | —                     | `204 No Content` / `404` |

### Chi tiết Endpoints

#### `GET /api/product` — Lấy danh sách sản phẩm

```json
// Response 200 OK
[
  { "id": 1, "name": "Laptop", "price": 15000000 },
  { "id": 2, "name": "Mouse", "price": 200000 }
]
```

#### `GET /api/product/{id}` — Lấy sản phẩm theo ID

```json
// Response 200 OK
{ "id": 1, "name": "Laptop", "price": 15000000 }

// Response 404 Not Found
{ "message": "Không tìm thấy sản phẩm với Id = 99" }
```

#### `POST /api/product` — Thêm sản phẩm mới

```json
// Request Body
{ "name": "Keyboard", "price": 500000 }

// Response 201 Created
{ "id": 3, "name": "Keyboard", "price": 500000 }

// Response 400 Bad Request (validation failed)
{
  "Name": ["Tên sản phẩm là bắt buộc"],
  "Price": ["Giá sản phẩm phải từ 0 đến 1,000,000,000 VND"]
}
```

#### `PUT /api/product/{id}` — Cập nhật sản phẩm

```json
// Request Body
{ "name": "Laptop Gaming", "price": 25000000 }

// Response 204 No Content (thành công)
// Response 404 Not Found (không tìm thấy)
// Response 400 Bad Request (dữ liệu không hợp lệ)
```

#### `DELETE /api/product/{id}` — Xóa sản phẩm

```json
// Response 204 No Content (thành công)
// Response 404 Not Found (không tìm thấy)
```

---

## 🔧 Dependency Injection (DI)

| Service | Lifetime | Mô tả |
|---------|----------|--------|
| `AppDbContext` | **Scoped** | Mỗi HTTP request tạo một DbContext riêng |
| `IProductService` → `ProductService` | **Scoped** | Tách biệt business logic ra khỏi Controller |

### 3 loại vòng đời DI:
- **Transient**: Tạo mới mỗi lần inject
- **Scoped**: Tạo mới mỗi HTTP request (phù hợp cho DbContext, Service)
- **Singleton**: Duy nhất trong toàn bộ ứng dụng

---

## 🛡️ Custom Middleware

### RequestLoggingMiddleware

Middleware tùy chỉnh ghi log thời gian xử lý của mỗi HTTP request.

**Ví dụ output log:**
```
>>> Request: GET /api/product - Bắt đầu xử lý
<<< Response: GET /api/product - Status: 200 - Thời gian: 15ms
```

---

## 🗄️ Kết nối Database

- **Database**: Microsoft SQL Server (MSSQL)
- **ORM**: Entity Framework Core 8.0
- **Connection String**: Cấu hình trong `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ProductApiDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## 📚 Công nghệ sử dụng

| Công nghệ | Phiên bản |
|------------|-----------|
| .NET | 8.0 |
| ASP.NET Core Web API | 8.0 |
| Entity Framework Core | 8.0 |
| SQL Server | MSSQL |
| Swashbuckle (Swagger) | 6.6.2 |

---

## 👤 Tác giả

- **Hạnh** — Thực tập sinh (TTS)
- GitHub: [hanh-cutephomaiques1vn](https://github.com/hanh-cutephomaiques1vn)
