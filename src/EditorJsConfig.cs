using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    /// <summary>
    /// Configuration of EditorJS
    /// </summary>
    public class EditorJsConfig
    {
        /// <summary>
        /// List of all plugins to load.
        /// </summary>
        public IEnumerable<EditorJsPlugin> Plugins { get; set; }

        /// <summary>
        /// Content to be pre-loaded to the editor.
        /// </summary>
        public EditorJsContent Content { get; set; }

        /// <summary>
        /// ID of the editor control.
        /// </summary>
        public string EditorID { get; set; }

        /// <summary>
        /// Determines whether the editor should load focused.
        /// </summary>
        public bool AutoFocus { get; set; }

        /// <summary>
        /// Placeholder to show when the content is empty.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Sets the log level for consol output.
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="plugins">Fluent plugin builder</param>
        public EditorJsConfig(Func<EditorJsPluginBuilder, EditorJsPluginBuilder> plugins)
        {
            var pb = plugins(new EditorJsPluginBuilder());

            Plugins = pb.GetPlugins(); 
        }
    }
}
