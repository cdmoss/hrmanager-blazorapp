using HRManager.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common.Services
{
    public class CurrentDateFilter
    {
        public bool CheckIfShiftDateIsAfterToday(Shift shift)
        {
            if (!string.IsNullOrEmpty(shift.RecurrenceRule))
            {
                string excludedDatesString = "";

                var childShiftDates = RecurrenceHelper.GetRecurrenceDateTimeCollection(shift.RecurrenceRule, shift.StartTime).ToList();

                for (int i = 0; i < childShiftDates.Count(); i++)
                {
                    if (childShiftDates[i] >= DateTime.Now.Date)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            DateTime selectedShiftDate = childShiftDates[j];

                            excludedDatesString += $"\\nEXDATE:{selectedShiftDate.ToString("yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture)}Z";
                        }

                        shift.RecurrenceRule += excludedDatesString;
                        return true;
                    }
                }
            }
            else
            {
                if (shift.StartTime >= DateTime.Now.Date)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
