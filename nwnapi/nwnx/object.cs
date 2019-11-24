using System;
using NWN;

namespace NWN.NWNX
{
    public class Object
    {
        private const string PluginName = "NWNX_Object";

        public const int LOCALVAR_TYPE_INT      = 1;
        public const int LOCALVAR_TYPE_FLOAT    = 2;
        public const int LOCALVAR_TYPE_STRING   = 3;
        public const int LOCALVAR_TYPE_OBJECT   = 4;
        public const int LOCALVAR_TYPE_LOCATION = 5;

        public struct LocalVariable
        {
            public int type; ///< Int, String, Float, Object
            public string key; ///< Name of the variable
        };

        public static int GetLocalVariableCount(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetLocalVariableCount");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static LocalVariable GetLocalVariable(uint obj, int index)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetLocalVariable");
            Internal.NativeFunctions.nwnxPushInt(index);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();

            LocalVariable lv = new LocalVariable();
            lv.key  = Internal.NativeFunctions.nwnxPopString();
            lv.type = Internal.NativeFunctions.nwnxPopInt();
            return lv;
        }

        public static uint StringToObject(string id)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "StringToObject");
            Internal.NativeFunctions.nwnxPushString(id);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopObject();
        }

        public static void SetPosition(uint obj, Vector pos)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetPosition");
            Internal.NativeFunctions.nwnxPushFloat(pos.x);
            Internal.NativeFunctions.nwnxPushFloat(pos.y);
            Internal.NativeFunctions.nwnxPushFloat(pos.z);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();

        }

        public static void SetCurrentHitPoints(uint creature, int hp)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetCurrentHitPoints");
            Internal.NativeFunctions.nwnxPushInt(hp);
            Internal.NativeFunctions.nwnxPushObject(creature);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void SetMaxHitPoints(uint creature, int hp)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetMaxHitPoints");
            Internal.NativeFunctions.nwnxPushInt(hp);
            Internal.NativeFunctions.nwnxPushObject(creature);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static string Serialize(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "Serialize");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopString();
        }

        public static uint Deserialize(string serialized)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "Deserialize");
            Internal.NativeFunctions.nwnxPushString(serialized);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopObject();
        }

        public static string GetDialogResref(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetDialogResref");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopString();
        }

        public static void SetDialogResref(uint obj, string dialog)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetDialogResref");
            Internal.NativeFunctions.nwnxPushString(dialog);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void SetAppearance(uint obj, int app)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetAppearance");
            Internal.NativeFunctions.nwnxPushInt(app);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static int GetAppearance(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetAppearance");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static int GetHasVisualEffect(uint obj, int nVFX)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetHasVisualEffect");
            Internal.NativeFunctions.nwnxPushInt(nVFX);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static int CheckFit(uint obj, int baseitem)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "CheckFit");
            Internal.NativeFunctions.nwnxPushInt(baseitem);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static int GetDamageImmunity(uint obj, int damageType)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetDamageImmunity");
            Internal.NativeFunctions.nwnxPushInt(damageType);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static void AddToArea(uint obj, uint area, Vector pos)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "AddToArea");
            Internal.NativeFunctions.nwnxPushFloat(pos.z);
            Internal.NativeFunctions.nwnxPushFloat(pos.y);
            Internal.NativeFunctions.nwnxPushFloat(pos.x);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static int GetPlaceableIsStatic(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetPlaceableIsStatic");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static void SetPlaceableIsStatic(uint obj, int isStatic)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetPlaceableIsStatic");
            Internal.NativeFunctions.nwnxPushInt(isStatic);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static int GetAutoRemoveKey(uint obj)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetAutoRemoveKey");
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

        public static void SetAutoRemoveKey(uint obj, int bRemoveKey)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetAutoRemoveKey");
            Internal.NativeFunctions.nwnxPushInt(bRemoveKey);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static string GetTriggerGeometry(uint oTrigger)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetTriggerGeometry");
            Internal.NativeFunctions.nwnxPushObject(oTrigger);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopString();
        }

        public static void SetTriggerGeometry(uint oTrigger, string sGeometry)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetTriggerGeometry");
            Internal.NativeFunctions.nwnxPushString(sGeometry);
            Internal.NativeFunctions.nwnxPushObject(oTrigger);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void AddIconEffect(uint obj, int nIcon, float fDuration=0f)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "AddIconEffect");
            Internal.NativeFunctions.nwnxPushFloat(fDuration);
            Internal.NativeFunctions.nwnxPushInt(nIcon);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void RemoveIconEffect(uint obj, int nIcon)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "RemoveIconEffect");
            Internal.NativeFunctions.nwnxPushInt(nIcon);
            Internal.NativeFunctions.nwnxPushObject(obj);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        public static void Export(string sFileName, uint oObject)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "Export");
            Internal.NativeFunctions.nwnxPushObject(oObject);
            Internal.NativeFunctions.nwnxPushString(sFileName);
            Internal.NativeFunctions.nwnxCallFunction();
        }
    }
}