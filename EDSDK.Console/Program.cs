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
        private static SDKHandler sdk;
        
        public static async Task Main(string[] args)
        {
            Console.WriteLine(args[0]);
            await Task.Delay(2000);

            return;
            
            sdk = new SDKHandler();
            sdk.SDKObjectEvent += OnObject;
            // sdk.ImageSaveDirectory = @"C:\Users\user\Downloads\imgs";
            // sdk.SetSetting(EDSDKLib.EDSDK.EdsSaveTo, new EDSDKLib.EDSDK.EdsSaveImageSetting());
            
            var cams = sdk.GetCameraList();
            Debug.Log("Cameras: " + cams.Count);
            foreach (var cam in cams)
            {
                Debug.Log(cam.Info + " - " + cam.Info.szDeviceDescription);
            }

            try
            {
                sdk.OpenSession(cams[0]);
                TakePhoto();
                
                var entry = sdk.GetAllEntries();
                Debug.Log(entry.Name);
                foreach (var en in entry.Entries)
                {
                    Debug.Log("0: " + en.Name);
                    foreach (var sub in en.Entries)
                    {
                        Debug.Log("1: " + sub.Name + " - " + sub.IsFolder);
                        if (sub.Entries == null) continue;
                        foreach (var file in sub.Entries)
                        {
                            Debug.Log(file.Name);
                            if (file.Entries != null)
                            {
                                foreach (var f in file.Entries)
                                {
                                    Debug.Log(f.Name);
                                    if (f.Thumbnail != null)
                                    {
                                        f.Thumbnail.Save(@"C:\Users\user\Downloads\imgs\" + f.Name);
                                    }
                                }
                            }
                        }
                    }
                }
                // await TakePhotoLoop(0);
            }
            finally
            {
                sdk.CloseSession();
            }

            Debug.Log("DONE");
            Process.GetCurrentProcess().Kill();
        }

        private static uint OnObject(uint inevent, IntPtr inref, IntPtr incontext)
        {
            Debug.Log(inevent);
            return 0;
        }

        private static void TakePhoto()
        {
            // if (i >= 2) return;
            sdk.TakePhoto();
            // sdk.DownloadImage(sdk.GetCameraList()[0].Ref, @"C:\Users\user\Downloads\imgs\test.jpg");
            // TakePhotoLoop(++i);
            // sdk.DownloadImage();
        }
    }
}