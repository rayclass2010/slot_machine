namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] p = new PictureBox[4];
        int[] num = new int[4];
        int count;
        int cheat = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap("up.jpg");
            p[1] = pictureBox1;
            p[2] = pictureBox2;
            p[3] = pictureBox3;
            for (int i = 1; i <= p.GetUpperBound(0); i++)
            {
                p[i].Image = new Bitmap("0.jpg");
                p[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            timer1.Interval = 100;
            label2.Text = "50";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown1.Value <= Convert.ToInt32(label2.Text))
            {
                pictureBox4.Image = new Bitmap("Down.jpg");
                timer1.Enabled = true;
                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - numericUpDown1.Value);
                cheat += 1;
            }
            else
            {
                MessageBox.Show("¿ù»~");
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            for(int i = 1; i <= p.GetUpperBound(0); i++)
            {
                num[i] = r.Next(0, 4);
                p[i].Image = new Bitmap(Convert.ToString(num[i]) + ".jpg");
            }
            count+=1;
            if(count == 20)
            {
                if (cheat%10 == 0)
                {
                    num[1] = num[2] = num[3];
                    p[1].Image = p[2].Image = p[3].Image;
                    
                }
                timer1.Enabled = false;
                if (num[1]==0 && num[2]==0 && num[3] == 0)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 5);
                }
                else if(num[1] == 1 && num[2] == 1 && num[3] == 1)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 10);
                }
                else if((num[1] == 2 && num[2] == 2 && num[3] == 2))
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 15);
                }
                else if((num[1] == 3 && num[2] == 3 && num[3] == 3))
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 20);
                }
                pictureBox4.Image = new Bitmap("up.jpg");
                count = 0;
            }
            
        }
    }
}