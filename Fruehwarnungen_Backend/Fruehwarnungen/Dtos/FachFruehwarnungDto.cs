namespace Fruehwarnungen.Dtos
{
    public class FachFruehwarnungDto
    {
        public string fach { get; set; }
        public bool fruehwarnung { get; set; }

        public FachFruehwarnungDto(string fach, bool fruehwarnung)
        {
            this.fach = fach;
            this.fruehwarnung = fruehwarnung;
        }
    }
}
