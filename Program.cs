using CustomBlogsAPI.DAL;
using CustomBlogsAPI.DAL.Repository;
using CustomBlogsAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<appDBContext>(options=>options.UseSqlServer(builder.Configuration["ConnectionStrings"]));

builder.Services.AddScoped<IRepository<myBlogsEntity>, Repository<myBlogsEntity>>();

builder.Services.AddScoped<IRepository<myCategoryEntity>, Repository<myCategoryEntity>>();

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

// use allow-CORS
app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.Run();
