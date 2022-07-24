using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Entity
    {
        private string _idContact = null;
        private string _genero_status;
        private string _status_estCivil;

        public string IdContact { get => _idContact; set => _idContact = value; }
        public string Genero_status { get => _genero_status; set => _genero_status = value; }
        public string Status_estCivil { get => _status_estCivil; set => _status_estCivil = value; }
    }
}
