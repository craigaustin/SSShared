using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStackShared.App_Start;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceInterface;

namespace ServiceStackShared
{
    public abstract class AppServiceBase<T> : ServiceBase<T>
    {
        //Injected in IOC - defaults to InMemory Cache if not defined in AppHost
        public ICacheClient Cache { get; set; }

        private CustomUserSession userSession;
        protected CustomUserSession UserSession
        {
            get
            {
                if (userSession != null) return userSession;

                if (SessionKey != null)
                    userSession = this.Cache.Get<CustomUserSession>(SessionKey);
                else
                    SessionFeature.CreateSessionIds();

                var newSession = new CustomUserSession();
                return userSession ?? (userSession = newSession);
            }
        }

        protected string SessionKey
        {
            get
            {
                var sessionId = SessionFeature.GetSessionId();
                return sessionId == null ? null : SessionFeature.GetSessionKey(sessionId);
            }
        }
    }
}