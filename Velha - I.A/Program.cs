using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velha___I.A
{
    class Program
    {
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
        public static char[] Vetor = new char[10]; // Vetor com as informações do jogo
        public static int[] Colors = new int[10];  // Com  as corres do jogo 
        public static int Game = 0, Vez = 1; // Determina de quem é a vez
        public static int A, B; // controle de telas
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
        public static int[] P1 = new int[3];
        public static int[] P2 = new int[3];
        public static int[] P3 = new int[3];
        public static int[] P4 = new int[3];
        public static int[] P5 = new int[3];
        public static int[] P6 = new int[3];
        public static int[] P7 = new int[3];
        public static int[] P8 = new int[3];
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
        public static int[] V1 = new int[3];
        public static int[] V2 = new int[3];
        public static int[] V3 = new int[3];
        public static int[] V4 = new int[3];
        public static int[] V5 = new int[3];
        public static int[] V6 = new int[3];
        public static int[] V7 = new int[3];
        public static int[] V8 = new int[3];
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
        public static int AI1 = 0, AI2 = 0, Empat = 0, Ngames;
        public static int TxT = 0;
        static void Main()
        {
            int W = 0, Op = 0;
            A = Console.WindowWidth;
            B = Console.WindowHeight;
            A = 60;
            Console.SetWindowSize(A, B);              // Controle do tamanho da janela
            Console.Title = "Jogo da Velha";          // Controle de Titulo
            Game = 0;
            Vez = 1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("          Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Jogar");
                Console.WriteLine(" 2 - Jogo Aleatorio\n 3 - Play1 - Ale vs  Play 2 - I.A.\n 4 - Analise do Jogo\n 5 - Jogo Vs I.A.\n 9 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Velha(); // To players
                        break;

                    case 2:
                        Aleatorio(); // Agente aleatorio
                        break;

                    case 3:
                        StartTest(); // Testes com angente Radom vs IA
                        break;

                    case 4:
                        Analise(); // Analises do jogo da velha
                        break;

                    case 5:
                        Vs_IA(); // I.A. 
                        break;

                    case 9:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //Jo
        public static void model() // Modelo
        {
            int W = 0, Op;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir\n 2 - Voltar\n 3 - Sair ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                Op = Convert.ToInt32(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        model();
                        break;

                    case 2:
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Velha()
        {
            int W = 0, Op = 0, Play = 0, Sort, i, Cont = 0;     // Game controla Fim de partida   
            Loading(); // Carrega os numeros inicialmente          // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
            }
            do
            {
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" Escolha sua jogada [Play 1]: ");
                        try // teste de entrada
                        {
                            Play = Convert.ToInt32(Console.ReadLine());
                            if (Play > 9 || Play < 1)
                            {
                                Main();
                            }
                        }
                        catch
                        {
                            Main();
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                        {
                            Vetor[(Play - 1)] = 'X';
                            Colors[(Play - 1)] = 1;
                            Vez = 2;
                        }
                        else
                        {
                            Vez = 1;  // Caso o usuario não possa mais fazer e tente
                        }
                    }
                    else
                    {
                        if (Vez == 2) // Vez do Play 2
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Escolha sua jogada [Play 2]: ");
                            try // teste de entrada
                            {
                                Play = Convert.ToInt32(Console.ReadLine());
                                if (Play > 9 || Play < 1)
                                {
                                    Main();
                                }
                            }
                            catch
                            {
                                Main();
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                            {
                                Vetor[(Play - 1)] = 'O';
                                Colors[(Play - 1)] = 2;
                                Vez = 1;
                            }
                            else
                            {
                                Vez = 2; // Caso o usuario não possa mais fazer e tente 
                            }
                        }
                    }
                    Game = AnalisarPartida();
                    if ((Game == 0) && (Cont == 9))
                    {
                        Cont = 0;
                        Vez = 3;
                        Game = 1;
                    }
                } while (Game == 0);
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Play 2 Vence a Partida ");
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Play 1 Vence a Partida ");
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Voltar\n 2 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Main();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Aleatorio()
        {
            int W = 0, W1 = 0, Op = 0, Val = 0, Play = 0, Sort, i, Cont = 0, ContBanc = 0, F;     // Game controla Fim de partida   
            int[] Banco = new int[10];
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
                Banco[i] = -1;
            }
            do
            {
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try // teste de entrada
                        {
                            do
                            {
                                Play = Rnd.Next(1, 10);
                                for (i = 0; i < 10; i++)
                                {
                                    if (Banco[i] == Play)
                                    {
                                        Val = 1;
                                    }
                                }
                                if (Val == 1)
                                {
                                    W1 = 0;
                                    Val = 0;
                                }
                                else
                                {
                                    W1 = 1;
                                    Banco[ContBanc] = Play;
                                    ContBanc = ContBanc + 1;
                                }
                            } while (W1 == 0);
                            W1 = 0;
                            Val = 0;
                            if (Play > 9 || Play < 1)
                            {
                                Vez = 1;
                            }
                            Console.Write(" Jogada [IA 1]: " + Play);
                        }
                        catch
                        {
                            Vez = 1;
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                        {
                            Vetor[(Play - 1)] = 'X';
                            Colors[(Play - 1)] = 1;
                            Vez = 2;
                        }
                        else
                        {
                            Vez = 1;  // Caso o usuario não possa mais fazer e tente
                            Cont = Cont - 1;
                        }
                    }
                    else
                    {
                        if (Vez == 2) // Vez do Play 2
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            try // teste de entrada
                            {
                                do
                                {
                                    Play = Rnd.Next(1, 10);
                                    if (Play == -1)
                                    {
                                        Play = Rnd.Next(1, 10);
                                    }
                                    for (i = 0; i < 10; i++)
                                    {
                                        if (Banco[i] == Play)
                                        {
                                            Val = 1;
                                        }
                                    }
                                    if (Val == 1)
                                    {
                                        W1 = 0;
                                        Val = 0;
                                    }
                                    else
                                    {
                                        W1 = 1;
                                        Banco[ContBanc] = Play;
                                        ContBanc = ContBanc + 1;
                                    }

                                } while (W1 == 0);
                                W1 = 0;
                                Val = 0;
                                if (Play > 9 || Play < 1)
                                {
                                    Vez = 2;
                                }
                                Console.Write(" Jogada [IA 2]: " + Play);
                            }
                            catch
                            {
                                Vez = 2;
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                            {
                                Vetor[(Play - 1)] = 'O';
                                Colors[(Play - 1)] = 2;
                                Vez = 1;
                            }
                            else
                            {
                                Vez = 2; // Caso o usuario não possa mais fazer e tente 
                                Cont = Cont - 1;
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" Loading...  ");
                    for (i = 0; i < 505550000; i++)
                    {
                        F = i * 2;
                    }
                    F = 0;
                    Game = AnalisarPartida();
                    if ((Game == 0) && (Cont == 9))
                    {
                        Cont = 0;
                        Vez = 3;
                        Game = 1;
                    }
                } while (Game == 0);
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" IA 2 Vence a Partida ");
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" IA 1 Vence a Partida ");
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Voltar\n 2 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Main();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void StartTest()
        {
            int Op = 0, W = 0, Qtd = 0, i;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha - Estatiscas");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Digite a Qtd de Jogos: ");
                try
                {
                    Qtd = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    StartTest();
                }
                for (i = 0; i < Qtd; i++)
                {
                    Estatisticas();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" AI 1 : " + AI1);
                Console.WriteLine(" AI 2 : " + AI2);
                Console.WriteLine(" Empt : " + Empat);
                Console.WriteLine(" N    : " + Ngames);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir \n 2 - Voltar \n 3 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    StartTest();
                }
                switch (Op)
                {
                    case 1:
                        W = 0;
                        break;

                    case 2:
                        Empat = 0;
                        AI1 = 0;
                        AI2 = 0;
                        Ngames = 0;
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }

            } while (W == 0);

        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Estatisticas()
        {
            int W1 = 0, Val = 0, Play = 0, Sort, i, Cont = 0, ContBanc = 0, F;     // Game controla Fim de partida   
            int[] Banco = new int[10];
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            else
            {
                Vez = 1;
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
                Banco[i] = -1;
            }
            do
            {
                Tela();
                Cont = Cont + 1;
                if (Vez == 1) // Vez do Play 1
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    try // teste de entrada
                    {
                        do
                        {
                            Play = Rnd.Next(1, 10);
                            for (i = 0; i < 10; i++)
                            {
                                if (Banco[i] == Play)
                                {
                                    Val = 1;
                                }
                            }
                            if (Val == 1)
                            {
                                W1 = 0;
                                Val = 0;
                            }
                            else
                            {
                                W1 = 1;
                                Banco[ContBanc] = Play;
                                ContBanc = ContBanc + 1;
                            }
                        } while (W1 == 0);
                        W1 = 0;
                        Val = 0;
                        if (Play > 9 || Play < 1)
                        {
                            Vez = 1;
                        }
                        Console.Write(" Jogada [IA 1]: " + Play);
                    }
                    catch
                    {
                        Vez = 1;
                    }
                    if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                    {
                        Vetor[(Play - 1)] = 'X';
                        Colors[(Play - 1)] = 1;
                        Vez = 2;
                    }
                    else
                    {
                        Vez = 1;  // Caso o usuario não possa mais fazer e tente
                        Cont = Cont - 1;
                    }
                }
                else
                {
                    if (Vez == 2) // Vez do Play 2
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        try // teste de entrada
                        {
                            do
                            {
                                Play = Lance_IA(2);
                                if (TxT == 1)
                                {
                                    Console.WriteLine(" P: " + Play);
                                    Console.ReadKey();
                                }                               
                                if (Play == -1 || Play == 0)
                                {
                                    Play = Rnd.Next(1, 10);
                                }
                                for (i = 0; i < 10; i++)
                                {
                                    if (Banco[i] == Play)
                                    {
                                        Val = 1;
                                    }
                                }
                                if (Val == 1)
                                {
                                    W1 = 0;
                                    Val = 0;
                                }
                                else
                                {
                                    W1 = 1;
                                    Banco[ContBanc] = Play;
                                    ContBanc = ContBanc + 1;
                                }

                            } while (W1 == 0);
                            W1 = 0;
                            Val = 0;
                            if (Play > 9 || Play < 1)
                            {
                                Vez = 2;
                            }
                            Console.Write(" Jogada [IA 2]: " + Play);
                        }
                        catch
                        {
                            Vez = 2;
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                        {
                            Vetor[(Play - 1)] = 'O';
                            Colors[(Play - 1)] = 2;
                            Vez = 1;
                        }
                        else
                        {
                            Vez = 2; // Caso o usuario não possa mais fazer e tente 
                            Cont = Cont - 1;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n --------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" AI 1 : " + AI1);
                Console.WriteLine(" AI 2 : " + AI2);
                Console.WriteLine(" Empt : " + Empat);
                Console.WriteLine(" N    : " + Ngames);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Loading...  ");
                for (i = 0; i < 5055500; i++)
                {
                    F = i * 2;
                }
                F = 0;
                Game = AnalisarPartida();
                if ((Game == 0) && (Cont == 9))
                {
                    Cont = 0;
                    Vez = 3;
                    Game = 1;
                }
            } while (Game == 0);
            Game = 0;
            Tela();
            if (Vez == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" IA 2 Vence a Partida ");
                AI2 = AI2 + 1;
            }
            else
            {
                if (Vez == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" IA 1 Vence a Partida ");
                    AI1 = AI1 + 1;
                }
                else
                {
                    if (Vez == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(" Empate Jogo em Velha ");
                        Empat = Empat + 1;
                    }
                }
            }
            Ngames = Ngames + 1;
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Vs_IA()
        {
            int W = 0, W1 = 0, Op = 0, Val = 0, Play = 0, Sort, i, Cont = 0, ContBanc = 0, J = 0;     // Game controla Fim de partida   
            int[] Banco = new int[10];
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
                Banco[i] = -1;
            }
            do
            {
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try // teste de entrada
                        {
                            do
                            {
                                Console.Write(" Jogador [1]: ");
                                Play = Convert.ToInt32(Console.ReadLine());
                                J = 1;
                                for (i = 0; i < 10; i++)
                                {
                                    if (Banco[i] == Play)
                                    {
                                        Val = 1;
                                    }
                                }
                                if (Val == 1)
                                {
                                    W1 = 0;
                                    Val = 0;
                                }
                                else
                                {
                                    W1 = 1;
                                    Banco[ContBanc] = Play;
                                    ContBanc = ContBanc + 1;
                                }
                            } while (W1 == 0);
                            W1 = 0;
                            Val = 0;
                            if (Play > 9 || Play < 1)
                            {
                                Vez = 1;
                            }
                        }
                        catch
                        {
                            Vez = 1;
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                        {
                            Vetor[(Play - 1)] = 'X';
                            Colors[(Play - 1)] = 1;
                            Vez = 2;
                        }
                        else
                        {
                            Vez = 1;  // Caso o usuario não possa mais fazer e tente
                            Cont = Cont - 1;
                        }
                    }
                    else
                    {
                        if (Vez == 2) // Vez do Play 2
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            try // teste de entrada
                            {
                                do
                                {
                                    Play = Lance_IA(2);
                                    J = 2;
                                    if (TxT == 1)
                                    {
                                        Console.WriteLine(" P.L.: " + Play);
                                        Console.ReadKey();
                                    }                                    
                                    for (i = 0; i < 10; i++)
                                    {
                                        if (Banco[i] == Play)
                                        {
                                            Val = 1;
                                        }
                                    }
                                    if (Val == 1)
                                    {
                                        W1 = 0;
                                        Val = 0;
                                    }
                                    else
                                    {
                                        W1 = 1;
                                        Banco[ContBanc] = Play;
                                        ContBanc = ContBanc + 1;
                                    }

                                } while (W1 == 0);
                                W1 = 0;
                                Val = 0;
                                if (Play > 9 || Play < 1)
                                {
                                    Vez = 2;
                                }
                                Console.Write(" Jogador [I.A.]: " + Play);
                            }
                            catch
                            {
                                Vez = 2;
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                            {
                                Vetor[(Play - 1)] = 'O';
                                Colors[(Play - 1)] = 2;
                                Vez = 1;
                            }
                            else
                            {
                                Vez = 2; // Caso o usuario não possa mais fazer e tente 
                                Cont = Cont - 1;
                            }
                        }
                    }
                    if (J == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n --------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" Loading...  ");
                        System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(3000));
                    }                 
                    Game = AnalisarPartida();
                    if ((Game == 0) && (Cont == 9))
                    {
                        Cont = 0;
                        Vez = 3;
                        Game = 1;
                    }
                } while (Game == 0);
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" IA 2 Vence a Partida ");
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" IA 1 Vence a Partida ");
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Voltar\n 2 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Main();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Analise() // Modelo
        {
            int W = 0, Op, i, j, cont = 10, Total = 0, Mult = 1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (i = 0; i < 10; i++)
                {
                    cont = cont - 1;
                    for (j = cont; j > 1; j--)
                    {
                        Mult = Mult * j;
                        Console.WriteLine(" Cont: " + cont + " e total: " + Total + " Mult: " + Mult);
                    }
                    Console.WriteLine(" Fatorial: " + Mult);
                    Total = Total + Mult;
                    Mult = 1;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Resultado: " + Total);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir\n 2 - Voltar\n 3 - Sair ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                Op = Convert.ToInt32(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        Analise();
                        break;

                    case 2:
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Tela() // Atualiza a tela do jogo
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" --------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("          Jogo da Velha");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" --------------------------------\n");

            Console.WriteLine("   -------------------------");
            Console.Write("   |   ");
            if (Colors[0] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[0] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[0] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[0]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[1] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[1] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[1] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[1]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[2] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[2] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[2] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[2]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |\n");
            Console.WriteLine("   -------------------------");
            Console.Write("   |   ");
            if (Colors[3] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[3] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[3] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[3]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[4] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[4] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[4] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[4]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[5] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[5] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[5] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[5]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |\n");
            Console.WriteLine("   -------------------------");
            Console.Write("   |   ");
            if (Colors[6] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[6] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[6] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[6]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[7] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[7] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[7] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[7]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |   ");
            if (Colors[8] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                if (Colors[8] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    if (Colors[8] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
            Console.Write("" + Vetor[8]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   |\n");
            Console.WriteLine("   -------------------------");

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" --------------------------------");
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Loading() // Carrega o vetor
        {
            Vetor[0] = '1';
            Vetor[1] = '2';
            Vetor[2] = '3';
            Vetor[3] = '4';
            Vetor[4] = '5';
            Vetor[5] = '6';
            Vetor[6] = '7';
            Vetor[7] = '8';
            Vetor[8] = '9';
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static int AnalisarPartida() // Analisa os casos onde aconteceram vitorias e muda o jogo pra ganho
        {
            if ((Vetor[0] == 'O' && Vetor[1] == 'O' && Vetor[2] == 'O') ||
                (Vetor[0] == 'X' && Vetor[1] == 'X' && Vetor[2] == 'X'))
            {
                Game = 1;
            }
            else
            {
                if ((Vetor[3] == 'O' && Vetor[4] == 'O' && Vetor[5] == 'O') ||
                   (Vetor[3] == 'X' && Vetor[4] == 'X' && Vetor[5] == 'X'))
                {
                    Game = 1;
                }
                else
                {
                    if ((Vetor[6] == 'O' && Vetor[7] == 'O' && Vetor[8] == 'O') ||
                       (Vetor[6] == 'X' && Vetor[7] == 'X' && Vetor[8] == 'X'))
                    {
                        Game = 1;
                    }
                    else
                    {
                        if ((Vetor[0] == 'O' && Vetor[3] == 'O' && Vetor[6] == 'O') ||
                           (Vetor[0] == 'X' && Vetor[3] == 'X' && Vetor[6] == 'X'))
                        {
                            Game = 1;
                        }
                        else
                        {
                            if (((Vetor[1] == 'O' && Vetor[4] == 'O' && Vetor[7] == 'O') ||
                               (Vetor[1] == 'X' && Vetor[4] == 'X' && Vetor[7] == 'X')))
                            {
                                Game = 1;
                            }
                            else
                            {
                                if ((Vetor[2] == 'O' && Vetor[5] == 'O' && Vetor[8] == 'O') ||
                                    (Vetor[2] == 'X' && Vetor[5] == 'X' && Vetor[8] == 'X'))
                                {
                                    Game = 1;
                                }
                                else
                                {
                                    if ((Vetor[0] == 'O' && Vetor[4] == 'O' && Vetor[8] == 'O') ||
                                       (Vetor[0] == 'X' && Vetor[4] == 'X' && Vetor[8] == 'X'))
                                    {
                                        Game = 1;
                                    }
                                    else
                                    {
                                        if ((Vetor[6] == 'O' && Vetor[4] == 'O' && Vetor[2] == 'O') ||
                                           (Vetor[6] == 'X' && Vetor[4] == 'X' && Vetor[2] == 'X'))
                                        {
                                            Game = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Game;
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Load_Victory(int A) // M vz N
        {
            int i;
            char M = 'x', N = 'y';
            if (A == 2)
            {
                N = 'X';
                M = 'O';
            }
            else
            {
                if (A == 1)
                {
                    N = 'O';
                    M = 'X';
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i] == M)
                {
                    V1[i] = 1;

                    if (i == 0)
                    {
                        V4[i] = 1;
                    }
                    if (i == 1)
                    {
                        V5[i - 1] = 1;
                    }
                    if (i == 2)
                    {
                        V6[i - 2] = 1;
                    }
                    if (i == 0)
                    {
                        V7[i] = 1;
                    }
                    if (i == 2)
                    {
                        V8[i - 2] = 1;
                    }

                }
                else
                {
                    if (Vetor[i] == N)
                    {
                        V1[i] = 2;
                        if (i == 0)
                        {
                            V4[i] = 2;
                        }
                        if (i == 1)
                        {
                            V5[i - 1] = 2;
                        }
                        if (i == 2)
                        {
                            V6[i - 2] = 2;
                        }
                        if (i == 0)
                        {
                            V7[i] = 2;
                        }
                        if (i == 2)
                        {
                            V8[i - 2] = 2;
                        }
                    }
                    else
                    {
                        V1[i] = 0;
                        if (i == 0)
                        {
                            V4[i] = 0;
                        }
                        if (i == 1)
                        {
                            V5[i - 1] = 0;
                        }
                        if (i == 2)
                        {
                            V6[i - 2] = 0;
                        }
                        if (i == 0)
                        {
                            V7[i] = 0;
                        }
                        if (i == 2)
                        {
                            V8[i - 2] = 0;
                        }
                    }
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i + 3] == M)
                {
                    V2[i] = 1;
                    if (i == 0)
                    {
                        V4[i + 1] = 1;
                    }
                    if (i == 1)
                    {
                        V5[i] = 1;
                    }
                    if (i == 2)
                    {
                        V6[i - 1] = 1;
                    }
                    if (i == 1)
                    {
                        V7[i] = 1;
                    }
                    if (i == 1)
                    {
                        V8[i] = 1;
                    }
                }
                else
                {
                    if(Vetor[i + 3] == N)
                    {
                        V2[i] = 2;
                        if (i == 0)
                        {
                            V4[i + 1] = 2;
                        }
                        if (i == 1)
                        {
                            V5[i] = 2;
                        }
                        if (i == 2)
                        {
                            V6[i - 1] = 2;
                        }
                        if (i == 1)
                        {
                            V7[i] = 2;
                        }
                        if (i == 1)
                        {
                            V8[i] = 2;
                        }
                    }
                    else
                    {
                        V2[i] = 0;
                        if (i == 0)
                        {
                            V4[i + 1] = 0;
                        }
                        if (i == 1)
                        {
                            V5[i] = 0;
                        }
                        if (i == 2)
                        {
                            V6[i - 1] = 0;
                        }
                        if (i == 1)
                        {
                            V7[i] = 0;
                        }
                        if (i == 1)
                        {
                            V8[i] = 0;
                        }
                    }
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i + 6] == M)
                {
                    V3[i] = 1;
                    if (i == 0)
                    {
                        V4[i + 2] = 1;
                    }
                    if (i == 1)
                    {
                        V5[i + 1] = 1;
                    }
                    if (i == 2)
                    {
                        V6[i] = 1;
                    }
                    if (i == 2)
                    {
                        V7[i] = 1;
                    }
                    if (i == 0)
                    {
                        V8[i + 2] = 1;
                    }
                }
                else
                {
                    if(Vetor[i + 6] == N)
                    {
                        V3[i] = 2;
                        if (i == 0)
                        {
                            V4[i + 2] = 2;
                        }
                        if (i == 1)
                        {
                            V5[i + 1] = 2;
                        }
                        if (i == 2)
                        {
                            V6[i] = 2;
                        }
                        if (i == 2)
                        {
                            V7[i] = 2;
                        }
                        if (i == 0)
                        {
                            V8[i + 2] = 2;
                        }
                    }
                    else
                    {
                        V3[i] = 0;
                        if (i == 0)
                        {
                            V4[i + 2] = 0;
                        }
                        if (i == 1)
                        {
                            V5[i + 1] = 0;
                        }
                        if (i == 2)
                        {
                            V6[i] = 0;
                        }
                        if (i == 2)
                        {
                            V7[i] = 0;
                        }
                        if (i == 0)
                        {
                            V8[i + 2] = 0;
                        }
                    }
                }
            }
        }
        // ----------------------------------------------------------------------- //
        // ----------------------------------------------------------------------- //
        public static int VictoryAnalisy(int[] X)
        {
            int Resposta = 0;

            if (X[0] == 1 && X[1] == 1 && X[2] == 0)
            {
                Resposta = 1;
            }
            else
            {
                if (X[0] == 1 && X[1] == 0 && X[2] == 1)
                {
                    Resposta = 1;
                }
                else
                {
                    if (X[0] == 0 && X[1] == 1 && X[2] == 1)
                    {
                        Resposta = 1;
                    }
                }
            }
            return Resposta;
        }
        // ----------------------------------------------------------------------- //
        // ----------------------------------------------------------------------- //
        public static void Load_Perigo(int A)  // M vz N
        {
            int  i;
            char M = 'x',N = 'y';
            if (A == 2)
            {
                N = 'X';
                M = 'O';
            }
            else
            {
                if(A == 1)
                {
                    N = 'O';
                    M = 'X';
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i] == M)
                {
                    P1[i] = 1;

                    if (i == 0)
                    {
                        P4[i] = 1;
                    }
                    if (i == 1)
                    {
                        P5[i - 1] = 1;
                    }
                    if (i == 2)
                    {
                        P6[i - 2] = 1;
                    }
                    if (i == 0)
                    {
                        P7[i] = 1;
                    }
                    if (i == 2)
                    {
                        P8[i - 2] = 1;
                    }

                }
                else
                {
                    if(Vetor[i] == N)
                    {
                        P1[i] = 2;
                        if (i == 0)
                        {
                            P4[i] = 2;
                        }
                        if (i == 1)
                        {
                            P5[i - 1] = 2;
                        }
                        if (i == 2)
                        {
                            P6[i - 2] = 2;
                        }
                        if (i == 0)
                        {
                            P7[i] = 2;
                        }
                        if (i == 2)
                        {
                            P8[i - 2] = 2;
                        }
                    }
                    else
                    {
                        P1[i] = 0;
                        if (i == 0)
                        {
                            P4[i] = 0;
                        }
                        if (i == 1)
                        {
                            P5[i - 1] = 0;
                        }
                        if (i == 2)
                        {
                            P6[i - 2] = 0;
                        }
                        if (i == 0)
                        {
                            P7[i] = 0;
                        }
                        if (i == 2)
                        {
                            P8[i - 2] = 0;
                        }
                    }
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i + 3] == M)
                {
                    P2[i] = 1;
                    if (i == 0)
                    {
                        P4[i + 1] = 1;
                    }
                    if (i == 1)
                    {
                        P5[i] = 1;
                    }
                    if (i == 2)
                    {
                        P6[i - 1] = 1;
                    }
                    if (i == 1)
                    {
                        P7[i] = 1;
                    }
                    if (i == 1)
                    {
                        P8[i] = 1;
                    }
                }
                else
                {
                    if (Vetor[i + 3] == N)
                    {
                        P2[i] = 2;
                        if (i == 0)
                        {
                            P4[i + 1] = 2;
                        }
                        if (i == 1)
                        {
                            P5[i] = 2;
                        }
                        if (i == 2)
                        {
                            P6[i - 1] = 2;
                        }
                        if (i == 1)
                        {
                            P7[i] = 2;
                        }
                        if (i == 1)
                        {
                            P8[i] = 2;
                        }
                    }
                    else
                    {
                        P2[i] = 0;
                        if (i == 0)
                        {
                            P4[i + 1] = 0;
                        }
                        if (i == 1)
                        {
                            P5[i] = 0;
                        }
                        if (i == 2)
                        {
                            P6[i - 1] = 0;
                        }
                        if (i == 1)
                        {
                            P7[i] = 0;
                        }
                        if (i == 1)
                        {
                            P8[i] = 0;
                        }
                    }
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Vetor[i + 6] == M)
                {
                    P3[i] = 1;
                    if (i == 0)
                    {
                        P4[i + 2] = 1;
                    }
                    if (i == 1)
                    {
                        P5[i + 1] = 1;
                    }
                    if (i == 2)
                    {
                        P6[i] = 1;
                    }
                    if (i == 2)
                    {
                        P7[i] = 1;
                    }
                    if (i == 0)
                    {
                        P8[i + 2] = 1;
                    }
                }
                else
                {
                    if(Vetor[i + 6] == N)
                    {
                        P3[i] = 2;
                        if (i == 0)
                        {
                            P4[i + 2] = 2;
                        }
                        if (i == 1)
                        {
                            P5[i + 1] = 2;
                        }
                        if (i == 2)
                        {
                            P6[i] = 2;
                        }
                        if (i == 2)
                        {
                            P7[i] = 2;
                        }
                        if (i == 0)
                        {
                            P8[i + 2] = 2;
                        }
                    }
                    else
                    {
                        P3[i] = 0;
                        if (i == 0)
                        {
                            P4[i + 2] = 0;
                        }
                        if (i == 1)
                        {
                            P5[i + 1] = 0;
                        }
                        if (i == 2)
                        {
                            P6[i] = 0;
                        }
                        if (i == 2)
                        {
                            P7[i] = 0;
                        }
                        if (i == 0)
                        {
                            P8[i + 2] = 0;
                        }
                    }
                }
            }
        }
        // ----------------------------------------------------------------------- //
        // ----------------------------------------------------------------------- //
        public static int PerigoAnalisy(int[] X)
        {
            int Resposta = 0, i;

            if (X[0] == 1 && X[1] == 1 && X[2] == 0)
            {
                Resposta = 1;
            }
            else
            {
                if (X[0] == 1 && X[1] == 0 && X[2] == 1)
                {
                    Resposta = 1;
                }
                else
                {
                    if (X[0] == 0 && X[1] == 1 && X[2] == 1)
                    {
                        Resposta = 1;
                    }
                }
            }
            /*for (i = 0; i<3; i++)
            {
                Console.WriteLine(">: " + X[i]);

            }
           
            Console.WriteLine("R>: " + Resposta);*/
            return Resposta;
        }
        // ----------------------------------------------------------------------- //
        // ----------------------------------------------------------------------- //
        public static int Lance_IA(int J)
        {
            int Lance = 0; // Lance retorna o lance final
            int Ax    = 0; // Variavel para auxilio
            int Ctrl  = 0; // Controle de analise 
            int Xl    = 0; // Variavel com os lances analisados
            int i     = 0; // Para repetição for
            Random rnd = new Random(); // Gera número randomico
            if (J == 1)
            {
                Load_Victory(1);
            }
            else
            {
                if (J == 2)
                {
                    Load_Victory(2);
                }
            }
            // --------------------------------- // Analisar Vitoria
            // --------------------------------- // Analisar Vitoria
            if (TxT == 1)
            {
                Console.WriteLine(" Oi: Entrou");
            }           
            if (Ax == 1)
            {
                Ax = VictoryAnalisy(V1);
                if (TxT == 1)
                {
                    Console.WriteLine(" Ax3: " + Ax);
                }
                for (i = 0; i < 3; i++)
                {
                    if (V1[i] == 0)
                    {
                        Xl = i + 1;
                    }
                }
            }
            else
            {
                Ax = VictoryAnalisy(V2);
                if (TxT == 1)
                {
                    Console.WriteLine(" Ax2: " + Ax);
                }             
                if (Ax == 1)
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (V2[i] == 0)
                        {
                            Xl = i + 4;
                        }
                    }
                }
                else
                {
                    Ax = VictoryAnalisy(V3);
                    if (TxT == 1)
                    {
                        Console.WriteLine(" Ax3: " + Ax);
                    }                
                    if (Ax == 1)
                    {
                        for (i = 0; i < 3; i++)
                        {
                            if (V3[i] == 0)
                            {
                                Xl = i + 7;
                            }
                        }
                    }
                    else
                    {
                        Ax = VictoryAnalisy(V4);
                        if (TxT == 1)
                        {
                            Console.WriteLine(" Ax4: " + Ax);
                        }
                        if (Ax == 1)
                        {
                            for (i = 0; i < 3; i++)
                            {
                                if (V4[i] == 0)
                                {
                                    if (i == 0)
                                    {
                                        Xl = 1;
                                    }
                                    else
                                    {
                                        if (i == 1)
                                        {
                                            Xl = 4;
                                        }
                                        else
                                        {
                                            if (i == 2)
                                            {
                                                Xl = 7;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Ax = VictoryAnalisy(V5);
                            if (TxT == 1)
                            {
                                Console.WriteLine(" Ax5: " + Ax);
                            }
                            if (Ax == 1)
                            {
                                for (i = 0; i < 3; i++)
                                {
                                    if (V5[i] == 0)
                                    {
                                        if (i == 0)
                                        {
                                            Xl = 2;
                                        }
                                        else
                                        {
                                            if (i == 1)
                                            {
                                                Xl = 5;
                                            }
                                            else
                                            {
                                                if (i == 2)
                                                {
                                                    Xl = 8;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Ax = VictoryAnalisy(V6);
                                if (TxT == 1)
                                {
                                    Console.WriteLine(" Ax6: " + Ax);
                                }
                                if (Ax == 1)
                                {
                                    for (i = 0; i < 3; i++)
                                    {
                                        if (V6[i] == 0)
                                        {
                                            if (i == 0)
                                            {
                                                Xl = 3;
                                            }
                                            else
                                            {
                                                if (i == 1)
                                                {
                                                    Xl = 6;
                                                }
                                                else
                                                {
                                                    if (i == 2)
                                                    {
                                                        Xl = 9;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Ax = VictoryAnalisy(V7);
                                    if (TxT == 1)
                                    {
                                        Console.WriteLine(" Ax7: " + Ax);
                                    }
                                    if (Ax == 1)
                                    {
                                        for (i = 0; i < 3; i++)
                                        {
                                            if (V7[i] == 0)
                                            {
                                                if (i == 0)
                                                {
                                                    Xl = 1;
                                                }
                                                else
                                                {
                                                    if (i == 1)
                                                    {
                                                        Xl = 5;
                                                    }
                                                    else
                                                    {
                                                        if (i == 2)
                                                        {
                                                            Xl = 9;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Ax = VictoryAnalisy(V8);
                                        if (TxT == 1)
                                        {
                                            Console.WriteLine(" Ax8: " + Ax);
                                        }
                                        if (Ax == 1)
                                        {
                                            for (i = 0; i < 3; i++)
                                            {
                                                if (V8[i] == 0)
                                                {
                                                    if (i == 0)
                                                    {
                                                        Xl = 3;
                                                    }
                                                    else
                                                    {
                                                        if (i == 1)
                                                        {
                                                            Xl = 5;
                                                        }
                                                        else
                                                        {
                                                            if (i == 2)
                                                            {
                                                                Xl = 7;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // ------------------------------------- //Analisando Victory
            // ------------------------------------- //Analisando Victory
            if (Xl >= 1)
            {
                if (Vetor[Xl - 1] == 'X')
                {
                    Ctrl = 1;
                }
                else
                {
                    Lance = Xl;
                    Ctrl = 0;
                    if (TxT == 1)
                    {
                        Console.WriteLine(" Key: " + Lance);
                        Console.ReadKey();
                    }                  
                }
            }
            else
            {
                Ctrl = 1;
            }
            // ------------------------------------- //Analisando Perigo
            // ------------------------------------- //Analisando Perigo
            if (Ctrl == 1)
            {
                if (J == 1)
                {
                    Load_Perigo(1);
                }
                else
                {
                    if (J == 2)
                    {
                        Load_Perigo(1);
                    }
                }             
                Ax = PerigoAnalisy(P1);
                if (TxT == 1)
                {
                    Console.WriteLine(" Ap1: " + Ax);
                }              
                if (Ax == 1)
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (P1[i] == 0)
                        {
                            Xl = i + 1;
                        }
                    }
                }
                else
                {
                    Ax = PerigoAnalisy(P2);
                    if (TxT == 1)
                    {
                        Console.WriteLine(" Ap2: " + Ax);
                    }
                    if (Ax == 1)
                    {
                        for (i = 0; i < 3; i++)
                        {
                            if (P2[i] == 0)
                            {
                                Xl = i + 4;
                            }
                        }
                    }
                    else
                    {
                        Ax = PerigoAnalisy(P3);
                        if (TxT == 1)
                        {
                            Console.WriteLine(" Ap3: " + Ax);
                        }
                        if (Ax == 1)
                        {
                            for (i = 0; i < 3; i++)
                            {
                                if (P3[i] == 0)
                                {
                                    Xl = i + 7;
                                }
                            }
                        }
                        else
                        {
                            Ax = PerigoAnalisy(P4);
                            if (TxT == 1)
                            {
                                Console.WriteLine(" Ap4: " + Ax);
                            }
                            if (Ax == 1)
                            {
                                for (i = 0; i < 3; i++)
                                {
                                    if (P4[i] == 0)
                                    {
                                        if (i == 0)
                                        {
                                            Xl = 1;
                                        }
                                        else
                                        {
                                            if (i == 1)
                                            {
                                                Xl = 4;
                                            }
                                            else
                                            {
                                                if (i == 2)
                                                {
                                                    Xl = 7;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Ax = PerigoAnalisy(P5);
                                if (TxT == 1)
                                {
                                    Console.WriteLine(" Ap5: " + Ax);
                                }
                                if (Ax == 1)
                                {
                                    for (i = 0; i < 3; i++)
                                    {
                                        if (P5[i] == 0)
                                        {
                                            if (i == 0)
                                            {
                                                Xl = 2;
                                            }
                                            else
                                            {
                                                if (i == 1)
                                                {
                                                    Xl = 5;
                                                }
                                                else
                                                {
                                                    if (i == 2)
                                                    {
                                                        Xl = 8;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Ax = PerigoAnalisy(P6);
                                    if (TxT == 1)
                                    {
                                        Console.WriteLine(" Ap6: " + Ax);
                                    }
                                    if (Ax == 1)
                                    {
                                        for (i = 0; i < 3; i++)
                                        {
                                            if (P6[i] == 0)
                                            {
                                                if (i == 0)
                                                {
                                                    Xl = 3;
                                                }
                                                else
                                                {
                                                    if (i == 1)
                                                    {
                                                        Xl = 6;
                                                    }
                                                    else
                                                    {
                                                        if (i == 2)
                                                        {
                                                            Xl = 9;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Ax = PerigoAnalisy(P7);
                                        if (TxT == 1)
                                        {
                                            Console.WriteLine(" Ap7: " + Ax);
                                        }
                                        if (Ax == 1)
                                        {
                                            for (i = 0; i < 3; i++)
                                            {
                                                if (P7[i] == 0)
                                                {
                                                    if (i == 0)
                                                    {
                                                        Xl = 1;
                                                    }
                                                    else
                                                    {
                                                        if (i == 1)
                                                        {
                                                            Xl = 5;
                                                        }
                                                        else
                                                        {
                                                            if (i == 2)
                                                            {
                                                                Xl = 9;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Ax = PerigoAnalisy(P8);
                                            if (TxT == 1)
                                            {
                                                Console.WriteLine(" Ap8: " + Ax);
                                            }
                                            if (Ax == 1)
                                            {
                                                for (i = 0; i < 3; i++)
                                                {
                                                    if (P8[i] == 0)
                                                    {
                                                        if (i == 0)
                                                        {
                                                            Xl = 3;
                                                        }
                                                        else
                                                        {
                                                            if (i == 1)
                                                            {
                                                                Xl = 5;
                                                            }
                                                            else
                                                            {
                                                                if (i == 2)
                                                                {
                                                                    Xl = 7;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // ------------------------------------- //Analisando Perigo
                // ------------------------------------- //Analisando Perigo
                if (Xl >= 1)
                {
                    if (Vetor[Xl - 1] == 'O' || Vetor[Xl - 1] == 'X')
                    {
                        Ctrl = 1;
                    }
                    else
                    {
                        Lance = Xl;
                        Ctrl = 0;
                        if (TxT == 1)
                        {
                            Console.WriteLine(" Key: " + Xl);
                            Console.ReadKey();
                        }                   
                    }
                }
                else
                {
                    Ctrl = 1;
                }
                // ------------------------------------- //Analisando Perigo
                // ------------------------------------- //Analisando Perigo
            }
            if (Ctrl == 1)
            {
                Lance = rnd.Next(1, 10);
            }
            return Lance;
        }
        // ----------------------------------------------------------------------- //
        // ----------------------------------------------------------------------- //
        public static void VictoryText()
        {
            int i;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P1[" + i + "] = " + V1[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P2[" + i + "] = " + V2[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P3[" + i + "] = " + V3[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P4[" + i + "] = " + V4[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P5[" + i + "] = " + V5[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P6[" + i + "] = " + V6[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P7[" + i + "] = " + V7[i]);
            }
            Console.WriteLine("---------------------------------");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine(" P8[" + i + "] = " + V8[i]);
            }
            Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }
        // ------------------------------- //
        // ------------------------------- //
    }
}
