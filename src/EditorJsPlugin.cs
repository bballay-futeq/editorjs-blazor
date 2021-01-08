using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    /// <summary>
    /// Represents an EditorJS plugin.
    /// </summary>
    public class EditorJsPlugin
    {
        /// <summary>
        /// Name of the plugin.
        /// </summary>
        public string PluginName { get; set; }

        /// <summary>
        /// Determines whether the plugin should show on toolbar.
        /// </summary>
        public bool InlineToolbar { get; set; } = true;

        /// <summary>
        /// Configuration object passed to EditorJS plugin.
        /// </summary>
        public dynamic Config { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pluginName">Name of the plugin</param>
        public EditorJsPlugin(string pluginName)
        {
            PluginName = pluginName;
        }
    }
}
