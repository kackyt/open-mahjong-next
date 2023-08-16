using OpenMahjong;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;
using solo_play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace solo_play.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDisposable
    {
        public CompositeDisposable disposables = new();
        public ReadOnlyReactiveCollection<PaiT> Kawahai { get; }
        public ReadOnlyReactiveCollection<PaiT> Tehai { get; }
        public ReadOnlyReactivePropertySlim<PaiT> Tsumohai { get; }
        public ReadOnlyReactivePropertySlim<int> Shanten { get; }
        public ReadOnlyReactivePropertySlim<bool> CanAgari { get; }

        public ReactiveCommand AgariCommand { get; }
        public DelegateCommand ResetCommand { get; }
        public DelegateCommand<int?> SutehaiCommand { get; }

        public MainWindowViewModel()
        {
            Tehai = MahjongEngine.Instance.Tehai.ToReadOnlyReactiveCollection();
            Kawahai = MahjongEngine.Instance.Kawahai.ToReadOnlyReactiveCollection();
            Tsumohai = MahjongEngine.Instance.Tsumohai.ToReadOnlyReactivePropertySlim(new PaiT());
            Shanten = MahjongEngine.Instance.Shanten.ToReadOnlyReactivePropertySlim(99);
            CanAgari = MahjongEngine.Instance.Shanten.Select(s => s < 0).ToReadOnlyReactivePropertySlim();

            ResetCommand = new DelegateCommand(Reset);
            SutehaiCommand = new DelegateCommand<int?>(Sutehai);
            AgariCommand = CanAgari.ToReactiveCommand().WithSubscribe(() => Agari()).AddTo(disposables);
        }


        public void Reset()
        {
            MahjongEngine.Instance.Reset();
        }

        public void Sutehai(int? index)
        {
            if (index.HasValue)
            {
                MahjongEngine.Instance.Sutehai((uint)index.Value);
            }
        }

        public void Agari()
        {
            // やったね！あがり
            Console.WriteLine("あがり");
            Reset();
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}
