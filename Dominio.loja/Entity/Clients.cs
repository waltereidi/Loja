using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.loja.Entity
{
    [Table("clients")]
    public class Clients : Entity<int>
    {


        [StringLength(320)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }
        [ForeignKey("PermissionsGroupId")]
        public int PermissionsGroupId { get; set; }
        public virtual PermissionsGroup? PermissionsGroup { get; set; }
        public virtual ICollection<ClientsProductsCart> ClientsProductsCart { get; set; }

    
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}