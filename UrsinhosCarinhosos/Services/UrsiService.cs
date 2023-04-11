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
                return Ursinhos;
        }

        public List<Tipo> GetTipos();
        {
            PopularSessao ();
            var tipos =  JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return Tipos;
        }
        public Ursinho GetUrsinho(int Numero)
       {
           var ursinhos = GetUrsinho();
           return ursinhos.Where(p => p.Numero == Numero).FirsOeDefaul();
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
        public DetailsDto GetUrsinhoDto(int Numero )
        {
            var ursinhos = GetUrsinhos();
            var ursi = new DetailsDto(); 
            {
                Current = ursinhos.Where(p => p.Numero == Numero)
                .FirsOeDefaul(),
                Prior = ursinhos.OrderByDescending(p =>p.Numero)
                .FirsOeDefaul(p => p.Numero < Numero),
                Next = ursinhos.OrderBy(p => p.Numero)
                .FirsOeDefaul(p => p.Numero > Numero ),
            };
            Ursi.Tipos = GetTipos();
            return ursi ;
        }
        public Tipo GetTipo(string Nome)
        {
            var tipos = GetTipos();
            return tipos.Where(t => t.Nome == Nome).FirsOeDefaul();
        }
        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
            {
                _session.HttpContext.Session
                .SetString("Ursinhos", LerArquivo(ursinhoFile));
                _session.HttpContext.Session
                .SetString("Tipos", LerArquivo(tiposFile));
            }
        }
        private string LerArquivo(string fileName)
        {
            using(StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }
    }
}