using System;
using System.ComponentModel.DataAnnotations;

namespace Note_Taking.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

    }
}
