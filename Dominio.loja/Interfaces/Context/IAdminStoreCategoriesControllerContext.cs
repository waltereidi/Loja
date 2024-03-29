﻿using Dominio.loja.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.loja.Interfaces.Context
{
    public interface IAdminStoreCategoriesControllerContext: IDbContext
    {
        DbSet<Categories> categories { get; set; }
        DbSet<SubCategories> subCategories { get; set; }
        DbSet<SubSubCategories> subSubCategories { get; set; }
    }
}
