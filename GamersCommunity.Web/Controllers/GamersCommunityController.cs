using GamersCommunity.Data.Models;
using GamersCommunity.Repo;
using GamersCommunity.Repo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace GamersCommunity.Web.Controllers
{
    [Authorize]
    public class GamersCommunityController : Controller
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly SignInManager<GcUser> _signInManager;
        public GamersCommunityController(IUnitOfWork unitOfWork, SignInManager<GcUser> signInManager)
        {
            this._unitOfWork = unitOfWork as UnitOfWork;
            this._signInManager = signInManager;
        }
        
        #region Genre
        public IActionResult GenreList()
        {
            dynamic model = new ExpandoObject();
            model.ListObj = _unitOfWork.gcGenreRepository.GetAllData();
            return View(model);
        }
        public IActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGenre(GcGenreInformation obj)
        {
            try
            {
                obj.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
                if (_signInManager.IsSignedIn(User))
                    obj.CreatedBy = User.Identity.Name.ToString();
                _unitOfWork.gcGenreRepository.Create(obj);
                await _unitOfWork.CommitAll();
                return RedirectToAction("GenreList", "GamersCommunity");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View();
            }
        }

        public IActionResult UpdateGenre(string Id)
        {
            GcGenreInformation initObj = new GcGenreInformation();
            initObj = _unitOfWork.gcGenreRepository.GetSingleById(Id);
            return View(initObj);
        }

        [HttpPost]
        public IActionResult UpdateGenre(GcGenreInformation obj)
        {
            try
            {
                _unitOfWork.gcGenreRepository.Update(obj);
                return RedirectToAction("GenreList", "GamersCommunity");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View();
            }
        }

        public IActionResult DeleteGenre(string Id)
        {
            try
            {
                _unitOfWork.gcGenreRepository.Delete(Id);
                return RedirectToAction("GenreList", "GamersCommunity");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return RedirectToAction("GenreList", "GamersCommunity");
            }
        }

        #endregion
    }
}