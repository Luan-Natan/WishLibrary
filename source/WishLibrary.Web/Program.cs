using WishLibrary.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Injeção de Dependência
DependencyInjection.AddServices(builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

//Configure routes
RouteConfiguration.AddRoute(app);

app.Run();
