using Microsoft.Extensions.DependencyInjection;
using ProjectAPI.BusinessLogic;
using ProjectAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSingleton<IFetchJson, FetchJson>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    //Configuring the MVC middleware to the request processing pipeline
    endpoints.MapDefaultControllerRoute();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
