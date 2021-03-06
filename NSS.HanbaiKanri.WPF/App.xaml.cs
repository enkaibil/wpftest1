﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using NSS.HanbaiKanri.WPF.Common.Models;

namespace NSS.HanbaiKanri.WPF
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// スタートアップ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Bootstrapperを起動する
            new Bootstrapper().Run();
        }

        /// <summary>
        /// 集約エラーハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Application_DispatcherUnhandledException(
            object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            // ログ出力

            // エラーメッセージ
            new DialogService().ShowError(e.Exception);
            e.Handled = true;

            // アプリ終了
            Environment.Exit(-1);
        }
    }
}