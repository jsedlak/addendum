using Addendum;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System.Text;
using System.Web;

namespace Addendum.Components.Documentation;

public partial class TopicRendering : ComponentBase
{
    private bool _isPreviewActive = false;
    private bool _isCodeActive = false;

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

    private MarkupString GenerateCode()
    {
        var type = Type.GetType(MetaData.ComponentType);

        if(type is null)
        {
            return new MarkupString("Error - could not produce the razor syntax");
        }

        var sb = new StringBuilder();

        sb.AppendLine($"<{type.Name}");

        foreach(var parameter in GetParameterCollection())
        {
            if(parameter.Value is null)
            {
                continue;
            }

            sb.AppendLine($"  {parameter.Key}=\"{parameter.Value.ToString()}\"");
        }

        sb.AppendLine(">");

        return new MarkupString(
             HttpUtility.HtmlEncode(sb.ToString())
        );
    }

    [Parameter]
    public ComponentMetaData? MetaData { get; set; }

    [Parameter]
    public Topic? Topic { get; set; }


}
