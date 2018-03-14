using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Caixeiro_Viajante
{
    class Tentativa_Erro
    {
        static int somaTotal = int.MaxValue;

        static int Fatorial(int fat)//Permutações.
        {
            if (fat == 0)
                return 1;
            else
                return fat * Fatorial(fat - 1);
        }
        static void Combinacoes(int[,] cidades, int tam, int[] vetResp)//Fazer as combinações.
        {
            int[] vet = new int[tam];
            int aux = 0, fat = Fatorial(tam);

            for (int i = 0; i < tam; i++)//Preenche vetor com as cidades.
            {
                vet[i] = i;
            }

            for (int n = 0; n < fat; n++)//Total de combinações.
            {
                for (int i = 0; i < tam - 1; i++)//Permutar e compor o caminho.
                {
                    menorCaminho(vet, cidades, vetResp);

                    aux = vet[i];
                    vet[i] = vet[i + 1];
                    vet[i + 1] = aux;
                }
            }
        }

        static void menorCaminho(int[] vetCaminho, int[,] cidades, int[] vetResp)//Verifica menor caminho.
        {
            int aux_2 = 0;

            for (int i = 0; i < vetCaminho.Length - 1; i++)//Peso total do caminho.
            {
                aux_2 += cidades[vetCaminho[i], vetCaminho[i + 1]];

                if (aux_2 > somaTotal)
                    i = vetCaminho.Length;
            }

            if (aux_2 < somaTotal)//Menor caminho calculado.
            {
                somaTotal = aux_2;

                for (int i = 0; i < vetCaminho.Length; i++)
                {
                    vetResp[i] = vetCaminho[i];
                }
            }

        }

        public void imprimeResultados(int tamanho, int[,] cidades)//Imprimir resultados no Main.
        {
            int[] vetResp = new int[tamanho];
            Stopwatch relogio = new Stopwatch();//Objeto para diagnóstico de tempo.

            relogio.Start();//Começa acontar o tempo.
            Combinacoes(cidades, tamanho, vetResp);
            relogio.Stop();//Para de contar o tempo.

            Console.WriteLine("Total de combinações possíveis: " + Fatorial(tamanho));
            Console.WriteLine("Peso total do menor caminho: " + somaTotal);
            Console.Write("Menor caminho: ");
            for (int i = 0; i < vetResp.Length; i++)
            {
                Console.Write(vetResp[i] + " ");
            }

            Console.WriteLine("\nTempo gasto: ");
            Console.WriteLine("Horas: " + relogio.Elapsed.Hours + ", minutos: " + relogio.Elapsed.Minutes + ", segundos: " + relogio.Elapsed.Seconds + ", milissegundos: " + relogio.Elapsed.Milliseconds);
        }
    }
}

