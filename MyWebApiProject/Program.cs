using Microsoft.EntityFrameworkCore;
using Repository;
using Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISignInRepository, SignInRepository>();
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<IUpdateRepository, UpdateRepository>();
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<IUpdateService, UpdateService>();
builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddDbContext<WebApiShopContext>(options =>
    options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=WEB-API_SHOP;Integrated Security=True;Trust Server Certificate=True"));


builder.Services.AddControllers();
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

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
