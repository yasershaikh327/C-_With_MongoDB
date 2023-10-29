using API.Mapper.DtoMapper.IMapper;
using API.Mapper.DtoMapper.Mapper;
using API.Mapper.UIMapper.IMapper;
using API.Mapper.UIMapper.Mapper;
using Database_Access.DatabaseManagement;
using Database_Access.IRepository;
using Database_Access.Mapper.UIMapper.IMapper;
using Database_Access.Mapper.UIMapper.Mapper;
using Database_Access.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerDtoMapper, CustomerDtoMapper>();
builder.Services.AddScoped<ICustomerMapper, CustomerMapper>();
builder.Services.AddScoped<IOrderDtoMapper, OrderDtoMapper>();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddDbContext<CustomerOrdersDB>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
