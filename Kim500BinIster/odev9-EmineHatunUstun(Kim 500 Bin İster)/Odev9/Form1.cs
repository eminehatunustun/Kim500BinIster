using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sure = 30;
        int kolaySoruSayaci = 1;
        int ortaSoruSayaci = 1;
        int zorSoruSayaci = 1;
        int odul;
        ArrayList dahaOnceSorulanSoruIndexiKolay = new ArrayList();
        ArrayList dahaOnceSorulanSoruIndexiOrta = new ArrayList();
        ArrayList dahaOnceSorulanSoruIndexiZor = new ArrayList();
        string[] kolaySorular = { "'Yerdeniz’ serisi ve 'Mülksüzler’ gibi bilim kurgu romanlarıyla tanınan yazar kimdir?", "İstanbul Arkeoloji Müzesi’nin kurucusu olan ve ilk Türk arkeoloğu olarak kabul edilen ressam kimdir?", "2005'de yayımlanan 'Olasılıksız’ adlı bilim kurgu ve gerilim romanıyla tanınan, 'Empati’ ve 'Oz’ kitaplarının yazarı kimdir?", "Ömer Seyfettin’in İran şahına gönderilen Muhsin Çelebi adlı elçinin maceralarını anlattığı öyküsü hangisidir?", "'Yeni dünyalar keşfetmek, yeni uygarlıklar aramak, daha önce hiç kimsenin gitmediği yerlere cesurca gitmek’ sloganı hangi ünlü dizide geçmektedir?" , "Tolstoy’un 'Savaş ve Barış' romanında Rusya’nın hangisine karşı savaşından bahsedilir?" };
        string[] kolaySorularSiklar = { "*Ursula K. Le Guin", "George Sand", "Sylvia Plath", "Simone de Beauvoir", "Burhan Doğançay", "*Osman Hamdi Bey", "Nuri İyem", "Halil Ethem Bey", "Paul Asuter", "Suzanne Collins", "*Adam Fawer", "Tom Robbins", "Diyet", "Yalnız Efe", "Beyaz Lale", "*Pembe İncili Kaftan", "*Uzay Yolu", "Doctor Who", "Battlestar Galactica", "Atlantis", "Osmanlı Devleti", "*Fransa", "İngiltere","Japonya" };
        string[] kolaySorularinCevaplari = { "*Ursula K. Le Guin", "*Osman Hamdi Bey", "*Adam Fawer", "*Pembe İncili Kaftan", "*Uzay Yolu", "*Fransa" };
        //------------------
        //-------------------
        //------------------
        string[] ortaSorular = { "Lakabı 'leğen kemiği’ olan şarkıcı kimdir?", "Bir astronot Ay yüzeyinde ellerindeki bir kuş tüyü ile bir çekici aynı anda bırakırsa hangisi gerçekleşir?", "Osmanlı Devleti’nde 'hanım iğnesi’ ile seyahat eden biri hangisini kullanmış demektir?", "Eskiden deri tabaklamakta kullanılan ve tabakhaneye hızlıca yetiştirilmesi gereken malzeme hangisinin dışkısı olurdu?", "'Asayiş berkemal’ sözünde geçen 'berkemal’in anlamı nedir?" , "Göz için kullanılan kontak lensler, adını hangisinin Latincesinden alırlar?", "Hangisi bir balıktır?" };
        string[] ortaSorularSiklar = { "*Elvis Presley", "Tina Turner", "Shakira", "Freddie Mercury", "Çekiç önce düşer", "*İkisi aynı anda düşer", "Kuş tüyü önce düşer", "İkisi de havada asılı kalır", "Fayton", "Balık", "*Kayık", "Tren", "Kedi", "Koyun", "Keçi", "*Köpek", "*Mükemmel", "Düzenli", "Sakin", "Temiz", "Üzüm", "*Mercimek", "Bezelye", "Fasulye" , "Fok balığı", "Ayı balığı", "*Yılan balığı", "Mürekkep balığı" };
        string[] ortaSorularinCevaplari = { "*Elvis Presley", "*İkisi aynı anda düşer", "*Kayık", "*Köpek", "*Mükemmel" , "*Mercimek", "*Yılan balığı" };
        //----------------
        //-----------------
        //------------------
        string[] zorSorular = { "Pera Müzesi’nde sergilenen Osman Hamdi Bey’e ait “Kaplumbağa Terbiyecisi” tablosunda yerde kaç adet kaplumbağa vardır?", "ABD Ulusal Arşivi’nden en çok talep edilen fotoğraf, neyin fotoğrafıdır?", "Hangisinin resmi adında “Halk Cumhuriyeti” yoktur?", "Dünyanın çevresini yelkenliyle hiç karaya çıkmadan dolaşmak isteyen birinin hangi güney enlemini takip etmesi gerekir?", "'Yapabilirler çünkü yapabileceklerini düşünüyorlar' sözü kime aittir?", "1920'de TBMM açıldıktan sonra çıkarılan ilk kanun olan “Ağnam Resmi Kanunu” hangisiyle ilgilidir?" };
        string[] zorSorularSiklar = { "*5", "1", "3", "7", "Abraham Lincoln'ün portresi", "*Nixon ve Elvis'in el sıkışması", "Bahriyelinin bir kızı öpme anı", "Marilyn Monroe'nun uçuşan eteği", "Cezayir", "Laos", "*Vietnam", "Bangladeş", "40", "50", "70", "*60", "*Vergilius", "Tales", "Sokrates", "Zenon", "Asker kaçakları", "*Hayvan vergisi", "Miras düzenlemesi", "Orduya erzak yardımı" };
        string[] zorSorularinCevaplari = { "*5", "*Nixon ve Elvis'in el sıkışması", "*Vietnam", "*60", "*Vergilius", "*Hayvan vergisi" };
        string yarismaciCevap;
        int hangisi;
        Random rnd = new Random();
        string dogruCevap;
        int tik; //tıklama sayısı
        private void btnCevapla_Click(object sender, EventArgs e)
        {
            rbA.Visible = true;
            rbB.Visible = true;
            rbC.Visible = true;
            rbD.Visible = true;
            txtIpucu.Text = "";
            tik++;
            if (tik<6)
            {
                sure = 30;
                tmrSure.Stop();
                dogruCevap = kolaySorularinCevaplari[hangisi];
                siklariCevabaEsitleme();
                if (yarismaciCevap == dogruCevap)
                {
                    MessageBox.Show("DoğruCevap");
                    kolayRenklendir();
                    DialogResult devamEtmekİstiyorMusunuz = MessageBox.Show("Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (devamEtmekİstiyorMusunuz == DialogResult.Yes)
                    { 
                            int aranan = 10;
                            while (aranan >= 0) // aranan daha önce varsa yeni sayı ürettiriyoruz.
                            {

                            if (tik == 5)
                            {
                                hangisi = rnd.Next(0, ortaSorular.Length);
                                dahaOnceSorulanSoruIndexiOrta.Add(hangisi);
                                txtSoru.Text = ortaSorular[hangisi].ToString();
                                rbA.Text = ortaSorularSiklar[hangisi * 4].ToString();
                                rbB.Text = ortaSorularSiklar[(hangisi * 4) + 1].ToString();
                                rbC.Text = ortaSorularSiklar[(hangisi * 4) + 2].ToString();
                                rbD.Text = ortaSorularSiklar[(hangisi * 4) + 3].ToString();
                                lblSure.Visible = false;
                                lblSuretxt.Visible = false;
                                break;
                            }                        
                                hangisi = rnd.Next(0, kolaySorular.Length);
                                aranan = dahaOnceSorulanSoruIndexiKolay.IndexOf(hangisi);
                                if (aranan < 0)
                                {
                                    dahaOnceSorulanSoruIndexiKolay.Add(hangisi);
                                    kolaySoruSayaci++;
                                    tmrSure.Start();
                                    txtSoru.Text = kolaySorular[hangisi].ToString();
                                    rbA.Text = kolaySorularSiklar[hangisi * 4].ToString();
                                    rbB.Text = kolaySorularSiklar[(hangisi * 4) + 1].ToString();
                                    rbC.Text = kolaySorularSiklar[(hangisi * 4) + 2].ToString();
                                    rbD.Text = kolaySorularSiklar[(hangisi * 4) + 3].ToString();
                                }
                            
                            
                            }
                        


                        // burada aynı soruyu tekrar yazdırmamaya çalışıyoruz. indexe göre.
                    }
                    // ----------
                    else if (devamEtmekİstiyorMusunuz == DialogResult.No)
                    {
                        kontrolleriGizleme();
                        // kolayOdulGetirici(kolaySoruSayaci);
                        switch (kolaySoruSayaci)
                        {
                            case 2: odul = 500; break;
                            case 3: odul = 1000; break;
                            case 4: odul = 2000; break;
                            case 5: odul = 5000; break;

                        }
                        txtSoru.Text = "Ödülünüz:"+odul.ToString();
                    }
                }
                else if (yarismaciCevap != dogruCevap)
                {
                    // kolayOdulGetirici(kolaySoruSayaci);
                    switch (kolaySoruSayaci)
                    {
                       // case 1: odul = 500; break;
                        case 2: odul = 500; break;
                        case 3: odul = 1000; break;
                        case 4: odul = 2000; break;
                        case 5: odul = 5000; break;

                    }
                    txtSoru.Text = "Üzgünüm yanlış cevap: \nÖdülünüz:"+ odul.ToString();
                    txtSoru.Font = new Font("Microsoft Sans Serif", 25);
                    kontrolleriGizleme();
                }
            }

            if (tik >= 6 && tik < 11)
            {              
                lblSuretxt.Visible = false;
                lblSure.Visible = false;
                siklariCevabaEsitleme();
                dogruCevap = ortaSorularinCevaplari[hangisi];

                if (yarismaciCevap == dogruCevap)
                {
                    MessageBox.Show("DoğruCevap");
                   
                    DialogResult devamEtmekİstiyorMusunuz = MessageBox.Show("Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (devamEtmekİstiyorMusunuz == DialogResult.Yes)
                    {
                        int aranan = 10;
                        while (aranan >= 0) // aranan daha önce varsa yeni sayı ürettiriyoruz.
                        {
                            hangisi = rnd.Next(0, ortaSorular.Length);
                            aranan = dahaOnceSorulanSoruIndexiOrta.IndexOf(hangisi);
                            if (aranan < 0)
                            {
                                if (tik == 10)
                                {
                                    ortaRenklendir();
                                    hangisi = rnd.Next(0, zorSorular.Length);
                                    dahaOnceSorulanSoruIndexiZor.Add(hangisi);
                                    txtSoru.Text = zorSorular[hangisi].ToString();
                                    rbA.Text = zorSorularSiklar[hangisi * 4].ToString();
                                    rbB.Text = zorSorularSiklar[(hangisi * 4) + 1].ToString();
                                    rbC.Text = zorSorularSiklar[(hangisi * 4) + 2].ToString();
                                    rbD.Text = zorSorularSiklar[(hangisi * 4) + 3].ToString();
                                   // zorSoruSayaci++;
                                    break;
                                }
                                ortaRenklendir();
                                dahaOnceSorulanSoruIndexiOrta.Add(hangisi);
                                ortaSoruSayaci++;
                               // tmrSure.Start();
                                txtSoru.Text = ortaSorular[hangisi].ToString();
                                rbA.Text = ortaSorularSiklar[hangisi * 4].ToString();
                                rbB.Text = ortaSorularSiklar[(hangisi * 4) + 1].ToString();
                                rbC.Text = ortaSorularSiklar[(hangisi * 4) + 2].ToString();
                                rbD.Text = ortaSorularSiklar[(hangisi * 4) + 3].ToString();
                            }
                        }
                        // burada aynı soruyu tekrar yazdırmamaya çalışıyoruz. indexe göre.
                    }
                    else if (devamEtmekİstiyorMusunuz == DialogResult.No)
                    {
                        switch (ortaSoruSayaci)
                        {
                            case 1: odul = 10000; break;
                            case 2: odul = 20000; break;
                            case 3: odul = 30000; break;
                            case 4: odul = 50000; break;
                            case 5: odul = 75000; break;

                        }
                        kontrolleriGizleme();
                        txtSoru.Text = "Ödülünüz:"+odul.ToString();

                    }
                }
                else if (yarismaciCevap != dogruCevap)
                {
                    switch (ortaSoruSayaci)
                    {
                        case 1: odul = 10000; break;
                        case 2: odul = 20000; break;
                        case 3: odul = 30000; break;
                        case 4: odul = 40000; break;
                        case 5: odul = 50000;break;

                    }
                    txtSoru.Text = "Üzgünüm yanlış cevap: \nÖdülünüz:" +odul.ToString();
                    txtSoru.Font = new Font("Microsoft Sans Serif", 25);
                    kontrolleriGizleme();
                }

            }
            if (tik >=11)
            {
                siklariCevabaEsitleme();
                dogruCevap = zorSorularinCevaplari[hangisi];

                if (yarismaciCevap == dogruCevap)
                {
                    MessageBox.Show("DoğruCevap");
                    zorRenklendir();
                    DialogResult devamEtmekİstiyorMusunuz = MessageBox.Show("Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (devamEtmekİstiyorMusunuz == DialogResult.Yes)
                    {
                        int aranan = 10;
                        while (aranan >= 0) // aranan daha önce varsa yeni sayı ürettiriyoruz.
                        {
                            hangisi = rnd.Next(0, zorSorular.Length);
                            aranan = dahaOnceSorulanSoruIndexiZor.IndexOf(hangisi);
                            if (aranan < 0)
                            {
                                if (tik == 15)
                                {
                                    kontrolleriGizleme();
                                    txtSoru.Text = "Tebrikler 500 bin sizin.";
                                    break;
                                }
                                dahaOnceSorulanSoruIndexiZor.Add(hangisi);
                                zorSoruSayaci++;
                               // tmrSure.Start();
                                txtSoru.Text = zorSorular[hangisi].ToString();
                                rbA.Text = zorSorularSiklar[hangisi * 4].ToString();
                                rbB.Text = zorSorularSiklar[(hangisi * 4) + 1].ToString();
                                rbC.Text = zorSorularSiklar[(hangisi * 4) + 2].ToString();
                                rbD.Text = zorSorularSiklar[(hangisi * 4) + 3].ToString();
                            }
                        }
                        // burada aynı soruyu tekrar yazdırmamaya çalışıyoruz. indexe göre.
                    }
                    else if (devamEtmekİstiyorMusunuz == DialogResult.No)
                    {
                        switch (zorSoruSayaci)
                        {
                            case 1: odul = 75000; break;
                            case 2: odul = 100000; break;
                            case 3: odul = 150000; break;
                            case 4: odul = 200000; break;
                            case 5: odul = 250000; break;

                        }
                        kontrolleriGizleme();
                        txtSoru.Text = "Ödülünüz:" +odul.ToString();

                    }
                }
                else if (yarismaciCevap != dogruCevap)
                {
                    switch (zorSoruSayaci)
                    {
                        case 1: odul = 75000; break;
                        case 2: odul = 100000; break;
                        case 3: odul = 150000; break;
                        case 4: odul = 200000; break;
                        case 5: odul = 250000; break;

                    }
                    txtSoru.Text = "Üzgünüm yanlış cevap: \nÖdülünüz:"+odul.ToString();
                    txtSoru.Font = new Font("Microsoft Sans Serif", 25);
                    kontrolleriGizleme();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrSure.Start();
            hangisi = rnd.Next(0, kolaySorular.Length);
            dahaOnceSorulanSoruIndexiKolay.Add(hangisi);
            txtSoru.Text = kolaySorular[hangisi].ToString();
            rbA.Text = kolaySorularSiklar[hangisi * 4].ToString();
            rbB.Text = kolaySorularSiklar[(hangisi * 4) + 1].ToString();
            rbC.Text = kolaySorularSiklar[(hangisi * 4) + 2].ToString();
            rbD.Text = kolaySorularSiklar[(hangisi * 4) + 3].ToString();
        }
        private void tmrSure_Tick(object sender, EventArgs e)
        {
            sure--;
            lblSure.Text = sure.ToString();
            if (sure == 0)
            {
                tmrSure.Stop();
                kontrolleriGizleme();
                txtSoru.Text = "Üzgünüm süre doldu. \nÖdülünüz:";
            }
        }
        private void kontrolleriGizleme()
        {
            rbA.Visible = false;
            rbB.Visible = false;
            rbC.Visible = false;
            rbD.Visible = false;
            btnCevapla.Visible = false;
            pictureBoxSeyirci.Visible = false;
            pictureBoxTelefon.Visible = false;
            pictureBoxYariYariya.Visible = false;
            grbOdul.Visible = false;
            lblSure.Visible = false;
            lblSuretxt.Visible = false;
        }
        private void siklariCevabaEsitleme()
        {

            if (rbA.Checked)
            {
                yarismaciCevap = rbA.Text;
            }
            if (rbB.Checked)
            {
                yarismaciCevap = rbB.Text;
            }
            if (rbC.Checked)
            {
                yarismaciCevap = rbC.Text;
            }
            if (rbD.Checked)
            {
                yarismaciCevap = rbD.Text;
            }
        }
        private void kolayRenklendir()
        {
            switch (kolaySoruSayaci)
            {
                case 1: lbl500.ForeColor = Color.Yellow; break;
                case 2: lbl1000.ForeColor = Color.Yellow; break;
                case 3: lbl2000.ForeColor = Color.Yellow; break;
                case 4: lbl5000.ForeColor = Color.Yellow; break;
                case 5: lbl10000.ForeColor = Color.Yellow; break;
            }

        }
        private void ortaRenklendir()
        {
            switch (ortaSoruSayaci)
            {
                case 1: lbl20000.ForeColor = Color.Yellow; break;
                case 2: lbl30000.ForeColor = Color.Yellow; break;
                case 3: lbl40000.ForeColor = Color.Yellow; break;
                case 4: lbl50000.ForeColor = Color.Yellow; break;
                case 5: lbl75000.ForeColor = Color.Yellow; break;
            }
        }
        private void zorRenklendir()
        {
            switch (zorSoruSayaci)
            {
                case 1: lbl100000.ForeColor = Color.Yellow; break;
                case 2: lbl150000.ForeColor = Color.Yellow; break;
                case 3: lbl200000.ForeColor = Color.Yellow; break;
                case 4: lbl250000.ForeColor = Color.Yellow; break;
                case 5: lbl5000.ForeColor = Color.Yellow; break;
            }
        }

        private void pictureBoxTelefon_Click(object sender, EventArgs e)
        {
            pictureBoxTelefon.Enabled = false;
           pictureBoxTelefon.Image= Properties.Resources.crossed;
            if (tik<5)
            {
                txtIpucu.Text = "Bence doğru cevap:" + kolaySorularinCevaplari[hangisi].ToString();
            }
            if(tik>=5 && tik<10)
            {
                txtIpucu.Text = "Bence doğru cevap:" + ortaSorularinCevaplari[hangisi].ToString();
            }
            if(tik>=10)
            {
                txtIpucu.Text = "Bence doğru cevap:" + zorSorularinCevaplari[hangisi].ToString();
            }
           
        }

        private void pictureBoxSeyirci_Click(object sender, EventArgs e)
        {
            pictureBoxSeyirci.Image = Properties.Resources.crossed;
            int buyukCogunluk;
            int kalan;
            buyukCogunluk =rnd.Next (70,100);
            kalan = 100 - buyukCogunluk;
            pictureBoxSeyirci.Enabled = false;
            if (tik < 5)
            {
                txtIpucu.Text = "Seyirci yüzde "+ buyukCogunluk+"oranında" + kolaySorularinCevaplari[hangisi].ToString()+" tercih etti. \nYüzde" + kalan.ToString()+ "'oranında diğer seçenekleri tercih etti.";

            }
            if (tik >= 5 && tik < 10)
            {
                txtIpucu.Text = "Seyirci yüzde " + buyukCogunluk + "oranında" + ortaSorularinCevaplari[hangisi].ToString() + " tercih etti. \nYüzde" + kalan.ToString() + "'oranında diğer seçenekleri tercih etti.";
            }
            if (tik >= 10)
            {
                txtIpucu.Text = "Seyirci yüzde " + buyukCogunluk + "oranında" + zorSorularinCevaplari[hangisi].ToString() + " tercih etti. \nYüzde" + kalan.ToString() + "'oranında diğer seçenekleri tercih etti.";
            }
        }
        private void pictureBoxYariYariya_Click(object sender, EventArgs e)
        {
            string hangisiDogru;
            pictureBoxYariYariya.Enabled = false;
            pictureBoxYariYariya.Image = Properties.Resources.crossed;
            if (tik < 5)
            {
                hangisiDogru = kolaySorularinCevaplari[hangisi];
                if(hangisiDogru==rbA.Text )
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }
                else if(hangisiDogru == rbB.Text)
                {
                    rbA.Visible = false;
                    rbC.Visible = false;
                }
                else if(hangisiDogru==rbC.Text)
                {
                    rbA.Visible = false;
                    rbD.Visible = false;
                }
                else if(hangisiDogru==rbD.Text)
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }

            }
            if (tik >= 5 && tik < 10)
            {
                hangisiDogru = ortaSorularinCevaplari[hangisi];
                if (hangisiDogru == rbA.Text)
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }
                else if (hangisiDogru == rbB.Text)
                {
                    rbA.Visible = false;
                    rbC.Visible = false;
                }
                else if (hangisiDogru == rbC.Text)
                {
                    rbA.Visible = false;
                    rbD.Visible = false;
                }
                else if (hangisiDogru == rbD.Text)
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }

            }
            if (tik >= 10)
            {
                hangisiDogru = zorSorularinCevaplari[hangisi];
                if (hangisiDogru == rbA.Text)
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }
                else if (hangisiDogru == rbB.Text)
                {
                    rbA.Visible = false;
                    rbC.Visible = false;
                }
                else if (hangisiDogru == rbC.Text)
                {
                    rbA.Visible = false;
                    rbD.Visible = false;
                }
                else if (hangisiDogru == rbD.Text)
                {
                    rbB.Visible = false;
                    rbC.Visible = false;
                }
            }
        }
    }
}
