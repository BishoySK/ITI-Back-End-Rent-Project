using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Realstate_BL;
using Realstate_DAL;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.KD


#region Cors
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.WithHeaders();
        builder.AllowAnyHeader();
    });
});
#endregion

#region Identity

builder.Services.AddIdentity<UserClass, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 6;

        options.User.RequireUniqueEmail = true;

        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    })
    .AddEntityFrameworkStores<RealstateContext>();

#endregion

#region Authontication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Jwt";
    options.DefaultChallengeScheme = "Jwt";
}).AddJwtBearer("Jwt", option =>
{
    var GetKey = builder.Configuration.GetValue<string>("SecretKey");
    var KeyOutBytes = Encoding.ASCII.GetBytes(GetKey);
    var SecretKey = new SymmetricSecurityKey(KeyOutBytes);

    option.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = SecretKey,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", opt => opt.RequireClaim(ClaimTypes.Role, "Admin"));
});
#endregion

#region services
#region Defaults

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#endregion

#region Database
var ConnectionString = builder.Configuration.GetConnectionString("Realstate");
builder.Services.AddDbContext<RealstateContext>(options => options.UseSqlServer(ConnectionString));

#endregion

#region Repos
builder.Services.AddScoped<IAdvertisementsRepo, AdvertisementsRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<IChatRepo, ChatRepo>();
builder.Services.AddScoped<IRatingRepo, RatingRepo>();  
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
#endregion

#region Managers
builder.Services.AddScoped<IAdvManager, AdvManager>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IChatManager, ChatManager>();
builder.Services.AddScoped<IRatingManger, RatingManger>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
