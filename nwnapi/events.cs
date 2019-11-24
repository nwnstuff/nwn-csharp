using System;

namespace NWN.Events
{
    public delegate void ModuleEventDelegate();
    public delegate void PlayerEventDelegate(NWPlayer pc);
    public delegate void ItemEventDelegate(NWItem item);
    public delegate void ItemLostEventDelegate(NWItem item, NWCreature lostBy);
    public delegate void AreaEventDelegate(NWArea area); //, NWCreature subject);

    public class PlayerChatEvent
    {
        public delegate void EventDelegate(PlayerChatEvent e);
        public NWPlayer Speaker {get; protected set;}
        public string OriginalText {get; protected set;}
        public string ModifiedText {get; protected set;}
        public int OriginalVolume {get; protected set;}
        public int ModifiedVolume {get; protected set;}

        public PlayerChatEvent()
        {
            Speaker = NWScript.GetPCChatSpeaker().AsPlayer();
            OriginalText = NWScript.GetPCChatMessage();
            OriginalVolume = NWScript.GetPCChatVolume();
        }
        public void ModifyText(string newText) 
        { 
            ModifiedText = newText; 
            NWScript.SetPCChatMessage(newText);
        }
        public void ModifyVolume(int newVolume)
        {
            ModifiedVolume = newVolume;
            NWScript.SetPCChatVolume(newVolume);
        }
    }

    public class ItemActivatedEvent
    {
        public delegate void EventDelegate(ItemActivatedEvent e);

        public NWItem Item {get; protected set;}
        public NWCreature Activator {get; protected set;}
        public Location TargetLocation {get; protected set;}
        public NWObject TargetObject {get; protected set;}

        public ItemActivatedEvent()
        {
            Item = NWScript.GetItemActivated().AsItem();
            Activator = NWScript.GetItemActivator().AsCreature();
            TargetLocation = NWScript.GetItemActivatedTargetLocation();
            TargetObject = NWScript.GetItemActivatedTarget().AsObject();
        }
    }

    public class BuiltinEvents
    {
        public static ModuleEventDelegate                   OnModuleLoad                = delegate {};
        public static ModuleEventDelegate                   OnModuleReload              = delegate {};
        public static ModuleEventDelegate                   OnModuleStart               = delegate {};
        public static ModuleEventDelegate                   OnModuleHeartbeat           = delegate {};
        public static ModuleEventDelegate                   OnClientEnter               = delegate {};
        public static ModuleEventDelegate                   OnClientLeave               = delegate {};

        public static PlayerEventDelegate                   OnCancelCutscene            = delegate {};
        public static PlayerEventDelegate                   OnPlayerDeath               = delegate {};
        public static PlayerEventDelegate                   OnPlayerDying               = delegate {};
        public static PlayerEventDelegate                   OnPlayerLevelUp             = delegate {};
        public static PlayerEventDelegate                   OnPlayerRest                = delegate {};
        public static PlayerEventDelegate                   OnPlayerRespawn             = delegate {};
        public static PlayerEventDelegate                   OnPlayerHeartbeat           = delegate {};
        public static PlayerChatEvent.EventDelegate         OnPlayerChat                = delegate {};

        public static ItemEventDelegate                     OnItemEquipped              = delegate {};
        public static ItemEventDelegate                     OnItemUnequipped            = delegate {};
        public static ItemEventDelegate                     OnItemAcquired              = delegate {};
        public static ItemLostEventDelegate                 OnItemLost                  = delegate {};
        public static ItemActivatedEvent.EventDelegate      OnItemActivated             = delegate {};

        public static AreaEventDelegate                     OnAreaEnter                 = delegate {};
        public static AreaEventDelegate                     OnAreaExit                  = delegate {};
    }


    public class EventHandlers
    {
        private static bool isConfigured = false;

        [ScriptHandler("on_module_load")]
        public static void OnModuleLoad(uint oModule)
        {
            if (isConfigured) 
            {
                BuiltinEvents.OnModuleReload();
                return;
            }

            Console.WriteLine("Module loaded. Configuring events.");
            var module = NWModule.Module;
            module.Scripts[EventScript.Module_OnClientEnter]            = "mod-client-enter";
            module.Scripts[EventScript.Module_OnClientExit]             = "mod-client-exit";
            module.Scripts[EventScript.Module_OnHeartbeat]              = "mod-heartbeat";
            module.Scripts[EventScript.Module_OnAcquireItem]            = "mod-acquire";
            module.Scripts[EventScript.Module_OnActivateItem]           = "mod-activate";
            module.Scripts[EventScript.Module_OnEquipItem]              = "mod-equip";
            module.Scripts[EventScript.Module_OnUnequipItem]            = "mod-unequip";
            module.Scripts[EventScript.Module_OnLoseItem]               = "mod-loseitem";
            // module.Scripts[EventScript.Module_OnModuleLoad]             = "mod-load";
            module.Scripts[EventScript.Module_OnModuleStart]            = "mod-start";
            module.Scripts[EventScript.Module_OnPlayerCancelCutscene]   = "mod-cutscene";
            module.Scripts[EventScript.Module_OnPlayerChat]             = "mod-pc-chat";
            module.Scripts[EventScript.Module_OnPlayerDeath]            = "mod-pc-death";
            module.Scripts[EventScript.Module_OnPlayerDying]            = "mod-pc-dying";
            module.Scripts[EventScript.Module_OnPlayerLevelUp]          = "mod-pc-levelup";
            module.Scripts[EventScript.Module_OnPlayerRest]             = "mod-pc-rest";
            module.Scripts[EventScript.Module_OnRespawnButtonPressed]   = "mod-pc-respawn";

            foreach (var area in module.Areas)
            {
                area.Scripts[EventScript.Area_OnEnter] = "area-enter";
                area.Scripts[EventScript.Area_OnExit] = "area-exit";
                area.Scripts[EventScript.Area_OnHeartbeat] = "";
                area.Scripts[EventScript.Area_OnUserDefined] = "";
            }

            NWNX.Events.SubscribeEvent("NWNX_ON_EXAMINE_OBJECT_BEFORE", "nxe-examine-before");

            isConfigured = true;
            BuiltinEvents.OnModuleLoad();
        }

