using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HRManager.Common.Services
{
    public class RecurrenceHelper
    {
        #region Internal Fields

        //internal static Dictionary<string, List<string>> ICalTimeZones = AddTimeZones();
        internal static List<string> valueList = new List<string>();
        //internal static Dictionary<string, RecurrenceProperties> RecPropertiesDict = new Dictionary<string, RecurrenceProperties>();
        internal static string COUNT;
        internal static string RECCOUNT;
        internal static string DAILY;
        internal static string WEEKLY;
        internal static string MONTHLY;
        internal static string YEARLY;
        internal static string INTERVAL;
        internal static string INTERVALCOUNT;
        internal static string BYSETPOS;
        internal static string BYSETPOSCOUNT;
        internal static string BYDAY;
        internal static string BYDAYVALUE;
        internal static string BYMONTHDAY;
        internal static string BYMONTHDAYCOUNT;
        internal static string BYMONTH;
        internal static string BYMONTHCOUNT;
        internal static int BYDAYPOSITION;
        internal static int BYMONTHDAYPOSITION;
        internal static int WEEKLYBYDAYPOS;
        internal static string WEEKLYBYDAY;
        internal static List<DateTime> exDateList = new List<DateTime>();
        internal static Nullable<DateTime> UNTIL;
        #endregion

        #region Out of the Box Methods

        public static IEnumerable<DateTime> GetRecurrenceDateTimeCollection(string RRule, DateTime? RecStartDate)
        {
            var filteredDates = GetRecurrenceDateCollection(RRule, RecStartDate, null, 43);
            return filteredDates;
        }
        public static IEnumerable<DateTime> GetRecurrenceDateTimeCollection(string RRule, DateTime RecStartDate, int NeverCount)
        {
            var filteredDates = GetRecurrenceDateCollection(RRule, RecStartDate, null, NeverCount);
            return filteredDates;
        }

        public static IEnumerable<DateTime> GetRecurrenceDateTimeCollection(string RRule, DateTime RecStartDate, string RecException)
        {
            var filteredDates = GetRecurrenceDateCollection(RRule, RecStartDate, RecException, 43);
            return filteredDates;
        }

        public static IEnumerable<DateTime> GetRecurrenceDateTimeCollection(string RRule, DateTime RecStartDate, string RecException, int NeverCount)
        {
            var filteredDates = GetRecurrenceDateCollection(RRule, RecStartDate, RecException, NeverCount);
            return filteredDates;
        }

        public static IEnumerable<DateTime> GetRecurrenceDateCollection(string RRule, DateTime? RecStartDate, string RecException, int NeverCount)
        {
            List<DateTime> RecDateCollection = new List<DateTime>();
            DateTime startDate = RecStartDate.Value;
            var ruleSeperator = new[] { '=', ';', ',' };
            var weeklySeperator = new[] { ';' };
            string[] ruleArray = RRule.Split(ruleSeperator);
            FindKeyIndex(ruleArray, RecStartDate.Value);
            string[] weeklyRule = RRule.Split(weeklySeperator);
            FindWeeklyRule(weeklyRule);
            if (RecException != null)
            {
                FindExdateList(RecException);
            }
            if (ruleArray.Length != 0 && RRule != "")
            {
                DateTime addDate = startDate;
                int recCount;
                int.TryParse(RECCOUNT, out recCount);

                #region DAILY
                if (DAILY == "DAILY")
                {

                    if ((ruleArray.Length > 4 && INTERVAL == "INTERVAL") || ruleArray.Length == 4)
                    {
                        int DyDayGap = ruleArray.Length == 4 ? 1 : int.Parse(INTERVALCOUNT);
                        if (recCount == 0 && UNTIL == null)
                        {
                            recCount = NeverCount;
                        }
                        if (recCount > 0)
                        {
                            for (int i = 0; i < recCount; i++)
                            {
                                RecDateCollection.Add(addDate.Date);
                                addDate = addDate.AddDays(DyDayGap);
                            }
                        }
                        else if (UNTIL != null)
                        {
                            bool IsUntilDateReached = false;
                            while (!IsUntilDateReached)
                            {
                                RecDateCollection.Add(addDate.Date);
                                addDate = addDate.AddDays(DyDayGap);
                                int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                if (statusValue != -1)
                                {
                                    IsUntilDateReached = true;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region WEEKLY
                else if (WEEKLY == "WEEKLY")
                {
                    int WyWeekGap = ruleArray.Length > 4 && INTERVAL == "INTERVAL" ? int.Parse(INTERVALCOUNT) : 1;
                    bool isweeklyselected = weeklyRule[WEEKLYBYDAYPOS].Length > 6;
                    if (recCount == 0 && UNTIL == null)
                    {
                        recCount = NeverCount;
                    }
                    if (recCount > 0)
                    {
                        while (RecDateCollection.Count < recCount && isweeklyselected)
                        {
                            GetWeeklyDateCollection(addDate, weeklyRule, RecDateCollection);
                            addDate = addDate.DayOfWeek == DayOfWeek.Saturday ? addDate.AddDays(((WyWeekGap - 1) * 7) + 1) : addDate.AddDays(1);
                        }
                    }
                    else if (UNTIL != null)
                    {
                        bool IsUntilDateReached = false;
                        while (!IsUntilDateReached && isweeklyselected)
                        {
                            GetWeeklyDateCollection(addDate, weeklyRule, RecDateCollection);
                            addDate = addDate.DayOfWeek == DayOfWeek.Saturday ? addDate.AddDays(((WyWeekGap - 1) * 7) + 1) : addDate.AddDays(1);
                            int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                            if (statusValue != -1)
                            {
                                IsUntilDateReached = true;
                            }
                        }
                    }
                }
                #endregion

                #region MONTHLY
                else if (MONTHLY == "MONTHLY")
                {
                    int MyMonthGap = ruleArray.Length > 4 && INTERVAL == "INTERVAL" ? int.Parse(INTERVALCOUNT) : 1;
                    int position = ruleArray.Length > 4 && INTERVAL == "INTERVAL" ? 6 : BYMONTHDAYPOSITION;
                    if (BYMONTHDAY == "BYMONTHDAY")
                    {
                        int monthDate = int.Parse(BYMONTHDAYCOUNT);
                        if (monthDate <= 30)
                        {
                            int currDate = int.Parse(startDate.Day.ToString());
                            var temp = new DateTime(addDate.Year, addDate.Month, monthDate);
                            addDate = monthDate < currDate ? temp.AddMonths(1) : temp;
                            if (recCount == 0 && UNTIL == null)
                            {
                                recCount = NeverCount;
                            }
                            if (recCount > 0)
                            {
                                for (int i = 0; i < recCount; i++)
                                {
                                    addDate = GetByMonthDayDateCollection(addDate, RecDateCollection, monthDate, MyMonthGap);
                                }
                            }
                            else if (UNTIL != null)
                            {
                                bool IsUntilDateReached = false;
                                while (!IsUntilDateReached)
                                {
                                    addDate = GetByMonthDayDateCollection(addDate, RecDateCollection, monthDate, MyMonthGap);
                                    int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                    if (statusValue != -1)
                                    {
                                        IsUntilDateReached = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (recCount == 0 && UNTIL == null)
                            {
                                recCount = NeverCount;
                            }
                            if (recCount > 0)
                            {
                                for (int i = 0; i < recCount; i++)
                                {
                                    if (addDate.Day == startDate.Day)
                                    {
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    else
                                    {
                                        i = i - 1;
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                    addDate = new DateTime(addDate.Year, addDate.Month, DateTime.DaysInMonth(addDate.Year, addDate.Month));
                                }
                            }
                            else if (UNTIL != null)
                            {
                                bool IsUntilDateReached = false;
                                while (!IsUntilDateReached)
                                {
                                    if (addDate.Day == startDate.Day)
                                    {
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                    addDate = new DateTime(addDate.Year, addDate.Month, DateTime.DaysInMonth(addDate.Year, addDate.Month));
                                    int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                    if (statusValue != -1)
                                    {
                                        IsUntilDateReached = true;
                                    }
                                }
                            }
                        }
                    }
                    else if (BYDAY == "BYDAY")
                    {
                        if (recCount == 0 && UNTIL == null)
                        {
                            recCount = NeverCount;
                        }
                        if (recCount > 0)
                        {
                            while (RecDateCollection.Count < recCount)
                            {
                                var weekCount = MondaysInMonth(addDate);
                                var monthStart = new DateTime(addDate.Year, addDate.Month, 1);
                                DateTime weekStartDate = monthStart.AddDays(-(int)(monthStart.DayOfWeek));
                                var monthStartWeekday = (int)(monthStart.DayOfWeek);
                                int nthweekDay = GetWeekDay(BYDAYVALUE) - 1;
                                int nthWeek;
                                int bySetPos = 0;
                                int setPosCount;
                                int.TryParse(BYSETPOSCOUNT, out setPosCount);
                                if (monthStartWeekday <= nthweekDay)
                                {
                                    if (setPosCount < 1)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    if (setPosCount < 0)
                                    {
                                        nthWeek = bySetPos;
                                    }
                                    else
                                    {
                                        nthWeek = bySetPos - 1;
                                    }
                                }
                                else
                                {
                                    if (setPosCount < 0)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    nthWeek = bySetPos;
                                }
                                addDate = weekStartDate.AddDays((nthWeek) * 7);
                                addDate = addDate.AddDays(nthweekDay);
                                if (addDate.CompareTo(startDate.Date) < 0)
                                {
                                    addDate = addDate.AddMonths(1);
                                    continue;
                                }
                                if (weekCount == 6 && addDate.Day == 23)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.Month == 2)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                                else if (weekCount == 6 && addDate.Day == 24)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.AddDays(7).Day != days)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                                else if (!(addDate.Day <= 23 && int.Parse(BYSETPOSCOUNT) == -1))
                                {
                                    RecDateCollection.Add(addDate.Date);
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                            }
                        }
                        else if (UNTIL != null)
                        {
                            bool IsUntilDateReached = false;
                            while (!IsUntilDateReached)
                            {
                                var weekCount = MondaysInMonth(addDate);
                                var monthStart = new DateTime(addDate.Year, addDate.Month, 1);
                                DateTime weekStartDate = monthStart.AddDays(-(int)(monthStart.DayOfWeek));
                                var monthStartWeekday = (int)(monthStart.DayOfWeek);
                                int nthweekDay = GetWeekDay(BYDAYVALUE) - 1;
                                int nthWeek;
                                int bySetPos = 0;
                                int setPosCount;
                                int.TryParse(BYSETPOSCOUNT, out setPosCount);
                                if (monthStartWeekday <= nthweekDay)
                                {
                                    if (setPosCount < 1)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    if (setPosCount < 0)
                                    {
                                        nthWeek = bySetPos;
                                    }
                                    else
                                    {
                                        nthWeek = bySetPos - 1;
                                    }
                                }
                                else
                                {
                                    if (setPosCount < 0)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    nthWeek = bySetPos;
                                }
                                addDate = weekStartDate.AddDays((nthWeek) * 7);
                                addDate = addDate.AddDays(nthweekDay);
                                if (addDate.CompareTo(startDate.Date) < 0)
                                {
                                    addDate = addDate.AddMonths(1);
                                    continue;
                                }
                                if (weekCount == 6 && addDate.Day == 23)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.Month == 2)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                                else if (weekCount == 6 && addDate.Day == 24)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.AddDays(7).Day != days)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                                else if (!(addDate.Day <= 23 && int.Parse(BYSETPOSCOUNT) == -1))
                                {
                                    RecDateCollection.Add(addDate.Date);
                                    addDate = addDate.AddMonths(MyMonthGap);
                                }
                                int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                if (statusValue != -1)
                                {
                                    IsUntilDateReached = true;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region YEARLY
                else if (YEARLY == "YEARLY")
                {
                    int YyYearGap = ruleArray.Length > 4 && INTERVAL == "INTERVAL" ? int.Parse(INTERVALCOUNT) : 1;
                    int position = ruleArray.Length > 4 && INTERVAL == "INTERVAL" ? 6 : BYMONTHDAYPOSITION;
                    if (BYMONTHDAY == "BYMONTHDAY")
                    {
                        int monthIndex = int.Parse(BYMONTHCOUNT);
                        int dayIndex = int.Parse(BYMONTHDAYCOUNT);
                        if (monthIndex > 0 && monthIndex <= 12)
                        {
                            int bound = DateTime.DaysInMonth(addDate.Year, monthIndex);
                            if (bound >= dayIndex)
                            {
                                var specificDate = new DateTime(addDate.Year, monthIndex, dayIndex);
                                if (specificDate.Date < addDate.Date)
                                {
                                    addDate = specificDate;
                                    addDate = addDate.AddYears(1);
                                }
                                else
                                {
                                    addDate = specificDate;
                                }
                                if (recCount == 0 && UNTIL == null)
                                {
                                    recCount = NeverCount;
                                }
                                if (recCount > 0)
                                {
                                    for (int i = 0; i < recCount; i++)
                                    {
                                        RecDateCollection.Add(addDate.Date);
                                        addDate = addDate.AddYears(YyYearGap);
                                    }
                                }
                                else if (UNTIL != null)
                                {
                                    bool IsUntilDateReached = false;
                                    while (!IsUntilDateReached)
                                    {
                                        RecDateCollection.Add(addDate.Date);
                                        addDate = addDate.AddYears(YyYearGap);
                                        int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                        if (statusValue != -1)
                                        {
                                            IsUntilDateReached = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (BYDAY == "BYDAY")
                    {
                        int monthIndex = int.Parse(BYMONTHCOUNT);
                        if (recCount == 0 && UNTIL == null)
                        {
                            recCount = NeverCount;
                        }
                        if (recCount > 0)
                        {
                            while (RecDateCollection.Count < recCount)
                            {
                                var weekCount = MondaysInMonth(addDate);
                                var monthStart = new DateTime(addDate.Year, monthIndex, 1);
                                DateTime weekStartDate = monthStart.AddDays(-(int)(monthStart.DayOfWeek));
                                var monthStartWeekday = (int)(monthStart.DayOfWeek);
                                int nthweekDay = GetWeekDay(BYDAYVALUE) - 1;
                                int nthWeek;
                                int bySetPos = 0;
                                int setPosCount;
                                int.TryParse(BYSETPOSCOUNT, out setPosCount);
                                if (monthStartWeekday <= nthweekDay)
                                {
                                    if (setPosCount < 1)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    if (setPosCount < 0)
                                    {
                                        nthWeek = bySetPos;
                                    }
                                    else
                                    {
                                        nthWeek = bySetPos - 1;
                                    }
                                }
                                else
                                {
                                    if (setPosCount < 0)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    nthWeek = bySetPos;
                                }
                                addDate = weekStartDate.AddDays((nthWeek) * 7);
                                addDate = addDate.AddDays(nthweekDay);
                                if (addDate.CompareTo(startDate.Date) < 0)
                                {
                                    addDate = addDate.AddYears(1);
                                    continue;
                                }
                                if (weekCount == 6 && addDate.Day == 23)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.Month == 2)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                                else if (weekCount == 6 && addDate.Day == 24)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.AddDays(7).Day != days)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                                else if (!(addDate.Day <= 23 && int.Parse(BYSETPOSCOUNT) == -1))
                                {
                                    RecDateCollection.Add(addDate.Date);
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                            }
                        }
                        else if (UNTIL != null)
                        {
                            bool IsUntilDateReached = false;
                            while (!IsUntilDateReached)
                            {
                                var weekCount = MondaysInMonth(addDate);
                                var monthStart = new DateTime(addDate.Year, monthIndex, 1);
                                DateTime weekStartDate = monthStart.AddDays(-(int)(monthStart.DayOfWeek));
                                var monthStartWeekday = (int)(monthStart.DayOfWeek);
                                int nthweekDay = GetWeekDay(BYDAYVALUE) - 1;
                                int nthWeek;
                                int bySetPos = 0;
                                int setPosCount;
                                int.TryParse(BYSETPOSCOUNT, out setPosCount);
                                if (monthStartWeekday <= nthweekDay)
                                {
                                    if (setPosCount < 1)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    if (setPosCount < 0)
                                    {
                                        nthWeek = bySetPos;
                                    }
                                    else
                                    {
                                        nthWeek = bySetPos - 1;
                                    }
                                }
                                else
                                {
                                    if (setPosCount < 0)
                                    {
                                        bySetPos = weekCount + setPosCount;
                                    }
                                    else
                                    {
                                        bySetPos = setPosCount;
                                    }
                                    nthWeek = bySetPos;
                                }
                                addDate = weekStartDate.AddDays((nthWeek) * 7);
                                addDate = addDate.AddDays(nthweekDay);
                                if (addDate.CompareTo(startDate.Date) < 0)
                                {
                                    addDate = addDate.AddYears(1);
                                    continue;
                                }
                                if (weekCount == 6 && addDate.Day == 23)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.Month == 2)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                                else if (weekCount == 6 && addDate.Day == 24)
                                {
                                    int days = DateTime.DaysInMonth(addDate.Year, addDate.Month);
                                    bool flag = true;
                                    if (addDate.AddDays(7).Day != days)
                                    {
                                        flag = false;
                                    }
                                    if (flag)
                                    {
                                        addDate = addDate.AddDays(7);
                                        RecDateCollection.Add(addDate.Date);
                                    }
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                                else if (!(addDate.Day <= 23 && int.Parse(BYSETPOSCOUNT) == -1))
                                {
                                    RecDateCollection.Add(addDate.Date);
                                    addDate = addDate.AddYears(YyYearGap);
                                }
                                int statusValue = DateTime.Compare(addDate.Date, Convert.ToDateTime(UNTIL));
                                if (statusValue != -1)
                                {
                                    IsUntilDateReached = true;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            var filteredDates = RecDateCollection.Except(exDateList).ToList();
            return filteredDates;
        }

        public static int MondaysInMonth(DateTime thisMonth)
        {
            DateTime today = thisMonth;
            //extract the month
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
            //days of week starts by default as Sunday = 0
            int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            int weeksInMonth = (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);
            return weeksInMonth;
        }

        private static void GetWeeklyDateCollection(DateTime addDate, string[] weeklyRule, List<DateTime> RecDateCollection)
        {
            switch (addDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("SU"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Monday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("MO"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("TU"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("WE"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("TH"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("FR"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        if (weeklyRule[WEEKLYBYDAYPOS].Contains("SA"))
                        {
                            RecDateCollection.Add(addDate.Date);
                        }
                        break;
                    }
            }
        }

        private static DateTime GetByMonthDayDateCollection(DateTime addDate, List<DateTime> RecDateCollection, int monthDate, int MyMonthGap)
        {
            if (addDate.Month == 2 && monthDate > 28)
            {
                addDate = new DateTime(addDate.Year, addDate.Month, DateTime.DaysInMonth(addDate.Year, 2));
                // RecDateCollection.Add(addDate.Date);
                addDate = addDate.AddMonths(MyMonthGap);
                addDate = new DateTime(addDate.Year, addDate.Month, monthDate);
            }
            else
            {
                RecDateCollection.Add(addDate.Date);
                addDate = addDate.AddMonths(MyMonthGap);
            }
            return addDate;
        }

        private static DateTime GetByDayDateValue(DateTime addDate, DateTime monthStart)
        {
            DateTime weekStartDate = monthStart.AddDays(-(int)(monthStart.DayOfWeek));
            var monthStartWeekday = (int)(monthStart.DayOfWeek);
            int nthweekDay = GetWeekDay(BYDAYVALUE) - 1;
            int nthWeek;
            if (monthStartWeekday <= nthweekDay)
            {
                nthWeek = int.Parse(BYSETPOSCOUNT) - 1;
            }
            else
            {
                nthWeek = int.Parse(BYSETPOSCOUNT);
            }
            addDate = weekStartDate.AddDays((nthWeek) * 7);
            addDate = addDate.AddDays(nthweekDay);
            return addDate;
        }
        private static void FindExdateList(string ruleException)
        {
            exDateList = new List<DateTime>();
            var exDates = ruleException.Split(',');
            for (int i = 0; i < exDates.Length; i++)
            {
                StringBuilder sb = new StringBuilder(exDates[i]);
                sb.Insert(4, '-'); sb.Insert(7, '-'); sb.Insert(13, ':'); sb.Insert(16, ':');
                DateTimeOffset value = DateTimeOffset.ParseExact(sb.ToString(), "yyyy-MM-dd'T'HH:mm:ss'Z'",
                                                       CultureInfo.InvariantCulture);
                exDateList.Add(value.DateTime.Date);
            }
        }

        private static int GetWeekDay(string weekDay)
        {
            switch (weekDay)
            {
                case "SU":
                    {
                        return 1;
                    }
                case "MO":
                    {
                        return 2;
                    }
                case "TU":
                    {
                        return 3;
                    }
                case "WE":
                    {
                        return 4;
                    }
                case "TH":
                    {
                        return 5;
                    }
                case "FR":
                    {
                        return 6;
                    }
                case "SA":
                    {
                        return 7;
                    }
            }
            return 8;
        }

        private static void FindWeeklyRule(string[] weeklyRule)
        {
            for (int i = 0; i < weeklyRule.Length; i++)
            {
                if (weeklyRule[i].Contains("BYDAY"))
                {
                    WEEKLYBYDAY = weeklyRule[i];
                    WEEKLYBYDAYPOS = i;
                    break;
                }
            }
        }

        private static void FindKeyIndex(string[] ruleArray, DateTime startDate)
        {
            RECCOUNT = "";
            DAILY = "";
            WEEKLY = "";
            MONTHLY = "";
            YEARLY = "";
            BYSETPOS = "";
            BYSETPOSCOUNT = "";
            INTERVAL = "";
            INTERVALCOUNT = "";
            COUNT = "";
            BYDAY = "";
            BYDAYVALUE = "";
            BYMONTHDAY = "";
            BYMONTHDAYCOUNT = "";
            BYMONTH = "";
            BYMONTHCOUNT = "";
            WEEKLYBYDAY = "";
            UNTIL = null;

            for (int i = 0; i < ruleArray.Length; i++)
            {
                if (ruleArray[i].Contains("COUNT"))
                {
                    COUNT = ruleArray[i];
                    RECCOUNT = ruleArray[i + 1];
                }

                if (ruleArray[i].Contains("UNTIL"))
                {
                    StringBuilder sb = new StringBuilder(ruleArray[i + 1]);
                    sb.Insert(4, '-'); sb.Insert(7, '-'); sb.Insert(13, ':'); sb.Insert(16, ':');
                    DateTimeOffset value = DateTimeOffset.ParseExact(sb.ToString(), "yyyy-MM-dd'T'HH:mm:ss'Z'",
                                                           CultureInfo.InvariantCulture);
                    UNTIL = value.DateTime.Date;
                }

                if (ruleArray[i].Contains("DAILY"))
                {
                    DAILY = ruleArray[i];
                }

                if (ruleArray[i].Contains("WEEKLY"))
                {
                    WEEKLY = ruleArray[i];
                }
                if (ruleArray[i].Contains("INTERVAL"))
                {
                    INTERVAL = ruleArray[i];
                    INTERVALCOUNT = ruleArray[i + 1];
                }
                if (ruleArray[i].Contains("MONTHLY"))
                {
                    MONTHLY = ruleArray[i];
                }
                if (ruleArray[i].Contains("YEARLY"))
                {
                    YEARLY = ruleArray[i];
                }
                if (ruleArray[i].Contains("BYSETPOS"))
                {
                    BYSETPOS = ruleArray[i];
                    var weekCount = MondaysInMonth(startDate);
                    BYSETPOSCOUNT = ruleArray[i + 1];
                }
                if (ruleArray[i].Contains("BYDAY"))
                {
                    BYDAYPOSITION = i;
                    BYDAY = ruleArray[i];
                    BYDAYVALUE = ruleArray[i + 1];
                }
                if (ruleArray[i].Contains("BYMONTHDAY"))
                {
                    BYMONTHDAYPOSITION = i;
                    BYMONTHDAY = ruleArray[i];
                    BYMONTHDAYCOUNT = ruleArray[i + 1];
                }
                if (ruleArray[i].Contains("BYMONTH"))
                {
                    BYMONTH = ruleArray[i];
                    BYMONTHCOUNT = ruleArray[i + 1];
                }
            }
        }
        #endregion

        public static List<DateTime> ConvertExDateStringToDateTimes(string exDateString)
        {
            string[] exDateStrings = new string[0];
            if (!string.IsNullOrWhiteSpace(exDateString))
            {
                 exDateStrings = exDateString.Split(',');
            }

            var exDates = new List<DateTime>();
            if (exDateStrings.Length > 0)
            {
                foreach (var date in exDateStrings)
                {
                    int newExDateYear = Convert.ToInt32(date.Substring(0, 4));
                    int newExDateMonth = Convert.ToInt32(date.Substring(4, 2));
                    int newExDateDay = Convert.ToInt32(date.Substring(6, 2));
                    int newExDateHour = Convert.ToInt32(date.Substring(9, 2));
                    int newExDateMinute = Convert.ToInt32(date.Substring(11, 2));
                    int newExDateSecond = Convert.ToInt32(date.Substring(13, 2));
                    exDates.Add(new DateTime(newExDateYear, newExDateMonth, newExDateDay));
                }
            }
            return exDates;
        }

        public static string ConvertDateTimesToExDateString(List<DateTime> dates)
        {
            string exDateString = "";
            foreach (var date in dates)
            {
                exDateString += $"{date.Year}{date.Month:00}{date.Day:00}T{date.Hour:00}{date.Minute:00}{date.Second:00}Z,";
            }

            return exDateString.Trim(',');
        }

        public static string ConvertDateTimeToExDateString(DateTime date)
        {
            return $"{date.Year}{date.Month:00}{date.Day:00}T{date.Hour:00}{date.Minute:00}{date.Second:00}Z";
        }
    }
}