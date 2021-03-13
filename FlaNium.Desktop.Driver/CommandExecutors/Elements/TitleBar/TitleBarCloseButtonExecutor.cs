﻿
using FlaUI.Core.AutomationElements;
using FlaNium.Desktop.Driver.FlaUI;
using FlaNium.Desktop.Driver.Common;
using FlaNium.Desktop.Driver.Exceptions;

namespace FlaNium.Desktop.Driver.CommandExecutors.Elements.TitleBar
{
    class TitleBarCloseButtonExecutor : CommandExecutorBase
    {
        #region Methods

        protected override string DoImpl()
        {
            var registeredKey = this.ExecutedCommand.Parameters["ID"].ToString();

            var element = this.Automator.ElementsRegistry.GetRegisteredElement(registeredKey);

            var titleBar = element.FlaUIElement.AsTitleBar();

            var result = titleBar.CloseButton;

            if (result == null)
            {
                throw new AutomationException("Element cannot be found", ResponseStatus.NoSuchElement);
            }

            var itemRegisteredKey = this.Automator.ElementsRegistry.RegisterElement(new FlaUIDriverElement(result));

            var registeredObject = new JsonElementContent(itemRegisteredKey);

            return this.JsonResponse(ResponseStatus.Success, registeredObject);
        }

        #endregion
    }
}
