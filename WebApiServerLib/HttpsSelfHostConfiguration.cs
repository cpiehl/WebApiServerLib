using System;
using System.ServiceModel.Channels;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace WebApiServerLib
{
	class HttpsSelfHostConfiguration : HttpSelfHostConfiguration
	{
		public HttpsSelfHostConfiguration(Uri baseAddress) : base(baseAddress) { }

        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            if (BaseAddress.ToString().ToLower().Contains("https://"))
            {
                httpBinding.Security.Mode = HttpBindingSecurityMode.Transport;
            }

            return base.OnConfigureBinding(httpBinding);
        }
	}
}
