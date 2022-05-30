using System;
using RSVPinvites.Data;
using RSVPinvites.Models;
using System.Collections.Generic;


namespace RSVPinvites.Interfaces
{
    public class WeddingInvitesRepo : IWeddingInvites
    {
        private readonly AppDbContext _databaseContext;

        public WeddingInvitesRepo(AppDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public IEnumerable<RSVPinvite> GetAListOfAllGuest()
        {
            List<RSVPinvite> GuestList = _databaseContext.RSVPinvites.ToList();
            return GuestList;
        }
        

        public void RSVPform(RSVPinvite dataInput)
        {
            _databaseContext.RSVPinvites.Add(dataInput);
            _databaseContext.SaveChanges();
        }


        public void ResetGuestsList()
        {
            var data = _databaseContext.RSVPinvites.ToList();
            foreach(var item in data)
            {
                _databaseContext.RSVPinvites.Remove(item);
                _databaseContext.SaveChanges();
            }
            
        }
    }
}
