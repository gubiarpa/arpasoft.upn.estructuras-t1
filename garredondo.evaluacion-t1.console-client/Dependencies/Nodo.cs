namespace garredondo.evaluacion_t1.console_client.Dependencies
{
    public class Nodo<T>
    {
        private T _elemento;
        private Nodo<T> _anterior;
        private Nodo<T> _siguiente;

        public Nodo(T elemento)
        {
            _elemento = elemento;
            _anterior = null;
            _siguiente = null;
        }

        public T Elemento { get => _elemento; set => _elemento = value; }
        public Nodo<T> Anterior { get => _anterior; set => _anterior = value; }
        public Nodo<T> Siguiente { get => _siguiente; set => _siguiente = value; }
    }
}
