using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    public class EditorJsConfig
    {
        public IEnumerable<EditorJsPlugin> Plugins { get; set; }

        public EditorJsContent Content { get; set; }

        public string EditorID { get; set; }

        public bool AutoFocus { get; set; }

        public string Placeholder { get; set; }

        public string LogLevel { get; set; }

        public EditorJsConfig(Func<EditorJsPluginBuilder, EditorJsPluginBuilder> plugins)
        {
            var pb = plugins(new EditorJsPluginBuilder());

            Plugins = pb.GetPlugins(); 
        }
    }
}
