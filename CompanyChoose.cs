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
using System.IO;
using System.Data.SqlClient;

namespace PostaKod
{
    public partial class CompanyChoose : DevExpress.XtraEditors.XtraForm
    {
        public CompanyChoose()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(File.ReadAllText("Database.txt"));
        string company = string.Empty, fileread = string.Empty;
        void DatabaseList(string getttext)
        {
            SqlDataAdapter da = new SqlDataAdapter(getttext, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            company = gridView1.GetFocusedRowCellValue("ŞİRKETLERİNİZ").ToString();

            FileStream read = new FileStream("Database.txt", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(read);
            fileread = rd.ReadLine();
            fileread =fileread.Replace(File.ReadAllText("table.txt"),company);
            rd.Close();
            read.Close();
            //
            FileStream fs = new FileStream("table.txt", FileMode.Truncate, FileAccess.Write);
            StreamWriter swr = new StreamWriter(fs);
            swr.Write(company);
            swr.Close();
            fs.Close();
            ///

            FileStream fst = new FileStream("Database.txt", FileMode.Truncate, FileAccess.Write);
            StreamWriter wr = new StreamWriter(fst);
            wr.Write(fileread);
            wr.Close();
            fst.Close();

            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void CompanyChoose_Load(object sender, EventArgs e)
        {
            DatabaseList("select name as 'ŞİRKETLERİNİZ' from sys.databases");
        }
    }
}