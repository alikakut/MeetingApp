﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Domain.Base
{
    public class BaseEntity
    {
        [Column("id")]
        [Key]
        public long? Id { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
