using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2TEST.DataAccess.DataEntity.Models
{
    /// <summary>
    /// ��ʋ敪
    /// </summary>
    public class ShubetsuKbn
    {
        /// <summary>��E</summary>
        public const int Yakushoku = 1;
    }

    /// <summary>
    /// �T���v���R�[�h�}�X�^���f���N���X
    /// </summary>
    public class Sample_M_Shubetsu
    {
        /// <summary>�敪</summary>
        //[Key][Column(Order =0)]
        public int KBN { get; set; }
        /// <summary>�R�[�h</summary>
        //[Key][Column(Order = 1)]
        public string Code { get; set; }
        /// <summary>����</summary>
        public string Name { get; set; }
        /// <summary>���я�</summary>
        public int Sort { get; set; }
        /// <summary>�L��</summary>
        public string Kiji { get; set; }

        /// <summary>�I�v�e�B�~�X�g</summary>
        [Timestamp]
        public byte[] Optimist { get; set; }
        /// <summary>���͎�</summary>
        public string InputUser { get; set; }
        /// <summary>���͓���</summary>
        public DateTime InputDate { get; set; }
        /// <summary>�X�V��</summary>
        public string UpdateUser { get; set; }
        /// <summary>�X�V����</summary>
        public DateTime UpdateDate { get; set; }
    }
}
