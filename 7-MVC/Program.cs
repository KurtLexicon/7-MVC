var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
builder.Services.AddMvc();

var app = builder.Build();
app.UseSession();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "About",
    pattern: "About",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "Contact",
    pattern: "Contact",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "Projects",
    pattern: "Projects",
    defaults: new { controller = "Home", action = "Projects" });

app.MapControllerRoute(
    name: "FeverCheck",
    pattern: "FeverCheck/{temperature?}",
    defaults: new { controller = "Doctor", action = "FeverCheck" });

app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "GuessingGame/{guess?}",
    defaults: new { controller = "Game", action = "GuessingGame" });

app.Run();
