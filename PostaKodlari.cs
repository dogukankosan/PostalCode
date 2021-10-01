using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace PostaKod
{
    public partial class PostaKodlari : DevExpress.XtraEditors.XtraForm
    {
        public PostaKodlari()
        {
            InitializeComponent();
        }
        string Page = "Sheet1";
        public string Postcity = string.Empty, Posttown = string.Empty, Postcode = string.Empty;
        void Excelget()
        {

            try
            {
                string excellocation = File.ReadAllText(Application.StartupPath + "\\excellocation.txt");
                OleDbConnection connectexcel = new OleDbConnection(excellocation);
                OleDbDataAdapter da = new OleDbDataAdapter("select RTRIM(MAHALE) as MAHALE,PK from[" + Page + "$] where İL='"+Postcity+ "' and İLÇE='"+Posttown+ "' order by MAHALE ", connectexcel);
                DataSet ds = new DataSet();
                da.Fill(ds);
               gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "HATALI OKUMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PostaKodlari_Load(object sender, EventArgs e)
        {
            Excelget();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Postcode=gridView1.GetFocusedRowCellValue("PK").ToString();
            this.Close();
        }

        private void PostaKodlari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close(); 
        }
    }
}