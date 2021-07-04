using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giercownia.NET_JS.Models
{
    public class Score
    {
        [Required]
        public int Id { get; set; }

        public int Points { get; set; }
        public int GameId { get; set; }
        public string AppUserId { get; set; }
        public Game Game { get; set; }
        public AppUser AppUser { get; set; }
    }
}
