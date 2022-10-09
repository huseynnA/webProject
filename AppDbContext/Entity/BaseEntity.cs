using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public abstract class BaseEntity
    {
        public int Id{ get; set; }
        public DateTime CreateAt { get; set; } 
        
        public int CreatedUser { get; set; }
        public DateTime UpdateAt { get; set; } 
    
        public int UpdatedUser { get; set; }
    }
}
