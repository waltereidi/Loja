﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Entity
{
    public class PermissionsRelation : MasterEntity 
    {
        [Key]
        public int ID_Permissions_Relation { get; set; }
        public int ID_PermissionsGroup { get; set; }
        public int ID_Permissions { get; set; }

        public PermissionsGroup PermissionsGroup { get; set; }
        public Permissions Permissions { get; set; }


    }
}