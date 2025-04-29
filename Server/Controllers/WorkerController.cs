using BL.API;
using Dal;
using Dal.API;
using Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IBLWorker worker;
        public WorkerController(IBL bl) 
        {
            worker = bl.blWorker;
        }
        [HttpGet]
        public ActionResult<List<Worker>> GetWorkers() => worker.Read();

        [HttpPost]
        public void CreateWorker([FromBody] Worker newWorker)
        {
            worker.Create(newWorker);
        }

        [HttpPut]
        public void UpdateWorker([FromBody] Worker updatedWorker)
        {
            worker.Update(updatedWorker);
        }
        [HttpDelete]
        public void DeleteWorker([FromBody] Worker deleteWorker)
        {

            worker.Delete(deleteWorker);
        }
    }
}
