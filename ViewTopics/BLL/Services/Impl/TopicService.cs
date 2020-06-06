using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using CLL.Security;
using System.Security.Permissions;
using CLL.Security.Identity;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class TopicService
        : ITopicService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public TopicService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<topicDTO> GetTopics(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            var categoryId = int.Parse(user.Category_ID);
            var topicsEntities =
                _database
                    .topics
                    .Find(z => z.Category_ID == categoryId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<topic, topicDTO>()
                    ).CreateMapper();
            var topicsDto =
                mapper
                    .Map<IEnumerable<topic>, List<topicDTO>>(
                        topicsEntities);
            return topicsDto;
        }
        public void AddStreet(topicDTO ntopic)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
                || userType != typeof(Moder))
            {
                throw new MethodAccessException();
            }
            if (ntopic == null)
            {
                throw new ArgumentNullException(nameof(ntopic));
            }

            validate(ntopic);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<topicDTO, topic>()).CreateMapper();
            var topicEntity = mapper.Map<topicDTO, topic>(ntopic);
            _database.topics.Create(topicEntity);
        }
        private void validate(topicDTO ntopic)
        {
            if (string.IsNullOrEmpty(ntopic.Topic_Name))
            {
                throw new ArgumentException("Topic_Name must consist value!");
            }
        }
    }
}
