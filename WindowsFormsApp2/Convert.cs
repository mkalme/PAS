using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    class Convert
    {
        private static String[] array = { "2znH", "3Rm7", "xXaT", "fR,B", "A7g(", "V0_5", "r~do", "9Mmu", "9~ly", "hs#~", "ow5=", "I}[)", "dN!!", "jS #", "B[S4", "m{}Q",
            "ij9g", "d2WK", "5h9^", "xEnt", "GZ,l", "Kl,h", "}i].", "Fn3r", "yfT]", "esIT", "uYm#", "8G){", "k]o4", "p2&{", "_Shx", "VK%H", "VIc4", "n31R", "3Zuo", "})Q[",
            "a`Eh", "~}!j", "`V}4", ",O{P", "UJOq", "bu.Z", "NB 7", ";7}U", "!.;u", "&AIX", "GwV;", "5zGf", "]K@X", "^_wj", "Si=a", "{kRK", "WL3}", "3'J6", "!tPi", "DrHQ",
            "x=[p", "xJuF", "5RH@", "!fZZ", "K,dj", "jITV", " 'Wg", "10K_", "Glgc", "1`P.", "Unjc", "c+4=", "@sD6", "1]eU", "h&or", "q04%", "(hw5", "~vLi", "_W7y", "^oru",
            "r;M=", "n4Oi", "(4x)", "n]@G", "[e[y", "3}@G", "MYX[", "Giuv", "4x Y", "ew7s", ";1-l", "{Cx!", ";rDv", "6wds", "}&o6", "]rGB", "@#tt", "]dac", "Pfa!"};

        private static String index = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        public static String turnTo(String text) {
            String newText = "";

            for (int i = 0; i < text.Length; i++) {
                newText += array[findIndex(text[i])];
            }

            return newText;
        }

        public static String turnFrom(string text) {
            String newText = "";

            for (int i = 0; i < text.Length; i += 4)
            {
                int number = 0;
                char[]temp = { text[i], text[i + 1], text[i + 2], text[i + 3] };
                for (int b = 0; b < array.Length; b++) {
                    if (new string(temp).Equals(array[b])) {
                        number = b;
                        b = array.Length;
                        break;
                    }
                }
                newText += index[number];
            }

            return newText;
        }

        public static int findIndex(char c) {
            int num = 0;

            for (int i = 0; i < index.Length; i++) {
                if (index[i].Equals(c)) {
                    num = i;

                    i = index.Length;
                    break;
                }
            }

            return num;
        }

        public static String Random(int num, String exclude, Random random) {
            String text = "";
            String ascii = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            
            for (int i = 0; i < exclude.Length; i++) {
                ascii = ascii.Replace(exclude[i].ToString(), "");
            }
            for (int i = 0; i < num; i++) {
                text += ascii[random.Next(0, ascii.Length)];
            }

            return text;
        }
    }
}
