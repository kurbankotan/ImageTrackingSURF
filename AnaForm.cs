using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Sonradan eklenenler
using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace SURF
{
    public partial class AnaForm : Form
    {
        private bool ilkDefaResimOlcusuDegistiMi = true;
        private int formunBastakiGenisligi;
        private int formunBastakiYuksekligi;
        private int resminBastakiGenisligi;
        private int resminBastakiYuksekligi;
        private Capture captureWebKamera;                   // Kameradan resim çekmek için
        private bool WebKamerasindanResimCekiliyorMu = false;
        private Image<Bgr, byte> sahneResmiRengi = null;
        private Image<Bgr, byte> aranacakResimRengi = null;
        private Image<Bgr, byte> cerceveyleBulunacakResminKopyasi = null;
        private bool sahneResmiYuklendiMi = false;
        private bool aranacakNesneResmiYuklendiMi = false;
        private Image<Bgr, byte> sonucResmi = null;
        private Bgr bgrOznitelikRengi = new Bgr(Color.Blue);
        private Bgr bgrOznitelikHatlariRengi = new Bgr(Color.Green);
        private Bgr bgrBulunanResimlerinRengi = new Bgr(Color.Red);
        private Stopwatch stopwatch = new Stopwatch();

        public AnaForm()
        {
            InitializeComponent();
            formunBastakiGenisligi = this.Width;
            formunBastakiYuksekligi = this.Height;
            resminBastakiGenisligi = Resim.Width;
            resminBastakiYuksekligi = Resim.Height;
        }

        private void AnaForm_Resize(object sender, EventArgs e)
        {
            if ((ilkDefaResimOlcusuDegistiMi == true))
                ilkDefaResimOlcusuDegistiMi = false;
            else
            {
                Resim.Width = this.Width - (formunBastakiGenisligi - resminBastakiGenisligi);
                Resim.Height = this.Height - (formunBastakiYuksekligi - resminBastakiYuksekligi);
            }
        }

        private void radioResimDosyasi_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioResimDosyasi.Checked == true))
            {
                if ((WebKamerasindanResimCekiliyorMu == true))
                {
                    Application.Idle -= new EventHandler(this.SurfUygulaVeResmiGuncelle);
                    WebKamerasindanResimCekiliyorMu = false;
                }

                sahneResmiRengi = null;
                aranacakResimRengi = null;
                cerceveyleBulunacakResminKopyasi = null;
                sonucResmi = null;
                sahneResmiYuklendiMi = false;
                aranacakNesneResmiYuklendiMi = false;
                text_SahneAdresi.Text = "";
                text_AranacakResimAdresi.Text = "";
                Resim.Image = null;
                this.Text = "Açıklama: '...' butonlarını kullanarak resimleri yükleyin ve 'SURF Algoritmasını Uygula' butonuna basınız";
                buton_SURF_Uygula.Text = "SURF Algoritmasını Uygula";
                Resim.Image = null;
                labelSahne.Visible = true;
                labelAranacakNesne.Visible = true;
                text_SahneAdresi.Visible = true;
                text_AranacakResimAdresi.Visible = true;
                buton_SahneSec.Visible = true;
                buton_AranacakResimSec.Visible = true;
            }
        }



        private void radioWebKamerasi_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioWebKamerasi.Checked == true))
            {
                sahneResmiRengi = null;
                aranacakResimRengi = null;
                cerceveyleBulunacakResminKopyasi = null;
                sonucResmi = null;
                sahneResmiYuklendiMi = false;
                aranacakNesneResmiYuklendiMi = false;
                text_SahneAdresi.Text = "";
                text_AranacakResimAdresi.Text = "";
                Resim.Image = null;
                try
                {
                    captureWebKamera = new Capture();
                }
                catch (Exception hata)
                {
                    this.Text = "Hata: Kameraya bağlanılamıyor.";
                    return;
                }

                this.Text = "Açıklama : görüntüyü izlemeyi güncellemek için, resmi kameraya tutun sonra 'Takip edilecek nesneyi güncelle' butonuna tıklayınız ";
                buton_SURF_Uygula.Text = "Takip edilecek nesneyi güncelle";
                aranacakResimRengi = null;
                Application.Idle += new EventHandler(this.SurfUygulaVeResmiGuncelle);
                WebKamerasindanResimCekiliyorMu = true;
                labelSahne.Visible = false;
                labelAranacakNesne.Visible = false;
                text_SahneAdresi.Visible = false;
                text_AranacakResimAdresi.Visible = false;
                buton_SahneSec.Visible = false;
                buton_AranacakResimSec.Visible = false;
            }
        }

        private void buton_SahneSec_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = OpenFileDialog_SahneResmiSec.ShowDialog();
            if ((dialogResult == System.Windows.Forms.DialogResult.OK | dialogResult == System.Windows.Forms.DialogResult.Yes))
                text_SahneAdresi.Text = OpenFileDialog_SahneResmiSec.FileName;
            else
                return;
            try
            {
                sahneResmiRengi = new Image<Bgr, byte>(text_SahneAdresi.Text);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.Message);
                return;
            }

            sahneResmiYuklendiMi = true;
            if ((aranacakNesneResmiYuklendiMi == false))
                Resim.Image = sahneResmiRengi;
            else
                Resim.Image = sahneResmiRengi.ConcateHorizontal(cerceveyleBulunacakResminKopyasi);
        }



        private void buton_AranacakResimSec_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = OpenFileDialog_AranacakResmiSec.ShowDialog();
            if ((dialogResult == System.Windows.Forms.DialogResult.OK | dialogResult == System.Windows.Forms.DialogResult.Yes))
                text_AranacakResimAdresi.Text = OpenFileDialog_AranacakResmiSec.FileName;
            else
                return;
            try
            {
                aranacakResimRengi = new Image<Bgr, byte>(text_AranacakResimAdresi.Text);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.Message);
                return;
            }

            aranacakNesneResmiYuklendiMi = true;
            cerceveyleBulunacakResminKopyasi = aranacakResimRengi.Copy();
            cerceveyleBulunacakResminKopyasi.Draw(new Rectangle(1, 1, cerceveyleBulunacakResminKopyasi.Width - 3, cerceveyleBulunacakResminKopyasi.Height - 3), bgrBulunanResimlerinRengi, 2);
            if ((sahneResmiYuklendiMi == true))
                Resim.Image = sahneResmiRengi.ConcateHorizontal(cerceveyleBulunacakResminKopyasi);
            else
                Resim.Image = cerceveyleBulunacakResminKopyasi;
        }

        private void text_SahneAdresi_TextChanged(object sender, EventArgs e)
        {
            text_SahneAdresi.SelectionStart = text_SahneAdresi.Text.Length;
        }

        private void text_AranacakResimAdresi_TextChanged(object sender, EventArgs e)
        {
            text_AranacakResimAdresi.SelectionStart = text_AranacakResimAdresi.Text.Length;
        }


        private void buton_SURF_Uygula_Click(object sender, EventArgs e)
        {
            if ((radioResimDosyasi.Checked == true))
                if ((text_AranacakResimAdresi.Text != string.Empty & text_SahneAdresi.Text != string.Empty))
                    SurfUygulaVeResmiGuncelle(new object(), new EventArgs());
                else
                    this.Text = "Önce Resimleri Seçin, Sonra 'SURF Algoritmasını Uygula' Butonuna Tıklayın";
            else if ((radioWebKamerasi.Checked == true))
            {
                aranacakResimRengi = sahneResmiRengi.Resize(320, 240, INTER.CV_INTER_CUBIC, true);
                this.Text = "Açıklama : görüntüyü izlemeyi güncellemek için, resmi kameraya tutun sonra 'Takip edilecek nesneyi güncelle' butonuna tıklayını ";
                buton_SURF_Uygula.Text = "Takip edilecek nesneyi güncelle";
            }
            else
            {
            }
        }


        private void checkBox_OznitelikNoktalari_CheckedChanged(object sender, EventArgs e)
        {
               if ((checkBox_OznitelikNoktalari.Checked == false))
                { 
                    checkBox_OznitelikHatlari.Checked = false;
                    checkBox_OznitelikHatlari.Enabled = false;
                }
                else if ((checkBox_OznitelikNoktalari.Checked == true))
                    checkBox_OznitelikHatlari.Enabled = true;
                if ((radioResimDosyasi.Checked == true))
                         buton_SURF_Uygula_Click(new object (), new EventArgs());
        }

        private void checkBox_OznitelikHatlari_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioResimDosyasi.Checked == true))
                buton_SURF_Uygula_Click(new object(), new EventArgs());
        }



        public void SurfUygulaVeResmiGuncelle(object sender, EventArgs arg)
        {
            if ((radioResimDosyasi.Checked == true))
            {
                if ((sahneResmiYuklendiMi == false | aranacakNesneResmiYuklendiMi == false | sahneResmiRengi == null | aranacakResimRengi == null))
                {
                    this.Text = "İki resimden biri veya ikisi boş veya yüklenmemiş. SURF algoritması uygulanmadan önce lütfen resimleri yükleyin";
                    return;
                }

                this.Text = "işleniyor, lütfen bekleyin . . .";
                Application.DoEvents();
                stopwatch.Restart();
            }
            else if ((radioWebKamerasi.Checked == true))
            {
                try
                {
                    sahneResmiRengi = captureWebKamera.QueryFrame();
                }
                catch (Exception hata)
                {
                    this.Text = hata.Message;
                    return;
                }

                if ((sahneResmiRengi == null))
                {
                    this.Text = "Hata, Sahne Resmi yok";
                    return;
                }

                if ((aranacakResimRengi == null))
                {
                    Resim.Image = sahneResmiRengi;
                    return;
                }
            }

            SURFDetector yuzeyBulucu = new SURFDetector(500, false);
            Image<Gray, byte> sahneResmiGri = null;
            Image<Gray, byte> aranacakResimGri = null;
            VectorOfKeyPoint oznitelikNoktalarininVektorleri;
            VectorOfKeyPoint oznitelikNoktalariniBulanVektorleri;
            Matrix<float> sahneBetimlemeMatrisi;
            Matrix<float> aranacakNesneBetimlemeMatrisi;
            Matrix<int> uyanIndisMatrisi;
            Matrix<float> uzaklikMatrisi;
            Matrix<byte> maskeMatrisi;
            BruteForceMatcher<float> kabaKuvvetleUygunlugunuYapan;
            HomographyMatrix homografiMatrisi = null;
            int enYakinKomsuNoktalarSayisi = 2;
            double essizlikEsigi = 0.8;
            int sifirOlmayanOgeSayisi;
            double olcekArttirimi = 1.5;
            int devir = 20;
            double projeksiyonEsigi = 2;

            Rectangle rectImageToFind = new Rectangle(50, 50, 10, 10);

            PointF[] ptfPointsF;
            Point[] ptPoints;
            sahneResmiGri = sahneResmiRengi.Convert<Gray, byte>();
            aranacakResimGri = aranacakResimRengi.Convert<Gray, byte>();
            oznitelikNoktalarininVektorleri = yuzeyBulucu.DetectKeyPointsRaw(sahneResmiGri, null);
            sahneBetimlemeMatrisi = yuzeyBulucu.ComputeDescriptorsRaw(sahneResmiGri, null, oznitelikNoktalarininVektorleri);
            oznitelikNoktalariniBulanVektorleri = yuzeyBulucu.DetectKeyPointsRaw(aranacakResimGri, null);
            aranacakNesneBetimlemeMatrisi = yuzeyBulucu.ComputeDescriptorsRaw(aranacakResimGri, null, oznitelikNoktalariniBulanVektorleri);
            kabaKuvvetleUygunlugunuYapan = new BruteForceMatcher<float>(DistanceType.L2);
            kabaKuvvetleUygunlugunuYapan.Add(aranacakNesneBetimlemeMatrisi);
            uyanIndisMatrisi = new Matrix<int>(sahneBetimlemeMatrisi.Rows, enYakinKomsuNoktalarSayisi);
            uzaklikMatrisi = new Matrix<float>(sahneBetimlemeMatrisi.Rows, enYakinKomsuNoktalarSayisi);
            kabaKuvvetleUygunlugunuYapan.KnnMatch(sahneBetimlemeMatrisi, uyanIndisMatrisi, uzaklikMatrisi, enYakinKomsuNoktalarSayisi, null);
            maskeMatrisi = new Matrix<byte>(uzaklikMatrisi.Rows, 1);
            maskeMatrisi.SetValue(255);
            Features2DToolbox.VoteForUniqueness(uzaklikMatrisi, essizlikEsigi, maskeMatrisi);
            sifirOlmayanOgeSayisi = CvInvoke.cvCountNonZero(maskeMatrisi);
            if ((sifirOlmayanOgeSayisi >= 4))
            {
                sifirOlmayanOgeSayisi = Features2DToolbox.VoteForSizeAndOrientation(oznitelikNoktalariniBulanVektorleri, oznitelikNoktalarininVektorleri, uyanIndisMatrisi, maskeMatrisi, olcekArttirimi, devir);
                if ((sifirOlmayanOgeSayisi >= 4))
                    homografiMatrisi = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(oznitelikNoktalariniBulanVektorleri, oznitelikNoktalarininVektorleri, uyanIndisMatrisi, maskeMatrisi, projeksiyonEsigi);
            }

            cerceveyleBulunacakResminKopyasi = aranacakResimRengi.Copy();
            cerceveyleBulunacakResminKopyasi.Draw(new Rectangle(1, 1, cerceveyleBulunacakResminKopyasi.Width - 3, cerceveyleBulunacakResminKopyasi.Height - 3), bgrBulunanResimlerinRengi, 2);
            if ((checkBox_OznitelikNoktalari.Checked == true & checkBox_OznitelikHatlari.Checked == true))
                sonucResmi = Features2DToolbox.DrawMatches(cerceveyleBulunacakResminKopyasi, oznitelikNoktalariniBulanVektorleri, sahneResmiRengi, oznitelikNoktalarininVektorleri, uyanIndisMatrisi, bgrOznitelikHatlariRengi, bgrOznitelikRengi, maskeMatrisi, Features2DToolbox.KeypointDrawType.DEFAULT);
            else if ((checkBox_OznitelikNoktalari.Checked == true & checkBox_OznitelikHatlari.Checked == false))
            {
                sonucResmi = Features2DToolbox.DrawKeypoints(sahneResmiRengi, oznitelikNoktalarininVektorleri, bgrOznitelikRengi, Features2DToolbox.KeypointDrawType.DEFAULT);
                cerceveyleBulunacakResminKopyasi = Features2DToolbox.DrawKeypoints(cerceveyleBulunacakResminKopyasi, oznitelikNoktalariniBulanVektorleri, bgrOznitelikRengi, Features2DToolbox.KeypointDrawType.DEFAULT);
                sonucResmi = sonucResmi.ConcateHorizontal(cerceveyleBulunacakResminKopyasi);
            }
            else if ((checkBox_OznitelikNoktalari.Checked == false & checkBox_OznitelikHatlari.Checked == false))
            {
                sonucResmi = sahneResmiRengi;
                sonucResmi = sonucResmi.ConcateHorizontal(cerceveyleBulunacakResminKopyasi);
            }
            else
            {
            }

            if ((homografiMatrisi != null))
            {
                rectImageToFind.X = 0;
                rectImageToFind.Y = 0;
                rectImageToFind.Width = aranacakResimGri.Width;
                rectImageToFind.Height = aranacakResimGri.Height;
                ptfPointsF = new PointF[] { new PointF(rectImageToFind.Left, rectImageToFind.Top), new PointF(rectImageToFind.Right, rectImageToFind.Top), new PointF(rectImageToFind.Right, rectImageToFind.Bottom), new PointF(rectImageToFind.Left, rectImageToFind.Bottom) };
                homografiMatrisi.ProjectPoints(ptfPointsF);
                ptPoints = new Point[] { Point.Round(ptfPointsF[0]), Point.Round(ptfPointsF[1]), Point.Round(ptfPointsF[2]), Point.Round(ptfPointsF[3]) };
                sonucResmi.DrawPolyline(ptPoints, true, bgrBulunanResimlerinRengi, 2);
            }

            Resim.Image = sonucResmi;
            if ((radioResimDosyasi.Checked == true))
            {
                stopwatch.Stop();
                this.Text = "İşlem zamanı = " + stopwatch.Elapsed.TotalSeconds.ToString() + " sn, işlem tamamlandı, başka bir işlem için farklı bir resim seçin";
            }
        }





    }
}
