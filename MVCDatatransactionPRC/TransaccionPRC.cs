using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDatatransactionBD;

namespace MVCDatatransactionPRC
{
    // ===========================================================================
    /// <summary>
    /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
    /// Create date: Apr  9 2020  3:42PM
    /// Procedimiento almacenado que genera Script de Clases PRC de la capa BD
    /// CLASE CONSTRUCTOR, INSERT, UPDATE, DELETE Y SELECT de tablas de Bases de Datos
    /// </summary>

    public class TransaccionPRC
    {

        TransaccionBD BDTransaccion = new TransaccionBD();


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

        public TransaccionPRC()
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
        /// Create date: Apr  9 2020  3:42PM
        /// Método que permite insertar en la tabla Transaccion capa PRC
        /// </summary>
        // ******************* = Método Insert = ******************************
        public void Transaccion_Insert(string tra_accountnumber, string tra_beneficiaryname, string tra_bankname, string tra_SWIFTCode, int tra_amount, DateTime tra_datetime)
        {
            try
            {
                BDTransaccion.Transaccion_Insert(tra_accountnumber, tra_beneficiaryname, tra_bankname, tra_SWIFTCode, tra_amount, tra_datetime);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:42PM
        /// Método que permite actualizar en la tabla Transaccion capa PRC
        /// </summary>
        // ******************* = Método Update = ******************************
        public void Transaccion_Update(int tra_id, string tra_accountnumber, string tra_beneficiaryname, string tra_bankname, string tra_SWIFTCode, int tra_amount, DateTime tra_datetime)
        {
            try
            {
                BDTransaccion.Transaccion_Update(tra_id, tra_accountnumber, tra_beneficiaryname, tra_bankname, tra_SWIFTCode, tra_amount, tra_datetime);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:42PM
        /// Método que permite eliminar en la tabla Transaccion capa PRC
        /// </summary>
        // ******************* = Método Delete = ******************************
        public void Transaccion_Delete(int tra_id)
        {
            try
            {
                BDTransaccion.Transaccion_Delete(tra_id);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        // ===========================================================================
        /// <summary>
        /// Author     : MARCO ANTONIO MARTINEZ LOPEZ
        /// Create date: Apr  9 2020  3:42PM
        /// Método que permite listar de la tabla Transaccion capa PRC
        /// </summary>
        // ******************* = Método List = ******************************
        public List<Transaccion_List_Result> Transaccion_List(int tra_id)
        {
            try
            {
                var Transaccion = (from TTransaccion in BDTransaccion.Transaccion_List(tra_id) select TTransaccion).ToList();
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
