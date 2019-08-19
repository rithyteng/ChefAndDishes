using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefanddishes.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace chefanddishes.Controllers
{
    
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Chef> chefList = dbContext.Chefs.Include(x=>x.MyDish).ToList();
            

            return View("Index",chefList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("/dishes")]
        public IActionResult GoToDish(){
            List<Dishes> dishList = dbContext.Dishes.Include(x=>x.myChef).ToList();

            return View("ShowDish",dishList);
        }
        [HttpGet("/AddDish")]
        public IActionResult AddADish(){
            var stuf = dbContext.Chefs.ToList();
            // For Chefs Lookat MyContext.cs to match it;
            ViewBag.AllChef = stuf;
            return View("AddDish");
        }
        [HttpGet("/new")]
        public IActionResult AddChef(){
            return View("AddChef");
        }
        [HttpPost("/addadish")]
        public IActionResult AddingDish(Dishes mydish){
            if(ModelState.IsValid){
                dbContext.Add(mydish);
                dbContext.SaveChanges();
                return RedirectToAction("GoToDish");
            }
            return View("AddDish");

        }

        [HttpPost("/addchef")]
        public IActionResult AddingChef(Chef mychef){
            if(ModelState.IsValid){
                string now = DateTime.Now.ToString("yyyyMMdd");
                string dobchef = mychef.DOB.ToString("yyyyMMdd");
                
                string dobchefyear="";
                string dobchefmonth="";
                string dobchefdate="";
                string nowofyear="";
                string nowofmonth="";
                string nowofdate="";


                for(int i =0; i <4; i ++){
                    dobchefyear += dobchef[i];
                }
                for(int i =4; i<6;i++){
                    dobchefmonth +=dobchef[i];
                }
                for(int i =6; i<8;i++){
                    dobchefdate +=dobchef[i];
                }
                //----------------------------------------------------------------
                for(int i =0; i <4; i ++){
                    nowofyear += now[i];
                }
                for(int i =4; i<6;i++){
                    nowofmonth +=now[i];
                }
                for(int i =6; i<8;i++){
                    nowofdate +=now[i];
                }

                int nowofyear2 = Int32.Parse(nowofyear);
                int dobchefyear2 = Int32.Parse(dobchefyear);

                int nowofmonth2 = Int32.Parse(nowofmonth);
                int dobchefmonth2 = Int32.Parse(dobchefmonth);

                int nowofdate2 = Int32.Parse(nowofdate);
                int dobchefdate2 = Int32.Parse(dobchefdate);

                if(dobchefdate2>=nowofdate2){
                    if(dobchefmonth2>=nowofmonth2){
                        if(dobchefyear2>=nowofyear2){
                            ModelState.AddModelError("DOB","Date of Birth Must Be In The Future");
                                return View("AddChef");
                        }
                    }
                }
                if(nowofyear2-dobchefyear2<18){
                    ModelState.AddModelError("DOB","Chef Musts Be At Least 18 Years Old");
                        return View("AddChef");
                }
                if(nowofyear2-dobchefyear2==18){
                    if(nowofmonth2-dobchefmonth2<0){
                        ModelState.AddModelError("DOB","Chef Musts Be At Least 18 Years Old");
                            return View("AddChef");
                    }
                    if(nowofmonth2-dobchefmonth2==0){
                        if(nowofdate2-dobchefdate2<0){
                        ModelState.AddModelError("DOB","Chef Musts Be At Least 18 Years Old");
                            return View("AddChef");
                        }
                    }
                }

                dbContext.Add(mychef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
