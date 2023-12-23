﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class RequestOrders : MasterEntity
    {
        [Key]
        public int ID_RequestOrders { get; set; }
        [StringLength(2048)]
        public string Descrption { get; set; }

    }
}