﻿using Connection_To_DataBaseCSharpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.DataBase
{ // a utilidade do generics se dá quando entedemos que estamos com duas classes DAL com os mesmos códigos, mesmos métodos
  //se quisermos otimizar isso precisaremos da utilização do generics, genericsDAL
    internal class ContaDAL:DAL<Contas>
    {
        //no nosso construtor do contaDAL, vai receber o contexto da classe DAL, usamos a :base que representa a superclasse (DAL) e dizemos
        //que pegaremos o contexto de lá.
        public ContaDAL(GerenciadorContext context) : base(context) { }

        public override IEnumerable<Contas> Listar()
        {
                return context.Contas.ToList();
        }

        public override void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("## ADICIONAR CONTA ##");
            Console.WriteLine();
            Console.WriteLine("Digite o Titular da Conta");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o Numero da Conta");
            int numeroC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Saldo");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());
            var novaConta = new Contas(nome,numeroC,saldo);

            try
            {
                context.Contas.Add(novaConta);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine();
            Console.WriteLine("Conta adicionada!");

            Thread.Sleep(15000);
            new MenuConta().Menu();
        }
        
        public override void Atualizar()
        {
            Console.Clear();
            Console.WriteLine("## ATUALIZAR CONTA ##");
            Console.WriteLine();

            Console.WriteLine("Digite o Id da conta que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id != null)
            {
                var conta = context.Contas.Find(id);

                Console.WriteLine("Digite o novo Titular da conta:");
                string novoNome = Console.ReadLine();
                conta.Nome = novoNome;
                context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Nome adicionado!");

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Conta não encontrada.");
            }

            Thread.Sleep(15000);
            new MenuConta().Menu();
        }

        public override void Remover()
        {
            Console.Clear();
            Console.WriteLine("## REMOVER CONTA  ##");
            try
            {
                Console.WriteLine("Digite um Id para remover a conta");
                
                int id = Convert.ToInt32(Console.ReadLine());
                var conta = context.Contas.Find(id);

                context.Contas.Remove(conta);
                context.SaveChanges();
                Console.WriteLine(" Conta removida com sucesso!");

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Thread.Sleep(15000);
            new MenuConta().Menu();

        }

    }
}
