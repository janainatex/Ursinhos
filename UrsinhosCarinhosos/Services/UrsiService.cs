using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsinhosCarinhosos.Services
{
    public class UrsiService : IUrsinhoService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string ursinhoFile = @"Data\Ursinhos.json";
        private readonly string tiposFile = @"Data\tipos.json";
        
        public UrsiService (IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }
       
         public List<Ursinho> GetUrsinhos()
       
        {
            PopularSessao ()
            var ursinhos = JsonSerializer.Deserialize<List<UrsinhosCarinhosos>>
                (_session.HttpContext.Session.GetString("Ursinhos"));
        }

        public List<Tipo> GetTipos();
        {
            PopularSessao ();
            var tipos =  JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return Tipos;
        }
        public UrsinhoDto GetUrsinhoDto(int Numero)
        {
            var ursinhos = GetUrsinhos();
            return ursinhos.Where(p => p.numero == Numero ).FirsOeDefaul();
        }
        public  UrsinhoDto GetUrsinhoDto()
        {
            var ursi = new UrsinhoDto()
            {
                Ursinhos = GetUrsinho(),
                Tipos = GetTipos()
            };
            return ursi ;
        }
        public DetailsDto Get
    }
}