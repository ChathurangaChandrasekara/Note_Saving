using System;
using System.ComponentModel.DataAnnotations;

namespace Note_Taking.DTOModels
{
    public class NoteDTO
    {
        
        public int NoteId { get; set; }

        public string Title { get; set; }

        [Display(Name ="Note")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name ="Create Date"),DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Update Date"), DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

    }
}
