using UIMatrixCalculator.Components;

namespace UIMatrixCalculator;

public partial class Calculator : Form
{
    private MatrixTextBoxes matrixA;
    private MatrixTextBoxes matrixB;
    private MatrixTextBoxes matrixC;

    public Calculator()
    {
        InitializeComponent();
        matrixA = new MatrixTextBoxes(0, new Point(100, 100));
        matrixB = new MatrixTextBoxes(0, new Point(150 + matrixA.Width, 100));
        matrixC = new MatrixTextBoxes(0, new Point((150 + matrixA.Width) / 2, matrixA.Height + 150));

        Controls.AddRange(matrixA.GetCells());
        Controls.AddRange(matrixB.GetCells());
        Controls.AddRange(matrixC.GetCells());
    }

    private void SetSizeClick(object sender, EventArgs e)
    {
        Remove(matrixA.GetCells());
        Remove(matrixB.GetCells());
        Remove(matrixC.GetCells());

        var size = int.Parse(SetSizeTestBox.Text.Trim());
        matrixA = new MatrixTextBoxes(size, new Point(100, 100));
        matrixB = new MatrixTextBoxes(size, new Point(150 + matrixA.Width, 100));
        matrixC = new MatrixTextBoxes(size, new Point((150 + matrixA.Width) / 2, matrixA.Height + 150));
        Controls.AddRange(matrixA.GetCells());
        Controls.AddRange(matrixB.GetCells());
        Controls.AddRange(matrixC.GetCells());
    }

    public void Remove(Control[] controls)
    {
        foreach (var control in controls)
        {
            Controls.Remove(control);
        }
    }
}