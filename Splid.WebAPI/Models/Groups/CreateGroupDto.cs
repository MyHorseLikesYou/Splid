using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.WebAPI.Core.Models.Groups
{
    public class CreateGroupDto
    {
        public string Name { get; set; }
        public IEnumerable<string> Persons { get; set; }
    }
}
