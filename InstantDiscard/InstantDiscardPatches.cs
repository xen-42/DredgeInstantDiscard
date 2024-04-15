using HarmonyLib;

namespace InstantDiscard;

[HarmonyPatch(typeof(DefaultActionHandler))]
public static class InstantDiscardPatches
{
    public static void Initialize() => new Harmony(nameof(InstantDiscard)).PatchAll();

    [HarmonyPostfix]
    [HarmonyPatch(nameof(DefaultActionHandler.TryAddDiscardAction))]
    public static void DefaultActionHandler_TryAddDiscardAction(DefaultActionHandler __instance, GridObject gridObject)
    {
        if (gridObject != null && gridObject.ItemData is FishItemData)
        {
            __instance.discardAction.holdTimeRequiredSec = 0f;
        }
    } 
}
