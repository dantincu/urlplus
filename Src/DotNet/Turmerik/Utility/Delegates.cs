﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmerik.Utility
{
    public delegate void ParamsAction(params object[] arguments);

    public delegate void ParamsAction<T1>(T1 arg1, params object[] arguments);

    public delegate void RefAction<T>(ref T t);

    public delegate int IdxRetriever<T, TNmrbl>(TNmrbl nmrbl, int count) where TNmrbl : IEnumerable<T>;

    public delegate bool TryRetrieve<TInput, TOutput>(
        TInput input,
        out TOutput output);

    public delegate bool TryRetrieve<TObj, TInput, TOutput>(
        TObj @obj,
        TInput input,
        out TOutput output);

    public delegate TValue UpdateDictnrValue<TKey, TValue>(
        TKey key,
        bool isUpdate,
        TValue value);

    public delegate TOutArr ArraySliceFactory<T, TInArr, TOutArr>(
        TInArr inputArr,
        int startIdx,
        int count);

    public delegate void ForEachCallback<T>(T value, MutableValueWrapper<bool> @break);
    public delegate void ForCallback<T>(T value, int idx, MutableValueWrapper<bool> @break);
    public delegate void ForIdxCallback(int idx, MutableValueWrapper<bool> @break);
}
