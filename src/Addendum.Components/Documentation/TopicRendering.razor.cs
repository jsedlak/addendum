using Addendum;
using Microsoft.AspNetCore.Components;

namespace Addendum.Components.Documentation;

public partial class TopicRendering : ComponentBase
{
    public IDictionary<string, object?> GetParameterCollection()
    {
        if(MetaData is null || Topic is null)
        {
            return new Dictionary<string, object?>();
        }

        var parameters = new Dictionary<string, object?>();

        foreach(var parm in MetaData.Parameters)
        {
            parameters.Add(parm.Name, parm.Value);
        }

        foreach(var parm in Topic.Parameters)
        {
            if(parameters.ContainsKey(parm.Name))
            {
                parameters[parm.Name] = parm.Value;
            }
            else
            {
                parameters.Add(parm.Name, parm.Value);
            }
        }

        return parameters;
    }

    [Parameter]
    public ComponentMetaData? MetaData { get; set; }

    [Parameter]
    public Topic? Topic { get; set; }
}
