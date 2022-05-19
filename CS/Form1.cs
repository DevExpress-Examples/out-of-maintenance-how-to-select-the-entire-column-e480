using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace Q184421 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			List<DataObject> ds = new List<DataObject>();
			for(int m = 1; m <= 12; m++) {
				for(int p = 1; p < 10; p++) {
					ds.Add(new DataObject(m, p * m, "Product " + p.ToString()));
				}
			}
			pivotGridControl1.Fields.AddDataSourceColumn("Month", PivotArea.ColumnArea);
			pivotGridControl1.Fields.AddDataSourceColumn("Sales", PivotArea.DataArea);
			pivotGridControl1.Fields.AddDataSourceColumn("ProductName", PivotArea.RowArea);
			pivotGridControl1.DataSource = ds;

			comboBox1.Items.Clear();
			for(int i = 0; i < pivotGridControl1.Cells.ColumnCount; i++)
				comboBox1.Items.Add((i + 1).ToString());
			comboBox1.SelectedIndex = 9;			
		}

		void SelectColumn(int columnIndex) {
			pivotGridControl1.Cells.FocusedCell = new Point(columnIndex, 0);
			pivotGridControl1.Cells.Selection = new Rectangle(columnIndex, 0, 1, pivotGridControl1.Cells.RowCount);
		}

		void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if(comboBox1.SelectedIndex < 0) return;
			SelectColumn(comboBox1.SelectedIndex);
		}
	}

	public class DataObject {
		int month, sales;
		string productName;

		public DataObject(int month, int sales, string productName) {
			this.month = month;
			this.sales = sales;
			this.productName = productName;
		}

		public int Month { get { return month; } }
		public int Sales { get { return sales; } }
		public string ProductName { get { return productName; } }
	}
}