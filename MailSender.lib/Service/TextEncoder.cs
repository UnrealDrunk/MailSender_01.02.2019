using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Service
{
    public static class TextEncoder
    {
        public static string Encode(this string source, int key = 1)=>
             new string (source.Select(c => (char) (c + key)).ToArray());



        public static string Decode(this string source, int key = 1)=>
            new string(source.Select(c => (char)(c - key)).ToArray());


    }
}
