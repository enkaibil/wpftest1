using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample;
using NSS.HanbaiKanri.DataAccess.BusinessEntity.Models.SampleTables;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace NSS.HanbaiKanri.Sample.Models
{
    public class EmployeeListModel : BindableBase
    {

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

        /// <summary>
        /// 初期表示処理
        /// </summary>
        public void InitAction()
        {
            SampleBL bl = new SampleBL();
            List<Sample_M_Shubetsu> result = bl.Init();

            YakushokuList.AddRange(result);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        public void SearchAction()
        {
            SampleBL bl = new SampleBL();
            SampleSearchParam param = new SampleSearchParam();
            param.YakushokuCode = YakushokuCode;
            param.KeyWord = KeyWord;

            param = bl.Search(param);
        }
    }
}
