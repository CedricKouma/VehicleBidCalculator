using System.Text.Json.Serialization;
using VehicleBidCalculator.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddLoggingConfiguration();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();