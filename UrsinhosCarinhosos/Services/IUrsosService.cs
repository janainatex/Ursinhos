using UrsinhosCarinhosos.Models;
namespace UrsinhosCarinhosos.Services;

    public interface IUrsosService
    {
        List<Personagem> GetPersonagens();
        Personagem GetPersonagem(int Numero);
        UrsoDto GetUrsoDto();
        DetailsDto GetDetailedPersonagem(int numero);
    }
