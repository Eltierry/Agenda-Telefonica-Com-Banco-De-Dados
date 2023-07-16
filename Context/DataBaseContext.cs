using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonicaComBancoDeDados.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonicaComBancoDeDados.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=localhost;port=3306;userid=root;password=;database=MinhaAgenda", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"))
            string conectionString = "server=localhost;port=3306;userid=root;password=123456789;database=MinhaAgenda";
            var serverConncetion = ServerVersion.AutoDetect(conectionString);
            optionsBuilder.UseMySql(conectionString, serverConncetion);
        }
    }
}