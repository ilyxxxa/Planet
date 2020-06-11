using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Planet
{
    public partial class Form1 : Form
    {
        private double _m;
        private double _r;
        private double _h;
        private const double G = 6.67e-11;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private List<Planet> GetDP()
        {
            using (var db = new PlanetContext())
            {
                var planets = db.Planet.ToList();
                return planets;
            }
        }
        private void GetData()
        {
            comboBox1.DataSource = GetDP();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var planet = GetDP();
            var id = int.Parse(comboBox1.SelectedValue.ToString());
            _h = double.Parse(textBox1.Text);
            _m = planet.FirstOrDefault(f => f.Id == id).Mass;
            _r = planet.FirstOrDefault(f => f.Id == id).Radius;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = Calc().Item1.ToString();
            textBox3.Text = Calc().Item2.ToString();    
        }
        private (double, double) Calc()
        {
            var v1 = Math.Sqrt((G * _m) / (_r + _h));
            var v2 = Math.Sqrt(2) * v1;
            return (v1, v2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var uForm2 = new Form2();
            uForm2.Show();
        }
    }
}
