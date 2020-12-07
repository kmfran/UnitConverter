using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace unitconverter
{
    public partial class Form1 : Form
    {
        public static List<UnitType> Lenght = new List<UnitType>()
            {
                new UnitType() {Value=1m, Name="Meter"},
                new UnitType() {Value=0.000621371192m, Name="Mile"},
                new UnitType() {Value=3.2808399m, Name="Foot"},
                new UnitType() {Value=39.3700787m, Name="Inch"},
                new UnitType() {Value=0.001m, Name="Kilometer"},
                new UnitType() {Value=100m, Name="Centimeter"}
            };

        public static List<UnitType> Weight = new List<UnitType>()
        {
                new UnitType() {Value=1m, Name="Kilogram"},
                new UnitType() {Value=35.2739619m, Name="Ounce"},
                new UnitType() {Value=0.001m, Name="Ton"},
                new UnitType() {Value=2.20462262m, Name="Pound"}
        };

        List<List<UnitType>> Units = new List<List<UnitType>>();

        List<decimal> UsedUnits = new List<decimal>();
        

        public Form1()  
        {
            InitializeComponent();
            unitsToolStripMenuItem.Text = nameof(Units);
            Units.Add(Lenght);
            Units.Add(Weight);
            
            for (int i = 0; i < Lenght.Count; i++)
            {
                listBox1.Items.Add(Lenght[i].Name);
                listBox2.Items.Add(Lenght[i].Name);
                UsedUnits.Add(Lenght[i].Value);
            }
            
            
        }
        private void UserInput_TextChanged(object sender, EventArgs e)
        {
            

        }
        public void button1_Click(object sender, EventArgs e)
        {
            if ((listBox1.SelectedIndex == -1) || (listBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Please select an Item first!");
            }
            else
            {               
                decimal x;
                if (!(decimal.TryParse(UserInput.Text, out x)))
                {
                    MessageBox.Show("Błąd!");
                }
                else
                {
                    decimal wynik = (x * ((UsedUnits[0] / UsedUnits[listBox1.SelectedIndex]) / (UsedUnits[0] / UsedUnits[listBox2.SelectedIndex])));
                    string wynik_s = wynik.ToString();

                    UserOutput.Text = wynik_s;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           for(int j=listBox1.Items.Count-1;j>=0;--j)
            {
                listBox1.Items.RemoveAt(j);
                listBox2.Items.RemoveAt(j);
                UsedUnits.RemoveAt(j);
            }

            for (int i = 0; i < Lenght.Count; i++)
            {
                listBox1.Items.Add(Lenght[i].Name);
                listBox2.Items.Add(Lenght[i].Name);
                UsedUnits.Add(Lenght[i].Value);
            }
        }

        private void weightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int j = listBox1.Items.Count - 1; j >= 0; --j)
            {
                listBox1.Items.RemoveAt(j);
                listBox2.Items.RemoveAt(j);
                UsedUnits.RemoveAt(j);
            }

            for (int i = 0; i < Weight.Count; i++)
            {
                listBox1.Items.Add(Weight[i].Name);
                listBox2.Items.Add(Weight[i].Name);
                UsedUnits.Add(Weight[i].Value);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
