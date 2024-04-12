using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyApp.WebAddIn.Components.Pages
{
    public partial class Weather
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;
        public IJSObjectReference JSModule { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                JSModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Pages/Home.razor.js");
            }
        }

        /// <summary>
        /// Basic function to invoke inserting `Hello world!` text.
        /// </summary>
        private async Task HelloButton() =>
            await JSModule.InvokeVoidAsync("helloButton");
    }
}
