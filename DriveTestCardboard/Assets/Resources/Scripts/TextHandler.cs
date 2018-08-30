using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class TextHandler : MonoBehaviour
{
    TextMesh TheMesh;
    public string UnwrappedText;

    //Set how long a string can be
    public float MaxWidth;
    public bool NeedsLayout = true;
    public bool ConvertNewLines = false;

    void Start()
    {
        //Create a mesh
        TheMesh = GetComponent<TextMesh>();

        //If the box is ticked, convert chars to new lines
        if (ConvertNewLines)
            UnwrappedText = UnwrappedText.Replace("\\n", System.Environment.NewLine);
    }

    string BreakPartIfNeeded(string part)
    {
        string saveText = TheMesh.text;
        TheMesh.text = part;

        if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
        {
            string remaining = part;
            part = "";
            while (true)
            {
                int len;
                for (len = 2; len <= remaining.Length; len++)
                {
                    TheMesh.text = remaining.Substring(0, len);
                    if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
                    {
                        len--;
                        break;
                    }
                }
                if (len >= remaining.Length)
                {
                    part += remaining;
                    break;
                }
                part += remaining.Substring(0, len) + System.Environment.NewLine;
                remaining = remaining.Substring(len);
            }

            part = part.TrimEnd();
        }

        TheMesh.text = saveText;

        return part;
    }

    void Update()
    {
        UnwrappedText = gameObject.GetComponent<TextMesh>().text;

        //If no update is needed, return
        if (!NeedsLayout)
            return;

        NeedsLayout = false;
        if (MaxWidth == 0)
        {
            TheMesh.text = UnwrappedText;
            return;
        }
        string builder = "";
        string text = UnwrappedText;
        TheMesh.text = "";
        string[] parts = text.Split(' ');
        for (int i = 0; i < parts.Length; i++)
        {
            string part = BreakPartIfNeeded(parts[i]);
            TheMesh.text += part + " ";
            if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
            {
                TheMesh.text = builder.TrimEnd() + System.Environment.NewLine + part + " ";
            }
            builder = TheMesh.text;
        }
    }
}
