using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MongoJäsenrekisteri.Models
{
    public class Jasenet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public string Id { get; set; }

        [BsonElement("Etunimi")]
        [Required]
        public string Etunimi { get; set; }

        [BsonElement("Sukunimi")]
        [Required]
        public string Sukunimi { get; set; }

        [BsonElement("Osoite")]
        [Required]
        public string Osoite { get; set; }

        [BsonElement("Postinumero")]
        [Required]
        public string Postinumero { get; set; }

        [BsonElement("Puhelin")]
        [Required]
        public string Puhelin { get; set; }

        [BsonElement("Sähköposti")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Sähköposti pitää olla.")]
        public string Sähköposti { get; set; }

        [BsonElement("LiittymisPvm")]
        public DateTime LiittymisPvm { get; set; }
    }
}
