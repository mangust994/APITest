using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AnimeUserModel User { get; set; }
        public int? CompositionId { get; set; }
        public CompositionModel Composition { get; set; }
        public string Text { get; set; }
        public int ComMark { get; set; }
        public DateTime Date { get; set; }
    }
}
