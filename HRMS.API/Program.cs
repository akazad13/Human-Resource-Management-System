using HRMS.API;
using HRMS.Application;
using HRMS.Infrastructure;
using HRMS.Infrastructure.SeedDatabase;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddAppInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();


app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.MapControllers();

var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
using(var scope = scopedFactory.CreateScope())
{
    await app.Services.SeedDefaultUserAsync(scope);
}

app.Run();

