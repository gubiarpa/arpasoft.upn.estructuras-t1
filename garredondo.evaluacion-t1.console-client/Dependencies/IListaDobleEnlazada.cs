namespace garredondo.evaluacion_t1.console_client.Dependencies
{
    public interface IListaDobleEnlazada<T> : IVisualizacion
    {
        #region Preguntas-T1
        void Intercambiar(int posicionA, int posicionB);
        void Eliminar(int posicion);
        void Ordenar();
        #endregion

        void Agregar(T elemento);
    }
}
