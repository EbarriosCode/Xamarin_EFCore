using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XamEFCore.Models
{
    public class IngenioSINS
    {
        public List<IngenioSINSResult> Result { get; set; }
    }

    public class IngenioSINSResult
    {
        public List<IngenioSINSRow> Rows { get; set; }
    }

    public class IngenioSINSRow
    {
        [Key]
        public int IngenioId { get; set; }
        public int IngenioSINSID { get; set; }
        public string RazonSocial { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public DateTime? HoraCorte { get; set; }
        public bool? Exportador { get; set; }
        public bool? Activo { get; set; }
        public bool? JumboPesoNominal { get; set; }
        public int? VersionJSONGuiaEnvio { get; set; }
        public int? VersionJSONNotaDePeso { get; set; }
        public int? VersionJSONGuiaEnvioMelaza { get; set; }
    }
}
