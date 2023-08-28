using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class ShapeColor : MonoBehaviour
    {
        [field: SerializeField] public Color Color { get; private set; }
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private bool _randomize;

        private void Start()
        {
            SetColor(Color); // to fix visual color

            if (!_randomize) return;

            Array values = Enum.GetValues(typeof(Color));
            var randomColor = (Color)values.GetValue(Random.Range(1, values.Length));

            SetColor(randomColor);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ColorChanger colorChanger) == false) return;

            SetColor(colorChanger.Color);
            Destroy(colorChanger.gameObject);
        }

        private void SetColor(Color color)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = color switch
                {
                    Color.None => UnityEngine.Color.grey,
                    Color.Cyan => new UnityEngine.Color(0.2078431373f, 0.8862745098f, 0.9490196078f),
                    Color.Yellow => new UnityEngine.Color(0.9647058824f, 0.8745098039f, 0.0549019608f),
                    Color.Magenta => new UnityEngine.Color(0.5490196078f, 0.0745098039f, 0.9843137255f),
                    Color.Pink => new UnityEngine.Color(1f, 0f, 0.5019607843f),
                    Color.Wild => UnityEngine.Color.white,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            Color = color;
        }
    }
}