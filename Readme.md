<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/152613217/18.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830507)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WinForms Scheduler - Synchronize colors of Google Events with appointment labels

In this example, the WinForms Scheduler is bound to an [Entity Framework Core data source](https://documentation.devexpress.com/WindowsForms/118049/Common-Features/Data-Binding/Binding-to-Entity-Framework-Core).

To run the sample, do the following:

* Go to "Project > Manage NuGet packages..." to re-install EF Core and Google Calendar API packages used in the example.
* Replace the contents of the *client_secret.json* file with contents of your own credentials file. You can download this file at [.NET Quickstart](https://developers.google.com/calendar/quickstart/dotnet).

The application will ask you to log in with a Google account.

To select a Google Calendar that you want to sync with the Scheduler control, click the *Options* Ribbon button. To manually start synchronization click *Sync*.

A custom `UpdateLabels` mehod retrieves colors used by Google Events and uses them to populate the Scheduler Label collection.

Colors are synchronized on `AppointmentValuesRequested` / `EventValuesRequested` events. These events occur when the `DXGoogleCalendarSync` needs to retrieve appointment data and assign it to a paired Google Event, or vice versa.
