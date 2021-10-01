using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.IO;
using System.Threading;
namespace PostaKod
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection myconnet = new SqlConnection(System.IO.File.ReadAllText("database.txt"));
        void Gridconnet(string gettext)
        {

            SqlDataAdapter da = new SqlDataAdapter(gettext, myconnet);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        void Info()
        {
            Lbl_CustomerSumCount.Text = 0.ToString();
            Lbl_CustomernullCount.Text = 0.ToString();
            Lbl_CustomerfullCount.Text = 0.ToString();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Lbl_CustomerSumCount.Text = (1 + Convert.ToInt32(Lbl_CustomerSumCount.Text)).ToString();
                if (gridView1.GetRowCellValue(i,"ADRPOSTAKOD").ToString() == null || gridView1.GetRowCellValue(i, "ADRPOSTAKOD").ToString() =="")
                    Lbl_CustomernullCount.Text = (1 + Convert.ToInt32(Lbl_CustomernullCount.Text)).ToString();
                else
                    Lbl_CustomerfullCount.Text = (1 + Convert.ToInt32(Lbl_CustomerfullCount.Text)).ToString();
            }
        }
        void Updatedatabase()
        {
            DialogResult message = new DialogResult();
            message = XtraMessageBox.Show("BÜTÜN KAYITLARI CARİ KARTTA İŞLEMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?", "POSTA KODLARINI CARİ İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (message == DialogResult.Yes)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        myconnet.Open();
                        SqlCommand komut = new SqlCommand("update ADRESLER set ADRESLER.ADRPOSTAKOD='" + gridView1.GetRowCellValue(i, "ADRPOSTAKOD").ToString() + "' where ADRESLER.ADRKOD1='" + gridView1.GetRowCellValue(i, "CARKOD").ToString() + "'", myconnet);
                        komut.ExecuteNonQuery();
                        myconnet.Close();
                    }
                    XtraMessageBox.Show("CARİ KARTLARA İŞLEMİ BAŞARILI !!", "POSTA KODLARINI CARİ İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception a)
            {
                XtraMessageBox.Show(a.Message, "HATALI İŞLEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myconnet.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Gridconnet("select CARKOD,CARUNVAN,ADRESLER.ADRIL,ADRILCE,ADRADRES1,ADRPOSTAKOD FROM CARKART inner join ADRESLER on ADRESLER.ADRKOD1=CARKOD order by CARUNVAN");
            webBrowser1.Navigate("https://postakodu.ptt.gov.tr/");
            Info();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                PostaKodlari ptk = new PostaKodlari();
                ptk.Postcity = gridView1.GetFocusedRowCellValue("ADRIL").ToString();
                ptk.Posttown = gridView1.GetFocusedRowCellValue("ADRILCE").ToString();
                ptk.ShowDialog();
                if (ptk.Postcode != null)
                    gridView1.SetFocusedRowCellValue("ADRPOSTAKOD", ptk.Postcode.ToString());
            }
            catch (Exception a)
            {
                XtraMessageBox.Show(a.Message, "HATALI SEÇME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Updatedatabase();
            Info();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                Gridconnet("select CARKOD, CARUNVAN, ADRESLER.ADRIL, ADRILCE, ADRADRES1, ADRPOSTAKOD FROM CARKART inner join ADRESLER on ADRESLER.ADRKOD1 = CARKOD  where ADRPOSTAKOD = '' order by CARUNVAN");
            else
                Gridconnet("select CARKOD,CARUNVAN,ADRESLER.ADRIL,ADRILCE,ADRADRES1,ADRPOSTAKOD FROM CARKART inner join ADRESLER on ADRESLER.ADRKOD1=CARKOD order by CARUNVAN");
            Info();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
