using System;
using System.Drawing;
using System.Windows.Forms;

namespace Filtr_Images
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            red_label.Text = red_track.Value.ToString();
            green_label.Text = green_track.Value.ToString();
            blue_label.Text = blue_track.Value.ToString();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        bool b = true;
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            maxmin();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            maxmin();
        }
        void maxmin()
        {
            if (b)
            {
                WindowState = FormWindowState.Maximized;
                label1.Left = 635;
                pictureBox3.Left = 245;
                label2.Left = 317;
                pictureBox2.Left = 785;
                label3.Left = 820;
                label4.Left = 710;
                red_track.Left = 715;
                label4.Top = 440;
                red_track.Top = 460;
                red_label.Left = 995;
                red_label.Top = 440;
                label5.Left = 710;
                green_track.Left = 715;
                label5.Top = 500;
                green_track.Top = 520;
                green_label.Left = 995;
                green_label.Top = 500;
                label6.Left = 710;
                blue_track.Left = 715;
                label6.Top = 560;
                blue_track.Top = 580;
                blue_label.Left = 995;
                blue_label.Top = 560;
                guna2GradientButton2.Left = 315;
                guna2GradientButton2.Top = 500;
                label7.Top = 580;
                label7.Left = 330;
                guna2ToggleSwitch1.Top = 580;
                guna2ToggleSwitch1.Left = 470;
                b = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                label1.Left = 335;
                pictureBox3.Left = 47;
                label2.Left = 125;
                pictureBox2.Left = 459;
                label3.Left = 501;
                label4.Left = 402;
                red_track.Left = 405;
                label4.Top = 422;
                red_track.Top = 443;
                red_label.Left = 685;
                red_label.Top = 422;
                label5.Left = 402;
                green_track.Left = 405;
                label5.Top = 476;
                green_track.Top = 497;
                green_label.Left = 685;
                green_label.Top = 476;
                label6.Left = 402;
                blue_track.Left = 405;
                label6.Top = 526;
                blue_track.Top = 547;
                blue_label.Left = 685;
                blue_label.Top = 526;
                guna2GradientButton2.Left = 116;
                guna2GradientButton2.Top = 476;
                label7.Top = 545;
                label7.Left = 127;
                guna2ToggleSwitch1.Top = 545;
                guna2ToggleSwitch1.Left = 257;
                b = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e){}
        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            red_label.Text = red_track.Value.ToString();
            edit_image();
        }
        string rasm_joylashuvi = "";
        bool key = false;
        private void green_track_Scroll(object sender, ScrollEventArgs e)
        {
            green_label.Text = green_track.Value.ToString();
            edit_image();
        }

        private void blue_track_Scroll(object sender, ScrollEventArgs e)
        {
            blue_label.Text = blue_track.Value.ToString();
            edit_image();
        }
        bool check = true;
        void edit_image()
        {
            if(key&&check)
                pictureBox2.Image = pictureBox3.Image.filtr(Convert.ToInt32(red_label.Text), Convert.ToInt32(green_label.Text), Convert.ToInt32(blue_label.Text));
        }
        OpenFileDialog fd = new OpenFileDialog();
        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                fd.Filter = "jpg fayllar(*.jpg)|*.jpg| png fayllar(*.png)|*.png| jpeg fayllar(*.jpeg)|*.jpeg| Barcha fayllar(*.*)|*.*";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    rasm_joylashuvi = fd.FileName;
                    pictureBox3.ImageLocation = rasm_joylashuvi;
                    key = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Xatolik !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2ToggleSwitch1.Checked == true)
                {
                    check = false;
                    Bitmap image = new Bitmap(fd.FileName);
                    for (int y = 0; y < image.Height; y++)
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            Color oldcolor = image.GetPixel(x, y);

                            int r = oldcolor.R;
                            int g = oldcolor.G;
                            int b = oldcolor.B;
                            int average = (r + g + b) / 3;
                            Color newcolor = Color.FromArgb(average, average, average);
                            image.SetPixel(x, y, newcolor);
                        }
                    }
                    pictureBox2.Image = image;
                    red_track.Enabled = false;
                    blue_track.Enabled = false;
                    green_track.Enabled = false;
                }
                else
                {
                    check = true;
                    red_track.Enabled = true;
                    blue_track.Enabled = true;
                    green_track.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Xatolik yuz berdi!", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }
        }
        Point last;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            last = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - last.X;
                this.Top += e.Y - last.Y;
            }
        }
    }
}
