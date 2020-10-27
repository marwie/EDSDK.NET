using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EDSDK.NET;

namespace EDSDK
{
    public static class Debug
    {
        public static void Log(object obj)
        {
            Console.WriteLine(obj);
        }
    }
    
    internal static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var sdk = new SDKHandler();
            
            var cams = sdk.GetCameraList();
            Debug.Log("Cameras: " + cams.Count);
            foreach (var cam in cams)
            {
                Debug.Log(cam.Info + " - " + cam.Info.szDeviceDescription);
                
            }

            try
            {
                sdk.OpenSession(cams[0]);

                // sdk.SetSetting();
                // foreach(var setting in sdk.GetSettingsList())
                sdk.StartLiveView();
                // sdk.TakePhoto();
                await Task.Delay(2000);
            }
            finally
            {
                sdk.CloseSession();
            }

            return 0;
        }
    }
}