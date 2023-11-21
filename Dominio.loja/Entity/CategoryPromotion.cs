﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class CategoryPromotion : MasterEntity
    {
        [Key]
        public int CategoriesPromotion { get; set; }
        public Categories Category { get; set; }
        public int DisplayOrder { get; set; }
    }
}
