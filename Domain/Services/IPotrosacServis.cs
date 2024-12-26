namespace Domain.Services
{
    public interface IPotrosacServis
    {
        public double PregledTrenutnogZaduzenja(Guid id);
        public bool PotrosacZahtev(Guid id, double kolicinaKW);

    }
}
