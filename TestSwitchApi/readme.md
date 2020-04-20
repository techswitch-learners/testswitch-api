# TestSwitch API
This is the API for the TestSwitch.

## TestSwitch Database
### Prerequisite
1. Install PostgreSQL
2. Download the InitialSchemaSetup.sql from  GitHub DataMigrations folder to a folder on your local client.

### To install
1. Open PostgreSQL SQL Shell (psql)
2. Click enter on the keyboard to go with default server: localhost, default database:postgres, default port:5432, default username:postgres
3. Enter the password for the username:postgres
4. Enter the command psql \i (your local folder path)/InitialSchemaSetup.sql

### Application changes
1. Insert the database password into the connection string in appsettings.json.
2. Ensure the port specified in the connection string is the one your database is running on.

## Linting
We're using StyleCop to lint the project.  
Some StyleCop rules are disabled in the .ruleset files in each project.

I'd recommend using auto-format (`ctrl+shift+L` is the default Rider command, or go to Code > Reformat Code) to auto-format files if StyleCop is complaining about formatting.
  
If Rider disagrees with StyleCop as to how to format code, make sure that Rider's code style settings match StyleCop's settings (Settings (`ctrl+shift+s`) > Editor > Code Style > C#).
  
I've made code style settings that seem to agree with StyleCop which are encapsulated in TestSwitchApi.sln.DotSettings.  
This is checked into git, so it should take effect across the whole team.
