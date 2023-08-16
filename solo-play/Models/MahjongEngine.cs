using OpenMahjong;
using Reactive.Bindings;
using solo_play.OpenMahjong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace solo_play.Models
{
    public class MahjongEngine : IDisposable
    {
        private IntPtr _coreObject;
        private IntPtr _stateBuf;
        private int _stateSize;

        public static readonly byte[] title = Encoding.UTF8.GetBytes("solo-play\0");

        public ReactiveCollection<PaiT> Tehai { get; }
        public ReactiveCollection<PaiT> Kawahai { get; }
        public ReactivePropertySlim<PaiT> Tsumohai { get; }
        public ReactivePropertySlim<int> Shanten { get; }

        private static readonly Lazy<MahjongEngine> _instance = new(() => new MahjongEngine());

        public static MahjongEngine Instance { get => _instance.Value; }

        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 get_work_mem_size();
        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 get_player_mem_size();
        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initialize(IntPtr p, byte[] title, UInt32 playerLen);
        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void do_action(IntPtr p, UInt32 actionType, UInt32 playerIndex, UInt64 param);
        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_player_state(IntPtr p, UInt32 playerIndex, IntPtr dst);
        [DllImport("game_lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 get_player_shanten(IntPtr p, UInt32 playerIndex);

        public void Dispose()
        {
            Marshal.FreeHGlobal(_coreObject);
            Marshal.FreeHGlobal(_stateBuf);
        }

        private MahjongEngine()
        {
            UInt32 siz = get_work_mem_size();

            _coreObject = Marshal.AllocHGlobal((Int32)siz);

            siz = get_player_mem_size();
            _stateSize = (Int32)siz;

            _stateBuf = Marshal.AllocHGlobal(_stateSize);

            Tehai = new ReactiveCollection<PaiT>();
            Tsumohai = new ReactivePropertySlim<PaiT>();
            Kawahai = new ReactiveCollection<PaiT>();
            Shanten = new ReactivePropertySlim<int>(99);
        }


        private void SyncTehai()
        {
            // 手牌を持ってきてReactiveCollectionに突っ込む
            Tehai.Clear();
            Kawahai.Clear();

            get_player_state(_coreObject, 0, _stateBuf);

            Player player = FlatBufferLoader.LoadFromMemory<Player>(_stateBuf, _stateSize);

            for (int i = 0; i < player.TehaiLen; i++)
            {
                Tehai.Add(player.Tehai(i).UnPack());
            }

            for (int i = 0; i < player.KawahaiLen; i++)
            {
                Kawahai.Add(player.Kawahai(i).UnPack());
            }

            Tsumohai.Value = player.Tsumohai.UnPack();
            Shanten.Value = get_player_shanten(_coreObject, 0);
        }

        public void Reset()
        {

            initialize(_coreObject, title, 1);

            do_action(_coreObject, (uint)ActionType.ACTION_SYNC, 0, 0);

            SyncTehai();
        }

        public void Sutehai(UInt32 index)
        {
            do_action(_coreObject, (uint)ActionType.ACTION_SUTEHAI, 0, index);
            do_action(_coreObject, (uint)ActionType.ACTION_SYNC, 0, 0);
            SyncTehai();
        }
    }
}
