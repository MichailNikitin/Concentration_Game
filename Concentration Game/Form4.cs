using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentration_Game
{
    public class SelectedPairs
    {
        public string Card1Id = "";
        public string Card2Id = "";
    }
    public partial class Form4 : Form
    {
        SelectedPairs SelectedPair = new SelectedPairs();
        public Form4()
        {
            InitializeComponent();

            for (int i = 0; i < 16; i++)
            {
                Button btn = new Button();

                btn.Text = $"Button {i}";
                btn.Height = 200;
                btn.Width= 100;
                //btn.Image = new Bitmap($"images/{i}.jpg");
                btn.ImageAlign = ContentAlignment.MiddleCenter;
                btn.BackgroundImage = new Bitmap("images/back.jpg");
                btn.Tag = i%8;

                btn.BackgroundImageLayout = ImageLayout.Stretch;

                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string text = btn.Tag.ToString();

            if (flowLayoutPanel1.Controls.Count == 0)
            {
                
            }
            if (string.IsNullOrWhiteSpace(SelectedPair.Card1Id))
            {
                SelectedPair.Card1Id = text;
            }
            else
            {
                SelectedPair.Card2Id = text;
            }

            if (SelectedPair.Card1Id == SelectedPair.Card2Id)
            {
                Thread.Sleep(1000);
                flowLayoutPanel1.Controls.Remove(flowLayoutPanel1.Controls.Cast<Button>().First(x => x.Tag.ToString() == SelectedPair.Card1Id));
                flowLayoutPanel1.Controls.Remove(flowLayoutPanel1.Controls.Cast<Button>().First(x => x.Tag.ToString() == SelectedPair.Card2Id));
            }

            btn.BackgroundImage = new Bitmap($"images/{text}.PNG");
            //flowLayoutPanel1.Controls.Clear();
            //MessageBox.Show(text);
        }
    }
}
