# TestSwitch API
This is the API for the TestSwitch.

### Linting
We're using StyleCop to lint the project.  
Some StyleCop rules are disabled in the .ruleset files in each project. 
 
Compile-time warnings are set to be treated as errors in the csproj files.  
This is to ensure Circle CI fails the build if there are lint errors.  
This can be changed during dev if it's a pain by setting the value of `TreatWarningsAsErrors` to false.

I'd recommend using auto-format (`ctrl+shift+L` is the default Rider command, or go to Code > Reformat Code) to auto-format files if StyleCop is complaining about formatting.  
If Rider disagrees with StyleCop as to how to format code, make sure that Rider's code style settings match StyleCop's settings (Settings (`ctrl+shift+s`) > Editor > Code Style > C#).