// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace OpenMahjong
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct FixedString : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p = new Struct(_i, _bb); }
  public FixedString __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte N1(int j) { return __p.bb.Get(__p.bb_pos + 0 + j * 1); }
  public void MutateN1(int j, byte n1) { __p.bb.Put(__p.bb_pos + 0 + j * 1, n1); }
  public byte N2(int j) { return __p.bb.Get(__p.bb_pos + 32 + j * 1); }
  public void MutateN2(int j, byte n2) { __p.bb.Put(__p.bb_pos + 32 + j * 1, n2); }
  public byte N3(int j) { return __p.bb.Get(__p.bb_pos + 64 + j * 1); }
  public void MutateN3(int j, byte n3) { __p.bb.Put(__p.bb_pos + 64 + j * 1, n3); }
  public byte N4(int j) { return __p.bb.Get(__p.bb_pos + 96 + j * 1); }
  public void MutateN4(int j, byte n4) { __p.bb.Put(__p.bb_pos + 96 + j * 1, n4); }
  public byte N5(int j) { return __p.bb.Get(__p.bb_pos + 128 + j * 1); }
  public void MutateN5(int j, byte n5) { __p.bb.Put(__p.bb_pos + 128 + j * 1, n5); }
  public byte N6(int j) { return __p.bb.Get(__p.bb_pos + 160 + j * 1); }
  public void MutateN6(int j, byte n6) { __p.bb.Put(__p.bb_pos + 160 + j * 1, n6); }
  public byte N7(int j) { return __p.bb.Get(__p.bb_pos + 192 + j * 1); }
  public void MutateN7(int j, byte n7) { __p.bb.Put(__p.bb_pos + 192 + j * 1, n7); }
  public byte N8(int j) { return __p.bb.Get(__p.bb_pos + 224 + j * 1); }
  public void MutateN8(int j, byte n8) { __p.bb.Put(__p.bb_pos + 224 + j * 1, n8); }

  public static Offset<OpenMahjong.FixedString> CreateFixedString(FlatBufferBuilder builder, byte[] N1, byte[] N2, byte[] N3, byte[] N4, byte[] N5, byte[] N6, byte[] N7, byte[] N8) {
    builder.Prep(1, 256);
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N8[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N7[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N6[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N5[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N4[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N3[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N2[_idx0-1]);
    }
    for (int _idx0 = 32; _idx0 > 0; _idx0--) {
      builder.PutByte(N1[_idx0-1]);
    }
    return new Offset<OpenMahjong.FixedString>(builder.Offset);
  }
  public FixedStringT UnPack() {
    var _o = new FixedStringT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(FixedStringT _o) {
    _o.N1 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N1[_j] = this.N1(_j); }
    _o.N2 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N2[_j] = this.N2(_j); }
    _o.N3 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N3[_j] = this.N3(_j); }
    _o.N4 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N4[_j] = this.N4(_j); }
    _o.N5 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N5[_j] = this.N5(_j); }
    _o.N6 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N6[_j] = this.N6(_j); }
    _o.N7 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N7[_j] = this.N7(_j); }
    _o.N8 = new byte[32];
    for (var _j = 0; _j < 32; ++_j) { _o.N8[_j] = this.N8(_j); }
  }
  public static Offset<OpenMahjong.FixedString> Pack(FlatBufferBuilder builder, FixedStringT _o) {
    if (_o == null) return default(Offset<OpenMahjong.FixedString>);
    var _n1 = _o.N1;
    var _n2 = _o.N2;
    var _n3 = _o.N3;
    var _n4 = _o.N4;
    var _n5 = _o.N5;
    var _n6 = _o.N6;
    var _n7 = _o.N7;
    var _n8 = _o.N8;
    return CreateFixedString(
      builder,
      _n1,
      _n2,
      _n3,
      _n4,
      _n5,
      _n6,
      _n7,
      _n8);
  }
}

public class FixedStringT
{
  public byte[] N1 { get; set; }
  public byte[] N2 { get; set; }
  public byte[] N3 { get; set; }
  public byte[] N4 { get; set; }
  public byte[] N5 { get; set; }
  public byte[] N6 { get; set; }
  public byte[] N7 { get; set; }
  public byte[] N8 { get; set; }

  public FixedStringT() {
    this.N1 = new byte[32];
    this.N2 = new byte[32];
    this.N3 = new byte[32];
    this.N4 = new byte[32];
    this.N5 = new byte[32];
    this.N6 = new byte[32];
    this.N7 = new byte[32];
    this.N8 = new byte[32];
  }
}


}
