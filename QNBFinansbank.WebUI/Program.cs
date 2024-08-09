using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Business.Concrete;
using QNBFinansbank.WebUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages().WithRazorPagesRoot("/Components/Pages/Callback");

builder.Services.AddSingleton<IVirtualPosService, VirtualPosManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Eğer varsa önce authentication middleware'ini ekleyin
app.UseAuthorization();  // Authorization middleware'i

app.UseAntiforgery(); // Antiforgery middleware'ini ekleyin

app.MapRazorPages(); // Razor Pages için rotayı ekleyin
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
