﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication
{
    public abstract class SingletonRegistrarBase<TData, TInputData>
    {
        private readonly object syncLock = new object();

        private TData data;
        private volatile int registered;

        public TData Data
        {
            get
            {
                if (registered == 0)
                {
                    lock (syncLock)
                    {
                        if (registered == 0)
                        {
                            throw new InvalidOperationException(
                                "The singleton has not yet been registered");
                        }
                        else
                        {
                            return this.data;
                        }
                    }
                }
                else
                {
                    return this.data;
                }
            }
        }

        public TData RegisterData(TInputData inputData)
        {
            if (registered != 0)
            {
                OnAlreadyRegistered();
            }
            else
            {
                lock (syncLock)
                {
                    if (registered != 0)
                    {
                        OnAlreadyRegistered();
                    }
                    else
                    {
                        this.data = Convert(inputData);
                        registered = 1;
                    }
                }
            }

            return this.data;
        }

        protected abstract TData Convert(TInputData inputData);

        private void OnAlreadyRegistered()
        {
            throw new InvalidOperationException(
                "The singleton has already been registered and cannot be registered twice");
        }
    }
}
