﻿using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.UseCase.Common
{
    /// <summary>
    /// IManageEventsUseCase
    /// </summary>
    public interface IManageEventsUseCase
    {
        /// <summary>
        /// Consoles the process log.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        /// <param name="writeData">if set to <c>true</c> [write data].</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null);

        /// <summary>
        /// Console log
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <returns></returns>
        Task ConsoleLogAsync(string eventName, string id, dynamic data, bool writeData = false);

        /// <summary>
        /// Console error log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        void ConsoleErrorLog(string message, Exception exception);

        /// <summary>
        /// ConsoleTraceLog
        /// </summary>
        /// <param name="message"></param>
        void ConsoleTraceLog(string message);

        /// <summary>
        /// Console information log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        void ConsoleInfoLog(string message, params object[] args);
    }
}