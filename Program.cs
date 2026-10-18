using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Petreus_Mihaela_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Petreus_Mihaela_Lab2Context' not found.");
builder.Services.AddDbContext<Petreus_Mihaela_Lab2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();