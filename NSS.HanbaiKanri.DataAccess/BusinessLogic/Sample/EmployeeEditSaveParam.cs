﻿using NSS.HanbaiKanri.DataAccess.BusinessLogic.Common;
using NSS.HanbaiKanri.DataAccess.DataEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NSS.HanbaiKanri.DataAccess.BusinessLogic.Common.BLConst;

namespace NSS.HanbaiKanri.DataAccess.BusinessLogic.Sample
{
    public class EmployeeEditSaveParam : BaseParam
    {
        /// <summary>登録対象一覧</summary>
        public List<Sample_M_Employee> InsertList { get; set; }

        /// <summary>更新対象対象一覧</summary>
        public List<Sample_M_Employee> UpdateList { get; set; }

        /// <summary>削除対象一覧</summary>
        public List<Sample_M_Employee> DeleteList { get; set; }

        //public List<KeyValuePair<DBState, Sample_M_Employee>> UpdateList { get; set; }
    }
}