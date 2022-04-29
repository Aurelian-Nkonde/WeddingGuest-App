using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RSVPinvites.Data;
using RSVPinvites.Models;
using RSVPinvites.Interfaces;
using System.Linq;

namespace RSVPinvites.Controllers
{
    public class HomeController: Controller
    {
        private readonly IWeddingInvites _weddingInvitesInterface;

        // constructor dependency injection happening here
        public HomeController(IWeddingInvites weddingInvitesInterface)
        {
            _weddingInvitesInterface = weddingInvitesInterface;
        }


        //Main Index action method
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<RSVPinvite> GettingListOfGuest = _weddingInvitesInterface.GetAListOfAllGuest();
            int DonationsSum = 0;
            foreach(var n in GettingListOfGuest)
            {
                int TakingDonationsOnlyPart = System.Convert.ToInt32(n.Donations);
                DonationsSum += TakingDonationsOnlyPart;
            }
            return View(DonationsSum);
        }


        // renders the form
        [HttpGet]
        public IActionResult RSVPform()
        {
            return View();
        }

        // processes the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RSVPform(RSVPinvite dataInputFromTheForm)
        {
            if(ModelState.IsValid)
            {
                var totalNumberOfGuest = _weddingInvitesInterface.GetAListOfAllGuest().Count();
                if (totalNumberOfGuest <= 10)
                {
                    _weddingInvitesInterface.RSVPform(dataInputFromTheForm);
                    if(dataInputFromTheForm.AreYouAttending == true)
                    {
                        return View("ThankYou", dataInputFromTheForm);
                    }
                    return View("NotComing", dataInputFromTheForm);
                }
                return View("EnoughGuest", dataInputFromTheForm);
            }
            return View(dataInputFromTheForm);
        }


        // renders the view with a list of Guest
        public IActionResult ListOfAttendies()
        {
            IEnumerable<RSVPinvite> data =  _weddingInvitesInterface.GetAListOfAllGuest();
            return View(data);
            
        }


    }
}