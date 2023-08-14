using OpenMahjong;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace solo_play.Models
{
    public class GameEngine : IDisposable
    {
        private IntPtr _coreObject;
        private IntPtr _stateBuf;

        public static readonly byte[] title = Encoding.UTF8.GetBytes("solo-play\0");

        public ReactiveCollection<PaiT> Tehai { get; }

        private static readonly Lazy<GameEngine> _instance = new(() => new GameEngine());

        public static GameEngine Instance { get => _instance.Value; }

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

        public void Dispose()
        {
            Marshal.FreeHGlobal(_coreObject);
            Marshal.FreeHGlobal(_stateBuf);
        }

        private GameEngine()
        {
            UInt32 siz = get_work_mem_size();

            _coreObject = Marshal.AllocHGlobal((Int32)siz);

            siz = get_player_mem_size();

            _stateBuf = Marshal.AllocHGlobal((Int32)siz);

            Tehai = new ReactiveCollection<PaiT>();
        }

        public void Reset()
        {
            initialize(_coreObject, title, 1);
        }
    }
}
