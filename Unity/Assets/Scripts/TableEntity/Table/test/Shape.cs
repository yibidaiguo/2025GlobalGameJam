
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace cfg.test
{
public abstract partial class Shape : Luban.BeanBase
{
    public Shape(ByteBuf _buf) 
    {
    }

    public static Shape DeserializeShape(ByteBuf _buf)
    {
        switch (_buf.ReadInt())
        {
            case test.Circle.__ID__: return new test.Circle(_buf);
            case test2.Rectangle.__ID__: return new test2.Rectangle(_buf);
            default: throw new SerializationException();
        }
    }

   

    public virtual void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "}";
    }
}

}

