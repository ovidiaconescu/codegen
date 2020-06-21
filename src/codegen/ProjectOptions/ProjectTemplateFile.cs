using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace codegen.ProjectOptions
{
    public class ProjectTemplateFile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isUnitTest")]
        public bool IsUnitTest { get; set; }
    }
}
