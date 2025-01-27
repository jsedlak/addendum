using Microsoft.AspNetCore.Components;

namespace Addendum.Components.Documentation
{
    public partial class ComponentDoc : ComponentBase
    {
        [Parameter]
        public ComponentMetaData? MetaData { get; set; }

        [Parameter]
        public IEnumerable<Topic> Topics { get; set; } = [];
    }
}
