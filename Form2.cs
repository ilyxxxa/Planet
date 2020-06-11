using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace Planet
{
    public partial class Form2 : Form
    {
        private readonly PlanetContext db;
        public Form2()
        {
            InitializeComponent();
            db = new PlanetContext();
            db.Planet.Load();
            dataGridView1.DataSource = db.Planet.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Изменения добавлены");
        }
    }
}
