using MaximaTech.api.Configuration;
using MaximaTech.Application;
using MaximaTech.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSwaggerConfig()
    .Services
        .AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
