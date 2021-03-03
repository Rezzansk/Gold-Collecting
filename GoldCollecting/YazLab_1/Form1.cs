using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static FileStream fs_a = new FileStream("a.txt", FileMode.OpenOrCreate, FileAccess.Write);
        public static FileStream fs_b = new FileStream("b.txt", FileMode.OpenOrCreate, FileAccess.Write);
        public static FileStream fs_c = new FileStream("c.txt", FileMode.OpenOrCreate, FileAccess.Write);
        public static FileStream fs_d = new FileStream("d.txt", FileMode.OpenOrCreate, FileAccess.Write);
        public static StreamWriter sw_a = new StreamWriter(fs_a);
        public static StreamWriter sw_b = new StreamWriter(fs_b);
        public static StreamWriter sw_c = new StreamWriter(fs_c);
        public static StreamWriter sw_d = new StreamWriter(fs_d);

        public static int boyut;
        public static int adim;
        public static int c_gizli;  // açması gereken gizli altın sayısı
        public static int Ax = 0, Ay = 0, Bx = 0, By = 0, Cx = 0, Cy = 0, Dx = 0, Dy = 0;
        public static int[,] dizi;    //matris
        public static int[,] dizi_g;  //gizli altın matrisi
        public static int[,] dizi_d;    //matris
        public static int[] altin;    //matris
        public static Button[,] buttonArray;
        public static int altin_yuzde;
        public static int gizli_altin;
        public static int altin_sayisi;

        public static int hamlea = 0;
        public static Boolean hedef_a = false;
        public static int hedef_ax;
        public static int hedef_ay;

        public static int hamleb = 0;
        public static Boolean hedef_b = false;
        public static int hedef_bx = 0;
        public static int hedef_by = 0;

        public static int hamlec = 0;
        public static Boolean hedef_c = false;
        public static int hedef_cx = 0;
        public static int hedef_cy = 0;

        public static int hamled = 0;
        public static Boolean hedef_d = false;
        public static int hedef_dx = 0;
        public static int hedef_dy = 0;

        public static int puan_hamle_a;
        public static int puan_hedef_a;
        public static int puan_hamle_b;
        public static int puan_hedef_b;
        public static int puan_hamle_c;
        public static int puan_hedef_c;
        public static int puan_hamle_d;
        public static int puan_hedef_d;

        public static int adim_sayisi_a = 0;
        public static int adim_sayisi_b = 0;
        public static int adim_sayisi_c = 0;
        public static int adim_sayisi_d = 0;
        public static int harcanan_altin_a = 0;
        public static int harcanan_altin_b = 0;
        public static int harcanan_altin_c = 0;
        public static int harcanan_altin_d = 0;
        public static int toplanan_altin_a = 0;
        public static int toplanan_altin_b = 0;
        public static int toplanan_altin_c = 0;
        public static int toplanan_altin_d = 0;

        public static int temp_min = 9999999;
        public static int x;
        public static int y;
        public static int bitti = 1;

        public static int sonuc()
        {
            MessageBox.Show("\t            A Kullanıcısı - B Kullanıcısı - C Kullanıcısı - D Kullanıcısı" + "\n" +
                            "--------------------------------------------------------------------------------------------" + "\n" +
                            "Toplam Adım Sayisi:    " + "\t" + adim_sayisi_a + "\t" + adim_sayisi_b + "\t" + adim_sayisi_c + "\t" + adim_sayisi_d + "\n" +
                            "Harcanan Altın Miktarı:" + "\t" + harcanan_altin_a + "\t" + harcanan_altin_b + "\t" + harcanan_altin_c + "\t" + harcanan_altin_d + "\n" +
                            "Kasadaki Altın Miktarı:" + "\t" + altin[0] + "\t" + altin[1] + "\t" + altin[2] + "\t" + altin[3] + "\n" +
                            "Toplanan Altın Miktarı:" + "\t" + toplanan_altin_a + "\t" + toplanan_altin_b + "\t" + toplanan_altin_c + "\t" + toplanan_altin_d + "\t");
            sw_a.Close();
            sw_b.Close();
            sw_c.Close();
            sw_d.Close();

            return 0;
        }

        public static void bitti_mi()
        {
            if (altin[0] <= 0 && altin[1] <= 0 && altin[2] <= 0 && altin[3] <= 0)
            {
                sw_a.WriteLine("TÜM OYUNCULARIN ALTINI BİTTİĞİ İÇİN OYUN BİTER!");
                sw_b.WriteLine("TÜM OYUNCULARIN ALTINI BİTTİĞİ İÇİN OYUN BİTER!");
                sw_c.WriteLine("TÜM OYUNCULARIN ALTINI BİTTİĞİ İÇİN OYUN BİTER!");
                sw_d.WriteLine("TÜM OYUNCULARIN ALTINI BİTTİĞİ İÇİN OYUN BİTER!");

                bitti = sonuc();
            }

            if (altin_sayisi == 0)
            {
                sw_a.WriteLine("KAZILACAK ALTIN KALMADIĞI İÇİN OYUN BİTER!");
                sw_b.WriteLine("KAZILACAK ALTIN KALMADIĞI İÇİN OYUN BİTER!");
                sw_c.WriteLine("KAZILACAK ALTIN KALMADIĞI İÇİN OYUN BİTER!");
                sw_d.WriteLine("KAZILACAK ALTIN KALMADIĞI İÇİN OYUN BİTER!");

                bitti = sonuc();
            }
        }

        public static void A_hedef()
        {
            temp_min = 9999999;
            int x = Ax;
            int y = Ay;
            hedef_ax = 0;
            hedef_ay = 0;

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (dizi[i, j] != 0)
                    {
                        hamlea = Math.Abs(i - x) + Math.Abs(j - y);
                        if (hamlea < temp_min)
                        {
                            temp_min = hamlea;
                            hedef_ax = i;
                            hedef_ay = j;
                        }
                        if (hamlea == temp_min)
                        {
                            if (dizi[i, j] > dizi[hedef_ax, hedef_ay])
                            {
                                temp_min = hamlea;
                                hedef_ax = i;
                                hedef_ay = j;
                            }
                        }

                    }
                }
            }
            hamlea = temp_min;
            altin[0] = altin[0] - puan_hedef_a;
            harcanan_altin_a = harcanan_altin_a + puan_hedef_a;
            hedef_a = true;
            sw_a.WriteLine("HEDEF BELİRLENDİ| X:" + hedef_ax + "\tY:" + hedef_ay + "\tHAMLE SAYISI:" + hamlea);
        }

        public static void hedef_ilerleme_a()
        {
            buttonArray[Ax, Ay].Text = "0";
            buttonArray[Ax, Ay].BackColor = DefaultBackColor;

            altin[0] = altin[0] - puan_hamle_a;
            harcanan_altin_a = harcanan_altin_a + puan_hamle_a;

            for (int j = 0; j < adim; j++)
            {
                if ((hedef_ax - Ax) > 0)
                {
                    Ax++;
                    adim_sayisi_a++;
                    hamlea--;
                    sw_a.WriteLine("X koordinatı bir adım artar. Aşağı yönlüdür.");
                    if (dizi_g[Ax, Ay] != 0)    //gizli altın kontrolü
                    {
                        dizi[Ax, Ay] = dizi_g[Ax, Ay];
                        sw_a.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Ax + "\t" + Ay + "\t Değeri:" + dizi[Ax, Ay]);
                        dizi_g[Ax, Ay] = 0;
                    }
                }
                else if ((hedef_ax - Ax) < 0)
                {
                    Ax--;
                    adim_sayisi_a++;
                    hamlea--;
                    sw_a.WriteLine("X koordinatı bir adım azalır. Yukarı yönlüdür.");
                    if (dizi_g[Ax, Ay] != 0)
                    {
                        dizi[Ax, Ay] = dizi_g[Ax, Ay];
                        sw_a.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Ax + "\t" + Ay + "\t Değeri:" + dizi[Ax, Ay]);
                        dizi_g[Ax, Ay] = 0;
                    }
                }
                else if ((hedef_ay - Ay) > 0)
                {
                    Ay++;
                    adim_sayisi_a++;
                    hamlea--;
                    sw_a.WriteLine("Y koordinatı bir adım artar. Sağ yönlüdür.");

                    if (dizi_g[Ax, Ay] != 0)
                    {
                        dizi[Ax, Ay] = dizi_g[Ax, Ay];
                        sw_a.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Ax + "\t" + Ay + "\t Değeri:" + dizi[Ax, Ay]);
                        dizi_g[Ax, Ay] = 0;
                    }
                }
                else if ((hedef_ay - Ay) < 0)
                {
                    Ay--;
                    adim_sayisi_a++;
                    hamlea--;
                    sw_a.WriteLine("Y koordinatı bir adım artar. Sol yönlüdür.");

                    if (dizi_g[Ax, Ay] != 0)
                    {
                        dizi[Ax, Ay] = dizi_g[Ax, Ay];
                        sw_a.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Ax + "\t" + Ay + "\t Değeri:" + dizi[Ax, Ay]);
                        dizi_g[Ax, Ay] = 0;
                    }
                }
            }

            if (hedef_ax == Ax && hedef_ay == Ay)
            {
                hedef_a = false;
                sw_a.WriteLine("HEDEFE ULAŞIR.");
                if (dizi[hedef_ax, hedef_ay] != 0)
                {
                    altin_sayisi--;
                }
                altin[0] = altin[0] + dizi[hedef_ax, hedef_ay];
                toplanan_altin_a = toplanan_altin_a + dizi[hedef_ax, hedef_ay];
                dizi[hedef_ax, hedef_ay] = 0;
                dizi_g[hedef_ax, hedef_ay] = 0;
            }

            sw_a.WriteLine("Hamle Hakkı Bitince Konumu| X:" + Ax + "\tY:" + Ay + "\tHedefe Kalan Hamle Sayısı:" + hamlea);

            buttonArray[Ax, Ay].Text = "A";
            buttonArray[Ax, Ay].BackColor = Color.Red;
        }

        public static void B_hedef()
        {
            int hamle_temp = 0;
            buttonArray[Bx, By].Text = "0";
            x = Bx;
            y = By;
            hedef_bx = 0;
            hedef_by = 0;
            hamleb = 0;
            Boolean negatif = true;
            int masraf, masraftemp;

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (dizi[i, j] != 0)
                    {
                        hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                        if (hamle_temp % adim == 0)    // hamle sayısı hesabı
                            masraftemp = hamle_temp / adim;
                        else
                            masraftemp = (hamle_temp / adim) + 1;

                        if (hamleb % adim == 0)
                            masraf = hamleb / adim;
                        else
                            masraf = (hamleb / adim) + 1;

                        if ((dizi[i, j] - (masraftemp * puan_hamle_b)) > (dizi[hedef_bx, hedef_by] - (masraf * puan_hamle_b)))
                        {
                            hamleb = hamle_temp;
                            hedef_bx = i;
                            hedef_by = j;
                            negatif = false;
                        }

                        if ((dizi[i, j] - (masraftemp * puan_hamle_b)) == (dizi[hedef_bx, hedef_by] - (masraf * puan_hamle_b)))
                        {
                            if (hamle_temp < hamleb)
                            {
                                hamleb = hamle_temp;
                                hedef_bx = i;
                                hedef_by = j;
                                negatif = false;
                            }
                        }

                    }
                }
            }

            if (negatif == true)   ///Hedefe giderken "-" ye düşünce yapması gereken
            {
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        if (dizi[i, j] != 0)
                        {
                            hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                            if (hamle_temp % adim == 0)    // hamle sayısı hesabı
                                masraftemp = hamle_temp / adim;
                            else
                                masraftemp = (hamle_temp / adim) + 1;

                            if (hamleb % adim == 0)
                                masraf = hamleb / adim;
                            else
                                masraf = (hamleb / adim) + 1;

                            if (Math.Abs(dizi[i, j] - (masraftemp * puan_hamle_b)) > Math.Abs(dizi[hedef_bx, hedef_by] - (masraf * puan_hamle_b)))
                            {
                                hamleb = hamle_temp;
                                hedef_bx = i;
                                hedef_by = j;
                            }

                            if (Math.Abs(dizi[i, j] - (masraftemp * puan_hamle_b)) == Math.Abs(dizi[hedef_bx, hedef_by] - (masraf * puan_hamle_b)))
                            {
                                if (hamle_temp < hamleb)
                                {
                                    hamleb = hamle_temp;
                                    hedef_bx = i;
                                    hedef_by = j;
                                }
                            }
                        }


                    }
                }
            }

            hedef_b = true;
            altin[1] = altin[1] - puan_hedef_b;
            harcanan_altin_b = harcanan_altin_b + puan_hedef_b;
            buttonArray[Bx, By].Text = "B";
            sw_b.WriteLine("HEDEF BELİRLENDİ| X:" + hedef_bx + "\tY:" + hedef_by + "\tHAMLE SAYISI:" + hamleb);
        }

        public static void hedef_ilerleme_b()
        {
            buttonArray[Bx, By].Text = "0";
            buttonArray[Bx, By].BackColor = DefaultBackColor;

            altin[1] = altin[1] - puan_hamle_b;
            harcanan_altin_b = harcanan_altin_b + puan_hamle_b;

            for (int j = 0; j < adim; j++)
            {
                if ((hedef_by - By) > 0)
                {
                    By++;
                    adim_sayisi_b++;
                    sw_b.WriteLine("Y koordinatı bir adım artar. Sağ yönlüdür.");
                    hamleb--;
                    if (dizi_g[Bx, By] != 0)    //gizli altın kontrolü
                    {
                        dizi[Bx, By] = dizi_g[Bx, By];
                        sw_b.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Bx + "\t" + By + "\t Değeri:" + dizi[Bx, By]);
                        dizi_g[Bx, By] = 0;
                    }
                }
                else if ((hedef_by - By) < 0)
                {
                    By--;
                    adim_sayisi_b++;
                    sw_b.WriteLine("Y koordinatı bir adım azalır. Sol yönlüdür.");
                    hamleb--;
                    if (dizi_g[Bx, By] != 0)    //gizli altın kontrolü
                    {
                        dizi[Bx, By] = dizi_g[Bx, By];
                        sw_b.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Bx + "\t" + By + "\t Değeri:" + dizi[Bx, By]);
                        dizi_g[Bx, By] = 0;
                    }
                }
                else if ((hedef_bx - Bx) > 0)
                {
                    Bx++;
                    adim_sayisi_b++;
                    sw_b.WriteLine("X koordinatı bir adım artar. Aşağı yönlüdür.");
                    hamleb--;
                    if (dizi_g[Bx, By] != 0)    //gizli altın kontrolü
                    {
                        dizi[Bx, By] = dizi_g[Bx, By];
                        sw_b.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Bx + "\t" + By + "\t Değeri:" + dizi[Bx, By]);
                        dizi_g[Bx, By] = 0;
                    }
                }
                else if ((hedef_bx - Bx) < 0)
                {
                    Bx--;
                    adim_sayisi_b++;
                    sw_b.WriteLine("X koordinatı bir adım azalır. Yukarı yönlüdür.");
                    hamleb--;
                    if (dizi_g[Bx, By] != 0)    //gizli altın kontrolü
                    {
                        dizi[Bx, By] = dizi_g[Bx, By];
                        sw_b.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Bx + "\t" + By + "\t Değeri:" + dizi[Bx, By]);
                        dizi_g[Bx, By] = 0;
                    }
                }
            }

            if (hedef_bx == Bx && hedef_by == By)
            {
                hedef_b = false;
                hamleb = 0;
                sw_b.WriteLine("HEDEFE ULAŞIR.");
                if (dizi[hedef_bx, hedef_by] != 0)
                {
                    altin_sayisi--;
                }
                altin[1] = altin[1] + dizi[hedef_bx, hedef_by];
                toplanan_altin_b = toplanan_altin_b + dizi[hedef_bx, hedef_by];
                dizi[hedef_bx, hedef_by] = 0;
                dizi_g[hedef_bx, hedef_by] = 0;
            }

            sw_b.WriteLine("Hamle Hakkı Bitince Konumu| X:" + Bx + "\tY:" + By + "\tHedefe Kalan Hamle Sayısı:" + hamleb);

            buttonArray[Bx, By].Text = "B";
            buttonArray[Bx, By].BackColor = Color.Blue;
        }

        public static void C_hedef()
        {
            hamlec = 0;
            temp_min = 9999999;
            buttonArray[Cx, Cy].Text = "0";

            x = Cx;
            y = Cy;
            hedef_cx = 0;
            hedef_cy = 0;
            //// gizli altınları açar
            for (int k = 0; k < c_gizli; k++)
            {
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        if (dizi_g[i, j] != 0)
                        {
                            hamlec = Math.Abs(i - x) + Math.Abs(j - y);
                            if (hamlec < temp_min)
                            {
                                temp_min = hamlec;
                                hedef_cx = i;
                                hedef_cy = j;
                            }
                        }
                    }
                }
                dizi[hedef_cx, hedef_cy] = dizi_g[hedef_cx, hedef_cy];
                if (dizi[hedef_cx, hedef_cy] != 0)
                {
                    sw_c.WriteLine("GİZLİ ALTIN AÇILDI| X:" + hedef_cx + "\tY:" + hedef_cy + "\tALTIN DEĞERİ:" + dizi[hedef_cx, hedef_cy]);
                }
                else
                {
                    sw_c.WriteLine("GİZLİ ALTIN BULUNMAMAKTADIR.");
                }
                dizi_g[hedef_cx, hedef_cy] = 0;
                buttonArray[hedef_cx, hedef_cy].Text = dizi[hedef_cx, hedef_cy].ToString();
                temp_min = 9999999;
                hedef_cx = 0;
                hedef_cy = 0;
            }

            //// C hedef
            int hamle_temp = 0;
            hedef_cx = 0;
            hedef_cy = 0;
            hamlec = 0;
            int masraf = 0;
            int masraftemp = 0;
            temp_min = 99999;

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (dizi[i, j] != 0)
                    {
                        hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                        if (hamle_temp % adim == 0)
                            masraftemp = hamle_temp / adim;
                        else
                            masraftemp = (hamle_temp / adim) + 1;

                        if (hamlec % adim == 0)
                            masraf = hamlec / adim;
                        else
                            masraf = (hamlec / adim) + 1;

                        if ((dizi[i, j] - (masraftemp * puan_hamle_c)) > (dizi[hedef_cx, hedef_cy] - (masraf * puan_hamle_c)))
                        {
                            hamlec = hamle_temp;
                            hedef_cx = i;
                            hedef_cy = j;
                        }

                        if ((dizi[i, j] - (masraftemp * puan_hamle_c)) == (dizi[hedef_cx, hedef_cy] - (masraf * puan_hamle_c)))
                        {
                            if (hamle_temp < hamlec)
                            {
                                hamlec = hamle_temp;
                                hedef_cx = i;
                                hedef_cy = j;
                            }
                        }
                    }
                }
            }

            if (hedef_cx == 0 && hedef_cy == 0)   ///Hedefe giderken "-" ye düşünce yapması gereken
            {
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        if (dizi[i, j] != 0)
                        {
                            hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                            if (hamle_temp % adim == 0)
                                masraftemp = hamle_temp / adim;
                            else
                                masraftemp = (hamle_temp / adim) + 1;

                            if (hamlec % adim == 0)
                                masraf = hamlec / adim;
                            else
                                masraf = (hamlec / adim) + 1;

                            if (Math.Abs((dizi[i, j] - (masraftemp * puan_hamle_c))) > Math.Abs((dizi[hedef_cx, hedef_cy] - (masraf * puan_hamle_c))))
                            {
                                hamlec = hamle_temp;
                                hedef_cx = i;
                                hedef_cy = j;
                            }

                            if (Math.Abs((dizi[i, j] - (masraftemp * puan_hamle_c))) == Math.Abs((dizi[hedef_cx, hedef_cy] - (masraf * puan_hamle_c))))
                            {
                                if (hamle_temp < hamlec)
                                {
                                    hamlec = hamle_temp;
                                    hedef_cx = i;
                                    hedef_cy = j;
                                }
                            }
                        }
                    }
                }
            }


            hedef_c = true;
            altin[2] = altin[2] - puan_hedef_c;
            harcanan_altin_c = harcanan_altin_c + puan_hedef_c;
            buttonArray[Cx, Cy].Text = "C";
            sw_c.WriteLine("HEDEF BELİRLENDİ| X:" + hedef_cx + "\tY:" + hedef_cy + "\tHAMLE SAYISI:" + hamlec);
        }

        public static void hedef_ilerleme_c()
        {
            buttonArray[Cx, Cy].Text = "0";
            buttonArray[Cx, Cy].BackColor = DefaultBackColor;
            altin[2] = altin[2] - puan_hamle_c;
            harcanan_altin_c = harcanan_altin_c + puan_hamle_c;

            for (int j = 0; j < adim; j++)
            {
                if ((hedef_cx - Cx) > 0)
                {
                    Cx++;
                    adim_sayisi_c++;
                    sw_c.WriteLine("X koordinatı bir adım artar. Aşağı yönlüdür.");
                    hamlec--;
                    if (dizi_g[Cx, Cy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Cx, Cy] = dizi_g[Cx, Cy];
                        sw_c.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Cx + "\t" + Cy + "\t Değeri:" + dizi[Cx, Cy]);
                        dizi_g[Cx, Cy] = 0;
                    }
                }
                else if ((hedef_cx - Cx) < 0)
                {
                    Cx--;
                    adim_sayisi_c++;
                    sw_c.WriteLine("X koordinatı bir adım azalır. Yukarı yönlüdür.");
                    hamlec--;
                    if (dizi_g[Cx, Cy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Cx, Cy] = dizi_g[Cx, Cy];
                        sw_c.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Cx + "\t" + Cy + "\t Değeri:" + dizi[Cx, Cy]);
                        dizi_g[Cx, Cy] = 0;
                    }
                }
                else if ((hedef_cy - Cy) > 0)
                {
                    Cy++;
                    adim_sayisi_c++;
                    sw_c.WriteLine("Y koordinatı bir adım artar. Sağ yönlüdür.");
                    hamlec--;
                    if (dizi_g[Cx, Cy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Cx, Cy] = dizi_g[Cx, Cy];
                        sw_c.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Cx + "\t" + Cy + "\t Değeri:" + dizi[Cx, Cy]);
                        dizi_g[Cx, Cy] = 0;
                    }
                }
                else if ((hedef_cy - Cy) < 0)
                {
                    Cy--;
                    adim_sayisi_c++;
                    sw_c.WriteLine("Y koordinatı bir adım azalır. Sol yönlüdür.");
                    hamlec--;
                    if (dizi_g[Cx, Cy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Cx, Cy] = dizi_g[Cx, Cy];
                        sw_c.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Cx + "\t" + Cy + "\t Değeri:" + dizi[Cx, Cy]);
                        dizi_g[Cx, Cy] = 0;
                    }
                }
            }

            if (hedef_cx == Cx && hedef_cy == Cy)
            {
                hedef_c = false;
                hamlec = 0;
                sw_c.WriteLine("HEDEFE ULAŞIR.");
                if (dizi[hedef_cx, hedef_cy] != 0)
                {
                    altin_sayisi--;
                }
                altin[2] = altin[2] + dizi[hedef_cx, hedef_cy];
                toplanan_altin_c = toplanan_altin_c + dizi[hedef_cx, hedef_cy];
                dizi[hedef_cx, hedef_cy] = 0;
                dizi_g[hedef_cx, hedef_cy] = 0;
            }

            sw_c.WriteLine("Hamle Hakkı Bitince Konumu| X:" + Cx + "\tY:" + Cx + "\tHedefe Kalan Hamle Sayısı:" + hamlec);

            buttonArray[Cx, Cy].Text = "C";
            buttonArray[Cx, Cy].BackColor = Color.Yellow;
        }

        public static void D_hedef()
        {
            ///// D Oyuncusu Hedef Belirleme
            buttonArray[Dx, Dy].Text = "0";
            int[] hamle = new int[3] { hamlea, hamleb, hamlec };
            int hamle_temp = 0;
            x = Dx;
            y = Dy;
            hedef_dx = 0;
            hedef_dy = 0;
            hamled = 0;
            int masraf = 0;
            int masraftemp = 0;
            temp_min = 99999;
            int temp_hedef = 0;
            x = Dx;
            y = Dy;
            int temp_d = 0;
            int[] dizi_temp = new int[3] { 0, 0, 0 };

            if (hamle[0] % adim == 0)
                hamle[0] = hamle[0] / adim;
            else
                hamle[0] = (hamle[0] / adim) + 1;

            if (hamle[1] % adim == 0)
                hamle[1] = hamle[1] / adim;
            else
                hamle[1] = (hamle[1] / adim) + 1;

            if (hamle[2] % adim == 0)
                hamle[2] = hamle[2] / adim;
            else
                hamle[2] = (hamle[2] / adim) + 1;

            dizi_temp[0] = dizi[hedef_ax, hedef_ay];
            dizi_temp[1] = dizi[hedef_bx, hedef_by];
            dizi_temp[2] = dizi[hedef_cx, hedef_cy];

            temp_d = Math.Abs(hedef_ax - x) + Math.Abs(hedef_ay - y);

            if (temp_d % adim == 0)
                temp_d = temp_d / adim;
            else
                temp_d = (temp_d / adim) + 1;

            if (temp_d > hamle[0])
            {
                dizi[hedef_ax, hedef_ay] = 0;
                sw_d.WriteLine("A oyuncusundan önce erişemeyeceği için A'nın hedefini hesaplamaz. X:" + hedef_ax + "\tY:" + hedef_ay);
            }
            temp_d = Math.Abs(hedef_bx - x) + Math.Abs(hedef_by - y);
            if (temp_d > hamle[1])
            {
                dizi[hedef_bx, hedef_by] = 0;
                sw_d.WriteLine("B oyuncusundan önce erişemeyeceği için B'nın hedefini hesaplamaz. X:" + hedef_bx + "\tY:" + hedef_by);
            }
            temp_d = Math.Abs(hedef_cx - x) + Math.Abs(hedef_cy - y);
            if (temp_d > hamle[2])
            {
                dizi[hedef_cx, hedef_cy] = 0;
                sw_d.WriteLine("C oyuncusundan önce erişemeyeceği için C'nın hedefini hesaplamaz. X:" + hedef_cx + "\tY:" + hedef_cy);
            }

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (dizi[i, j] != 0)
                    {
                        hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                        if (hamle_temp % adim == 0)
                            masraftemp = hamle_temp / adim;
                        else
                            masraftemp = (hamle_temp / adim) + 1;

                        if (hamled % adim == 0)
                            masraf = hamled / adim;
                        else
                            masraf = (hamled / adim) + 1;

                        if ((dizi[i, j] - (masraftemp * puan_hamle_d)) > (dizi[hedef_dx, hedef_dy] - (masraf * puan_hamle_d)))
                        {
                            hamled = hamle_temp;
                            hedef_dx = i;
                            hedef_dy = j;
                        }

                        if ((dizi[i, j] - (masraftemp * puan_hamle_d)) == (dizi[hedef_dx, hedef_dy] - (masraf * puan_hamle_d)))
                        {
                            if (hamle_temp < hamled)
                            {
                                hamled = hamle_temp;
                                hedef_dx = i;
                                hedef_dy = j;
                            }
                        }
                    }
                }
            }

            if (hedef_dx == 0 && hedef_dy == 0)   ///Hedefe giderken "-" ye düşünce yapması gereken
            {
                for (int i = 0; i < boyut; i++)
                {
                    for (int j = 0; j < boyut; j++)
                    {
                        if (dizi[i, j] != 0)
                        {
                            hamle_temp = Math.Abs(i - x) + Math.Abs(j - y); // masraf hesabı

                            if (hamle_temp % adim == 0)
                                masraftemp = hamle_temp / adim;
                            else
                                masraftemp = (hamle_temp / adim) + 1;

                            if (hamled % adim == 0)
                                masraf = hamled / adim;
                            else
                                masraf = (hamled / adim) + 1;

                            if (Math.Abs(dizi[i, j] - (masraftemp * puan_hamle_d)) > Math.Abs(dizi[hedef_dx, hedef_dy] - (masraf * puan_hamle_d)))
                            {
                                hamled = hamle_temp;
                                hedef_dx = i;
                                hedef_dy = j;
                            }

                            if (Math.Abs(dizi[i, j] - (masraftemp * puan_hamle_d)) == Math.Abs(dizi[hedef_dx, hedef_dy] - (masraf * puan_hamle_d)))
                            {
                                if (hamle_temp < hamled)
                                {
                                    hamled = hamle_temp;
                                    hedef_dx = i;
                                    hedef_dy = j;
                                }
                            }
                        }
                    }
                }

            }

            dizi[hedef_ax, hedef_ay] = dizi_temp[0];
            dizi[hedef_bx, hedef_by] = dizi_temp[1];
            dizi[hedef_cx, hedef_cy] = dizi_temp[2];

            hedef_d = true;
            altin[3] = altin[3] - puan_hedef_d;
            harcanan_altin_d = harcanan_altin_d + puan_hedef_d;
            buttonArray[Dx, Dy].Text = "D";
            sw_d.WriteLine("HEDEF BELİRLENDİ| X:" + hedef_dx + "\tY:" + hedef_dy + "\tHAMLE SAYISI:" + hamled);
        }

        public static void hedef_ilerleme_d()
        {
            buttonArray[Dx, Dy].Text = "0";
            buttonArray[Dx, Dy].BackColor = DefaultBackColor;
            altin[3] = altin[3] - puan_hamle_d;
            harcanan_altin_d = harcanan_altin_d + puan_hamle_d;

            for (int j = 0; j < adim; j++)
            {
                if ((hedef_dy - Dy) > 0)
                {
                    Dy++;
                    adim_sayisi_d++;
                    sw_d.WriteLine("Y koordinatı bir adım artar. Sağ yönlüdür.");
                    hamled--;
                    if (dizi_g[Dx, Dy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Dx, Dy] = dizi_g[Dx, Dy];
                        sw_d.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Dx + "\t" + Dy + "\t Değeri:" + dizi[Dx, Dy]);
                        dizi_g[Dx, Dy] = 0;
                    }
                }
                else if ((hedef_dy - Dy) < 0)
                {
                    Dy--;
                    adim_sayisi_d++;
                    sw_d.WriteLine("Y koordinatı bir adım azalır. Sol yönlüdür.");
                    hamled--;
                    if (dizi_g[Dx, Dy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Dx, Dy] = dizi_g[Dx, Dy];
                        sw_d.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Dx + "\t" + Dy + "\t Değeri:" + dizi[Dx, Dy]);
                        dizi_g[Dx, Dy] = 0;
                    }
                }
                else if ((hedef_dx - Dx) > 0)
                {
                    Dx++;
                    adim_sayisi_d++;
                    sw_d.WriteLine("X koordinatı bir adım artar. Aşağı yönlüdür.");
                    hamled--;
                    if (dizi_g[Dx, Dy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Dx, Dy] = dizi_g[Dx, Dy];
                        sw_d.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Dx + "\t" + Dy + "\t Değeri:" + dizi[Dx, Dy]);
                        dizi_g[Dx, Dy] = 0;
                    }
                }
                else if ((hedef_dx - Dx) < 0)
                {
                    Dx--;
                    adim_sayisi_d++;
                    sw_d.WriteLine("X koordinatı bir adım azalır. Yukarı yönlüdür.");
                    hamled--;
                    if (dizi_g[Dx, Dy] != 0)    //gizli altın kontrolü
                    {
                        dizi[Dx, Dy] = dizi_g[Dx, Dy];
                        sw_d.WriteLine("Gizli altın üzerinden geçer ve açılır. Koordinatları:" + Dx + "\t" + Dy + "\t Değeri:" + dizi[Dx, Dy]);
                        dizi_g[Dx, Dy] = 0;
                    }
                }
            }

            if (hedef_dx == Dx && hedef_dy == Dy)
            {
                sw_d.WriteLine("HEDEFE ULAŞIR.");
                hedef_d = false;
                if (dizi[hedef_dx, hedef_dy] != 0)
                {
                    altin_sayisi--;
                }
                altin[3] = altin[3] + dizi[hedef_dx, hedef_dy];
                toplanan_altin_d = toplanan_altin_d + dizi[hedef_dx, hedef_dy];
                dizi[hedef_dx, hedef_dy] = 0;
                dizi_g[hedef_dx, hedef_dy] = 0;
            }

            sw_d.WriteLine("Hamle Hakkı Bitince Konumu| X:" + Dx + "\tY:" + Dx + "\tHedefe Kalan Hamle Sayısı:" + hamled);

            buttonArray[Dx, Dy].Text = "D";
            buttonArray[Dx, Dy].BackColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            boyut = Convert.ToInt32(textBox1.Text);
            altin_yuzde = Convert.ToInt32(textBox2.Text);
            gizli_altin = Convert.ToInt32(textBox3.Text);
            adim = Convert.ToInt32(textBox5.Text);
            c_gizli = Convert.ToInt32(textBox14.Text);

            dizi = new int[boyut, boyut];
            dizi_g = new int[boyut, boyut];
            dizi_d = new int[boyut, boyut];
            buttonArray = new Button[boyut, boyut];
            altin = new int[4];
            altin[0] = Convert.ToInt32(textBox4.Text);
            altin[1] = Convert.ToInt32(textBox4.Text);
            altin[2] = Convert.ToInt32(textBox4.Text);
            altin[3] = Convert.ToInt32(textBox4.Text);

            puan_hamle_a = Convert.ToInt32(textBox6.Text);
            puan_hedef_a = Convert.ToInt32(textBox7.Text);
            puan_hamle_b = Convert.ToInt32(textBox8.Text);
            puan_hedef_b = Convert.ToInt32(textBox9.Text);
            puan_hamle_c = Convert.ToInt32(textBox10.Text);
            puan_hedef_c = Convert.ToInt32(textBox11.Text);
            puan_hamle_d = Convert.ToInt32(textBox12.Text);
            puan_hedef_d = Convert.ToInt32(textBox13.Text);

            Ax = 0; Ay = 0; Bx = 0; By = boyut - 1; Cx = boyut - 1; Cy = 0; Dx = boyut - 1; Dy = boyut - 1;


            for (int i = 0; i < boyut; i++)     /// Oyun Alanı Oluşturma
            {
                for (int j = 0; j < boyut; j++)
                {
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Size = new Size(30, 30);
                    buttonArray[i, j].Location = new Point(30 * j, 1 + 30 * i);
                    panel1.Controls.Add(buttonArray[i, j]);
                }
            }

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    dizi[i, j] = 0;
                    dizi_g[i, j] = 0;
                    dizi_d[i, j] = 0;
                }
            }

            //            Console.WriteLine(Bx + "\t" + By + "\t" + Cx + "\t" + Cy + "\t" + Dx + "\t" + Dy);

            Random rastgele = new Random();
            altin_yuzde = 100 / altin_yuzde;
            altin_sayisi = (boyut * boyut) / altin_yuzde;
            for (int i = 0; i < altin_sayisi; i++)
            {
                int yatay = rastgele.Next(boyut);
                int dikey = rastgele.Next(boyut);
                int deger = rastgele.Next(1, 5);

                if (dizi[yatay, dikey] == 0)
                {
                    if (dikey == 0)
                        if (dikey != 0 && dikey != (boyut - 1))
                            dizi[yatay, dikey] = deger * 5;
                        else
                            i--;

                    if (dikey == (boyut - 1))
                        if (yatay != 0 && yatay != (boyut - 1))
                            dizi[yatay, dikey] = deger * 5;
                        else
                            i--;

                    if (dikey != 0 && dikey != (boyut - 1))
                        dizi[yatay, dikey] = deger * 5;
                }
                else
                    i--;
            }

            ////gizli altın yerleştirme

            if (gizli_altin == 100)
            {
                for (int k = 0; k < boyut; k++)
                {
                    for (int l = 0; l < boyut; l++)
                    {
                        dizi_g[k, l] = dizi[k, l];
                        dizi[k, l] = 0;
                    }
                }
            }
            else
            {
                gizli_altin = 100 / gizli_altin;
                gizli_altin = altin_sayisi / gizli_altin;
                int rastgele_altin = altin_sayisi;

                for (int i = 0; i < gizli_altin; i++)
                {
                    int gizli = rastgele.Next(rastgele_altin + 2);
                    int temp = 0;

                    for (int k = 0; k < boyut; k++)
                    {
                        for (int l = 0; l < boyut; l++)
                        {
                            if (dizi[k, l] != 0)
                            {
                                temp++;
                            }
                            if (temp == gizli)
                            {
                                dizi_g[k, l] = dizi[k, l];
                                dizi[k, l] = 0;
                                k = boyut;
                                rastgele_altin--;
                                break;
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < boyut; i++)     /// ALANA ALTIN YAZMA
            {
                for (int j = 0; j < boyut; j++)
                {
                    buttonArray[i, j].Text = dizi[i, j].ToString();
                    dizi_d[i, j] = dizi[i, j];
                }
            }

            sw_a.WriteLine("AÇIK ALTIN ve MADEN YAPISI\t");
            sw_b.WriteLine("AÇIK ALTIN ve MADEN YAPISI\t");
            sw_c.WriteLine("AÇIK ALTIN ve MADEN YAPISI\t");
            sw_d.WriteLine("AÇIK ALTIN ve MADEN YAPISI\t");

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    sw_a.Write(dizi[i, j] + "\t");
                    sw_b.Write(dizi[i, j] + "\t");
                    sw_c.Write(dizi[i, j] + "\t");
                    sw_d.Write(dizi[i, j] + "\t");
                }
                sw_a.WriteLine("\n");
                sw_b.WriteLine("\n");
                sw_c.WriteLine("\n");
                sw_d.WriteLine("\n");
            }

            buttonArray[Ax, Ay].Text = "A"; buttonArray[Ax, Ay].BackColor = Color.Red;
            buttonArray[Bx, By].Text = "B"; buttonArray[Bx, By].BackColor = Color.Blue;
            buttonArray[Cx, Cy].Text = "C"; buttonArray[Cx, Cy].BackColor = Color.Yellow;
            buttonArray[Dx, Dy].Text = "D"; buttonArray[Dx, Dy].BackColor = Color.Green;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bitti == 1)
            {
                if (altin[0] > 0)
                {
                    if (hedef_a == false)
                    {
                        A_hedef(); bitti_mi();
                    }
                    if (hedef_a == true)
                    {
                        hedef_ilerleme_a(); bitti_mi();
                    }
                }
            }
            if (bitti == 1)
            {
                if (altin[0] <= 0)
                {
                    sw_a.WriteLine("ALTINI BİTTİĞİ İÇİN OYUNDAN ATILDI.");
                    buttonArray[Ax, Ay].Text = "0"; bitti_mi();
                    buttonArray[Ax, Ay].BackColor = DefaultBackColor;
                }
            }
            if (bitti == 1)
            {
                if (altin[1] > 0)
                {
                    if (hedef_b == false)
                    {
                        B_hedef(); bitti_mi();
                    }
                    if (hedef_b == true)
                    {
                        hedef_ilerleme_b(); bitti_mi();
                    }
                }
            }
            if (bitti == 1)
            {
                if (altin[1] <= 0)
                {
                    sw_b.WriteLine("ALTINI BİTTİĞİ İÇİN OYUNDAN ATILDI.");
                    buttonArray[Bx, By].Text = "0"; bitti_mi();
                    buttonArray[Bx, By].BackColor = DefaultBackColor;
                }
            }
            if (bitti == 1)
            {
                if (altin[2] > 0)
                {
                    if (hedef_c == false)
                    {
                        C_hedef(); bitti_mi();
                    }
                    if (hedef_c == true)
                    {
                        hedef_ilerleme_c(); bitti_mi();
                    }
                }
            }
            if (bitti == 1)
            {
                if (altin[2] <= 0)
                {
                    sw_c.WriteLine("ALTINI BİTTİĞİ İÇİN OYUNDAN ATILDI.");
                    buttonArray[Cx, Cy].Text = "0"; bitti_mi();
                    buttonArray[Cx, Cy].BackColor = DefaultBackColor;
                }
            }
            if (bitti == 1)
            {
                if (altin[3] > 0)
                {
                    if (hedef_d == false)
                    {
                        D_hedef(); bitti_mi();
                    }
                    if (hedef_d == true)
                    {
                        hedef_ilerleme_d(); bitti_mi();
                    }
                }
            }
            if (bitti == 1)
            {
                if (altin[3] <= 0)
                {
                    sw_d.WriteLine("ALTINI BİTTİĞİ İÇİN OYUNDAN ATILDI.");
                    buttonArray[Dx, Dy].Text = "0"; bitti_mi();
                    buttonArray[Dx, Dy].BackColor = DefaultBackColor;
                }
            }
        }
 

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}

