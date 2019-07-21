using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit.Services
{
    static internal class ScriptContent
    {
        public static bool Write(string path, object content)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var df = new DeflateStream(fs, CompressionLevel.Fastest))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));
                    df.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static T Read<T>(string path)
        {
            try
            {
                int count = 0;
                byte[] bytes;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var df = new DeflateStream(fs, CompressionMode.Decompress))
                using (var ms= new MemoryStream())
                {
                    df.CopyTo(ms);
                    bytes = new byte[ms.Length];
                    ms.Seek(0, SeekOrigin.Begin);
                    count=ms.Read(bytes, 0, (int) ms.Length);
                }
                    if (count > 0)
                    {
                        var str = Encoding.UTF8.GetString(bytes);
                        return JsonConvert.DeserializeObject<T>(str);
                    }
            }
            catch (Exception e)
            {
            }
            return default(T);
        }
    }
}
