using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf5.ViewModel.Commands
{
    class GetCommand : ICommand
    {
        public CovidVM CovidVM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public GetCommand(CovidVM covidVM)
        {
            CovidVM = covidVM;
        }

        public void Execute(object parameter)
        {
            CovidVM.MakeRequest();
        }
    }
}
