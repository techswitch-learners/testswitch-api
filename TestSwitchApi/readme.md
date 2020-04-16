# TestSwitch API
This is the API for the TestSwitch.

### Linting
We're using StyleCop to lint the project.  
Some StyleCop rules are disabled in the .ruleset files in each project.

I'd recommend using auto-format (`ctrl+shift+L` is the default Rider command, or go to Code > Reformat Code) to auto-format files if StyleCop is complaining about formatting.
  
If Rider disagrees with StyleCop as to how to format code, make sure that Rider's code style settings match StyleCop's settings (Settings (`ctrl+shift+s`) > Editor > Code Style > C#).
  
I've made code style settings that seem to agree with StyleCop which are encapsulated in TestSwitchApi.sln.DotSettings.  
This is checked into git, so it should take effect across the whole team.