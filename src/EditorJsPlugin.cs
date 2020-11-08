using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    public class EditorJsPlugin
    {
        public string PluginName { get; set; }

        public bool InlineToolbar { get; set; } = true;

        public dynamic Config { get; set; }

        public EditorJsPlugin(string pluginName)
        {
            PluginName = pluginName;
        }
    }
}
