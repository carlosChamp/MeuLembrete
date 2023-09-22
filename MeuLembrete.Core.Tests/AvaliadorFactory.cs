using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLembreteCore.Tests
{
    public class AvaliadorFactoryTests
    {
        [Fact]
        public void AvaliadorFactory_DeveInstanciarTodosOsTiposDeIntervalo()
        {
            foreach (var tipo in Enum.GetValues(typeof(TipoIntervalo)))
            {
                AvaliadorFactory.Create((TipoIntervalo)tipo);
            }
        }
    }
}
