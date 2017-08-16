﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2017 Simplesoft.pt
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSoft.Mediator.Internal
{
    internal class DelegateCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly Func<TCommand, CancellationToken, Task> _handler;

        public DelegateCommandHandler(Func<TCommand, CancellationToken, Task> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            _handler = handler;
        }

        public async Task HandleAsync(TCommand cmd, CancellationToken ct = default(CancellationToken))
        {
            await _handler(cmd, ct).ConfigureAwait(false);
        }
    }

    internal class DelegateCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly Func<TCommand, CancellationToken, Task<TResult>> _handler;

        public DelegateCommandHandler(Func<TCommand, CancellationToken, Task<TResult>> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            _handler = handler;
        }

        public async Task<TResult> HandleAsync(TCommand cmd, CancellationToken ct = default(CancellationToken))
        {
            return await _handler(cmd, ct).ConfigureAwait(false);
        }
    }
}