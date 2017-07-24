using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using System.ComponentModel.DataAnnotations;

namespace NSS.HanbaiKanri.Sample.Models
{
    /// <summary>
    /// 社員マスタ登録画面用Modelクラス
    /// </summary>
    public class EmployeeEditModel : BindableValidatableBase
    {
        #region プロパティ

        /// <summary>役職一覧</summary>
        public List<Sample_M_Shubetsu> YakushokuList
        {
            get { return _yakushokuList; }
            set { SetProperty(ref _yakushokuList, value); }
        }
        private List<Sample_M_Shubetsu> _yakushokuList = new List<Sample_M_Shubetsu>();

        private Sample_M_Employee _employeeInfo;

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

            if (!string.IsNullOrEmpty(shainCode))
            {
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
    }
}
