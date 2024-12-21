
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace cfg
{
public partial class Tables
{
    public common.TbGlobalConfig TbGlobalConfig {get; }
    public l10n.TbL10NDemo TbL10NDemo {get; }
    public l10n.TbPatchDemo TbPatchDemo {get; }

    public Tables(System.Func<string, ByteBuf> loader)
    {
        TbGlobalConfig = new common.TbGlobalConfig(loader("common_tbglobalconfig"));
        TbL10NDemo = new l10n.TbL10NDemo(loader("l10n_tbl10ndemo"));
        TbPatchDemo = new l10n.TbPatchDemo(loader("l10n_tbpatchdemo"));
        ResolveRef();
    }
    
    private void ResolveRef()
    {
        TbGlobalConfig.ResolveRef(this);
        TbL10NDemo.ResolveRef(this);
        TbPatchDemo.ResolveRef(this);
    }
}

}
