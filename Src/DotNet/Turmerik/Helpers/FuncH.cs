using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turmerik.Helpers;

namespace Turmerik
{
    public static partial class FuncH
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

        public static T If<T>(
            this bool condition,
            Func<T> ifTrueAction = null,
            Func<T> ifFalseAction = null)
        {
            T retVal;

            if (condition)
            {
                retVal = ifTrueAction.FirstNotNull(
                    () => default).Invoke();
            }
            else
            {
                retVal = ifFalseAction.FirstNotNull(
                    () => default).Invoke();
            }

            return retVal;
        }

        public static bool ActIf(
            this bool condition,
            Action ifTrueAction = null,
            Action ifFalseAction = null)
        {
            if (condition)
            {
                ifTrueAction?.Invoke();
            }
            else
            {
                ifFalseAction?.Invoke();
            }

            return condition;
        }

        public static async Task<bool> ActIfSync(
            this Task<bool> conditionTask,
            Action ifTrueAction = null,
            Action ifFalseAction = null)
        {
            var condition = await conditionTask;

            condition.ActIf(
                ifTrueAction,
                ifFalseAction);

            return condition;
        }
    }
}
