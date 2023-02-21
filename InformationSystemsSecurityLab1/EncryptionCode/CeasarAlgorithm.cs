using System.Windows;
using System;

namespace InformationSystemsSecurityLab1.EncryptionCode
{
    public class CeasarAlgorithm
    {
        public static string Encrypt(string input, string key)
        {
            try
            {
                char charKey = (char)ValidateKey(key);
                char[] letters = input.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    letters[i] += charKey;
                }
                return new string(letters);
            }
            catch (Exception) { }
            return input;
            
        }

        public static string Encrypt(string input, int key)
        {
            char charKey = (char)key;
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] += charKey;
            }
            return new string(letters);

        }

        public static string Decrypt(string input, string key)
        {
            try
            {
                char charKey = (char)ValidateKey(key);
                char[] letters = input.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    letters[i] -= charKey;
                }
                return new string(letters);
            }
            catch (Exception) { }
            return input;
        }

        public static string Decrypt(string input, int key)
        {
            char charKey = (char)key;
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] -= charKey;
            }
            return new string(letters);
        }

        private static int ValidateKey(string key)
        {
            if (int.TryParse(key, out int answer))
            {
                return answer;
            }
            else
            {
                MessageBox.Show("Key must be a number");
                throw new Exception();
            }
        }
    }
}
