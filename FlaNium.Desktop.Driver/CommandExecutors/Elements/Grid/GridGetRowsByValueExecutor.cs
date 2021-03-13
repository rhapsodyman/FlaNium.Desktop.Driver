﻿
namespace FlaNium.Desktop.Driver.CommandExecutors.Elements.Grid
{
    using System;
    using System.Linq;
    using global::FlaUI.Core.AutomationElements;
    using FlaNium.Desktop.Driver.FlaUI;
    using FlaNium.Desktop.Driver.Common;

    class GridGetRowsByValueExecutor : CommandExecutorBase
    {
        #region Methods

        protected override string DoImpl()
        {
            var registeredKey = this.ExecutedCommand.Parameters["ID"].ToString();

            var index = this.ExecutedCommand.Parameters["index"].ToString();

            var text = this.ExecutedCommand.Parameters["text"].ToString();
            
            var count = this.ExecutedCommand.Parameters["count"].ToString();

            var element = this.Automator.ElementsRegistry.GetRegisteredElement(registeredKey);

            Grid grid = element.FlaUIElement.AsGrid();

            var result = grid.GetRowsByValue(int.Parse(index), text, int.Parse(count));

            var flaUiDriverElementList = result
                .Select<AutomationElement, FlaUIDriverElement>((Func<AutomationElement, FlaUIDriverElement>)(x => new FlaUIDriverElement(x)))
                .ToList<FlaUIDriverElement>();

            var registeredKeys = this.Automator.ElementsRegistry.RegisterElements(flaUiDriverElementList);

            var registeredObjects = registeredKeys.Select(e => new JsonElementContent(e));

            return this.JsonResponse(ResponseStatus.Success, registeredObjects);
        }

        #endregion
    }
}
