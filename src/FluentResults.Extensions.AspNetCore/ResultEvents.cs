using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FluentResults.Extensions.AspNetCore
{
    public abstract class ResultEvents<TContext>
    {
        public Dictionary<Type, Func<TContext, ActionResult>> _handlers = new();

        public IReadOnlyDictionary<Type, Func<TContext, ActionResult>> Handlers => _handlers;

        public Func<TContext, ActionResult> OnSuccess
        {
            get => _handlers[typeof(Success)];
            set => RegisterHandler<Success>(value);
        }

        public Func<TContext, ActionResult> OnFailed
        {
            get => _handlers[typeof(Error)];
            set => RegisterHandler<Error>(value);
        }

        public void RegisterHandler<TReason>(Func<TContext, ActionResult> handler)
        {
            _handlers[typeof(TReason)] = handler;
        }
    }
}
