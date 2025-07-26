using TiendaJuegos.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servicios del backend
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var origenesPermitidos = builder.Configuration
    .GetSection("OrigenesPermitidos")
    .Get<string[]>();
// HABILITAR CORS para Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy.WithOrigins(origenesPermitidos!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// REGISTRAR TU SERVICIO (esto evita el error 500)
builder.Services.AddScoped<IVideojuegoService, VideojuegosService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection(); //Redirección segura
}
app.UseRouting();
// Activar CORS
app.UseCors("AllowAngularDevClient"); 

app.UseAuthorization(); // Habilita la autorización despues de CORS
app.MapControllers(); //Mapea endpoints de los controladores

app.Run();