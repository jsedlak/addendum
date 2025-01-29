using Microsoft.AspNetCore.Components;

namespace Addendum.Components.Toolkit;

public partial class ButtonTrayButton : ComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        if(IsDefaultActive && Parent is not null)
        {
            await Parent.ActivateButton(this);
        }
    }

    private async Task OnButtonClicked()
    {
        Console.WriteLine("OnButtonClicked");

        if(Parent == null || Parent.AllowMultipleActive)
        {
            Console.WriteLine("Flipping IsActive");

            IsActive = !IsActive;
            if(IsActiveChanged.HasDelegate)
            {
                await IsActiveChanged.InvokeAsync(IsActive);
            }
        }
        else
        {
            Console.WriteLine($"Calling Parent.Activate(this) for {Text}");
            await Parent.ActivateButton(this);
        }

        StateHasChanged();
    }

    public async Task Activate()
    {
        IsActive = true;
        if (IsActiveChanged.HasDelegate)
        {
            await IsActiveChanged.InvokeAsync(IsActive);
        }
    }

    public async Task Deactivate()
    {
        IsActive = false;
        if (IsActiveChanged.HasDelegate)
        {
            await IsActiveChanged.InvokeAsync(IsActive);
        }
    }

    [Parameter]
    public bool IsActive { get; set; }

    [Parameter]
    public EventCallback<bool> IsActiveChanged { get; set; }

    [Parameter]
    public string Text { get; set; } = "";

    [Parameter]
    public RenderFragment? Icon { get; set; } = null;

    [CascadingParameter(Name = "ButtonTray")]
    public ButtonTray Parent { get; set; }

    [Parameter]
    public bool IsDefaultActive { get; set; }
}
