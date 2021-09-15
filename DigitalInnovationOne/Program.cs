using System;
using System.Globalization;

namespace DigitalInnovationOne
{

    public struct Aluno
    {
        public string Nome { get; set; }

        public decimal Nota { get; set; }

    }

    public enum Conceito
    {
        A,

        B,

        C,

        D,

        E
    }


    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5]; // aloca 5 posições 
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno(); // instanciando um objeto do tipo Aluno
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)) // verifica se com a entrada do usuário é possível converter em decimal, se sim, já preenche a variável
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal"); // tratamento de erros
                        }

                        alunos[indiceAluno] = aluno; // neste momento insere o aluno na posição 0
                        indiceAluno++; //Incrementa posição

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) // método que retorna se a string está vazia ou nula
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - ALUNO: {a.Nota}");
                            }
                        }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral <2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral <4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral <6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral <8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }


        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Inserir novo aluno");
                Console.WriteLine("2 - Listas alunos");
                Console.WriteLine("3 - Calcular média geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                Console.WriteLine();
                return opcaoUsuario;
            }


    }

}
