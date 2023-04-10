using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsinhosCarinhosos.Services
{
    public interface IUrsinhoService
    {
        List<UrsinhosCarinhosos> GetUrsinhosCarinhosos ();
        UrsinhosCarinhosos GetUrsinhosCarinhosos(int Numero );
        UrsinhoDto GetUrsinhoDto ();
        DetailsDto GetDetailUrsinho(int Numero);
        Tipo GetTipo (string Nome);

    }
}