using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseInMemoryDatabase("HotelDB"));
builder.Services.AddScoped<BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hotel}/{action=Index}/{id?}");

app.Run();
