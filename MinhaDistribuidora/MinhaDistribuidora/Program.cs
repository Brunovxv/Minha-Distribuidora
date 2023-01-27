using Microsoft.EntityFrameworkCore;
using MinhaDistribuidora.Business;
using MinhaDistribuidora.Business.Implementations;
using MinhaDistribuidora.Repository;
using MinhaDistribuidora.Data;
using MinhaDistribuidora.Repository.Generic;
using MinhaDistribuidora.Hypermedia.Filters;
using MinhaDistribuidora.Hypermedia.Enricher;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options =>
                 options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));


var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new ClienteEnricher());

builder.Services.AddSingleton(filterOptions);
//injeção de dependências 
builder.Services.AddScoped<IClienteBusiness, ClienteBusinessImplementation>();
builder.Services.AddScoped<IProdutoBusiness, ProdutoBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


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
app.MapControllerRoute(
   name: "DefaultApi",
   pattern: "{controller=values}/{id?}");

app.Run();
