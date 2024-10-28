using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ElimperioAPI.Models;
using ElimperioAPI.Services;
using ElimperioAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de MongoDB
builder.Services.Configure<ImperioDBsettings>(
    builder.Configuration.GetSection("ConfiguraciónBaseDatos"));

// Agregar servicios singleton para la aplicación
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ProductoService>();
builder.Services.AddSingleton<ReportMensualService>();
builder.Services.AddSingleton<ReportSemanalService>();
builder.Services.AddSingleton<InventarioService>();
builder.Services.AddSingleton<BebidaMasVendidaService>();
builder.Services.AddSingleton<ProductoMasVendidoService>();
builder.Services.AddSingleton<VentaGeneralService>();
builder.Services.AddSingleton<VentaPorDiaService>();

// Configurar JSON para mantener el formato de las propiedades
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Configuración de CORS para permitir el acceso desde todas las fuentes (ajústalo según sea necesario)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
});

var app = builder.Build();

// Configurar el middleware de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins"); // Aplicar política de CORS

app.UseAuthentication(); // Habilitar autenticación JWT
app.UseAuthorization();  // Habilitar autorización

app.MapControllers();

app.Run();
