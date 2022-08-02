using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VRC;
using VRC.Core;

namespace ListCounter
{
    internal class Patch
    {
        public static HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony("Patches");
        public static void Init()
        {
            foreach (MethodInfo methodInfo in typeof(UiUserList).GetMethods())
            {
                if (methodInfo.Name.StartsWith("Method_Protected_Virtual_Void_VRCUiContentButton_Object_"))
                    harmonyInstance.Patch(methodInfo, null, new HarmonyMethod(typeof(Patch).GetMethod(nameof(UiUserListPrefix), BindingFlags.Static | BindingFlags.NonPublic)));
            }
        }
        private static void UiUserListPrefix(ref UiUserList __instance, ref VRCUiContentButton __0, ref Il2CppSystem.Object __1)
        {
            if (__instance.Cast<UiUserList>() != null)
            {
                UiUserList list = __instance.Cast<UiUserList>();
                var txt = list.field_Public_Text_0;
                string Text = txt.text;
                if (Text.Contains("In Room"))
                {
                    txt.text = $"In Room [{PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count}/{RoomManager.field_Internal_Static_ApiWorld_0.capacity}]";
                }
                else if (Text.Contains("Online Friends"))
                {
                    txt.text = $"Online Friends [{list.field_Private_Int32_0}/{APIUser.CurrentUser.friendIDs.Count}]";
                }
                else if (Text.Contains("Offline Friends"))
                {
                    txt.text = $"Offline Friends [{list.field_Private_Int32_0}]";
                }
            }
        }
    }
}
