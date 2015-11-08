using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.SecurityCryptography
{
    public class SecurityProvider
    {
        public static string MD5Encrypt(string content)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string a = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(content)));
            a = a.Replace("-", "");
            return a;
        }

        public static string EncryptSymmetric(string symmetricInstance, string plaintext)
        {
            return Cryptographer.EncryptSymmetric(symmetricInstance, plaintext);
        }

        public static string DecryptSymmetric(string symmetricInstance, string ciphertextBase64)
        {
            return Cryptographer.DecryptSymmetric(symmetricInstance, ciphertextBase64);
        }

        //public static bool CompareHash(string hashInstance, byte[] plaintext, byte[] hashedText)
        //{
        //    return Cryptographer.CompareHash(hashInstance, plaintext, hashedText);
        //}
        //public static bool CompareHash(string hashInstance, string plaintext, string hashedText)
        //{
        //    return Cryptographer.CompareHash(hashInstance, plaintext, hashedText);
        //}
        //public static byte[] CreateHash(string hashInstance, byte[] plaintext)
        //{
        //    return Cryptographer.CreateHash(hashInstance, plaintext);
        //}
        //public static string CreateHash(string hashInstance, string plaintext)
        //{
        //    return Cryptographer.CreateHash(hashInstance, plaintext);
        //}
        //public static byte[] DecryptSymmetric(string symmetricInstance, byte[] ciphertext)
        //{
        //    return Cryptographer.DecryptSymmetric(symmetricInstance, ciphertext);
        //}
        //public static byte[] EncryptSymmetric(string symmetricInstance, byte[] plaintext)
        //{
        //    return Cryptographer.EncryptSymmetric(symmetricInstance, plaintext);
        //}
    }
}
