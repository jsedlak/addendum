using Microsoft.AspNetCore.Components;

namespace Addendum.Components.Toolkit;

public partial class ButtonTray : ComponentBase
{
    private ButtonTrayButton? _activeButton;

    public async Task ActivateButton(ButtonTrayButton button)
    {
        if(_activeButton is not null)
        {
            Console.WriteLine($"Calling {_activeButton.Text}.Deactivate()");
            await _activeButton.Deactivate();
        }

        _activeButton = button;

        Console.WriteLine($"Calling {_activeButton.Text}.Activate()");
        await _activeButton.Activate();

        StateHasChanged();
    }

    [Parameter]
    public bool AllowMultipleActive { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;
}
