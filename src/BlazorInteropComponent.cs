using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorJSBlazor
{
    /// <summary>
    /// Base class for components that have JS client component.
    /// </summary>
    public class BlazorInteropComponent : ComponentBase
    {
        /// <summary>
        /// Element that will be passed to client JS component. 
        /// </summary>
        protected ElementReference DomElement { get; set; }

        /// <summary>
        /// ID of the client component.
        /// </summary>
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

        /// <summary>
        /// Initialize the client JS component.
        /// </summary>
        /// <returns></returns>
        protected virtual Task InitializeClientComponent()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Calls the JS object method.
        /// </summary>
        /// <param name="methodName">Name of the JS method.</param>
        /// <param name="args">Argumets to pass to the method</param>
        protected async Task CallClientMethod(string methodName, params object[] args)
        {
            var allParams = new object[] { ClientComponentID, methodName }.ToList();

            allParams.AddRange(args.ToList());

            await JSRuntime.InvokeAsync<string>($"editorJsHandler.callEditorMethod", allParams.ToArray());
        }

        /// <summary>
        /// Method invoked from JS that retrieves Blazor component property value.
        /// </summary>
        /// <param name="propertyName">Name of the property to retrieve</param>
        /// <returns>Vale of the property</returns>
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
