using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;
using MeetingApp.Infrastructure.Repositories.Base;

namespace MeetingApp.Infrastructure.Repositories
{
    public class UserOtpRepository : EfRepositoryBase<UserOtpEntity> ,IUserOtpRepository
    {
    }
}
