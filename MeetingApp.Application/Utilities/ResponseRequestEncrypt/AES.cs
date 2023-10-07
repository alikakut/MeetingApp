using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Utilities.ResponseRequestEncrypt
{
    public static class AES
    {
        private static byte[] keybytes = Encoding.UTF8.GetBytes(AESConstant.KeyBytes);
        private static byte[] iv = Encoding.UTF8.GetBytes(AESConstant.Iv);

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            CheckPlainTextArguments(plainText, Key, IV);

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.FeedbackSize = 128;
                aesAlg.KeySize = 256;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private static void CheckPlainTextArguments(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            CheckCipherTextArguments(cipherText, Key, IV);

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                // aesAlg.FeedbackSize = 128;
                aesAlg.KeySize = 256;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd().ToString();
                        }
                    }
                }
            }

            return plaintext;
        }

        private static void CheckCipherTextArguments(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
        }

        public static string DecryptStringAES(string cipherText)
        {
            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes_Aes(encrypted, keybytes, iv);
            return decriptedFromJavascript;
        }

        public static string EncryptStringAES(string text)
        {
            var decriptedFromJavascript = EncryptStringToBytes_Aes(text, keybytes, iv);
            var encrypted = Convert.ToBase64String(decriptedFromJavascript, 0, decriptedFromJavascript.Length);
            byte[] convertedByte = Encoding.Unicode.GetBytes(encrypted);

            string hex = BitConverter.ToString(decriptedFromJavascript, 0, decriptedFromJavascript.Length);
            hex = hex.Replace("-", "").ToLower();
            return hex;
        }

        public static string DecryptStringAESForRestClientResponse(string cipherText)
        {
            byte[] bytes = Enumerable.Range(0, cipherText.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(cipherText.Substring(x, 2), 16))
                     .ToArray();
            var sBse64 = Convert.ToBase64String(bytes);
            return DecryptStringAES(sBse64);
        }
    }
}
