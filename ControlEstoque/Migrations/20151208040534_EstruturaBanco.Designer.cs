using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ControlEstoque.Models;

namespace ControlEstoque.Migrations
{
    [DbContext(typeof(DadosContexto))]
    [Migration("20151208040534_EstruturaBanco")]
    partial class EstruturaBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("ControlEstoque.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("NrPedido");

                    b.Property<int?>("PessoaPessoaId");

                    b.Property<int?>("ProdutoProdutoId");

                    b.HasKey("PedidoId");
                });

            modelBuilder.Entity("ControlEstoque.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("PessoaId");
                });

            modelBuilder.Entity("ControlEstoque.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ProdutoId");
                });

            modelBuilder.Entity("ControlEstoque.Models.Pedido", b =>
                {
                    b.HasOne("ControlEstoque.Models.Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaPessoaId");

                    b.HasOne("ControlEstoque.Models.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoProdutoId");
                });
        }
    }
}
