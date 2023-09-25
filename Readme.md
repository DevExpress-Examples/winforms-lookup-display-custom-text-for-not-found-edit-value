<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128620596/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E781)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Lookup - Display custom text if the lookup's value is not found in the drop-down list

This example handles the [Properties.CustomDisplayText](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItem.CustomDisplayText) event to display custom text if the lookup's `EditValue` does not match any value in the drop-down list (the value does not exist in the data source).

```csharp
const string NotFoundText = "???";

private void RepositoryItemLookUpEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e) {
    RepositoryItemLookUpEdit props;
    if(sender is LookUpEdit)
        props = (sender as LookUpEdit).Properties;
    else
        props = sender as RepositoryItemLookUpEdit;
    
    if(props != null && (e.Value is int)) {
        object row = props.GetDataSourceRowByKeyValue(e.Value);
        if(row == null) {
            e.DisplayText = NotFoundText;
        }
    }
}
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Lookup Editors](https://docs.devexpress.com/WindowsForms/116008/controls-and-libraries/editors-and-simple-controls/lookup-editors)
* [Lookup Main Settings](https://docs.devexpress.com/WindowsForms/116029/controls-and-libraries/editors-and-simple-controls/lookup-editors/lookup-editors-and-main-settings)
* [Standard Binding (to Simple Data Types)](https://docs.devexpress.com/WindowsForms/116015/controls-and-libraries/editors-and-simple-controls/lookup-editors/standard-binding-to-simple-data-types)

## See Also

* [DevExpress WinForms Troubleshooting - LookUp Editors](https://go.devexpress.com/CheatSheets_WinForms_Examples_T929986.aspx)
* [How to Determine if a Value Put into the LookupEdit Does Not Exist in the Data Source](https://supportcenter.devexpress.com/ticket/details/a149/how-to-determine-if-a-value-put-into-the-lookupedit-does-not-exist-in-the-lookup-data)
* [How to Use the ProcessNewValue Event of a LookUp Editor](https://supportcenter.devexpress.com/ticket/details/a238/how-to-use-the-processnewvalue-event-of-a-lookup-editor)


