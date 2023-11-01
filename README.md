## A very Fast, Fully automated and easy to setup ORM for SQLite on .Net Framework with many features:

- Supports out of the box: SqLite.
- Auto Create and Update Database on Startup.
- Tables are based on the Entities.
- All Tables have Autoincrement and Integer Primary Key.
- Has a DataProvider with many ready methods to interact with the database.
- Has ExecutionProvider for custom SQL commands.
- Uses Property Attributes to declare, Foreign Keys , Unique constraints and more.
- Can Perform Inner Join across multiple tables without writing SQL Commands.
- Direct Mapping Entities to DTO on Joins.
- Interface for adding Default Data on the Creation of the database.
- Interface to Store Joins as StoredViews on the startup of the Application.
- Can Execute stored Views directly from the DataProvider.

Port to .Net Framework from the Original BlackHole.Core.ORM for dotnet Core => [versions (6.1.2 / 7.1.2 / 8.1.0-rc2)](https://www.nuget.org/packages/BlackHole.Core.ORM/8.1.0-rc.2)

### Version: v4.1.1

### Quick Start:

- Download and import <b>BlackHole.Net.Lite package</b> from Nuget.org

- On Program.cs that runs on the Start of your Project add <b>'using BlackHole.Configuration'</b>
  .On 'Main' void add <b>BlackHoleConfiguration.SuperNova('path of the database', 'databaseName');</b>

  <b> Tip: you only need to run 'SuperNova' Once on the start of the Application</b>

- Create some class scripts in any folder that Inherit from the class <b>'BlackHoleEntity'</b> and Add properties to them, <b>'using BlackHole.Entities'</b>.

  <b> Tip: a Property of type (int) already exists in a BlackHoleEntity and it's the Primary Key of the Table with autoincrement</b>

- Add Attributes to the Properties of your Entities to specify the constraints of each column on the Table that will be created. 
  <b>'[ForeignKey(typeof(Entity), nullability)]' , '[NotNullable]', [Unique(int)] and '[VarCharSize(int)]</b>

  <b> Tip: You can also use '[UseActivator]' Attribute on your BlackHoleEntity, to take advantage of the 'Inactive' column in case you need to keep the
  data after deleting some lines in the Table </b>

- Create class scripts in any folder, that inherit from <b>'IBHInitialData'</b> and <b>'IBHInitialViews'</b> interfaces if you want to have default data and stored views
  inserted on the creation of the database.
  
 - Ready! when you run the Game, the database and the Tables will be automatically created. You can then use the <b>'BHDataProvider'</b> class to interact with
   the database, <b>'using BlackHole.Core'</b> namespace on any script.

   Example for ready methods: BHDataProvider.For<'EntityType'>.GetEntryById(int Id);

   Example for custom command:  BHDataProvider.Command.Query<'EntityType'>( "select * from EntityType");

- Additional Features

   <b> Feature: All methods have additional overload that takes a disposable transaction object 'BHTransaction' </b>
   
   <b> Feature: BlackHole provides Dynamic Parameters with the class 'BHParameters' that can be used with the custom Commands </b>

   <b> Feature: BlackHole has a custom embedded LinQ which translates Expressions directly to SQL Commands. 'BHDataProvider.For<'EntityType'>.GetEntryWhere( x => x.Id == 5)' </b>

   <b> Feature: BlackHole Provides the class of 'BlackHoleDto' which is a data transfer object that can be used to map multiple table properties in a joins sequence </b>

   <b> Feature: BlackHole can perform Inner Join across multiple tables using the 'BHDataProvider.Join<'Entity, OtherEntity'>.On(x => x.Id, x => x.FirstEntityId)....Then().ExecuteQuery<'Dto'>()' </b>

   <b> Feature: There are Popular SQL functions included that can be used with the embedded LinQ 'SqlLike', 'SqlAverage' , 'SqlMin', 'SqlEqualsTo', 'Replace', 'Contains'... and more </b>

   <b> Feature: BlackHole has a Logger Service which creates a 'Logs' folder in the selected database path and is Logging every SQL error in .txt files. The files are deleted on the start of the
application to keep the device's storage clean.
