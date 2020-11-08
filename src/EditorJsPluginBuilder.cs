using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    public class EditorJsPluginBuilder
    {
        List<EditorJsPlugin> plugins = new List<EditorJsPlugin>();

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

        public EditorJsPluginBuilder Paragraph(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("paragraph", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Header(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("header", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Code(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("code", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Checklist(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("checklist", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Link(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("link", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder List(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("list", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Marker(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("marker", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Quote(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("quote", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder SimpleImage(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("image", inlineToolbar, config);

            return this;
        }

        public EditorJsPluginBuilder Warning(bool inlineToolbar = true, dynamic config = null)
        {
            AddPlugin("warning", inlineToolbar, config);

            return this;
        }

        public IEnumerable<EditorJsPlugin> GetPlugins()
        {
            return plugins;
        }

        private void AddPlugin(string name, bool inlineToolbar = true, dynamic config = null)
        {
            this.plugins.Add(new EditorJsPlugin(name)
            {
                Config = config,
                InlineToolbar = inlineToolbar
            });
        }
    }
}
