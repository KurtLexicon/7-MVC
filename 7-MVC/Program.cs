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

app.MapControllerRoute (
    "Default",                                              // Route name
    "Doctor/{action}/{id}",                                 // URL with parameters
    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
);

app.MapControllerRoute(
    name: "FeverCheck",
    pattern: "FeverCheck/{temperature?}",
    defaults: new { controller = "Doctor", action = "FeverCheck"});

app.Run();
