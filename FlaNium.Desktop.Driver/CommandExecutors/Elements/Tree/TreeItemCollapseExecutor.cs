﻿using FlaNium.Desktop.Driver.Common;
using FlaUI.Core.AutomationElements;

namespace FlaNium.Desktop.Driver.CommandExecutors.Elements.Tree {

    class TreeItemCollapseExecutor : CommandExecutorBase {

        protected override JsonResponse  DoImpl() {
            var registeredKey = this.ExecutedCommand.Parameters["ID"].ToString();

            var element = this.Automator.ElementsRegistry.GetRegisteredElement(registeredKey);

            var treeItem = element.FlaUiElement.AsTreeItem();

            treeItem.Collapse();

            return this.JsonResponse();
        }

    }

}