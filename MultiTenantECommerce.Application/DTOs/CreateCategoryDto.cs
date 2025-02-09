using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Application.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }

}
