////////////////////////////////////////////////////////////////////////////
//
//
//      Project     :   TsakiridisDevicesDaedalos
//      Description :   Tsakiridis Devices Daedalos SDK
//      Author      :   Pantelis Georgiadis (PantelisGeorgiadis@Gmail.com)
//      Date        :   30-04-2017
//
//
//      File description :
//      Name    :       SafeLinqExtensions.cs
//      Details :
//
//      (C) Copyright 2016-2022 Tsakiridis Devices
//      All rights reserved.
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace TsakiridisDevicesDaedalos.SDK.Helpers
{
    public static class SafeLinqExtensions
    {
        private delegate bool TryParseHandler<T>(String value, NumberStyles numberStyles,
            IFormatProvider formatProvider, out T result);
        private delegate bool DateTryParseHandler<T>(String value, out T result);

        public static bool HasElement(this XElement element, String elementName)
        {
            if (element == null)
                return false;

            return element.Elements(elementName).Count() == 1;
        }

        public static String GetStringElement(this XElement element, String elementName)
        {
            return HasElement(element, elementName) ? element.Element(elementName).Value : null;
        }

        public static DateTime? GetDateTimeElement(this XElement element, String elementName)
        {
            if (!HasElement(element, elementName))
                return null;

            var elementValue = element.Element(elementName).Value;
            if (!String.IsNullOrWhiteSpace(elementValue))
            {
                var value = DateTryParse<DateTime>(elementValue, DateTime.TryParse);
                return value;
            }

            return null;
        }

        public static int? GetIntElement(this XElement element, String elementName)
        {
            if (!HasElement(element, elementName))
                return null;

            var elementValue = element.Element(elementName).Value;
            if (!String.IsNullOrWhiteSpace(elementValue))
            {
                var value = TryParse<int>(elementValue, int.TryParse);
                if (value != null)
                    return value;
            }

            return null;
        }

        public static float? GetFloatElement(this XElement element, String elementName)
        {
            if (!HasElement(element, elementName))
                return null;

            var elementValue = element.Element(elementName).Value;
            if (!String.IsNullOrWhiteSpace(elementValue))
            {
                var value = TryParse<float>(elementValue, float.TryParse);
                if (value != null)
                    return value;
            }

            return null;
        }

        private static T? TryParse<T>(String value, TryParseHandler<T> handler) where T : struct
        {
            if (String.IsNullOrEmpty(value))
                return null;

            T result;
            if (handler(value, NumberStyles.Any,
                CultureInfo.InvariantCulture, out result))
                return result;

            return null;
        }

        private static T? DateTryParse<T>(String value, DateTryParseHandler<T> handler) where T : struct
        {
            if (String.IsNullOrEmpty(value))
                return null;

            T result;
            if (handler(value, out result))
                return result;

            return null;
        }
    }
}
