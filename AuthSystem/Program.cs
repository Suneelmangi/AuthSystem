using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using AuthSystem.Infrastructure;
using AuthSystem.Infrastructure.Repositories;
using AuthSystem.Models;
using AuthSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

    builder.Services.AddDbContext<EmployeeContext>(options => options.UseNpgsql(connectionString));
    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();

    builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseNpgsql(connectionString));
   


    builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<AuthDbContext>();
    //builder.Services.AddMvc(config => {
    //    var policy = new AuthorizationPolicyBuilder()
    //                    .RequireAuthenticatedUser()
    //                    .Build();
    //    config.Filters.Add(new AuthorizeFilter(policy));
    //});

// Add services to the container.
builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    builder.Services.Configure<IdentityOptions>(Options =>
    {
        Options.Password.RequiredLength = 6;
        Options.Password.RequiredUniqueChars = 1;
    });
    builder.Services.AddMemoryCache();

    var app = builder.Build();
    var loggerFactory = app.Services.GetService<ILoggerFactory>();
    loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        // app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication(); 
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Error}/{action=httpErrorHandler}/{id?}");
        endpoints.MapRazorPages();
    });
    app.Run();
