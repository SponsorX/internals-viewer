using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Allocations;

namespace InternalsViewer.Ui.TestApp.Models
{
    public class AllocationLayers
    {
        public ObservableCollection<AllocationMap> Allocations { get; set; } = new ObservableCollection<AllocationMap>();
    }
}
