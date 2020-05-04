# TestSwitch API
This is the API for the TestSwitch.

## TestSwitch Database
### Prerequisite
1. Download PostgreSQL installer and install PostgreSQL
2. Download the InitialSchemaSetup.sql from  GitHub DataMigrations folder to a folder on your local client.

### To create the TestSwitch database
1. Open PostgreSQL SQL Shell (psql)
2. Provide all necessary information such as the server, database, port, username, and password that you entered during installing the PostgreSQL. To accept the default, you can press Enter.
3. Enter the command psql \i (your local folder path)/InitialSchemaSetup.sql

### Application changes
1. Insert the database password into the connection string in appsettings.json.
2. Ensure the port specified in the connection string is the one your database is running on.

### Creating an Admin user
1. On startup the Program looks for two environment variables called DEFAULTADMINEMAIL and DEFAULTADMINPASSWORD to create an admin user if no admin user already exists. If you are starting the program for the first time then  

## Linting
We're using StyleCop to lint the project.  
Some StyleCop rules are disabled in the .ruleset files in each project.

I'd recommend using auto-format (`ctrl+alt+L` is the default Rider command, or go to Code > Reformat Code) to auto-format files if StyleCop is complaining about formatting.  
I'd recommend using auto-optimise-imports (`ctrl+alt+O` default, or go to Code > Optimise imports) to remove unused using directives and fix any StyleCop import-ordering violations.
  
If Rider disagrees with StyleCop as to how to format code, make sure that Rider's code style settings match StyleCop's settings (Settings (`ctrl+alt+S`) > Editor > Code Style > C#).
  
I've made code style settings that seem to agree with StyleCop which are encapsulated in TestSwitchApi.sln.DotSettings.  
This is checked into git, so it should take effect across the whole team.
