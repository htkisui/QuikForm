using Microsoft.EntityFrameworkCore;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.WebApp.Mappers.Fields;
using QuikForm.WebApp.Mappers.Forms;
using QuikForm.WebApp.Mappers.InputTypes;
using QuikForm.WebApp.Mappers.Questions;
using QuikForm.WebApp.Services;
using QuikForm.WebApp.Views.Shared.Components.QuestionForm;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Add Repositories
builder.Services.AddTransient<IFieldRepository, FieldRepository>();
builder.Services.AddTransient<IFormRepository, FormRepository>();
builder.Services.AddTransient<IInputTypeRepository, InputTypeRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IRecordRepository, RecordRepository>();

// Add Business
builder.Services.AddTransient<IFieldBusiness, FieldBusiness>();
builder.Services.AddTransient<IFormBusiness, FormBusiness>();
builder.Services.AddTransient<IInputTypeBusiness, InputTypeBusiness>();
builder.Services.AddTransient<IQuestionBusiness, QuestionBusiness>();

// Add Mappers
builder.Services.AddScoped<IFormMapper, FormMapper>();
builder.Services.AddScoped<IQuestionMapper, QuestionMapper>();
builder.Services.AddScoped<IFieldMapper, FieldMapper>();
builder.Services.AddScoped<IInputTypeMapper, InputTypeMapper>();


// Add Services
builder.Services.AddScoped<InputTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
