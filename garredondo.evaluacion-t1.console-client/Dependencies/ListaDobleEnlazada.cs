namespace garredondo.evaluacion_t1.console_client.Dependencies
{
    public class ListaDobleEnlazada<T> : IListaDobleEnlazada<T>
    {
        private Nodo<T> _inicial;
        private Nodo<T> _actual;
        private int _length;

        public ListaDobleEnlazada()
        {
            _inicial = _actual = null;
            _length = 0;
        }

        public ListaDobleEnlazada(T elemento)
        {
            var nodo = new Nodo<T>(elemento);
            _inicial = _actual = nodo;
            _length = 1;
        }

        public Nodo<T> Inicial { get => _inicial; set => _inicial = value; }
        public Nodo<T> Actual { get => _actual; set => _actual = value; }
        public int Length { get => _length; }

        public void Agregar(T elemento)
        {
            var nodo = new Nodo<T>(elemento);

            if (_actual == null)
            {
                _inicial = nodo;
            }
            else
            {
                nodo.Anterior = _actual;
                _actual.Siguiente = nodo;
            }
            _actual = nodo; // hay un nuevo último nodo
            _length++; // cuenta un elemento más
        }

        #region PreguntasT1
        public void Intercambiar(int posicionA, int posicionB)
        {
            if (_length > 1) // solo aplica si 
            {

            }
        }

        public void Eliminar(int posicion)
        {
            throw new System.NotImplementedException();
        }

        public void Ordenar()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Auxiliares
        private bool EsListaVacia()
        {
            return _inicial == null;
        }
        #endregion
    }
}
