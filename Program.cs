using System;
using System.Security.Authentication;
using System.Security.Cryptography;

class program
{
    public class dados()
    {
        public string nome, curso;
        public int ra, semestre, faltas;
        public double p1, p2, p3, media, mediadecimal; //tem que ser double pra utilizar o comando Math.Round
        public bool exame, situacaop3;

    }
    public class registro : dados
    {
        public void preenche()
        {
            Console.WriteLine("Olá, seja bem vindo ao sistema de registro e conferência, made by flavio08-20 on GitHub");
            Console.WriteLine("======= ++ =======");
            Console.Write("Nome Completo:");
             nome = Console.ReadLine();
            Console.Write("Curso Matriculado:");
             curso = Console.ReadLine();
            Console.Write("Semestre (somente o número):");
             semestre = int.Parse(Console.ReadLine()); // variavel = tipodesejado.Parses
            Console.Write("Insira seu RA:");
             ra = int.Parse(Console.ReadLine());
            Console.Write("Insira suas faltas:");
            faltas = int.Parse(Console.ReadLine());
            Console.Write("Insira a sua nota da P1:");
            p1 = double.Parse(Console.ReadLine());
            Console.Write("Insira a sua nota da P2:");
            p2 = double.Parse(Console.ReadLine());
            media = (p1 + p2 * 2) / 3;
            mediadecimal = Math.Round(media, 2);

            //mediadecimal = Math.Round(media, 2); //Math.Round(valor,2); é o mesmo que .toFixed(2) em JS, ele faz o numero ficar em decimal
        }

        /*public void exibe()
        {
            Console.WriteLine($"Olá {nome}, aqui estão as suas informaçoes de cadastro");
            Console.WriteLine($"Curso:{curso} | RA:{ra} | {semestre} Semestre | Faltas: {faltas}|  Nota P1:{p1} Nota P2 {p2} | Media: {media}");
        }*/
    }

    public class calculos : registro
    {
        public void confere()
        {
            if (media < 5)
            {
                Console.Write("Insira sua nota da P3:");
                p3 = double.Parse(Console.ReadLine());
                situacaop3 = true;
            }
            else
            {
                situacaop3 = false;
            }
            if (p3 > p2)
            {
                p2 = p3;
                media = (p1 + p2 * 2) / 3;
            }
            else
            {
                exame = true;
            }
            if (media < 5)
            {
                exame = true;
            } else
            {
                exame = false;
            }
            mediadecimal = Math.Round(media, 2);

        }

        public void mostra()
        {
            Console.Clear();
            Console.WriteLine("Olá, seja bem vindo ao sistema de registro e conferência, made by flavio08-20 on GitHub");
            Console.WriteLine("================ + + ================");
            if (exame == false && situacaop3 == false)
            { 
                Console.WriteLine($"Parábens aluno: {nome} || RA: {ra}, Você foi aprovado no {semestre}°Semestre do curso {curso}");
                Console.WriteLine("Você finalizou o semestre com esses dados:");
                Console.WriteLine($"Nota P1:{p1} || Nota P2:{p2} || Faltas:{faltas} || Media: {mediadecimal}");
            } else if (exame == false && situacaop3 == true)
            {
                Console.WriteLine($"Parábens aluno: {nome} || RA: {ra}, Você foi aprovado no {semestre}°Semestre do curso {curso}");
                Console.WriteLine("Você finalizou o semestre com esses dados:");
                Console.WriteLine($"Nota P1:{p1} || Nota P2:{p2} || Nota P3:{p3} || Faltas:{faltas} || Media: {mediadecimal}");
            } else if (exame == true)
            {
                Console.WriteLine($"Sinto muito aluno:{nome} || RA: {ra}, Você foi reprovado no {semestre}°Semestre do curso {curso}");
                Console.WriteLine("Você finalizou o semestre com esses dados:");
                Console.WriteLine($"Nota P1:{p1} || Nota P2:{p2} || Nota P3:{p3} || Faltas:{faltas} || Media: {mediadecimal}");
            }
        }
    }
    static void Main(string [] args) //coloquei string pq oque é apresentado é uma string
    { 
      
        calculos oi = new calculos();
        oi.preenche();
        oi.confere();
        oi.mostra();
      //importante criar somente um objeto nesse caso para os dados se manterem e viajarem entre os campos
    }
}