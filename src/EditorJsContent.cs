using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    /// <summary>
    /// Represents an EditorJS block.
    /// </summary>
    public class EditorJsBlock
    {
        public string Type { get; set; }

        public dynamic Data { get; set; }
    }

    /// <summary>
    /// Represents an EditorJS content.
    /// </summary>
    public class EditorJsContent
    {
        /// <summary>
        /// Content version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Time when block was created.
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Blocks compoing the content.
        /// </summary>
        public List<EditorJsBlock> Blocks { get; set; }

        /// <summary>
        /// Parses the <see cref="EditorJsContent"/> from string.
        /// </summary>
        /// <param name="content">String Content representation.</param>
        /// <returns></returns>
        public static EditorJsContent FromString(string content)
        {
            return JsonConvert.DeserializeObject<EditorJsContent>(content);
        }
    }
}
