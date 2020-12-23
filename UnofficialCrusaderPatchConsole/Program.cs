using System;
using System.IO;
using UCP.Patching;
using UCP.Startup;

namespace UCP
{
    class Program
    {
        static void Main(string[] args)
        {
            AOB aob = new AOB("ai_access");
            KMP kmp = new KMP(new ByteOrWildCard[]{
                /*0x75,*/ new ByteOrWildCard(0x12), new ByteOrWildCard(WildCard.Instance), new ByteOrWildCard(WildCard.Instance), new ByteOrWildCard(0x66), new ByteOrWildCard(0x66), new ByteOrWildCard(0x66)/*,new ByteOrWildCard(WildCard.Instance),new ByteOrWildCard(0x66), new ByteOrWildCard(WildCard.Instance), new ByteOrWildCard(0x66), new ByteOrWildCard(WildCard.Instance)*//*0x06, 0x03, 0x00, 0xEB, 0x12, 0x83, 0xF8, 0x02, 0x75, 0x07, 0x66, 0xC7, 0x06, 0x03, 
                0x00, 0xEB, 0x06, 0x66, 0x83, 0x3E, 0x03, 0x75, 0x14, 0x0F, 0xBF, 0x56, 0x20, 0x0F */
            });
            //  06 03 00 EB 12 83 F8 02 75 07 66 C7 06 03 00 EB 06 66 83 3E 03 75 14 0F BF 56 20 0F

            /*int match = kmp.search(new byte[]{
                0x10, 0x66, 0x66, 0x66
            });
            Console.WriteLine(match)*/;

            int match_address = kmp.findFirstInstance(new byte[]{
                0x12, 0x10, 0x10, 0x66, 0x66, 0x66
            });
            /*int match = kmp.search(new byte[]{
                0x10, 0x00, 0x07, 0x00, 0x66, 0xC7
            });*/
            /*int match_address = kmp.findFirstInstance(new byte[]{
                0x10, 0x00, 0x07, 0x00, 0x66, 0xC7
            });*/

            
            Console.WriteLine(match_address);
            /*Configuration.Load();
            StartTroopChange.Load();
            ResourceChange.Load();
            Version.AddExternalChanges();
            ResolvePath();
            ResolveArgs(args);
            SilentInstall();*/
        }

        static void ResolveArgs(String[] args)
        {

            Func<String, String, bool, bool, bool> fileTransfer = (src, dest, overwrite, log) =>
            {
                return FileUtils.Transfer(src, dest, overwrite, log);
            };

            bool silent = false;
            foreach (String arg in args)
            {
                if (arg == "--no-output")
                {
                    silent = true;
                }
            }

            foreach (String arg in args)
            {
                if (arg == "--no-output")
                {
                    continue;
                } else if (!arg.StartsWith("--") || !arg.Contains("="))
                {
                    Console.WriteLine("Install failed. Invalid arguments provided.");
                    return;
                } else if (arg.Contains("aic"))
                {
                    continue;
                }
                String srcPath = arg.Split('=')[1];
                String rawOpt = arg.Split('=')[0].Substring(2);
                bool overwrite = false;
                if (rawOpt.Split('-').Length > 1 && rawOpt.Split('-')[1].ToLower().Contains("overwrite"))
                {
                    overwrite = true;
                }
                String opt = rawOpt.Split('-')[0];

                fileTransfer(Path.Combine(Environment.CurrentDirectory, srcPath), Path.GetFullPath(Path.Combine(Configuration.Path, PathUtils.Get(opt))), overwrite, !silent);   
            }
        }

        static void ResolvePath()
        {
            if (!Patcher.CrusaderExists(Configuration.Path))
            {
                if (Patcher.CrusaderExists(Environment.CurrentDirectory))
                {
                    Configuration.Path = Environment.CurrentDirectory;
                }
                else if (Patcher.CrusaderExists(Path.Combine(Environment.CurrentDirectory, "..\\")))
                {
                    Configuration.Path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\"));
                }
            }
        }

        static void SilentInstall()
        {
            Version.Changes.Contains(null);
            Patcher.Install(Configuration.Path, null);
            Console.WriteLine("UCP successfully installed");
            Console.WriteLine("Path to Stronghold Crusader is:" + Configuration.Path);
        }
    }
}
