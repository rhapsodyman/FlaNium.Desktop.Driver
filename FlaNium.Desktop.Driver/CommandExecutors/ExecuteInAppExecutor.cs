﻿using System.Collections.Generic;
using FlaNium.Desktop.Driver.Common;
using FlaNium.Desktop.Driver.FlaUI;
using Newtonsoft.Json.Linq;

namespace FlaNium.Desktop.Driver.CommandExecutors {

    internal class ExecuteInAppExecutor : CommandExecutorBase {

        protected override JsonResponse  DoImpl() {
            IDictionary<string, JToken> map = this.ExecutedCommand.Parameters;

            if (!this.Automator.ActualCapabilities.InjectionActivate) {
                return this.JsonResponse(ResponseStatus.UnknownCommand,
                    "InjectionActivate Capabilities (DesktopOptions) should be TRUE!");
            }

            if (map.ContainsKey("SESSIONID")) map.Remove("SESSIONID");

            var response = DriverManager.ClientSocket.DataExchange(map);

            return this.JsonResponse(ResponseStatus.Success, response);
        }

    }

}