Imports Microsoft.EntityFrameworkCore
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SchedulerGSync.DAL
	Public Class SchedulerGSyncDbContext
		Inherits DbContext

		Public Shared ReadOnly DBFileName As String = $"{NameOf(SchedulerGSync)}.sqlite"

		Public Property AppointmentObjects() As DbSet(Of AppointmentObject)

		Protected Overrides Sub OnConfiguring(ByVal optionsBuilder As DbContextOptionsBuilder)
			optionsBuilder.UseSqlite($"Filename={DBFileName}")
		End Sub
	End Class
End Namespace
