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

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

`com.gameframex.unity.tuyoogame.yooasset.alipay`은 Unity WebGL의 Alipay 미니게임 런타임을 위한 YooAsset `IFileSystem` 어댑터를 제공합니다. Alipay 파일 시스템을 YooAsset에 연결하여 패키징된 애셋을 Alipay 미니게임 컨테이너에서 직접 전달·캐시·로드할 수 있도록 합니다.

## 기능

- Alipay 미니게임 런타임 전용 `IFileSystem` 구현.
- Alipay SDK와 통합된 AssetBundle 다운로드 및 로컬 캐시.
- YooAsset 연산을 통한 패키지 버전 요청, 매니페스트 로드, 번들 다운로드/로드.
- 커스텀 CDN 엔드포인트 및 복호화 파이프라인을 위한 플러그 가능한 `IRemoteServices`.

## 빠른 시작

### 설치
다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:

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
    "com.gameframex.unity.tuyoogame.yooasset.alipay": "1.2.0"
  }
}
   ```

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:

   ```json
{
    "com.gameframex.unity.tuyoogame.yooasset.alipay": "https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay.git"
  }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay.git`
`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.

### 업그레이드 안내

> **1.2.0 파괴적 변경:** 이 패키지는 더 이상 `com.gameframex.unity.asset`에 의존하지 않으며, 유일한 의존성은 `com.gameframex.unity.tuyoogame.yooasset`(≥ 3.1.0)입니다. 업그레이드 시 코어 패키지를 ≥ 3.1.0로 함께 업그레이드해야 하며, 프로젝트에 asset 패키지가 설치되어 있다면 ≥ 4.1.0로 함께 업그레이드하십시오. asset ≥ 4.1.0가 함께 설치된 프로젝트는 영향을 받지 않습니다.

### 사용 예시

번들된 `AliPayFileSystemCreater`를 사용해 Alipay 미니게임 런타임용 `WebPlayModeParameters`를 가져옵니다.

```csharp
using YooAsset;

var createParameters = new WebPlayModeParameters();
createParameters.WebFileSystemParameters = AliPayFileSystemCreater.CreateAliPayFileSystemParameters(remoteServices);
```

## 의존성

| 패키지 | 설명 |
| --- | --- |
| com.gameframex.unity.tuyoogame.yooasset | ≥ 3.1.0 — YooAsset 코어 런타임 및 API. |


## 등록 기반 디스패치 메커니즘

이 패키지가 제공하는 `AliPayWebPlayModeFileSystemProvider`(Priority 4)는 `BeforeSceneLoad` 시점에 코어 패키지의 `WebPlayModeFileSystemProviderRegistry`에 자동 등록되며, 이 시점은 첫 Web 모드 초기화보다 이릅니다. 초기화 시 에셋 추상화 계층은 Priority 기준으로 상호 배타적으로 확인하여(가장 높은 Priority, 동일하면 먼저 등록된 항목) 단 하나의 플랫폼 파일 시스템만 선택해 초기화합니다.

## 문서 및 자료

- [공식 문서](https://gameframex.doc.alianblank.com)

## 커뮤니티 및 지원

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

## 변경 로그

변경 로그는 [Releases](https://github.com/gameframex/com.gameframex.unity.tuyoogame.yooasset.alipay/releases)를 확인하세요.

## 라이선스

자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.