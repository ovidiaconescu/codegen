# codegen
The `codegen` tool takes the tamplates from the /templates folder and generates classes needed for your .net core project.
By default it includes templates for an API based project that contains Resources, Services, Controllers and Unit Tests.

## Usage Example
`codegen.exe --f ../../ --p api.json --r result --n MyNamespace --d MyDbContext --c Organization --o org`

## Command Line Arguments
>       -f, --folder		  Required. The path to the base folder where the templates and results should stay
>       -p, --project         Required. The relative path from the base folder to the json file that contains the template file definitions
>       -r, --result          Required. The relative path from base folder to the folder that will contain the resulted files
>       -n, --namespace       (Default: CodeGenSample) The Namespace for the class
>       -d, --dbcontext       (Default: DbContext) The DbContext for that will be referenced in the repository class
>       -c, --class           (Default: Organization) The POCO class name. Eg: Organization
>       --classpluralized     The POCO class name in pluralized format. Eg: Organizations
>       -o, --object          Required. (Default: org) The POCO object name. Eg: org
>       --objectpluralized    The POCO object name in pluralized format. Eg: orgs
>       --help                Display this help screen.
>       --version             Display version information.

