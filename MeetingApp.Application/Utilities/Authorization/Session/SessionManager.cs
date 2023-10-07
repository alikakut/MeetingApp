using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Utilities.Authorization.Constant;
using MeetingApp.Application.Utilities.Authorization.Extensions;
using MeetingApp.Application.Utilities.Authorization.Model;
using Microsoft.AspNetCore.Http;

namespace MeetingApp.Application.Utilities.Authorization.Session
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public SessionManager(HttpContext context)
        {
            _session = context.Session;
        }

        public virtual PersonnelSessionModel LoginResult
        {
            get
            {
                var _userInfo = _session.GetObjectFromJson<PersonnelSessionModel>(SessionConstant.PERSONNEL_INFO);
                if (_userInfo != null)
                    return _userInfo;
                else
                    return null;
            }
            set
            {
                _session.SetObjectAsJson(SessionConstant.PERSONNEL_INFO, value);
            }
        }

        public int? PersonnelId
        {
            get
            {
                var v = _session.GetInt32(SessionConstant.PERSONNEL_ID);
                if (v.HasValue)
                    return v.Value;
                else
                    return null;
            }
            set
            {
                _session.SetInt32(SessionConstant.PERSONNEL_ID, value.Value);
            }
        }

        public string UserName
        {
            get
            {
                return _session.GetString(SessionConstant.USER_NAME);
            }
            set
            {
                _session.SetString(SessionConstant.USER_NAME, value);
            }
        }
    }
}
