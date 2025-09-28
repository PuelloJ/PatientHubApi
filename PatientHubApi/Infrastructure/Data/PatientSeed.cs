using PatientHubApi.Core.Entities;

namespace PatientHubApi.Infrastructure.Data;

public static class PatientSeed
{
    public static List<Patient> GetSeedData()
    {
        return new List<Patient>
        {
            // Registros Civiles (RC) - Menores de 7 años
            new Patient
            {
                DocumentType = "RC",
                DocumentNumber = "1234567890123",
                FirstName = "Santiago",
                LastName = "Rodríguez García",
                BirthDate = new DateTime(2020, 3, 15),
                PhoneNumber = "+57 310 123 4567",
                Email = null
            },
            new Patient
            {
                DocumentType = "RC",
                DocumentNumber = "9876543210987",
                FirstName = "Valentina",
                LastName = "Morales Jiménez",
                BirthDate = new DateTime(2021, 7, 22),
                PhoneNumber = "+57 315 987 6543",
                Email = null
            },
            new Patient
            {
                DocumentType = "RC",
                DocumentNumber = "1122334455667",
                FirstName = "Mateo",
                LastName = "González Vargas",
                BirthDate = new DateTime(2019, 12, 8),
                PhoneNumber = "+57 300 112 2334",
                Email = null
            },

            // Tarjetas de Identidad (TI) - Menores de 18 años
            new Patient
            {
                DocumentType = "TI",
                DocumentNumber = "98765432101",
                FirstName = "Isabella",
                LastName = "Hernández Ruiz",
                BirthDate = new DateTime(2010, 5, 18),
                PhoneNumber = "+57 320 456 7890",
                Email = "isabella.hernandez@estudiante.edu.co"
            },
            new Patient
            {
                DocumentType = "TI",
                DocumentNumber = "87654321012",
                FirstName = "Sebastián",
                LastName = "López Castañeda",
                BirthDate = new DateTime(2008, 9, 25),
                PhoneNumber = "+57 318 765 4321",
                Email = "sebastian.lopez@colegio.edu.co"
            },
            new Patient
            {
                DocumentType = "TI",
                DocumentNumber = "76543210123",
                FirstName = "Sofía",
                LastName = "Martínez Ospina",
                BirthDate = new DateTime(2012, 2, 14),
                PhoneNumber = "+57 314 567 8901",
                Email = null
            },
            new Patient
            {
                DocumentType = "TI",
                DocumentNumber = "65432101234",
                FirstName = "Alejandro",
                LastName = "Ramírez Parra",
                BirthDate = new DateTime(2009, 11, 30),
                PhoneNumber = "+57 312 890 1234",
                Email = "alejandro.ramirez@gmail.com"
            },

            // Cédulas de Ciudadanía (CC) - Adultos
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1012345678",
                FirstName = "María Fernanda",
                LastName = "Gutiérrez Peña",
                BirthDate = new DateTime(1985, 4, 12),
                PhoneNumber = "+57 301 234 5678",
                Email = "maria.gutierrez@hotmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1123456789",
                FirstName = "Carlos Andrés",
                LastName = "Vásquez Molina",
                BirthDate = new DateTime(1990, 8, 7),
                PhoneNumber = "+57 305 123 4567",
                Email = "carlos.vasquez@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1234567890",
                FirstName = "Ana Lucía",
                LastName = "Torres Delgado",
                BirthDate = new DateTime(1978, 1, 25),
                PhoneNumber = "+57 320 987 6543",
                Email = "ana.torres@outlook.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1345678901",
                FirstName = "Jorge Luis",
                LastName = "Mendoza Silva",
                BirthDate = new DateTime(1982, 6, 18),
                PhoneNumber = "+57 315 456 7890",
                Email = "jorge.mendoza@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1456789012",
                FirstName = "Claudia Patricia",
                LastName = "Ramos Quintero",
                BirthDate = new DateTime(1975, 10, 3),
                PhoneNumber = "+57 310 765 4321",
                Email = "claudia.ramos@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1567890123",
                FirstName = "Julián David",
                LastName = "Cárdenas Herrera",
                BirthDate = new DateTime(1993, 3, 28),
                PhoneNumber = "+57 318 234 5678",
                Email = "julian.cardenas@hotmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1678901234",
                FirstName = "Diana Carolina",
                LastName = "Salazar Moreno",
                BirthDate = new DateTime(1987, 12, 15),
                PhoneNumber = "+57 300 345 6789",
                Email = "diana.salazar@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1789012345",
                FirstName = "Ricardo",
                LastName = "Pedraza Aguilar",
                BirthDate = new DateTime(1980, 5, 9),
                PhoneNumber = "+57 312 456 7890",
                Email = "ricardo.pedraza@outlook.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1890123456",
                FirstName = "Luz Marina",
                LastName = "Bermúdez Castro",
                BirthDate = new DateTime(1973, 9, 21),
                PhoneNumber = "+57 314 567 8901",
                Email = "luz.bermudez@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "1901234567",
                FirstName = "Andrés Felipe",
                LastName = "Vargas Rodríguez",
                BirthDate = new DateTime(1995, 2, 6),
                PhoneNumber = "+57 316 678 9012",
                Email = "andres.vargas@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2012345678",
                FirstName = "Paola Andrea",
                LastName = "Jiménez Sánchez",
                BirthDate = new DateTime(1989, 7, 14),
                PhoneNumber = "+57 320 789 0123",
                Email = "paola.jimenez@hotmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2123456789",
                FirstName = "Fabián",
                LastName = "Cortés Londoño",
                BirthDate = new DateTime(1981, 11, 27),
                PhoneNumber = "+57 301 890 1234",
                Email = "fabian.cortes@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2234567890",
                FirstName = "Natalia",
                LastName = "Acosta Pineda",
                BirthDate = new DateTime(1992, 4, 2),
                PhoneNumber = "+57 305 901 2345",
                Email = "natalia.acosta@outlook.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2345678901",
                FirstName = "Mauricio",
                LastName = "Restrepo Gómez",
                BirthDate = new DateTime(1977, 8, 19),
                PhoneNumber = "+57 318 012 3456",
                Email = "mauricio.restrepo@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2456789012",
                FirstName = "Carolina",
                LastName = "Navas Suárez",
                BirthDate = new DateTime(1986, 1, 11),
                PhoneNumber = "+57 315 123 4567",
                Email = "carolina.navas@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2567890123",
                FirstName = "Diego Alejandro",
                LastName = "Montes Valencia",
                BirthDate = new DateTime(1991, 6, 24),
                PhoneNumber = "+57 310 234 5678",
                Email = "diego.montes@hotmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2678901234",
                FirstName = "Yolanda",
                LastName = "Betancur Ríos",
                BirthDate = new DateTime(1974, 10, 16),
                PhoneNumber = "+57 312 345 6789",
                Email = "yolanda.betancur@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2789012345",
                FirstName = "Óscar Eduardo",
                LastName = "Patiño Mejía",
                BirthDate = new DateTime(1988, 3, 5),
                PhoneNumber = "+57 314 456 7890",
                Email = "oscar.patino@outlook.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2890123456",
                FirstName = "Liliana",
                LastName = "Carvajal Orozco",
                BirthDate = new DateTime(1983, 12, 8),
                PhoneNumber = "+57 316 567 8901",
                Email = "liliana.carvajal@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "2901234567",
                FirstName = "Hernán",
                LastName = "Buitrago Escobar",
                BirthDate = new DateTime(1979, 5, 22),
                PhoneNumber = "+57 320 678 9012",
                Email = "hernan.buitrago@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3012345678",
                FirstName = "Sandra Milena",
                LastName = "Rojas Echeverri",
                BirthDate = new DateTime(1994, 9, 13),
                PhoneNumber = "+57 301 789 0123",
                Email = "sandra.rojas@hotmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3123456789",
                FirstName = "Luis Carlos",
                LastName = "Giraldo Arango",
                BirthDate = new DateTime(1976, 2, 28),
                PhoneNumber = "+57 305 890 1234",
                Email = "luis.giraldo@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3234567890",
                FirstName = "Adriana",
                LastName = "Franco Cardona",
                BirthDate = new DateTime(1990, 7, 17),
                PhoneNumber = "+57 318 901 2345",
                Email = "adriana.franco@outlook.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3345678901",
                FirstName = "Jaime",
                LastName = "Muñoz Bedoya",
                BirthDate = new DateTime(1984, 11, 4),
                PhoneNumber = "+57 315 012 3456",
                Email = "jaime.munoz@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3456789012",
                FirstName = "Rocío",
                LastName = "Velásquez Toro",
                BirthDate = new DateTime(1972, 4, 26),
                PhoneNumber = "+57 310 123 4567",
                Email = "rocio.velasquez@gmail.com"
            },
            new Patient
            {
                DocumentType = "CC",
                DocumentNumber = "3567890123",
                FirstName = "Edison",
                LastName = "Zapata Duque",
                BirthDate = new DateTime(1996, 8, 12),
                PhoneNumber = "+57 312 234 5678",
                Email = "edison.zapata@hotmail.com"
            },

            // Cédulas de Extranjería (CE)
            new Patient
            {
                DocumentType = "CE",
                DocumentNumber = "987654321",
                FirstName = "María José",
                LastName = "Fernández González",
                BirthDate = new DateTime(1985, 3, 15),
                PhoneNumber = "+57 301 555 0001",
                Email = "mariajose.fernandez@gmail.com"
            },
            new Patient
            {
                DocumentType = "CE",
                DocumentNumber = "876543210",
                FirstName = "Juan Carlos",
                LastName = "Mendoza Ruiz",
                BirthDate = new DateTime(1992, 6, 8),
                PhoneNumber = "+57 305 555 0002",
                Email = "juancarlos.mendoza@outlook.com"
            },
            new Patient
            {
                DocumentType = "CE",
                DocumentNumber = "765432109",
                FirstName = "Lucia Elena",
                LastName = "Vargas Silva",
                BirthDate = new DateTime(1988, 11, 22),
                PhoneNumber = "+57 320 555 0003",
                Email = "lucia.vargas@yahoo.com"
            },
            new Patient
            {
                DocumentType = "CE",
                DocumentNumber = "654321098",
                FirstName = "Roberto",
                LastName = "Martinez Pérez",
                BirthDate = new DateTime(1981, 9, 5),
                PhoneNumber = "+57 315 555 0004",
                Email = "roberto.martinez@hotmail.com"
            },

            // Pasaportes (PA)
            new Patient
            {
                DocumentType = "PA",
                DocumentNumber = "AB123456",
                FirstName = "Catherine",
                LastName = "Johnson Smith",
                BirthDate = new DateTime(1987, 2, 14),
                PhoneNumber = "+57 318 555 0005",
                Email = "catherine.johnson@gmail.com"
            },
            new Patient
            {
                DocumentType = "PA",
                DocumentNumber = "CD789012",
                FirstName = "Michael",
                LastName = "Brown Wilson",
                BirthDate = new DateTime(1991, 7, 30),
                PhoneNumber = "+57 310 555 0006",
                Email = "michael.brown@outlook.com"
            },
            new Patient
            {
                DocumentType = "PA",
                DocumentNumber = "EF345678",
                FirstName = "Sophie",
                LastName = "Martin Davis",
                BirthDate = new DateTime(1983, 12, 18),
                PhoneNumber = "+57 312 555 0007",
                Email = "sophie.martin@yahoo.com"
            },
            new Patient
            {
                DocumentType = "PA",
                DocumentNumber = "GH901234",
                FirstName = "Alexander",
                LastName = "Taylor Anderson",
                BirthDate = new DateTime(1995, 5, 3),
                PhoneNumber = "+57 314 555 0008",
                Email = "alexander.taylor@gmail.com"
            }
        };
    }
}