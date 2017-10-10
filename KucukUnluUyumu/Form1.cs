using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using net.zemberek.erisim;
using net.zemberek.islemler;
using net.zemberek.islemler.cozumleme;
using net.zemberek.yapi;
using net.zemberek.tr.yapi;

namespace KucukUnluUyumu
{
    public partial class Form1 : Form
    {
        Zemberek zemberek = new Zemberek(new TurkiyeTurkcesi());
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private Sonuc KelimeKontrol(String Kelime)
        {
            Sonuc sonuc = new Sonuc();

            Heceleyici heceleyici = zemberek.heceleyici();
            Boolean b = heceleyici.hecelenebilirmi(Kelime);
            if (!zemberek.kelimeDenetle(Kelime))
            {
                sonuc.msg = (Kelime + " kelimesi dogru yazılmamış.");
                sonuc.sonuc = false;
            }
            else if (!b)
            {
                sonuc.msg = (Kelime + " kelimesi hecelenemez.");
                sonuc.sonuc = false;
            }
            else
            {
                sonuc.msg = "";
                sonuc.sonuc = true;
            }
            return sonuc;
        }
        private void Btn_kucukUnluUyumuKontrolEt_Click(object sender, EventArgs e)
        {
            if(Txt_kelimeGir.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kelime giriniz.");
                return;
            }else if(Txt_kelimeGir.Text.Trim().Length >0 && Txt_kelimeGir.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Kelime boşluk içeremez giriniz.");
                return;
            }
            Sonuc sonuc = KucukUnluUyumunaBak(Txt_kelimeGir.Text.Trim());
            if (sonuc.sonuc)
                Txt_Durum.ForeColor = Color.Green;
            else
                Txt_Durum.ForeColor = Color.Red;

            Txt_Durum.Text =sonuc.msg;
        }

        private void Txt_kelimeGir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sonuc sonuc = KucukUnluUyumunaBak(Txt_kelimeGir.Text);
                if (sonuc.sonuc)
                    Txt_Durum.ForeColor = Color.Green;
                else
                    Txt_Durum.ForeColor = Color.Red;

                Txt_Durum.Text = sonuc.msg;
            }
        }

        //Bir sözcükte düz ünlü harflerden(a, e, ı, i) sonra 
        //yine düz ünlü harfler(a, e, ı, i) gelebilir.
        //Yani düz ünlülerden sonra yuvarlak ünlüler(o, ö, u, ü) gelemez.
        //Gelirse bu sözcük küçük ünlü uyumuna uymaz
        // Kelimenin ilk hecesinde yuvarlak sesli harf (o,ö,u,ü) varsa, 
        //diğer hecelerinde ya düz-geniş (a,e), ya da dar-yuvarlak (u,ü) sesli harf bulunması gerekir
        //tek hecelide küçük ünlü uyumu aranmaz
        private Sonuc KucukUnluUyumunaBak(String kelime)
        {
            Sonuc sonuc = KelimeKontrol(kelime);
            if (!sonuc.sonuc)
                return sonuc;

            sonuc = IstisnaKontrol(kelime);
            if (!sonuc.sonuc)
                return sonuc;

            sonuc = new Sonuc();

            Boolean ilkHarfCtrl = false,
                ilkSesliHarfDuzMu = false,
                ilkSesliHarfYuvarlakMi = false,
                ilkSesliHarfMi = false;

            TurkceDilBilgisi dilBilgisi = new TurkceDilBilgisi(new TurkiyeTurkcesi());
            Alfabe alfabe = dilBilgisi.alfabe();

            List<Char> harfler = kelime.ToList();
            Boolean uyma = false;
            for (int i = 0; i < harfler.Count; i++)
            {
                TurkceHarf simdikiSesliHarf = alfabe.harf(harfler[i]);
                if (!simdikiSesliHarf.sesliMi())
                    continue;
                if (!ilkHarfCtrl)
                {
                    if (simdikiSesliHarf.yuvarlakSesliMi())
                    {
                        ilkSesliHarfYuvarlakMi = true;
                        ilkSesliHarfMi = true;
                    }
                    else if (simdikiSesliHarf.duzSesliMi())
                    {
                        ilkSesliHarfDuzMu = true;
                    }
                    else
                        break;

                    ilkHarfCtrl = true;
                }
                if (ilkSesliHarfDuzMu)
                {
                    if (simdikiSesliHarf.duzSesliMi())
                    {
                        uyma = true;
                    }
                    else
                    {
                        uyma = false;
                        break;
                    }
                }
                else if (ilkSesliHarfYuvarlakMi)
                {
                    if (ilkSesliHarfMi)
                    {
                        ilkSesliHarfMi = false;
                        continue;
                    }

                    if (!ilkSesliHarfMi)
                    {
                        char c = simdikiSesliHarf.charDeger();

                        if (DuzGenisYadaDarYuvarlakMi(Convert.ToString(c)))
                        {
                            uyma = true;
                        }
                        else
                        {
                            uyma = false;
                            break;
                        }
                    }
                }
            }
            sonuc.sonuc = uyma;
            if (uyma)
                sonuc.msg ="'"+ kelime+ "' kelimesi küçük ünlü uyumuna uyar.";
            else
                sonuc.msg = "'" + kelime + "' kelimesi küçük ünlü uyumuna uymaz.";

            return sonuc;
        }


        private Sonuc IstisnaKontrol(String kelime)
        {
            Sonuc sonuc = new Sonuc();

            if (zemberek.hecele(kelime).Length > 1)
                sonuc.sonuc = true;
            else
            {
                sonuc.sonuc = false;
                sonuc.msg = ("Tek heceli kelimelerde küçük ünlü uyumu aranmaz.");
            }

            return sonuc;
        }


        private bool DuzGenisYadaDarYuvarlakMi(String harf)
        {
            String ha = "aeuüAEUÜ";

            return ha.Contains(harf);
        }
    }

    internal class Sonuc
    {
        public Boolean sonuc;
        public String msg;
    }
}
/*
Heceleyici heceleyici = zemberek.heceleyici();
            Boolean b = heceleyici.hecelenebilirmi(txt_kelimeGir.Text);
            if (!zemberek.kelimeDenetle(txt_kelimeGir.Text.ToString()))
            {
                MessageBox.Show(txt_kelimeGir.Text.ToString() + " kelimesi dogru yazilmamis");
                return false;
            }
            else if (!b)
            {
                MessageBox.Show("Hecelenemez");
                return false;
            }
            return true;
*/
