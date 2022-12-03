using MatrixLabs;

var matrices = FileParser.CreateMatrixList<Rational>("Matrices.txt");
matrices.SwitchLastFirst();
Console.WriteLine("matrices.SwitchLastFirst()");
matrices.Print();

Console.ReadKey();
Console.WriteLine("matrices.SumAll()");
Console.WriteLine(matrices.SumAll());

Console.ReadKey();
Console.WriteLine("matrices.MultiplyAll()");
Console.WriteLine(matrices.MultiplyAll());