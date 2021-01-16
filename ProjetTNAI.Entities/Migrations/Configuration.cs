﻿using ProjetTNAI.Entities.Models;

namespace ProjetTNAI.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetTNAI.Entities.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetTNAI.Entities.AppDbContext context)
        {
            if (!context.Plany.Any())
            {
                var plan = new Plan()
                {
                    Nazwa = "Testowy",
                    Rok = "Drugi",
                    Grupa = "Niebieska",
                    KluczEdycji = "superTajne"
                };

                context.Plany.Add(plan);
                context.SaveChanges();

                // Przykladowe zajecia
                if (!context.Zajecia.Any())
                {
                    var zajecia = new Zajecia()
                    {
                        Nazwa = "Testowe Zajecia",
                        PlanId = plan.Id,
                        Godzina = 10,
                        CzasTrwania = 2,
                        DzienTygodnia = 3,
                        LinkDoZajec = "www.test.pl"
                    };

                    var zajecia2 = new Zajecia()
                    {
                        Nazwa = "Inne Testowe Zajecia",
                        PlanId = plan.Id,
                        Godzina = 12,
                        CzasTrwania = 1,
                        DzienTygodnia = 3,
                        LinkDoZajec = "www.testoweInne.pl"
                    };

                    context.Zajecia.Add(zajecia);
                    context.Zajecia.Add(zajecia2);
                    context.SaveChanges();
                }

            }
        }
    }
}