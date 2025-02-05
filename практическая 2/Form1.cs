using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace практическая_2
{
    public partial class Form1 : Form
    {

        Dictionary<string, int> ObjectsInBackpack;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            progressBarCapacity.Minimum = 0;
            progressBarCapacity.Maximum = 10000;
            textBoxAddedItems.ReadOnly = true;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ObjectsInBackpack = new Dictionary<string, int>()
            {
                ["спальный мешок 2 кг"] = 2000,
                ["салфетки 0.2 кг"] = 200,
                ["ложка 0.1 кг"] = 150,
                ["вилка 0.1 кг"] = 150,
                ["нож 0.33 кг"] = 330,
                ["антисептик 0.45 кг"] = 450,
                ["фонарь 0.68 кг"] = 680,
                ["веревка 0.9 кг"] = 900,
                ["кружка 0.65 кг"] = 650,
                ["носки 0.7 кг"] = 700,
                ["аптечка 1.2 кг"] = 1200,
                ["палатка 5 кг"] = 5000,
                ["еда 3 кг"] = 3000,
                ["дождевик 1.4 кг"] = 1400,
                ["лопата 2 кг"] = 2000,
                ["вода 1 кг"] = 1000
            };
            foreach (string objects in ObjectsInBackpack.Keys)
                comboBoxОbject.Items.Add(objects);
            comboBoxОbject.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int value = 0;
                if (ObjectsInBackpack.TryGetValue(comboBoxОbject.SelectedItem.ToString(), out value))
                {
                    if (progressBarCapacity.Value < 100000) { progressBarCapacity.Value += value; }

                }
                if (comboBoxОbject.SelectedItem != null)
                {
                    textBoxAddedItems.AppendText(comboBoxОbject.SelectedItem.ToString() + ",");
                }
                comboBoxОbject.SelectedIndex = -1;
            }
            catch (NullReferenceException)
            { MessageBox.Show("Выберите один предмет из списка чтобы добавтить его в рюкзак!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Рюкзак заполнен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (ObjectsInBackpack.TryGetValue(comboBoxОbject.SelectedItem.ToString(), out value))
            {
                List<string> AddedItems = new List<string>();
                string text = textBoxAddedItems.Text;
                AddedItems = text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                if (progressBarCapacity.Value >= value)
                    progressBarCapacity.Value -= value;
                if (progressBarCapacity.Value == 0) progressBarCapacity.Value = 0;
                if (comboBoxОbject.SelectedItem != null)
                {
                    string itemComboBox = comboBoxОbject.SelectedItem.ToString();
                    if (AddedItems.Contains(itemComboBox)) { AddedItems.Remove(itemComboBox); }
                    else { MessageBox.Show("Этого предмета нет в рюкзаке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    textBoxAddedItems.Clear();
                    foreach (string item in AddedItems)
                        textBoxAddedItems.AppendText(item + ",");
                    comboBoxОbject.SelectedIndex = -1;
                }
            }
        }

        private void buttonСancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxAddedItems.Clear();
            progressBarCapacity.Value = 0;
            comboBoxОbject.SelectedIndex = -1;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
