using MinimalApi.Contracts;
using MinimalApi.EndpointDefinitions;
using MinimalApi.Model;
using MinimalApi.Repository;
using MinimalApi.SecretSauce;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));

var app = builder.Build();

app.UseEndpointDefinitions();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.Run();

