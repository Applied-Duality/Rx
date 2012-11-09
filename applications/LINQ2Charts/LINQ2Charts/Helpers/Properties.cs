// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    public static class Properties
    {
        static bool TryParse<T>(string input, out T result)
        {
            result = default(T);
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            try
            {
                object resultAsObject = converter.ConvertFromString(input);
                if (resultAsObject == null) return false;
                result = (T)resultAsObject;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static T Get<T>(this DataPoint point, string property)
        {
            var result = default(T);
            TryParse(point[property], out result);
            return result;
        }
        public static void Set<T>(this DataPoint point, string property, T value)
        {
            point[property] = value.ToString();
        }

        public static T Get<T>(this Series series, string property, T @default)
        {
            var result = default(T);
            return TryParse(series[property], out result) ? result : @default;
        }

        public static T Get<T>(this Series series, string property)
        {
            var result = default(T);
            return TryParse(series[property], out result) ? result :result;
        }
        public static void Set<T>(this Series series, string property, T value)
        {
            series[property] = value.ToString();
        }
    }
}