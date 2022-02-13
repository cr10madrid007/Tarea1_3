using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Tarea1_3.Models;
using System.Threading.Tasks;

namespace Tarea1_3.Models
{
    public class EmpleDB
    {
        readonly SQLiteAsyncConnection db;

        //Contructor de clase vacio

        public EmpleDB()
        {
        }

        // contructor de parametros
        public EmpleDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // -- Creación de tablas de base de datos
            db.CreateTableAsync<Empleados>();

        }

        // procedimientos y funciones necesarias
        //retorna la tabla empleados como lista
        public Task<List<Empleados>> listaempleados()
        {

            return db.Table<Empleados>().ToListAsync();
        }

        // buscar un empleado especifico por el codigo
        public Task<Empleados> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<Empleados>().Where(i => i.codigo == pcodigo).FirstOrDefaultAsync();
        }


        // Guardar o actualizar empleado

        public Task<Int32> EmpleadoGuardar(Empleados emple)
        {
            if (emple.codigo != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        //Eliminar empleado

        public Task<Int32> EmpleadoBorrar(Empleados emple)
        {
            return db.DeleteAsync(emple);
        }


    }
}
