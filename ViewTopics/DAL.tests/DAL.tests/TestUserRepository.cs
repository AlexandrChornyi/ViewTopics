using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using DAL.Repositories.Impl;


namespace DAL.tests
{
    class TestUserRepository
        : BaseRepository<users>
    {
        public TestUserRepository(DbContext context)
        : base(context)
        {
        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<categoryContext>()
                .Options;
            var mockContext = new Mock<categoryContext>(opt);
            var mockDbSet = new Mock<DbSet<users>>();
            mockContext
                .Setup(context =>
                    context.Set<users>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestUserRepository(mockContext.Object);

            users expectedStreet = new Mock<users>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<categoryContext>()
                .Options;
            var mockContext = new Mock<categoryContext>(opt);
            var mockDbSet = new Mock<DbSet<users>>();
            mockContext
                .Setup(context =>
                    context.Set<users>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestUserRepository(mockContext.Object);

            users expectedStreet = new users() { User_ID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.User_ID)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.User_ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.User_ID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<categoryContext>()
                .Options;
            var mockContext = new Mock<categoryContext>(opt);
            var mockDbSet = new Mock<DbSet<users>>();
            mockContext
                .Setup(context =>
                    context.Set<users>(
                        ))
                .Returns(mockDbSet.Object);

            users expectedStreet = new users() { User_ID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.User_ID))
                    .Returns(expectedStreet);
            var repository = new TestUserRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.User_ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.User_ID
                    ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }
    }
}
