using System;
using System.Threading;

namespace Exercicio_Jogo_Da_Velha
{
    class Program
    {
        static char[] posicao = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //Array das posições do tabuleiro
        static int jogador = 1; //Jogador 1 inicia o jogo primeiro
        static int escolha; //Esta variavel irá armazenar a escolha do usuario

        static int verifica = 0; //Esta variavel verifica quem ganhou, se o seu valor for (1) então alguem ganhou,
                                 //se for (-1) empatou e se for (0) a partida ainda está acontecendo
        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); //Toda vez que o loop iniciar irá limpar a tela
                Console.WriteLine("Jogador 1: X e Jogador 2: O\n");

                if (jogador % 2 == 0) //Verifica de qual jogador é a vez
                {
                    Console.WriteLine("Vez do Jogador 2\n");
                }
                else
                {
                    Console.WriteLine("Vez do Jogador 1\n");
                }

                Tabuleiro(); //Chama o método tabuleiro
                Console.WriteLine("");
                Console.Write("Digite a posição desejada: ");
                escolha = int.Parse(Console.ReadLine()); //Irá armazenar a escolha do usuario dentro da variavel "escolha"   

                //Irá verificar se a posição onde o usuário deseja escolher está marcada com ("X" ou "O")
                if (posicao[escolha] != 'X' && posicao[escolha] != 'O')
                {
                    if (jogador % 2 == 0) //Se a vez for do jogador 2 irá marcar com "0"
                    {
                        posicao[escolha] = 'O';
                        jogador++;
                    }

                    else //Se não irá marcar com "X" (Vez do jogador 1)
                    {
                        posicao[escolha] = 'X';
                        jogador++;
                    }
                }
                else //Se for uma posição já marcada, irá mostrar na tela oque aconteceu e aparecerá o tabuleiro novamente
                {
                    Console.WriteLine("A posição {0} já foi marcada por {1}", escolha, posicao[escolha]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde 2 segundos para tentar novamente...");
                    Thread.Sleep(2000);
                }

                verifica = VerificarVitoria(); //Chama o método para verificar a vitória

            } while (verifica != 1 && verifica != -1); //Este loop será executado até que todas as posições não sejam marcadas com ("X" e "O") ou algum jogador não seja vencedor

            Console.Clear(); //Limpa tela
            Tabuleiro(); //Chama o método tabuleiro novamente

            if (verifica == 1)  //Se a variavel "verifica" ter o valor 1 então alguém ganhou
            {
                Console.WriteLine("Jogador {0} ganhou! Parabéns!!", (jogador % 2) + 1);
            }
            else //Se não, verifica == -1, empatou
            {
                Console.WriteLine("Empatou!");
            }
            Console.ReadLine();
        }

        private static void Tabuleiro()

        {
            //Criação do tabuleiro e suas posições
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", posicao[1], posicao[2], posicao[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", posicao[4], posicao[5], posicao[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", posicao[7], posicao[8], posicao[9]);
            Console.WriteLine("     |     |      ");

        }

        private static int VerificarVitoria()
        {  
            //Vitória pela 1ª linha
            if (posicao[1] == posicao[2] && posicao[2] == posicao[3])
            {
                return 1;
            }
            //Vitória pela 2ª linha
            else if (posicao[4] == posicao[5] && posicao[5] == posicao[6])
            {
                return 1;
            }
            //Vitória pela 3ª linha
            else if (posicao[6] == posicao[7] && posicao[7] == posicao[8])
            {
                return 1;
            }

            //Vitória pela 1ª coluna
            else if (posicao[1] == posicao[4] && posicao[4] == posicao[7])
            {
                return 1;
            } 
            //Vitória pela 2ª coluna
            else if (posicao[2] == posicao[5] && posicao[5] == posicao[8])
            {
                return 1;
            }
            //Vitória pela 3ª coluna
            else if (posicao[3] == posicao[6] && posicao[6] == posicao[9])
            {
                return 1;
            }

            //Vitória pela diagonal dos 2 sentidos
            else if (posicao[1] == posicao[5] && posicao[5] == posicao[9])
            {
                return 1;
            }
            else if (posicao[3] == posicao[5] && posicao[5] == posicao[7])
            {
                return 1;
            }

            //Se todas as posições forem preenchidos com X ou O, então empatou
            else if (posicao[1] != '1' && posicao[2] != '2' && posicao[3] != '3' && posicao[4] != '4' && posicao[5] != '5' && posicao[6] != '6' && posicao[7] != '7' && posicao[8] != '8' && posicao[9] != '9')
            {
                return -1;
            }
            else //Se não, irá continuar o jogo
            {
                return 0;
            }
        }
    }
}
