using FluentValidation.AspNetCore;
using GokalpLogistics.UI.Extensions;
using GokalpLogistics.UI.Service.Absract;
using GokalpLogistics.UI.Service.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers()
            .AddFluentValidation(x => x
            .RegisterValidatorsFromAssembly(typeof(Program).Assembly));



builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

//Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddHttpContextAccessor();

//Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Depency Ýnjection
#region RestService
builder.Services.AddScoped<IRestService, RestService>();
#endregion

var app = builder.Build();
AppHttpContext.ServiceProvider = app.Services;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
