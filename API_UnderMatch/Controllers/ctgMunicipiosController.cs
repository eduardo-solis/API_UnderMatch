using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API_UnderMatch.Models;

namespace API_UnderMatch.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ctgMunicipiosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgMunicipios
        public IQueryable<ctgMunicipios> GetctgMunicipios(int idEstado)
        {
            List<Estados_Municipios> estadosMunicipios = db.Estados_Municipios.Where(e => e.IdEstado == idEstado).ToList();
            List<int> idsMunicipios = new List<int>();

            for (int i = 0; i < estadosMunicipios.Count; i++)
            {
                idsMunicipios.Add(estadosMunicipios[i].IdMunicipio);
            }

            List<ctgMunicipios> municipios = db.ctgMunicipios.Where(m => idsMunicipios.Contains(m.IdMunicipio)).ToList();

            return municipios.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgMunicipiosExists(int id)
        {
            return db.ctgMunicipios.Count(e => e.IdMunicipio == id) > 0;
        }
    }
}