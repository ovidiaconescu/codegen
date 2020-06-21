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
            var templatesFolder = Path.GetDirectoryName(_opts.ProjectPath);
            var resultDir = createResultFolder(_opts, _project);

            foreach (var f in _project.Files)
            {
                var template = File.ReadAllText(Path.Combine(templatesFolder, f.Value.Path, f.Key));
                template = process(_opts, template);
                var templateFileName = process(_opts, f.Value.Name);

                var resultFolderPath = Path.Combine(resultDir.FullName, f.Value.Path);
                DirectoryInfo resultSubDir = new DirectoryInfo(resultFolderPath);
                if (!resultSubDir.Exists)
                    resultSubDir = Directory.CreateDirectory(resultFolderPath);

                File.WriteAllText(Path.Combine(resultFolderPath, templateFileName), template);
                Console.WriteLine($"Processed {f.Key} to {templateFileName}");
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
