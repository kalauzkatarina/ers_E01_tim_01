using Domain.Services;

namespace Services.EvidencijaServisi
{
    public class EvidencijaGarantovanoServis : IEvidencijaServis
    {
        private readonly string putanjaFajla = "evidencija_garantovano.txt";
        public bool EvidentirajIsporuku(string zapis)
        {
            //PITANJE: Kako da uradim try-catch blok pravilno?
            try
            {
                //upisivanje u fajl
                using (StreamWriter sw = new StreamWriter(putanjaFajla, true))
                {
                    sw.WriteLine(zapis);
                    return true;
                }
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
