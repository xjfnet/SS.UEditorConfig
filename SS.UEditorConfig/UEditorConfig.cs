using HookingDotNet;
using Newtonsoft.Json.Linq;
using SiteServer.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SS.UEditorConfig
{
    public class UEditorConfig : PluginBase
    {
        private static Dictionary<string, Interceptor> Interceptors = new Dictionary<string, Interceptor>();
        
        public override void Startup(IService service)
        {
            Interceptors["UEditorConfig"] = new Interceptor(
                typeof(SiteServer.CMS.UEditor.Config).GetMethod("BuildItems", BindingFlags.Static | BindingFlags.NonPublic),
                typeof(UEditorConfig).GetMethod("BuildItems"));
        }

        public static JObject BuildItems()
        {
            var file = Path.Combine(Context.Environment.PhysicalApplicationPath, @"SiteServer\assets\ueditor\config.json");
            return Context.UtilsApi.JsonDeserialize<dynamic>(File.ReadAllText(file));
        }
    }
}
