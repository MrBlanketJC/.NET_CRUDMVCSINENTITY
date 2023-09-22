using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using CAE;

namespace CAD
{
    //Clase publoca que hereda de la clase ConnectionSQL
    public class EmployeeData : ConnectionToSQL
    {
        //Listar
        public List<EmployeeEntity> GetAll()
        {
            List<EmployeeEntity> misListas = new List<EmployeeEntity>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from empleados";
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            misListas.Add(new EmployeeEntity()
                            {
                                IDEmpleados = Convert.ToInt32(reader["IDEmpleados"]),
                                Apellidos = reader["Apellidos"].ToString(),
                                Nombres = reader["Nombres"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Pais = reader["Pais"].ToString(),
                                Provincia = reader["Provincia"].ToString(),
                                Canton = reader["Canton"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Estado = Convert.ToBoolean(reader["Estado"])
                            });
                        }
                    }
                }
            }
            return misListas;
        }

        //Insertar
        public bool Insert(EmployeeEntity employee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into Empleados (Apellidos, Nombres, Telefono, Correo, Pais, Provincia, Canton, Direccion, Estado)" +
                        "values (@apellidos, @nombres, @telefono, @correo, @pais, @provincia, @canton, @direccion, 1)";                    
                    cmd.Parameters.AddWithValue("@apellidos", employee.Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", employee.Nombres);
                    cmd.Parameters.AddWithValue("@telefono", employee.Telefono);
                    cmd.Parameters.AddWithValue("@correo", employee.Correo);
                    cmd.Parameters.AddWithValue("@pais", employee.Pais);
                    cmd.Parameters.AddWithValue("@provincia", employee.Provincia);
                    cmd.Parameters.AddWithValue("@canton", employee.Canton);
                    cmd.Parameters.AddWithValue("@direccion", employee.Direccion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    var ok = cmd.ExecuteNonQuery();
                    return (ok==1) ? true : false;
                }
            }
        }

        //Editar
        public bool Update(EmployeeEntity employee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "update Empleados set Apellidos=@apellidos, Nombres=@nombres, Telefono=@telefono, Correo=@correo, Pais=@pais, Provincia=@provincia, Canton=@canton, Direccion=@direccion " +
                        "where IDEmpleados=@idempleados";
                    cmd.Parameters.AddWithValue("@idempleados", employee.IDEmpleados);
                    cmd.Parameters.AddWithValue("@apellidos", employee.Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", employee.Nombres);
                    cmd.Parameters.AddWithValue("@telefono", employee.Telefono);
                    cmd.Parameters.AddWithValue("@correo", employee.Correo);
                    cmd.Parameters.AddWithValue("@pais", employee.Pais);
                    cmd.Parameters.AddWithValue("@provincia", employee.Provincia);
                    cmd.Parameters.AddWithValue("@canton", employee.Canton);
                    cmd.Parameters.AddWithValue("@direccion", employee.Direccion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    var ok = cmd.ExecuteNonQuery();
                    return (ok == 1) ? true : false;
                }
            }
        }

        //Eliminar
        public bool Delete(int IDEmployee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "update Empleados set Estado=0 where IDEmpleados=@idempleados";
                    cmd.Parameters.AddWithValue("@idempleados", IDEmployee);
                    cmd.CommandType = System.Data.CommandType.Text;
                    var ok = cmd.ExecuteNonQuery();
                    return (ok == 1) ? true : false;
                }
            }
        }
    }
}
