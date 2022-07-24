using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Data_Layer;

namespace Logic_Layer
{
    public class Tools_Contact
    {
        private CD_Contacts cD_Contacts = new CD_Contacts();


        //Method to List the Contacts
        public DataTable ViewAllContacts()
        {
            DataTable table = new DataTable();
            table = cD_Contacts.viewAll();
            return table;
        }

        //Method to Search
        public DataTable SearchContact(string name)
        {
            DataTable table = new DataTable();
            table = cD_Contacts.Search(name);
            return table;
        }


        //Method to Add Contacts
        public void Create_Contact(string name, string lastname, DateTime date, string direc, string gener, string estado_c, string phone, string email)
        {

            cD_Contacts.Create_Contact(name, lastname, date, direc, gener, estado_c, phone, email);

        }

        //Method to Edit the Contacts
        public void Edit_Contact(string name, string lastname, DateTime date, string direc, string gener, string estado_c, string phone, string email, string id)
        {
            cD_Contacts.Edit_Contact(name, lastname, date, direc, gener, estado_c, phone, email, Convert.ToInt32(id));
        }

        //Method to Delete
        public void Delete_Contact(string id)
        {
            cD_Contacts.Delete_Contact(Convert.ToInt32(id));
        }

    }
}
