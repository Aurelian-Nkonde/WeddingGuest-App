using System;
using RSVPinvites.Models;
using System.Collections.Generic;


namespace RSVPinvites.Interfaces
{
    public interface IWeddingInvites
    {
        IEnumerable<RSVPinvite> GetAListOfAllGuest();
        void RSVPform(RSVPinvite dataInput);
    }
}