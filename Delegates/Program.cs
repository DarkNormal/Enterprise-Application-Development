using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate string cipherDel(string message);
    class Program
    {
        static void Main(string[] args)
        {
            cipherDel caesar = new cipherDel(Cipher.encrypt);
            Console.WriteLine(caesar("Hello Darkness My Old Friend"));

            cipherDel reverse = new cipherDel(Cipher.reverse);
            Console.WriteLine(reverse("Hello Darkness My Old Friend"));
            Console.ReadLine();


        }
    }
    public class Cipher
    {
        public static string encrypt(string message)
        {
            message.ToLower();
            message = message.Replace(" ", string.Empty);
            char[] buffer = message.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                // Letter.
                char letter = buffer[i];
                letter++;
                // Store.
                buffer[i] = letter;
            }
            return new string(buffer);
        }
        public static string reverse(string message)
        {
            char[] reversed = message.ToCharArray();
            Array.Reverse(reversed);
            return new string(reversed);
        }
    }
}
