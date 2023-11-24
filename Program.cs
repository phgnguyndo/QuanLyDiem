using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Mapping;
using BE_QuanLiDiem.Models.DTO.User;
using BE_QuanLiDiem.Repository.Abstract;
using BE_QuanLiDiem.Repository.Implement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QL_DiemDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiDiemConnectionString")));

//builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",null);
var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddScoped<IKhoaRP, KhoaRP>();
builder.Services.AddScoped<IBoMonRP, BoMonRP>();
builder.Services.AddScoped<IGiangVienRP, GiangVienRP>();
builder.Services.AddScoped<IHocPhanRP, HocPhanRP>();
builder.Services.AddScoped<IDayHocRP, DayHocRP>();
builder.Services.AddScoped<ILopHocPhanRP, LopHocPhanRP>();
builder.Services.AddScoped<IPhieuDiemRP, PhieuDiemRP>();
builder.Services.AddScoped<IHocVienRP, HocVienRP>();
builder.Services.AddScoped<ILopCnRP, LopCnRP>();
builder.Services.AddScoped<IDaiDoiRP, DaiDoiRP>();
builder.Services.AddScoped<IRefreshHandler, RefreshHandler>();
builder.Services.AddScoped<ICreateUser, CreateUser>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsettings);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}
);

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/api/HocVien")
});

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/api/DaiDoi")
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/api/lopchuyennganh")
});
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
