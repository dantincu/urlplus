using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerplateCode
{
    public static class UtilsH
    {
        public static TOut With<TIn, TOut>(
            this TIn inVal,
            Func<TIn, TOut> convertor) => convertor(inVal);

        public static TVal ActWith<TVal>(
            this TVal val,
            Action<TVal> callback)
        {
            callback(val);
            return val;
        }

        public static T[] Arr<T>(this T firstVal, params T[] nextItemsArr)
        {
            T[] retArr = new T[nextItemsArr.Length + 1];
            retArr[0] = firstVal;

            nextItemsArr.CopyTo(retArr, 1);
            return retArr;
        }

        public static KeyValuePair<int, T> FirstKvp<T>(
            this IEnumerable<T> nmrbl,
            Func<T, int, bool> predicate)
        {
            KeyValuePair<int, T> retKvp = new KeyValuePair<int, T>(-1, default);
            int idx = 0;

            foreach (T item in nmrbl)
            {
                if (predicate(item, idx))
                {
                    retKvp = new KeyValuePair<int, T>(idx, item);
                    break;
                }
                else
                {
                    idx++;
                }
            }

            return retKvp;
        }

        public static KeyValuePair<int, T> FirstKvp<T>(
            this IEnumerable<T> nmrbl,
            Func<T, bool> predicate) => FirstKvp(
                nmrbl, (item, idx) => predicate(item));
    }
}
