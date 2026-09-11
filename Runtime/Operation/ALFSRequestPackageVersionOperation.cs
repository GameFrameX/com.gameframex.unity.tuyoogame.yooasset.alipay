#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ALIPAYMINIGAME
using YooAsset;

namespace YooAsset.Alipay
{

[UnityEngine.Scripting.Preserve]
internal class ALFSRequestPackageVersionOperation : FSRequestPackageVersionOperation
{
    [UnityEngine.Scripting.Preserve]
    private enum ESteps
    {
        None,
        RequestPackageVersion,
        Done,
    }

    private readonly AliPayFileSystem _fileSystem;
    private readonly bool _appendTimeTicks;
    private readonly int _timeout;
    private RequestAliPayPackageVersionOperation _requestWebPackageVersionOp;
    private ESteps _steps = ESteps.None;


    [UnityEngine.Scripting.Preserve]
    internal ALFSRequestPackageVersionOperation(AliPayFileSystem fileSystem, bool appendTimeTicks, int timeout)
    {
        _fileSystem = fileSystem;
        _appendTimeTicks = appendTimeTicks;
        _timeout = timeout;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnStart()
    {
        _steps = ESteps.RequestPackageVersion;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnUpdate()
    {
        if (_steps == ESteps.None || _steps == ESteps.Done)
        {
            return;
        }

        if (_steps != ESteps.RequestPackageVersion)
        {
            return;
        }

        if (_requestWebPackageVersionOp == null)
        {
            _requestWebPackageVersionOp = new RequestAliPayPackageVersionOperation(_fileSystem, _appendTimeTicks, _timeout);
            OperationSystem.StartOperation(_fileSystem.PackageName, _requestWebPackageVersionOp);
        }

        Progress = _requestWebPackageVersionOp.Progress;
        if (_requestWebPackageVersionOp.IsDone == false)
        {
            return;
        }

        if (_requestWebPackageVersionOp.Status == EOperationStatus.Succeed)
        {
            _steps = ESteps.Done;
            PackageVersion = _requestWebPackageVersionOp.PackageVersion;
            Status = EOperationStatus.Succeed;
        }
        else
        {
            _steps = ESteps.Done;
            Status = EOperationStatus.Failed;
            Error = _requestWebPackageVersionOp.Error;
        }
    }
}
}
#endif