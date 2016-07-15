using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFWebSrv
{
    public interface IWCFService
    {
        Task<int> Sum(int v1, int v2);
    }
}
