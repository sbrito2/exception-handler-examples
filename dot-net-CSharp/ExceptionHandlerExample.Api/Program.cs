using API.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
SwaggerExtensions.AddSwaggerConfiguration(builder.Services);
builder.Services.AddHttpClient();
builder.Services.AddExceptionHandler<ExceptionHandlerConfiguration>();
builder.Services.AddProblemDetails();
DependencyContainerConfiguration.RegisterServices(builder.Services);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    SwaggerExtensions.UseSwaggerRoutes(app);
}
app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler();
app.Run();