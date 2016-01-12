using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Registry_Scriptor
{
    class Scriptor
    {
        public static RegistryKey GetKey(string keyname)
        {
            string rootName = "";
            string subkeyName = "";

            rootName = Regex.Match(keyname, "HKEY_[^\\\\]+", RegexOptions.IgnoreCase).Value.ToUpper();
            if (rootName.Length < 6) return null;
            rootName = rootName.Substring(5);

            subkeyName = Regex.Match(keyname, "[\\\\].+").Value.Trim('\\');

            if (rootName == "CLASSES_ROOT")
            {
                if (subkeyName == "")
                    return Registry.ClassesRoot;
                else
                    return Registry.ClassesRoot.OpenSubKey(subkeyName);
            }
            else if (rootName == "CURRENT_USER")
            {
                if (subkeyName == "")
                    return Registry.CurrentUser;
                else
                    return Registry.CurrentUser.OpenSubKey(subkeyName);
            }
            else if (rootName == "LOCAL_MACHINE")
            {
                if (subkeyName == "")
                    return Registry.LocalMachine;
                else
                    return Registry.LocalMachine.OpenSubKey(subkeyName);
            }
            else if (rootName == "USERS")
            {
                if (subkeyName == "")
                    return Registry.Users;
                else
                    return Registry.Users.OpenSubKey(subkeyName);
            }
            else if (rootName == "CURRENT_CONFIG")
            {
                if (subkeyName == "")
                    return Registry.CurrentConfig;
                else
                    return Registry.CurrentConfig.OpenSubKey(subkeyName);
            }
            return null;
        }
        public static string GetScript(RegistryKey key)
        {
            string script = "[" + key.Name + "]", vname;
            foreach (string val in key.GetValueNames())
            {
                vname = val == "" ? "@" : '\"' + val + '\"';
                script += "\r\n";
                switch (key.GetValueKind(val))
                {
                    case RegistryValueKind.String:
                        script += vname + "=\"" + key.GetValue(val).ToString().Replace("\\", "\\\\").Replace("\r\n", string.Empty) + "\"";
                        break;
                    case RegistryValueKind.Binary:
                        {
                            byte[] data = (byte[])key.GetValue(val);
                            string s = vname + "=hex:";
                            script += s + GetFormattedHexFromByteArray(data, s.Length);
                        }
                        break;
                    case RegistryValueKind.DWord:
                        {
                            Int32 data = ((Int32)key.GetValue(val));
                            string s = vname + "=dword:" + data.ToString("X");
                            script += s;
                        }
                        break;
                    case RegistryValueKind.None:
                        {
                            byte[] data = (byte[])key.GetValue(val);
                            string s = vname + "=hex(0):";
                            script += s + GetFormattedHexFromByteArray(data, s.Length);
                        }
                        break;
                    case RegistryValueKind.ExpandString:
                        {
                            string str = (String)key.GetValue(val);
                            byte[] data = new byte[str.Length * 2 + 2];
                            Encoding.Unicode.GetBytes(str).CopyTo(data, 0);
                            string st = GetFormattedHexFromByteArray(data, vname.Length + 8);
                            string s = vname + "=hex(2):";

                            script += s + GetFormattedHexFromByteArray(data, s.Length);
                        }
                        break;
                    case RegistryValueKind.MultiString:
                        {
                            string[] strings = (string[])key.GetValue(val);
                            byte[] data = new byte[strings.Sum((st) => st.Length * 2 /*2 bytes per char*/) + 2 * (strings.Length + 1) /*end of record and empty record bytes*/];
                            long idx = 0;
                            foreach (string str in strings)
                            {
                                var bytes = Encoding.Unicode.GetBytes(str);
                                bytes.CopyTo(data, idx);
                                idx += bytes.Length;
                                idx += 2;
                            }
                            string s = vname + "=hex(7):";
                            script += s + GetFormattedHexFromByteArray(data, s.Length);
                        }
                        break;
                    case RegistryValueKind.QWord:
                        {
                            Int64 data = (Int64)key.GetValue(val);
                            string s = vname + "=hex(b):";
                            string st = data.ToString("X");
                            short count = 0;
                            for (int i = st.Length - 2; i >= 0; i -= 2)
                            {
                                s += st.Substring(i, 2) + ",";
                                count++;
                            }
                            while (count++ < 8)
                                s += "00,";
                            script += s.Trim(',');
                        }
                        break;
                    case RegistryValueKind.Unknown:
                        script += "; Unsupported value: " + val;
                        break;
                    default:
                        {
                            byte[] data = (byte[])key.GetValue(val);
                            string s = vname + "=hex:";
                            script += s + GetFormattedHexFromByteArray(data, s.Length);
                        }
                        break;
                }
            }
            return script;
        }

        private static string GetFormattedHexFromByteArray(byte[] data, int offset)
        {
            if (data == null) return "ERROR";
            StringBuilder s = new StringBuilder();
            foreach (byte b in data)
            {
                offset += 3;
                if (offset >= 75)
                { s.Append("\\\r\n"); offset = 0; }
                s.Append((b <= 0xF ? "0" : "") + b.ToString("X") + ",");
            }
            return s.ToString().Trim(',');
        }

        public static void ListKeys(string[] keys, ref int count, ref List<RegistryKey> list, ref List<string> errors, HashSet<string> exclusions)
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
