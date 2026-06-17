using ProductApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ========================================
// Minimal APIs - So sánh với Controller truyền thống
// ========================================

var minimalProducts = new List<Product>
{
    new Product { Id = 1, Name = "Keyboard", Price = 500000 },
    new Product { Id = 2, Name = "Monitor", Price = 5000000 }
};

// GET: Lấy tất cả sản phẩm
app.MapGet("/api/minimal/products", () =>
{
    return Results.Ok(minimalProducts);
})
.WithName("GetMinimalProducts")
.WithTags("Minimal APIs");

// GET: Lấy sản phẩm theo ID
app.MapGet("/api/minimal/products/{id}", (int id) =>
{
    var product = minimalProducts.FirstOrDefault(p => p.Id == id);
    return product is not null
        ? Results.Ok(product)
        : Results.NotFound(new { Message = $"Product with Id = {id} not found" });
})
.WithName("GetMinimalProductById")
.WithTags("Minimal APIs");

// POST: Thêm sản phẩm mới
app.MapPost("/api/minimal/products", (Product product) =>
{
    minimalProducts.Add(product);
    return Results.Created($"/api/minimal/products/{product.Id}", product);
})
.WithName("CreateMinimalProduct")
.WithTags("Minimal APIs");

// PUT: Cập nhật sản phẩm
app.MapPut("/api/minimal/products/{id}", (int id, Product product) =>
{
    var existingProduct = minimalProducts.FirstOrDefault(p => p.Id == id);

    if (existingProduct is null)
    {
        return Results.NotFound(new { Message = $"Product with Id = {id} not found" });
    }

    existingProduct.Name = product.Name;
    existingProduct.Price = product.Price;

    return Results.NoContent();
})
.WithName("UpdateMinimalProduct")
.WithTags("Minimal APIs");

// DELETE: Xóa sản phẩm
app.MapDelete("/api/minimal/products/{id}", (int id) =>
{
    var product = minimalProducts.FirstOrDefault(p => p.Id == id);

    if (product is null)
    {
        return Results.NotFound(new { Message = $"Product with Id = {id} not found" });
    }

    minimalProducts.Remove(product);

    return Results.NoContent();
})
.WithName("DeleteMinimalProduct")
.WithTags("Minimal APIs");

app.Run();
