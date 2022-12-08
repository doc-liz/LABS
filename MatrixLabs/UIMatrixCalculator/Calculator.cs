using System.Drawing.Drawing2D;
using MatrixLabs;
using UIMatrixCalculator.Components;

namespace UIMatrixCalculator;

public partial class Calculator : Form
{
    private MatrixTextBoxes matrixA;
    private MatrixTextBoxes matrixB;
    private MatrixResultText matrixResult;

    public Calculator()
    {
        InitializeComponent();
        matrixA = new MatrixTextBoxes(0, new Point(0));
        matrixB = new MatrixTextBoxes(0, new Point(0));
        matrixResult = new MatrixResultText(0, new Point(0));
        AddPlusButton();
        AddMinusButton();
        AddMultiplyButton();
        AddNormButton();
        AddDetButton();
        AddRndButton();
    }

    private void AddPlusButton()
    {
        var plus = new Button();
        plus.Text = "+";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(200, 0);
        plus.Click += PlusClick;
        Controls.Add(plus);
    }

    private void AddMinusButton()
    {
        var plus = new Button();
        plus.Text = "-";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(250, 0);
        plus.Click += MinusClick;
        Controls.Add(plus);
    }

    private void AddMultiplyButton()
    {
        var plus = new Button();
        plus.Text = "*";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(300, 0);
        plus.Click += MultiplyClick;
        Controls.Add(plus);
    }

    private void AddNormButton()
    {
        var plus = new Button();
        plus.Text = "ToNorm";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(350, 0);
        plus.Click += NormClick;
        Controls.Add(plus);
    }

    private void NormClick(object? sender, EventArgs e)
    {
        Remove(matrixB.GetCells());
        var result = matrixA.CreateMatrix().ToNormMatrix();
        ResetResult(result);
    }

    private void DetClick(object? sender, EventArgs e)
    {
        Remove(matrixB.GetCells());
        var a = matrixA.CreateMatrix();
        var d = a.Determinant();
        var result = new Matrix<Rational>(1);
        result[0, 0] = d;
        ResetResult(result);
    }

    private void AddDetButton()
    {
        var plus = new Button();
        plus.Text = "Det";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(400, 0);
        plus.Click += DetClick;
        Controls.Add(plus);
    }

    private void AddRndButton()
    {
        var plus = new Button();
        plus.Text = "Rnd";
        plus.Size = new Size(49, 49);
        plus.Location = new Point(450, 0);
        plus.Click += RndClick;
        Controls.Add(plus);
    }

    private void RndClick(object? sender, EventArgs e)
    {
        var a = Matrix<Rational>.CreateRandom(CashSize);
        var b = Matrix<Rational>.CreateRandom(CashSize);
        matrixA.SetMatrix(a);
        matrixB.SetMatrix(b);
    }

    private void SetSizeClick(object sender, EventArgs e)
    {
        RemoveMatrix();
        AddMatrix();
    }

    private void PlusClick(object sender, EventArgs e)
    {
        var a = matrixA.CreateMatrix();
        var b = matrixB.CreateMatrix();
        var result = a + b;
        ResetResult(result);
    }

    private void MinusClick(object? sender, EventArgs e)
    {
        var a = matrixA.CreateMatrix();
        var b = matrixB.CreateMatrix();
        var result = a - b;
        ResetResult(result);
    }

    private void MultiplyClick(object? sender, EventArgs e)
    {
        var a = matrixA.CreateMatrix();
        var b = matrixB.CreateMatrix();
        var result = a * b;
        ResetResult(result);
    }

    public void ResetResult(Matrix<Rational> matrix)
    {
        Remove(matrixResult.GetCells());
        Controls.AddRange(matrixResult.GetCells());
        matrixResult.SetMatrix(matrix);
    }

    private void AddMatrix()
    {
        var size = int.Parse(SetSizeTestBox.Text.Trim());
        CashSize = size;
        matrixA = new MatrixTextBoxes(size, new Point(100, 100));
        matrixB = new MatrixTextBoxes(size, new Point(150 + matrixA.Width, 100));
        matrixResult = new MatrixResultText(size, new Point((150 + matrixA.Width) / 2, matrixA.Height + 150));
        Controls.AddRange(matrixA.GetCells());
        Controls.AddRange(matrixB.GetCells());
        Controls.AddRange(matrixResult.GetCells());
    }

    public int CashSize { get; set; }


    private void RemoveMatrix()
    {
        Remove(matrixA.GetCells());
        Remove(matrixB.GetCells());
        Remove(matrixResult.GetCells());
    }

    private void Remove(Control[] controls)
    {
        foreach (var control in controls)
        {
            Controls.Remove(control);
        }
    }
}