using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using SampleAppForWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Azure Key Vault
string vaultUri = builder.Configuration["AzureKeyVault:VaultUri"];
if (!string.IsNullOrEmpty(vaultUri))
{
    var client = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential());
    builder.Services.AddSingleton(client);
}
builder.Services.AddSingleton<KeyVaultService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
