Pour créer un service : https://docs.microsoft.com/en-us/dotnet/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer




ATTENTION: pour créer automatiquement le windows service l'application console dotnet (exemple : console app .NET Framework) doit être du même type que l'application windows service (exemple: windows service .NET Framework 4.7.2).

(ATTENTION: l'encart "servicename" sera celui qui sera visible.)
ATTENTION: choose View Designer et right click sur le background permet de choisir Add Instaler.

cela cree deux objects servicInstaller (channger le nom du service et metter start automatic)
et serviceProcessInsaller (la important de metter Account = LocalSytem)




Pour instaler > search "developer powerShell for visual studio" in windows task bar and choose run as administrator.
Taper > installutil MyNewService.exe > Press Enter


Vous pouvez à présent l'activer avec l'utilitaire services app (taper "services" dans la barre de recherche windows)










