namespace NWN.Events
{
    public class ClientConnectEvent : NWNXEvent
    {
        public override bool Skippable => true;
        
        public const string BEFORE_CONNECT      = "NWNX_ON_CLIENT_CONNECT_BEFORE";
        public const string AFTER_CONNECT       = "NWNX_ON_CLIENT_CONNECT_AFTER";

        public delegate void EventDelegate(ClientConnectEvent e);

        public static EventDelegate BeforeClientConnect          = delegate {};
        public static EventDelegate AfterClientConnect           = delegate {};

        public string PlayerName => GetEventString("PLAYER_NAME");
        public string PlayerCDKey => GetEventString("CDKEY");
        public string PlayerIP => GetEventString("IP_ADDRESS");
        public bool IsDM => GetEventInt("IS_DM") == 1;

        public ClientConnectEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_CONNECT)]
        [NWNEventHandler(AFTER_CONNECT)]
        public static void EventHandler(string script)
        {
            var e = new ClientConnectEvent(script);
            switch (script)
            {
                case BEFORE_CONNECT:    BeforeClientConnect(e); break;
                case AFTER_CONNECT:     AfterClientConnect(e); break;
                default: break;
            }
        }
    }
    
    public class ClientDisconnectEvent : NWNXEvent
    {
        public const string BEFORE_DISCONNECT      = "NWNX_ON_CLIENT_DISCONNECT_BEFORE";
        public const string AFTER_DISCONNECT       = "NWNX_ON_CLIENT_DISCONNECT_AFTER";

        public delegate void EventDelegate(ClientDisconnectEvent e);

        public static EventDelegate BeforeClientDisconnect          = delegate {};
        public static EventDelegate AfterClientDisconnect           = delegate {};

        public NWPlayer Player => Internal.OBJECT_SELF.AsPlayer();

        public ClientDisconnectEvent(string script) { EventType = script; }

        [NWNEventHandler(BEFORE_DISCONNECT)]
        [NWNEventHandler(AFTER_DISCONNECT)]
        public static void EventHandler(string script)
        {
            var e = new ClientDisconnectEvent(script);
            switch (script)
            {
                case BEFORE_DISCONNECT:    BeforeClientDisconnect(e); break;
                case AFTER_DISCONNECT:     AfterClientDisconnect(e); break;
                default: break;
            }
        }
    }
}