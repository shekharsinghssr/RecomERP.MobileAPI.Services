using Microsoft.OpenApi.Models;
using RecomERP.MobileAPI.Infrastructure.ServicesReg;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//----------------------------
// Add services
//----------------------------
builder.Services.AddDatabaseContexts(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddAuthorization();


//----------------------------
// Add CORS services
//----------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:3000", "https://localhost:7295", "http://localhost:3001")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

//----------------------------
// Swagger
//----------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recom-ERP-Mobile-API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } }
    });
});



//========================== MAIN ==========================
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});
// Enable the CORS middleware
//app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();