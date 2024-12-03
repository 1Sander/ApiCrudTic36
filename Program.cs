using ApiCrud.Data;
using ApiCrud.Clientes;
using ApiCrud.Pedidos;
using ApiCrud.Produtos;
using Microsoft.AspNetCore.Cors.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddCors(option =>
 option.AddDefaultPolicy(policy => 
 {
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
 } ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//configurando rotas
//app.UseHttpsRedirection();

app.UseCors();

app.AddRotasClientes();
app.AddRotasPedidos();
app.AddRotasProdutos();


app.Run();
