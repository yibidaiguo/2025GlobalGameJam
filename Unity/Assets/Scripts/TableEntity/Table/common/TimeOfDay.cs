
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace cfg.common
{
public sealed partial class TimeOfDay : Luban.BeanBase
{
    public TimeOfDay(ByteBuf _buf) 
    {
        Hour = _buf.ReadInt();
        Minute = _buf.ReadInt();
        Second = _buf.ReadInt();
    }

    public static TimeOfDay DeserializeTimeOfDay(ByteBuf _buf)
    {
        return new common.TimeOfDay(_buf);
    }

    public readonly int Hour;
    public readonly int Minute;
    public readonly int Second;
   
    public const int __ID__ = -1728347371;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "hour:" + Hour + ","
        + "minute:" + Minute + ","
        + "second:" + Second + ","
        + "}";
    }
}

}

