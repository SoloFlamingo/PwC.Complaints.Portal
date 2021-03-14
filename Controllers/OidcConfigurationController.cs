using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PwC.Complaints.Portal.Controllers
{
    public class OidcConfigurationController : Controller
    {
        //private readonly ILogger<OidcConfigurationController> Logger;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider
            //, ILogger<OidcConfigurationController> logger
            )
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            //Logger = logger;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute]string clientId)
        {
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}
