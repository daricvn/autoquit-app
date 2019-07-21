using Autoquit.Models;
using MouseHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoquit.Constant
{
    internal static class SharedProperty
    {
        public static Settings appSettings { get; set; }

        public static List<HotkeyItem> hotkeys { get; set; }

        public static bool ToggleHotkey(Form which, bool onlyRemove=false)
        {
            for (var i=0; i<hotkeys.Count; i++)
                if (hotkeys[i].active)
                {
                    hotkeys[i].active = false;
                    KeyboardHook.UnregisterHotKey(which.Handle, hotkeys[i].id);
                }
                else if (!onlyRemove)
                {
                    hotkeys[i].active = true;
                    KeyboardHook.RegisterHotKey(which.Handle, hotkeys[i].id, (int)hotkeys[i].modifier, hotkeys[i].key.GetHashCode());
                }
            return true;
        }
        public static bool IsHotkey(Keys key, KeyModifier modifier)
        {
            return hotkeys !=null && hotkeys.FindIndex(x => x.key == key && x.modifier == modifier && x.active==true) >= 0;
        }
        public static bool IsHotkey(int id, Keys key, KeyModifier modifier)
        {
            return hotkeys.FindIndex(x => x.id==id && x.key == key && x.modifier == modifier && x.active == true) >= 0;
        }
        public static HotkeyItem FindHotkey(int id)
        {
            return hotkeys.FirstOrDefault(x => x.id == id);
        }
        public static bool IsHotkeyRegistered
        {
            get
            {
                foreach (var item in hotkeys)
                    if (item.active == false)
                        return false;
                return true;
            }
        }
        public static bool UpdateHotkeys(int startId=0)
        {
            if (hotkeys == null)
                hotkeys = new List<HotkeyItem>();
            hotkeys.Clear();
            HotkeyItem temp;
            if (!string.IsNullOrWhiteSpace(appSettings.PlayHotKey))
            {
                temp =new HotkeyItem();
                temp.id = hotkeys.Count + startId;
                Enum.TryParse(appSettings.PlayHotKey,out temp.key);
                temp.modifier = KeyModifier.None;
                if (!string.IsNullOrWhiteSpace(appSettings.PlayModifier))
                    Enum.TryParse(appSettings.PlayModifier, out temp.modifier);
                temp.active = false;
                temp.event_name = "PLAY";
                hotkeys.Add(temp);
            }
            if (!string.IsNullOrWhiteSpace(appSettings.RecordHotKey))
            {
                temp = new HotkeyItem();
                temp.id = hotkeys.Count + startId;
                Enum.TryParse(appSettings.RecordHotKey, out temp.key);
                temp.modifier = KeyModifier.None;
                temp.active = false;
                temp.event_name = "RECORD";
                hotkeys.Add(temp);
            }
            return hotkeys.Count > 0;
        }

    }
}
