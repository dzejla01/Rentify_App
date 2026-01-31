using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentify.Services.Database
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
        public string PropertyImg { get; set; }
        public bool IsMain { get; set; }

    }
}
