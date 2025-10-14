using System;
using System.Runtime.Serialization.Formatters;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace AdicionarNomeNotasAlunos
{
    class Program
    {


        public static List<string> Nomes = new List<string>();
        public static List<int> Notas = new List<int>();

        struct Metodos
        {
            static void Main(string[] args)
            {
                Menu();
            }

            static void Menu()
            {
                Console.WriteLine();

                Console.WriteLine(" MENU");
                Console.WriteLine(" 1 - ADICIONAR NOME DO ALUNO E A NOTA");
                Console.WriteLine(" 2 - LISTAR NOMES E NOTAS");
                Console.WriteLine(" 3 - LISTAR APENAS NOMES");
                Console.WriteLine(" 4 - DEFINIR ALUNOS APROVADOS E REPROVADOS");
                Console.WriteLine(" 5 -  VER A MAIOR NOTA");
                Console.WriteLine(" 6 -  VER A MENOR NOTA");
                Console.WriteLine(" 7 -  EDITAR NOME OU NOTA");
                Console.WriteLine(" 0 - SAIR");
                int opcao;

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("ESCOLHA UMA DAS FUNCIONALIDADES USANDO O NUEMRO DE ACORDO");
                    var s = Console.ReadLine()?.Trim() ?? "";

                    if (int.TryParse(s, out opcao) && opcao >= 0 && opcao <= 7)
                        break;


                    Console.WriteLine($"esse valor e invalido");
                    Console.WriteLine($"escolha um valor correto");

                    Menu();
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarNomesNotas();
                    break;

                    case 2:
                        ListarNomesAlunos();
                    break;

                    case 3:
                        ListarNomes();
                    break;

                    case 4:
                        AlunosAprovadoseReprovados();
                    break;

                    case 5:
                        MaiorNota();
                    break;

                    case 6:
                        MenorNota();
                    break;

                    case 7:
                        EditarNome();
                    break;

                    case 0:
                        Sair();
                    break;
                }
            }

            public static void AdicionarNomesNotas()
            {
                Console.Clear();
                var MundialNotas = Nomes;

                Console.WriteLine("DIGITE O NOME DO ALUNO");
                string Nome = Console.ReadLine();
                Nomes.Add(Nome);

                //Console.WriteLine($"DIGITE A NOTA FINAL DO(a)  {Nome} ");
                int Nota;
                while (true)
                {
                    Console.Write($"Digite a nota do(a) { Nome } (1 a 10): ");
                    var s = Console.ReadLine()?.Trim() ?? "";

                    if (int.TryParse(s, out Nota) && Nota >= 1 && Nota <= 10)
                        break; 

                    Console.WriteLine("Apenas números de 1 a 10 são permitidos.");
                    Console.WriteLine();
                }

                Notas.Add(Nota);
                Menu();

            }

            public static void ListarNomesAlunos()
            {
                VeificarCondicoese();

                Console.Clear();

                for (int i = 0; i < Nomes.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + "O ALUNO: " + Nomes[i] + " TEM UMA NOTA: " + Notas[i] + " ");
                }

                Menu();
            }

            public static void ListarNomes()
            {
                Console.Clear();
                VeificarCondicoese();
                for (int i = 0; i < Nomes.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + Nomes[i]);
                }

                Menu();
            }

            public static void AlunosAprovadoseReprovados()
            {
                VeificarCondicoese();
                Console.Clear();

                Console.WriteLine("DEFINA UMA NOTA MINIMA A QUAL O ALUNO PODE SER APROVADO");
                int validarNotas;
                while (true)
                {
                    var s = Console.ReadLine()?.Trim() ?? "";

                    if (int.TryParse(s, out validarNotas) && validarNotas >= 1 && validarNotas <= 10)
                        break;
                    
                    Console.WriteLine("Apenas números de 1 a 10 são permitidos.");
                    Console.WriteLine();
                }

                Console.WriteLine("ALUNOS APROVADOS");
                for (int i = 0; i < Notas.Count; i++)
                {
                    if (Notas[i] >= validarNotas)
                    {
                        Console.WriteLine((i + 1) + " - " + Nomes[i] + " NOTA: " + Notas[i]);

                    }
                    else
                    {
                    }
                }
                Console.WriteLine();
                Console.WriteLine("ALUNOS REPROVADOS");
                for (int j = 0; j < Notas.Count; j++)
                {
                    if (Notas[j] <= validarNotas)
                    {

                        Console.WriteLine((j + 1) + " - " + Nomes[j] + " NOTA: " + Notas[j]);
                    }
                }
                Console.WriteLine();
                Menu();
            }

            static void MaiorNota()
            {
                VeificarCondicoese();
                Console.Clear();
                int ValorNotaArtual = 0;
                for (int i = 0;i < Notas.Count;i++)
                {
                    
                    if (Notas[i] > ValorNotaArtual)
                    {
                        ValorNotaArtual = Notas[i];

                    }
                }

                for (int i = 0; i < Notas.Count; i++)
                {
                    if (ValorNotaArtual == Notas[i])
                    {
                        Console.WriteLine("A MAIOR NOTA É DO ALUNO(a) " + Nomes[i] + " QUE TEM UMA NOTA: " +  ValorNotaArtual);
                    } 
                }
                Console.WriteLine();

                /*Console.WriteLine("A MAIOR NOTA É " + ValorNotaArtual)*/;
                Menu();
            }

            static void MenorNota()
            {
                VeificarCondicoese();
                Console.Clear();
                int ValorNotaArtual = 10;
                for (int i = 0; i < Notas.Count; i++)
                {

                    if (Notas[i] < ValorNotaArtual)
                    {
                        ValorNotaArtual = Notas[i];

                    }
                }

                for (int i = 0; i < Notas.Count; i++)
                {
                    if (ValorNotaArtual == Notas[i])
                    {
                        Console.WriteLine("A MAIOR NOTA É DO ALUNO(a) " + Nomes[i] + " QUE TEM UMA NOTA: " + ValorNotaArtual);
                    }
                }
                Console.WriteLine();

                /*Console.WriteLine("A MAIOR NOTA É " + ValorNotaArtual)*/;
                Menu();
            }

            static void EditarNome()
            {
                
                Console.Clear();
                VeificarCondicoese();
                Console.WriteLine("Selecione o numero que corresponda com o nome que você quer editar".ToUpper());
                int NumeroEditar = 0;
                string ValorDeNota;
                Console.WriteLine();
                for (int i = 0;i < Nomes.Count;i++)
                {
                    Console.WriteLine((i + 1 ) + " - " + Nomes[i] + " NOTA: " + Notas[i]);
                }

                while (true)
                {
                    Console.WriteLine();
                    var s = Console.ReadLine()?.Trim() ?? "";

                    if (int.TryParse(s, out NumeroEditar) && NumeroEditar >= 1 && NumeroEditar <= Nomes.Count)
                        break;

                    Console.WriteLine("Escolha o número que está ao lado do nome que você deseja editar.");
                    s = Console.ReadLine()?.Trim() ?? "";
                }

                NumeroEditar = NumeroEditar - 1;
                for (int i = NumeroEditar; i == NumeroEditar; i++)
                {
                    Console.WriteLine("selecione o novo Nome para ".ToUpper() + Nomes[i]);
                    string NomeAtualizado = Console.ReadLine();

                    Nomes[NumeroEditar] = NomeAtualizado;
                    Console.WriteLine();
                    Console.WriteLine("Nome atualizado para: ".ToUpper() + NomeAtualizado);
                    Console.WriteLine();
                    Console.WriteLine("DESEJA ALTERAR A NOTA DO(a) ".ToUpper() + NomeAtualizado + " NOTA ATUAL: " + Notas[i]);
                    Console.WriteLine("SE SIM DIGITE A NOTA A BAIXO SE NÃO APENAS DIGITE N".ToUpper());
                    ValorDeNota = (Console.ReadLine());

                    if (ValorDeNota ==  "n")
                    {
                        Console.WriteLine("Nome atual: ".ToUpper() + Nomes[i]);
                        Console.WriteLine("Nota atual: ".ToUpper() + Notas[i]);

                        Menu();
                    }


                    int ValorNotaAtualizado = 0;
                    Notas[ValorNotaAtualizado] = int.Parse(ValorDeNota);

                    Console.WriteLine("A nota do(a) ".ToUpper() + Nomes[i] + " FOI ATUALIZADA PARA: " + ValorDeNota);


                    Console.WriteLine("Nome atual: ".ToUpper() + Nomes[i]);
                    Console.WriteLine("Nota atual: ".ToUpper() + Notas[i]);

                }
                Menu();
            }


            public static void VeificarCondicoese()
            {
                if (Nomes.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("CRIE UM NOME E NOTA PARA ACESSAR ESSA FUNCIONALIDADE");
                    Menu();
                }
            }

            public static void Sair()
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("OBRIGADO POR USAR NOSSO SISTEMA");
                int Contador = 0;
                for (int i = 0; i < Nomes.Count; i++)
                {
                    Contador++;
                }
                Console.WriteLine();
                Console.WriteLine(" VOCÊ USOU " + Contador + " NOSSO SISTEMA");
            }
        }
    }
}



