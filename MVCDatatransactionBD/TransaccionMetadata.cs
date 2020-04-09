using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDatatransactionBD
{
    [MetadataType(typeof(Transaccion.Metadata))]
    public partial class Transaccion
    {
        sealed class Metadata
        {
            [DisplayName("ID")]
            public int tra_id { get; set; }

            [DisplayName("NumeroCuenta")]
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            [StringLength(12)]
            public string tra_accountnumber { get; set; }

            [DisplayName("Beneficiario")]
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            [StringLength(100)]
            public string tra_beneficiaryname { get; set; }

            [DisplayName("Banco")]
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            [StringLength(100)]
            public string tra_bankname { get; set; }

            [DisplayName("SWIFTCode")]
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            [StringLength(11)]
            public string tra_SWIFTCode { get; set; }

            [DisplayName("Cantidad")]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            public Nullable<int> tra_amount { get; set; }

            [DisplayName("Fecha")]
            [DataType(DataType.DateTime)]
            [Required(ErrorMessage = "Debe ingresar el {0}")]
            public Nullable<System.DateTime> tra_datetime { get; set; }
        }
    }
}
