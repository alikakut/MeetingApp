using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Utilities.Authorization.Model
{
    public class TokenModel
    {
        public long PersonnelId { get; set; }
        public string Username { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
        public string RefreshToken { get; set; }
        public long? SaleChannelId { get; set; }
        public string? SaleChannelName { get; set; }
        public byte PersonnelType { get; set; }
    }
}
