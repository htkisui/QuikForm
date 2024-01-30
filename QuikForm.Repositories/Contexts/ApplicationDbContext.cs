using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuikForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Contexts;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public DbSet<Form> Forms { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<InputType> InputTypes { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<FieldRecord> FieldRecords { get; set; }

    private const int FIELD_NUMBER = 50;
    private const int QUESTION_NUMBER = 20;
    private const int FORM_NUMBER = 5;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var fields = CreateFields();
        var inputTypes = CreateInputTypes();
        var questions = CreateQuestions(inputTypes);
        var forms = CreateForms();


        modelBuilder.Entity<Form>().HasData(forms);
        modelBuilder.Entity<Question>().HasData(questions);
        modelBuilder.Entity<InputType>().HasData(inputTypes);
        modelBuilder.Entity<Field>().HasData(fields);
        base.OnModelCreating(modelBuilder);
    }

    private List<Field> CreateFields()
    {
        int id = 1;
        var fieldFaker = new Faker<Field>()
            .RuleFor(fi => fi.Id, fa => id++)
            .RuleFor(fi => fi.Label, fa => fa.Lorem.Sentence(1))
            .RuleFor(fi => fi.QuestionId, fa => fa.Random.Int(1, QUESTION_NUMBER));

        return fieldFaker.Generate(FIELD_NUMBER);
    }

    private List<InputType> CreateInputTypes()
    {
        return new List<InputType>() {
            new InputType { Id = 1, Name ="text" },
            new InputType { Id = 2, Name ="textarea" },
            new InputType { Id = 3, Name ="checkbox" },
            new InputType { Id = 4, Name ="radio" },
       };
    }

    private List<Question> CreateQuestions(List<InputType> inputTypes)
    {
        int id = 1;
        var questionFaker = new Faker<Question>()
            .RuleFor(q => q.Id, f => id++)
            .RuleFor(q => q.Label, f => f.Lorem.Sentence(5))
            .RuleFor(q => q.IsMandatory, f => f.Random.Int(0, 1) == 1)
            .RuleFor(q => q.FormId, f => f.Random.Int(1, FORM_NUMBER))
            .RuleFor(q => q.InputTypeId, f => f.Random.Int(1, inputTypes.Count));

        return questionFaker.Generate(QUESTION_NUMBER);
    }

    private List<Form> CreateForms()
    {
        int id = 1;
        var formFaker = new Faker<Form>()
            .RuleFor(fo => fo.Id, fa => id++)
            .RuleFor(fo => fo.Title, fa => fa.Lorem.Sentence(5))
            .RuleFor(fo => fo.Description, fa => fa.Lorem.Paragraph())
            .RuleFor(fo => fo.CreatedAt, fa => fa.Date.Between(DateTime.Parse("2024/01/01"), DateTime.Parse("2024/01/05")))
            .RuleFor(fo => fo.UpdatedAt, fa => fa.Date.Between(DateTime.Parse("2024/01/10"), DateTime.Now));
            //.RuleFor(fo => fo.ApplicationUserId, fa => 1);

        return formFaker.Generate(FORM_NUMBER);
    }
}
