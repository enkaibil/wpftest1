﻿using Microsoft.Practices.Unity;
using NSS.HanbaiKanri.Common.Models;
using NSS.HanbaiKanri.StartMenu;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.Common
{
    public class ShellViewModel : BaseViewModel
    {
        public HeaderInfoModel HeaderInfo
        {
            get { return _headerInfo; }
            set { SetProperty(ref _headerInfo, value); }
        }
        private HeaderInfoModel _headerInfo;

        /// <summary>ウィンドウタイトル</summary>
        public override string Title { get { return "BLANK"; } }

        public DelegateCommand CMD_Form_Loaded { get; }
        public DelegateCommand CMD_btnBack_Click { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShellViewModel()
        {
            // イベント定義
            CMD_Form_Loaded = new DelegateCommand(From_Loaded);
            CMD_btnBack_Click = new DelegateCommand(btnBack_Click);

        }

        /// <summary>
        /// 画面初期表示イベント
        /// </summary>
        public void From_Loaded()
        {
            // Model初期化
            HeaderInfo = new HeaderInfoModel(EventAggregator);

            this.RegionManager.RequestNavigate("main", nameof(StartMenuView));
        }

        /// <summary>
        /// 戻るボタンクリックイベント
        /// </summary>
        public void btnBack_Click()
        {
            // バックボタンが押された場合
            BackButtonClickPubSubEvent.Publish(this.EventAggregator);
        }
    }
}
