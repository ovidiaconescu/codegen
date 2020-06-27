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

        [JsonPropertyName("templatePath")]
        [DefaultValue("")]
        public string TemplatePath { get; set; } = "";

        [JsonPropertyName("resultPath")]
        [DefaultValue("")]
        public string ResultPath { get; set; } = "";


        [JsonPropertyName("isUnitTest")]
        [DefaultValue(false)]
        public bool IsUnitTest { get; set; } = false;
    }
}
