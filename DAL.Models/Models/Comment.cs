using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required (ErrorMessage ="Name must not be empty")]
        public string Name { get; set; }
        [Required (ErrorMessage ="EMail must not be empty")]
        public string EMail { get; set; }
        [Required (ErrorMessage = "Comment must be not empty")]
        [StringLength(250, MinimumLength = 5, ErrorMessage ="Comment length less than 5 or more than 250")]
        public string Commentary { get; set; }
        public DateTime SendDate { get; set; }
    }
}
