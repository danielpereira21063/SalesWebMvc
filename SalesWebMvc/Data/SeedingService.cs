using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;


        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return;
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Daniel", "daniel.com", new DateTime(1998, 04, 13), 1000, d1);
            Seller s2 = new Seller(2, "Hugo", "hugo.com", new DateTime(1889, 12, 22), 1000, d2);
            Seller s3 = new Seller(3, "Vanessa", "vanessa.com", new DateTime(2002, 03, 21), 3000, d4);
            Seller s4 = new Seller(4, "Guilherme", "guilherme.com", new DateTime(2001, 02, 21), 3200, d2);
            Seller s5 = new Seller(5, "Jhonas", "jhonas.com", new DateTime(2012, 10, 11), 1222, d3);
            Seller s6 = new Seller(6, "Marcos", "marcos.com", new DateTime(1922, 09, 05), 24200, d3);
            Seller s7 = new Seller(7, "Joana", "joana.com", new DateTime(1998, 04, 30), 9000, d2);
            Seller s8 = new Seller(8, "Mirela", "mirela.com", new DateTime(1998, 01, 19), 1100, d1);
            Seller s9 = new Seller(9, "Delacir", "delacir.com", new DateTime(1999, 10, 12), 1650, d4);


            SalesRecord r1 = new SalesRecord(1, new DateTime(2012, 09, 25), 12123, SaleSatus.Pending, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2013, 02, 15), 1242, SaleSatus.Pending, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 09, 22), 3464, SaleSatus.Billed, s2);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2022, 01, 22), 75475, SaleSatus.Canceled, s5);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 04, 1), 8745, SaleSatus.Canceled, s9);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 06, 2), 43636, SaleSatus.Canceled, s3);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 07, 21), 86735, SaleSatus.Pending, s3);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 01, 5), 45737, SaleSatus.Billed, s3);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 02, 2), 3574, SaleSatus.Canceled, s2);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 03, 1), 74747, SaleSatus.Billed, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 3), 36774, SaleSatus.Billed, s4);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 11, 4), 45775, SaleSatus.Pending, s1);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 12, 21), 765467, SaleSatus.Canceled, s1);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 08, 12), 153458100, SaleSatus.Billed, s1);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 09, 11), 46434, SaleSatus.Billed, s5);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 01, 14), 587874, SaleSatus.Billed, s6);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2018, 02, 22), 236467, SaleSatus.Canceled, s8);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2018, 02, 28), 34667, SaleSatus.Pending, s9);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2018, 03, 30), 346577, SaleSatus.Canceled, s7);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2018, 12, 3), 4367886, SaleSatus.Pending, s1);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2018, 12, 25), 4367577, SaleSatus.Billed, s3);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecords.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21);

            _context.SaveChanges();
        }
    }
}
