using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Mvc;
using ServiceStack.Configuration;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStackShared
{
	/*
	 * ServiceStack's Hello World Web Service. 
	 */

	//Request DTO
	public class Hello
	{
		public string Name { get; set; }
	}

	//Response DTO
	public class HelloResponse : IHasResponseStatus
	{
		public string Result { get; set; }
        public int HelloCount { get; set; }
		public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
	}

	//Implementation. Can be called via any endpoint or format, see: http://servicestack.net/ServiceStack.Hello/
    public class HelloService : AppServiceBase<Hello>
	{
		protected override object Run(Hello request)
		{
            UserSession.HelloCount++;
            return new HelloResponse { Result = "Hello, " + request.Name, HelloCount = UserSession.HelloCount };
		}
	}

}
