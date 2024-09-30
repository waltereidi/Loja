using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Events.FileUpload
{
    public class Video : FileType
    {
        public List<Dimensions> Dimensions { get; set; }
        public int Duration { get; set; }

        public override void IsValid(object ft)
        {
            throw new NotImplementedException();
        }
    }
}
