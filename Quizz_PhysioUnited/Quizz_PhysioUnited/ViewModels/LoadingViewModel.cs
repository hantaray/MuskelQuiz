using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Quizz_PhysioUnited.ViewModels
{
    class LoadingViewModel : INotifyPropertyChanged
    {

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }



    }
}
