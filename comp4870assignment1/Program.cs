using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Data;
using ClassLibrary.Models;
using assignment1.Components;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("DataSource=app.db;Cache=Shared"));

builder.Services.AddIdentity<Member, IdentityRole>(
options => {
    options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services
.AddRazorComponents()
.AddInteractiveServerComponents()
.AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


builder.Services.AddRazorPages()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<ManifestService>();

builder.Services.AddQuickGridEntityFrameworkAdapter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "manifests_edit",
    pattern: "Manifests/Edit/{manifestId:int}/{memberId:guid}",
    defaults: new { controller = "Manifests", action = "Edit" });
app.MapControllerRoute(
    name: "manifests_delete",
    pattern: "Manifests/Delete/{manifestId:int}/{memberId:guid}",
    defaults: new { controller = "Manifests", action = "Delete" });

app.MapControllerRoute(
    name: "trips_edit",
    pattern: "Trips/Edit/{tripId:int}/{vehicleId:int}",
    defaults: new { controller = "Trips", action = "Edit" });
app.MapControllerRoute(
    name: "trips_delete",
    pattern: "Trips/Delete/{tripId:int}/{vehicleId:int}",
    defaults: new { controller = "Trips", action = "Delete" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.UseAntiforgery();
app.MapRazorComponents<App>()
.AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();    
    context.Database.Migrate();

    var userMgr = services.GetRequiredService<UserManager<Member>>();  
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();  

    IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}

app.Run();
