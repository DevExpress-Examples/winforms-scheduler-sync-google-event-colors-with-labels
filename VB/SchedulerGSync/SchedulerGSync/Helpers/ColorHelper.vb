Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Linq

Namespace SchedulerGSync
	Public Module ColorHelper
		Public Function FromString(ByVal stringValue As String) As Color
			If stringValue.StartsWith("#") Then
				If stringValue.Length = 7 Then
					Dim colorHexValue As String = stringValue.Substring(1, 6)
					Dim r As Integer = Integer.Parse(stringValue.Substring(1, 2), NumberStyles.HexNumber)
					Dim g As Integer = Integer.Parse(stringValue.Substring(3, 2), NumberStyles.HexNumber)
					Dim b As Integer = Integer.Parse(stringValue.Substring(5, 2), NumberStyles.HexNumber)
					Return Color.FromArgb(r, g, b)
				End If
				Return Color.Pink
			Else
				Return Color.FromName(stringValue)
			End If
		End Function
	End Module
End Namespace
