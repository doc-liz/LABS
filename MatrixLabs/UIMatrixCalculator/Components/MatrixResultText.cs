using System.Drawing.Drawing2D;
using MatrixLabs;

namespace UIMatrixCalculator.Components;

public class MatrixResultText
{
    private Label[,] Cells { get; }

    public Point Position { get; }
    public int Size { get; }
    public int Width => Size * (CellWidth + offset);
    public int Height => Size * (CellHeight + offset);
    private static int CellWidth = 50;
    private static int CellHeight = 25;
    private readonly int offset = 2;

    public MatrixResultText(int size, Point position)
    {
        Cells = new Label[size, size];
        Size = size;
        Position = position;
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var cell = new Label();
                cell.Size = new Size(CellWidth, CellHeight);
                cell.Location = new Point(
                    position.X + cell.Size.Width * i + offset,
                    position.Y + cell.Size.Height * j + offset
                );
                Cells[i, j] = cell;
            }
        }
    }

    public void SetMatrix(Matrix<Rational> matrix)
    {
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                Cells[i, j].Text = matrix[i, j].ToString();
            }
        }
    }
    public Control[] GetCells()
    {
        var list = new List<Label>();
        foreach (var cell in Cells)
        {
            list.Add(cell);
        }

        return list.ToArray();
    }
}