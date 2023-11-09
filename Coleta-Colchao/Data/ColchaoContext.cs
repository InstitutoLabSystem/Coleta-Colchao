﻿using Coleta_Colchao.Models;
using Microsoft.EntityFrameworkCore;

namespace Coleta_Colchao.Data
{
    public class ColchaoContext : DbContext
    {
        public ColchaoContext(DbContextOptions<ColchaoContext> options) : base(options)
        {
        }
        public DbSet <ColetaModel.Registro> regtro_colchao { get; set; }  
    }

}
