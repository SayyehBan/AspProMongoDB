using AspProMongoDB.Web.Models;
using AspProMongoDB.Web.Services.Interface;
using AspProMongoDB.Web.Services.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient, MongoClient>(service =>
{
    var mongoSetting = service.GetRequiredService<MongoSettings>();
    return new MongoClient(mongoSetting.ConnectionString);
});
builder.Services.AddSingleton<MongoSettings>(sp =>
sp.GetRequiredService<IOptions<MongoSettings>>().Value);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
