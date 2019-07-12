# How to synchronize Google Event colors with Scheduler Labels

In this example, the Scheduler is bound to an [Entity Framework Core data source](https://documentation.devexpress.com/WindowsForms/118049/Common-Features/Data-Binding/Binding-to-Entity-Framework-Core).

To run the sample, you need to:
* go to "Project | Manage NuGet packages..." to re-install EF Core and Google Calendar API packages used in this sample;
* replace the contents of the *client_secret.json* file with a contents of your own credentials file. You can download this file at the
[.NET Quickstart](https://developers.google.com/calendar/quickstart/dotnet) Google help page.

At the first launch, the application will ask you to log in with any Google account.

To select a Google Calendar that you want to sync with the Scheduler, click the *Options* Ribbon button. To manually start synchronization click *Sync*.

On every synchronization, the custom **UpdateLabels** mehod retrieves colors used by Google Events and uses them to populate the Scheduler Label collection.

Colors are synchronized on the **AppointmentValuesRequested** / **EventValuesRequested** events.
These events occur when the **DXGoogleCalendarSync** needs to retrieve Appointment data and assign it to a paired Event, or vice versa.
