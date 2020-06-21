using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace codegen.ProjectOptions
{
    public class ProjectTemplateFile
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("path")]
        [DefaultValue("")]
        public string Path { get; set; } = "";

        [JsonPropertyName("isUnitTest")]
        [DefaultValue(false)]
        public bool IsUnitTest { get; set; } = false;
    }
}
