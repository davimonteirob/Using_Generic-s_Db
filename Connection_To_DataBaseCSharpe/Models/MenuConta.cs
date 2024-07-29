﻿using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    internal class MenuConta
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U   C O N T A S  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar uma Conta");
            Console.WriteLine("# Digite 2 para Exibir as Contas");
            Console.WriteLine("# Digite 3 para Atualizar a Conta");
            Console.WriteLine("# Digite 4 para Deletar uma Conta");
            Console.WriteLine("# Digite 5 para Voltar ao Menu de Usuarios");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {
                case 1:
                    new ContaDAL(new UserContext()).AdicionarConta();
                    break;
                case 2:
                    new ContaDAL(new UserContext()).InformacoesConta();
                    break;
                case 3:
                    new ContaDAL(new UserContext()).AtualizarConta();
                    break;
                case 4:
                    new ContaDAL(new UserContext()).RemoverConta();
                    break;
                case 5:
                    new MenuUser().Menu_();
                    break;

                case 0: break;
            }
        }
    }
}
