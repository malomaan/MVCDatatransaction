using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDatatransactionBD
{
    // ===========================================================================
    /// <summary>
    /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
    /// Create date: Apr  9 2020  3:40PM
    /// Procedimiento almacenado que genera Script de Clases BD de Tablas
    /// CLASE CONSTRUCTOR, INSERT, UPDATE, DELETE Y SELECT de tablas de Bases de Datos
    /// </summary>

    public class TransaccionBD
    {
        MVCDatatransactionEntities BD = new MVCDatatransactionEntities();


        // ******************* = Costructor = ******************************
        // Declaración de variables
        int tra_id;
        string tra_accountnumber;
        string tra_beneficiaryname;
        string tra_bankname;
        string tra_SWIFTCode;
        int tra_amount;
        DateTime tra_datetime;

        // Deficinción de propiedades
        public int Tra_id { get; set; }
        public string Tra_accountnumber { get; set; }
        public string Tra_beneficiaryname { get; set; }
        public string Tra_bankname { get; set; }
        public string Tra_SWIFTCode { get; set; }
        public int Tra_amount { get; set; }
        public DateTime Tra_datetime { get; set; }

        public TransaccionBD()
        {
            tra_accountnumber = "";
            tra_beneficiaryname = "";
            tra_bankname = "";
            tra_SWIFTCode = "";
            tra_amount = 0;
            tra_datetime = DateTime.Now;
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:40PM
        /// Método que permite insertar en la tabla Transaccion capa BD
        /// </summary>
        // ******************* = Método Insert = ******************************
        public void Transaccion_Insert(string tra_accountnumber, string tra_beneficiaryname, string tra_bankname, string tra_SWIFTCode, int tra_amount, DateTime tra_datetime)
        {
            try
            {
                BD.Transaccion_Insert(tra_accountnumber, tra_beneficiaryname, tra_bankname, tra_SWIFTCode, tra_amount, tra_datetime);
                BD.SaveChanges();
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:40PM
        /// Método que permite actualizar en la tabla Transaccion capa BD
        /// </summary>
        // ******************* = Método Update = ******************************
        public void Transaccion_Update(int tra_id, string tra_accountnumber, string tra_beneficiaryname, string tra_bankname, string tra_SWIFTCode, int tra_amount, DateTime tra_datetime)
        {
            try
            {
                BD.Transaccion_Update(tra_id, tra_accountnumber, tra_beneficiaryname, tra_bankname, tra_SWIFTCode, tra_amount, tra_datetime);
                BD.SaveChanges();
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:40PM
        /// Método que permite eliminar en la tabla Transaccion capa BD
        /// </summary>
        // ******************* = Método Delete = ******************************
        public void Transaccion_Delete(int tra_id)
        {
            try
            {
                BD.Transaccion_Delete(tra_id);
                BD.SaveChanges();
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:40PM
        /// Método que permite listar de la tabla Transaccion capa BD
        /// </summary>
        // ******************* = Método List = ******************************
        public List<Transaccion_List_Result> Transaccion_List(int tra_id)
        {
            try
            {
                var Transaccion = (from TTransaccion in BD.Transaccion_List(tra_id) select TTransaccion).ToList();
                return Transaccion;
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
    }
    //FIN DE LA CLASE


}
