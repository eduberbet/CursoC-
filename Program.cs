using System;

namespace DigitalInnovationOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        if (indiceAluno < 5)
                        {
                            Console.WriteLine("Informe o nome do aluno:");
                            Aluno aluno = new Aluno();
                            aluno.Nome = Console.ReadLine();
                            Console.WriteLine("Informe a Nota do aluno:");
                            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            {
                                aluno.Nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("Valor da nota deve ser decimal");
                            }
                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                        }
                        else 
                        {
                            Console.WriteLine("Impossivel no momento!");
                            Console.WriteLine("Quantidade maxima de alunos atingida.");
                        }
                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");    
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        int mediaCalculo = Decimal.ToInt16(mediaGeral);
                        Conceito conceitoGeral;
                        if (mediaCalculo < 4)
                        {
                            conceitoGeral = Conceito.F;
                        }
                        else if (mediaCalculo < 5)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaCalculo < 7)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaCalculo < 9)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno.");
            Console.WriteLine("2 - Listar Alunos.");
            Console.WriteLine("3 - Calcular média Geral.");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}