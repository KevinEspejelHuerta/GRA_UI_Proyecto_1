using System;
using System.Linq;

class Program
{
    private static int intents;

    static void Main()
    {
        Console.Title = "Localización de Vectores y Matrices";
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            DibujarMarco();
            MostrarMenuPrincipal();

            var opcion = LeerOpcion(1, 8);

            switch (opcion)
            {
                case 1: JuegoAhorcado(); break;
                case 2: ContarPositivosNegativosCeros(); break;
                case 3: TransponerMatriz(); break;
                case 4: MayorYMenorMatriz(); break;
                case 5: SumaParesImpares(); break;
                case 6: SumaFilasColumnas3x3(); break;
                case 7: MultiplicarMatrices(); break;
                case 8: CalcularDesviacionEstandar(); break;
                case 0: return;
            }
        }
    }

    static void DibujarMarco()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        Console.SetCursorPosition(0, 0);
        Console.Write("╔" + new string('═', width - 2) + "╗");

        for (int i = 1; i < height - 1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("║");
            Console.SetCursorPosition(width - 1, i);
            Console.Write("║");
        }

        Console.SetCursorPosition(0, height - 1);
        Console.Write("╚" + new string('═', width - 2) + "╝");
        Console.ResetColor();
    }

    static void MostrarMenuPrincipal()
    {
        Console.SetCursorPosition(10, 5);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Menú. Localización de vectores y matrices");
        Console.ResetColor();

        Console.SetCursorPosition(10, 7);
        Console.WriteLine("1. Juego del ahorcado para cualquier palabra");

        Console.SetCursorPosition(10, 8);
        Console.WriteLine("2. Contar positivos, negativos y ceros en matriz");

        Console.SetCursorPosition(10, 9);
        Console.WriteLine("3. Transposición de matriz");

        Console.SetCursorPosition(10, 10);
        Console.WriteLine("4. Mayor y menor número en matriz");

        Console.SetCursorPosition(10, 11);
        Console.WriteLine("5. Suma de pares e impares en matriz");

        Console.SetCursorPosition(10, 12);
        Console.WriteLine("6. Suma de filas y columnas (3x3)");

        Console.SetCursorPosition(10, 13);
        Console.WriteLine("7. Multiplicación de 2 matrices");

        Console.SetCursorPosition(10, 14);
        Console.WriteLine("8. Calcular desviación estándar");

        Console.SetCursorPosition(10, 16);
        Console.WriteLine("0. Salir");

        Console.SetCursorPosition(10, 18);
        Console.Write("Seleccione una opción: ");
    }

    static int LeerOpcion(int min, int max)
    {
        int opcion;
        while (true)
        {
            Console.SetCursorPosition(31, 18);
            Console.Write(new string(' ', 10));
            Console.SetCursorPosition(31, 18);

            if (int.TryParse(Console.ReadLine(), out opcion) && (opcion >= min && opcion <= max || opcion == 0))
                return opcion;

            Console.SetCursorPosition(10, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Opción inválida. Intente nuevamente.");
            Console.ResetColor();
            Console.ReadKey();
            Console.SetCursorPosition(10, 19);
            Console.Write(new string(' ', 40));
        }
    }

    static void MostrarSubMenu()
    {
        Console.SetCursorPosition(10, Console.WindowHeight - 4);
        Console.WriteLine("1. Menú anterior");
        Console.SetCursorPosition(10, Console.WindowHeight - 3);
        Console.WriteLine("2. Continuar");
        Console.SetCursorPosition(10, Console.WindowHeight - 2);
        Console.WriteLine("0. Salir");
        Console.SetCursorPosition(10, Console.WindowHeight - 1);
        Console.Write("Seleccione una opción: ");
    }

    static int LeerSubOpcion()
    {
        int opcion;
        while (true)
        {
            Console.SetCursorPosition(31, Console.WindowHeight - 1);
            Console.Write(new string(' ', 10));
            Console.SetCursorPosition(31, Console.WindowHeight - 1);

            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 0 && opcion <= 2)
                return opcion;

            Console.SetCursorPosition(10, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Opción inválida. Intente nuevamente.");
            Console.ResetColor();
            Console.ReadKey();
            Console.SetCursorPosition(10, Console.WindowHeight);
            Console.Write(new string(' ', 40));
        }
    }

    static void JuegoAhorcado()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Juego del Ahorcado");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese la palabra a adivinar: ");
            string palabra = Console.ReadLine().ToUpper();

            if (string.IsNullOrWhiteSpace(palabra))
            {
                Console.SetCursorPosition(10, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La palabra no puede estar vacía.");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

            char[] letrasAdivinadas = new char[palabra.Length];
            for (int i = 0; i < letrasAdivinadas.Length; i++)
                letrasAdivinadas[i] = '_';

            int intentos = 6;
            bool palabraCompleta = false;

            while (intentos > 0 && !palabraCompleta)
            {
                Console.Clear();
                DibujarMarco();
                DibujarAhorcado(intentos);

                Console.SetCursorPosition(10, 5);
                Console.WriteLine("Juego del Ahorcado");

                Console.SetCursorPosition(10, 7);
                Console.WriteLine("Palabra: " + string.Join(" ", letrasAdivinadas));

                Console.SetCursorPosition(10, 9);
                Console.WriteLine("Intentos restantes: " + intentos);

                Console.SetCursorPosition(10, 11);
                Console.Write("Ingrese una letra: ");
                char letra = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

                bool letraAdivinada = false;
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == letra)
                    {
                        letrasAdivinadas[i] = letra;
                        letraAdivinada = true;
                    }
                }

                if (!letraAdivinada)
                    intentos--;

                palabraCompleta = !letrasAdivinadas.Contains('_');
            }

            Console.Clear();
            DibujarMarco();
            DibujarAhorcado(intentos);

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Juego del Ahorcado");

            Console.SetCursorPosition(10, 7);
            if (palabraCompleta)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Felicidades! Has adivinado la palabra: " + palabra);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Oh no! La palabra era: " + palabra);
            }
            Console.ResetColor();

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void DibujarAhorcado(int intentos)
    {
        Console.SetCursorPosition(60, 5);
        Console.WriteLine("  _______");

        Console.SetCursorPosition(60, 6);
        Console.WriteLine("  |     |");

        Console.SetCursorPosition(60, 7);
        Console.WriteLine("  |     " + (intentos < 6 ? "O" : ""));

        Console.SetCursorPosition(60, 8);
        Console.WriteLine("  |    " + (intents < 4 ? "/" : " ") + (intents < 5 ? "|" : "") + (intents < 3 ? "\\" : ""));

        Console.SetCursorPosition(60, 9);
        Console.WriteLine("  |    " + (intents < 2 ? "/" : " ") + " " + (intents < 1 ? "\\" : ""));

        Console.SetCursorPosition(60, 10);
        Console.WriteLine("__|__");
    }

    static void ContarPositivosNegativosCeros()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Contar positivos, negativos y ceros en matriz");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese número de filas (m): ");
            int m = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 8);
            Console.Write("Ingrese número de columnas (n): ");
            int n = LeerEnteroPositivo();

            double[,] matriz = new double[m, n];

            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Ingrese los elementos de la matriz:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 11 + i);
                    Console.Write($"Fila {i + 1}, Columna {j + 1}: ");
                    matriz[i, j] = LeerNumero();
                }
            }

            int positivos = 0, negativos = 0, ceros = 0;

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz ingresada:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);

                    if (matriz[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        positivos++;
                    }
                    else if (matriz[i, j] < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        negativos++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        ceros++;
                    }

                    Console.Write(matriz[i, j].ToString("0.##").PadLeft(6));
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(10, 7 + m * 2 + 1);
            Console.WriteLine($"Positivos: {positivos}");

            Console.SetCursorPosition(10, 7 + m * 2 + 2);
            Console.WriteLine($"Negativos: {negativos}");

            Console.SetCursorPosition(10, 7 + m * 2 + 3);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Ceros: {ceros}");
            Console.ResetColor();

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void TransponerMatriz()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Transposición de Matriz");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese número de filas (m): ");
            int m = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 8);
            Console.Write("Ingrese número de columnas (n): ");
            int n = LeerEnteroPositivo();

            double[,] matriz = new double[m, n];

            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Ingrese los elementos de la matriz:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 11 + i);
                    Console.Write($"Fila {i + 1}, Columna {j + 1}: ");
                    matriz[i, j] = LeerNumero();
                }
            }

            double[,] transpuesta = new double[n, m];

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    transpuesta[j, i] = matriz[i, j];

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz original:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);
                    Console.Write(matriz[i, j].ToString("0.##").PadLeft(6));
                }
            }

            Console.SetCursorPosition(40, 5);
            Console.WriteLine("Matriz transpuesta:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.SetCursorPosition(45 + j * 8, 7 + i * 2);
                    Console.Write(transpuesta[i, j].ToString("0.##").PadLeft(6));
                }
            }

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void MayorYMenorMatriz()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mayor y menor número en matriz");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese número de filas (m): ");
            int m = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 8);
            Console.Write("Ingrese número de columnas (n): ");
            int n = LeerEnteroPositivo();

            double[,] matriz = new double[m, n];

            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Ingrese los elementos de la matriz:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 11 + i);
                    Console.Write($"Fila {i + 1}, Columna {j + 1}: ");
                    matriz[i, j] = LeerNumero();
                }
            }

            double mayor = matriz[0, 0], menor = matriz[0, 0];
            int filaMayor = 0, colMayor = 0, filaMenor = 0, colMenor = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matriz[i, j] > mayor)
                    {
                        mayor = matriz[i, j];
                        filaMayor = i;
                        colMayor = j;
                    }

                    if (matriz[i, j] < menor)
                    {
                        menor = matriz[i, j];
                        filaMenor = i;
                        colMenor = j;
                    }
                }
            }

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz ingresada:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);

                    if (i == filaMayor && j == colMayor)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (i == filaMenor && j == colMenor)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(matriz[i, j].ToString("0.##").PadLeft(6));
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(10, 7 + m * 2 + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mayor número: {mayor} (Fila {filaMayor + 1}, Columna {colMayor + 1})");

            Console.SetCursorPosition(10, 7 + m * 2 + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Menor número: {menor} (Fila {filaMenor + 1}, Columna {colMenor + 1})");
            Console.ResetColor();

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void SumaParesImpares()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Suma de pares e impares en matriz");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese número de filas (m): ");
            int m = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 8);
            Console.Write("Ingrese número de columnas (n): ");
            int n = LeerEnteroPositivo();

            int[,] matriz = new int[m, n];

            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Ingrese los elementos de la matriz (enteros):");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 11 + i);
                    Console.Write($"Fila {i + 1}, Columna {j + 1}: ");
                    matriz[i, j] = LeerEntero();
                }
            }

            int sumaPares = 0, sumaImpares = 0, cantPares = 0, cantImpares = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matriz[i, j] % 2 == 0)
                    {
                        sumaPares += matriz[i, j];
                        cantPares++;
                    }
                    else
                    {
                        sumaImpares += matriz[i, j];
                        cantImpares++;
                    }
                }
            }

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz ingresada:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);
                    Console.Write(matriz[i, j].ToString().PadLeft(6));
                }
            }

            Console.SetCursorPosition(10, 7 + m * 2 + 1);
            Console.WriteLine($"Suma de pares: {sumaPares}");

            Console.SetCursorPosition(10, 7 + m * 2 + 2);
            Console.WriteLine($"Suma de impares: {sumaImpares}");

            Console.SetCursorPosition(10, 7 + m * 2 + 3);
            Console.WriteLine($"Cantidad de pares: {cantPares}");

            Console.SetCursorPosition(10, 7 + m * 2 + 4);
            Console.WriteLine($"Cantidad de impares: {cantImpares}");

            Console.SetCursorPosition(10, 7 + m * 2 + 5);
            Console.WriteLine($"Promedio de pares: {(cantPares > 0 ? (double)sumaPares / cantPares : 0):0.##}");

            Console.SetCursorPosition(10, 7 + m * 2 + 6);
            Console.WriteLine($"Promedio de impares: {(cantImpares > 0 ? (double)sumaImpares / cantImpares : 0):0.##}");

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void SumaFilasColumnas3x3()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Suma de filas y columnas (matriz 3x3)");
            Console.ResetColor();

            int m = 3, n = 3;
            double[,] matriz = new double[m, n];

            Console.SetCursorPosition(10, 7);
            Console.WriteLine("Ingrese los elementos de la matriz 3x3:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 8 + i);
                    Console.Write($"Fila {i + 1}, Columna {j + 1}: ");
                    matriz[i, j] = LeerNumero();
                }
            }

            double[] sumaFilas = new double[m];
            double[] sumaColumnas = new double[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sumaFilas[i] += matriz[i, j];
                    sumaColumnas[j] += matriz[i, j];
                }
            }

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz ingresada y sumas:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);
                    Console.Write(matriz[i, j].ToString("0.##").PadLeft(6));
                }

                Console.SetCursorPosition(15 + n * 8 + 5, 7 + i * 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"F{i + 1} = {sumaFilas[i]:0.##}");
                Console.ResetColor();
            }

            for (int j = 0; j < n; j++)
            {
                Console.SetCursorPosition(15 + j * 8, 7 + m * 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"C{j + 1} = {sumaColumnas[j]:0.##}");
                Console.ResetColor();
            }

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void MultiplicarMatrices()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Multiplicación de matrices");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese filas de matriz A (m): ");
            int m = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 8);
            Console.Write("Ingrese columnas de matriz A (n): ");
            int n = LeerEnteroPositivo();

            Console.SetCursorPosition(10, 9);
            Console.Write("Ingrese columnas de matriz B (p): ");
            int p = LeerEnteroPositivo();

            double[,] A = new double[m, n];
            double[,] B = new double[n, p];

            Console.SetCursorPosition(10, 11);
            Console.WriteLine("Ingrese elementos de matriz A:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(10, 12 + i);
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    A[i, j] = LeerNumero();
                }
            }

            Console.SetCursorPosition(10, 12 + m + 1);
            Console.WriteLine("Ingrese elementos de matriz B:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Console.SetCursorPosition(10, 12 + m + 2 + i);
                    Console.Write($"B[{i + 1},{j + 1}]: ");
                    B[i, j] = LeerNumero();
                }
            }

            double[,] C = new double[m, p];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Matriz A:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + i * 2);
                    Console.Write(A[i, j].ToString("0.##").PadLeft(6));
                }
            }

            Console.SetCursorPosition(40, 5);
            Console.WriteLine("Matriz B:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Console.SetCursorPosition(45 + j * 8, 7 + i * 2);
                    Console.Write(B[i, j].ToString("0.##").PadLeft(6));
                }
            }

            Console.SetCursorPosition(10, 7 + Math.Max(m, n) * 2 + 2);
            Console.WriteLine("Matriz resultante C = A x B:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    Console.SetCursorPosition(15 + j * 8, 7 + Math.Max(m, n) * 2 + 4 + i * 2);
                    Console.Write(C[i, j].ToString("0.##").PadLeft(6));
                }
            }

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static void CalcularDesviacionEstandar()
    {
        while (true)
        {
            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cálculo de Desviación Estándar");
            Console.ResetColor();

            Console.SetCursorPosition(10, 7);
            Console.Write("Ingrese número de elementos (n): ");
            int n = LeerEnteroPositivo();

            double[] datos = new double[n];
            double suma = 0;

            Console.SetCursorPosition(10, 9);
            Console.WriteLine("Ingrese los datos:");

            for (int i = 0; i < n; i++)
            {
                Console.SetCursorPosition(10, 10 + i);
                Console.Write($"Dato {i + 1}: ");
                datos[i] = LeerNumero();
                suma += datos[i];
            }

            double media = suma / n;
            double sumaDiferencias = 0;

            for (int i = 0; i < n; i++)
            {
                sumaDiferencias += Math.Pow(datos[i] - media, 2);
            }

            double desviacion = Math.Sqrt(sumaDiferencias / n);

            Console.Clear();
            DibujarMarco();

            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Datos ingresados:");

            for (int i = 0; i < n; i++)
            {
                Console.SetCursorPosition(15 + i % 5 * 12, 7 + i / 5 * 2);
                Console.Write(datos[i].ToString("0.##").PadLeft(10));
            }

            Console.SetCursorPosition(10, 7 + (n / 5 + 1) * 2 + 1);
            Console.WriteLine($"Media (μ): {media:0.##}");

            Console.SetCursorPosition(10, 7 + (n / 5 + 1) * 2 + 2);
            Console.WriteLine($"Desviación estándar (σ): {desviacion:0.##}");

            MostrarSubMenu();
            int opcion = LeerSubOpcion();

            if (opcion == 1) return;
            if (opcion == 0) Environment.Exit(0);
        }
    }

    static int LeerEnteroPositivo()
    {
        int numero;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out numero) && numero > 0)
                return numero;

            Console.SetCursorPosition(10, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Debe ingresar un entero positivo. Intente nuevamente: ");
            Console.ResetColor();
            Console.SetCursorPosition(10, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth - 20));
            Console.SetCursorPosition(10, Console.CursorTop);
        }
    }

    static int LeerEntero()
    {
        int numero;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out numero))
                return numero;

            Console.SetCursorPosition(10, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Debe ingresar un número entero. Intente nuevamente: ");
            Console.ResetColor();
            Console.SetCursorPosition(10, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth - 20));
            Console.SetCursorPosition(10, Console.CursorTop);
        }
    }

    static double LeerNumero()
    {
        double numero;
        while (true)
        {
            string input = Console.ReadLine();
            if (double.TryParse(input, out numero))
                return numero;

            Console.SetCursorPosition(10, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Debe ingresar un número válido. Intente nuevamente: ");
            Console.ResetColor();
            Console.SetCursorPosition(10, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth - 20));
            Console.SetCursorPosition(10, Console.CursorTop);
        }
    }
}