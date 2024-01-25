using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Exceptions.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories.Tests;

[TestClass()]
public class QuestionRepositoryTests
{
    #region CreateAsync
    [TestMethod()]
    public async Task CreateAsync_QuestionToAdd_QuestionWithId()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);
        int idExpected = 1;
        Question questionToAdd = new Question() { Label = "Label" };

        // Act
        await questionRepository.CreateAsync(questionToAdd);

        // Assert
        Assert.AreEqual(idExpected, context.Questions.Find(1)?.Id);
    }
    #endregion

    #region DeleteAsync
    [TestMethod()]
    public async Task DeleteAsync_QuestionToDelete_EmptyList()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);
        Question qToDelete = new Question() { Id = 1, Label = "Label" };
        await context.Questions.AddAsync(qToDelete);
        context.SaveChangesAsync();
        int countExpected = 0;

        // Act
        await questionRepository.DeleteAsync(1);

        // Assert
        Assert.AreEqual(countExpected, context.Questions.Count());
    }

    [TestMethod()]
    [ExpectedException(typeof(QuestionNotFoundException))]
    public async Task DeleteAsync_QuestionToDelete_ThrowQuestionNotFoundException()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);

        // Act
        await questionRepository.DeleteAsync(1);
    }
    #endregion

    #region GetAllAsync
    [TestMethod()]
    public async Task GetAllAsync_Empty_QuestionList()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);

        List<Question> questions = new List<Question>()
        {
            new Question { Id = 1, Label = "Label" },
            new Question { Id = 2, Label = "Label" }
        };
        await context.Questions.AddRangeAsync(questions);
        await context.SaveChangesAsync();


        //Act
        List<Question> questionsResult = await questionRepository.GetAllAsync();

        //Assert
        Assert.AreEqual(context.Questions.Count(), questionsResult.Count());
    }
    #endregion

    #region GetByIdAsync
    [TestMethod()]
    public async Task GetByIdAsync_QuestionToSearch_QuestionFound()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);
        await context.AddAsync(new Question { Id = 1, Label = "Label" });
        await context.SaveChangesAsync();
        string labelExpected = "Label";

        // Act
        Question questionResult = await questionRepository.GetByIdAsync(1);

        // Assert
        Assert.AreEqual(labelExpected, questionResult.Label);
    }

    [TestMethod()]
    [ExpectedException(typeof(QuestionNotFoundException))]
    public async Task GetByIdAsync_InvalidQuestionToSearch_ThrowQuestionNotFoundException()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);

        // Act
        Question questionResult = await questionRepository.GetByIdAsync(1);
    }
    #endregion

    #region UpdateAsync
    [TestMethod()]
    public async Task UpdateAsync_QuestionToUpdate_QuestionUpdated()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);

        await context.Questions.AddAsync(new Question { Id = 1, Label = "Label", IsMandatory = false });
        await context.SaveChangesAsync();

        Question questionExpected = new Question() { Id = 1, Label = "LabelUpdated", IsMandatory = true };

        //Act
        Question questionUpdated = await questionRepository.UpdateAsync(questionExpected);

        //Assert
        ApplicationDbContext otherContext = new ApplicationDbContext(builder.Options);
        Assert.AreEqual(questionExpected.Label, otherContext.Questions.Find(1)?.Label);
        Assert.AreEqual(questionExpected.IsMandatory, otherContext.Questions.Find(1)?.IsMandatory);
    }

    [TestMethod()]
    [ExpectedException(typeof(QuestionNotFoundException))]
    public async Task UpdateAsync_InvalidQuestionToUpdate_ThrowQuestionNotFoundException()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        QuestionRepository questionRepository = new QuestionRepository(context);

        //Act
        Question question = new Question();
        await questionRepository.UpdateAsync(question);
    }
    #endregion
}