using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Core.Models
{
    public class Questions
    {
        public Guid Id { get; set; }
        public string? Question { get; set; }
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public int AnswerId { get; set; }
    }
}
