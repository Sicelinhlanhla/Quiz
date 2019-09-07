# Quiz
simple C#   LMS


# How to run the application:
There will be no build errors, but when you run it, it might return an error that specifies
'Could not find part of path '...\bin\roslyn\csc.exe'.
This requires that you run the following coommand on the package manager console:
Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform


# If .mdf file error occurs
The 'App_Data' folder might or might not show on your cloned/ downloaded solution
but would still return a '... cannot find specified file' error.

Todo if the folder shows in the solution: 1. exclude the folder from the solution,
2. build your solution and then 3. click 'Add', navigate to 'Add Asp.Net Folder',
select the 'App_Data' folder, build your solution and then debug the solution again.

If the folder does not exist in the solution, following the whole of step 3 above.
