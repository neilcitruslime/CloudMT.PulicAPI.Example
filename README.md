### Simple Cloud MT Example 

This project is provides a simple example to retrieve items or categories from the Cloud MT API using C#. 
The API documentation can be found at https://api.citruslime.com.

## Prerequisites

You will need the DotNet 8 SDK installed. https://dotnet.microsoft.com/en-us/download/dotnet/8.0

### Getting Started

To get started, you will need to create an account with Citrus-Lime Cloud MT. 

The username and password can be passed in as command line arguments or the application will request them when it is run.

```
dotnet run myusername mypassword
```

The item keys are retrieved and then chucked into 100 item batches. The batches are then sent to the API and the results are written to the console.
The application will output the items to a CSV file with the name 'items.csv' in the same directory as the application binarys files and write this file location to the console.

```
e.g.
File saved to '/Users/neilmcquillan/Downloads/CloudMT.PublicAPI.Example/bin/Debug/net8.0/items.csv'
```

The class CsvModel.cs can be extended to add extra fields to the CSV file and modifying the line.

```
records.Add(new CsvModel() {Id = item.Id, LookupCode = item.LookupCode, Name = item.Name, Active = Convert.ToBoolean(item.Active)});
```

