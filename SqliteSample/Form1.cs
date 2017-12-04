using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteSample
{
    public partial class Form1 : Form
    {
        private DataManager dataManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataManager = DataManager.GetInstance();
            dataManager.CreateTableWaT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataManager.InsertIntoTableWaT(new WordAndTranslation(0, textBoxRussian.Text, textBoxEnglish.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewWaT.DataSource = dataManager.SelectAllFromTableWaT();
        }
    }
}
