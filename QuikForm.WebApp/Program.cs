using Microsoft.EntityFrameworkCore;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.WebApp.Services;
using BusinessMappers = QuikForm.Business.Contracts.Mappers;
using WebAppMappers = QuikForm.WebApp.Mappers;

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
builder.Services.AddTransient<IFieldRecordRepository, FieldRecordRepository>();
builder.Services.AddTransient<IFormRepository, FormRepository>();
builder.Services.AddTransient<IInputTypeRepository, InputTypeRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IRecordRepository, RecordRepository>();

// Add Business
builder.Services.AddTransient<IFieldBusiness, FieldBusiness>();
builder.Services.AddTransient<IFormBusiness, FormBusiness>();
builder.Services.AddTransient<IInputTypeBusiness, InputTypeBusiness>();
builder.Services.AddTransient<IQuestionBusiness, QuestionBusiness>();
builder.Services.AddTransient<IRecordBusiness, RecordBusiness>();

// Add Mappers
builder.Services.AddScoped<BusinessMappers.Forms.IFormMapper, BusinessMappers.Forms.FormMapper>();
builder.Services.AddScoped<BusinessMappers.Questions.IQuestionMapper, BusinessMappers.Questions.QuestionMapper>();
builder.Services.AddScoped<BusinessMappers.Fields.IFieldMapper, BusinessMappers.Fields.FieldMapper>();
builder.Services.AddScoped<BusinessMappers.InputTypes.IInputTypeMapper, BusinessMappers.InputTypes.InputTypeMapper>();

builder.Services.AddScoped<WebAppMappers.Forms.IFormMapper, WebAppMappers.Forms.FormMapper>();
builder.Services.AddScoped<WebAppMappers.Questions.IQuestionMapper, WebAppMappers.Questions.QuestionMapper>();
builder.Services.AddScoped<WebAppMappers.Fields.IFieldMapper, WebAppMappers.Fields.FieldMapper>();
builder.Services.AddScoped<WebAppMappers.InputTypes.IInputTypeMapper, WebAppMappers.InputTypes.InputTypeMapper>();

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
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseErrorHandlingMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
