using LibraryManagementSystem.Extentions;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddRepositoryServices();
    builder.Services.AddDomainServices();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
}


var app = builder.Build();
{
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
        pattern: "{controller=Transactions}/{action=Index}/{id?}");

    app.Run();
}
