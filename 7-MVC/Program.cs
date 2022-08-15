var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

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

app.Run();
