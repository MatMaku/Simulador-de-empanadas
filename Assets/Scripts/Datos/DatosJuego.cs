[System.Serializable]
public class DatosJuego
{
    public int diaActual;
    public int propinasAcumuladas;

    public bool MejoraCocina;
    public bool MejoraCuchillo;
    public bool MejoraPalo;


    public DatosJuego(int dia, int propinas)
    {
        diaActual = dia;
        propinasAcumuladas = propinas;

        MejoraCocina = false;
        MejoraCuchillo = false;
        MejoraPalo = false;
    }
}
