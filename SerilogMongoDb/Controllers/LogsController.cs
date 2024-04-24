using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SerilogMongoDb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LogsController : ControllerBase
  {
    private readonly ILogger<LogsController> logger;

    public LogsController(ILogger<LogsController> logger)
    {
      this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Log()
    {
      logger.LogCritical("Uygulamada ciddi bir hata meydana geldi");

      // Custom veriyi log'a bind ettik. Log Stash ile
      logger.LogCritical("Uygulamada ciddi bir hata meydana geldi, {userId}", Guid.NewGuid().ToString());

      return Ok();
    }
  }
}
