﻿using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Degree.Commands
{
    public class CreateDegreeCommandRequest : BaseResquestModel
    {
        public string Description { get; set; }
    }
}
