using InventoryManagementApi.Data;
using InventoryManagementApi.Services;
using InventoryManagementApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Initialize SQLite
Batteries.Init();

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICategoryService, CategoryService>(); // Register ICategoryService
builder.Services.AddScoped<IProductService, ProductService>(); // Register IProductService



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

app.Run();
