using BAM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM.Entities.Abstract
{
    public abstract class Base : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
