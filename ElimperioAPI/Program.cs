using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ElimperioAPI.Models;
using ElimperioAPI.Services;
using ElimperioAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configuraci�n de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de MongoDB
builder.Services.Configure<ImperioDBsettings>(
    builder.Configuration.GetSection("Configuraci�nBaseDatos"));

// Agregar servicios singleton para la aplicaci�n
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

// Configuraci�n de CORS para permitir el acceso desde todas las fuentes (aj�stalo seg�n sea necesario)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configuraci�n de JWT
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

// Configurar el middleware de la aplicaci�n
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins"); // Aplicar pol�tica de CORS

app.UseAuthentication(); // Habilitar autenticaci�n JWT
app.UseAuthorization();  // Habilitar autorizaci�n

app.MapControllers();

app.Run();
