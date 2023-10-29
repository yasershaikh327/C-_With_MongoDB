using DataBase_Access.DataBase_Management;
using DataBase_Access.Helper;
using DataBase_Access.IRepository;
using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.DToMapper.Mapper;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Mapper;
using DataBase_Access.Repository;
using FoodManagement_UI.Clients;
using FoodManagement_UI.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Mappers.UIMapper.Mapper;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IWebinarMapper, WebinarMapper>();
builder.Services.AddScoped<IWebinarDtoMapper, WebinarDtoMapper>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();    
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IRegistrationMapper, RegistrationMapper>();  
builder.Services.AddScoped<IRegistrationDtoMapper, RegistrationDtoMapper>();
builder.Services.AddScoped<ICourseBookMapper, CourseBookMapper>();
builder.Services.AddScoped<ICourseBookDtoMapper, CourseBookDtoMapper>();
builder.Services.AddScoped<IContactDtoMapper,ContactDtoMapper>();
builder.Services.AddScoped<IContactMapper, ContactMapper>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICourseDtoMapper,CourseDtoMapper>();
builder.Services.AddScoped<ICourseMapper,CourseMapper>();
builder.Services.AddScoped<IHelper,Helper>();
builder.Services.AddScoped<IEmailClient, EmailClient>();
var multipartBodyLengthLimit = builder.Configuration.GetValue<long>("FormOptions:MultipartBodyLengthLimit");
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 524288000; // 500 MB in bytes
});
builder.Services.AddScoped<IEmailService, EmailService>();  
builder.Services.AddDbContext<OnlineClassesDB>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Configuration.AddJsonFile("appSettings.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
