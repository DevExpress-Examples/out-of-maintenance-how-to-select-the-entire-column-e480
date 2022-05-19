Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace Q184421
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim ds As List(Of DataObject) = New List(Of DataObject)()
			For m As Integer = 1 To 12
				For p As Integer = 1 To 9
					ds.Add(New DataObject(m, p * m, "Product " & p.ToString()))
				Next p
			Next m
			pivotGridControl1.Fields.AddDataSourceColumn("Month", PivotArea.ColumnArea)
			pivotGridControl1.Fields.AddDataSourceColumn("Sales", PivotArea.DataArea)
			pivotGridControl1.Fields.AddDataSourceColumn("ProductName", PivotArea.RowArea)
			pivotGridControl1.DataSource = ds

			comboBox1.Items.Clear()
			For i As Integer = 0 To pivotGridControl1.Cells.ColumnCount - 1
				comboBox1.Items.Add((i + 1).ToString())
			Next i
			comboBox1.SelectedIndex = 9
		End Sub

		Private Sub SelectColumn(ByVal columnIndex As Integer)
			pivotGridControl1.Cells.FocusedCell = New Point(columnIndex, 0)
			pivotGridControl1.Cells.Selection = New Rectangle(columnIndex, 0, 1, pivotGridControl1.Cells.RowCount)
		End Sub

		Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
			If comboBox1.SelectedIndex < 0 Then
				Return
			End If
			SelectColumn(comboBox1.SelectedIndex)
		End Sub
	End Class

	Public Class DataObject
		Private month_Renamed, sales_Renamed As Integer
		Private productName_Renamed As String

		Public Sub New(ByVal month As Integer, ByVal sales As Integer, ByVal productName As String)
			Me.month_Renamed = month
			Me.sales_Renamed = sales
			Me.productName_Renamed = productName
		End Sub

		Public ReadOnly Property Month() As Integer
			Get
				Return month_Renamed
			End Get
		End Property
		Public ReadOnly Property Sales() As Integer
			Get
				Return sales_Renamed
			End Get
		End Property
		Public ReadOnly Property ProductName() As String
			Get
				Return productName_Renamed
			End Get
		End Property
	End Class
End Namespace