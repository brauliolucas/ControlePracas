using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlePracas.Models;

namespace ControlePracas.DAL
{
    public class PracaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PracaContext>
    {
        protected override void Seed(PracaContext context)
        {
            var pracas = new List<Praca>
            {
                new Praca{Nome="ABAETETUBA", Sigla="ABA",UF="PA"},
                new Praca{Nome="ABELARDO LUZ", Sigla="AUZ",UF="SC"},
                new Praca{Nome="ABREU E LIMA", Sigla="ABL",UF="PE"},
                new Praca{Nome="AC-ESTADO", Sigla="ACE",UF="AC"},
                new Praca{Nome="ACAILANDIA", Sigla="ACA",UF="MA"}
            };

            pracas.ForEach(s => context.Pracas.Add(s));
            context.SaveChanges();
        }

    }
}