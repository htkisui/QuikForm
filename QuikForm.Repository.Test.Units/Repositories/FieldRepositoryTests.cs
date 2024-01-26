using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Exceptions.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories.Tests;

[TestClass()]
public class FieldRepositoryTests
{

    #region CreateAsync
    [TestMethod()]
    public async Task CreateAsync_FieldToAdd_FieldAdded()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        Field fieldToAdd = new Field() { Id = 1, Label = "Question to answer", QuestionId = 1 };
        int idExpected = 1;

        //Act
        await fieldRepository.CreateAsync(fieldToAdd);

        //Assert
        Assert.AreEqual(idExpected, context.Fields.Find(1)?.Id);
    }
    #endregion

    #region DeleteAsync
    [TestMethod()]
    public async Task DeleteAsync_FieldToDelete_EmptyList()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        Field fieldToDelete = new Field() { Id = 1, Label = "Question option", QuestionId = 1 };
        await context.Fields.AddAsync(fieldToDelete);
        await context.SaveChangesAsync();
        int countExpected = 0;

        //Act
        await fieldRepository.DeleteAsync(1);

        //Assert
        Assert.AreEqual(countExpected, context.Fields.Count());
    }

    [TestMethod()]
    [ExpectedException(typeof(FieldNotFoundException))]
    public async Task DeleteAsync_FieldToDelete_ThrowFieldNotFoundException()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        //Act
        await fieldRepository.DeleteAsync(1);
    }
    #endregion

    #region GetAllAsync
    [TestMethod()]
    public async Task GetAll_Empty_FieldList()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        List<Field> fields = new List<Field>
        {
            new Field { Id = 1, Label = "Question to answer", QuestionId = 1 },
            new Field { Id = 2, Label = "Question to answer", QuestionId = 2 },
        };

        await context.Fields.AddRangeAsync(fields);
        await context.SaveChangesAsync();

        //Act
        List<Field> fieldsResult = await fieldRepository.GetAllAsync();

        //Assert
        Assert.AreEqual(context.Fields.Count(), fieldsResult.Count());
    }
    #endregion

    #region GetByIdAsync
    [TestMethod()]
    public async Task GetByIdAsync_FieldToSearch_FieldFound()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        await context.Fields.AddAsync(new Field() { Id = 1, Label = "Question to answer", QuestionId = 1 });
        await context.SaveChangesAsync(); ;

        string labelExpected = "Question to answer";

        //Act
        Field actualField = await fieldRepository.GetByIdAsync(1);

        //Assert
        Assert.AreEqual(labelExpected, actualField.Label);
    }

    [TestMethod()]
    [ExpectedException(typeof(FieldNotFoundException))]
    public async Task GetByIdAsync_FieldToSearch_ThrowFieldNotFoundException()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        //Act
        await fieldRepository.GetByIdAsync(1);
    }
    #endregion

    #region UpdateAsync
    [TestMethod()]
    public async Task UpdateAsync_FieldToUpdate_FieldUpdated()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        await context.Fields.AddAsync(new Field() { Id = 1, Label = "Question to answer", QuestionId = 1 });
        await context.SaveChangesAsync();

        Field fieldExpected =  new Field() { Id = 1, Label = "Question updated", QuestionId = 1 };

        //Act
        Field fieldUpdated = await fieldRepository.UpdateAsync(fieldExpected);
        ApplicationDbContext otherContext = new ApplicationDbContext(builder.Options);

        //Assert
        Assert.AreEqual(fieldExpected.Label, otherContext.Fields.Find(1)?.Label);
    }

    [TestMethod()]
    [ExpectedException(typeof(FieldNotFoundException))]
    public async Task UpdateAsync_FieldToUpdate_ThrowFieldNotFoundException()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        Field fieldToUpdate = new Field();

        //Act
        await fieldRepository.UpdateAsync(fieldToUpdate);
    }
    #endregion
}