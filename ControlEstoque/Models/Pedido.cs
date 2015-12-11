using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEstoque.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public string NrPedido { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual Pessoa Pessoa{ get; set; }
        public virtual Produto Produto { get; set; }
    }
}
