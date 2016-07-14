using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCALQR
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}
