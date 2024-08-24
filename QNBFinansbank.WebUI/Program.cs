using QNBFinansbank.CashManagement.Business.Abstract;
using QNBFinansbank.CashManagement.Business.Concrete;
using QNBFinansbank.MoneyTransfer.Business.Abstract;
using QNBFinansbank.MoneyTransfer.Business.Concrete;
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
builder.Services.AddSingleton<ICashManagementService, CashManagementManager>();
builder.Services.AddSingleton<IMoneyTransferService, MoneyTransferManager>();

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

app.UseAntiforgery();

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
