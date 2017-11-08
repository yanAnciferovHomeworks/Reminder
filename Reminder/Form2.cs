using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminder
{
    public partial class Form2 : Form
    {
        RemindsTable table;
        public Form2(RemindsTable userTable)
        {
            InitializeComponent();
            table = userTable;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           for (int i = 0; i < table.Length; i++)
			{
                List.SetItemChecked(i,table[i].IsOn);
			}
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                table[e.Index].IsOn = true;
            else table[e.Index].IsOn = false;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    [Serializable]
    public class Reminds
    {
        public bool IsOn { get; set; }

        public TimeSpan DateSpan { get; set; }

        public string Message { get; set; }
    }

    [Serializable]
    public class RemindsTable : IEnumerable<Reminds>
    {
        List<Reminds> reminds;
        public RemindsTable()
        {
            reminds = new List<Reminds>();
            for (int i = 0; i < 13; i++)
                reminds.Add(new Reminds());
            reminds[0].DateSpan = new TimeSpan(0, 1, 0);
            reminds[0].Message = "Через минуту ";
            reminds[1].DateSpan = new TimeSpan(0, 2, 0);
            reminds[1].Message = "Через две минуты ";
            reminds[2].DateSpan = new TimeSpan(0, 5, 0);
            reminds[2].Message = "Через пять минут ";
            reminds[3].DateSpan = new TimeSpan(0, 10, 0);
            reminds[3].Message = "Через десять минут ";
            reminds[4].DateSpan = new TimeSpan(0, 20, 0);
            reminds[4].Message = "Через двадцать минут ";
            reminds[5].DateSpan = new TimeSpan(0, 30, 0);
            reminds[5].Message = "Через тридцать минут ";
            reminds[6].DateSpan = new TimeSpan(1, 0, 0);
            reminds[6].Message = "Через час  ";
            reminds[7].DateSpan = new TimeSpan(2, 0, 0);
            reminds[7].Message = "Через два часа ";
            reminds[8].DateSpan = new TimeSpan(5, 0, 0);
            reminds[8].Message = "Через пять часов ";
            reminds[9].DateSpan = new TimeSpan(10, 0, 0);
            reminds[9].Message = "Через десять часов ";
            reminds[10].DateSpan = new TimeSpan(1,0,0,0);
            reminds[10].Message = "Через день ";
            reminds[11].DateSpan = new TimeSpan(7, 0, 0, 0);
            reminds[11].Message = "Через неделю ";
            reminds[12].DateSpan = new TimeSpan(30, 0, 0, 0);
            reminds[12].Message = "Через тридцать дней ";

        }

        public int Length {
            get 
            { 
                return reminds.Count; 
            }
            
        }

        public Reminds this[int index]
        {
            get{
                return reminds[index];
            }

            
        }

        public IEnumerator<Reminds> GetEnumerator()
        {
            return reminds.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return reminds.GetEnumerator();
        }
    }
}
