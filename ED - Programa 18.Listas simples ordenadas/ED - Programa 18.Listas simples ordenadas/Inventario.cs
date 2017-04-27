using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_18.Listas_simples_ordenadas
{
    class Inventario
    {
        private Producto _inicio;

        public void agregar(Producto producto)
        {
            if (_inicio == null || producto.codigo < _inicio.codigo)
            {
                producto.siguiente = _inicio;
                _inicio = producto;
            }
            else
            {
                Producto auxiliar = _inicio;
                while (auxiliar.siguiente != null && producto.codigo > auxiliar.siguiente.codigo) //_codigo.Substring(0,1)>auxiliar.siguiente.codigo.Substring(0,1)
                    auxiliar = auxiliar.siguiente;
                producto.siguiente = auxiliar.siguiente;
                auxiliar.siguiente = producto;
            }
        }

        public void borrar(int codigo)
        {
            if (_inicio.codigo == codigo)
                _inicio = _inicio.siguiente;
            else
            {
                Producto auxiliar = _inicio;
                while (auxiliar.siguiente != null && codigo >  auxiliar.siguiente.codigo)
                    auxiliar = auxiliar.siguiente;
                if (auxiliar.siguiente != null && codigo == auxiliar.siguiente.codigo)
                    auxiliar.siguiente = auxiliar.siguiente.siguiente;
            }
        }

        public Producto buscar(int codigo)
        {
            Producto auxiliar = _inicio;
            //Esta muy bien pero valdría la pena validar que inicio sea diferente de null para que no haya problemas
            //eso lo recomiendo también en eliminar 
            while (auxiliar.siguiente != null && codigo > auxiliar.codigo)
                auxiliar = auxiliar.siguiente;
            if (auxiliar.codigo == codigo)
                return auxiliar;
            else
                return null;
        }

        public string reporte()
        {
            if (_inicio == null)
                return "No hay productos";
            else
            {
                string cadena = "";
                Producto auxiliar = _inicio;
                while (auxiliar.siguiente != null)
                {
                    cadena += auxiliar.ToString() + Environment.NewLine;
                    auxiliar = auxiliar.siguiente;
                }
                cadena += auxiliar.ToString() + Environment.NewLine;
                return cadena;
            }
        }
    }
}
