using NWN;

namespace NWN.NWNX
{
    public static class Appearance
    {
        const string PluginName = "NWNX_Appearance";
        public enum OverrideType
        {
            Appearance       = 0,
            Gender           = 1,
            Hitpoints        = 2,
            HairColor        = 3,
            SkinColor        = 4,
            Phenotype        = 5,
            HeadType         = 6,
            Soundset         = 7,
            TailType         = 8,
            WingType         = 9,
            FootstepSound    = 10,
            Portrait         = 11,
        }

        // Override oCreature's nType to nValue for oPlayer
        // - oCreature can be a PC
        //
        // nType = NWNX_APPEARANCE_TYPE_APPEARANCE
        // nValue = APPEARANCE_TYPE_* or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_GENDER
        // nValue = GENDER_* or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_HITPOINTS
        // nValue = 0-GetMaxHitPoints(oCreature) or -1 to remove
        // NOTE: This is visual only. Does not change the Examine Window health status
        //
        // nType = NWNX_APPEARANCE_TYPE_HAIR_COLOR
        // nType = NWNX_APPEARANCE_TYPE_SKIN_COLOR
        // nValue = 0-175 or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_PHENOTYPE
        // nValue = PHENOTYPE_* or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_HEAD_TYPE
        // nValue = 0-? or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_SOUNDSET
        // nValue = See soundset.2da or -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_TAIL_TYPE
        // nValue = CREATURE_WING_TYPE_* or see wingmodel.2da, -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_WING_TYPE
        // nValue = CREATURE_TAIL_TYPE_* or see tailmodel.2da, -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_FOOTSTEP_SOUND
        // nValue = 0-17 or see footstepsounds.2da, -1 to remove
        //
        // nType = NWNX_APPEARANCE_TYPE_PORTRAIT
        // nValue = See portraits.2da, -1 to remove
        // NOTE: Does not change the Examine Window portrait
        public static void SetOverride(uint oPlayer, uint oCreature, OverrideType nType, int nValue)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetOverride");
            Internal.NativeFunctions.nwnxPushInt(nValue);
            Internal.NativeFunctions.nwnxPushInt((int)nType);
            Internal.NativeFunctions.nwnxPushObject(oCreature);
            Internal.NativeFunctions.nwnxPushObject(oPlayer);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get oCreature's nValue of nType for oPlayer
        // - oCreature can be a PC
        // Returns -1 when not set
        public static int GetOverride(uint oPlayer, uint oCreature, OverrideType nType)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetOverride");
            Internal.NativeFunctions.nwnxPushInt((int)nType);
            Internal.NativeFunctions.nwnxPushObject(oCreature);
            Internal.NativeFunctions.nwnxPushObject(oPlayer);
            Internal.NativeFunctions.nwnxCallFunction();
            return Internal.NativeFunctions.nwnxPopInt();
        }

    }
}
