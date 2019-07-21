using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit.Models
{
    internal class Settings
    {
        public string RecordHotKey { get; set; }
        public string PlayHotKey { get; set; }
        public string PlayModifier { get; set; }
        public string RetrieveCoordKey { get; set; }
        public string RetrieveCoordModifier { get; set; }
        public string Language { get; set; }

        public bool Save(string filePath)
        {
            var str = JsonConvert.SerializeObject(this);
            if (!string.IsNullOrEmpty(filePath) &&
                (filePath.Contains("/") || filePath.Contains("\\"))
                && !Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var bytes = Encoding.UTF8.GetBytes(str);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
            }
            return true;
        }
        public bool Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var result = false;
                    var bytes = new byte[fs.Length];
                    var count=fs.Read(bytes, 0, bytes.Length);
                    if (count == 0) return false;
                    try
                    {
                        var temp = JsonConvert.DeserializeObject<Settings>(Encoding.UTF8.GetString(bytes));
                        if (temp != null)
                        {
                            this.PlayHotKey = temp.PlayHotKey;
                            this.PlayModifier = temp.PlayModifier;
                            this.RecordHotKey = temp.RecordHotKey;
                            this.RetrieveCoordKey = temp.RetrieveCoordKey;
                            this.RetrieveCoordModifier = temp.RetrieveCoordModifier;
                            this.Language = temp.Language ?? "en-us.json";
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    finally
                    {
                        fs.Close();
                    }
                    return result;
                }
            }
            return false;
        }
    }
}
