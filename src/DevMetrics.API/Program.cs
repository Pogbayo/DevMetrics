using DevMetrics.API.Middleware;
using DevMetrics.Infrastructure.Extensions;
using DevMetrics.Infrastructure.Shard;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await ShardMigrationHelper.ApplyMigrationsAsync(builder.Configuration);
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CurrentUserMiddleware>();

app.UseHttpsRedirection();
app.Run();
