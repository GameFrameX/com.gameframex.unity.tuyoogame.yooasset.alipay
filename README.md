<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X YooAsset Alipay

[![License](https://img.shields.io/badge/license-blue.svg)](LICENSE.md)
[![Version](https://img.shields.io/github/v/release/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay)](https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)
[![Discord](https://img.shields.io/badge/-5865F2?logo=discord&logoColor=white)](https://discord.gg/VDWUjWMDw9)
[![GitHub](https://img.shields.io/badge/-181717?logo=github&logoColor=white)](https://github.com/GameFrameX/gameframex)
[![Bilibili](https://img.shields.io/badge/-00A1D6?logo=bilibili&logoColor=white)](https://www.bilibili.com/video/BV1yrpeepEn7)
[![Gitee](https://img.shields.io/badge/-C71D23?logo=gitee&logoColor=white)](https://gitee.com/GameFrameX/gameframex)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

`com.gameframex.unity.tuyoogame.yooasset.alipay` provides a YooAsset `IFileSystem` adapter for the Alipay mini-game runtime on Unity WebGL. It wires the Alipay file system into YooAsset so packaged assets can be delivered, cached, and loaded directly inside the Alipay mini-game container.

## Features

- Dedicated `IFileSystem` implementation for the Alipay mini-game runtime.
- Integrated Alipay SDK AssetBundle download and local cache.
- Package version request, manifest loading, and bundle download/load through YooAsset operations.
- Pluggable `IRemoteServices` for custom CDN endpoints and decryption pipelines.

## Quick Start

### Installation
Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add a `scopedRegistries` section:

   ```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ],
  "dependencies": {
    "com.gameframex.unity.tuyoogame.yooasset.alipay": "1.0.2"
  }
}
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add the Git URL directly to `manifest.json` under `dependencies`:

   ```json
{
    "com.gameframex.unity.tuyoogame.yooasset.alipay": "https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay.git"
  }
   ```
3. In Unity's **Package Manager**, add via **Git URL**: `https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay.git`.
4. Clone the repository into your Unity project's `Packages/` directory; it will be picked up automatically.

### Usage Examples

Use the bundled `AliPayFileSystemCreater` to obtain `WebPlayModeParameters` for the Alipay mini-game runtime.

```csharp
using YooAsset;

var createParameters = new WebPlayModeParameters();
createParameters.WebFileSystemParameters = AliPayFileSystemCreater.CreateAliPayFileSystemParameters(remoteServices);
```

## Dependencies

| Package | Description |
| --- | --- |
| com.gameframex.unity.tuyoogame.yooasset | 2.9.4 — Core YooAsset runtime & API. |
| com.gameframex.unity.asset | 3.1.1 — GameFrameX asset/runtime integration. |

## Documentation & Resources

- [Official Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/GameFrameX/gameframex)
[![Discord](https://img.shields.io/badge/Discord-5865F2?style=for-the-badge&logo=discord&logoColor=white)](https://discord.gg/VDWUjWMDw9)
[<img src="https://cdn.jsdelivr.net/npm/devicon@2/icons/linkedin/linkedin-original.svg" height="28" alt="LinkedIn" />](https://www.linkedin.com/in/alianblank)
[![Reddit](https://img.shields.io/badge/Reddit-FF4500?style=for-the-badge&logo=reddit&logoColor=white)](https://www.reddit.com/r/GameFrameX/)
[![X](https://img.shields.io/badge/X-000000?style=for-the-badge&logo=x&logoColor=white)](https://x.com/alian_blank)
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCD9QhSFJ5xZkn5NTSV-DVAw)
[![Bluesky](https://img.shields.io/badge/Bluesky-0285FF?style=for-the-badge&logo=bluesky&logoColor=white)](https://bsky.app/profile/alianblank.bsky.social)
[![Bilibili](https://img.shields.io/badge/Bilibili-00A1D6?style=for-the-badge&logo=bilibili&logoColor=white)](https://www.bilibili.com/video/BV1yrpeepEn7)
[![Gitee](https://img.shields.io/badge/Gitee-C71D23?style=for-the-badge&logo=gitee&logoColor=white)](https://gitee.com/GameFrameX/gameframex)
![QQ](https://img.shields.io/badge/QQ-467608841%2F233840761-EB1923?style=for-the-badge&logo=qq&logoColor=white)

## Changelog

See [Releases](https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay/releases) for the changelog.

## License

See [LICENSE.md](LICENSE.md) for license information.