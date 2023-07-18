using Todo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.MyModels
{
    public class GlobalData
    {
        public static string ApiToken { get; set; }
        public static string LoginUserId { get; set; }
        public static UserModel LoginUser { get; set; }

        private static string _CurrentLanguageCode = "";
        public static string CurrentLanguageCode {
            get
            {
                return _CurrentLanguageCode;
            } 
            
            set
            {
                _CurrentLanguageCode = value;
            }
        }

        //private static string _FactoryId = "";
        //public static string FactoryId
        //{
        //    get { return _FactoryId; }
        //    set
        //    {
        //        if (value == _FactoryId)
        //            return;

        //        _FactoryId = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<int>> _AllGenders;
        //public static ObservableCollection<CommonProperty<int>> AllGenders
        //{
        //    get { return _AllGenders; }
        //    set
        //    {
        //        if (value == _AllGenders)
        //            return;

        //        _AllGenders = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<string>> _AllLanguages;
        //public static ObservableCollection<CommonProperty<string>> AllLanguages
        //{
        //    get { return _AllLanguages; }
        //    set
        //    {
        //        if (value == _AllLanguages)
        //            return;

        //        _AllLanguages = value;
        //    }
        //}


        //private static ObservableCollection<CommonProperty<int>> _SysOrManual;
        //public static ObservableCollection<CommonProperty<int>> SysOrManual
        //{
        //    get { return _SysOrManual; }
        //    set
        //    {
        //        if (value == _SysOrManual)
        //            return;

        //        _SysOrManual = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<int>> _SysExecable;
        //public static ObservableCollection<CommonProperty<int>> SysExecable
        //{
        //    get { return _SysExecable; }
        //    set
        //    {
        //        if (value == _SysExecable)
        //            return;

        //        _SysExecable = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<int>> _CTinterval_unit;
        //public static ObservableCollection<CommonProperty<int>> CTinterval_unit
        //{
        //    get { return _CTinterval_unit; }
        //    set
        //    {
        //        if (value == _CTinterval_unit)
        //            return;

        //        _CTinterval_unit = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<int>> _CTopstatus;
        //public static ObservableCollection<CommonProperty<int>> CTopstatus
        //{
        //    get { return _CTopstatus; }
        //    set
        //    {
        //        if (value == _CTopstatus)
        //            return;

        //        _CTopstatus = value;
        //    }
        //}

        //private static ObservableCollection<CommonProperty<int>> _CTcstatus;
        //public static ObservableCollection<CommonProperty<int>> CTcstatus
        //{
        //    get { return _CTcstatus; }
        //    set
        //    {
        //        if (value == _CTcstatus)
        //            return;

        //        _CTcstatus = value;
        //    }
        //}

        //private static List<CommonProperty> _AllDepts;
        //public static List<CommonProperty> AllDepts
        //{
        //    get { return _AllDepts; }
        //    set
        //    {
        //        if (value == _AllDepts)
        //            return;

        //        _AllDepts = value;
        //    }
        //}

        //private static ObservableCollection<CommonBoolProperty> _AllPrintState;
        //public static ObservableCollection<CommonBoolProperty> AllPrintState
        //{
        //    get { return _AllPrintState; }
        //    set
        //    {
        //        if (value == _AllPrintState)
        //            return;

        //        _AllPrintState = value;
        //    }
        //}


        //private static List<lc_com_permission_button> _MyButtonPermission = new List<lc_com_permission_button>();
        //public static List<lc_com_permission_button> MyButtonPermission
        //{
        //    get { return _MyButtonPermission; }
        //    set
        //    {
        //        if (value == _MyButtonPermission)
        //            return;

        //        _MyButtonPermission = value;
        //    }
        //}

        //private static List<srw_adm_account_perm> _SRAWButtonPermission = new List<srw_adm_account_perm>();
        //public static List<srw_adm_account_perm> SRAWButtonPermission
        //{
        //    get { return _SRAWButtonPermission; }
        //    set
        //    {
        //        if (value == _SRAWButtonPermission)
        //            return;

        //        _SRAWButtonPermission = value;
        //    }
        //}
    }
}
