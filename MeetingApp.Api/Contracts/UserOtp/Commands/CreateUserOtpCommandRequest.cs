﻿using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.UserOtp.Commands
{
    public class CreateUserOtpCommandRequest : BaseResquestModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
