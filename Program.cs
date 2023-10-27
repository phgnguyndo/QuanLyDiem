using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Mapping;
using BE_QuanLiDiem.Repository.Abstract;
using BE_QuanLiDiem.Repository.Implement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QL_DiemDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiDiemConnectionString")));

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

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
    RequestPath = new PathString("/api/HocViens")
});
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
