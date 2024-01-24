using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
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
    public async Task CreateAsync_FormToAdd_FormWithId()
    {
        // Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FormRepository formRepository = new FormRepository(context);
        int IdExpected = 1;
        Form formToAdd = new Form() { Title = "title" };

        // Act
        await formRepository.CreateAsync(formToAdd);


        // Assert
        Assert.AreEqual(IdExpected, context.Forms.Find(1)?.Id);
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

        // Assert
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
        await context.AddAsync(new Form { Id = 1, Title = "title1" });
        await context.SaveChangesAsync();
        string titleExpected = "title1";

        // Act 
        Form formResult = await formRepository.GetByIdAsync(1);

        // Assert
        Assert.AreEqual(titleExpected, formResult.Title);
    }

    [TestMethod()]
    [ExpectedException(typeof(FormNotFoundException))]
    public async Task GetByIdAsync_InvalidFormToSearch_ThrowFormNotFoundException()
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



}