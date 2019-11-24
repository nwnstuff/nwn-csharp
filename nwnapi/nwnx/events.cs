using System;
using NWN;

namespace NWN.NWNX
{
    public class Events
    {
        private const string PluginName = "NWNX_Events";

        public static void SubscribeEvent(string evt, string script)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnSubscribeEvent");
            Internal.NativeFunctions.nwnxPushString(script);
            Internal.NativeFunctions.nwnxPushString(evt);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void PushEventData(string tag, string data)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnPushEventData");
            Internal.NativeFunctions.nwnxPushString(data);
            Internal.NativeFunctions.nwnxPushString(tag);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static int SignalEvent(string evt, uint target)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnSignalEvent");
            Internal.NativeFunctions.nwnxPushObject(target);
            Internal.NativeFunctions.nwnxPushString(evt);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static string GetEventData(string tag)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnGetEventData");
            Internal.NativeFunctions.nwnxPushString(tag);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopString();
        }

        public static void SkipEvent()
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnSkipEvent");
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void SetEventResult(string data)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnSetEventResult");
            Internal.NativeFunctions.nwnxPushString(data);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static string GetCurrentEvent()
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnGetCurrentEvent");
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopString();
        }

        public static void ToggleDispatchListMode(string sEvent, string sScript, int bEnable)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnToggleDispatchListMode");
            Internal.NativeFunctions.nwnxPushInt(bEnable);
            Internal.NativeFunctions.nwnxPushString(sScript);
            Internal.NativeFunctions.nwnxPushString(sEvent);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void AddObjectToDispatchList(string sEvent, string sScript, uint oObject)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnAddObjectToDispatchList");
            Internal.NativeFunctions.nwnxPushObject(oObject);
            Internal.NativeFunctions.nwnxPushString(sScript);
            Internal.NativeFunctions.nwnxPushString(sEvent);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void RemoveObjectFromDispatchList(string sEvent, string sScript, uint oObject)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "OnRemoveObjectFromDispatchList");
            Internal.NativeFunctions.nwnxPushObject(oObject);
            Internal.NativeFunctions.nwnxPushString(sScript);
            Internal.NativeFunctions.nwnxPushString(sEvent);
            Internal.NativeFunctions.nwnxCallFunction();
        }
    }
}