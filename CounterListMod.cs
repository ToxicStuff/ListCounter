using MelonLoader;
using System.Collections;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;

[assembly: MelonInfo(typeof(ListCounter.Main), ListCounter.BuildInfo.Name, ListCounter.BuildInfo.Version, ListCounter.BuildInfo.Author, ListCounter.BuildInfo.DownloadLink)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ListCounter;

public static class BuildInfo
{
    public const string Name = "ListCounter";
    public const string Author = "XoX-Toxic";
    public const string Version = "1.0.0";
    public const string DownloadLink = "https://github.com/ToxicStuff/ListCounter";
}

public class Main : MelonMod 
{
    public override void OnApplicationStart()
    {
        Patch.Init();
    }
}
