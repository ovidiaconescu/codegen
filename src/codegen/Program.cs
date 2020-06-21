using codegen.ProjectOptions;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace codegen
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        static void RunOptions(CommandLineOptions opts)
        {
            opts.ProjectPath = Path.GetFullPath(opts.ProjectPath);
            opts.ResultPath = Path.GetFullPath(opts.ResultPath);

            if (string.IsNullOrWhiteSpace(opts.ClassPluralized))
                opts.ClassPluralized = opts.Class + "s";

            if (string.IsNullOrWhiteSpace(opts.ObjectPluralized))
                opts.ObjectPluralized = opts.Object + "s";

            if (!File.Exists(opts.ProjectPath))
            {
                Console.WriteLine("Invalid Project File");
                return;
            }

            var transform = new Transform.TransformProject(opts);
            transform.Run();

            Console.WriteLine("Code Gen Complete");
        }

        static void HandleParseError(IEnumerable<Error> errors)
        {
            foreach (var err in errors)
            {
                Console.WriteLine(err.Tag.ToString());
            }
        }
    }
}
