
namespace CAE
{
    public class EmployeeEntity
    {
        //Propiedades tal cual esta en la DB
        public int IDEmpleados { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
