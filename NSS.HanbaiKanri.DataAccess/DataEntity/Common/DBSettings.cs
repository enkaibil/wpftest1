﻿using Dapper;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NSS.HanbaiKanri.DataAccess.DataEntity.Common
{
    public class DBSettings
    {
        #region 定数定義

        private static Dictionary<SettingID, string> _values;

        /// <summary>
        /// セッティングテーブルID定数
        /// </summary>
        public enum SettingID
        {
            /// <summary>接続文字列</summary>
            HanbaiConStr = 1
        }

        /// <summary>
        /// 暗号化タイプ
        /// </summary>
        private enum EncryptType
        {
            /// <summary>平文</summary>
            Plain = 0,
            /// <summary>暗号文</summary>
            Encrypt = 1,
            /// <summary>次回アクセス時に暗号化</summary>
            WaitEncrypt = 2,
            /// <summary>次回アクセス時に復号化</summary>
            WaitDecrypt = 3

        }

        #endregion

        /// <summary>接続文字列</summary>
        public static Dictionary<SettingID, string> Values
        {
            get
            {
                if (_values == null || _values.Count == 0) Load();

                return _values;
            }
            private set { _values = value; }
        }

        //===========================================================================================
        /// <summary>
        /// ＤＢから設定情報を読み込みます。
        /// </summary>
        //===========================================================================================
        public static void Load()
        {
            _values = new Dictionary<SettingID, string>();

            using (SettingDbContext db = new SettingDbContext())
            {
                List<Settings> settings = (from row in db.Settings select row).ToList();

                foreach (Settings s in settings)
                {
                    // 設定値の取得
                    SettingID id = (SettingID)s.ID;
                    string value = GetValue(s);

                    // 設定値の保持
                    _values.Add(id, value);

                    // 暗号化・復号化待ちがある場合、変換してＤＢを更新する。
                    UpdateSettingValue(db, s);
                }
            }
        }

        //===========================================================================================
        /// <summary>
        /// 設定情報から値を取得します。
        /// </summary>
        /// <param name="s">設定情報</param>
        /// <returns>設定値</returns>
        //===========================================================================================
        private static string GetValue(Settings s)
        {
            string result = string.Empty;

            EncryptType encrypt = (EncryptType)s.Encrypt;
            switch(encrypt)
            {
                case EncryptType.Encrypt:
                case EncryptType.WaitDecrypt:
                    // 復号化する。
                    result = Encryptor.Decrypt(s.Value);
                    break;
                default:
                    // その他の場合、平文のためそのまま取得。
                    result = s.Value;
                    break;
            }

            return result;
        }


        //===========================================================================================
        /// <summary>
        /// 暗号化・復号化待ちがある場合、変換してＤＢを更新する。
        /// </summary>
        /// <param name="db">DBコンテキスト</param>
        /// <param name="s">設定レコード</param>
        //===========================================================================================
        private static void UpdateSettingValue(SettingDbContext db, Settings s)
        {
            EncryptType encrypt = (EncryptType)s.Encrypt;

            // 暗号化・復号化待ちがある場合、変換してＤＢを更新する。
            if (encrypt == EncryptType.WaitEncrypt || encrypt == EncryptType.WaitDecrypt)
            {
                if (encrypt == EncryptType.WaitEncrypt)
                {
                    s.Encrypt = (int)EncryptType.Encrypt;
                    s.Value = Encryptor.Encrypt(s.Value);
                }
                else if (encrypt == EncryptType.WaitDecrypt)
                {
                    s.Encrypt = (int)EncryptType.Plain;
                    s.Value = Encryptor.Decrypt(s.Value);
                }

                // SQL文生成
                StringBuilder sql = new StringBuilder();
                sql.AppendLine($"UPDATE {nameof(Settings)} ");
                sql.AppendLine(" SET ");
                sql.AppendFormat("{0} = @{0}, ", nameof(s.Encrypt)).AppendLine();
                sql.AppendFormat("{0} = @{0} ", nameof(s.Value)).AppendLine();
                sql.AppendLine(" WHERE ");
                sql.AppendFormat("{0} = @{0} ", nameof(s.ID)).AppendLine();

                // パラメータ生成
                var param = new { s.Encrypt, s.Value, s.ID };

                // クエリ実行
                DbConnection conn = db.Database.GetDbConnection();
                conn.Execute(sql.ToString(), param);
            }
        }
    }
}
