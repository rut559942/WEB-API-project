using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using AutoMapper;
using DTOs;
using NLog;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped<ISignInRepository, SignInRepository>();
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<IUpdateRepository, UpdateRepository>();
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<IUpdateService, UpdateService>();
builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<WebApiShopContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Logging.ClearProviders();
builder.Host.UseNLog();


var logger = LogManager.GetCurrentClassLogger();
logger.Info("Application started (.NET 9)");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
