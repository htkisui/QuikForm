using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuikForm.Entities;
using QuikForm.Repositories.Contexts;
using QuikForm.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikForm.Repositories.Repositories.Tests;

[TestClass()]
public class FieldRepositoryTests
{
    [TestMethod()]
    public void CreateAsync_FieldToAdd_FieldAdded()
    {
        //Arrange
        DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("QuikFormTest");
        ApplicationDbContext context = new ApplicationDbContext(builder.Options);
        context.Database.EnsureDeleted();
        FieldRepository fieldRepository = new FieldRepository(context);

        Field fieldToAdd = new Field() { Id = 1, Label = "Question to answer" };

        //Act

        //Assert
        Assert.Fail();
    }
}