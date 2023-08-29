using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CryptoApp.Models
{
    public class WalletUsers
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PublicAdress { get; set; }

        public int NumberTransactions { get; set; }

        public DateTime BuiltDate { get; set; }

        public bool ActiveInactive { get; set; }
        //add5
    }
   
}

