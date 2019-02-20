using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFull0aNuvem.Model.Context
{
    public class BDinicializador
    {
        public static void Inicializador(BdFoodContext context)
        {
            context.Database.EnsureCreated();

            // Procurar por permissoes
            if (context.Permissoes.Any()) { return; } //bd já foi inicializado

            var permissoes = new Permissao[]
                {
                    new  Permissao{Titulo="ARQUIVO",Permitir=true, PermissaoParentId=null},
                    new  Permissao{Titulo="CONTATO",Permitir=true, PermissaoParentId=1},
                    new  Permissao{Titulo="SAIR",Permitir=true, PermissaoParentId=1},
                    new  Permissao{Titulo="FINANCEIRO",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="SELECIONAR CAIXA",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="ABRIR CAIXA",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="FECHAR CAIXA",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="SANGRIA / REFORÇO DE CAIXA",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="TRANSFERIR DINHEIRO",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="RECEITAS E DESPESAS",Permitir=true, PermissaoParentId=5},
                    new  Permissao{Titulo="VENDAS",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="MESAS",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="COMANDAS",Permitir=true, PermissaoParentId=13},
                    new  Permissao{Titulo="BALCÃO",Permitir=true, PermissaoParentId=13},
                    new  Permissao{Titulo="VENDA RÁPIDA",Permitir=true, PermissaoParentId=13},
                    new  Permissao{Titulo="ENTREGA",Permitir=true, PermissaoParentId=13},
                    new  Permissao{Titulo="FILA DE PEDIDOS",Permitir=true, PermissaoParentId=13},
                    new  Permissao{Titulo="RELATÓRIOS",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="RELATÓRIOS DE VENDAS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIOS DE PEDIDOS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="VENDAS POR PRODUTO",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="VENDAS POR VENDEDOR",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="VENDAS POR CLIENTE",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="VENDAS POR PERÍODO",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="MOVIMENTAÇÃO DO CAIXA",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="PAGAMENTO DE CONTAS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="BALANÇO DE CONTAS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="FLUXO DE CAIXA",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE CHEQUES",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="ENTREGAS POR ENTREGADOR",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="COMPRA DE PRODUTOS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE PRODUTOS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE FUNCIONÁRIOS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE CLIENTES",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="CRÉDITOS DE CLIENTES",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE BAIRROS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="RELATÓRIO DE CARTEIRAS",Permitir=true, PermissaoParentId=19},
                    new  Permissao{Titulo="CADASTRO",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="PRODUTOS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="ESTOQUE",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="FORNECEDORES",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CLIENTES",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="MESAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="COMANDAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CEP",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="FUNCIONÁRIOS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="FUNÇÕES",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CONTAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="SERVIÇOS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CRÉDITOS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="FORMAS DE PAGAMENTO",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CARTÕES",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="BANCOS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CARTEIRAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="MOEDAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CAIXAS",Permitir=true, PermissaoParentId=39},
                    new  Permissao{Titulo="CONFIGURAÇÕES",Permitir=false, PermissaoParentId=null},
                    new  Permissao{Titulo="EMPRESA",Permitir=true, PermissaoParentId=58},
            };
        }
    }
}
