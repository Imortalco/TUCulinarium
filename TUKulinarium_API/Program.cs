using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TUKulinarium_API.Data;
using TUKulinarium_API.Data.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddControllers();
services.AddIdentityApiEndpoints<User>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
    opt.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<DataContext>();

services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; });

services.AddAuthorization();

services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TUKUlinarium API Documentation",
        Description = "Welcome to the world of delicious food.",
        Contact = new OpenApiContact
        {
            Name = "Reffera12"
        }
    });
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(c =>
{
    c.LoginPath = new PathString("/login");
    c.ExpireTimeSpan = TimeSpan.FromDays(40);
    c.Events = new CookieAuthenticationEvents
    {
        OnValidatePrincipal = async context =>
        {
            var validateInterval = TimeSpan.FromMinutes(30);

            // Check if the last validation timestamp is within the interval
            if (context.Properties.IssuedUtc != null && context.Properties.IssuedUtc.Value.Add(validateInterval) < DateTimeOffset.UtcNow)
            {
                var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                var user = await userManager.GetUserAsync(context.Principal);

                if (user != null)
                {
                    throw new Exception("User validation failed.");
                }
            }
        }
    };

})
.AddGoogle((options =>
        {
            IConfigurationSection googleAuthNSection =
                configuration.GetSection("Authentication:Google");

            options.ClientId = googleAuthNSection["ClientId"];
            options.ClientSecret = googleAuthNSection["ClientSecret"];
        }));

services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; });

services.AddFluentEmail(builder.Configuration);

services.AddTransient<IEmailService, EmailService>();
services.AddTransient<IEmailSender<User>, EmailSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("api/auth")
.MapIdentityApi<User>();

app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync().ConfigureAwait(false);
}).RequireAuthorization();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
