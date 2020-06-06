using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using CLL.Security;
using System.Security.Permissions;
using CLL.Security.Identity;
using AutoMapper;
using Xunit;
using BLL.Services.Impl;
using Moq;
using DAL.Repositories.Interfaces;
using DAL.Entities;

namespace BLL.Tests
{
    public class TopicServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new TopicService(nullUnitOfWork));
        }
        [Fact]
        public void GetTopics_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", "1");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ITopicService topicService = new TopicService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => topicService.GetTopics(0));
        }
        [Fact]
        public void GetTopics_TopicFromDAL_CorrectMappingToTopicDTO()
        {
            // Arrange
            User user = new Moder(1, "test", "1");
            SecurityContext.SetUser(user);
            var topicService = GetTopicService();

            // Act
            var actualTopicDto = topicService.GetTopics(0).First();

            // Assert
            Assert.True(
                actualTopicDto.Topic_ID == 1
                && actualTopicDto.Topic_Name == "testN"
                && actualTopicDto.Topic_Description == "testD"
                );
        }
        ITopicService GetTopicService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedTopic = new topic() { Topic_ID = 1, Topic_Name = "testN", Topic_Description = "testD", Category_ID = 2 };
            var mockDbSet = new Mock<ITopicRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<topic, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<topic>() { expectedTopic }
                    );
            mockContext
                .Setup(context =>
                    context.topics)
                .Returns(mockDbSet.Object);

            ITopicService topicService = new TopicService(mockContext.Object);

            return topicService;
        }

    }
}
