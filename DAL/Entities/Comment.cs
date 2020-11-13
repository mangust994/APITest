using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ClientProfile User { get; set; }
        public int? CompositionId { get; set; }
        public virtual Composition Composition { get; set; }
        public string Text { get; set; }
        public int ComMark { get; set; }
        public DateTime Date { get; set; }
    }
}
