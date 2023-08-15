using Google.FlatBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace solo_play.OpenMahjong
{
    public class FlatBufferLoader
    {
        public static T LoadFromMemory<T>(IntPtr src, int size)
        where T : IFlatbufferObject, new()
        {
            byte[] data = new byte[size];

            Marshal.Copy(src, data, 0, size);
            T inst = new T();
            ByteBuffer buf = new ByteBuffer(data);

            int pos = buf.GetInt(0);

            inst.__init(pos, buf);

            return inst;
        }

        public static T LoadFromByteArray<T>(byte[] data)
        where T : IFlatbufferObject, new()
        {
            T inst = new T();
            ByteBuffer buf = new ByteBuffer(data);

            int pos = buf.GetInt(0);

            inst.__init(pos, buf);

            return inst;
        }

        public static T LoadFromStream<T>(System.IO.Stream stream)
        where T : IFlatbufferObject, new()
        {
            byte[] data = new byte[stream.Length];

            stream.Read(data, 0, data.Length);

            T inst = new T();

            ByteBuffer buf = new ByteBuffer(data);

            int pos = buf.GetInt(0);

            inst.__init(pos, buf);

            return inst;
        }

        public static async Task<T> LoadFromStreamAsync<T>(System.IO.Stream stream)
        where T : IFlatbufferObject, new()
        {
            byte[] data = new byte[stream.Length];

            await stream.ReadAsync(data, 0, data.Length);

            T inst = new T();

            ByteBuffer buf = new ByteBuffer(data);

            int pos = buf.GetInt(0);

            inst.__init(pos, buf);

            return inst;
        }
    }
}
