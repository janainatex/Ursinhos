using Pokedex.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAcessor();
builder.Services.AddSingleton<IPokeServece, PokeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days . You may want to change this for production .....
}

app.UseHttpsRedirection();
app.UseStaticFile();

app.UseRouting();

app.UserAutorization();

app.UseSesion();

app.MapControllerRoute(
    name : "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();