using Microsoft.AspNetCore.Mvc;
using NetCoreApiExtensions.Shared.Responses;
using NetCoreApiExtensions.WebApi.Discovery;

namespace NetCoreApiExtensions.WebAip.TestHarness.v1_0.Controllers
{
    /// <summary>
    /// Version 1 test controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [VersionedApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Just Returns true
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DataResponse<bool>> GetBool()
        {
            return await Task.FromResult(DataResponse<bool>.Create(true));
        }
    }
}
