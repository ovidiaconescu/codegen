# codegen
The `codegen` tool takes the tamplates from the /templates folder and generates classes needed for .net core projects.

By default it includes tampltes for an API based project that contains Resources, Services, Controllers and Unit Tests.

## Usage Example
`codegen.exe -p ../../api.json -r ../../result -n MyNamespace -d MyDbContext -c Organization -o org`

## Command Line Arguments
>       -p, --project         Required. The path to the json file that contains the template file definitions
>       -r, --result          Required. The path to the folder that will contain the resulted files
>       -n, --namespace       (Default: CodeGenSample) The Namespace for the class
>       -d, --dbcontext       (Default: DbContext) The DbContext for that will be referenced in the repository class
>       -c, --class           (Default: Organization) The POCO class name. Eg: Organization
>       --classpluralized     The POCO class name in pluralized format. Eg: Organizations
>       -o, --object          Required. (Default: org) The POCO object name. Eg: org
>       --objectpluralized    The POCO object name in pluralized format. Eg: orgs
>       --help                Display this help screen.
>       --version             Display version information.

