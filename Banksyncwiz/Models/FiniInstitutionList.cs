using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Banksyncwiz.Models
{
    public record FiniInstitutListDataAttrib
    {
        public int id { get; set; }
        public string? name { get; set; }
        [JsonPropertyName("url_home_app")]
        public string? urlHomeApp { get; set; }
        public string? urlLoginApp { get; set; }
        public bool? oauthEnabled { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? postalCode { get; set; }
        public string? email { get; set; }
    }

    public record FiniInstitutListData
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public FiniInstitutListDataAttrib? attributes { get; set; }
    }

    public record FiniInstitutList
    {
        public List<FiniInstitutListData>? data { get; set; }
    }
}
