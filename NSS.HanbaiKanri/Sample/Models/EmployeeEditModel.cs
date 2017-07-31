using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using System.ComponentModel.DataAnnotations;
using static NSS.HanbaiKanri.DataAccess.BusinessLogic.Common.BLConst;
using System.Windows;

namespace NSS.HanbaiKanri.Sample.Models
{
    /// <summary>
    /// 社員マスタ登録画面用Modelクラス
    /// </summary>
    public class EmployeeEditModel : BindableValidatableBase
    {
        private Sample_M_Employee _employeeInfo;

        #region プロパティ

        /// <summary>新規フラグ</summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { SetProperty(ref _isNew, value); }
        }
        private bool _isNew;

        /// <summary>役職一覧</summary>
        public List<Sample_M_Shubetsu> YakushokuList
        {
            get { return _yakushokuList; }
            set { SetProperty(ref _yakushokuList, value); }
        }
        private List<Sample_M_Shubetsu> _yakushokuList = new List<Sample_M_Shubetsu>();


        /// <summary>社員コード</summary>
        [Required]
        public string ShainCode
        {
            get { return _shainCode; }
            set { SetProperty(ref _shainCode, value); }
        }
        private string _shainCode = string.Empty;

        /// <summary>社員氏名 姓</summary>
        [Required]
        public string ShainName_Sei
        {
            get { return _shainName_Sei; }
            set { SetProperty(ref _shainName_Sei, value); }
        }
        private string _shainName_Sei = string.Empty;

        /// <summary>社員氏名 名</summary>
        [Required]
        public string ShainName_Mei
        {
            get { return _shainName_Mei; }
            set { SetProperty(ref _shainName_Mei, value); }
        }
        private string _shainName_Mei = string.Empty;

        /// <summary>社員氏名(カナ) 姓</summary>
        public string ShainName_Kana_Sei
        {
            get { return _shainName_Kana_Sei; }
            set { SetProperty(ref _shainName_Kana_Sei, value); }
        }
        private string _shainName_Kana_Sei = string.Empty;

        /// <summary>社員氏名(カナ) 名</summary>
        public string ShainName_Kana_Mei
        {
            get { return _shainName_Kana_Mei; }
            set { SetProperty(ref _shainName_Kana_Mei, value); }
        }
        private string _shainName_Kana_Mei = string.Empty;

        /// <summary>年齢</summary>
        public int? Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }
        private int? _age = null;

        /// <summary>給料</summary>
        public decimal? Salary
        {
            get { return _salary; }
            set { SetProperty(ref _salary, value); }
        }
        private decimal? _salary = null;

        /// <summary>入社年月日</summary>
        public DateTime? NyushaDate
        {
            get { return _nyushaDate; }
            set { SetProperty(ref _nyushaDate, value); }
        }
        private DateTime? _nyushaDate = null;

        /// <summary>退職フラグ</summary>
        public bool TaishokuFlg
        {
            get { return _taishokuFlg; }
            set { SetProperty(ref _taishokuFlg, value); }
        }
        private bool _taishokuFlg = false;

        /// <summary>記事</summary>
        public string Kiji
        {
            get { return _kiji; }
            set { SetProperty(ref _kiji, value); }
        }
        private string _kiji = string.Empty;
        #endregion

        /// <summary>
        /// 初期表示処理
        /// </summary>
        public void InitAction(string shainCode)
        {
            //--------------------------------------------------
            // データ取得処理
            //--------------------------------------------------
            EmployeeEdit_BL bl = new EmployeeEdit_BL();
            EmployeeEditInitParam result = bl.Init(shainCode);

            // 取得情報の保持
            _employeeInfo = result.Employee;

            //--------------------------------------------------
            // データバインド
            //--------------------------------------------------
            // 役職一覧
            YakushokuList = result.YakushokuList;

            if(string.IsNullOrEmpty(shainCode))
            {
                // 社員番号のパラメータがない場合、新規フラグを立てる。
                this.IsNew = true;
            }
            else
            {
                // 社員番号が存在する場合、取得データを画面に反映する。
                this.ShainCode = result.Employee.ShainCode;
                this.ShainName_Sei = result.Employee.ShainName_Sei;
                this.ShainName_Mei = result.Employee.ShainName_Mei;
                this.ShainName_Kana_Sei = result.Employee.ShainName_Kana_Sei;
                this.ShainName_Kana_Mei = result.Employee.ShainName_Kana_Mei;
                this.Age = result.Employee.Age;
                this.Salary = result.Employee.Salary;
                this.NyushaDate = result.Employee.NyushaDate;
                this.TaishokuFlg = result.Employee.TaishokuFlg;
                this.Kiji = result.Employee.Kiji;
            }  
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns>結果</returns>
        public bool ValidateInput()
        {
            base.ValidateProperties();

            return !base.HasErrors;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="isDelete">削除フラグ</param>
        public BusinessErrorCode SaveAction(bool isDelete)
        {
            //--------------------------------------------------
            // 画面入力値の取得
            //--------------------------------------------------
            Sample_M_Employee empInfo = (_employeeInfo != null) ? _employeeInfo : new Sample_M_Employee();
            if(this.IsNew) empInfo.ShainCode = this.ShainCode;
            empInfo.ShainName_Sei = this.ShainName_Sei;
            empInfo.ShainName_Mei = this.ShainName_Mei;
            empInfo.ShainName_Kana_Sei = this.ShainName_Kana_Sei;
            empInfo.ShainName_Kana_Mei = this.ShainName_Kana_Mei;
            empInfo.Age = this.Age;
            empInfo.Salary = this.Salary;
            empInfo.NyushaDate = this.NyushaDate;
            empInfo.TaishokuFlg = this.TaishokuFlg;
            empInfo.Kiji = this.Kiji;

            //--------------------------------------------------
            // データ更新処理
            //--------------------------------------------------
            EmployeeEdit_BL bl = new EmployeeEdit_BL();
            EmployeeEditSaveParam param = new EmployeeEditSaveParam();
            if(this.IsNew)
            {
                param.InsertList.Add(empInfo);
            }
            else if(isDelete)
            {
                param.DeleteList.Add(empInfo);
            }
            else
            {
                param.UpdateList.Add(empInfo);
            }

            // 更新実行
            param = bl.Save(param);

            return param.BusinessError;
        }
    }
}
