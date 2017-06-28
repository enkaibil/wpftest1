﻿using NSS.HanbaiKanri.Common;
using NSS.HanbaiKanri.Common.Models;
using NSS.HanbaiKanri.MasterMeinte.Views;
using NSS.HanbaiKanri.DataAccess.BusinessLogic.StartMenu;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NSS.HanbaiKanri.StartMenu.ViewModels
{
    public class StartMenuViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "スタートメニュー"; } }

        public DelegateCommand CMD_btnBack_Click { get; }
        public DelegateCommand CMD_btnMMEmp_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StartMenuViewModel() : base()
        {
            CMD_btnMMEmp_Click = new DelegateCommand(btnMMEmp_Click);
            CMD_btnBack_Click = new DelegateCommand(OnBackButtonClick);
        }

        /// <summary>
        /// 戻るボタンイベントのオーバーライド
        /// </summary>
        protected override void OnBackButtonClick()
        {
            // アプリを終了する。
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 画面に遷移してきたときに呼び出されるメソッド
        /// </summary>
        /// <param name="navigationContext">引数</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 基底クラスの処理
            base.OnNavigatedTo(navigationContext);

            StartMenuBL bl = new StartMenuBL();

            var result = bl.Initialize();

            foreach (var i in result)
            {
                string value = i.Name;
            }
        }

        /// <summary>
        /// 社員マスタボタン押下イベント
        /// </summary>
        private void btnMMEmp_Click()
        {
            this.RequestNavigate<EmployeeView>();
        }

    }
}
