using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    public class PersonasNotificar
    {

        public String codDepartamento;
        public String codMunicipio;
        public String codigoDANE;
        public String tipoIdent;
        public String numIdent;
        public String primerNombre;
        public String segundoNombre;
        public String primerApellido;
        public String segundoApellido;
        public String direccion;
        public String telefono;
        public String tipoPersona;
        public Int64 IdTipoNotificante;
        public Int64 Id;

        public PersonasNotificar() { 
        }

        public PersonasNotificar(String codDepartamento, String codMunicipio, String codigoDANE, String tipoIdent,
            String numIdent, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
            String direccion, String telefono, String tipoPersona)
        {
            this.codDepartamento = codDepartamento;
            this.codMunicipio = codMunicipio;
            this.codigoDANE = codigoDANE; 
            this.tipoIdent = tipoIdent; 
            this.numIdent = numIdent; 
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido; 
            this.direccion = direccion;
            this.telefono = telefono; 
            this.tipoPersona = tipoPersona;
        }
    }
}
