using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJSBlazor
{
    public class EditorInteropComponent : ComponentBase
    {
        protected ElementReference DomElement { get; set; }

        protected Guid ClientComponentID { get; set; } = Guid.NewGuid();

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await this.InitializeClientComponent();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected virtual Task InitializeClientComponent()
        {
            return Task.CompletedTask;
        }

        protected async Task CallClientMethod(string methodName, params object[] args)
        {
            var allParams = new object[] { ClientComponentID, methodName }.ToList();

            allParams.AddRange(args.ToList());

            await JSRuntime.InvokeAsync<string>($"editorJsHandler.callEditorMethod", allParams.ToArray());
        }

        [JSInvokable]
        public Task<object> GetBlazorProperty(string propertyName)
        {
            var property = this.GetType().GetProperty(propertyName);

            if (property == null)
            {
                throw new ApplicationException($"Property {propertyName} not found on {this.GetType().Name}");
            }

            return Task.FromResult(property.GetValue(this));
        }
    }
}
