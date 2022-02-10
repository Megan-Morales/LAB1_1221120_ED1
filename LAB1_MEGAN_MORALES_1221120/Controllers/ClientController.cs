using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB1_MEGAN_MORALES_1221120.Helpers;
using LAB1_MEGAN_MORALES_1221120.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB1_MEGAN_MORALES_1221120.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        public ActionResult Index()
        {
            return View(Singelton.Instance.ClientList);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            var Client = Singelton.Instance.ClientList.Find(clients => clients.Id == id);
            return View(Client);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View(new ClientModel());
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var response = ClientModel.Save(new ClientModel
                {
                    Id = Convert.ToInt32(Singelton.Instance.ClientList.Count),
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Phone = Convert.ToInt32(collection["Phone"]),
                    Description = collection["Description"]
                });

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag["Error"] = "Error while creating new element";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = Singelton.Instance.ClientList.Find(client => client.Id == id);

            return View(edit);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Singelton.Instance.ClientList.Find(client => client.Id == id).Name = collection["Name"];
                Singelton.Instance.ClientList.Find(client => client.Id == id).LastName = collection["LastName"];
                Singelton.Instance.ClientList.Find(client => client.Id == id).Phone = Convert.ToInt32(collection["Phone"]);
                Singelton.Instance.ClientList.Find(client => client.Id == id).Description = collection["Description"];
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Singelton.Instance.ClientList.Find(client => client.Id == id);
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var deleteClient = Singelton.Instance.ClientList.Find(x => x.Id == id);
                Singelton.Instance.ClientList.Remove(deleteClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SortbyName(int id)
        {
            
            for (int i = 0; i < Singelton.Instance.ClientList.Count - 1; i++)
            {
                for (int j = i + 1; j < Singelton.Instance.ClientList.Count; j++)
                {
                    if (Singelton.Instance.ClientList[j].Name.CompareTo(Singelton.Instance.ClientList[i].Name) < 0)
                    {
                        var temp = Singelton.Instance.ClientList[j];
                        Singelton.Instance.ClientList[j] = Singelton.Instance.ClientList[i];
                        Singelton.Instance.ClientList[i] = temp;
                    }
                }
            }
            return View(Singelton.Instance.ClientList);
        }

        public ActionResult SortbyLastName(int id)
        {
            
            for (int i = 0; i < Singelton.Instance.ClientList.Count - 1; i++)
            {
                for (int j = i + 1; j < Singelton.Instance.ClientList.Count; j++)
                {
                    if (Singelton.Instance.ClientList[j].LastName.CompareTo(Singelton.Instance.ClientList[i].LastName) < 0)
                    {
                        var temp = Singelton.Instance.ClientList[j];
                        Singelton.Instance.ClientList[j] = Singelton.Instance.ClientList[i];
                        Singelton.Instance.ClientList[i] = temp;
                    }
                }
            }
            return View(Singelton.Instance.ClientList);
        }

        public ActionResult SortbyX(int id)
        {

            for (int i = 0; i < Singelton.Instance.ClientList.Count - 1; i++)
            {
                for (int j = i + 1; j < Singelton.Instance.ClientList.Count; j++)
                {
                    if (Singelton.Instance.ClientList[j].Id < (Singelton.Instance.ClientList[i].Id))
                    {
                        var temp = Singelton.Instance.ClientList[j];
                        Singelton.Instance.ClientList[j] = Singelton.Instance.ClientList[i];
                        Singelton.Instance.ClientList[i] = temp;
                    }
                }
            }
            return View(Singelton.Instance.ClientList);
        }

    }
}
