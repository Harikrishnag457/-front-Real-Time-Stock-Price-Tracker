var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllers();
 
// Register repository and services for dependency injection
builder.Services.AddSingleton<MyStockSymbolApi.Data.IStockSymbolRepository, MyStockSymbolApi.Data.StockSymbolRepository>();
builder.Services.AddSingleton<MyStockSymbolApi.Services.IStockSymbolService, MyStockSymbolApi.Services.StockSymbolService>();
builder.Services.AddSingleton<MyStockSymbolApi.Services.ITickerService, MyStockSymbolApi.Services.TickerService>();
 
// Add HttpClient support (for external API like RapidAPI)
builder.Services.AddHttpClient();
 
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
 
var app = builder.Build();
 
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
 
app.Run();