namespace Fruehwarnungen.Dtos
{
    public class FilterDto
    {
        public string clazz { get; set; }
        public string fach { get; set; }

        public FilterDto(string clazz, string fach)
        {
            this.clazz = clazz;
            this.fach = fach;
        }
    }
}
