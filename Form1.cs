using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        int cizx, cizy;
        int[,] ilknokta = new int[1, 1];
        Point nokta1 = new Point(0, 0);
        Point ilk;
        public static int digsay = 0;
        void cizimyap()
        {
            int tutulanx = 0;
            int tutulany = 0;
            for (int i = 0; i < dizi1.Length / 2 - 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    int karsix = dizi1[i + 1, j];
                    int karsiy = dizi1[i + 1, j + 1];
                    if (digsay == 0)
                    {
                        ilk = new Point(dizi1[i, j], dizi1[i, j + 1]);
                        tutulanx = dizi1[i, j];
                        tutulany = dizi1[i, j + 1];
                        nokta1.X = tutulanx;
                        nokta1.Y = tutulany;
                    }

                    digsay++;
                    Point nokta2 = new Point(karsix, karsiy);
                    int indisx = i + 1;
                    int indisy = j + 1;
                    tutulanx = nokta1.X;
                    tutulany = nokta1.Y;
                    if (nokta1.X != -1 && nokta1.Y != -1 && nokta2.X != -1 && nokta2.Y != -1)
                        mesafehesapla(tutulanx, tutulany, karsix, karsiy, indisx, indisy, nokta1, nokta2);
                    else if (i == ((dizi1.Length / 2) - 2))
                    {
                        sayac1 = dizi1.Length / 2 - 2;
                        mesafehesapla(tutulanx, tutulany, karsix, karsiy, indisx, indisy, nokta1, nokta2);

                    }
                    else
                        sayac1++;
                }

            }

        }
        int enyakın = 1920;
        int yakinindisx = 0;
        int yakinindisy = 0;
        int sayac1 = 0;
        int cizilen = 0;
        Point enyak = new Point(0, 0);
        int s = 0;
        int topmesafe = 0;
        double mesafe;
        public void mesafehesapla(int a, int b, int w, int z, int indx, int indy, Point nok1, Point nok2)
        {
            sayac1++;
            int sayix = 0;

            if (nok1.X != -1 && nok1.Y != -1 && nok2.X != -1 && nok2.Y != -1)
            {
                mesafe = Math.Sqrt(Math.Pow(w - a, 2) + Math.Pow(z - b, 2));
                if (mesafe < enyakın)
                {
                    enyakın = (int)mesafe;
                    yakinindisx = indx;
                    yakinindisy = indy;
                    sayix = dizi1[yakinindisx, yakinindisy];
                    enyak.X = w;
                    enyak.Y = z;
                }
            }
            if (sayac1 == dizi1.Length / 2 - 1 && nok1 != enyak)
            {

                topmesafe += (int)mesafe;
                sayac1 = 0;
                dizi1[0, 0] = -1;
                dizi1[0, 1] = -1;
                enyakın = 1920;
                for (int u = 0; u < 2; u++)
                    dizi1[yakinindisx, u] = -1;
                if (nokta1.X != -1 && nokta1.Y != -1 && enyak.X != -1 && enyak.Y != -1)
                {
                    g.DrawLine(pen, nok1, enyak);
                    cizilen++;

                }
                nokta1 = enyak;

                for (int k = 0; k < dizi1.Length / 2 - 1; k++)
                {
                    sayac1 = 0;
                    cizimyap();

                }
                sayac1 = 0;
                int eksisay = 0;
                for (int y = 0; y < dizi1.Length / 2 - 1; y++)
                    for (int t = 0; t < 2; t++)
                    {
                        if (dizi1[y, t] == -1)
                            eksisay++;
                    }
                if (eksisay == dizi1.Length)
                    g.DrawLine(pen, nok1, ilk);
                else
                {
                    sayac1 = 0;
                    cizimyap();
                }
                eksisay = 0;

            }

            label7.Text = "En Kısa Toplam Mesafe : " + Convert.ToString(topmesafe) + " Km";
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            button2.Visible = false;
        }

        void mesefehesapla(Rectangle x, Rectangle y)
        {
            label1.Text = Convert.ToString(x.Y);
            double mesafe = Math.Sqrt(Math.Pow(x.Y - y.Y, 2) + Math.Pow(x.X - y.X, 2));
            label1.Text = Convert.ToString(mesafe);
        }


        int geciciX, geciciy;
        public static int sayac = 0;
        Point nokta, nokta2;


        Pen pen = new Pen(Color.Blue, 2);
        Rectangle kare;
        Graphics g;
        ArrayList dizi = new ArrayList();

        public static int k = 0;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sehirsay != 0)
            {
                geciciX = e.X;
                geciciy = e.Y;



                label3.Text = Convert.ToString(geciciX);
                label4.Text = Convert.ToString(geciciy);
                kare = new Rectangle(geciciX, geciciy, 2, 2);
                g = this.CreateGraphics();
                g.DrawRectangle(pen, kare);
                dizi1[sayac, digsay] = e.X;
                dizi1[sayac, digsay + 1] = e.Y;
                sayac++;
                if (sayac == dizi1.Length / 2)
                {
                    MessageBox.Show("Yeterli Şehir Girildi Cizim yapabilirsiniz");
                    button2.Visible = true;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static int sehirsay = 0;
        public static int[,] dizi1;
       

        private void button1_Click_2(object sender, EventArgs e)
        {
            sehirsay = Convert.ToInt16(textBox1.Text);
            dizi1 = new int[sehirsay, 2];
            MessageBox.Show("Şehirleri Form Ekranına Tıklayarak Yerleştiriniz..");
        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (sehirsay != 0)
            {
                geciciX = e.X;
                geciciy = e.Y;



                label3.Text = Convert.ToString(geciciX);
                label4.Text = Convert.ToString(geciciy);
                kare = new Rectangle(geciciX, geciciy, 2, 2);
                g = this.CreateGraphics();
                g.DrawRectangle(pen, kare);
                dizi1[sayac, digsay] = e.X;
                dizi1[sayac, digsay + 1] = e.Y;
                sayac++;
                if (sayac == dizi1.Length / 2)
                {
                    MessageBox.Show("Yeterli Şehir Girildi Cizim yapabilirsiniz");
                    button2.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cizimyap();
        }
    }
}
