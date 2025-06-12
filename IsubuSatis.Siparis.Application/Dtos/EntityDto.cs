using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Dtos
{
    public abstract class EntityDto<T>
    {
        public T Id { get; set; }
    }
}
