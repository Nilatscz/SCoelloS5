//using Microsoft.Maui.Controls.Compatibility.Platform.UWP;
using SCoelloS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Windows.Devices.Display.Core;

namespace SCoelloS5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
                conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
            Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Name = name };
                result= conn.Insert(person);
                StatusMessage = string.Format("Se insertar una persona", result, name);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al insertar una persona", name, ex.Message);
                
            }
        }
        public List<Persona> getAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al insertar al Listar", ex.Message);
            }
            return new List<Persona>();
        }
        public void Eliminarperson(int id,string name)
        {
           int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre que desea eliminar es requerido para confirmar su eliminacion");
                Persona person = new() { Name = name };             
                    result = conn.Delete<Persona>(id);
               

                StatusMessage = string.Format("Se elimino una persona", result, name);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al eliminar una persona, revisar si ingreso el nombre de la persona que desea eliminar", name, ex.Message);
            }
        }
        public void ActualizarPerson(int id,string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Name = name, Id=id};
                result = conn.Update(person);
                StatusMessage = string.Format("Se actualizo una persona", result, name);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al Actualizar una persona", name, ex.Message);
            }
        }
    }
}
