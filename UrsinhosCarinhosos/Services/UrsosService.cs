using System.Text.Json;
using UrsinhosCarinhosos.Models;

namespace UrsinhosCarinhosos.Services;

public class UrsosService : IUrsosService{
    private readonly IHttpContextAccessor _session;
    private readonly string personagemFile = @"Data\personagens.json";

    public UrsosService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Personagem> GetPersonagens(){
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<List<Personagem>>
            (_session.HttpContext.Session.GetString("Personagens"));
        return personagens;
    }

    public Personagem GetPersonagem(int Numero)
    {
        var personagens = GetPersonagens();
        return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public UrsoDto GetUrsoDto()
    {
        var perso = new UrsoDto()
        {
            Personagens = GetPersonagens()
        };
        return perso;
    }

    public DetailsDto GetDetailedPersonagem(int Numero)
    {
        var personagens = GetPersonagens();
        var perso = new DetailsDto()
        {
            Current = personagens.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
            Prior = personagens.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
            Next = personagens.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero),
        };
        return perso;
    }

    private void PopularSessao()
    {
        if(string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Personagens")))
        {
            _session.HttpContext.Session
                .SetString("Personagens", LerArquivo(personagemFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
} 
