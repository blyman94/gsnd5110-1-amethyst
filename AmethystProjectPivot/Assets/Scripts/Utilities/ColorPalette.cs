using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds data for a color palette for easy copy/paste in the editor.
/// </summary>
[CreateAssetMenu]
public class ColorPalette : ScriptableObject
{
    [SerializeField] private List<Color> _colors;
}
