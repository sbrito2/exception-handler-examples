using API.Configurations;
using Presentation.API.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
builder.Services.AddHttpClient();
builder.Services.AddExceptionHandler<ExceptionHandlerConfiguration>();
builder.Services.AddProblemDetails();
DependencyContainerConfiguration.RegisterServices(builder.Services);
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(NotificationFilter));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    SwaggerConfiguration.UseSwaggerRoutes(app);
}
app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler();
app.Run();