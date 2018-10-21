using AutoMapper;
using NHSHealthCareSolution.Core.ViewModel;
using NHSHealthCareSolution.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NHSHealthCareSolution.Controllers
{
    public class PatientsController : Controller
    {
        private readonly NHSHealthContext db;
        public PatientsController()
        {
            db = new NHSHealthContext();
        }

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            var patienList = await db.Patients.ToListAsync();
            var patientModel = Mapper.Map<List<PatientViewModel>>(patienList);
            return View(patientModel);
        }


        public ActionResult Report()
        {
            var patienList = db.Patients.ToList();
            var patientModelList = Mapper.Map<List<PatientViewModel>>(patienList);
            var bmiReports = (from p in patientModelList
                              where p.Age >= 18
                              group p by p.BmiCategory into patientGroup
                              select new BmiReportViewModel
                              {
                                  BmiCategory = patientGroup.Key,
                                  PatientCount = patientGroup.Count()
                              }).ToList();

            return View("Report", bmiReports);
        }
        // GET: Patients/Create
        public ActionResult Create()
        {
            var patientModel = new PatientFormViewModel { Heading = "Add a patient" };
            return View("PatientFormView", patientModel);
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Height,Weight,DateOfBirth")] PatientFormViewModel patientModel)
        {
            if (patientModel.DateOfBirth.GetCurrentAge() < 18)
            {
                ModelState.AddModelError("Age", "Patient is  not adult!");
            }

            if (!ModelState.IsValid)
            {
                return View("PatientFormView", patientModel);
            }

            var patient = Mapper.Map<Patient>(patientModel);
            db.Patients.Add(patient);
            db.SaveChanges();
            return RedirectToAction("Report");
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patient = db.Patients.FirstOrDefault(p => p.Id == id.Value);
            if (patient == null)
            {
                return HttpNotFound();
            }

            var patientModel = Mapper.Map<PatientFormViewModel>(patient);
            patientModel.Heading = "Edit patient details";
            return View("PatientFormView", patientModel);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PatientFormViewModel patientModel)
        {
            if (patientModel.DateOfBirth.GetCurrentAge() < 18)
            {
                ModelState.AddModelError("Age", "Patient is  not adult!");
            }
            if (!ModelState.IsValid)
            {
                return View("PatientFormView", patientModel);
            }

            var patient = db.Patients.FirstOrDefault(p => p.Id == patientModel.Id);

            if (patient == null)
                return HttpNotFound();

            patient.Name = patientModel.Name;
            patient.Weight = patientModel.Weight;
            patient.Height = patientModel.Height;
            patient.DateOfBirth = patientModel.DateOfBirth;
            patient.BmiCategory = patientModel.BmiCategory;
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Patients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient patient = await db.Patients.FindAsync(id);
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
