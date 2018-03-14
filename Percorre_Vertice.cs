using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
/*

- método para gravar a lista de vértices mais próximo  (antes do teste, deverá testar se todos os vértices foram visitados
- método para buscar o vértice mais próximo (não pode ter sido visitado) 
*/

namespace Caixeiro_Viajante
{
    class Vertice
    {
        int distancia;

        Stopwatch diagnostico = new Stopwatch();

        int[] caminho; //vetor para guardar o caminho a partir da cidade arbitrária
        int conta_Cidades; //contador para guardar na posição do caminho
        int[,] cidades; //matriz de cidades
        int atual; //ultima cidade visitada pelo caxeiro

        List<int> melhor_Caminho = new List<int>(); //lista do caminho das cidades

        public Vertice(int[,] cidades) //recebe a matriz
        {
            this.cidades = cidades;
        }

        public List<int> viajante(int atual)
        {
            caminho = new int[cidades.GetLength(0)]; //inicia o vetor com o tamanho da linha da matriz (numero de cidades)
            this.atual = atual; //armazena na variável da classe a cidade que deseja começar o caminho

            caminho[conta_Cidades] = this.atual; //insere na posição 0 do vetor de caminho a primeira cidade 

            melhor_Caminho.Add(atual); //insere na lista de melhor caminho a cidade arbitrária como a primeira da lista

            diagnostico.Start();

            for (int i = 0; i < caminho.Length - 1; i++) //busca o caminho enquanto i for menor do que a quantidade de cidades a visitar
            {
                Busca_Caminho(); //método para buscar a cidade com menor caminho
            }

            diagnostico.Stop();

            imprime();
            return melhor_Caminho; //retorna uma lista com o caminho mais curto entre todas as cidades
        }

        private void Busca_Caminho()
        {
            int distancia_Menor = int.MaxValue; //variavel para encontrar a menor distância entre cidade atual e i

            for (int j = 0; j < cidades.GetLength(0); j++) //percorre todos os nós de um índice da matriz
            {
                if ((atual) != j) //"atual" e "i" não podem ser da mesma cidade 
                {
                    if ((cidades[atual, j] < distancia_Menor) || (cidades[j, atual] < distancia_Menor))
                    {//o elemento da matriz é menor do que o ultimo elemento encontrado
                        if (cidades[atual, j] != -1 && cidades[j, atual] != -1)
                        {//o elemento ainda não foi visitado
                            if (!melhor_Caminho.Contains(j))
                            {//o elemento ainda não foi inclúído na matriz
                                distancia_Menor = cidades[atual, j]; //grava na variável o valor da matriz encontrado
                                caminho[conta_Cidades] = j; //inclui no vetor de cidades a cidade de menor caminho a partir da ultima cidade visitada
                                cidades[atual, j] = -1; //marcar cidade como visitada
                                cidades[j, atual] = -1; //marcar cidade como visitada
                            }
                        }
                    }
                }
            }

            atual = caminho[conta_Cidades]; //agora o vértice atual é o ultimo elemento do vetor
            conta_Cidades++;//adiciona uma cidade na quantidade de cidades encontradas

            melhor_Caminho.Add(atual); //adiciona a cidade atual (encontrada) na lista de melhor caminho

            distancia = distancia + distancia_Menor;
            //soma a distância encontrada nas distâncias acumuladas


        }

        public void imprime()
        {
            Console.WriteLine("Sequência de cidades a visitar");

            for (int i = 0; i < melhor_Caminho.Count; i++)
            {
                Console.Write(melhor_Caminho[i] + " ");
            }

            Console.WriteLine("\nPeso total do caminho: " + distancia);
            Console.WriteLine("\nTempo: " + diagnostico.Elapsed.Days + " dias, " + diagnostico.Elapsed.Hours + " horas, " + diagnostico.Elapsed.Minutes + " minutos, " + diagnostico.Elapsed.Seconds + " segundos, " +
               diagnostico.Elapsed.Milliseconds + " milisegundos.");

        }
    }
}
