using Microsoft.AspNetCore.Mvc;
using WebSignalRAppLesson15.Helpers;

namespace WebSignalRAppLesson15.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    // GET: api/<OfferController>
    //[HttpGet]
    //public double Get()
    //{
    //    return FileHelper.Read();
    //}

    //[HttpGet("Increase")]
    //public void IncreaseOffer(double data)
    //{
    //    var result = FileHelper.Read() + data;
    //    FileHelper.Write(result);
    //}

    // groupping : 
    [HttpGet("RoomCurrent")]
    public double GetCurrent(string room)
    {
        return FileHelper.GetCurrentPrice(room);
    }


    [HttpGet("IncreaseRoom")]
    public void Increase(string room,double data)
    {
      FileHelper.UpdateCarPrice(room, data);
    }

    [HttpGet("RoomInitial")]
    public double GetInitial(string room)
    {
        return FileHelper.GetBeginPrice(room);
    }
}
