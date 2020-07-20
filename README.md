# How it works?

Telegram bot that will help you to find a flat.
It send requests in custom interval and send you a Telegram message if there new flats.

## Usage
First you need to update appsettings.json file with your configuration.

#### Connection string

`"ConnectionStrings"` - this is your connection string to database with flats.

##### Example

```json
"ConnectionStrings": {"Default": "data source=(local);Initial Catalog=Kuzya;Integrated Security=True"}
```

#### NLog

`"targets"` - just enter you targets for logging (Console, ColoredConsole, File ex.)

`"rules"` - your logic what exceptions should be logged where (Info to Console,  Error to ColoredConsole, Fatal to File ex.)

##### Example
```js
"NLog": {
    "targets": {
      "file": {
        "type": "File",
        "fileName": "monitoring.log" 
      }
    },
    "rules": [
      {
        "logger": "*",
        "minLevel": "Info",
        "writeTo": "file"
      }
    ]
  }
```

#### Monitoring Settings

```js
"MonitoringSettings": {
    "Sites": []
}
```

Sites - collection of sites will be monitored. See site configuration below.

```js
{
   "Name": "Site name", // Site name
   "Url": "Site url",
   "DeserializerType": "Type of class that will deseraialize response data",
   "IntervalInSeconds": 60, //Interval between monitoring requests.
   "Parameters": [ // Collection of parameters will be transformed to query string
    {
        "Alias": "Nice readable name for user",
        "Name": "Parameter name",
        "Value": "Parameter value"
    }
  ]
}
```

#### Bot Settings
Settings of your telegram bot that will send you messages with new flats.

```js
"BotSettings": {
    "ChatId": 12345678, // Id of chat for sending messages
    "Name": "Kuzya", // Your bot name
    "Token": "123token" // Your bot token (write BotFather to create new bot)
}
```
