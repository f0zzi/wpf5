using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using wpf5.Model;
using wpf5.ViewModel.Commands;
using wpf5.ViewModel.Helpers;

namespace wpf5.ViewModel
{
    class CovidVM : INotifyPropertyChanged
    {
        public GetCommand getCommand { get; set; }
        private Place selectedCountry;
        private Global global;
        public ObservableCollection<Place> Countries { get; set; }
        public CovidVM()
        {
            getCommand = new GetCommand(this);
            Countries = new ObservableCollection<Place>();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                selectedCountry = new Place();
                global = new Global();
            }
        }

        public Global Global
        {
            get { return global; }
            set
            {
                global = value;
                NotifyPropertyChanged();
            }
        }
        public Place SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                NotifyPropertyChanged();
            }
        }

        public async void MakeRequest()
        {
            Info info = await CovidHelper.GetInfo();
            Global = info.Global;
            Countries.Clear();
            foreach (var item in info.Countries)
            {
                Countries.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
