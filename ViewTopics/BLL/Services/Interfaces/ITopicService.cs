using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<topicDTO> GetTopics(int page);
    }
}
