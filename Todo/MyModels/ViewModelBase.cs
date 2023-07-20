using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Todo.MyModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 紀錄資料所屬畫面，例如:UI_UserList
        /// </summary>
        private string _Category;
        public string Category
        {
            get { return _Category; }
            set
            {
                if (value == _Category)
                    return;

                _Category = value;
            }
        }

        #region 擴充欄位

        private bool _isnew;
        [JsonIgnore]
        public bool isnew
        {
            get { return _isnew; }
            set
            {
                if (value == _isnew)
                    return;

                _isnew = value;
                OnPropertyChanged("isnew");
            }
        }


        private bool _ismodified = false;
        [JsonIgnore]
        public bool ismodified
        {
            get { return _ismodified; }
            set
            {
                if (value == _ismodified)
                    return;

                _ismodified = value;
                OnPropertyChanged("ismodified");
            }
        }



        private bool _isreadonly = false;
        [JsonIgnore]
        public bool isreadonly
        {
            get { return _isreadonly; }
            set
            {
                if (value == _isreadonly)
                    return;

                _isreadonly = value;
                OnPropertyChanged("isreadonly");
            }
        }

        private bool _IsChecked = false;
        [JsonIgnore]
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (value == _IsChecked)
                    return;

                _IsChecked = value;
            }
        }


        #endregion

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        /// <summary>
        /// Sets property if it does not equal existing value. Notifies listeners if change occurs.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="member">The property's backing field.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual bool SetProperty<T>(ref T member, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(member, value))
            {
                return false;
            }

            member = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property, used to notify listeners.</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // Validate the property name in debug builds
            VerifyProperty(propertyName);
            if (propertyName == "ismodified" || propertyName == "isreadonly" || propertyName == "isnew") return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ismodified = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ismodified"));
        }

        /// <summary>
        /// Verifies whether the current class provides a property with a given
        /// name. This method is only invoked in debug builds, and results in
        /// a runtime exception if the <see cref="OnPropertyChanged"/> method
        /// is being invoked with an invalid property name. This may happen if
        /// a property's name was changed but not the parameter of the property's
        /// invocation of <see cref="OnPropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            Type type = this.GetType();

            // Look for a *public* property with the specified name
            System.Reflection.PropertyInfo pi = type.GetProperty(propertyName);
            if (pi == null)
            {
                // There is no matching property - notify the developer
                string msg = "OnPropertyChanged was invoked with invalid " +
                                "property name {0}. {0} is not a public " +
                                "property of {1}.";
                msg = String.Format(msg, propertyName, type.FullName);
                System.Diagnostics.Debug.Fail(msg);
            }
        }
    }
}
