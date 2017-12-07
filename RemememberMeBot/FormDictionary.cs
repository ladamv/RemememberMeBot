using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemememberMeBot
{
    public partial class FormDictionary : Form
    {
        private DataManager dataManager;
        public FormDictionary()
        {
            InitializeComponent();
        }

        private void FormDictionary_Load(object sender, EventArgs e)
        {
            dataManager = DataManager.GetInstance();
            dataManager.CreateTableWaT();
            dataGridViewWaT.DataSource = dataManager.SelectAllFromTableWaT();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            dataManager.InsertIntoTableWaT(new WordAndTranslation(0, textBoxRussian.Text, textBoxEnglish.Text));
            textBoxEnglish.Clear();
            textBoxRussian.Clear();
            dataGridViewWaT.DataSource = dataManager.SelectAllFromTableWaT();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            dataGridViewWaT.DataSource = dataManager.SelectAllFromTableWaT();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            dataManager.DeleteFromTableWaTByID(textBoxID.Text);
            buttonDelete.Enabled = false;
            textBoxID.Clear();
            dataGridViewWaT.DataSource = dataManager.SelectAllFromTableWaT();
        }

        private void dataGridViewWaT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridViewWaT.Rows[e.RowIndex].Cells[0].Value.ToString();
            buttonDelete.Enabled = true;
        }
    }
}
