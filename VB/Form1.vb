Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository

Namespace NotFoundValue
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim tblLookUp As New DataTable()
			tblLookUp.Columns.Add("Code", GetType(Integer))
			tblLookUp.Columns.Add("Name")
			tblLookUp.Rows.Add(New Object() { 1, "one" })
			tblLookUp.Rows.Add(New Object() { 2, "two" })

			Dim tblGrid As New DataTable()
			tblGrid.Columns.Add("Number", GetType(Integer))
			For i As Integer = 0 To 2
				tblGrid.Rows.Add(New Object() { i })
			Next i
			gridControl1.DataSource = tblGrid

			Dim editor As RepositoryItemLookUpEdit = TryCast(gridControl1.RepositoryItems.Add("LookUpEdit"), RepositoryItemLookUpEdit)
			editor.DataSource = tblLookUp
			editor.ValueMember = "Code"
			editor.DisplayMember = "Name"
			AddHandler editor.CustomDisplayText, AddressOf RepositoryItemLookUpEdit_CustomDisplayText

			gridView1.Columns(0).ColumnEdit = editor
			' add the second column bound to the same field for easier reference
			gridView1.Columns.AddField("Number").VisibleIndex = 1

			lookUpEdit1.Properties.Assign(editor)
			lookUpEdit1.EditValue = 0
		End Sub

		Private Const NotFoundText As String = "???"

		Private Sub RepositoryItemLookUpEdit_CustomDisplayText(ByVal sender As Object, ByVal e As CustomDisplayTextEventArgs)
			Dim props As RepositoryItemLookUpEdit
			If TypeOf sender Is LookUpEdit Then
				props = (TryCast(sender, LookUpEdit)).Properties
			Else
				props = TryCast(sender, RepositoryItemLookUpEdit)
			End If

			If props IsNot Nothing AndAlso (TypeOf e.Value Is Integer) Then
				Dim row As Object = props.GetDataSourceRowByKeyValue(e.Value)
				If row Is Nothing Then
					e.DisplayText = NotFoundText
				End If
			End If
		End Sub
	End Class
End Namespace