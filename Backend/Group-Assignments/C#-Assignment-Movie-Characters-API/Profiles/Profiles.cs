using AutoMapper;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie,MovieDTO>();
                
            CreateMap<CharacterDTO, Character>();
            CreateMap<Character, CharacterDTO>();

            CreateMap<FranchiseDTO, Franchise>();
            CreateMap<Franchise, FranchiseDTO>();
        }
    }
}