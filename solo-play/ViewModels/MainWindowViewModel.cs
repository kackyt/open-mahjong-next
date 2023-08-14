using Prism.Commands;
using Prism.Mvvm;
using solo_play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace solo_play.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand ResetCommand { get; }

        public MainWindowViewModel()
        {
            ResetCommand = new DelegateCommand(Reset);
        }


        public void Reset()
        {
            GameEngine.Instance.Reset();
        }
    }
}
