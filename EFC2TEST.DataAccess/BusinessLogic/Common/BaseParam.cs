using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EFC2TEST.BusinessLogic.Common.BLConst;

namespace EFC2TEST.BusinessLogic.Common
{
    public class BaseParam
    {
        /// <summary>ビジネスエラーのエラーコード</summary>
        public BLConst.BusinessErrorCode BusinessError { get; set; }

        /// <summary>エラーメッセージ</summary>
        public string Message { get; set; }

        /// <summary>ビジネスエラーのエラー内容</summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// BaseParamクラスのインスタンスを生成します。
        /// </summary>
        public BaseParam()
        {
            this.BusinessError = BLConst.BusinessErrorCode.Sucsess;
        }

        /// <summary>
        /// エラー情報を元にビジネスエラーの判定を行い、エラーコードを格納します。
        /// </summary>
        /// <remarks>
        /// 予期しないエラーの場合、エラーをスローします。
        /// </remarks>
        /// <param name="ex">エラー情報</param>
        /// <returns>エラーコード</returns>
        public BLConst.BusinessErrorCode CheckBusinessError(Exception ex)
        {
            BLConst.BusinessErrorCode result = BLConst.BusinessErrorCode.UnHandle;

            if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == SqlErrorNumber.KEY_Duplicate)
            {
                this.BusinessError = BLConst.BusinessErrorCode.DuplicateError;
                this.Message = "既に登録済みのKEYです。";
            }
            else
            {
                throw ex;
            }

            return result;
        }
    }
}
