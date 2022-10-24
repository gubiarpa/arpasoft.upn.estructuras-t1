namespace garredondo.evaluacion_t1.console_client.Dependencies
{
    public interface IListaDobleEnlazada<T>
    {
        void Intercambiar(int posicionA, int posicionB);
        void Eliminar(int posicion);
        void Ordenar();
    }
}