        [ScriptHandler("mod-heartbeat")]
        public static void OnModuleHeartBeat(uint oModule) { 
            BuiltinEvents.OnModuleHeartbeat(); 
        }

        [ScriptHandler("mod-start")]
        public static void OnModuleStart(uint oModule) { 
            BuiltinEvents.OnModuleStart(); 
        }

        [ScriptHandler("mod-client-enter")]
        public static void OnClientEnter(uint oModule) { 
            BuiltinEvents.OnClientEnter(); 
        }

        [ScriptHandler("mod-client-exit")]
        public static void OnClientLeave(uint oModule) { 
            BuiltinEvents.OnClientLeave(); 
        }

        [ScriptHandler("default")]
        public static void OnDefault(uint oid) { 
            BuiltinEvents.OnPlayerHeartbeat(oid.AsPlayer()); 
        }

        [ScriptHandler("mod-cutscene")]
        public static void OnCancelCutscene(uint oid) { 
            BuiltinEvents.OnCancelCutscene(NWScript.GetLastPCToCancelCutscene().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-death")]
        public static void OnPlayerDeath(uint oid) { 
            BuiltinEvents.OnPlayerDeath(NWScript.GetLastPlayerDied().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-dying")]
        public static void OnPlayerDying(uint oid) { 
            BuiltinEvents.OnPlayerDying(NWScript.GetLastPlayerDying().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-levelup")]
        public static void OnPlayerLevelUp(uint oid) { 
            BuiltinEvents.OnPlayerLevelUp(NWScript.GetPCLevellingUp().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-rest")]
        public static void OnPlayerRest(uint oid) { 
            BuiltinEvents.OnPlayerRest(NWScript.GetLastPCRested().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-respawn")]
        public static void OnPlayerRespawn(uint oid) { 
            BuiltinEvents.OnPlayerRespawn(NWScript.GetLastRespawnButtonPresser().AsPlayer()); 
        }

        [ScriptHandler("mod-pc-chat")]
        public static void OnPlayerChat(uint oid) { 
            BuiltinEvents.OnPlayerChat(new PlayerChatEvent()); 
        }

        [ScriptHandler("mod-acquire")]
        public static void OnItemAcquired(uint oid) { 
            BuiltinEvents.OnItemAcquired(NWScript.GetModuleItemAcquired().AsItem()); 
        }

        [ScriptHandler("mod-itemlost")]
        public static void OnItemLost(uint oid) { 
            BuiltinEvents.OnItemLost(NWScript.GetModuleItemLost().AsItem(), NWScript.GetModuleItemLostBy().AsCreature()); 
        }

        [ScriptHandler("mod-activate")]
        public static void OnItemActivated(uint oid) { 
            BuiltinEvents.OnItemActivated(new ItemActivatedEvent()); 
        }
        
        [ScriptHandler("mod-equip")]
        public static void OnItemEquipped(uint oid) { 
            BuiltinEvents.OnItemEquipped(NWScript.GetPCItemLastEquipped().AsItem()); 
        }

        [ScriptHandler("mod-unequip")]
        public static void OnItemUnequipped(uint oid) { 
            BuiltinEvents.OnItemUnequipped(NWScript.GetPCItemLastUnequipped().AsItem()); 
        }

        [ScriptHandler("area-enter")]
        public static void OnAreaEnter(uint oid) { 
            BuiltinEvents.OnAreaEnter(oid.AsArea()); 
        }

        [ScriptHandler("area-exit")]
        public static void OnAreaExit(uint oid) { 
            BuiltinEvents.OnAreaExit(oid.AsArea()); 
        }


        [ScriptHandler("nxe-examine-before")]
        public static void BeforeExamineObject(uint oid)
        {
            var sExaminee = NWNX.Events.GetEventData("EXAMINEE_OBJECT_ID");
            var oExaminee = NWNX.Object.StringToObject(sExaminee);
            var subjectName = NWScript.GetName(oid); 
            var objectName = NWScript.GetName(oExaminee);
            Console.WriteLine($"{subjectName} examined {objectName}");
        }
    }
}