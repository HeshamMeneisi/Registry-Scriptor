using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Registry_Scriptor
{
    class Scriptor
    {
        public static RegistryKey GetKey(string keyname)
        {
            RegistryKey retKey = null;
            string rootName = "";
            string subkeyName = "";
            if (keyname.Contains("\\"))
            {
                rootName = keyname.Substring(keyname.IndexOf("_") + 1, keyname.IndexOf("\\") - keyname.IndexOf("_") - 1);
                subkeyName = keyname.Substring(keyname.IndexOf("\\") + 1);
            }
            else
                rootName = keyname.Substring(keyname.IndexOf("_") + 1);
            if (rootName.ToUpper() == "CLASSES_ROOT")
            {
                if (subkeyName == "")
                    retKey = Registry.ClassesRoot;
                else
                    retKey = Registry.ClassesRoot.OpenSubKey(subkeyName);
            }
            else if (rootName.ToUpper() == "CURRENT_USER")
            {
                if (subkeyName == "")
                    retKey = Registry.CurrentUser;
                else
                retKey = Registry.CurrentUser.OpenSubKey(subkeyName);
            }
            else if (rootName.ToUpper() == "LOCAL_MACHINE")
            {
                if (subkeyName == "")
                    retKey = Registry.LocalMachine;
                else
                retKey = Registry.LocalMachine.OpenSubKey(subkeyName);
            }
            else if (rootName.ToUpper() == "USERS")
            {
                if (subkeyName == "")
                    retKey = Registry.Users;
                else
                retKey = Registry.Users.OpenSubKey(subkeyName);
            }
            else if (rootName.ToUpper() == "CURRENT_CONFIG")
            {
                if (subkeyName == "")
                    retKey = Registry.CurrentConfig;
                else
                retKey = Registry.CurrentConfig.OpenSubKey(subkeyName);
            }
            return retKey;
        }
        public static string GetScript(RegistryKey key)
        {
            string script = "[" + key.Name + "]";
            foreach (string val in key.GetValueNames())
            {
                if (val != string.Empty)
                {
                    script += "\r\n";
                    if (key.GetValueKind(val) == RegistryValueKind.String)
                    {
                        script += "\"" + val + "\"=\"" + key.GetValue(val).ToString().Replace("\\", "\\\\").Replace("\r\n", string.Empty) + "\"";
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.Binary)
                    {
                        byte[] data = (byte[])key.GetValue(val);
                        string s = "\"" + val + "\"=hex:" + GetHexFromByteArray(data);
                        script += s;
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.DWord)
                    {
                        Int32 data = ((Int32)key.GetValue(val));
                        string s = "\"" + val + "\"=dword:" + data.ToString("X");
                        script += s;
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.None)
                    {
                        byte[] data = (byte[])key.GetValue(val);
                        string s = "\"" + val + "\"=hex(0):" + GetHexFromByteArray(data);
                        script += s;
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.ExpandString)
                    {
                        byte[] data = Encoding.UTF8.GetBytes((String)key.GetValue(val));
                        string st = GetHexFromByteArray(data);
                        string s = "\"" + val + "\"=hex(2):";
                        foreach(string h in st.Split(','))
                            s += h + ",00,";
                        s += "00";
                        script += s;
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.MultiString)
                    {
                        string[] data = (string[])key.GetValue(val);
                        string s = "\"" + val + "\"=hex(7):";
                        foreach (string st in data)
                        {
                            foreach (string h in GetHexFromByteArray(Encoding.UTF8.GetBytes(st)).Split(','))
                                s += h + ",00,";
                            s += "00,00,";
                        }
                        script += s.Trim(',');
                    }
                    else if (key.GetValueKind(val) == RegistryValueKind.QWord)
                    {
                        Int64 data = (Int64)key.GetValue(val);
                        string s = "\"" + val + "\"=hex(b):";
                        string st = data.ToString("X");
                        for(int i=st.Length-2;i>=0;i-=2)
                            s += st.Substring(i,2)+",";
                        script += s.Trim(',');
                    }
                    else
                    {
                        byte[] data = (byte[])key.GetValue(val);
                        string s = "\"" + val + "\"=hex:" + GetHexFromByteArray(data);
                        script += s;
                    }
                }
            }
            return script;
        }

        private static string GetHexFromByteArray(byte[] data)
        {
            string s = "";
            foreach (byte b in data)
                s += b.ToString("X") + ",";
            return s.Trim(',');
        }

        public static void ListKeys(string[] keys, ref int count, ref List<RegistryKey> list, ref List<string> errors, List<string> exclusions)
        {
            foreach (string k in keys)
            {
                try
                {
                    if (exclusions.Contains(k))
                        continue;
                    RegistryKey key = GetKey(k);
                    list.Add(key);
                    count++;
                    ListKeys(GetFullSubKeyNames(key), ref count, ref list, ref errors, exclusions);
                }
                catch (Exception ex)
                {
                    errors.Add(k + "%%##" + ex.Message);
                }
            }
        }

        private static string[] GetFullSubKeyNames(RegistryKey key)
        {
            List<string> subs = new List<string>();
            foreach (string sub in key.GetSubKeyNames())
                subs.Add(key.Name + "\\" + sub);
            return subs.ToArray();
        }
    }
}
