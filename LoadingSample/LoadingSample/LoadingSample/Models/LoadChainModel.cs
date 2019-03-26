using System;
using LoadingSample.Enums;
using Prism.Mvvm;

namespace LoadingSample.Models
{
    public class LoadChainModel : BindableBase
    {
        public int Id { get; set; }

        private ELoadState _state;
        public ELoadState State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
    }
}
