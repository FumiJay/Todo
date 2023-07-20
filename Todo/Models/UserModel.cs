using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.MyModels;

namespace Todo.Models
{
    public class UserModel : ViewModelBase
    {
        public string ApiToken { get; set; }
        public string LoginUserId { get; set; }
        public UserModel LoginUser { get; set; }
        public string accountid { get; set; } = "1";
        public string passwd { get; set; } = "2";
        public string name { get; set; }
        public string nickname { get; set; }
        public string language { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string picture { get; set; }
        public string title { get; set; }
        public string manager { get; set; }
        public bool? isadmin { get; set; }
        public DateTime? takeoffdate { get; set; }
        public string classtype { get; set; }
        public int gender { get; set; }
        public DateTime? createtime { get; set; }
        public DateTime? updatetime { get; set; }
        public string creator { get; set; }
        public string updator { get; set; }
        public bool? actived { get; set; }
        public string shiftid { get; set; }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value == _isBusy)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
    }
}
