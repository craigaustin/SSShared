using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStackShared.App_Start;

namespace ServiceStackShared.Controllers
{
    public class AppControllerBase : ServiceStackController<CustomUserSession> 
    {
        // expose this so filters can get to the UserSession
        public CustomUserSession GetUserSession
        {
            get
            {
                return UserSession;
            }
        }

        public void SaveSession(TimeSpan? expiresIn = null)
        {
            Cache.CacheSet(SessionKey, UserSession, expiresIn ?? new TimeSpan(0, 30, 0));
        }

        //protected string SessionKey
        //{
        //    get
        //    {
        //        var sessionId = SessionFeature.GetSessionId();
        //        return sessionId == null ? null : SessionFeature.GetSessionKey(sessionId);
        //    }
        //}
    }
}