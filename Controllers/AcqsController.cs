using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    public class AcqsController : ControllerBase
    {
        private readonly DataContext db;

        public AcqsController(DataContext context)
        {
            db = context;
        }
        [HttpGet]
        public IEnumerable<Acq> GetClients()
        {
            return db.Acqs.ToList();
        }
        [HttpGet("{id}")]
        public Acq GetAcq(int id)
        {
            return db.Acqs.Where(p => p.IdAcq == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveAcq([FromBody] Acq acq)
        {
            db.Acqs.Add(acq);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateAcq([FromBody] Acq acq)
        {
            db.Acqs.Update(acq);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteAcq(long id)
        {
            db.Acqs.Remove(db.Acqs.Where(p => p.IdAcq == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
