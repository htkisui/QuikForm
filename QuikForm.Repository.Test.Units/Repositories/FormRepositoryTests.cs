using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using QuikForm.Repository.Contracts.Contracts;
using QuikForm.Repository.Contracts.Exceptions.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories.Tests;

[TestClass()]
public class FormRepositoryTests
{
    #region CreateAsync

    [TestMethod()]
    public async Task CreateAsync_FormToAdd_FormAdded()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        int idExpected = 1;
        Form formToAdd = new Form() { Title = "title" };

        // Act
        await formRepository.CreateAsync(formToAdd);


        // Assert
        Assert.AreEqual(idExpected, context.Forms.Find(1)?.Id);
    }

    #endregion

    #region DeleteAsync
    [TestMethod()]
    public async Task DeleteAsync_FormToDelete_EmptyList()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);

        await context.Forms.AddAsync(new Form() { Id = 1, Title = "title" });
        await context.SaveChangesAsync();
        int countExpected = 0;

        // Act
        await formRepository.DeleteAsync(1);

        // Assert
        Assert.AreEqual(countExpected, context.Forms.Count());
    }

    [TestMethod()]
    [ExpectedException(typeof(FormNotFoundException))]
    public async Task DeleteAsync_FormToDelete_FormNotFound()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);

        // Act
        await formRepository.DeleteAsync(1);
    }
    #endregion

    #region GetByIdAsync
    [TestMethod()]
    public async Task GetByIdAsync_FormToSearch_FormToFound()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        await context.Forms.AddAsync(entity: new Form { Id = 1, Title = "title1" });
        await context.SaveChangesAsync();
        string titleExpected = "title1";

        // Act 
        Form formResult = await formRepository.GetByIdAsync(1);

        // Assert
        Assert.AreEqual(titleExpected, formResult.Title);

    }

    [TestMethod()]
    [ExpectedException(typeof(FormNotFoundException))]
    public async Task GetByIdAsync_InvalidForm_ThrowFormNotFoundException()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);

        // Act 
        Form formResult = await formRepository.GetByIdAsync(1);

    }
    #endregion

    #region GetAllAsync
    [TestMethod()]
    public async Task GetAllAsync_Empty_Forms()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        List<Form> forms = new List<Form>()
        {
            new Form { Id = 1, Title = "titleA" },
            new Form { Id = 2, Title = "titleB" },
            new Form { Id = 3, Title = "titleC" }
        };
        await context.Forms.AddRangeAsync(forms);
        await context.SaveChangesAsync();
        int countExpected = 3;

        // Act 
        List<Form> formsResult = await formRepository.GetAllAsync();
        int countResult = formsResult.Count();

        // Assert
        Assert.AreEqual(countExpected, countResult);
    }
    #endregion

    #region UpdateAsync

    [TestMethod()]
    public async Task UpdateAsync_FormToUpdate_FormUpdated()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        await context.Forms.AddAsync(new Form() { Id = 1, Title = "Title1", Description = "Description", PublishedAt = DateTime.Parse("12/01/2024"), ClosedAt = DateTime.Parse("24/01/2024") });
        await context.SaveChangesAsync();
        Form formExpected = new Form() { Id = 1, Title = "TitleUpdate", Description = "DescriptionUpdate", PublishedAt = DateTime.Parse("15/01/2024"), ClosedAt = DateTime.Parse("25/01/2024") };

        // Act
        Form formResult = await formRepository.UpdateAsync(formExpected);
        ApplicationDbContext otherContext = new ApplicationDbContext(builder.Options);

        // Assert
        Assert.AreEqual(formExpected.Title, otherContext.Forms.Find(1)?.Title);
        Assert.AreEqual(formExpected.Description, otherContext.Forms.Find(1)?.Description);
        Assert.AreEqual(formExpected.PublishedAt, otherContext.Forms.Find(1)?.PublishedAt);
        Assert.AreEqual(formExpected.ClosedAt, otherContext.Forms.Find(1)?.ClosedAt);
    }

    [TestMethod()]
    [ExpectedException(typeof(FormNotFoundException))]
    public async Task UpdateAsync_InvalidForm_ThrowFormNotFoundException()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        Form form = new Form() { Id = 1};

        // Act
        Form formResult = await formRepository.UpdateAsync(form);
    }

    #endregion

}