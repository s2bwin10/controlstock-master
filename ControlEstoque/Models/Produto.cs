using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEstoque.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco
        {
            get
            {
                return Preco;
            }
            set
            {
                Preco = value;
            }
        }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
