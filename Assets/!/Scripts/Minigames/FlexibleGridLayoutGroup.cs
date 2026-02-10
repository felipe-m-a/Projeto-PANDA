using UnityEngine;
using UnityEngine.UI;

namespace Panda.Minigames
{
    public class FlexibleGridLayoutGroup : LayoutGroup
    {
        [SerializeField] [Min(1)] private int _rows = 1;
        [SerializeField] [Min(1)] private int _columns = 1;

        public int rows
        {
            get => _rows;
            set
            {
                _rows = value;
                SetDirty();
            }
        }

        public int columns
        {
            get => _columns;
            set
            {
                _columns = value;
                SetDirty();
            }
        }

        public override void SetLayoutHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            var width = rectTransform.rect.width;
            var height = rectTransform.rect.height;

            var cellWidth = (width - padding.horizontal) / _columns;
            var cellHeight = (height - padding.vertical) / _rows;

            for (var i = 0; i < rectChildren.Count; i++)
            {
                var row = i / _columns;
                var column = i % _columns;

                var x = cellWidth * column + padding.left;
                var y = cellHeight * row + padding.top;
                // y = height - y - cellHeight; // Ajuste para colocar (0,0) no canto inferior esquerdo

                var child = rectChildren[i];
                SetChildAlongAxis(child, 0, x, cellWidth);
                SetChildAlongAxis(child, 1, y, cellHeight);
            }
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutVertical()
        {
        }
    }
}