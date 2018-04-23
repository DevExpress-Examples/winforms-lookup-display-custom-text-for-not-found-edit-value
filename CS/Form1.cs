using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace NotFoundValue {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DataTable tblLookUp = new DataTable();
            tblLookUp.Columns.Add("Code", typeof(int));
            tblLookUp.Columns.Add("Name");
            tblLookUp.Rows.Add(new object[] { 1, "one" });
            tblLookUp.Rows.Add(new object[] { 2, "two" });

            DataTable tblGrid = new DataTable();
            tblGrid.Columns.Add("Number", typeof(int));
            for(int i = 0; i < 3; i++)
                tblGrid.Rows.Add(new object[] { i });
            gridControl1.DataSource = tblGrid;

            RepositoryItemLookUpEdit editor = gridControl1.RepositoryItems.Add("LookUpEdit") as RepositoryItemLookUpEdit;
            editor.DataSource = tblLookUp;
            editor.ValueMember = "Code";
            editor.DisplayMember = "Name";
            editor.CustomDisplayText += new CustomDisplayTextEventHandler(RepositoryItemLookUpEdit_CustomDisplayText);

            gridView1.Columns[0].ColumnEdit = editor;
            // add the second column bound to the same field for easier reference
            gridView1.Columns.AddField("Number").VisibleIndex = 1;

            lookUpEdit1.Properties.Assign(editor);
            lookUpEdit1.EditValue = 0;
        }

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
    }
}