/*
 * How To Get A Better Grid Layout in Unity
 * https://www.youtube.com/gamedevguide
 */

using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FlexibleGridLayout: LayoutGroup
{
    [SerializeField] public int rows = 3;
    [SerializeField] public int columns = 7;
    [SerializeField] Vector2 cellSize;
    [SerializeField] Vector2 spacing;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;
        
        float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns) * (columns - 1)) - (padding.left / (float)columns) - (padding.right / (float)columns);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * (rows - 1)) - (padding.top / (float)rows) - (padding.bottom / (float)rows);
        
        cellSize.x = cellWidth;
        cellSize.y = cellHeight;
        
        int columnCount = 0;
        int rowCount = 0;
        
        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;
            
            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount);// + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount);// + padding.top;
            
            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }
    
    public override void CalculateLayoutInputVertical()
    {
        //throw new System.NotImplementedException();
    }
    
    public override void SetLayoutHorizontal()
    {
        //throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        //throw new System.NotImplementedException();
    }
}
