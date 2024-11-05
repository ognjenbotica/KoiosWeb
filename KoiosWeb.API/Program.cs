using KoiosWeb.API.Configurations;
using KoiosWeb.API.Data;
using KoiosWeb.API.Interfaces;
using KoiosWeb.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

var container = new Container();

var connStringMain = builder.Configuration.GetConnectionString("KoiosDBConnection");
builder.Services.AddDbContext<KoiosDBContext>(options => options.UseSqlServer(connStringMain));

builder.Services.AddScoped<IComputerHardwareRepository, ComputerHardwareRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferItemRepository, OfferItemRepository>();

builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
