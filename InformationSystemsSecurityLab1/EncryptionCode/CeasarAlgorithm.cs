namespace InformationSystemsSecurityLab1.EncryptionCode
{
    public class CeasarAlgorithm
    {
        public static string Encrypt(string input, int key)
        {
            char charKey = (char)key;
            char[] letters = input.ToCharArray();
            for(int i = 0; i < letters.Length; i++)
            {
                letters[i] += charKey;
            }
            return new string(letters);
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
    }
}
