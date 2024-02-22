using Domain.Data;
using Domain.Interfaces;
using FunnyCocktail.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_allowall";
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDataBaseContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<ICocktailService, CocktailService>();
builder.Services.AddScoped<ICocktailReviewService, CocktailReviewService>();
builder.Services.AddScoped<ICocktailGradeService, CocktailGradeService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader());
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
