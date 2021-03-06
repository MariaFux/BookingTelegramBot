# BookingTelegramBot

BookingTelegramBot - an application for booking rooms for mettings

## Quick start

Clone the repo:

```bash
 $ git clone https://github.com/MariaFux/BookingTelegramBot.git
```

## Steps to reproduce

1.  Create your bot
2.  Install and run ngrok
3.  Replace application data with yours
4.  Set Webhook
5.  Migrations
6.  Fill tables in database (i use SQL Server with SSMS)
7.  Start application
8.  Fill tables with BookingTelegramBot if you didn't fill them earlier **(available only for admin)**
9.  Try all commands of bot 

### 1.  Create your bot

1.  Open Telegram
2.  Search @BotFather
3.  Type /newbot
4.  Type the name of your bot
5.  Then the username of your bot. It must end in _bot_ (example_bot)
6.  Take the **TELEGRAM_BOT_TOKEN** for later use

### 2.  Install and run ngrok

To interact with telegram bot we need ngrok.

Ngrok - secure introspectable tunnels to localhost webhook development tool and debugging tool.

1.  Link for downloading - [Ngrok](https://ngrok.com/download)
2.  Unzip the atchive
3.  Then you need to create an account to get the **YOUR_AUTHTOKEN**
4.  Run ngrok.exe
5.  Install your Authtoken
`ngrok authtoken <YOUR_AUTHTOKEN>`
6.  Find your port in BookingTelegramBot->Properties->launchSettings.json
7.  Then you need forward to the default http port on localhost
`ngrok http 127.0.0.1:<YOUR_PORT>`
8.  UI will be displayed in your terminal
9.  Take the second URL (with https) for later use

### 3.  Replace application data with yours

1.  Follow BookingTelegramBot->appsettings.json and change YOUR_SERVER_NAME and DATABASE_NAME in ConnectionStrings section 
`"DbConstr": "Server=<YOUR_SERVER_NAME>;Database=<DATABASE_NAME>;Integrated Security=SSPI;"`

>If you will change "DbConstr" on another name, don't forget to change it in Startup.cs 
`var ConnectionString = Configuration.GetConnectionString("DbConstr");`

2.  Follow C:\Users\<UserName>\AppData\Roaming\Microsoft\UserSecrets and add folder with name _4f918b6e-75d9-42aa-ba9c-887a033cd3bd_ like in `<UserSecretsId>4f918b6e-75d9-42aa-ba9c-887a033cd3bd</UserSecretsId>` tag from BookingTelegramBot.csproj
3.  Then add to the new folder **secrets.json** file
4.  Fill sercrets.json:

```
{
  "BotSettings": {
    "Token": "<TELEGRAM_BOT_TOKEN>",
    "Name": "<BOT_NAME>",
    "BaseUrl": "<URL_FROM_NGROK>/"
  }
}
```

### 4.  Set Webhook

Follow `https://api.telegram.org/bot<TELEGRAM_BOT_TOKEN>/setWebhook?url=<URL_FROM_NGROK>` and webhook will be set.

### 5.  Migrations

1. Follow _Tools->NuGet Package Manager->Package Manager Console_ in Visual Studio
2. At the top of the _Package Manager Console_ set as _Default project_: **BookingTelegramot.DAL**
3. Open _Migrations_ folder in IDE (BookingTelegramot.DAL->Migrations)
4. For each top-down migration of _Mifrations_ folder, type a `update-database <MigrationName>` in the _Package Manager Console_ (update-database FirstMigration and etc.)

### 6.  Fill tables in database

Open SSMS(SQL Server Managment Studio) and fill tables with suitable data. For your **TelegramId** set admin role to be able to use admin commands in BookingTelegramBot.

### 7.  Start application

1. Run application
2. In the browser window that appears enter URL localhost:port_/api/message/get_
3. The bot will start waiting for the command

:exclamation: **Important**: 

Under IIS the application needs to be **always on** because it uses a service with timer and iterruption can slow down the application cycle!

### 8.  Fill tables with BookingTelegramBot if you didn't fill them earlier

If you didn't fill tables before start application you can do it with **BookingTelegramot**. But you must have admin rights.

#### Wish you success!