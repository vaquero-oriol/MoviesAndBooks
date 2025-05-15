using App;
using Repos;
using System.Net.Http.Headers;
using System.Text.Json;
using WebApi.Framework;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<MovieRepo>((provider, client) =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var tmdbConfig = config.GetSection("TMDB");

    client.BaseAddress = new Uri(tmdbConfig["BaseUrl"]!);
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", tmdbConfig["AccessTokenV4"]!);

    // Debug: Verifica en consola
    Console.WriteLine($" HttpClient configurado:");
    Console.WriteLine($"BaseAddress: {client.BaseAddress}");
    Console.WriteLine($"Token Header: {client.DefaultRequestHeaders.Authorization}");
});
builder.Services.AddScoped<TmbdService>();

builder.Services.Configure<JsonSerializerOptions>(options => {
    options.PropertyNameCaseInsensitive = true;
    options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .WithOrigins(
                "https://localhost:51101",  
                "http://localhost:51101"   
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("CorsPolicy"); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
