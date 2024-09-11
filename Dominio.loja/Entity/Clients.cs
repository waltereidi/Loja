using Framework.loja;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.loja.Entity
{
    [Table("clients")]
    public class Clients : Entity<int?>
    {


        [StringLength(120)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Password { get; set; }
        [ForeignKey("PermissionsGroupId")]
        public int PermissionsGroupId { get; set; }
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public virtual PermissionsGroup? PermissionsGroup { get; set; }
    
        protected override void When(object @event)
        {
            switch(@event)
            {
                case 
            }
        }
    }
}