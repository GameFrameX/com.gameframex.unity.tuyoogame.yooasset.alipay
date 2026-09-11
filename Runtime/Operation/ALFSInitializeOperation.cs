#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ALIPAYMINIGAME
using YooAsset;

namespace YooAsset.Alipay
{

[UnityEngine.Scripting.Preserve]
internal partial class ALFSInitializeOperation : FSInitializeFileSystemOperation
{
    private readonly AliPayFileSystem _fileSystem;

    [UnityEngine.Scripting.Preserve]
    public ALFSInitializeOperation(AliPayFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnStart()
    {
        Status = EOperationStatus.Succeed;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnUpdate()
    {
    }
}
}
#endif