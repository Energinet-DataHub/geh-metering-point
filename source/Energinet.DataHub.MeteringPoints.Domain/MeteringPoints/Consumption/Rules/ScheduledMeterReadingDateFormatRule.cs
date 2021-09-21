﻿// Copyright 2020 Energinet DataHub A/S
//
// Licensed under the Apache License, Version 2.0 (the "License2");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Globalization;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;

namespace Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.Consumption.Rules
{
    public class ScheduledMeterReadingDateFormatRule : IBusinessRule
    {
        public ScheduledMeterReadingDateFormatRule(string monthAndDay)
        {
            if (monthAndDay == null) throw new ArgumentNullException(nameof(monthAndDay));

            IsBroken = !IsValid(monthAndDay);
        }

        public bool IsBroken { get; }

        public ValidationError ValidationError => new InvalidScheduledMeterReadingDateRuleError();

        private static bool IsValid(string monthAndDay)
        {
            if (monthAndDay.Length > 4)
            {
                return false;
            }

            return IsNumeric(monthAndDay) != false && IsMonthAndDayValid(monthAndDay);
        }

        private static bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }

        private static bool IsMonthAndDayValid(string monthAndDay)
        {
            var month = int.Parse(monthAndDay.Substring(0, 2), NumberStyles.Integer, new NumberFormatInfo());
            var day = int.Parse(monthAndDay.Substring(2, 2), NumberStyles.Integer, new NumberFormatInfo());

            if (month is < 1 or > 12)
            {
                return false;
            }

            return day <= DateTime.DaysInMonth(1970, month);
        }
    }
}
