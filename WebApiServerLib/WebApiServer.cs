using CPLogging;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebApiServerLib
{
	public class WebApiServer
	{
		HttpSelfHostServer server;
		HttpSelfHostConfiguration config;
		Uri hostUri;
		public int MaxBufferSize = int.MaxValue;
		public int MaxReceivedMessageSize = int.MaxValue;

		public WebApiServer(string hostAddr)
		{
			this.hostUri = new Uri(hostAddr);
		}

		public bool Start()
		{
			try
			{
				config = new HttpsSelfHostConfiguration(this.hostUri);
				config.Routes.MapHttpRoute("API DEFAULT", "{controller}/{action}",
					new { id = RouteParameter.Optional });

				config.MaxBufferSize = this.MaxBufferSize;
				config.MaxReceivedMessageSize = this.MaxReceivedMessageSize;

				server = new HttpSelfHostServer(config);
				server.OpenAsync();

				return true;
			}
			catch (Exception e)
			{
				Logging.Write(e.ToString());
				return false;
			}
		}

		public bool Stop()
		{
			try
			{
				server.CloseAsync();
				return true;
			}
			catch (Exception e)
			{
				Logging.Write(e.ToString());
				return false;
			}
		}

		// DO NOT DELETE
		private void ReferencesDummy()
		{
			(new System.Collections.Generic.List<Type>
			{
				typeof(HttpPostAttribute),
				typeof(RoutePrefixAttribute),
				typeof(ApiController),
				new HttpRequestMessage().Content.IsMimeMultipartContent().GetType(),
			}).ForEach(e => Console.WriteLine(e));
		}
	}
}
