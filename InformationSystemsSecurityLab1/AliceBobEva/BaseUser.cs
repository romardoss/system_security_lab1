using InformationSystemsSecurityLab1.EncryptionCode;

namespace InformationSystemsSecurityLab1.AliceBobEva
{
    internal abstract class BaseUser
    {
        public string Name { get; }
        public string Message { get; }
        public int Key { get; set; }

        public string SendMessage()
        {
            string ecryptedMessage = CeasarAlgorithm.Encrypt(Message, Key);
            return ecryptedMessage;
        }

        public string ReceiveMessage(string message)
        {
            string decryptedMessage = CeasarAlgorithm.Decrypt(message, Key);
            return decryptedMessage;
        }

        public abstract void SetKey(BaseUser user = null);
    }
}
