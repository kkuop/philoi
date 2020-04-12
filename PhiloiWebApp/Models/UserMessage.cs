using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Models
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public int RecipientUserId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User Sender { get; set; }
        

    }
}
