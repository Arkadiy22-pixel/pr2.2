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
            
            int value = 0;            
            if (ObjectsInBackpack.TryGetValue(comboBoxОbject.SelectedItem.ToString(), out value))
            {                
                progressBarCapacity.Value += value;    
            }
            //if (ObjectsInBackpack.TryGetValue(comboBoxОbject.SelectedItem))
            comboBoxОbject.SelectedIndex = -1;
            //if (progressBarCapacity.Value > 12)
            //    MessageBox.Show("Рюкзак заполнен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (ObjectsInBackpack.TryGetValue(comboBoxОbject.SelectedItem.ToString(), out value))
            { progressBarCapacity.Value -= value; }
        }

    }
}
