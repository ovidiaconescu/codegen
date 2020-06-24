using codegen.ProjectOptions;
using System;
using System.IO;
using System.Text.Json;

namespace codegen.Transform
{
    public class TransformProject
    {
        public void Run(CommandLineOptions opts)
        {
            var project = JsonSerializer.Deserialize<Project>(File.ReadAllText(opts.ProjectPath));

            var templatesFolder = Path.GetDirectoryName(opts.ProjectPath);
            var resultPath = resultFolderPath(opts, project);

            foreach (var f in project.Files)
            {
                var template = File.ReadAllText(Path.Combine(templatesFolder, f.Value.Path, f.Key));
                template = processTemplatedText(opts, template);
                var templateFileName = processTemplatedText(opts, f.Value.Name);

                Directory.CreateDirectory(Path.Combine(resultPath, f.Value.Path));

                File.WriteAllText(Path.Combine(resultPath, f.Value.Path, templateFileName), template);
                Console.WriteLine($"Processed {f.Key} to {f.Value.Path}/{templateFileName}");
            }
        }

        private string resultFolderPath(CommandLineOptions opts, Project project)
        {
            string current = $"{project.Name}_{opts.Class}";
            int i = 0;

            while (Directory.Exists(Path.Combine(opts.ResultPath, current)))
            {
                i++;
                current =$"{project.Name}_{opts.Class}_{i}";
            }

            var resultPath = Path.Combine(opts.ResultPath, current);
            Directory.CreateDirectory(resultPath);

            Console.WriteLine($"Saving results in {resultPath}");            
            return resultPath;
        }

        private string processTemplatedText(CommandLineOptions opts, string template)
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
