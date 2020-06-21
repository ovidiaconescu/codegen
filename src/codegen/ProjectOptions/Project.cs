using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace codegen.ProjectOptions
{
    public class Project
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("files")]
        public Dictionary<string, ProjectTemplateFile> Files { get; set; }
    }
}
