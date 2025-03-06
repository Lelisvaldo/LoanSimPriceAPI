using LoanSimPriceAPI.Converters;
using LoanSimPriceAPI.Data;
using LoanSimPriceAPI.Services;
using LoanSimPriceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona Controllers e Configura Serialização
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new DecimalConverter()); });

// Configuração do JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

// Adiciona autenticação e autorização
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

// Adiciona Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do Banco de Dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra os Serviços
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanSimulationService, LoanSimulationService>();
builder.Services.AddScoped<IAuthService, AuthService>(); // ✅ REGISTRA O SERVIÇO CORRETAMENTE

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();