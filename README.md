# ProductApi

REST API xây dựng bằng **ASP.NET Core Web API** với Swagger UI.

## 🚀 Cách chạy

```bash
dotnet run
```

- **HTTP**: `http://localhost:5295`
- **HTTPS**: `https://localhost:7177`
- **Swagger UI**: `http://localhost:5295/swagger`

---

## 📦 Models

### Product

| Trường  | Kiểu dữ liệu | Mô tả         |
|---------|---------------|----------------|
| `Id`    | `int`         | Mã sản phẩm    |
| `Name`  | `string`      | Tên sản phẩm   |
| `Price` | `decimal`     | Giá sản phẩm   |

### WeatherForecast

| Trường          | Kiểu dữ liệu | Mô tả                          |
|-----------------|---------------|---------------------------------|
| `Date`          | `DateOnly`    | Ngày dự báo                     |
| `TemperatureC`  | `int`         | Nhiệt độ (°C)                  |
| `TemperatureF`  | `int`         | Nhiệt độ (°F) — tính tự động   |
| `Summary`       | `string?`     | Mô tả thời tiết                |

---

## 📋 Danh sách API Endpoints

### 1. Product API

Base URL: `/api/product`

#### `GET /api/product` — Lấy danh sách sản phẩm

Trả về toàn bộ danh sách sản phẩm.

- **Response**: `200 OK`

```json
[
  {
    "id": 1,
    "name": "Laptop",
    "price": 15000000
  },
  {
    "id": 2,
    "name": "Mouse",
    "price": 200000
  }
]
```

---

#### `GET /api/product/{id}` — Lấy sản phẩm theo ID

Trả về thông tin một sản phẩm dựa theo `id`.

- **Tham số**: `id` (int) — Mã sản phẩm
- **Response**:
  - `200 OK` — Thành công
  - `404 Not Found` — Không tìm thấy sản phẩm

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 15000000
}
```

---

#### `POST /api/product` — Thêm sản phẩm mới

Thêm một sản phẩm mới vào danh sách.

- **Request Body**:

```json
{
  "id": 3,
  "name": "Keyboard",
  "price": 500000
}
```

- **Response**: `201 Created` — Trả về sản phẩm vừa tạo kèm header `Location`

---

### 2. WeatherForecast API

Base URL: `/weatherforecast`

#### `GET /weatherforecast` — Lấy dự báo thời tiết

Trả về danh sách 5 ngày dự báo thời tiết (dữ liệu ngẫu nhiên).

- **Response**: `200 OK`

```json
[
  {
    "date": "2026-06-18",
    "temperatureC": 25,
    "temperatureF": 76,
    "summary": "Warm"
  }
]
```

---

### 3. Minimal API

#### `GET /student` — Lấy thông tin sinh viên

Endpoint đơn giản trả về thông tin một sinh viên (Minimal API).

- **Response**: `200 OK`

```json
{
  "id": 1,
  "name": "Hanh"
}
```

---

## 📁 Cấu trúc dự án

```
ProductApi/
├── Controllers/
│   ├── ProductController.cs       # CRUD sản phẩm
│   └── WeatherForecastController.cs  # Dự báo thời tiết
├── Models/
│   └── Product.cs                 # Model sản phẩm
├── Properties/
│   └── launchSettings.json        # Cấu hình chạy
├── Program.cs                     # Entry point + Minimal API
├── WeatherForecast.cs             # Model thời tiết
├── appsettings.json
└── ProductApi.csproj
```

---

## 🔧 Tổng hợp API

| Method | Endpoint               | Mô tả                        | Response    |
|--------|------------------------|-------------------------------|-------------|
| GET    | `/api/product`         | Lấy tất cả sản phẩm          | `200`       |
| GET    | `/api/product/{id}`    | Lấy sản phẩm theo ID         | `200`/`404` |
| POST   | `/api/product`         | Thêm sản phẩm mới            | `201`       |
| GET    | `/weatherforecast`     | Lấy dự báo thời tiết         | `200`       |
| GET    | `/student`             | Lấy thông tin sinh viên       | `200`       |
