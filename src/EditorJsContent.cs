using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EditorJSBlazor
{
    public class EditorJsBlock
    {
        public string Type { get; set; }

        public dynamic Data { get; set; }
    }

    public class EditorJsContent
    {
        public string Version { get; set; }

        public long Time { get; set; }

        public List<EditorJsBlock> Blocks { get; set; }

        public static EditorJsContent FromString(string content)
        {
            return JsonConvert.DeserializeObject<EditorJsContent>(content);
        }
    }
}
