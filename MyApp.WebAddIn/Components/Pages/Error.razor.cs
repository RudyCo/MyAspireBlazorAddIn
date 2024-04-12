using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace MyApp.WebAddIn.Components.Pages
{
    public partial class Error
    {
        [CascadingParameter]
        public HttpContext? HttpContext { get; set; }

        private string? requestId;
        private bool ShowRequestId => !string.IsNullOrEmpty(requestId);

        protected override void OnInitialized()
        {
            requestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        }
    }
}