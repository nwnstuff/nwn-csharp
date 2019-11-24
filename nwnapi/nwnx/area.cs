using System;
using NWN;

namespace NWN.NWNX
{
    public static class Area
    {
        const string PluginName = "NWNX_Area";

        // Gets the number of players in area
        public static int GetNumberOfPlayersInArea(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetNumberOfPlayersInArea");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Gets the creature that last entered area
        public static uint GetLastEntered(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetLastEntered");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopObject();
        }

        // Gets the creature that last left area
        public static uint GetLastLeft(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetLastLeft");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopObject();
        }

        // Get the PVP setting of area
        // Returns NWNX_AREA_PVP_SETTING_*
        public static PvPSetting GetPVPSetting(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetPVPSetting");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return (PvPSetting)Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the PVP setting of area
        // pvpSetting = NWNX_AREA_PVP_SETTING_*
        public static void SetPVPSetting(uint area, PvPSetting pvpSetting)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetPVPSetting");

            Internal.NativeFunctions.nwnxPushInt((int)pvpSetting);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get the spot modifier of area
        public static int GetAreaSpotModifier(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetAreaSpotModifier");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the spot modifier of area
        public static void SetAreaSpotModifier(uint area, int spotModifier)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetAreaSpotModifier");

            Internal.NativeFunctions.nwnxPushInt(spotModifier);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get the listen modifer of area
        public static int GetAreaListenModifier(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetAreaListenModifier");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the listen modifier of area
        public static void SetAreaListenModifier(uint area, int listenModifier)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetAreaListenModifier");

            Internal.NativeFunctions.nwnxPushInt(listenModifier);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Returns TRUE if resting is not allowed in area
        public static bool GetNoRestingAllowed(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetNoRestingAllowed");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt() == 1;
        }

        // Set whether resting is allowed in area
        // TRUE: Resting not allowed
        // FALSE: Resting allowed
        public static void SetNoRestingAllowed(uint area, bool bNoRestingAllowed)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetNoRestingAllowed");

            Internal.NativeFunctions.nwnxPushInt(bNoRestingAllowed?1:0);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }
        // Get the wind power in area
        public static int GetWindPower(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetWindPower");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the wind power in area
        // windPower = 0-2
        public static void SetWindPower(uint area, int windPower)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetWindPower");

            Internal.NativeFunctions.nwnxPushInt(windPower);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get the weather chance of type in area
        // type = NWNX_AREA_WEATHER_CHANCE_*
        public static int GetWeatherChance(uint area, WeatherEffectType type)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetWeatherChance");

            Internal.NativeFunctions.nwnxPushInt((int)type);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }
        // Set the weather chance of type in area
        // type = NWNX_AREA_WEATHER_CHANCE_*
        // chance = 0-100
        public static void SetWeatherChance(uint area, WeatherEffectType type, int chance)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetWeatherChance");

            Internal.NativeFunctions.nwnxPushInt(chance);
            Internal.NativeFunctions.nwnxPushInt((int)type);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get the fog clip distance in area
        public static float GetFogClipDistance(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetFogClipDistance");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopFloat();
        }

        // Set the fog clip distance in area
        public static void SetFogClipDistance(uint area, float distance)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetFogClipDistance");

            Internal.NativeFunctions.nwnxPushFloat(distance);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }


        // Get the shadow opacity of area
        public static int GetShadowOpacity(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetShadowOpacity");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the shadow opacity of area
        // shadowOpacity = 0-100
        public static void SetShadowOpacity(uint area, int shadowOpacity)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetShadowOpacity");

            Internal.NativeFunctions.nwnxPushInt(shadowOpacity);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }


        // Get the day/night cycle of area
        // Returns NWNX_AREA_DAYNIGHTCYCLE_*
        public static DayNightCycleType GetDayNightCycle(uint area)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetDayNightCycle");

            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return (DayNightCycleType)Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the day/night cycle of area
        // type = NWNX_AREA_DAYNIGHTCYCLE_*
        public static void SetDayNightCycle(uint area, DayNightCycleType type)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetDayNightCycle");

            Internal.NativeFunctions.nwnxPushInt((int)type);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Get the Sun/Moon Ambient/Diffuse colors of area
        // type = NWNX_AREA_COLOR_TYPE_*
        //
        // Returns FOG_COLOR_* or a custom value, -1 on error
        public static int GetSunMoonColors(uint area, AreaColorType type)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetSunMoonColors");

            Internal.NativeFunctions.nwnxPushInt((int)type);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the Sun/Moon Ambient/Diffuse colors of area
        // type = NWNX_AREA_COLOR_TYPE_*
        // color = FOG_COLOR_*
        //
        // The color can also be represented as a hex RGB number if specific color shades are desired.
        // The format of a hex specified color would be 0xFFEEDD where
        // FF would represent the amount of red in the color
        // EE would represent the amount of green in the color
        // DD would represent the amount of blue in the color.
        public static void SetSunMoonColors(uint area, AreaColorType type, int color)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetSunMoonColors");

            Internal.NativeFunctions.nwnxPushInt(color);
            Internal.NativeFunctions.nwnxPushInt((int)type);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();
        }

        // Create and returns a transition (square shaped of specified size) at a location
        // Valid object types for the target are DOOR or WAYPOINT.
        // If a tag is specified the returning object will have that tag
        public static uint CreateTransition(uint area, uint target, float x, float y, float z, float size = 2.0f, string tag="")
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "CreateTransition");

            Internal.NativeFunctions.nwnxPushString(tag);
            Internal.NativeFunctions.nwnxPushFloat(size);
            Internal.NativeFunctions.nwnxPushFloat(z);
            Internal.NativeFunctions.nwnxPushFloat(y);
            Internal.NativeFunctions.nwnxPushFloat(x);
            Internal.NativeFunctions.nwnxPushObject(target);
            Internal.NativeFunctions.nwnxPushObject(area);
            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopObject();
        }

        // Get the state of a tile animation loop
        // nAnimLoop = 1-3
        public static int GetTileAnimationLoop(uint oArea, float fTileX, float fTileY, int nAnimLoop)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "GetTileAnimationLoop");

            Internal.NativeFunctions.nwnxPushInt(nAnimLoop);
            Internal.NativeFunctions.nwnxPushFloat(fTileY);
            Internal.NativeFunctions.nwnxPushFloat(fTileX);
            Internal.NativeFunctions.nwnxPushObject(oArea);

            Internal.NativeFunctions.nwnxCallFunction();

            return Internal.NativeFunctions.nwnxPopInt();
        }

        // Set the state of a tile animation loop
        // nAnimLoop = 1-3
        //
        // NOTE: Requires clients to re-enter the area for it to take effect
        public static void SetTileAnimationLoop(uint oArea, float fTileX, float fTileY, int nAnimLoop, bool bEnabled)
        {
            Internal.NativeFunctions.nwnxSetFunction(PluginName, "SetTileAnimationLoop");

            Internal.NativeFunctions.nwnxPushInt(bEnabled?1:0);
            Internal.NativeFunctions.nwnxPushInt(nAnimLoop);
            Internal.NativeFunctions.nwnxPushFloat(fTileY);
            Internal.NativeFunctions.nwnxPushFloat(fTileX);
            Internal.NativeFunctions.nwnxPushObject(oArea);

            Internal.NativeFunctions.nwnxCallFunction();
        }

    }
}
