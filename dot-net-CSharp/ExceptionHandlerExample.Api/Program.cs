using API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
SwaggerExtensions.AddSwaggerConfiguration(builder.Services);
builder.Services.AddHttpClient();
builder.Services.AddExceptionHandler<ExceptionHandlerConfiguration>();
builder.Services.AddProblemDetails();
DependencyContainerConfiguration.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    SwaggerExtensions.UseSwaggerRoutes(app);
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler();
app.Run();