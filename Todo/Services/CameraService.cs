using Dynamsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services
{
    public class CameraService : ICameraService
    {
        private readonly String webApikey = "DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ=="; 

        public async Task<bool> InitService() 
        {
            await Task.Run(() =>
            {
                BarcodeQRCodeReader.InitLicense(webApikey);
            });
            return true;
        }
    }
}
