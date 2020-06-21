using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace codegen.ProjectOptions
{
    public class Project
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [Required]
        [JsonPropertyName("files")]      
        public Dictionary<string, ProjectTemplateFile> Files { get; set; }
    }
}
