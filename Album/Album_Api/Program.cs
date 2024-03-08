using Album.DataAccess;
using CityEye_Api.InjectProviders;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region DB Connection

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionString")));
new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


#endregion
#region Service Bindings
// you can inject in class file "ServiceBinding" inside Folder "InjectProviders"
builder.Services.InjectServices();
#endregion


#region Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
#endregion
#region Session and Cookie

builder.Services.AddHttpContextAccessor();


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    //options.HttpOnly = HttpOnlyPolicy.None;
    options.Secure = CookieSecurePolicy.SameAsRequest;
});

#endregion


builder.Services.AddCors(p => p.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Attachments")),
    RequestPath = "/Attachments"


});
app.MapControllers();
app.Run();