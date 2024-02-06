using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuikForm.Business.Business;
using QuikForm.Business.Contracts.Business;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Contracts;
using System.Reflection;
using System.Text.Json.Serialization;
using BusinessMappers = QuikForm.Business.Contracts.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuikForm.API", Version = "v1" });
});

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuikForm.API V1"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();