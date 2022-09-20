using System;


    class jogo_da_velha
    {
        private bool FimdeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public jogo_da_velha()
        {
            FimdeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }
        public void iniciar()
        {
            while (!FimdeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimdeJogo();
                MudarVez();
            }
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimdeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                FimdeJogo = true;
                System.Console.WriteLine($"Fim De Jogo! Vitoria de {vez}");
                return;
            }

            if (quantidadePreenchida is 9)
            {
                FimdeJogo = true;
                System.Console.WriteLine("Fim de Jogo! Empate");
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }

        private void LerEscolhaDoUsuario()
        {
            System.Console.WriteLine($"Agora é vez de {vez}, Selecione uma posicao DE 1 a 9 que esteja livre na tabela");

            bool conversao = int.TryParse(System.Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                System.Console.WriteLine("O Campo Escolhido é invalido, por favor digite um numero entre 1 e 9 que esteja livre na tabela.");
                conversao = int.TryParse(System.Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEcolha(posicaoEscolhida);
        }

        private void PreencherEcolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        private bool
            ValidarEscolhaUsuario(int posicaoEscolhdia)
        {
            int indice = posicaoEscolhdia - 1;

            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
        }

        private void RenderizarTabela()
        {
            System.Console.Clear();

            System.Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }