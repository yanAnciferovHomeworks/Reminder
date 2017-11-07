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
    public partial class RemindForm : Form
    {
        public RemindForm()
        {
            InitializeComponent();
            ResizeWinToSmall();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DateEvent.Value = new DateTime().ToLocalTime();
            AddButton.Enabled = false;
            ResizeWinToBig();
        }

        private void ResizeWinToBig()
        {
            Size = new Size(Size.Width, Size.Height + 180);
        }

        private void ResizeWinToSmall()
        {
            Size = new Size(Size.Width, Size.Height - 180);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ResizeWinToBig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResizeWinToSmall();
            AddButton.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.Name = NameEvent.Text;
            if (ev.Name == "")
                return;

            ev.IsRemind = IsRemind.Checked;

            ev.GetRemind = (RemindMode)Repeat.SelectedValue;

            ev.Time = DateEvent.Value;
            

        }

        
    }

    public class Event
    {
        public string Name { get; set; }

        public DateTime Time { get; set; }

        public bool IsRemind { get; set; }

        public RemindMode GetRemind { get; set; }
    }

    public enum RemindMode
    {
        One = 0,
        EveryMonth,
        EveryYear
    }
}
