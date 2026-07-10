using TH.BLL.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddIdentityService();
builder.Services.AddRepositoryService();
builder.Services.AddManagerService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddService();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie = new CookieBuilder
    {
        Name = "TH_Cookie",//Cookie ismi

    };
    x.LoginPath = "/Account/Login"; //Bu yoldan baþarýlý geçiþ yapan kullanýcýya ait bilgileri verdiðimiz cookie nin altýnda sakla 
    x.LogoutPath = "/Account/Logout"; //Bu yoldan baþarýlý geçiþ yapan kullanýcýya ait bilgileri verdiðimiz cookie nin altýnda sakla 
    x.AccessDeniedPath = new PathString("/Home/AccessDenied");//Rolü uygun deðilse gönderilecek alan
    x.SlidingExpiration = true;//Cookie nin ömrü dolmak üzereyken yenilenmesini saðlar
    x.ExpireTimeSpan = TimeSpan.FromMinutes(1);//Cookie nin ömrü 1 dk. Bu cookie browserdan silinecek tekrar giriþ yapýlmasý gerekecek
    //x.ReturnUrlParameter = "returnUrl";
});

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(30);//30 dk iþlem yapýlmazsa session silinecek
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
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

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
