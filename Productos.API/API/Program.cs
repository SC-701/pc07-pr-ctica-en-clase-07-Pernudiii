using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// HttpClient para consumir APIs externas
builder.Services.AddHttpClient("ServicioRegistro", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Servicios:Registro"]);
});

builder.Services.AddHttpClient("ServicioRevision", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Servicios:Revision"]);
});


// Inyección de dependencias - Reglas
builder.Services.AddScoped<IConfiguracion, Configuracion>();
builder.Services.AddScoped<IProductoRegistroReglas, ProductoRegistroReglas>();
builder.Services.AddScoped<IProductoRevisionReglas, ProductoRevisionReglas>();

// Inyección de dependencias - Servicios
builder.Services.AddScoped<IRegistroProductoServicio, RegistroProductoServicio>();
builder.Services.AddScoped<IRevisionProductoServicio, RevisionProductoServicio>();


var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();