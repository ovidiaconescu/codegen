using codegen.ProjectOptions;
using System;
using System.IO;
using System.Text.Json;

namespace codegen.Transform
{
    public class TransformProject
    {
        Project _project;
        CommandLineOptions _opts;

        public TransformProject(CommandLineOptions opts)
        {
            _opts = opts;
            _project = JsonSerializer.Deserialize<Project>(File.ReadAllText(opts.ProjectPath));
        }

        public void Run()
        {
            var resultDir = createResultFolder(_opts, _project);
            var templatesFolder = Path.GetDirectoryName(_opts.ProjectPath);

            foreach (var f in _project.Files)
            {
                var template = process(_opts, File.ReadAllText(Path.Combine(templatesFolder, f.Key)));
                var templateFile = process(_opts, f.Value.Name);

                var resultPath = Path.Combine(resultDir.FullName, templateFile);

                File.WriteAllText(resultPath, template);

                Console.WriteLine($"Processed {f.Key} to {templateFile}");
            }
        }

        private DirectoryInfo createResultFolder(CommandLineOptions opts, Project project)
        {
            DirectoryInfo dir = new DirectoryInfo(opts.ResultPath);

            if (!dir.Exists)
                dir = Directory.CreateDirectory(opts.ResultPath);

            string name = project.Name;
            string current = name;

            int i = 0;
            while (Directory.Exists(Path.Combine(opts.ResultPath, current)))
            {
                i++;
                current =$"{name} {i}";
            }

            return Directory.CreateDirectory(Path.Combine(opts.ResultPath, current));
        }

        private string process(CommandLineOptions opts, string template)
        {
            return template
                .Replace("%%=Namespace%%", opts.Namespace)
                .Replace("%%=Class%%", opts.Class)
                .Replace("%%=ClassPluralized%%", opts.ClassPluralized)
                .Replace("%%=Object%%", opts.Object)
                .Replace("%%=ObjectPluralized%%", opts.ObjectPluralized);    
        }
    }
}
