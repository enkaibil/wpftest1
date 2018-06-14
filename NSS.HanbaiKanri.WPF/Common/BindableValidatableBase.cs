using NSS.HanbaiKanri.WPF.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity = Microsoft.Practices.Unity;

namespace NSS.HanbaiKanri.WPF.Common
{
    public class BindableValidatableBase : BindableBase, INotifyDataErrorInfo
    {
        /// <summary>ダイアログサービス</summary>
        [Unity.Dependency]
        public IDialogService DialogService { get; set; }

        /// <summary>入力エラー管理コンテナ</summary>
        private ErrorsContainer<string> ErrorsContainer { get; }

        #region コンストラクタ
        /// <summary>
        /// BindableValidatableBaseクラスのインスタンスを生成します。
        /// </summary>
        public BindableValidatableBase() : base()
        {
            this.ErrorsContainer = new ErrorsContainer<string>(
                p => this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(p)));
        }
        #endregion

        /// <summary>
        /// プロパティが既に目的の値と一致するかどうかをチェックします。
        /// プロパティを設定し、必要なときだけリスナーに通知します。
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="storage">getterとsetterの両方を持つプロパティへの参照</param>
        /// <param name="value">プロパティの値</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>
        /// 値が変更された場合はtrue、
        /// 既存の値が目的の値と一致する場合はfalse
        /// </returns>
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            // 基底クラスの処理
            if (!base.SetProperty<T>(ref storage, value, propertyName)) return false;

            // 入力値の検証
            ValidateProperty(value, propertyName);

            return true;
        }

        #region ValidateProperties
        /// <summary> 
        /// 全プロパティの検証を行う 
        /// </summary> 
        public void ValidateProperties()
        {
            foreach (var p in this.GetType().GetProperties())
            {
                object value = p.GetValue(this);
                string propertyName = p.Name;

                this.ValidateProperty(value, propertyName);
            }
        }
        #endregion

        #region ValidateProperty
        /// <summary>
        /// プロパティの入力エラー検証を行います。
        /// </summary>
        /// <param name="value">検証値</param>
        /// <param name="propertyName">プロパティ名</param>
        private void ValidateProperty(object value, string propertyName)
        {
            ValidationContext context = new ValidationContext(this) { MemberName = propertyName };
            var errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, errors))
            {
                this.ErrorsContainer.SetErrors(propertyName, errors.Select(x => x.ErrorMessage));
            }
            else
            {
                this.ErrorsContainer.ClearErrors(propertyName);
            }
        }
        #endregion

        #region INotifyDataErrorInfoインターフェースメンバ

        /// <summary>エラー変更通知用イベント</summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>入力エラーの有無</summary>
        public bool HasErrors { get { return ErrorsContainer.HasErrors; } }

        /// <summary>
        /// 指定されたプロパティの検証エラーを取得します。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>エラー情報</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            return this.ErrorsContainer.GetErrors(propertyName);
        }

        #endregion
    }
}
