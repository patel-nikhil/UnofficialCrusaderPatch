using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UCP
{
    public class AOB
    {
        public static Dictionary<string, AOB> AOBList = new Dictionary<string, AOB>();

        public ByteOrWildCard[] Elements { get; }
        public int? Address { get; set; }

        public AOB(string codeBlockName)
        {
            AOBList.Add(codeBlockName, this);
            this.Address = null;
            Assembly asm = Assembly.GetExecutingAssembly();

            // check if code block file is there
            string file = string.Format("UCP.CodeBlocks.{0}.block", codeBlockName);
            if (!asm.GetManifestResourceNames().Contains(file))
                throw new Exception("MISSING BLOCK FILE " + file);

            string codeBlockContent;
            // read code block file
            using (Stream stream = asm.GetManifestResourceStream(file))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    codeBlockContent = reader.ReadToEnd();
                }
            }

            if (codeBlockContent.Length % 3 != 2)
            {
                throw new Exception();
            }
            Elements = new ByteOrWildCard[codeBlockContent.Length / 3 + 1];

            var index = 0;
            for (var i = 0; i <= codeBlockContent.Length - 2; i+=3, index++)
            {
                ByteOrWildCard elem;
                try
                {
                    elem = hexToByte(codeBlockContent.Substring(i, 2));
                }
                catch (InvalidCastException)
                {
                    throw new Exception("Invalid codeblock " + codeBlockName);
                }
                    
                if (i != codeBlockContent.Length - 2)
                {
                    if (codeBlockContent[i+2] != ' ')
                    {
                        throw new Exception("Invalid codeblock " + codeBlockName);
                    }
                }
                Elements[index] = elem;
            }
        }

        internal void SetAddress(byte[] data)
        {
            if (this.Address == null)
            {
                KMP kmp = new KMP(this.Elements);
                this.Address = kmp.findFirstInstance(data); // SHC data byte array
            }
            if (this.Address == -1)
            {
                throw new Exception();
            }
        }

        public ByteOrWildCard hexToByte(string hexString)
        {
            if (hexString[0] == '?' && hexString[1] == '?')
            {
                return new ByteOrWildCard(WildCard.Instance);
            }
            return new ByteOrWildCard((byte)int.Parse(hexString, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
