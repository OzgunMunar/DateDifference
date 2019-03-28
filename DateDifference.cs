using System;
using System.Collections;

namespace DateDifferencePackage
{

    public class DateDifference
    {

        #region -- Private Variables --
        private static System.DateTime _EarlyDateTime { get; set; }
        private static System.DateTime _LateDateTime { get; set; }

        private static int _FirstDateTimeYear { get; set; }
        private static int _SecondDateTimeYear { get; set; }

        private static int _FirstDateTimeMonth { get; set; }
        private static int _SecondDateTimeMonth { get; set; }

        private static int _FirstDateTimeDay { get; set; }
        private static int _SecondDateTimeDay { get; set; }

        private static int _DaysToCompleteMonth { get; set; }

        private static int _LastDayOfMonth { get; set; }

        private static int _YearDifference { get; set; }

        #endregion
        public static Hashtable Calculate(DateTime FirstDatetime, DateTime SecondDateTime)
        {

            Hashtable DateDiff = new Hashtable();

            int Day = 0;
            int Month = 0;
            int Year = 0;

            DateDiff.Add("Day", Day);
            DateDiff.Add("Month", Month);
            DateDiff.Add("Year", Year);

            #region -- Declaring Early and Late Date --

            if (FirstDatetime == SecondDateTime)
            {
                
                return DateDiff;

            }
            else if (FirstDatetime > SecondDateTime)
            {

                _EarlyDateTime = SecondDateTime;
                _LateDateTime = FirstDatetime;

            }
            else
            {

                _EarlyDateTime = FirstDatetime;
                _LateDateTime = SecondDateTime;

            }

            #endregion

            #region -- Date Calculation --

            if (_LateDateTime.Year - _EarlyDateTime.Year == 0)
            {

                if (_EarlyDateTime.Day > _LateDateTime.Day)
                {

                    _LastDayOfMonth = DateTime.DaysInMonth(_EarlyDateTime.Year, _EarlyDateTime.Month);
                    
                    DateDiff["Month"] = _LateDateTime.Month - _EarlyDateTime.Month - 1;
                    DateDiff["Day"] = _LastDayOfMonth - (_EarlyDateTime.Day - _LateDateTime.Day);

                }
                else
                {

                    DateDiff["Month"] = _LateDateTime.Month - _EarlyDateTime.Month;
                    DateDiff["Day"] = _LateDateTime.Day - _EarlyDateTime.Day;

                }

                Year = 0;

            }
            else if (_LateDateTime.Year - _EarlyDateTime.Year > 0)
            {

                _YearDifference = _LateDateTime.Year - _EarlyDateTime.Year;

                if (_LateDateTime.Month == _EarlyDateTime.Month)
                {

                    if (_LateDateTime.Day < _EarlyDateTime.Day)
                    {

                        _DaysToCompleteMonth = DateTime.DaysInMonth(_EarlyDateTime.Year, _EarlyDateTime.Month);

                        DateDiff["Day"] = (_DaysToCompleteMonth - _EarlyDateTime.Day) + _LateDateTime.Day;
                        DateDiff["Month"] = 11;
                        DateDiff["Year"] = _YearDifference - 1;

                    }
                    else
                    {

                        DateDiff["Day"] = _LateDateTime.Day - _EarlyDateTime.Day;
                        DateDiff["Month"] = 0;
                        DateDiff["Year"] = _YearDifference;

                    }

                }
                else if (_LateDateTime.Month - _EarlyDateTime.Month > 0)
                {

                    DateDiff["Year"] = _YearDifference;
                    DateDiff["Month"] = _LateDateTime.Month - _EarlyDateTime.Month;

                    if (_LateDateTime.Day < _EarlyDateTime.Day)
                    {

                        DateDiff["Month"] = Convert.ToInt32(DateDiff["Month"]) - 1;

                        _DaysToCompleteMonth = DateTime.DaysInMonth(_EarlyDateTime.Year, _EarlyDateTime.Month);
                        DateDiff["Day"] = (_DaysToCompleteMonth - _EarlyDateTime.Day) + _LateDateTime.Day;

                    }
                    else
                    {

                        DateDiff["Day"] = _LateDateTime.Day - _EarlyDateTime.Day;

                    }

                }
                else if (_LateDateTime.Month - _EarlyDateTime.Month < 0)
                {

                    DateDiff["Year"] = _YearDifference - 1;
                    DateDiff["Month"] = 12 - _EarlyDateTime.Month + _LateDateTime.Month;

                    if (_LateDateTime.Day < _EarlyDateTime.Day)
                    {

                        DateDiff["Month"] = Convert.ToInt32(DateDiff["Month"]) - 1;

                        _DaysToCompleteMonth = DateTime.DaysInMonth(_EarlyDateTime.Year, _EarlyDateTime.Month);
                        DateDiff["Day"] = (_DaysToCompleteMonth - _EarlyDateTime.Day) + _LateDateTime.Day;

                    }
                    else
                    {

                        DateDiff["Day"] = _LateDateTime.Day - _EarlyDateTime.Day;

                    }

                }

            }

            #endregion

            return DateDiff;

        }

    }

}
