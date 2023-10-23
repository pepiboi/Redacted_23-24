namespace Fruehwarnungen.Dtos
{
    public class PersonDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string clazz { get; set; }
        public List<FachFruehwarnungDto> fachFruehwarnungDto { get; set; }

        public PersonDto(int id, string name, int age, string email, string clazz, List<FachFruehwarnungDto> fachFruehwarnungDto)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.clazz = clazz;
            this.fachFruehwarnungDto = fachFruehwarnungDto;
        }
    }
}
