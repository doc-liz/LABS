using System.Drawing.Drawing2D;
using System.Numerics;
using MatrixLabs;
using UIMatrixCalculator.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIMatrixCalculator;

public partial class Calculator : Form
{
    private MatrixTextBoxes matrixA;  
    private MatrixTextBoxes matrixB;
    private MatrixResultText matrixResult;
    private string type;
    public Calculator()
    {
        InitializeComponent();
        matrixA = new MatrixTextBoxes(0, new Point(0));
        matrixB = new MatrixTextBoxes(0, new Point(0));
        matrixResult = new MatrixResultText(0, new Point(0));
        AddPlusButton();
        AddMinusButton();
        AddMultiplyButton();
        //AddNormButton();
        //AddDetButton();
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
        type = comboBox1.Text;
        RemoveMatrix();
        AddMatrix();
    }

    private void PlusClick(object sender, EventArgs e)
    {
        switch (type)
        {
            case "int":
                ResetResult( matrixA.CreateMatrix<int>() + matrixB.CreateMatrix<int>());
                break;
            case "float":
                ResetResult(matrixA.CreateMatrix<float>() + matrixB.CreateMatrix<float>());
                break;
            case "double":
                ResetResult(matrixA.CreateMatrix<double>() + matrixB.CreateMatrix<double>());
                break;
            case "rational":
                ResetResult(matrixA.CreateMatrix<Rational>() + matrixB.CreateMatrix<Rational>());
                break;
            default:
                ResetResult(matrixA.CreateMatrix<int>() + matrixB.CreateMatrix<int>());
                break;
        }
        
        
    }

    private void MinusClick(object? sender, EventArgs e)
    {
        switch (type)
        {
            case "int":
                ResetResult(matrixA.CreateMatrix<int>() - matrixB.CreateMatrix<int>());
                break;
            case "float":
                ResetResult(matrixA.CreateMatrix<float>() - matrixB.CreateMatrix<float>());
                break;
            case "double":
                ResetResult(matrixA.CreateMatrix<double>() - matrixB.CreateMatrix<double>());
                break;
            case "rational":
                ResetResult(matrixA.CreateMatrix<Rational>() - matrixB.CreateMatrix<Rational>());
                break;
            default:
                ResetResult(matrixA.CreateMatrix<int>() - matrixB.CreateMatrix<int>());
                break;
        }
    }

    private void MultiplyClick(object? sender, EventArgs e)
    {
        switch (type)
        {
            case "int":
                ResetResult(matrixA.CreateMatrix<int>() * matrixB.CreateMatrix<int>());
                break;
            case "float":
                ResetResult(matrixA.CreateMatrix<float>() * matrixB.CreateMatrix<float>());
                break;
            case "double":
                ResetResult(matrixA.CreateMatrix<double>() * matrixB.CreateMatrix<double>());
                break;
            case "rational":
                ResetResult(matrixA.CreateMatrix<Rational>() * matrixB.CreateMatrix<Rational>());
                break;
            default:
                ResetResult(matrixA.CreateMatrix<int>() * matrixB.CreateMatrix<int>());
                break;
        }
    }

    public void ResetResult<T>(Matrix<T> matrix) where T: INumber<T>
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