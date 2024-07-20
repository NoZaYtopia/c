using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _123
{

    
    public partial class Form1 : Form
    {
        int[,] kl = new int[10, 10];
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Random r = new Random();




            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(c.A, c.R, c.G, c.B));
                }



            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    kl[i, j] = r.Next(10);



                    if (kl[i, j] == 1)
                    {
                        for (int y = i * (bmp.Height / 10); y < (i + 1) * (bmp.Height / 10); y++)
                            for (int x = j * (bmp.Width / 10); x < (j + 1) * (bmp.Width / 10); x++)
                            {
                                Color c = bmp.GetPixel(x, y);
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, c.G, c.B));
                            }
                    }
                    if (kl[i, j] == 2)
                    {
                        for (int y = i * (bmp.Height / 10); y < (i + 1) * (bmp.Height / 10); y++)
                            for (int x = j * (bmp.Width / 10); x < (j + 1) * (bmp.Width / 10); x++)
                            {
                                Color c = bmp.GetPixel(x, y);
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, c.G, c.B));
                            }
                    }
                    if (kl[i, j] == 3)
                    {
                        for (int y = i * (bmp.Height / 10); y < (i + 1) * (bmp.Height / 10); y++)
                            for (int x = j * (bmp.Width / 10); x < (j + 1) * (bmp.Width / 10); x++)
                            {
                                Color c = bmp.GetPixel(x, y);
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, 255, c.B));
                            }
                    }
                    if (kl[i, j] == 4)
                    {
                        for (int y = i * (bmp.Height / 10); y < (i + 1) * (bmp.Height / 10); y++)
                            for (int x = j * (bmp.Width / 10); x < (j + 1) * (bmp.Width / 10); x++)
                            {
                                Color c = bmp.GetPixel(x, y);
                                bmp.SetPixel(x, y, Color.FromArgb(255, 255, c.G, 255));
                            }
                    }
                    if (kl[i, j] == 5)
                    {
                        for (int y = i * (bmp.Height / 10); y < (i + 1) * (bmp.Height / 10); y++)
                            for (int x = j * (bmp.Width / 10); x < (j + 1) * (bmp.Width / 10); x++)
                            {
                                Color c = bmp.GetPixel(x, y);
                                bmp.SetPixel(x, y, Color.FromArgb(255, c.R,255, 255));
                            }
                    }


                }
            }


            pictureBox1.Image = (Bitmap)bmp;
        }
    }
}
