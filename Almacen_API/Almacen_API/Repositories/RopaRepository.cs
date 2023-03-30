using Almacen_API.Contracts;
using Almacen_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_API.Repositories
{
    public class RopaRepository : IRopaRepository
    {

        const string JSON_PATH = @"C:\Users\I40265\source\repos\Almacen_API\Almacen_API\Resources\Almacen.json";

        private string GetRopaFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }

        private void UpdateRopa(List<Ropa> ropaList)
        {
            var ropaJson = JsonConvert.SerializeObject(ropaList, Formatting.Indented);
            File.WriteAllText(JSON_PATH, ropaJson);
        }

        public void AddArticle(Ropa ropa)
        {
            var ropas = GetRopas();
            var existsRopa = ropas.Exists(a => a.Id == ropa.Id);
            if (existsRopa)
            {
                throw new Exception("Ya existe una prenda con este id");
            }
            ropas.Add(ropa);
            UpdateRopa(ropas);
        }

        public void AddArticleStock(int id, int cantidad)
        {
            var ropas = GetRopas();
            var ropa = ropas.FirstOrDefault(a => a.Id == id);


            if (ropa == null)
            {
                throw new Exception("No se encontro ningun articulo con ese id");
            }
            else
            {
                ropa.cantidad += cantidad;
            }

            UpdateRopa(ropas);
        }

        public List<Ropa> GetRopas()
        {
            try
            {
                var ropaFromFile = GetRopaFromFile();
                List<Ropa> ropas = JsonConvert.DeserializeObject<List<Ropa>>(ropaFromFile);
                return ropas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveArticleStock(int id, int cantidad)
        {
            var ropas = GetRopas();
            var ropa = ropas.FirstOrDefault(a => a.Id == id);


            if (ropa == null)
            {
                throw new Exception("No se encontro ningun articulo con ese id");
            }
            else if (ropa.cantidad < cantidad)
            {
                throw new Exception("No hay suficientes cantidades de este producto");
            }
            else
            {
                ropa.cantidad -= cantidad;
            }

            UpdateRopa(ropas);
        }

        public void UpdateRopa(Ropa ropaActualizada)
        {
            var listaRopas = GetRopas();
            var ropa = listaRopas.FirstOrDefault(a => a.Id == ropaActualizada.Id);

            if (ropa == null)
            {
                throw new Exception("No se encontro ninguna ropa con ese id");
            }

            listaRopas[listaRopas.IndexOf(ropa)] = ropaActualizada;
            UpdateRopa(listaRopas);
        }
    }
}
