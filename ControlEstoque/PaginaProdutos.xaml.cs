using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ControlEstoque.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlEstoque
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaginaProdutos : Page
    {
        private readonly List<Produto> _produtos;
        Produto produto;
        DadosContexto dc = new DadosContexto();
        public PaginaProdutos()
        {
            this.InitializeComponent();

            //_produtos = new ListaProdutos().GetProdutos().Where(p=>p.Preco >=40).ToList();
            _produtos = new ListaProdutos().GetProdutos().ToList();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if(produto == null)
            {
                produto = new Produto();
                produto.Nome = txtProduto.Text;
                produto.Preco = double.Parse(txtPreco.Text);
                dc.Produto.Add(produto);
                dc.SaveChanges();
            }
           
            //limpando os campos
            produto = null;
        
            txtProduto.Text = string.Empty;
            txtPreco.Text = string.Empty;
            this.Frame.Navigate(typeof(PaginaProdutos));

        }

        private void btnNavegaCarrinho_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CarrinhoDeCompras));
        }
    }
}
