using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace Caixeiro_Viajante
{
    class Principal
    {
        static void geraMatriz(int[,] cidades, int tam)//Gerar matriz e salvar no arquivo.
        {

            StreamWriter escrever = new StreamWriter("Matriz.txt");//Nome recebido do usuário.
            Random gera = new Random();//Objeto de número randômico.

            //Gerar matriz.
            for (int ln = 0; ln < tam; ln++)
            {
                for (int col = 0; col < tam; col++)
                {
                    if (col == ln)
                        cidades[ln, col] = 0;
                    else
                    {
                        cidades[ln, col] = gera.Next(1, 10);//Gerar números aleatórios.
                        cidades[col, ln] = cidades[ln, col];
                    }
                }
            }

            //Escrever matriz no arquivo.
            for (int ln = 0; ln < tam; ln++)
            {

                for (int cl = 0; cl < tam; cl++)
                {
                    escrever.Write(cidades[ln, cl] + ";");
                }
                escrever.WriteLine();
            }

            escrever.Close();
        }
        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho da matriz: ");
            int tam = int.Parse(Console.ReadLine());

            Console.Clear();

            int[,] cidades = new int[tam, tam];
            geraMatriz(cidades, tam);

            //Fazer Força Bruta.
            Console.WriteLine("Executar Força Bruta (O(n!)):\n");
            Forca_Bruta forcaBruta = new Forca_Bruta();
            forcaBruta.imprimeResultados(tam, cidades);

            //Fazer Tentativa e Erro.
            Console.WriteLine("\nExecuatar algoritmo Tentativa e Erro (O(n^1,26)):\n");
            Tentativa_Erro tentativa = new Tentativa_Erro();
            tentativa.imprimeResultados(tam, cidades);

            //Fazer Melhor Caso.
            Console.WriteLine("\nExecutar algoritmo com melhor resposta (O(n²)): ");
            Vertice vertice = new Vertice(cidades);

            vertice.viajante(tam - 1);

            Console.ReadKey();
        }
    }
}