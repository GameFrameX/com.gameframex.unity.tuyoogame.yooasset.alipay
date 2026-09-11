#if UNITY_WEBGL && ENABLE_ALIPAY_MINI_GAME && ALIPAYMINIGAME
using YooAsset;

namespace YooAsset.Alipay
{

[UnityEngine.Scripting.Preserve]
internal class ALFSLoadPackageManifestOperation : FSLoadPackageManifestOperation
{
    [UnityEngine.Scripting.Preserve]
    private enum ESteps
    {
        None,
        RequestRemotePackageHash,
        LoadRemotePackageManifest,
        Done,
    }

    private readonly AliPayFileSystem _fileSystem;
    private readonly string _packageVersion;
    private readonly int _timeout;
    private RequestAliPayPackageHashOperation _requestRemotePackageHashOp;
    private LoadAliPayPackageManifestOperation _loadRemotePackageManifestOp;
    private ESteps _steps = ESteps.None;

    [UnityEngine.Scripting.Preserve]
    public ALFSLoadPackageManifestOperation(AliPayFileSystem fileSystem, string packageVersion, int timeout)
    {
        _fileSystem = fileSystem;
        _packageVersion = packageVersion;
        _timeout = timeout;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnStart()
    {
        _steps = ESteps.RequestRemotePackageHash;
    }

    [UnityEngine.Scripting.Preserve]
    public override void InternalOnUpdate()
    {
        if (_steps == ESteps.None || _steps == ESteps.Done)
            return;

        if (_steps == ESteps.RequestRemotePackageHash)
        {
            if (_requestRemotePackageHashOp == null)
            {
                _requestRemotePackageHashOp = new RequestAliPayPackageHashOperation(_fileSystem, _packageVersion, _timeout);
                OperationSystem.StartOperation(_fileSystem.PackageName, _requestRemotePackageHashOp);
            }

            if (_requestRemotePackageHashOp.IsDone == false)
                return;

            if (_requestRemotePackageHashOp.Status == EOperationStatus.Succeed)
            {
                _steps = ESteps.LoadRemotePackageManifest;
            }
            else
            {
                _steps = ESteps.Done;
                Status = EOperationStatus.Failed;
                Error = _requestRemotePackageHashOp.Error;
            }
        }

        if (_steps == ESteps.LoadRemotePackageManifest)
        {
            if (_loadRemotePackageManifestOp == null)
            {
                string packageHash = _requestRemotePackageHashOp.PackageHash;
                _loadRemotePackageManifestOp = new LoadAliPayPackageManifestOperation(_fileSystem, _packageVersion, packageHash, _timeout);
                OperationSystem.StartOperation(_fileSystem.PackageName, _loadRemotePackageManifestOp);
            }

            Progress = _loadRemotePackageManifestOp.Progress;
            if (_loadRemotePackageManifestOp.IsDone == false)
                return;

            if (_loadRemotePackageManifestOp.Status == EOperationStatus.Succeed)
            {
                _steps = ESteps.Done;
                Manifest = _loadRemotePackageManifestOp.Manifest;
                Status = EOperationStatus.Succeed;
            }
            else
            {
                _steps = ESteps.Done;
                Status = EOperationStatus.Failed;
                Error = _loadRemotePackageManifestOp.Error;
            }
        }
    }
}
}
#endif