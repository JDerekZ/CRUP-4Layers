using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data_Layer
{
    public class CD_Contacts
    {
        private BD_Connect connect = new BD_Connect();

        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();


        //for List
        public DataTable viewAll()
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Listar_Contactos";
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }

        //for SEARCH
        public DataTable Search(string name)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Buscar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@buscar", name);
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.ClosedsqlConnection();

            return table;
        }


        //For add
        public void Create_Contact(string name, string lastname, DateTime date, string direc, string gener, string estado_c, string phone, string email)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Crear_Contacto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@apellido", lastname);
            cmd.Parameters.AddWithValue("@fechaN", date);
            cmd.Parameters.AddWithValue("@direccion", direc);
            cmd.Parameters.AddWithValue("@genero", gener);
            cmd.Parameters.AddWithValue("@estado_c", estado_c);
            cmd.Parameters.AddWithValue("@telefono", phone);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }


        //For Edit
        public void Edit_Contact(string name, string lastname, DateTime date, string direc, string gener, string estado_c, string phone, string email, int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Editar_Contacto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@apellido", lastname);
            cmd.Parameters.AddWithValue("@fechaN", date);
            cmd.Parameters.AddWithValue("@direccion", direc);
            cmd.Parameters.AddWithValue("@genero", gener);
            cmd.Parameters.AddWithValue("@estado_c", estado_c);
            cmd.Parameters.AddWithValue("@telefono", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }


        //For Delete
        public void Delete_Contact(int id)
        {
            cmd.Connection = connect.OpensqlConnection();
            cmd.CommandText = "SP_Eliminar_Contacto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            connect.ClosedsqlConnection();
        }
    }
}
