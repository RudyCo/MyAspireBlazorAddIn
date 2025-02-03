# MyAspireBlazorAddIn
- This sample was created from [.NET Aspire Starter](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio) and sample from [Blazor Webassembly Excel add-in](https://github.com/OfficeDev/Office-Add-in-samples/tree/main/Samples/blazor-add-in/excel-blazor-add-in).
- Blazor Web App Call web API (Weather) [sample app](https://github.com/dotnet/blazor-samples/tree/main/8.0/BlazorWebAppCallWebApi_Weather) was used to consume data from server API.
- TypeScript support.

# Changes
- Keep only the ```https``` profile.
- Add a new Blazor Web Application for the Excel Add-in.

# Startup from Visual Studio
![Startup](startup.png)

# Issue(s)
- Ugly hack in the code because of unfixed bug in Office JS. See this issue: [Office.js-specific web API behavior](https://learn.microsoft.com/en-us/office/dev/add-ins/develop/referencing-the-javascript-api-for-office-library-from-its-cdn#officejs-specific-web-api-behavior)
