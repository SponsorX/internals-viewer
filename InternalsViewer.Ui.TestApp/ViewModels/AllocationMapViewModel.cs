using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Ui.TestApp.Models;
using Prism.Mvvm;

namespace InternalsViewer.Ui.TestApp.ViewModels
{
    public class AllocationMapViewModel : BindableBase
    {
        public AllocationMapViewModel()
        {
            ScrollMaximum = 100;
        }

        private int scrollValue;
        private int scrollMaximum;
        private AllocationLayers allocationLayers;

        public int ScrollValue
        {
            get => scrollValue;
            set
            {
                scrollValue = value;
                RaisePropertyChanged();
            }
        }

        public int ScrollMaximum
        {
            get => scrollMaximum;
            set
            {
                scrollMaximum = value;
                RaisePropertyChanged();
            }
        }

        public AllocationLayers AllocationLayers
        {
            get => allocationLayers;
            set
            {
                allocationLayers = value;
                RaisePropertyChanged();
            }
        }
    }
}
