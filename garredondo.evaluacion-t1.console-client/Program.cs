using garredondo.evaluacion_t1.console_client.Dependencies;

namespace garredondo.evaluacion_t1.console_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IListaDobleEnlazada<string> listaDobleEnlazada = new ListaDobleEnlazada<string>();

            listaDobleEnlazada.Agregar("Aries");
            listaDobleEnlazada.Agregar("Tauro");
            listaDobleEnlazada.Agregar("Géminis");
            listaDobleEnlazada.Agregar("Cáncer");
            listaDobleEnlazada.Agregar("Leo");
            listaDobleEnlazada.Agregar("Virgo");
            listaDobleEnlazada.Agregar("Libra");
            listaDobleEnlazada.Agregar("Escórpio");
            listaDobleEnlazada.Agregar("Sagitario");
            listaDobleEnlazada.Agregar("Capricornio");
            listaDobleEnlazada.Agregar("Acuario");
            listaDobleEnlazada.Agregar("Piscis");

            //listaDobleEnlazada.Intercambiar(12, 6);

            //listaDobleEnlazada.Eliminar(2);

            //listaDobleEnlazada.Agregar("I");
            //listaDobleEnlazada.Agregar("E");
            //listaDobleEnlazada.Agregar("A");
            //listaDobleEnlazada.Agregar("U");
            //listaDobleEnlazada.Agregar("O");

            listaDobleEnlazada.Ordenar();

            listaDobleEnlazada.Imprimir();
        }
    }
}
