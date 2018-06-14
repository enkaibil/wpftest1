using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSS.HanbaiKanri.WPF.Common
{
    /// <summary>
    /// 定数クラス
    /// </summary>
    public class SystemConst
    {
        /// <summary>システム名</summary>
        public const string SystemTitle = "販売管理システム";

        public static GlobalProperties Global { get; set; } = new GlobalProperties();
    }

    public class GlobalProperties
    {
        public System.Windows.Window ActiveWindow { get; set; }
    }
}
