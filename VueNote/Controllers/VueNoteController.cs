using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YFPHelper.Helper.Data;

namespace VueNote.Controllers
{
    public class VueNoteController : Controller
    {
        // GET: VueNote
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetJsonData(string search)
        {
            string sql = @" SELECT [ID],[OrderSN],[TicketNo],[ChkTag] 
                            FROM [WEB_BP_NET].[dbo].[XgDpcFileData] WITH(NOLOCK)
                            WHERE TicketNo LIKE @sn";

            var data = SqlHelper.Execute("localhost", sql).AddParameter("@sn", "%" + search + "%").Entities<myModel>();


            var serverModel = JsonConvert.SerializeObject(data);

            return Json(new { serverModel }, JsonRequestBehavior.AllowGet);


        }


        public class myModel
        {
            public int ID { get; set; }
            public string OrderSN { get; set; }
            public string TicketNo { get; set; }
            public int ChkTag { get; set; }
        }
    }
}