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

using System.Threading;
using System.Threading.Tasks;

namespace SimpleSoft.Mediator
{
    /// <summary>
    /// Mediator to publish commands, broadcast events and fetch queries
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Sends a command to an <see cref="ICommandHandler{TCommand}"/>.
        /// </summary>
        /// <param name="cmd">The command to publish</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited</returns>
        Task SendAsync(ICommand cmd, CancellationToken ct);

        /// <summary>
        /// Sends a command to an <see cref="ICommandHandler{TCommand,TResult}"/> and 
        /// returns the operation result.
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="cmd">The command to publish</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited for the result</returns>
        Task<TResult> SendAsync<TResult>(ICommand<TResult> cmd, CancellationToken ct);

        /// <summary>
        /// Broadcast the event across all <see cref="IEventHandler{TEvent}"/>.
        /// </summary>
        /// <param name="evt">The event to broadcast</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited</returns>
        Task BroadcastAsync(IEvent evt, CancellationToken ct);

        /// <summary>
        /// Fetches a query from a <see cref="IQueryHandler{TQuery,TResult}"/> and 
        /// returns the query result.
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="query">The query to fetch</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task to be awaited for the result</returns>
        Task<TResult> FetchAsync<TResult>(IQuery<TResult> query, CancellationToken ct);
    }
}
