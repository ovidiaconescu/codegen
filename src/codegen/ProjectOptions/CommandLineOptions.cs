using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace codegen.ProjectOptions
{
    public class CommandLineOptions
    {
        [Option('f', "folder", Required = false, HelpText = "The path to the base folder where the templates and results should stay")]
        public string Folder { get; set; }

        [Option('p', "project", Required = true, HelpText = "The relative path from the base folder to the json file that contains the template file definitions")]
        public string ProjectPath { get; set; }

        [Option('r', "result", Required = true, HelpText = "The relative path from base folder to the folder that will contain the resulted files")]
        public string ResultPath { get; set; }


        [Option('n', "namespace", Default = "CodeGenSample", Required = false, HelpText = "The Namespace for the class"  )]
        public string Namespace { get; set; }

        [Option('d', "dbcontext", Default = "DbContext", Required = false, HelpText = "The DbContext for that will be referenced in the repository class")]
        public string Context { get; set; }


        [Option('c', "class", Default = "Organization", Required = false, HelpText = "The POCO class name. Eg: Organization")]
        public string Class { get; set; }

        [Option("classpluralized", Required = false, HelpText = "The POCO class name in pluralized format. Eg: Organizations")]
        public string ClassPluralized { get; set; }


        [Option('o', "object", Default = "org", Required = true, HelpText = "The POCO object name. Eg: org")]
        public string Object { get; set; }

        [Option("objectpluralized", Required = false, HelpText = "The POCO object name in pluralized format. Eg: orgs")]
        public string ObjectPluralized { get; set; }
    }
}
