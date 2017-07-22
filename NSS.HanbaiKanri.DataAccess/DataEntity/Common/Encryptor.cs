using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Common
{
    /// <summary>
    /// AES暗号化処理クラス
    /// </summary>
    public static class Encryptor
    {
        /// <summary>128bit(16byte)AES IV(初期ベクタ)</summary>
        private const string AesIV  = @"ABCDEFGHIJKLMNOP";
        /// <summary>128bit(16byte)AES KEY(暗号化キー)</summary>
        private const string AesKey = @"ZYXWVUTSRQPONMLK";

        /// <summary>
        /// 文字列を暗号化する
        /// </summary>
        /// <param name="value">対象文字列</param>
        /// <returns>暗号文</returns>
        public static string Encrypt(string value)
        {
            string result = string.Empty;

            // AES暗号化サービスプロバイダ
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // 文字列をバイト型配列に変換
            byte[] src = Encoding.Unicode.GetBytes(value);

            // 暗号化する
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // バイト型配列からBase64形式の文字列に変換
                result = Convert.ToBase64String(dest);
            }

            return result;
        }

        /// <summary>
        /// 文字列をAESで復号化
        /// </summary>
        /// <param name="value">対象文字列</param>
        /// <returns>平文</returns>
        public static string Decrypt(string value)
        {
            string result = string.Empty;

            // AES暗号化サービスプロバイダ
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Base64形式の文字列からバイト型配列に変換
            byte[] src = System.Convert.FromBase64String(value);

            // 複号化する
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                result = Encoding.Unicode.GetString(dest);
            }

            return result;
        }
    }
}
