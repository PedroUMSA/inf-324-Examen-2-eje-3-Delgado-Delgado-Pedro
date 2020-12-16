using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        int cmR, cmG, cmB;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes JPG|*.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            cR = c.R;
            cG = c.G;
            cB = c.B;
            textBox1.Text = c.R.ToString()+", "+c.G.ToString()+", "+c.B.ToString();
            
            cmR = 0;
            cmG = 0;
            cmB = 0;
            for (int i = e.X; i < e.X + 10; i++)
                for (int j = e.Y; j < e.Y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cmR = cmR + c.R;
                    cmG = cmG + c.G;
                    cmB = cmB + c.B;
                }
            cmR = cmR / 100;
            cmG = cmG / 100;
            cmB = cmB / 100;

            int[,] mat = new int[6, 3];
            mat[0, 0] = 138; mat[0, 1] = 128; mat[0, 2] = 111;
            mat[1, 0] = 104; mat[1, 1] = 99; mat[1, 2] = 85;
            mat[2, 0] = 162; mat[2, 1] = 146; mat[2, 2] = 125;

            mat[3, 0] = 32; mat[3, 1] = 55; mat[3, 2] = 45;

            mat[4, 0] = 9; mat[4, 1] = 42; mat[4, 2] = 63;
            mat[5, 0] = 28; mat[5, 1] = 37; mat[5, 2] = 38;

            Color cc = new Color();
            for (int ii = 0; ii < 6; ii++)
            {
                if (((mat[ii, 0] - 20 < cmR) && (cmR < mat[ii, 0] + 20)) && ((mat[ii, 1] - 20 < cmG) && (cmG < mat[ii, 1] + 20)) && ((mat[ii, 2] - 20 < cmB) && (cmB < mat[ii, 2] + 20)))
                {
                    if (ii < 3)
                    {
                        //bmp2.SetPixel(x, y, Color.Chocolate);
                        textBox1.Text = "Tierra";
                        label2.BackColor = Color.Chocolate;
                        label2.ForeColor = Color.Chocolate;
                    }
                    else
                    {
                        if (ii < 4)
                        {
                            //bmp2.SetPixel(x, y, Color.Green);
                            textBox1.Text = "Vegetacion";
                            label2.BackColor = Color.Green;
                            label2.ForeColor = Color.Green;
                        }
                        else
                        {
                            
                            if (ii < 6)
                            {
                                //bmp2.SetPixel(x, y, Color.Blue);
                                textBox1.Text = "Agua";
                                label2.BackColor = Color.Blue;
                                label2.ForeColor = Color.Blue;
                            }
                            else
                            {
                                if (ii < 7)
                                {
                                    //bmp2.SetPixel(x, y, Color.White);
                                    textBox1.Text = "Nevado";
                                    label2.BackColor = Color.White;
                                    label2.ForeColor = Color.White;
                                }
                                else
                                {
                                    if (ii == 7)
                                    {
                                        //bmp2.SetPixel(x, y, Color.Yellow);
                                        textBox1.Text = "Montañas";
                                        label2.BackColor = Color.Yellow;
                                        label2.ForeColor = Color.Yellow;
                                    }

                                }

                            }
                            //
                        }
                    }
                }
            }


                
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i=0;i<bmp.Width;i++)
                for (int j = 0; j <bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox1.Image = bmp2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int ciR, ciG, ciB;
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    ciR = c.R;
                    ciG = c.G;
                    ciB = c.B;
                    if (((cR - 10 < ciR) && (ciR < cR + 10)) && ((cG - 10 < ciG) && (ciG < cG + 10)) && ((cB - 10 < ciB) && (ciB < cB + 10)))
                    {
                        bmp2.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                    
                }
            pictureBox1.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int ciR, ciG, ciB;
            int[,] mat=new int[13,3];
            //tierra
            mat[0, 0] = 138; mat[0,1]=128; mat[0,2]=111;
            //mat[1, 0] = 104; mat[1, 1] = 99; mat[1, 2] = 85;
            mat[1, 0] = 212; mat[1, 1] = 203; mat[1, 2] =188;
            //212, 203, 188
            //mat[1, 0] = 138; mat[1, 1] = 128; mat[1, 2] = 111;
            mat[2, 0] = 162; mat[2, 1] = 146; mat[2, 2] = 125;
            mat[3, 0] = 181; mat[3, 1] = 170; mat[3, 2] = 162;
            //vegetacion
            mat[4, 0] = 32; mat[4, 1] = 55; mat[4, 2] = 45;
            mat[5, 0] = 78; mat[5, 1] = 86; mat[5, 2] = 70;
            //agua
            mat[6, 0] = 9; mat[6, 1] = 42; mat[6, 2] = 63;
            //mat[7, 0] = 28; mat[7, 1] =37; mat[7, 2] = 38;
            mat[7, 0] = 64; mat[7, 1] = 84; mat[7, 2] = 135;
            //mat[8, 0] = 64; mat[8, 1] = 84; mat[8, 2] = 135;
            mat[8, 0] = 32; mat[8, 1] = 50; mat[8, 2] = 100;
            //nieve
            mat[9, 0] = 242; mat[9, 1] = 244; mat[9, 2] = 246;
            mat[10, 0] = 181; mat[10, 1] = 203; mat[10, 2] = 217;
            mat[11, 0] = 206; mat[11, 1] = 227; mat[11, 2] = 242;
            //motaña
            mat[12, 0] = 87; mat[12, 1] = 84; mat[12, 2] = 73;



            for (int ii=0;ii<13;ii++) {
                Console.WriteLine(" "+mat[ii,0]+"  "+mat[ii,1]+"   "+mat[ii,2]);

                for (int i = 0; i < bmp.Width - 5; i = i + 5)
                    for (int j = 0; j < bmp.Height - 5; j = j + 5)
                    {
                        ciR = 0;
                        ciG = 0;
                        ciB = 0;

                        for (int x = i; x < i + 5; x++)
                            for (int y = j; y < j + 5; y++)
                            {
                                c = bmp.GetPixel(x, y);
                                ciR = ciR + c.R;
                                ciG = ciG + c.G;
                                ciB = ciB + c.B;
                            }
                        ciR = ciR / 25;//ii,0
                        ciG = ciG / 25;//ii,1
                        ciB = ciB / 25;//ii,2

                        if (((mat[ii,0] - 20 < ciR) && (ciR < mat[ii,0] + 20)) && ((mat[ii,1] - 20 < ciG) && (ciG < mat[ii,1] + 20)) && ((mat[ii,2] - 20 < ciB) && (ciB < mat[ii,2] + 20)))
                        {
                            //estar por terminar
                            
                            //ya casi
                            for (int x = i; x < i + 5; x++)
                                for (int y = j; y < j + 5; y++)
                                {
                                    if (ii<4)
                                    {
                                        bmp2.SetPixel(x, y, Color.Chocolate);
                                    }
                                    else
                                    {
                                        if (ii<6)
                                        {
                                            bmp2.SetPixel(x, y, Color.Green);
                                        }
                                        else
                                        {
                                            if (ii<9)
                                            {
                                                bmp2.SetPixel(x, y, Color.Blue);
                                            }
                                            else
                                            {
                                                if (ii<12)
                                                {
                                                    bmp2.SetPixel(x, y, Color.White);
                                                }
                                                else
                                                {
                                                    if (ii==12)
                                                    {
                                                        bmp2.SetPixel(x, y, Color.Yellow);
                                                    }
                                                    
                                                }
                                                
                                            }
                                            
                                        }
                                    }
                                   // bmp2.SetPixel(x, y, Color.Red);
                                }
                        }
                        else
                        {

                            for (int x = i; x < i + 5; x++)
                                for (int y = j; y < j + 5; y++)
                                {
                                    c = bmp.GetPixel(x, y);
                                    bmp2.SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B));
                                }

                        }

                    }
                pictureBox1.Image = bmp2;
                bmp = new Bitmap(pictureBox1.Image);
            }
            
            
        }
    }
}
