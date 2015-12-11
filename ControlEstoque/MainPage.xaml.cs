using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using pop = Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlEstoque
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public ObservableCollection<Models.Pessoa> listaPessoas { get; private set; } = new ObservableCollection<Models.Pessoa>();
        Pessoa pessoa;
        DadosContexto db = new DadosContexto();
        public MainPage()
        {
            this.InitializeComponent();
            CarregarListView();

        }

        private async void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (pessoa == null)
                {
                    pessoa = new Pessoa();
                    db.Pessoa.Add(pessoa);

                }
              
                pessoa.Nome = txtNome.Text;

                db.SaveChanges();
                pop.MessageDialog message = new pop.MessageDialog("Dado salvo no banco dados com sucesso");
                await message.ShowAsync();


                //Limpando campos
                pessoa = null;
                txtNome.Text = String.Empty;
                CarregarListView();
            }
            catch (Exception ex)
            {
                pop.MessageDialog message = new pop.MessageDialog("Erro ao cadastrar no banco de dados{0}", ex.Message);
                await message.ShowAsync();

            }

            //db.Pessoa.Add(new Pessoa()
            //{ 

            //    Nome = txtNome.Text,
            //});


            //db.SaveChangesAsync();
            //var l = db.Pessoa.ToList();
            //txtVer.Text = l[4].Nome;
            //var result = from pc in db.Pessoa orderby pc.PessoaId select pc;

            //foreach (var item in result)
            //{
            //    lstTeste.ItemsSource = item.Nome[0];
            //}
            CarregarListView();


        }
        private void CarregarListView()
        {
            List<Pessoa> lstPessoa = new List<Pessoa>();
            lstPessoa = db.Pessoa.ToList();
            lstTeste.Items.Clear();
            foreach (var item in lstPessoa)
            {
                lstTeste.Items.Add(string.Format("{0}-{1}", item.PessoaId, item.Nome));
            }

        }

        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (pessoa != null)
                {
                    //pop.MessageDialog message = new pop.MessageDialog("Deseja Realmente Excluir?{0}");

                    //await message.ShowAsync();
                    //if (MessageBox.Show("Realmente gostaria de excluir o registro?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    db.Pessoa.Remove(pessoa);
                    db.SaveChanges();
                    //pop.MessageDialog message2 = new pop.MessageDialog("Dado excluido com sucesso{0}");
                    //await message2.ShowAsync();

                    //Limpando campos
                    pessoa = null;
                    txtNome.Text = String.Empty;
                    lstTeste.Items.Clear();
                    CarregarListView();
                }
            }
            catch (Exception ex) {
            }
        }

        private async void lstTeste_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string item = lstTeste.SelectedItem.ToString();

            //int pos = item.IndexOf("-");
            //int id = int.Parse(item.Substring(0, pos));
            //pop.MessageDialog message = new pop.MessageDialog("Valor Selecionado{0}", id.ToString());
            //pessoa = db.Pessoa.FirstOrDefault(p => p.PessoaId == id);
            //if (pessoa != null)
            //    txtNome.Text = pessoa.Nome;
            //await message.ShowAsync();
        }

        private async void lstTeste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lstTeste.SelectedItem?.ToString();
            if (item != null)
            {
                int pos = item.IndexOf("-", StringComparison.Ordinal);
                int id = int.Parse(item.Substring(0, pos));
                pop.MessageDialog message = new pop.MessageDialog("Valor Selecionado{0}", id.ToString());
                pessoa = db.Pessoa.FirstOrDefault(p => p.PessoaId == id);
                if (pessoa != null)
                    txtNome.Text = pessoa.Nome;
                await message.ShowAsync();
            }
        }

        private async void lstTeste_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
         
        }

        private async void lstTeste_ChoosingItemContainer(ListViewBase sender, ChoosingItemContainerEventArgs args)
        {
           

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            pessoa.Nome = txtNome.Text;
            db.SaveChanges();
            CarregarListView();
        }

        private void btnVerProdutos_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof (PaginaProdutos));
        }
    }
    
}


            
    
    
