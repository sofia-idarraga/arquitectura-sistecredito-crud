﻿using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.UseCase.Common
{
    /// <summary>
    /// Manage Events UseCase
    /// </summary>
    public class ManageEventsUseCase : IManageEventsUseCase
    {
        private readonly ITestEntityRepository testEntityRepository;
        private readonly ILogger<ManageEventsUseCase> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageEventsUseCase"/> class.
        /// </summary>
        /// <param name="testEntityRepository">The test entity repository.</param>
        /// <param name="logger">The logger.</param>
        public ManageEventsUseCase(ITestEntityRepository testEntityRepository, ILogger<ManageEventsUseCase> logger)
        {
            this.testEntityRepository = testEntityRepository;
            _logger = logger;
            _logger.LogInformation("Entro al use case en: {time}", DateTimeOffset.Now);
        }

        /// <summary>
        /// <see cref="IManageEventsUseCase.ConsoleLogAsync(string, string, dynamic, bool)"/>
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <returns></returns>
        public async Task ConsoleLogAsync(string eventName, string id, dynamic data, bool writeData = false) =>
            await Task.Run(() =>
            {
                _logger.LogInformation("EventName: {eventName} - Id: {id}", eventName, id);

                if (writeData)
                {
                    _logger.LogInformation($"Data: {data}");
                }
            });

        /// <summary>
        /// ConsoleErrorLog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public void ConsoleErrorLog(string message, Exception exception)
        {
            _logger.LogError("ERROR - {message} :: {@exception}", message, exception);
        }

        /// <summary>
        /// ConsoleTraceLog
        /// </summary>
        /// <param name="message"></param>
        public void ConsoleTraceLog(string message)
        {
            _logger.LogTrace("TRACE - {message}", message);
        }

        /// <summary>
        /// <see cref="IManageEventsUseCase.ConsoleInfoLog(string, object[])"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void ConsoleInfoLog(string message, params object[] args)
        {
            _logger.LogInformation("INFORMATION - {message} :: {args}", message, args);
        }

        /// <summary>
        /// <see cref="ConsoleProcessLog(string, string, dynamic, bool, string)"/>
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        public void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null)
        {
            _logger.LogInformation($"ClassName: {eventName} - MethodName: {callerMemberName} - Id: {id}");

            if (writeData)
                _logger.LogInformation($"Data: {data}");
        }
    }
}