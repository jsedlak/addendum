using Microsoft.AspNetCore.Components;

namespace Addendum.DocsApp.Components;

[AutoDoc(Category = "Content")]
public partial class Button : ComponentBase
{
    [Parameter]
    public required RenderFragment Content { get; set; }

    [Parameter]
    public required string Href { get; set; }
}
