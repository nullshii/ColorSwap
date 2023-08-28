using UnityEngine;

namespace Code
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private ShapeColor _shapeColor;
        
        public Color Color => _shapeColor.Color;
    }
}