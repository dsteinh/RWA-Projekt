using Microsoft.AspNet.Identity;
using Recaptcha.Web.Mvc;
using RWA_Projekt_MVC.Dal;
using RWA_Projekt_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RWA_Projekt_MVC.Controllers
{
    //    Rate sistem:
    //https://www.dotnetfunda.com/articles/show/3438/star-rating-system-in-aspnet-mvc
    public class HomeController : Controller
    {
        RwaAparmentsContext context = new RwaAparmentsContext();

        public ActionResult Index()
        {
            //if (HttpContext.Request.Cookies["sort"] != null)
            //{
            //    HttpCookie cookie = HttpContext.Request.Cookies.Get("sort");
            //    return RedirectToAction("GetSortRecord", "Home", new { SortType = cookie.Value });

            //}
            

            return View(context);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Apartment apartment = context.Apartments.ToList().Find(a => a.Id == id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentsId = id.Value;

            var reviews = context.ApartmentReviews.Where(a => a.ApartmentId == apartment.Id).ToList();
            ViewBag.Comments = reviews;

            var ratings = context.ApartmentReviews.Where(r => r.ApartmentId == apartment.Id).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(r => r.Stars.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(apartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var apartmentId = int.Parse(form["ApartmentId"]);
            var rating = int.Parse(form["Rating"]);

            int userId = int.Parse(User.Identity.GetUserId());
            TempData["userId"] = userId;

            ApartmentReview artComment = new ApartmentReview()
            {
                ApartmentId = apartmentId,
                Details = comment,
                Stars = rating,
                CreatedAt = DateTime.Now,
                UserId = (int)TempData["userId"]
            };

            context.ApartmentReviews.Add(artComment);
            context.SaveChanges();

            return RedirectToAction("Details", "Home", new { Id = apartmentId });
        }
        [HttpGet]

        public ActionResult Reserve(int id)
        {

            Apartment apartment = context.Apartments.ToList().Find(a => a.Id == id);
            if (Request.IsAuthenticated)
            {
                int userId = int.Parse(User.Identity.GetUserId());
                TempData["userId"] = userId;
            }

            ApartmentReservation apartmentReservation = new ApartmentReservation();
            TempData["apId"] = id;

            return View(apartmentReservation);
        }

        [HttpPost]
        public ActionResult Reserve(ApartmentReservation ar)
        {
            var aptId = int.Parse(RouteData.Values["id"] + Request.Url.Query);
            if (Request.IsAuthenticated)
            {
                ar.UserId = (int)TempData["userId"];
            }
            ar.ApartmentId = aptId;
            ar.Guid = Guid.NewGuid();
            ar.CreatedAt = DateTime.Now;

            if (!Request.IsAuthenticated)
            {
                var recaptchaHelper = this.GetRecaptchaVerificationHelper();
                if (String.IsNullOrEmpty(recaptchaHelper.Response))
                {
                    ModelState.AddModelError(
                        "",
                        "Captcha answer cannot be empty.");
                    return View(ar);
                }
                var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
                if (!recaptchaResult.Success)
                {
                    ModelState.AddModelError(
                        "",
                        "Incorrect captcha answer.");
                    return View(ar);
                }
            }
            if (ModelState.IsValid || Request.IsAuthenticated)
            {
                context.ApartmentReservations.Add(ar);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(ar);

        }
        public ActionResult GetSearchRecord(string SearchText)
        {

            List<Apartment> ApaList = context.Apartments.Where(x => x.Name.Contains(SearchText)).ToList();
            return PartialView("_ApartmentCard", ApaList);
        }
        public ActionResult GetFilterCityRecord(string SearchText)
        {
            List<Apartment> ApaList;
            if (SearchText == "default")
            {
                ApaList = context.Apartments.ToList();
            }
            else
            {
                ApaList = context.Apartments.Where(x => x.City.Name == SearchText).ToList();
            }
            return PartialView("_ApartmentCard", ApaList);
        }
        public ActionResult GetFilterRecord(int TotalRooms)
        {
            List<Apartment> ApaList;
            if (TotalRooms == -1)
            {
                ApaList = context.Apartments.ToList();
            }
            else
            {
                ApaList = context.Apartments.Where(x => x.TotalRooms == TotalRooms).ToList();
            }
            return PartialView("_ApartmentCard", ApaList);
        }

        public ActionResult GetSortRecord(string SortType)
        {
            List<Apartment> ApaList = context.Apartments.ToList();
            HttpCookie cookie = new HttpCookie("sort");
            cookie.Value = SortType;
            HttpContext.Response.Cookies.Remove("sort");
            HttpContext.Response.SetCookie(cookie);
            switch (SortType)
            {
                case "asc":
                    ApaList.Sort((a, b) => a.Price.CompareTo(b.Price));
                    break;
                case "desc":
                    ApaList.Sort((a, b) => b.Price.CompareTo(a.Price));
                    break;
                default:
                    ApaList.Sort((a, b) => a.Id.CompareTo(b.Id));
                    break;
            }
            return PartialView("_ApartmentCard", ApaList);
        }
    }
}