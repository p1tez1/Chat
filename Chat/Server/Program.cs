using BLL.Features.Heshing;
using BLL.Features.MapingProfiel;
using BLL.Services;
using DAL.ChatDBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters
});

builder.Services.AddScoped<IHeshing, Heshing>();
builder.Services.AddScoped<IAcountServices, AcountServices>();

//Add automapper
builder.Services.AddAutoMapper(typeof(UserDtoMappingProfile));

//EF core builder
builder.Services.AddDbContext<ChatContext>(options => options.UseSqlServer("Server=MAREK;Database=User;Trusted_Connection=True;TrustServerCertificate=true"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
