using Aspose.Zip;
using Aspose.Zip.Rar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackRarZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string type = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
            button2.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Rar - Zip Seçiniz";
            ofd.Filter = "Desteklenen Dosyalar (Rar-Zip) |*.Rar;*.Zip;*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label6.Text = ofd.FileName;
                button2.Enabled = true;
            }
            string ext = Path.GetExtension(ofd.SafeFileName);
            type = ext.ToLower();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (label6.Text != "")
                {
                    progressBar1.Show();
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();
                    string folderName = fbd.SelectedPath;
                    if (type == ".zip")
                    {
                        using (FileStream AppFile = File.Open(label6.Text, FileMode.Open))
                        {
                            using (var archive = new Archive(AppFile, new ArchiveLoadOptions() { DecryptionPassword = "zomonozzip" }))
                            {
                                progressBar1.Show();
                                archive.ExtractToDirectory(folderName);
                                progressBar1.Hide();
                            }
                        }
                    }
                    if (type == ".rar")
                    {
                        progressBar1.Show();
                        RarArchive archive = new RarArchive(label6.Text);
                        archive.ExtractToDirectory(folderName, "zomonozrar");
                        progressBar1.Hide();
                    }

                }
                if (label6.Text == "X")
                {
                    MessageBox.Show("Seçim Yapılmadı.", "İşlem yapmak için bir sıkıştırılmış dosya seçin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //int deneme = 0;
        //deneme++;
        //Random rnd = new Random();
        //string harf = @"QWABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVXYZqwabcçdefgğhiıjklmnoöprsştuüvxyz0123456789!'^#+$%&/{([)]=*?-.,¨~<>|@_\";
        //string deger = null;
        //for (int i = 0; i < 2; i++)
        //{
        //    deger += harf[rnd.Next(harf.Length)];
        //    textBox1.Text = deger;
        //    if (deger == "#!")
        //    {
        //        timer1.Stop();
        //    }
        //}
        //this.Text = deneme.ToString();
    }
}
