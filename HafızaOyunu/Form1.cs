using System.Timers;

namespace HafızaOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> icon = new List<string>()
        {

            "A","B","C","D","E","F","G","H","K","L","Z","X","C","V","N","M","W","R","T","U",
            "A","B","C","D","E","F","G","H","K","L","Z","X","C","V","N","M","W","R","T","U",
        };

        Random rnd = new Random();
        int randomi;

        Button first, second;


        int Skor1, Skor2 = 0;

        int sira;



        private void Form1_Load(object sender, EventArgs e)
        {
            addicon();
            timer1.Start();
            sira = 1;

        }

        private void addicon()
        {
            Button btn;
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    btn = item as Button;
                    randomi = rnd.Next(icon.Count);
                    btn.Text = icon[randomi];
                    btn.ForeColor = Color.Black;
                    icon.RemoveAt(randomi);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            foreach (Control item in Controls)
            {

                if (item is Button)
                {
                    item.ForeColor = item.BackColor;
                }
            }


        }

        private void Button_Click(object sender, EventArgs e)
        {




            Button btn = sender as Button;

            

        
            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;

                if (first != null && second == null)
                {
                    timer3.Start();
                    return;
                }


                return;
            }
            
            second = btn;
            second.ForeColor = Color.Black;

          

            if (first.Text == second.Text)
            {
                first.ForeColor = Color.White;
                second.ForeColor = Color.White;
                first = null;
                second = null;

                if (sira == 1)
                {
                    Skor1 = Skor1 + 10;
                    if (Skor1 == 110)
                    {
                        MessageBox.Show("Oyuncu 1 Kazandı");
                        reset();
                    }

                }
                else
                {
                    Skor2 = Skor2 + 10;

                    if (Skor2 == 110)
                    {
                        MessageBox.Show("Oyuncu 2 Kazandı");
                        reset();
                    }
                }
            }
            else
            {

                timer2.Start();

                if (sira == 1)
                {
                    sira = 0;
                }
                else
                {
                    sira = 1;
                }



            }
            skor1.Text = Skor1.ToString();
            skor2.Text = Skor2.ToString();

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();



            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void reset()
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Dispose(false);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            timer3.Stop();

            if(first != null)
            {
                first.ForeColor = first.BackColor;
                first = null;
            }

            if (sira == 1)
            {
                sira = 0;
            }
            else
            {
                sira = 1;
            }




        }
    }
}
