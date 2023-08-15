using OpenMahjong;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
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
        public ReadOnlyReactiveCollection<PaiT> Tehai { get; }

        public MainWindowViewModel()
        {
            ResetCommand = new DelegateCommand(Reset);

            Tehai = GameEngine.Instance.Tehai.ToReadOnlyReactiveCollection();
        }


        public void Reset()
        {
            GameEngine.Instance.Reset();
        }
    }
}
