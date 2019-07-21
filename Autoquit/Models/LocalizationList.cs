using Autoquit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit.Models
{
    public class LocalizationList
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public LocalizationList()
        {

        }
        public static List<LocalizationList> Create(string[] list)
        {
            var result = new List<LocalizationList>();
            foreach (string item in list)
                result.Add(new LocalizationList()
                {
                    Value = item,
                    Text = Language.Get(item)
                });
            return result;
        }
    }
}
