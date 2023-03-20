using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Core.Models
{
    public class Questions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        [Required]
        public string? Answer { get; set; }
        public int AnswerId { get; set; }
    }
}
