using BoxOfficeASP.Context;
using BoxOfficeASP.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoxOfficeASP.Controllers
{
    public class PurchaseController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, mDataBase.Seances);
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody] Purchase purchase)
        {
            purchase.TimeSelling = DateTime.Now;
            purchase.Seance = null;

            mDataBase.Purchases.Add(purchase);
            mDataBase.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Order Accepted");
        }

        private BoxOfficeContext mDataBase = new BoxOfficeContext();
    }
}
