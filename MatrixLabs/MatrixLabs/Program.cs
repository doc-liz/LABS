using MatrixLabs;

var matrices = FileParser.CreateMatrixList<int>("Matrices.txt");
matrices.Print();
matrices.SwitchLastFirst();
Console.WriteLine("matrices.SwitchLastFirst()");
matrices.Print();

Console.ReadKey();
Console.WriteLine("matrices.SumAll()");
Console.WriteLine(matrices.SumAll());

Console.ReadKey();
Console.WriteLine("matrices.MultiplyAll()");
Console.WriteLine(matrices.MultiplyAll());
