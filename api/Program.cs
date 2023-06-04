using Api.Extentions;
using Api.ActionFilters;
using Microsoft.AspNetCore.Hosting;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidateCommentExistsAttribute>();
builder.Services.AddScoped<ValidateUserForCommentExistsAttribute>();
builder.Services.AddControllers();
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

app.Run();
