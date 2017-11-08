using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminder
{
    public partial class RemindForm : Form
    {
        DataBaseEvents DBEvents = new DataBaseEvents();
        BindingList<Event> currentEventsDay = new BindingList<Event>();
        bool editMode = false;
        bool maxSize = true;
        Event ev;
        public RemindForm()
        {
            InitializeComponent();
            ResizeWinToSmall();
            DeSerializeDB();
            Events.DataSource = currentEventsDay;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Handler);
            timer.Start();
        }

        private void Handler(Object o, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            bool isChange = false;
            for (int item = 0; item < DBEvents.Length; item++)
            {
                foreach (var it in DBEvents[item].Reminds)
                {
                    if (it.IsOn)
                    {
                        DateTime resultDate = DBEvents[item].Date - it.DateSpan;
                        DateTime resultTime = DBEvents[item].Time - it.DateSpan;
                        if (resultDate.Day == currentTime.Day
                            && resultDate.Month == currentTime.Month
                            && resultDate.Year == currentTime.Year
                            && resultTime.Second == currentTime.Second
                            && resultTime.Minute == currentTime.Minute
                            && resultTime.Second == currentTime.Second)
                        {
                            MessageBox.Show(it.Message + DBEvents[item].Name, "Напоминание!");
                        }
                    }
                }
               

                    if (currentTime.Month == DBEvents[item].Date.Month
                    && currentTime.Day == DBEvents[item].Date.Day)
                    {

                        if (currentTime.Hour == DBEvents[item].Time.Hour
                        && currentTime.Minute == DBEvents[item].Time.Minute
                        && currentTime.Second == DBEvents[item].Time.Second)
                        {
                            
                            if (DBEvents[item].GetRemind == RemindMode.One)
                            {

                                if (Calendar.SelectionStart.Day == DBEvents[item].Date.Day
                                && Calendar.SelectionStart.Month == DBEvents[item].Date.Month)
                                {

                                    DBEvents.Remove(DBEvents[item]);
                                    Events.DataSource = DBEvents.GetEventsByDate(Calendar.SelectionStart);
                                }
                                else DBEvents.Remove(DBEvents[item]);
                                Events.Update();
                                item--;
                                isChange = true;
                            }
                        }
                    }
                    else if (DBEvents[item].GetRemind == RemindMode.EveryMonth
                         && currentTime.Day == DBEvents[item].Date.Day)
                    {
                        if (currentTime.Date.Hour == DBEvents[item].Time.Hour
                        && currentTime.Date.Minute == DBEvents[item].Time.Minute
                        && currentTime.Date.Second == DBEvents[item].Time.Second)
                        {
                            
                            if (Calendar.SelectionStart.Day == DBEvents[item].Date.Day
                                && Calendar.SelectionStart.Month == DBEvents[item].Date.Month)
                            {

                                DBEvents.Remove(DBEvents[item]);
                                Events.DataSource = DBEvents.GetEventsByDate(Calendar.SelectionStart);
                            }
                            else DBEvents.Remove(DBEvents[item]);
                            Events.Update();
                            item--;
                            isChange = true;
                        }
                    }
                
            }
            if (isChange)
            {
                SerializeDB();

                setBoldedDayToCalendar();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            editMode = false;
            DateEvent.Value = DateTime.Now;
            AddButton.Enabled = false;
            ResizeWinToBig();
            EditButton.Enabled = false;
            ev = new Event();
        }

        private void ResizeWinToBig()
        {
            if (!maxSize)
            {
                Size = new Size(Size.Width, Size.Height + 180);
                maxSize = !maxSize;
            }
        }
        private void ResizeWinToSmall()
        {
            if (maxSize)
            {
                Size = new Size(Size.Width, Size.Height - 180);
                maxSize = !maxSize;
            }
            NameEvent.Text = "";
            Repeat.SelectedIndex = -1;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            editMode = true;
            ResizeWinToBig();
            Event changedEvent = (Event)Events.SelectedItem;
            panel1.Enabled = false;
            Calendar.Enabled = false;
            Events.Enabled = false;
            NameEvent.Text = changedEvent.Name;
            Repeat.SelectedIndex = (int)changedEvent.GetRemind;
            DateEvent.Value = changedEvent.Time;
            //IsRemind.Checked = changedEvent.IsRemind;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResizeWinToSmall();
            AddButton.Enabled = true;
            Calendar.Enabled = true;
            Events.Enabled = true;
            EnableEditDel();
            panel1.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (editMode) { OKEdit(); }
            else { 
                OKAdd(); 
            }

            ResizeWinToSmall();
            AddButton.Enabled = true;
            Calendar.Enabled = true;
            Events.Enabled = true;
            EnableEditDel();
            panel1.Enabled = true;
        }

        private void OKAdd()
        {
            
            ev.Name = NameEvent.Text;
            if (ev.Name == "")
                return;

           // ev.IsRemind = IsRemind.Checked;

            if (Repeat.SelectedIndex != -1)
            {
                if (Repeat.SelectedIndex == 0)
                    ev.GetRemind = RemindMode.One;
                else if (Repeat.SelectedIndex == 1)
                    ev.GetRemind = RemindMode.EveryMonth;
                else if (Repeat.SelectedIndex == 2)
                    ev.GetRemind = RemindMode.EveryYear;
            }

            ev.Time = DateEvent.Value;
            ev.Date = Calendar.SelectionStart;
            switch (ev.GetRemind)
            {
                case RemindMode.One:
                    var newListBoldedDates = Calendar.BoldedDates.ToList();
                    newListBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.BoldedDates = newListBoldedDates.ToArray();
                    break;

                case RemindMode.EveryMonth:
                    var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                    newListMonthlyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                    break;

                case RemindMode.EveryYear:
                    var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                    AnnuallyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                    break;
                default:
                    break;
            }

            DBEvents.Add(ev);
            Calendar_DateSelected(null, null);
            SerializeDB();
        }

        private void OKEdit()
        {
            if (NameEvent.Text == "")
                return;

            Event changedEvent = (Event)Events.SelectedItem;
           // changedEvent.IsRemind = IsRemind.Checked;
            changedEvent.Name = NameEvent.Text;
            if (Repeat.SelectedIndex != -1)
            {
                if (Repeat.SelectedIndex == 0)
                    changedEvent.GetRemind = RemindMode.One;
                else if (Repeat.SelectedIndex == 1)
                    changedEvent.GetRemind = RemindMode.EveryMonth;
                else if (Repeat.SelectedIndex == 2)
                    changedEvent.GetRemind = RemindMode.EveryYear;
            }

            changedEvent.Time = DateEvent.Value;
            changedEvent.Date = Calendar.SelectionStart;
            switch (changedEvent.GetRemind)
            {
                case RemindMode.One:
                    var newListBoldedDates = Calendar.BoldedDates.ToList();
                    newListBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.BoldedDates = newListBoldedDates.ToArray();
                    break;

                case RemindMode.EveryMonth:
                    var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                    newListMonthlyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                    break;

                case RemindMode.EveryYear:
                    var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                    AnnuallyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                    break;
                default:
                    break;
            }

            setBoldedDayToCalendar();
            SerializeDB();
            Events.Update();
        }

        private void EnableEditDel()
        {

            if (Events.SelectedIndex != -1)
            {
                EditButton.Enabled = true;
                DelButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DelButton.Enabled = false;
            }

        }
        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentEventsDay = new BindingList<Event>(DBEvents.GetEventsByDate(Calendar.SelectionStart));
            Events.DataSource = currentEventsDay;
            EnableEditDel();
        }

        private void SerializeDB()
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, DBEvents);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            
        }

        private void DeSerializeDB()
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                DBEvents = (DataBaseEvents)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to deserialize. Reason: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
            setBoldedDayToCalendar();


        }

        private void setBoldedDayToCalendar()
        {
            Calendar.BoldedDates = null;
            Calendar.MonthlyBoldedDates = null;
            Calendar.AnnuallyBoldedDates = null;
            foreach (var item in DBEvents)
            {
                switch (item.GetRemind)
                {
                    case RemindMode.One:
                        var newListBoldedDates = Calendar.BoldedDates.ToList();
                        newListBoldedDates.Add(item.Date);
                        Calendar.BoldedDates = newListBoldedDates.ToArray();
                        break;

                    case RemindMode.EveryMonth:
                        var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                        newListMonthlyBoldedDates.Add(item.Date);
                        Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                        break;

                    case RemindMode.EveryYear:
                        var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                        AnnuallyBoldedDates.Add(item.Date);
                        Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            Event removedItem = (Event)Events.SelectedItem;
            DBEvents.Remove(removedItem);
            currentEventsDay.Remove(removedItem);
            removedItem = null;
            SerializeDB();

            if (Events.SelectedIndex != -1)
            {
                EditButton.Enabled = true;
                DelButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DelButton.Enabled = false;
            }

            setBoldedDayToCalendar();
        }

        private void Reminds_Click(object sender, EventArgs e)
        {
            
            Form2 testDialog;
            if (!editMode)
            {
                testDialog = new Form2(ev.Reminds);
            }
            else
            {
                RemindsTable tableRem = currentEventsDay[Events.SelectedIndex].Reminds;
                testDialog = new Form2(tableRem);
            }


            testDialog.ShowDialog(this);

            testDialog.Dispose();
        }
    }

}
