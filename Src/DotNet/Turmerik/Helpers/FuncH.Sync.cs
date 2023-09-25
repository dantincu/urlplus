using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Turmerik
{
    public static partial class FuncH
    {
        public static async Task<TOut> WithSync<TIn, TOut>(
            this Task<TIn> inTask,
            Func<TIn, TOut> convertor) => convertor(await inTask);

        public static async Task<TVal> ActWithSync<TVal>(
            this Task<TVal> task,
            Action<TVal> callback)
        {
            var val = await task;
            callback(val);

            return val;
        }

        public static async Task<T> IfSync<T>(
            this Task<bool> conditionTask,
            Func<T> ifTrueAction = null,
            Func<T> ifFalseAction = null)
        {
            var condition = await conditionTask;

            var retVal = condition.If(
                ifTrueAction,
                ifFalseAction);

            return retVal;
        }
    }
}
