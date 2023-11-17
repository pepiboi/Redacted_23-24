using Fruehwarnungen.Dtos;

namespace Fruehwarnungen.Services
{
    public class FruehwarnungenService
    {
        private List<string> _faecher;
        private List<string> _clazz;
        private List<PersonDto> _personen;

        public FruehwarnungenService()
        {
            _faecher = new List<string> { "AM", "D", "E1", "NAWI", "SYP1", "POS1", "BWM_1", "NVS1", "DBI_1" };
            _clazz = new List<string> { "1A", "1B", "1C", "1M", "2A", "2B", "2C", "2M", "3A", "3B", "3C", "3M", "4A", "4B", "4C", "4M", "5A", "5B", "5C", "5M" };
            _personen = InitPersons();
        }

        public List<string> GetClazzes()
        {
            return _clazz;
        }

        public List<string> GetFaecher(string clazz)
        {
            var faecherByClazz = InitFaecherByClazz();

            return faecherByClazz.Where(x => x.clazz.Equals(clazz)).Select(x => x.fach).ToList();
        }

        public List<PersonDto> GetPersons(string clazz)
        {
            return _personen.Where(x => x.clazz == clazz).ToList();
        }

        public bool PostFruehwarnung(PostDto post)
        {
            try
            {
                if (_personen.Where(x => x.id == post.personId).FirstOrDefault().fachFruehwarnungDto.Where(x => x.fach == post.fach).FirstOrDefault().fruehwarnung)
                {
                    return false;
                }
                _personen.Where(x => x.id == post.personId).FirstOrDefault().fachFruehwarnungDto.Where(x => x.fach == post.fach).FirstOrDefault().fruehwarnung = true;
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        private List<FilterDto> InitFaecherByClazz()
        {
            var listFilter = new List<FilterDto>();

            foreach (string fach in _faecher)
            {
                foreach(string clazz in _clazz)
                {
                    listFilter.Add(new FilterDto(clazz, fach));
                }
            }

            return listFilter;
        }

        private List<PersonDto> InitPersons()
        {
            List<FachFruehwarnungDto> faecher = new List<FachFruehwarnungDto>();

            foreach(string fach in _faecher)
            {
                faecher.Add(new FachFruehwarnungDto(fach, false));
            }
            return new List<PersonDto> { new PersonDto( 0, "Kaan Yilmaz", 18, "YilmazK190043@sus.htl-grieskirchen.at", "5C", faecher), 
                new PersonDto( 1, "Petar Invanovic", 18, "IvanovicP190069@sus.htl-grieskirchen.at", "5A", faecher),
                new PersonDto( 2, "Petar Golub", 18, "GolubP190058@sus.htl-grieskirchen.at", "5B", faecher) };
        }

        public string GetCurrentUserName()
        {
            return "Grüneis Robert";
        }
    }
}
