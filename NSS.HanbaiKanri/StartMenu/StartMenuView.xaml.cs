﻿using NSS.HanbaiKanri.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NSS.HanbaiKanri.StartMenu
{
    /// <summary>
    /// StartMenuView.xaml の相互作用ロジック
    /// </summary>
    public partial class StartMenuView : UserControl, IHanbaiKanriView
    {
        public StartMenuView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int a = 1;
        }
    }
}
