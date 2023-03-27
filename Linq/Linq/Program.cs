using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public double Temperature { get; set; }
        public int HeartRate { get; set; }
        public string Specialty { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nLastname: {Lastname}\nSex: {Sex}\nTemperature: {Temperature}\nHeartRate: {HeartRate}\nSpecialty: {Specialty}\nAge: {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>() {
                new Patient {
                    Id = 1,
                    Name = "John",
                    Lastname = "Doe",
                    Sex = "Male",
                    Temperature = 36.8,
                    HeartRate = 80,
                    Specialty = "general medicine",
                    Age = 44
                },
                new Patient {
                    Id = 2,
                    Name = "Jane",
                    Lastname = "Doe",
                    Sex = "Female",
                    Temperature = 36.8,
                    HeartRate = 70,
                    Specialty = "general medicine",
                    Age = 43
                },
                new Patient {
                    Id = 3,
                    Name = "Junior",
                    Lastname = "Doe",
                    Sex = "Male",
                    Temperature = 36.8,
                    HeartRate = 90,
                    Specialty = "pediatrics",
                    Age = 8
                },
                new Patient {
                    Id = 4,
                    Name = "Mary",
                    Lastname = "Wien",
                    Sex = "Female",
                    Temperature = 36.8,
                    HeartRate = 120,
                    Specialty = "general medicine",
                    Age = 20
                },
                new Patient {
                    Id = 5,
                    Name = "Scarlett",
                    Lastname = "Somez",
                    Sex = "Female",
                    Temperature = 36.8,
                    HeartRate = 110,
                    Specialty = "general medicine",
                    Age = 30
                },
                new Patient {
                    Id = 6,
                    Name = "Brian",
                    Lastname = "Kid",
                    Sex = "Male",
                    Temperature = 39.8,
                    HeartRate = 80,
                    Specialty = "pediatrics",
                    Age = 11
                }
            };

            // 1 - Extraer la lista de pacientes que sean de la especialidad pediatrics y que tengan menos de 10 años.
            var query1 = patients.Where(s => s.Specialty.Equals("pediatrics")).Where(s => s.Age < 10).ToList();
            Console.WriteLine("--------------------------------------------------------------\nESPECIALIDAD PEDIATRICS Y MENOS DE 10 ANOS:\n--------------------------------------------------------------");
            foreach (Patient query in query1)
            {
                Console.WriteLine(query.ToString());
            }

            // 2 - Queremos activar el protocolo de urgencia si hay algún paciente con ritmo cardíaco mayor que 100 o temperatura mayor a 39.
            var query2 = patients.Where(x => x.HeartRate > 100 || x.Temperature > 39);
            Console.WriteLine("--------------------------------------------------------------\nACTIVANDO EL PROTOCOLO DE EMERGENCIA PARA LOS SIGUINETES PACIENTES:\n--------------------------------------------------------------");
            foreach (Patient query in query2)
            {
                Console.WriteLine(query.ToString());
            }

            // 3 - No podemos atender a todos los pacientes hoy por lo que vamos a crear una nueva coleccion y reasignar a los pacientes de pediatrics a general medicine 

            var query3 = patients.Where(p => p.Specialty == "pediatrics");
            Console.WriteLine("--------------------------------------------------------------\nNO PODEMOS ATENDEROS A TODOS, CAMBIANDO LA ESPECIALIDAD A MEDICINA GENERAL EN LOS SIGUINETES PACIENTES:\n--------------------------------------------------------------");
            foreach (Patient patient in query3)
            {
                patient.Specialty = "general medicine";
                Console.WriteLine(patient.ToString());
                patient.Specialty = "pediatrics";
            }

            // 4 - Queremos conocer de una sola consulta el numero de pacientes que estan asignado a general medicine y a pediatrics.

            int[] query4 = patients.Where(p => p.Specialty == "general medicine" || p.Specialty == "pediatrics").GroupBy(p => p.Specialty).Select(g => g.Count()).ToArray();
            Console.WriteLine("--------------------------------------------------------------\nNUMERO DE PACIENTES EN GENERAL MEDICINE:\n--------------------------------------------------------------");
            Console.WriteLine(query4[0]);
            Console.WriteLine("--------------------------------------------------------------\nNUMERO DE PACIENTES EN PEDIATRICS:\n--------------------------------------------------------------");
            Console.WriteLine(query4[1]);


            // 5 - Devuelve una lista nueva que por cada paciente se indique si tiene prioridad o no. Se tendrá prioridad si el ritmo cardiaco es mayor 100 o la temperatura es mayor a 39.
            var query5 = patients.Select(p => new {Patient = p, HasPriority = p.HeartRate > 100 || p.Temperature > 39}).ToList();

            Console.WriteLine("--------------------------------------------------------------\nLISTA DE PACIENTES CON PRIORIDAD:\n--------------------------------------------------------------");
            foreach (var query in query5)
            {
                Console.WriteLine($"{query.Patient.Name} {query.Patient.Lastname} - Prioridad: {(query.HasPriority)}");
            }

            // 6 - Queremos conocer de una sola consulta La edad media de pacientes asignados a pediatrics y general medicine.
            var query6 = patients.Where(p => p.Specialty == "general medicine" || p.Specialty == "pediatrics").GroupBy(p => p.Specialty).Select(g => new { Specialty = g.Key, averageAge = g.Average(a => a.Age)});

            Console.WriteLine("--------------------------------------------------------------\nEDAD MEDIA DE PACIENTES ASIGNADOS A PEDIATRICS Y GENERAL MEDICINE:\n--------------------------------------------------------------");
            foreach (var item in query6)
            {
                Console.WriteLine($"{item.Specialty}: {item.averageAge} años");
            }

            Console.Read();
        }
    }
}
