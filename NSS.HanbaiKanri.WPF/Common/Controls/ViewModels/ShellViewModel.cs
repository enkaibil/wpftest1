﻿using Microsoft.Practices.Unity;
using NSS.HanbaiKanri.WPF.Common.Models;
using NSS.HanbaiKanri.WPF.StartMenu.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.WPF.Common.Controls.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "BLANK"; } }

        /// <summary>ヘッダー情報</summary>
        public HeaderInfoModel HeaderInfo
        {
            get { return _headerInfo; }
            set { SetProperty(ref _headerInfo, value); }
        }
        private HeaderInfoModel _headerInfo;

        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_Form_Closing { get; }
        public DelegateCommand CMD_btnBack_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShellViewModel()
        {
            // イベント定義
            CMD_Form_Loaded = new DelegateCommand(From_Loaded);
            CMD_Form_Closing = new DelegateCommand(Form_Closing);
            CMD_btnBack_Click = new DelegateCommand(btnBack_Click);
        }

        /// <summary>
        /// 画面初期表示イベント
        /// </summary>
        public void From_Loaded()
        {
            // Model初期化
            HeaderInfo = new HeaderInfoModel(EventAggregator);

            this.RequestNavigate<SystemMenuView>();
            //this.RegionManager.RegisterViewWithRegion("main", typeof(SystemMenuView));
        }

        /// <summary>
        /// 戻るボタンクリックイベント
        /// </summary>
        public void btnBack_Click()
        {
            // バックボタンが押された場合
            BackButtonClickPubSubEvent.Publish(this.EventAggregator);
        }

        /// <summary>
        /// 画面終了時イベント
        /// </summary>
        public void Form_Closing()
        {
        }
    }
}
