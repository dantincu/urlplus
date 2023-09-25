﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Turmerik
{
    public static partial class FuncH
    {
        public static async Task<TOut> WithAsync<TIn, TOut>(
            this TIn inVal,
            Func<TIn, Task<TOut>> convertor) => await convertor(inVal);

        public static async Task<TOut> WithAsync<TIn, TOut>(
            this Task<TIn> inTask,
            Func<TIn, Task<TOut>> convertor) => await convertor(await inTask);

        public static async Task<TVal> ActWithAsync<TVal>(
            this TVal val,
            Func<TVal, Task> callback)
        {
            await callback(val);
            return val;
        }

        public static async Task<TVal> ActWithAsync<TVal>(
            this Task<TVal> task,
            Func<TVal, Task> callback)
        {
            var val = await task;
            await callback(val);

            return val;
        }

        public static async Task<T> IfAsync<T>(
            this bool condition,
            Func<Task<T>> ifTrueAction = null,
            Func<Task<T>> ifFalseAction = null)
        {
            T retVal;

            if (condition)
            {
                if (ifTrueAction != null)
                {
                    retVal = await ifTrueAction();
                }
                else
                {
                    retVal = default;
                }
            }
            else
            {
                if (ifFalseAction != null)
                {
                    retVal = await ifFalseAction();
                }
                else
                {
                    retVal = default;
                }
            }

            return retVal;
        }

        public static async Task<T> IfAsync<T>(
            this Task<bool> conditionTask,
            Func<Task<T>> ifTrueAction = null,
            Func<Task<T>> ifFalseAction = null)
        {
            var condition = await conditionTask;

            var retVal = await condition.IfAsync(
                ifTrueAction,
                ifFalseAction);

            return retVal;
        }

        public static async Task<bool> ActIfAsync(
            this bool condition,
            Func<Task> ifTrueAction = null,
            Func<Task> ifFalseAction = null)
        {
            if (condition)
            {
                if (ifTrueAction != null)
                {
                    await ifTrueAction();
                }
            }
            else
            {
                if (ifFalseAction != null)
                {
                    await ifFalseAction();
                }
            }

            return condition;
        }

        public static async Task<bool> ActIfAsync(
            this Task<bool> conditionTask,
            Func<Task> ifTrueAction = null,
            Func<Task> ifFalseAction = null)
        {
            var condition = await conditionTask;

            await condition.ActIfAsync(
                ifTrueAction,
                ifFalseAction);

            return condition;
        }
    }
}