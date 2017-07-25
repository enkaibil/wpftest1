using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models.Sample;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace NSS.HanbaiKanri.Sample.Models
{
    public class EmployeeListModel : BindableBase
    {
        #region プロパティ

        /// <summary>役職一覧</summary>
        public List<Sample_M_Shubetsu> YakushokuList
        {
            get { return _yakushokuList; }
            set { SetProperty(ref _yakushokuList, value); }
        }
        private List<Sample_M_Shubetsu> _yakushokuList = new List<Sample_M_Shubetsu>();

        /// <summary>役職コード選択値</summary>
        public string YakushokuCode
        {
            get { return _yakushokuCode; }
            set { SetProperty(ref _yakushokuCode, value); }
        }
        private string _yakushokuCode = string.Empty;

        /// <summary>キーワード</summary>
        public string KeyWord
        {
            get { return _keyWord; }
            set { SetProperty(ref _keyWord, value); }
        }
        private string _keyWord = string.Empty;

        /// <summary>社員一覧</summary>
        public ObservableCollection<EmployeeList_SearchResult> EmployeeList
        {
            get { return _employeeList; }
            set { SetProperty(ref _employeeList, value); }
        }
        private ObservableCollection<EmployeeList_SearchResult> _employeeList = new ObservableCollection<EmployeeList_SearchResult>();

        /// <summary>選択社員</summary>
        public EmployeeList_SearchResult EmployeeList_SelectedItem
        {
            get { return _employeeList_SelectedItem; }
            set { SetProperty(ref _employeeList_SelectedItem, value); }
        }
        public EmployeeList_SearchResult _employeeList_SelectedItem = new EmployeeList_SearchResult();

        #endregion

        /// <summary>
        /// 初期表示処理
        /// </summary>
        public void InitAction()
        {
            // 役職一覧の取得
            EmployeeList_BL bl = new EmployeeList_BL();
            List<Sample_M_Shubetsu> result = bl.Init();

            // 画面項目にバインド
            YakushokuList.AddRange(result);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        public void SearchAction()
        {
            // データ検索処理
            EmployeeList_BL bl = new EmployeeList_BL();
            SampleSearchParam param = new SampleSearchParam();
            param.YakushokuCode = YakushokuCode;
            param.KeyWord = KeyWord;
            param = bl.Search(param);

            // 画面項目にバンド
            EmployeeList = new ObservableCollection<EmployeeList_SearchResult>(param.ResultData);
        }

        /// <summary>
        /// 選択処理
        /// </summary>
        /// <returns>選択社員番号</returns>
        public string SelectAction()
        {
            EmployeeList_SearchResult value = this.EmployeeList_SelectedItem;
            return value.ShainCode;
        }
    }
}
