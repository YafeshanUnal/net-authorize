var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a custom middleware to check the hash key
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HashKeyPolicy", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var headers = context.Resource as Microsoft.AspNetCore.Http.DefaultHttpContext;
            var hashKey = headers?.Request.Headers["X-Hash-Key"].FirstOrDefault();

            // otelz is the hash key convert to md5 hash string using https://www.md5hashgenerator.com/
            return hashKey == "088d310940808a7a6910fa94bca59e75";
        });
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseRouting();
app.Use(async (context, next) =>
{
    var hashKey = context.Request.Headers["X-Hash-Key"].FirstOrDefault();

    // Check if the hash key is missing or incorrect
    if (hashKey != "088d310940808a7a6910fa94bca59e75")
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Forbidden - Invalid Hash Key");
        return;
    }

    await next();
});
app.MapControllers();


app.Run();
