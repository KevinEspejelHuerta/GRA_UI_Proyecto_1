using System;
using System.Net;
using System.Threading;

class Program
{
    static void Main()
    {
        int ancho = 50; 
        int alto = 20;  
        int espacio = 3; 

        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("--- Menú Principal ---");
            Console.WriteLine("1. Ejecutar método Espiral");
            Console.WriteLine("2. Ejecutar método Rectángulo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MetodoEspiral();
                    break;

                case "2":
                    MetodoRectangulo(ancho, alto, espacio);
                    break;

                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para intentarlo de nuevo...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void MetodoEspiral()
    {
        Console.SetCursorPosition(43, 0);
        Console.WriteLine("Has seleccionado el método Espiral.");
        Console.SetCursorPosition(45, 3);
        Console.WriteLine("Ejecutando lógica de Espiral...");
        int n = 21;
        char[,] matriz = new char[n, n];
        ConsoleColor[,] coloresMatriz = new ConsoleColor[n, n];


        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matriz[i, j] = ' ';


        int x = n / 2, y = n / 2;
        matriz[x, y] = '*';


        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        int dir = 0;

        int paso = 1;
        int cambioDireccion = 0;
        int color = 0;
        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow };

        while (true)
        {
            for (int i = 0; i < paso; i++)
            {
                x += dx[dir];
                y += dy[dir];


                if (x < 0 || y < 0 || x >= n || y >= n || matriz[x, y] == '*')
                    break;

                matriz[x, y] = '*';
                coloresMatriz[x, y] = colores[color];
                color = (color + 1) % colores.Length;

                ImprimirMatrizCentrada(matriz, coloresMatriz);
                Thread.Sleep(10);
            }


            dir = (dir + 1) % 4;
            cambioDireccion++;


            if (cambioDireccion % 2 == 0)
                paso += 2;


            int nx = x + dx[dir], ny = y + dy[dir];
            if (nx < 0 || ny < 0 || nx >= n || ny >= n || matriz[nx, ny] == '*')
                break;
        }
        Console.SetCursorPosition(0, 28);
        Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
        Console.ReadKey();
    }
    static void ImprimirMatrizCentrada(char[,] matriz, ConsoleColor[,] coloresMatriz)
    {
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        int startX = (consoleHeight / 2) - (matriz.GetLength(0) / 2);
        int startY = (consoleWidth / 2) - (matriz.GetLength(1));

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Console.SetCursorPosition(startY, startX + i);
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.ForegroundColor = coloresMatriz[i, j];
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

    static void MetodoRectangulo(int ancho, int alto, int espacio)
    {
        Console.SetCursorPosition(43, 0);
        Console.WriteLine("Has seleccionado el método Rectángulo.");
        Console.SetCursorPosition(45, 4);
        Console.WriteLine("Ejecutando lógica de Rectángulo...");
        
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        int centroX = consoleWidth / 2;
        int centroY = consoleHeight / 2;

        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Cyan };
        int colorIndex = 0;

        while (ancho > 0 && alto > 0)
        {
            Console.ForegroundColor = colores[colorIndex % colores.Length]; 
            DibujarRectangulo(centroX, centroY, ancho, alto);
            colorIndex++;

            ancho -= espacio * 2;
            alto -= espacio * 2;
        }

        Console.SetCursorPosition(0,28);
        Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
        Console.ReadKey();

        Console.ResetColor();
    }

    static void DibujarRectangulo(int centroX, int centroY, int ancho, int alto)
    {
        int inicioX = centroX - (ancho / 2);
        int inicioY = centroY - (alto / 2);

        
        for (int x = inicioX; x < inicioX + ancho; x++)
        {
            Console.SetCursorPosition(x, inicioY);
            Console.Write("*");
            Thread.Sleep(30); 
        }

        
        for (int y = inicioY; y < inicioY + alto; y++)
        {
            Console.SetCursorPosition(inicioX + ancho - 1, y);
            Console.Write("*");
            Thread.Sleep(30);
        }

        
        for (int x = inicioX + ancho - 1; x >= inicioX; x--)
        {
            Console.SetCursorPosition(x, inicioY + alto - 1);
            Console.Write("*");
            Thread.Sleep(30);
        }

        
        for (int y = inicioY + alto - 1; y >= inicioY; y--)
        {
            Console.SetCursorPosition(inicioX, y);
            Console.Write("*");
            Thread.Sleep(30);
        }

        Thread.Sleep(100); 
    }
}
