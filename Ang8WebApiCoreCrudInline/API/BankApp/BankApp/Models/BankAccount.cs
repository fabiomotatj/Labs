using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AccountHolder { get; set; }

        public int BankID { get; set; }

        [ForeignKey("BankID")]
        public virtual Bank Bank { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string IFSC { get; set; }
    }
}
