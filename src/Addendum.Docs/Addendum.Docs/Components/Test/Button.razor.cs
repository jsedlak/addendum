using Microsoft.AspNetCore.Components;

namespace Addendum.Docs.Components.Test;

[AutoDoc(Category = "Content")]
public partial class Button
{
    [Parameter]
    public required RenderFragment Content { get; set; }

    [Parameter]
    public required string Href { get; set; }
}
