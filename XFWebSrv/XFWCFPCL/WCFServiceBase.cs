using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace XFWCFPCL
{
    public class WCFServiceBase
    {
        public Task<int> Sum(int v1, int v2)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            var binding = new BasicHttpBinding()
            {
                Name = "basicHttpBinding",
                MaxReceivedMessageSize = 67108864,
            };

            var timeout = new TimeSpan(0, 1, 0);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;

            var client = new ServiceReference1.Service1Client(binding, new EndpointAddress("http://wcfservice120160626121524.azurewebsites.net/Service1.svc"));
            client.GetSumDataCompleted += (s,e) =>
            {
                tcs.SetResult(e.Result);
            };
            client.GetSumDataAsync(v1, v2);
            return tcs.Task;
        }
    }
}
