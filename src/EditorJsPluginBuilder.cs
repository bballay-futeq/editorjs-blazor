using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    /// <summary>
    /// Enables fluent registering of plugins.
    /// </summary>
    public class EditorJsPluginBuilder
    {
        private List<EditorJsPlugin> _plugins = new List<EditorJsPlugin>();

        /// <summary>
        /// Inlude all available plugins.
        /// </summary>
        public EditorJsPluginBuilder All()
        {
            Paragraph();
            Header();
            Code();
            Checklist();
            Link();
            List();
            Marker();
            Quote();
            SimpleImage();
            Warning();

            return this;
        }

        /// <summary>
        /// Adds a paragraph plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Paragraph(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("paragraph", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a header plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Header(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("header", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a code plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Code(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("code", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a checklist plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Checklist(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("checklist", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a link plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Link(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("link", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a list plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder List(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("list", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a marker plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        /// <returns></returns>
        public EditorJsPluginBuilder Marker(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("marker", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds an quote plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        public EditorJsPluginBuilder Quote(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("quote", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a simple image plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        public EditorJsPluginBuilder SimpleImage(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("image", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Adds a warning plugin.
        /// </summary>
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        public EditorJsPluginBuilder Warning(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("warning", inlineToolbar, config);

            return this;
        }

        /// <summary>
        /// Retrieve a list of plugins added to the builder.
        /// </summary>
        /// <returns>A list of plugins registered.</returns>
        public IEnumerable<EditorJsPlugin> GetPlugins()
        {
            return _plugins;
        }

        /// <summary>
        /// Adds a plugin with specified name.
        /// </summary>
        /// <param name="name">Name of the plugin</param>s
        /// <param name="inlineToolbar">Show on inline toolbr</param>
        /// <param name="config">Configuration of the EditorJS plugin</param>
        private void AddPlugin(string name, bool inlineToolbar = true, dynamic config = null)
        {
            this._plugins.Add(new EditorJsPlugin(name)
            {
                Config = config,
                InlineToolbar = inlineToolbar
            });
        }
    }
}
