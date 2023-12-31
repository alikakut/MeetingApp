﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Base;

namespace MeetingApp.Domain.Entities
{
    [Table("user_otp")]
    public class UserOtpEntity : BaseEntity
    {
        [Column("email")]
        public string Email { get; set; }

        [Column("password_no")]
        public string Password { get; set; }
    }
}
