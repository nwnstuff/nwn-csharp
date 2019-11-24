using System;
using System.Linq;
using System.Collections.Generic;

namespace NWN
{
    public delegate void ScriptDelegate(uint oid);

    public class Entrypoints
    {
        public const int SCRIPT_HANDLED = 0;
        public const int SCRIPT_NOT_HANDLED = -1;

        public static Dictionary<string, ScriptDelegate> Scripts;

        public static void OnMainLoop(ulong frame)
        {
            // Console.WriteLine($"MainLoop frame {frame}");
        }

        public static int OnRunScript(string script, uint oidSelf)
        {
            if (Scripts.ContainsKey(script)) {
                Console.WriteLine($"Handling '{script}' on oid {oidSelf}");
                Scripts[script](oidSelf);
                return SCRIPT_HANDLED;
            }
            Console.WriteLine($"Passing '{script}' on oid {oidSelf} to nwscript");
            return SCRIPT_NOT_HANDLED;
        }

        public static void OnStart()
        {
            Console.WriteLine("OnStart() called");
            Scripts = ScriptHandler.GetHandlersFromAssembly();
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple=true)]  
    public class ScriptHandler : System.Attribute {
        public string Script;

        public ScriptHandler(string script) { Script = script; }
        
        public static Dictionary<string, ScriptDelegate> GetHandlersFromAssembly() {
            var result = new Dictionary<string, ScriptDelegate>();
            var handlers = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(ScriptHandler), false).Length > 0)
                .ToArray();
            foreach (var mi in handlers)
            {
                var del = (ScriptDelegate) mi.CreateDelegate(typeof(ScriptDelegate));
                foreach (var attr in mi.GetCustomAttributes(typeof(ScriptHandler), false))
                {
                    result[(attr as ScriptHandler).Script] = del;
                }
            }
            return result;
        }
    }    
}
