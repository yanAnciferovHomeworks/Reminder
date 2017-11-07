﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    [Serializable]
    public class Event
    {
        public string Name { get; set; }

        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public bool IsRemind { get; set; }

        public RemindMode GetRemind { get; set; }

        public override string ToString() 
        {
            return Name;
        }
    }

    [Serializable]
    public class DataBaseEvents : IEnumerable<Event>
    {
        
        List<Event> events = new List<Event>();

        public void Add(Event even){
            events.Add(even);
        }

        public void Remove(Event even)
        {
            events.Remove(even);
        }

        public int Length { get { return events.Count; } }

        public List<Event> GetEventsByDate(DateTime dateTime)
        {
            List<Event> needEvents = new List<Event>();
            foreach (var item in events)
            {
                if (dateTime.Month.Equals(item.Date.Month) && dateTime.Day.Equals(item.Date.Day))
                {
                    needEvents.Add(item);
                }
                else if(dateTime.Day.Equals(item.Date.Day) && item.GetRemind == RemindMode.EveryMonth)
                {
                    needEvents.Add(item);
                }
                //else if (dateTime.Day == item.Time.Day && item.GetRemind == RemindMode.EveryMonth)
                //{
                //    needEvents.Add(item);
                //}
            }
            return needEvents;
        }

        public IEnumerator<Event> GetEnumerator()
        {
            return events.GetEnumerator();
        }

        public Event this[int index]
        {
            get
            {
                return events[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return events.GetEnumerator();
        }
    }

    public enum RemindMode
    {
        One = 0,
        EveryMonth,
        EveryYear
    }
}
