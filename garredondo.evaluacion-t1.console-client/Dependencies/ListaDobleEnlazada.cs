using System;

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
            /// Debe haber, al menos, dos elementos
            if (_length <= 1)
                return;

            /// No se cambia sobre la misma posición
            if (posicionA == posicionB)
                return;

            /// Nos aseguramos que posicionA < posicionB
            if (posicionA > posicionB)
                CambiarValores(ref posicionA, ref posicionB);

            /// Ubicamos cada nodo según el índice
            var nodoA = ObtenerNodoPorIndice(posicionA);
            var nodoB = ObtenerNodoPorIndice(posicionB);

            /// Si cualquiera es nulo, no hay cambio
            if (nodoA == null && nodoB == null)
                return;

            /// Captura los nodos contiguos a los que intercambiarán
            var nodoA_Anterior = nodoA.Anterior;
            var nodoA_Siguiente = nodoA.Siguiente;
            var nodoB_Anterior = nodoB.Anterior;
            var nodoB_Siguiente = nodoB.Siguiente;

            /// ¿posicionA y posicionB son contiguas?
            var sonContiguos = SonPosicionesContiguas(posicionA, posicionB);

            /// Desconecta los contiguos
            if (nodoA_Siguiente != null)
                nodoA_Siguiente.Anterior = nodoB;

            if (nodoA_Anterior != null)
                nodoA_Anterior.Siguiente = nodoB;

            if (nodoB_Siguiente != null)
                nodoB_Siguiente.Anterior = nodoA;

            if (nodoB_Anterior != null)
                nodoB_Anterior.Siguiente = nodoA;

            /// Actualiza anteriores y siguientes según si son contiguos
            nodoA.Anterior = sonContiguos ? nodoB : nodoB_Anterior;
            nodoA.Siguiente = nodoB_Siguiente;
            nodoB.Anterior = nodoA_Anterior;
            nodoB.Siguiente = sonContiguos ? nodoA : nodoA_Siguiente;

            /// Actualiza los punteros a Inicial, Actual
            if (posicionA == 1)
                _inicial = nodoB;

            if (posicionA == _length)
                _actual = nodoB;

            if (posicionB == 1)
                _inicial = nodoA;

            if (posicionB == _length)
                _actual = nodoA;
        }

        public void Eliminar(int posicion)
        {
            if (IndiceFueraDeRango(posicion))
                return;

            var nodoEliminar = ObtenerNodoPorIndice(posicion);

            if (nodoEliminar.Anterior != null)
                nodoEliminar.Anterior.Siguiente = nodoEliminar.Siguiente;

            if (nodoEliminar.Siguiente != null)
                nodoEliminar.Siguiente.Anterior = nodoEliminar.Anterior;

            _length--; // cuenta un elemento menos
        }

        public void Ordenar()
        {
            var nodoCompara = _inicial;
            var posicionCompara = 1;

            var nodoCambio = _inicial.Siguiente;
            var posicionCambio = 2;

            while (nodoCompara != null && nodoCambio != null)
            {
                var comparacion = string.Compare(nodoCompara.Elemento.ToString(), nodoCambio.Elemento.ToString());

                if (comparacion > 0)
                {
                    Intercambiar(posicionCambio, posicionCompara);
                    posicionCompara = 1;
                    nodoCompara = _inicial;
                }
                posicionCambio++;
                nodoCambio = ObtenerNodoPorIndice(posicionCambio);
            }
        }
        #endregion

        #region Auxiliares
        private bool EsListaVacia()
        {
            return _inicial == null;
        }

        private bool SonPosicionesContiguas(int i, int j)
        {
            return (i + 1 == j);
        }

        private void CambiarValores(ref int i, ref int j)
        {
            var temp = i; i = j; j = temp;
        }

        private bool IndiceFueraDeRango(int posicion)
        {
            return (posicion < 1 || posicion > _length);
        }

        private Nodo<T> ObtenerNodoPorIndice(int posicion)
        {
            if (IndiceFueraDeRango(posicion))
                return null;

            int posicionActual = 1;
            Nodo<T> nodoActual = _inicial;

            while (posicionActual < posicion)
            {
                nodoActual = nodoActual.Siguiente;
                posicionActual++;
            }

            return nodoActual;
        }

        public void Imprimir()
        {
            if (EsListaVacia())
                return;

            Nodo<T> nodoActual = _inicial;
            Console.WriteLine("Lista:");

            while (nodoActual != null)
            {
                Console.WriteLine(nodoActual.Elemento);
                nodoActual = nodoActual.Siguiente;
            }
            Console.WriteLine("----");
        }
        #endregion
    }
}
