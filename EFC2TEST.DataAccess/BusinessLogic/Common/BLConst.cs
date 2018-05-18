using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFC2TEST.BusinessLogic.Common
{
    public class BLConst
    {
        public enum BusinessErrorCode
        {
            /// <summary>成功</summary>
            Sucsess = 0,
            /// <summary>SQLタイムアウト</summary>
            /// <remarks>
            /// コネクションタイムアウト、
            /// トランザクションタイムアウト、
            /// コマンドタイムアウト等
            /// </remarks>
            SqlTimeout,
            /// <summary>同時実行(排他)エラー</summary>
            OptimisticError,
            /// <summary>キー重複エラー</summary>
            DuplicateError,
            /// <summary>想定外エラー</summary>
            UnHandle
        }

        /// <summary>
        /// DB更新ステータス
        /// </summary>
        public enum DBState
        {
            /// <summary>変更なし</summary>
            Unchanged,
            /// <summary>追加</summary>
            Added,
            /// <summary>更新</summary>
            Modified,
            /// <summary>削除</summary>
            Deleted
        }

        /// <summary>
        /// SQLエラーコード
        /// </summary>
        public class SqlErrorNumber
        {
            /// <summary>キー重複違反</summary>
            public static int KEY_Duplicate = 2627;
        }
    }
}
