using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.BLL.Concretes;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Entities;
using NTierECommerce.IOC.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Resolvers


//DbContext
builder.Services.AddECommerceDb();


//IdentityInjection
builder.Services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<ECommerceContext>();

//AddRepositories
builder.Services.AddRepositoryService();


//Cookie
builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie = new CookieBuilder
    {
        Name = "Login"
    };

    x.LoginPath = new PathString("/Login");
    x.SlidingExpiration = true;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    //Admin Route
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    });
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
        );
    });
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
        );
    });
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}"
        );
    });


    //Custom Route
    //Buraya custom route tanýmlanacak. Örneðin ürün detaylarý gösterilirken url'de olabildðince seo'a uygun bir route oluþturulacak.


    //Default Route

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    });

});


//Custom Route

app.Run();
