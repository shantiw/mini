﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XData.Windows.Components;

namespace XData.Windows.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FrameworkElement View { get; set; }

        protected void ShowMessage(string message)
        {
            ShowMessageBox.Show(message, View);
        }

        protected void ShowException(Exception exception)
        {
            ShowMessageBox.Show(exception, View);
        }

        public void Dispose()
        {
            if (View != null) // as unmanaged object
            {
                View = null;
            }
        }

        ~ViewModel()
        {
            Dispose();
        }


    }
}
