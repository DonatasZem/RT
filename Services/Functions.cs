using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public class Functions : IFunctions
    {
        public string Clock()
        {
            Console.WriteLine("Enter hour from 1-12");
            var hours = "";
            do
            {
                bool stop = false;
                var hourInput = Console.ReadLine();
                var hourValidation = ValidateHour(hourInput);
                // Validation hour
                if (hourValidation != "ok")
                {
                    Console.WriteLine(hourValidation);
                }
                else if (hourValidation == "ok")
                {
                    hours = hourInput;
                    stop = true;
                }

                if (stop == true) break;

            } while (true);
            //----------------------------------------------
            
            Console.WriteLine("Enter minutes from 0-60");
            var minutes = "";
            do
            {
                bool stop = false;
                var minutesInput = Console.ReadLine();
                var minutesValidation = ValidateMinutes(minutesInput);
                // Validation hour
                if (minutesValidation != "ok")
                {
                    Console.WriteLine(minutesValidation);
                }
                else if (minutesValidation == "ok")
                {
                    minutes = minutesInput;
                    stop = true;
                }

                if (stop == true) break;

            } while (true);
            //---------------------------------------------


            //hour int
            var hourInt = int.Parse(hours);
            // minutes int
            var minutesInt = int.Parse(minutes);

            // 720 max minutes (12*60)
            // 1 min = 6degree (360/60)
            // one minute in hour got 0.5 degree (360/720)
            // 1h = 30 degree

            double resultHourToMinute = 0;
            double resultMinuteToHour = 0;
            double result = 0;
            if (hourInt == 12)
            {
                hourInt = 0;
            }

            var getHourArrowDegree = (hourInt * 60 + minutesInt) * 0.5;

            var getMinutesArrowDegree = minutesInt * 6;

            if (getHourArrowDegree > 180)
            {
                var a = getHourArrowDegree - getMinutesArrowDegree;

                resultHourToMinute = 360 - a;
            } else
            {
                if (getHourArrowDegree > getMinutesArrowDegree)
                {
                    resultHourToMinute = getHourArrowDegree - getMinutesArrowDegree;
                } else
                {
                    resultHourToMinute = getMinutesArrowDegree - getHourArrowDegree;
                }
            }

            resultMinuteToHour = 360 - resultHourToMinute;

            if (resultHourToMinute < resultMinuteToHour)
            {
                result = resultHourToMinute;
            } else
            {
                result = resultMinuteToHour;
            }

            return $"Resutl : {result}";
        }

        public string ValidateHour(string hourInput)
        {
            var regexForHour = new Regex("^[0-9]+$");

            if (!regexForHour.IsMatch(hourInput))
            {
                return "Only positive numbers allowed no letters";
            }

            if (hourInput == "0")
            {
                return "Hour cannot be 0";
            }

            if (hourInput == "00")
            {
                return "Hour cannot be 00";
            }

            if (hourInput.Length > 2)
            {
                return "Large length";
            }

            if (hourInput.Length == null)
            {
                return "It's null";
            }

            if (int.Parse(hourInput) > 12)
            {
                return "Your number is higher than 12";
            }

            return "ok";
        }

        public string ValidateMinutes(string minutesInput)
        {
            var regexForMinutes = new Regex("^[0-9]+$");

            if (!regexForMinutes.IsMatch(minutesInput))
            {
                return "Only positive numbers allowed no letters";
            }

            if (minutesInput.Length <= 1)
            {
                return "Must be two numbers";
            }

            if (minutesInput.Length > 2)
            {
                return "Large length";
            }

            if (minutesInput.Length == null)
            {
                return "It's null";
            }

            if (int.Parse(minutesInput) > 60)
            {
                return "Your number is higher than 60";
            }

            return "ok";
        }
    }
}
