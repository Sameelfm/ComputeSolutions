using WebAppWithData.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://az204-appconf.azconfig.io;Id=HZh1-laa-s0:IxRFdEymE/cy/hFUNckR;Secret=EJ+1TzQiYMXrIGFLXyj8i2/wy2VrvvuRr4hWwzsTu3I=";
builder.Host.ConfigureAppConfiguration(apps =>
{
    apps.AddAzureAppConfiguration(connectionString);
});

// Add services to the container.
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
